using System;
using System.Drawing;
using System.Windows.Forms;

namespace CurrencyRatesApp
{
    public partial class MenuForm : Form
    {
        private Button currencyRatesButton;
        private Button htmlPageButton;
        private Button exitButton;
        private Label titleLabel;

        public MenuForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Главное меню";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            titleLabel = new Label
            {
                Text = "Выберите раздел",
                Font = new Font("Arial", 16, FontStyle.Bold),
                Location = new Point(100, 30),
                Size = new Size(200, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            currencyRatesButton = new Button
            {
                Text = "Курсы валют",
                Location = new Point(100, 80),
                Size = new Size(200, 40),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.LightBlue,
                FlatStyle = FlatStyle.Flat
            };
            currencyRatesButton.Click += CurrencyRatesButton_Click;

            htmlPageButton = new Button
            {
                Text = "Открыть HTML страницу",
                Location = new Point(100, 130),
                Size = new Size(200, 40),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };
            htmlPageButton.Click += HtmlPageButton_Click;

            exitButton = new Button
            {
                Text = "Выход",
                Location = new Point(100, 180),
                Size = new Size(200, 40),
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.LightCoral,
                FlatStyle = FlatStyle.Flat
            };
            exitButton.Click += ExitButton_Click;

            this.Controls.AddRange(new Control[] {
                titleLabel,
                currencyRatesButton,
                htmlPageButton,
                exitButton
            });
        }

        private void CurrencyRatesButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void HtmlPageButton_Click(object sender, EventArgs e)
        {
            HtmlViewerForm htmlViewer = new HtmlViewerForm();
            htmlViewer.Show();
            this.Hide();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}