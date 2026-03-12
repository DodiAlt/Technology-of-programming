using System;
using System.Drawing;
using System.Windows.Forms;
using CurrencyRatesApp.Models;

namespace CurrencyRatesApp
{
    public class AddCurrencyRateDialog : Form
    {
        private TextBox fromCurrencyTextBox;
        private TextBox toCurrencyTextBox;
        private NumericUpDown rateNumericUpDown;
        private DateTimePicker timestampPicker;
        private Button okButton;
        private Button cancelButton;

        public AddCurrencyRateDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Настройка формы
            this.Text = "Добавить курс валют";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Создание элементов управления
            Label fromCurrencyLabel = new Label();
            Label toCurrencyLabel = new Label();
            Label rateLabel = new Label();
            Label timestampLabel = new Label();

            fromCurrencyTextBox = new TextBox();
            toCurrencyTextBox = new TextBox();
            rateNumericUpDown = new NumericUpDown();
            timestampPicker = new DateTimePicker();
            okButton = new Button();
            cancelButton = new Button();

            // Настройка fromCurrencyLabel
            fromCurrencyLabel.Text = "Из валюты:";
            fromCurrencyLabel.Location = new Point(20, 20);
            fromCurrencyLabel.Size = new Size(80, 25);
            fromCurrencyLabel.TextAlign = ContentAlignment.MiddleRight;

            // Настройка toCurrencyLabel
            toCurrencyLabel.Text = "В валюту:";
            toCurrencyLabel.Location = new Point(20, 55);
            toCurrencyLabel.Size = new Size(80, 25);
            toCurrencyLabel.TextAlign = ContentAlignment.MiddleRight;

            // Настройка rateLabel
            rateLabel.Text = "Курс:";
            rateLabel.Location = new Point(20, 90);
            rateLabel.Size = new Size(80, 25);
            rateLabel.TextAlign = ContentAlignment.MiddleRight;

            // Настройка timestampLabel
            timestampLabel.Text = "Дата и время:";
            timestampLabel.Location = new Point(20, 125);
            timestampLabel.Size = new Size(80, 25);
            timestampLabel.TextAlign = ContentAlignment.MiddleRight;

            // Настройка fromCurrencyTextBox
            fromCurrencyTextBox.Location = new Point(110, 20);
            fromCurrencyTextBox.Size = new Size(250, 25);
            fromCurrencyTextBox.CharacterCasing = CharacterCasing.Upper;

            // Настройка toCurrencyTextBox
            toCurrencyTextBox.Location = new Point(110, 55);
            toCurrencyTextBox.Size = new Size(250, 25);
            toCurrencyTextBox.CharacterCasing = CharacterCasing.Upper;

            // Настройка rateNumericUpDown
            rateNumericUpDown.Location = new Point(110, 90);
            rateNumericUpDown.Size = new Size(250, 25);
            rateNumericUpDown.DecimalPlaces = 4;
            rateNumericUpDown.Minimum = 0.0001M;
            rateNumericUpDown.Maximum = 1000000M;
            rateNumericUpDown.Value = 1.0000M;

            // Настройка timestampPicker
            timestampPicker.Location = new Point(110, 125);
            timestampPicker.Size = new Size(250, 25);
            timestampPicker.Format = DateTimePickerFormat.Custom;
            timestampPicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            timestampPicker.ShowUpDown = true;
            timestampPicker.Value = DateTime.Now;

            // Настройка okButton
            okButton.Text = "OK";
            okButton.Location = new Point(190, 170);
            okButton.Size = new Size(80, 30);
            okButton.DialogResult = DialogResult.OK;
            okButton.Click += OkButton_Click;

            // Настройка cancelButton
            cancelButton.Text = "Отмена";
            cancelButton.Location = new Point(280, 170);
            cancelButton.Size = new Size(80, 30);
            cancelButton.DialogResult = DialogResult.Cancel;

            // Добавление элементов на форму
            this.Controls.AddRange(new Control[] {
                fromCurrencyLabel,
                toCurrencyLabel,
                rateLabel,
                timestampLabel,
                fromCurrencyTextBox,
                toCurrencyTextBox,
                rateNumericUpDown,
                timestampPicker,
                okButton,
                cancelButton
            });

            // Установка кнопки по умолчанию
            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            // Валидация данных
            if (string.IsNullOrWhiteSpace(fromCurrencyTextBox.Text))
            {
                MessageBox.Show("Введите название валюты (из)", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }

            if (string.IsNullOrWhiteSpace(toCurrencyTextBox.Text))
            {
                MessageBox.Show("Введите название валюты (в)", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
                return;
            }
        }

        public CurrencyRate GetCurrencyRate()
        {
            return new CurrencyRate(
                fromCurrencyTextBox.Text.Trim().ToUpper(),
                toCurrencyTextBox.Text.Trim().ToUpper(),
                rateNumericUpDown.Value,
                timestampPicker.Value
            );
        }
    }
}