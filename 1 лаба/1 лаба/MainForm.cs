using System;
using System.Windows.Forms;
using CurrencyRatesApp.Models;
using CurrencyRatesApp.Services;

namespace CurrencyRatesApp
{
    public partial class MainForm : Form
    {
        private readonly CurrencyRateService _rateService;

        public MainForm()
        {
            // Инициализация сервисов
            var fileService = new FileService("currency_rates.txt");
            _rateService = new CurrencyRateService(fileService);

            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                _rateService.LoadRates();
                RefreshDataGridView();
                UpdateStatus($"Загружено {_rateService.GetAllRates().Count} записей");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshDataGridView()
        {
            dataGridView.Rows.Clear();
            foreach (var rate in _rateService.GetAllRates())
            {
                dataGridView.Rows.Add(
                    rate.FromCurrency,
                    rate.ToCurrency,
                    rate.Rate,
                    rate.Timestamp.ToString("yyyy-MM-dd HH:mm:ss")
                );
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new AddCurrencyRateDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var rate = dialog.GetCurrencyRate();
                        _rateService.AddRate(rate);
                        _rateService.SaveRates();
                        RefreshDataGridView();
                        UpdateStatus($"Добавлена запись: {rate}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите запись для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedRow = dataGridView.SelectedRows[0];
            var fromCurrency = selectedRow.Cells[0].Value.ToString();
            var toCurrency = selectedRow.Cells[1].Value.ToString();
            var timestamp = DateTime.Parse(selectedRow.Cells[3].Value.ToString());

            var rateToDelete = _rateService.FindRate(fromCurrency, toCurrency, timestamp);

            if (rateToDelete != null)
            {
                var result = MessageBox.Show(
                    $"Удалить запись: {rateToDelete}?",
                    "Подтверждение удаления",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        _rateService.RemoveRate(rateToDelete);
                        _rateService.SaveRates();
                        RefreshDataGridView();
                        UpdateStatus($"Удалена запись: {rateToDelete}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении записи: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void UpdateStatus(string message)
        {
            statusLabel.Text = message;
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}