using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Reflection;

namespace Parser
{
    public partial class Form1 : Form
    {
        const string MAIN_URL = "https://www.dveriregionov.ru";
        string[] ParametersTemp = new string[29];


        public class Products
        {
            [Name("Категория")]
            public string Category { get; set; }
            [Name("URL категории")]
            public string Category_URL { get; set; }
            [Name("Товар")]
            public string Product { get; set; }
            [Name("Цена")]
            public string Price { get; set; }
            [Name("Старая цена")]
            public string OldPrice { get; set; }
            [Name("URL товара")]
            public string Product_URL { get; set; }
            [Name("Производитель")]
            public string Vendor { get; set; }
            [Name("Размер дверного блока")]
            public string DoorSize { get; set; }
            [Name("Серия")]
            public string Lot { get; set; }
            [Name("Толщина полотна мм.")]
            public string ThicknessPolotn { get; set; }
            [Name("Толщина листа металла мм.")]
            public string ThicknessList { get; set; }
            [Name("Класс прочности")]
            public string StrengthClass { get; set; }
            [Name("Значение по эксплутационным характеристикам")]
            public string PerfomanceValue { get; set; }
            [Name("Класс устойчивости к взлому")]
            public string BurglaryResistanceClass { get; set; }
            [Name("Количество петель")]
            public string NumberOfLoops { get; set; }
            [Name("Противосъемы")]
            public string AntiSteal { get; set; }
            [Name("Регулировка прижима")]
            public string Regul { get; set; }
            [Name("Короб")]
            public string Box { get; set; }
            [Name("Вылет наличника от короба")]
            public string BoxOut { get; set; }
            [Name("Крепление")]
            public string Binding { get; set; }
            [Name("Утеплитель")]
            public string Heate { get; set; }
            [Name("Усиление замковой зоны")]
            public string Strengthening { get; set; }
            [Name("Ночная задвижка")]
            public string Night { get; set; }
            [Name("Терморазрыв")]
            public string Termo { get; set; }
            [Name("Цинкогрунт")]
            public string Zinc { get; set; }
            [Name("Вес двери")]
            public string WeightDoor { get; set; }
            [Name("Внутреннее наполнение")]
            public string Inside { get; set; }
            [Name("Покрытие")]
            public string Outside { get; set; }
            [Name("Тип остекления")]
            public string GlazingType { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void ParseCategory(string url = "", string html = "")  // Парсер определённой категории
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            if (url != "")
            {
                WebClient webClient = new WebClient();
                doc.Load(webClient.OpenRead(url), Encoding.UTF8);
            }
            else
            {
                doc.Load(Path_tb.Text, Encoding.UTF8);
            }
            var tmp2131 = doc.DocumentNode.SelectSingleNode("//li[contains(@class, 'uk-active')]");
            if (tmp2131 == null)   // если только 1 страница с товарами
            {
                ParsePage(url);  // парсинг текущей страницы
            }
            else
            {
                int active_page = Convert.ToInt32(doc.DocumentNode.SelectSingleNode("//li[contains(@class, 'uk-active')]").SelectSingleNode("./span").InnerText);
                ParsePage(url);  // парсинг текущей страницы
                string tmp = doc.DocumentNode.SelectSingleNode("//ul[contains(@class, 'uk-pagination uk-flex-center')]").OuterHtml;
                var tmp1 = new HtmlAgilityPack.HtmlDocument();
                tmp1.LoadHtml(tmp);
                int page_count = tmp1.DocumentNode.SelectNodes("//a").Count();
                for (int i = 1; i < page_count; ++i)
                {
                    string urli = url + "?PAGEN_1=" + (i + 1);
                    ParsePage(urli);
                }
            }
        }

        List<Products> products = new List<Products>(800);

        private void ParsePage(string url = "", string html = "")   // Парсер определённой странички
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            if (url != "")
            {
                WebClient webClient = new WebClient();
                doc.Load(webClient.OpenRead(url), Encoding.UTF8);
            }
            else
            {
                doc.Load(Path_tb.Text, Encoding.UTF8);
            }
            HtmlNodeCollection products = doc.DocumentNode.SelectNodes("//div[contains(@class, 'card__img')]");
            foreach (HtmlNode product in products)
            {
                try
                {
                    string html_tmp = product.OuterHtml;
                    var doc1 = new HtmlAgilityPack.HtmlDocument();
                    doc1.LoadHtml(html_tmp);
                    string tmp = doc1.DocumentNode.OuterHtml;
                    string url_tmp = MAIN_URL + doc1.DocumentNode.SelectSingleNode("// a").Attributes["href"].Value;
                    ParseProduct(url_tmp);
                }
                catch
                {
                }
            }

        }


