import random
import os

def generate_large_input(n=100000, d=10**9):
    # Путь к папке, где лежит этот скрипт
    current_dir = os.path.dirname(os.path.abspath(__file__))
    input_path = os.path.join(current_dir, 'INPUT.TXT')

    print(f"Генерация файла с N={n}...")

    # Генерируем возрастающие последовательности
    # Чтобы значения не вышли за 10^9, используем небольшой шаг
    def gen_increasing_sequence(count, max_val):
        seq = []
        curr = random.randint(0, 100)
        for _ in range(count):
            seq.append(curr)
            curr += random.randint(1, 5000) # Случайный шаг
        return seq

    a_times = gen_increasing_sequence(n, 10**9)
    b_times = gen_increasing_sequence(n, 10**9)
    
    # Условие задачи: T1 <= T2
    if a_times[0] > b_times[0]:
        a_times[0], b_times[0] = b_times[0], a_times[0]

    with open(input_path, 'w', encoding='utf-8') as f:
        f.write(f"{n}\n")
        f.write(f"{d}\n")
        for t in a_times:
            f.write(f"{t}\n")
        for t in b_times:
            f.write(f"{t}\n")

    print(f"Готово! Файл создан: {input_path}")
    print(f"Размер файла: {os.path.getsize(input_path) / 1024 / 1024:.2f} MB")

if __name__ == "__main__":
    generate_large_input()