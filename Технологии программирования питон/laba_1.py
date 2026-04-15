import tkinter as tk
from tkinter import ttk, messagebox, filedialog
import logging
import os
import re
from dataclasses import dataclass, asdict
from datetime import datetime
from typing import List

DEFAULT_FILE = "Технологии программирования питон\\data.txt"

logging.basicConfig(
    filename='Технологии программирования питон\\app.log',
    level=logging.INFO,
    format='%(asctime)s - %(levelname)s - %(message)s',
    encoding='utf-8'
)

@dataclass
class CurrencyCourse:
    base_currency: str
    target_currency: str
    rate: float
    date: str

    def to_file_line(self) -> str:
        return f'"{self.base_currency}" "{self.target_currency}" {self.rate} {self.date}\n'

class CurrencyParser:
    @staticmethod
    def parse_line(line: str) -> CurrencyCourse:
        pattern = r'"([^"]*)"\s+"([^"]*)"\s+(\d+[.,]?\d*)\s+(\d{4}\.\d{2}\.\d{2})'
        match = re.search(pattern, line)
        if not match:
            raise ValueError(f"Ошибка формата: {line}")
        
        v1, v2, rate_str, date_str = match.groups()
        return CurrencyCourse(v1, v2, float(rate_str.replace(',', '.')), date_str)

class AddItemDialog(tk.Toplevel):
    def __init__(self, parent):
        super().__init__(parent)
        self.title("Добавить курс")
        self.geometry("350x250")
        self.result = None
        
        labels = ["Валюта 1:", "Валюта 2:", "Курс:", "Дата (гггг.мм.дд):"]
        self.entries = []
        for i, text in enumerate(labels):
            tk.Label(self, text=text).grid(row=i, column=0, padx=10, pady=5, sticky="e")
            e = tk.Entry(self)
            e.grid(row=i, column=1, padx=10, pady=5)
            self.entries.append(e)

        tk.Button(self, text="Сохранить", command=self.save).grid(row=4, column=0, columnspan=2, pady=15)

class AddItemDialog(tk.Toplevel):
    """Окно добавления с раздельными полями и кнопкой сохранения."""
    def __init__(self, parent):
        super().__init__(parent)
        self.title("Добавить курс")
        self.geometry("400x300")  # Увеличили размер, чтобы всё влезло
        self.result = None
        
        # Контейнер для полей ввода (чтобы отделить их от кнопки)
        form_frame = tk.Frame(self)
        form_frame.pack(fill=tk.BOTH, expand=True, padx=20, pady=20)

        labels = ["Валюта 1:", "Валюта 2:", "Курс:", "Дата (гггг.мм.дд):"]
        self.entries = []

        for i, text in enumerate(labels):
            tk.Label(form_frame, text=text).grid(row=i, column=0, pady=10, sticky="w")
            e = tk.Entry(form_frame, width=25)
            e.grid(row=i, column=1, padx=10, pady=10)
            self.entries.append(e)

        # Кнопка сохранения - закрепляем внизу окна
        self.btn_save = tk.Button(
            self, 
            text="💾 Сохранить и записать в файл", 
            command=self.save,
            bg="#e1e1e1",  # Немного цвета для заметности
            font=("Arial", 10, "bold")
        )
        self.btn_save.pack(side=tk.BOTTOM, fill=tk.X, padx=20, pady=20)

        # Делаем окно модальным (блокирует основное, пока не закроют это)
        self.transient(parent)
        self.grab_set()

    def save(self):
        raw_values = [e.get().strip() for e in self.entries]
        v1, v2, rate_str, date_str = raw_values

        try:
            if not all(raw_values):
                raise ValueError("Все поля должны быть заполнены!")

            rate = float(rate_str.replace(',', '.'))
            datetime.strptime(date_str, "%Y.%m.%d")

            # Если всё Ок
            self.result = CurrencyCourse(v1, v2, rate, date_str)
            logging.info(f"Добавлен объект: {v1}-{v2} по курсу {rate}")
            self.destroy()

        except ValueError as e:
            # Логируем ошибку в app.log (Задание 3)
            logging.error(f"Ошибка ручного ввода: {e} | Введено: {raw_values}")
            messagebox.showerror("Ошибка валидации", f"Проверьте данные:\n{e}")


