using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace SlemiumWeb
{
    public class ClalcPage
    {
        private readonly IWebDriver driver;
        private readonly string url = @"file:///G:/ORT%20Course/Calc/Html+JS/Calc.html";

        public ClalcPage(IWebDriver browser)
        {
            this.driver = browser;
            PageFactory.InitElements(browser, this);
        }

        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        // 0-9 buttons
        [FindsBy(How = How.Name, Using = "bt1")]
        public IWebElement btnNum1 { get; set; }

        [FindsBy(How = How.Name, Using = "bt2")]
        public IWebElement btnNum2 { get; set; }

        [FindsBy(How = How.Name, Using = "bt3")]
        public IWebElement btnNum3 { get; set; }

        [FindsBy(How = How.Name, Using = "bt4")]
        public IWebElement btnNum4 { get; set; }

        [FindsBy(How = How.Name, Using = "bt5")]
        public IWebElement btnNum5 { get; set; }

        [FindsBy(How = How.Name, Using = "bt6")]
        public IWebElement btnNum6 { get; set; }

        [FindsBy(How = How.Name, Using = "bt7")]
        public IWebElement btnNum7 { get; set; }

        [FindsBy(How = How.Name, Using = "bt8")]
        public IWebElement btnNum8 { get; set; }

        [FindsBy(How = How.Name, Using = "bt9")]
        public IWebElement btnNum9 { get; set; }

        [FindsBy(How = How.Name, Using = "bt0")]
        public IWebElement btnNum0 { get; set; }

        // operations
        [FindsBy(How = How.Name, Using = "plus")]
        public IWebElement btnPlus { get; set; }

        [FindsBy(How = How.Name, Using = "sub")]
        public IWebElement btnMin { get; set; }

        [FindsBy(How = How.Name, Using = "mul")]
        public IWebElement btnMult { get; set; }

        [FindsBy(How = How.Name, Using = "div")]
        public IWebElement btnDiv { get; set; }

        // ------------
        [FindsBy(How = How.Name, Using = "count")]
        public IWebElement btnCount { get; set; }

        [FindsBy(How = How.Name, Using = "clear")]
        public IWebElement btnClear { get; set; }
        
        // display
        [FindsBy(How = How.Name, Using = "input")]
        public IWebElement display { get; set; }

        public int realJob(string input)
        {
            int res = 0;

            display.SendKeys(input);
            btnCount.Click();

            try
            {
                res = int.Parse(display.GetAttribute("value"));
            }
            catch(Exception)
            { }

            return res;
        }
    }

    [TestClass]
    public class CalcPagePattern
    {
        private static IWebDriver Driver;
        private static ClalcPage pCalc;

        // инициализация и открытие браузера при начале тестирования
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Driver = new ChromeDriver();
            pCalc = new ClalcPage(Driver);
            pCalc.Navigate();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Driver.Close();
            Driver.Quit();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Driver.Navigate().Refresh();
        }

        [TestMethod]
        public void TestBtnNum1Exist()
        {
            bool exist = pCalc.btnNum1.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum2Exist()
        {
            bool exist = pCalc.btnNum2.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum3Exist()
        {
            bool exist = pCalc.btnNum3.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum4Exist()
        {
            bool exist = pCalc.btnNum4.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum5Exist()
        {
            bool exist = pCalc.btnNum5.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum6Exist()
        {
            bool exist = pCalc.btnNum6.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum7Exist()
        {
            bool exist = pCalc.btnNum7.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum8Exist()
        {
            bool exist = pCalc.btnNum8.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum9Exist()
        {
            bool exist = pCalc.btnNum9.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum0Exist()
        {
            bool exist = pCalc.btnNum0.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnMinExist()
        {
            bool exist = pCalc.btnMin.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnPlusExist()
        {
            bool exist = pCalc.btnPlus.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnMultExist()
        {
            bool exist = pCalc.btnMult.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnDIvExist()
        {
            bool exist = pCalc.btnDiv.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnClearExist()
        {
            bool exist = pCalc.btnClear.Displayed;
            Assert.IsTrue(exist);
        }

        [TestMethod]
        public void TestBtnNum1Simple()
        {
            pCalc.btnNum1.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("1", act);
        }

        [TestMethod]
        public void TestBtnNum2Simple()
        {
            pCalc.btnNum2.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("2", act);
        }

        [TestMethod]
        public void TestBtnNum3Simple()
        {
            pCalc.btnNum3.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("3", act);
        }

        [TestMethod]
        public void TestBtnNum4Simple()
        {
            pCalc.btnNum4.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("4", act);
        }

        [TestMethod]
        public void TestBtnNum5Simple()
        {
            pCalc.btnNum5.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("5", act);
        }

        [TestMethod]
        public void TestBtnNum6Simple()
        {
            pCalc.btnNum6.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("6", act);
        }

        [TestMethod]
        public void TestBtnNum7Simple()
        {
            pCalc.btnNum7.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("7", act);
        }

        [TestMethod]
        public void TestBtnNum8Simple()
        {
            pCalc.btnNum8.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("8", act);
        }

        [TestMethod]
        public void TestBtnNum9Simple()
        {
            pCalc.btnNum9.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("9", act);
        }

        [TestMethod]
        public void TestBtnNum0Simple()
        {
            pCalc.btnNum0.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual("0", act);
        }

        [TestMethod]
        public void TestBtnPlusSimple()
        {
            pCalc.btnPlus.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual(" + ", act);
        }

        [TestMethod]
        public void TestBtnMinusSimple()
        {
            pCalc.btnMin.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual(" - ", act);
        }

        [TestMethod]
        public void TestBtnMultSimple()
        {
            pCalc.btnMult.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual(" * ", act);
        }

        [TestMethod]
        public void TestBtnDivSimple()
        {
            pCalc.btnDiv.Click();
            string act = pCalc.display.GetAttribute("value");
            Assert.AreEqual(" / ", act);
        }

        [DataTestMethod]
        [DataRow("1 + 3", 4)]
        [DataRow("7 - 5", 2)]
        [DataRow("2 * 6", 12)]
        [DataRow("20 / 4", 5)]

        [TestMethod]
        public void realJob_test(string inp, int exp)
        {
            int act = pCalc.realJob(inp);
            Assert.AreEqual(exp, act);            
        }
    }   
}
