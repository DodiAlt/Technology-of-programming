using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CurrencyRatesApp
{
    public partial class HtmlViewerForm : Form
    {
        private WebBrowser webBrowser;
        private Button backButton;
        private Button refreshButton;
        private Button homeButton;
        private TextBox urlTextBox;
        private Panel topPanel;

        public HtmlViewerForm()
        {
            InitializeComponent();
            LoadDefaultHtml();
        }

        private void InitializeComponent()
        {
            this.Text = "HTML просмотрщик";
            this.Size = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            backButton = new Button
            {
                Text = "← Назад",
                Location = new Point(10, 8),
                Size = new Size(80, 25),
                BackColor = Color.White
            };
            backButton.Click += BackButton_Click;

            webBrowser = new WebBrowser
            {
                Dock = DockStyle.Fill,
                ScriptErrorsSuppressed = true,
                WebBrowserShortcutsEnabled = true,
                IsWebBrowserContextMenuEnabled = true
            };

            this.Controls.Add(webBrowser);
            this.Controls.Add(topPanel);
        }

        private void LoadDefaultHtml()
        {
            string htmlContent = 
@"<!DOCTYPE html>
<html>
<head>
    <meta charset='utf-8'>
    <title>Информация о курсах валют</title>
</head>
<body>
    <div class='container'>
        <img src='C:\Users\ilsem\source\repos\8 семак\Technology-of-programming\Технологии программирования\Технологии программирования\bin\Debug\Photo.jpg'>
    </div>
</body>
</html>";

            string tempHtmlFile = Path.Combine(Path.GetTempPath(), "currency_info.html");
            File.WriteAllText(tempHtmlFile, htmlContent);
            
            webBrowser.Navigate(tempHtmlFile);
            urlTextBox.Text = tempHtmlFile;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Close();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            LoadDefaultHtml();
        }

        private void UrlTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                NavigateToUrl();
            }
        }

        private void NavigateToUrl()
        {
            string url = urlTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(url))
            {
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }
                webBrowser.Navigate(url);
            }
        }
    }
}