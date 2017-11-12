using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Firefox;
using System.IO;

namespace SlemiumWeb
{
    [TestClass]
    public class ChromeTestPHP : CalcBTNTest
    {
        static IWebDriver MakeDriver()
        {
            return new ChromeDriver();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Driver = MakeDriver();
            //Driver.Navigate().GoToUrl(uri.AbsoluteUri);
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }

        [TestInitialize]
        public void TestSetUp()
        {
            //string path = Path.GetFullPath("Calc.html");
            //var uri = new System.Uri(path);
            Driver.Navigate().GoToUrl("http://localhost/ForSelenium/calc.html");
        }
    }
    [TestClass]
    public class ChromeTestHTTP : CalcBTNTest
    {
        static IWebDriver MakeDriver()
        {
            return new ChromeDriver();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Driver = MakeDriver();
            //Driver.Navigate().GoToUrl("http://localhost/ForSelenium/calc.html");
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }

        [TestInitialize]
        public void TestSetUp()
        {
            string path = Path.GetFullPath("Calc.html");
            var uri = new System.Uri(path);
            Driver.Navigate().GoToUrl("http://localhost/ForSelenium/calc.html");
        }
    }
    /*
    [TestClass]
    public class IETest : CalcBTNTest
    {
        static IWebDriver MakeDriver()
        {
            return new InternetExplorerDriver();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Driver = MakeDriver();
            Driver.Navigate().GoToUrl("http://localhost/ForSelenium/calc.html");
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }
    }

    [TestClass]
    public class FFTest : CalcBTNTest
    {
        static IWebDriver MakeDriver()
        {
            return new FirefoxDriver();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Driver = MakeDriver();
            Driver.Navigate().GoToUrl("http://localhost/ForSelenium/calc.html");
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }
    }

    [TestClass]
    public class EdgeTest : CalcBTNTest
    {
        static IWebDriver MakeDriver()
        {
            return new EdgeDriver();
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Driver = MakeDriver();
            Driver.Navigate().GoToUrl("http://localhost/ForSelenium/calc.html");
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }
    }

    [TestClass]
    public class OperaTest : CalcBTNTest
    {
        static IWebDriver MakeDriver()
        {
            OperaOptions opera = new OperaOptions();
            opera.BinaryLocation = @"C:\Program Files\Opera\launcher.exe";

            return new OperaDriver(opera);
        }
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Driver = MakeDriver();
            Driver.Navigate().GoToUrl("http://localhost/ForSelenium/calc.html");
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
    */
    [TestClass]
    public abstract class CalcBTNTest
    {
        protected static IWebDriver Driver;

        //internal abstract IWebDriver MakeDriver();        

        [ClassCleanup]
        public void ClassCleanup()
        {
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
        }        
        
        [DataTestMethod]
        [DataRow("bt1")]
        [DataRow("bt2")]
        [DataRow("bt3")]
        [DataRow("bt4")]
        [DataRow("bt5")]
        [DataRow("bt6")]
        [DataRow("bt7")]
        [DataRow("bt8")]
        [DataRow("bt9")]
        [DataRow("bt0")]
        [DataRow("plus")]
        [DataRow("sub")]
        [DataRow("mul")]
        [DataRow("div")]
        [DataRow("clear")]
        [DataRow("count")]
        [DataRow("input")]

        [TestMethod]
        public void TestDriverCalcBTNExist(string name)
        {

            bool exist = Driver.FindElement(By.Name(name)).Displayed;


            Assert.IsTrue(exist);
        }

        [DataTestMethod]
        [DataRow(0, "0")]
        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(3, "3")]
        [DataRow(4, "4")]
        [DataRow(5, "5")]
        [DataRow(6, "6")]
        [DataRow(7, "7")]
        [DataRow(8, "8")]
        [DataRow(9, "9")]

