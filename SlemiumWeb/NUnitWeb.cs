using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.IE;

namespace SlemiumWeb
{
    class NUnit
    {
        //[TestFixture(typeof(ChromeDriver))]
        //[TestFixture(typeof(FirefoxDriver))]
        [TestFixture(typeof(EdgeDriver))]
        //[TestFixture(typeof(OperaDriver))]
        //[TestFixture(typeof(InternetExplorerDriver))]

        public class NUnitTests<TPage> where TPage : IWebDriver, new()
        {
            IWebDriver driver = null;
            [OneTimeSetUp]
            public void DriverPath()
            {
                if (typeof(TPage) == typeof(OperaDriver))
                {
                    OperaOptions opera = new OperaOptions();
                    opera.BinaryLocation = @"C:\Program Files\Opera\launcher.exe";

                    driver = new OperaDriver(opera);
                }
                else
                {
                    driver = new TPage();
                }
            }

            [SetUp]
            public void CreateList()
            {
                driver.Navigate().GoToUrl("file:///E:/SeleniumWeb/SlemiumWeb/Calc.html"); // to do: correct path
            }

            [Test]
            [TestCase("bt1", "1")]
            [TestCase("bt2", "2")]
            [TestCase("bt3", "3")]
            [TestCase("bt4", "4")]
            [TestCase("bt5", "5")]
            [TestCase("bt6", "6")]
            [TestCase("bt7", "7")]
            [TestCase("bt8", "8")]
            [TestCase("bt9", "9")]
            [TestCase("bt0", "0")]
            public void JSTestCalcWithBSeimpleCheckTest(string button, string result)
            {
                driver.FindElement(By.Name(button)).Click();
                string res = driver.FindElement(By.Name("input")).GetAttribute("value");
                Assert.AreEqual(result, res);
            }

            [Test]
            [TestCase("bt1", "bt3", "13")]
            [TestCase("bt2", "bt4", "24")]
            [TestCase("bt3", "bt6", "36")]
            [TestCase("bt4", "bt7", "47")]
            [TestCase("bt5", "bt4", "54")]
            [TestCase("bt6", "bt2", "62")]
            [TestCase("bt7", "bt3", "73")]
            [TestCase("bt8", "bt3", "83")]
            [TestCase("bt9", "bt2", "92")]
            [TestCase("bt0", "bt9", "09")]
            public void JSTestCalcWithBComplexCheck(string firstbutton, string secondbutton, string result)
            {
                driver.FindElement(By.Name(firstbutton)).Click();
                driver.FindElement(By.Name(secondbutton)).Click();
                string res = driver.FindElement(By.Name("input")).GetAttribute("value");
                Assert.AreEqual(result, res);
            }

            [Test]
            [TestCase("bt1", "sub", "bt5", "-4")]
            [TestCase("bt7", "plus", "bt5", "12")]
            [TestCase("bt5", "mul", "bt6", "30")]
            [TestCase("bt6", "div", "bt3", "2")]
            public void JSTestCalcWithBRealJobTest(string firstbutton, string operation, string secondbutton, string result)
            {
                driver.FindElement(By.Name(firstbutton)).Click();
                driver.FindElement(By.Name(operation)).Click();
                driver.FindElement(By.Name(secondbutton)).Click();
                driver.FindElement(By.Name("count")).Click();
                string res = driver.FindElement(By.Name("input")).GetAttribute("value");
                Assert.AreEqual(result, res);
            }

            [OneTimeTearDown]
            public void CloseWeb()
            {
                driver.Close();
                driver.Dispose();
            }
        }
    }
}
