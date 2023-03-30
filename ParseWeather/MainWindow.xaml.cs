using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Python.Runtime;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using HtmlAgilityPack;
using static IronPython.Runtime.Profiler;

namespace ParseWeather
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string strSPlit;

        public MainWindow()
        {
            InitializeComponent();

        }
        private string CleanText(string inputText)
        {
            // убираем символ '&minus;' и заменяем его на '-'
            inputText = inputText.Replace("&minus;", "-");
            // убираем символ '&nbsp;' и заменяем его на пробел ' '
            inputText = inputText.Replace("&nbsp;", " ");
            // убираем все символы '&deg;', которые могут появиться при выводе температуры
            inputText = inputText.Replace("&deg;", "");
            // убираем лишние пробелы в строке
            inputText = inputText.Trim();

            return inputText;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var url = "https://www.gismeteo.ua/";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var DateTime = doc.DocumentNode.SelectNodes("/html/body/section/div[1]/section[1]/div[1]/div/div[2]/div[1]/div[1]");
            var temp = doc.DocumentNode.SelectNodes("/html/body/section/div[1]/section[1]/div[1]/div/div[2]/div[1]/div[2]");
            var poOwuweny = doc.DocumentNode.SelectNodes("/html/body/section/div[1]/section[1]/div[1]/div/div[2]/div[1]/div[3]");
            var winter = doc.DocumentNode.SelectNodes("/html/body/section/div[1]/section[1]/div[1]/div/div[2]/div[1]/div[4]");
            var davlenie = doc.DocumentNode.SelectNodes("/html/body/section/div[1]/section[1]/div[1]/div/div[2]/div[1]/div[5]");
            var vlaga = doc.DocumentNode.SelectNodes("/html/body/section/div[1]/section[1]/div[1]/div/div[2]/div[1]/div[6]");
            var gMactiv = doc.DocumentNode.SelectNodes("/html/body/section/div[1]/section[1]/div[1]/div/div[2]/div[1]/div[7]");
            var water = doc.DocumentNode.SelectNodes("/html/body/section/div[1]/section[1]/div[1]/div/div[2]/div[1]/div[8]");
            if (DateTime != null)
            {
                try
                {
                    DateTime.ToList().ForEach(item => box.Text+= CleanText(item.InnerText)+"\n");
                    temp.ToList().ForEach(item => box.Text += CleanText(item.InnerText) + "\n");
                    poOwuweny.ToList().ForEach(item => box.Text += CleanText(item.InnerText) + "\n");
                    winter.ToList().ForEach(item => box.Text += CleanText(item.InnerText) + "\n");
                    davlenie.ToList().ForEach(item => box.Text += CleanText(item.InnerText) + "\n");
                    vlaga.ToList().ForEach(item => box.Text += CleanText(item.InnerText) + "\n");
                    gMactiv.ToList().ForEach(item => box.Text += CleanText(item.InnerText) + "\n");
                    winter.ToList().ForEach(item => box.Text += CleanText(item.InnerText) + "\n");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
  