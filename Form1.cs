using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Newtonsoft.Json.Linq;
using xNet;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void TestSelenium()
        {
            try
            {
                ChromeDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://www.google.com");

                IWebElement searchBox = driver.FindElement(By.Name("q"));
                searchBox.SendKeys("Selenium C#");
                searchBox.Submit();

                IWebElement resultsDiv = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists(By.Id("search")));

                Console.WriteLine(driver.Title);

                driver.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        void checkIp()
        {
            MessageBox.Show("Start check IP");

            Task.Run(() =>
            {
                HttpRequest request = new HttpRequest();

                string url = "https://api.ipify.org/?format=json";
                
                HttpResponse response = request.Get(url);

                string json = response.ToString();

                MessageBox.Show(json);

                JObject obj = JObject.Parse(json);

                string ip = (string)obj["ip"];

                MessageBox.Show("IP: " + ip);
            });
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            checkIp();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            TestSelenium();
        }
    }
}