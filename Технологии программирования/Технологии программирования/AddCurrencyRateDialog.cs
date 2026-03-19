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
        private Label fromCurrencyLabel;
        private Label toCurrencyLabel;
        private Label rateLabel;
        private Label timestampLabel;
        private Button cancelButton;

        public AddCurrencyRateDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.fromCurrencyLabel = new System.Windows.Forms.Label();
            this.toCurrencyLabel = new System.Windows.Forms.Label();
            this.rateLabel = new System.Windows.Forms.Label();
            this.timestampLabel = new System.Windows.Forms.Label();
            this.fromCurrencyTextBox = new System.Windows.Forms.TextBox();
            this.toCurrencyTextBox = new System.Windows.Forms.TextBox();
            this.rateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.timestampPicker = new System.Windows.Forms.DateTimePicker();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rateNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // fromCurrencyLabel
            // 
            this.fromCurrencyLabel.Location = new System.Drawing.Point(20, 20);
            this.fromCurrencyLabel.Name = "fromCurrencyLabel";
            this.fromCurrencyLabel.Size = new System.Drawing.Size(80, 25);
            this.fromCurrencyLabel.TabIndex = 0;
            this.fromCurrencyLabel.Text = "Из валюты:";
            this.fromCurrencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.fromCurrencyLabel.Click += new System.EventHandler(this.fromCurrencyLabel_Click);
            // 
            // toCurrencyLabel
            // 
            this.toCurrencyLabel.Location = new System.Drawing.Point(20, 55);
            this.toCurrencyLabel.Name = "toCurrencyLabel";
            this.toCurrencyLabel.Size = new System.Drawing.Size(80, 25);
            this.toCurrencyLabel.TabIndex = 1;
            this.toCurrencyLabel.Text = "В валюту:";
            this.toCurrencyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rateLabel
            // 
            this.rateLabel.Location = new System.Drawing.Point(20, 90);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(80, 25);
            this.rateLabel.TabIndex = 2;
            this.rateLabel.Text = "Курс:";
            this.rateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timestampLabel
            // 
            this.timestampLabel.Location = new System.Drawing.Point(20, 125);
            this.timestampLabel.Name = "timestampLabel";
            this.timestampLabel.Size = new System.Drawing.Size(80, 25);
            this.timestampLabel.TabIndex = 3;
            this.timestampLabel.Text = "Дата и время:";
            this.timestampLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fromCurrencyTextBox
            // 
            this.fromCurrencyTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fromCurrencyTextBox.Location = new System.Drawing.Point(110, 20);
            this.fromCurrencyTextBox.Name = "fromCurrencyTextBox";
            this.fromCurrencyTextBox.Size = new System.Drawing.Size(250, 22);
            this.fromCurrencyTextBox.TabIndex = 4;
            // 
            // toCurrencyTextBox
            // 
            this.toCurrencyTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.toCurrencyTextBox.Location = new System.Drawing.Point(110, 55);
            this.toCurrencyTextBox.Name = "toCurrencyTextBox";
            this.toCurrencyTextBox.Size = new System.Drawing.Size(250, 22);
            this.toCurrencyTextBox.TabIndex = 5;
            // 
            // rateNumericUpDown
            // 
            this.rateNumericUpDown.DecimalPlaces = 4;
            this.rateNumericUpDown.Location = new System.Drawing.Point(110, 90);
            this.rateNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.rateNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            262144});
            this.rateNumericUpDown.Name = "rateNumericUpDown";
            this.rateNumericUpDown.Size = new System.Drawing.Size(250, 22);
            this.rateNumericUpDown.TabIndex = 6;
            this.rateNumericUpDown.Value = new decimal(new int[] {
            10000,
            0,
            0,
            262144});
            // 
            // timestampPicker
            // 
            this.timestampPicker.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.timestampPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timestampPicker.Location = new System.Drawing.Point(110, 125);
            this.timestampPicker.Name = "timestampPicker";
            this.timestampPicker.ShowUpDown = true;
            this.timestampPicker.Size = new System.Drawing.Size(250, 22);
            this.timestampPicker.TabIndex = 7;
            this.timestampPicker.Value = new System.DateTime(2026, 3, 18, 14, 0, 54, 286);
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(190, 170);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(80, 30);
            this.okButton.TabIndex = 8;
            this.okButton.Text = "OK";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(280, 170);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(80, 30);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Отмена";
            // 
            // AddCurrencyRateDialog
            // 
            this.AcceptButton = this.okButton;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(382, 203);
            this.Controls.Add(this.fromCurrencyLabel);
            this.Controls.Add(this.toCurrencyLabel);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.timestampLabel);
            this.Controls.Add(this.fromCurrencyTextBox);
            this.Controls.Add(this.toCurrencyTextBox);
            this.Controls.Add(this.rateNumericUpDown);
            this.Controls.Add(this.timestampPicker);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddCurrencyRateDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить курс валют";
            this.Load += new System.EventHandler(this.AddCurrencyRateDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rateNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
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

        private void AddCurrencyRateDialog_Load(object sender, EventArgs e)
        {

        }

        private void fromCurrencyLabel_Click(object sender, EventArgs e)
        {

        }
    }
}