        [TestMethod]
        public void TestDriverCalcBTNSimple(int id, string expected)
        {

            Driver.FindElement(By.Name("bt" + id)).Click();

            string actual = Driver.FindElement(By.Name("input")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [DataTestMethod]
        [DataRow("bt1", "bt2", "bt3", "123")]
        [DataRow("bt4", "bt5", "bt6", "456")]
        [DataRow("bt7", "bt8", "bt9", "789")]
        [DataRow("bt0", "bt8", "bt3", "083")]
        [DataRow("bt5", "plus", "bt3", "5 + 3")]
        [DataRow("bt1", "sub", "bt7", "1 - 7")]
        [DataRow("bt8", "mul", "bt2", "8 * 2")]
        [DataRow("bt1", "div", "bt3", "1 / 3")]
        [DataRow("sub", "mul", "bt0", " -  * 0")]
        [DataRow("bt0", "plus", "div", "0 +  / ")]

        [TestMethod]
        public void TestDriverCalcBTNComplex(string bt1, string bt2, string bt3, string expected)
        {

            Driver.FindElement(By.Name(bt1)).Click();
            Driver.FindElement(By.Name(bt2)).Click();
            Driver.FindElement(By.Name(bt3)).Click();

            string actual = Driver.FindElement(By.Name("input")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDriverCalcBTN_10p5_15()
        {

            string expected = "15";

            Driver.FindElement(By.Name("bt1")).Click();
            Driver.FindElement(By.Name("bt0")).Click();
            Driver.FindElement(By.Name("plus")).Click();
            Driver.FindElement(By.Name("bt5")).Click();
            Driver.FindElement(By.Name("count")).Click();

            string actual = Driver.FindElement(By.Name("input")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDriverCalcBTN_10m5_5()
        {

            string expected = "5";

            Driver.FindElement(By.Name("bt1")).Click();
            Driver.FindElement(By.Name("bt0")).Click();
            Driver.FindElement(By.Name("sub")).Click();
            Driver.FindElement(By.Name("bt5")).Click();
            Driver.FindElement(By.Name("count")).Click();

            string actual = Driver.FindElement(By.Name("input")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDriverCalcBTN_20d2_10()
        {

            string expected = "10";

            Driver.FindElement(By.Name("bt2")).Click();
            Driver.FindElement(By.Name("bt0")).Click();
            Driver.FindElement(By.Name("div")).Click();
            Driver.FindElement(By.Name("bt2")).Click();
            Driver.FindElement(By.Name("count")).Click();

            string actual = Driver.FindElement(By.Name("input")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDriverCalcBTN_6mul2_12()
        {

            string expected = "12";

            Driver.FindElement(By.Name("bt6")).Click();
            Driver.FindElement(By.Name("mul")).Click();
            Driver.FindElement(By.Name("bt2")).Click();
            Driver.FindElement(By.Name("count")).Click();

            string actual = Driver.FindElement(By.Name("input")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDriverCalcBTNClear()
        {

            string expected = "";

            Driver.FindElement(By.Name("bt6")).Click();
            Driver.FindElement(By.Name("mul")).Click();
            Driver.FindElement(By.Name("bt2")).Click();
            Driver.FindElement(By.Name("clear")).Click();

            string actual = Driver.FindElement(By.Name("input")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }
    }

    /*
    [TestClass]
    public class CalcTBTest
    {
        private static IWebDriver Driver;

        // инициализация и открытие браузера при начале тестирования
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("http://localhost/ForSelenium/calc.html");
        }

        [TestMethod]
        public void TestDriverCalcBTN_5p10_15()
        {

            string expected = "15";

            Driver.FindElement(By.Name("num1")).SendKeys("5");
            Driver.FindElement(By.Name("op")).SendKeys("+");
            Driver.FindElement(By.Name("num2")).SendKeys("10");
            Driver.FindElement(By.Id("count")).Click();

            string actual = Driver.FindElement(By.Name("res")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDriverCalcBTN_5m10_15()
        {

            string expected = "-5";

            Driver.FindElement(By.Name("num1")).SendKeys("5");
            Driver.FindElement(By.Name("op")).SendKeys("-");
            Driver.FindElement(By.Name("num2")).SendKeys("10");
            Driver.FindElement(By.Id("count")).Click();

            string actual = Driver.FindElement(By.Name("res")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDriverCalcBTN_3mul7_21()
        {

            string expected = "21";

            Driver.FindElement(By.Name("num1")).SendKeys("3");
            Driver.FindElement(By.Name("op")).SendKeys("*");
            Driver.FindElement(By.Name("num2")).SendKeys("7");
            Driver.FindElement(By.Id("count")).Click();

            string actual = Driver.FindElement(By.Name("res")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDriverCalcBTN_12div3_4()
        {

            string expected = "4";

            Driver.FindElement(By.Name("num1")).SendKeys("12");
            Driver.FindElement(By.Name("op")).SendKeys("/");
            Driver.FindElement(By.Name("num2")).SendKeys("3");
            Driver.FindElement(By.Id("count")).Click();

            string actual = Driver.FindElement(By.Name("res")).GetAttribute("value");

            Assert.AreEqual(expected, actual);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Navigate().Refresh();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
    */
}