        private void ParseProduct(string url = "", string html = "")   // Парсер определённого товара
        {
            Products prod = new Products();
            var doc = new HtmlAgilityPack.HtmlDocument();
            if (url != "")
            {
                WebClient webClient = new WebClient();
                doc.Load(webClient.OpenRead(url), Encoding.UTF8);
            }
            else
            {
                doc.Load(Path_tb.Text, Encoding.UTF8);
            }
            
            HtmlNodeCollection lis = doc.DocumentNode.SelectSingleNode("//ul[contains(@class, 'breadcrumbs')]").SelectNodes("./li");
            string cat = "";
            string tmp = "";
            string hrefmax = "";
            foreach (HtmlNode li in lis)
            {
                var doc1 = new HtmlAgilityPack.HtmlDocument();
                doc1.LoadHtml(li.OuterHtml);
                HtmlNode tmp1 = doc1.DocumentNode.SelectSingleNode("//a");
                if (tmp1 != null)
                {
                    string href = tmp1.Attributes["href"].Value;
                    if (href.Length > hrefmax.Length)
                    {
                        hrefmax = href;
                    }
                }
                if (tmp != "Главная")
                {
                    cat = cat + tmp + '/';
                }
                tmp = li.InnerText.Trim();
                
            }
            cat = cat.Trim('/');
            prod.Category = cat;
            hrefmax = hrefmax.Trim('/');
            prod.Category_URL = hrefmax;
            //HtmlNodeCollection titl = doc.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-h1')]").InnerText;
            string title = doc.DocumentNode.SelectSingleNode("//h1[contains(@class, 'title-h1')]").InnerText;
            prod.Product = title;
            prod.Product_URL = url;
            string oldprice = "";
            if (doc.GetElementbyId("oldprice") != null)
            {
                oldprice = doc.GetElementbyId("oldprice").InnerText.Trim();
            }
            prod.OldPrice = oldprice;
            string currprice = "";
            currprice = doc.GetElementbyId("itogpricedoors").InnerText.Trim();
            if (currprice == "")
                try
                {
                    currprice = doc.GetElementbyId("priceouterpanel").Attributes["value"].Value.Trim();
                }
                catch
                { }
            prod.Price = currprice;
            HtmlNode tbody = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'uk-overflow-auto')]").SelectSingleNode("./table/tbody");
            foreach (HtmlNode tr in tbody.SelectNodes("./tr"))
            {
                HtmlNodeCollection td = tr.SelectNodes("./td");
                string param_name = td[0].InnerText;
                string param_value = td[1].InnerText;
                foreach (var prop in prod.GetType().GetProperties())
                {
                    MemberInfo property = typeof(Products).GetProperty(prop.Name);
                    var dd = property.GetCustomAttribute(typeof(NameAttribute)) as NameAttribute;
                    if (dd.Names[0] == param_name)
                    {
                        prop.SetValue(prod, param_value);
                        break;
                    }
                }
                /*
                foreach(HtmlNode td in tr.SelectNodes("./td"))
                {
                    string a = td.InnerText;
                }
                */
            }
            products.Add(prod);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                Path_tb.Text = openFileDialog1.FileName;
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (html_rb.Checked == true)
                view_btn.Enabled = true;
            else
                view_btn.Enabled = false;
        }

        private void OutCsv()
        {
            string pathCsvFile = "data_csv_" + DateTime.Now.ToString().Replace('.', '_').Replace(':', '_') + ".csv";
            using (StreamWriter streamReader = new StreamWriter(pathCsvFile, true, Encoding.UTF8))
            {
                using (CsvWriter csvReader = new CsvWriter(streamReader))
                {
                    // указываем разделитель, который будет использоваться в файле
                    csvReader.Configuration.Delimiter = ";";
                    // записываем данные в csv файл
                    csvReader.WriteRecords(products);
                }
            }
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            this.Enabled = false;
            if ((Catalog_rb.Checked) && (url_rb.Checked))
            {
                try
                {
                    WebClient webClient = new WebClient();
                    string html = webClient.DownloadString(Path_tb.Text);
                    int ParamCount = Properties.Resources.Parameters.Split(';').Count();
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    string tmp = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'products-short-list')]").SelectSingleNode("./div[contains(@class, 'uk-grid')]").OuterHtml;
                    var tmp1 = new HtmlAgilityPack.HtmlDocument();
                    tmp1.LoadHtml(tmp);
                    foreach (HtmlNode cat in tmp1.DocumentNode.SelectNodes("//a"))
                    {
                        string href = cat.Attributes["href"].Value;
                        ParseCategory(MAIN_URL + href, "");
                    }
                    OutCsv();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    DialogResult dialogResult1 = MessageBox.Show("Задание выполнено за " + Math.Round(elapsedMs / 1000.0, MidpointRounding.AwayFromZero) + " с", "Успех", MessageBoxButtons.OK);
                }
                catch
                {
                    watch.Stop();
                    DialogResult dialogResult = MessageBox.Show("Неправильный адрес сайта!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
            else if ((Category_rb.Checked) && (url_rb.Checked))
            {
                try
                {
                    ParseCategory(Path_tb.Text, "");
                    OutCsv();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    DialogResult dialogResult1 = MessageBox.Show("Задание выполнено за " + Math.Round(elapsedMs / 1000.0, MidpointRounding.AwayFromZero) + " с", "Успех", MessageBoxButtons.OK);
                }
                catch
                {
                    watch.Stop();
                    DialogResult dialogResult = MessageBox.Show("Неправильный адрес сайта!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
            else if ((Product_rb.Checked) && (url_rb.Checked))
            {
                try
                {
                    ParseProduct(Path_tb.Text, "");
                    OutCsv();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    DialogResult dialogResult1 = MessageBox.Show("Задание выполнено за " + Math.Round(elapsedMs/1000.0, MidpointRounding.AwayFromZero) + " с", "Успех", MessageBoxButtons.OK);
                }
                catch
                {
                    watch.Stop();
                    DialogResult dialogResult = MessageBox.Show("Неправильный адрес сайта!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
            else if ((Catalog_rb.Checked) && (html_rb.Checked))
            {
                try
                {
                    string html = File.ReadAllText(Path_tb.Text);
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);

                    string tmp = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'products-short-list')]").SelectSingleNode("./div[contains(@class, 'uk-grid')]").OuterHtml;
                    var tmp1 = new HtmlAgilityPack.HtmlDocument();
                    tmp1.LoadHtml(tmp);
                    foreach (HtmlNode cat in tmp1.DocumentNode.SelectNodes("//a"))
                    {
                        string href = cat.Attributes["href"].Value;
                        ParseCategory(MAIN_URL + href);
                    }
                    OutCsv();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    DialogResult dialogResult1 = MessageBox.Show("Задание выполнено за " + Math.Round(elapsedMs / 1000.0, MidpointRounding.AwayFromZero) + " с", "Успех", MessageBoxButtons.OK);
                }
                catch
                {
                    watch.Stop();
                    DialogResult dialogResult = MessageBox.Show("Ошибка в пути!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
            else if ((Category_rb.Checked) && (html_rb.Checked))
            {
                try
                {
                    string html = File.ReadAllText(Path_tb.Text);
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);
                    ParseCategory("", html);
                    OutCsv();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    DialogResult dialogResult1 = MessageBox.Show("Задание выполнено за " + Math.Round(elapsedMs / 1000.0, MidpointRounding.AwayFromZero) + " с", "Успех", MessageBoxButtons.OK);
                }
                catch
                {
                    watch.Stop();
                    DialogResult dialogResult = MessageBox.Show("Ошибка в пути!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
            else
            {
                try
                {
                    string html = File.ReadAllText(Path_tb.Text);
                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.LoadHtml(html);
                    ParseProduct("", html);
                    OutCsv();
                    watch.Stop();
                    var elapsedMs = watch.ElapsedMilliseconds;
                    DialogResult dialogResult1 = MessageBox.Show("Задание выполнено за " + Math.Round(elapsedMs / 1000.0, MidpointRounding.AwayFromZero) + " с", "Успех", MessageBoxButtons.OK);

                }
                catch
                {
                    watch.Stop();
                    DialogResult dialogResult = MessageBox.Show("Ошибка в пути!", "Ошибка!", MessageBoxButtons.OK);
                }
            }
            products.Clear();
            this.Enabled = true;

        }
    }
}