class MainView(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Currency Manager (Auto-Sync)")
        self.geometry("700x400")
        self._setup_ui()

    def _setup_ui(self):
        columns = ("v1", "v2", "rate", "date")
        self.tree = ttk.Treeview(self, columns=columns, show="headings")
        self.tree.heading("v1", text="Валюта 1")
        self.tree.heading("v2", text="Валюта 2")
        self.tree.heading("rate", text="Курс")
        self.tree.heading("date", text="Дата")
        self.tree.pack(fill=tk.BOTH, expand=True, padx=10, pady=10)

        btn_frame = tk.Frame(self)
        btn_frame.pack(fill=tk.X, padx=10, pady=5)

        self.btn_add = tk.Button(btn_frame, text="➕ Добавить", width=15)
        self.btn_add.pack(side=tk.LEFT, padx=5)

        self.btn_delete = tk.Button(btn_frame, text="❌ Удалить", width=15)
        self.btn_delete.pack(side=tk.LEFT, padx=5)
        
        self.lbl_status = tk.Label(self, text="Файл: синхронизирован", fg="green")
        self.lbl_status.pack(side=tk.BOTTOM, anchor="w", padx=10)

class AppPresenter:
    def __init__(self, view: MainView, file_path: str):
        self.view = view
        self.file_path = file_path
        self.items: List[CurrencyCourse] = []
        
        self.view.btn_add.config(command=self.handle_add)
        self.view.btn_delete.config(command=self.handle_delete)
        
        self.load_from_file()

    def load_from_file(self):
        if not os.path.exists(self.file_path):
            logging.warning(f"Файл {self.file_path} не найден. Будет создан новый при сохранении.")
            return

        try:
            with open(self.file_path, 'r', encoding='utf-8') as f:
                lines = f.readlines()
                for i, line in enumerate(lines, 1):
                    line = line.strip()
                    if not line: continue
                    try:
                        obj = CurrencyParser.parse_line(line)
                        self.items.append(obj)
                    except Exception as e:
                        # Логируем некорректную строку и продолжаем работу
                        log_msg = f"Строка {i} пропущена. Причина: {e} | Контент: {line}"
                        logging.error(log_msg)
            self.refresh_ui()
        except Exception as e:
            logging.critical(f"Критическая ошибка доступа к файлу: {e}")
            messagebox.showerror("Ошибка", "Не удалось прочитать файл данных.")

    def save_to_file(self):
        try:
            with open(self.file_path, 'w', encoding='utf-8') as f:
                for item in self.items:
                    f.write(item.to_file_line())
        except Exception as e:
            messagebox.showerror("Ошибка сохранения", f"Не удалось обновить файл: {e}")

    def refresh_ui(self):
        self.view.tree.delete(*self.view.tree.get_children())
        for item in self.items:
            self.view.tree.insert("", tk.END, values=(item.base_currency, item.target_currency, item.rate, item.date))

    def handle_add(self):
        dialog = AddItemDialog(self.view)
        self.view.wait_window(dialog)
        if dialog.result:
            self.items.append(dialog.result)
            self.refresh_ui()
            self.save_to_file()

    def handle_delete(self):
        selected = self.view.tree.selection()
        if not selected: return
        
        for s in selected:
            idx = self.view.tree.index(s)
            del self.items[idx]
            self.view.tree.delete(s)
        
        self.save_to_file() 



if __name__ == "__main__":
    app_view = MainView()
    presenter = AppPresenter(app_view, DEFAULT_FILE)
    app_view.mainloop()