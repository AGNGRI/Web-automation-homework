using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace Homework
{
    public class Tests
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()

        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.demoblaze.com/index.html");
        }

        [Test, Order(1)]
        
        public void SignUP()
        {
            var Button = driver.FindElement(By.Id("signin2"));
            Button.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var username = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("sign-username")));
            username.SendKeys("agn2");

            var password = driver.FindElement(By.Id("sign-password"));         
            password.SendKeys("a1");

            var Button2 = driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[2]"));
            Button2.Click();

            var wait2 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.AlertIsPresent());
            driver.SwitchTo().Alert().Accept();
        }

        [Test, Order(2)]
        
        public void LoginIn()
        {
            var Button3 = driver.FindElement(By.Id("login2"));
            Button3.Click();

            var wait3 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var username = wait3.Until(ExpectedConditions.ElementToBeClickable(By.Id("loginusername")));
            username.SendKeys("agn2");

            var password = driver.FindElement(By.Id("loginpassword"));
            var Button4 = driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[3]"));

            password.SendKeys("a1");
            Button4.Click();

            Thread.Sleep(4000);

            Assert.IsTrue(driver.FindElement(By.Id("nameofuser")).Displayed);
            Console.WriteLine("Login Successful");

        }

        [Test, Order(3)]
        
        public void SelectItem()
        {
            var wait4 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait4.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@class='list-group-item'])[3]"))).Click();

            Thread.Sleep(1000);

            var wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait5.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//img[@class='card-img-top img-fluid'])[3]"))).Click();

            var wait6 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait6.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[@class='btn btn-success btn-lg'])"))).Click();
               
            var wait7= new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait7.Until(ExpectedConditions.AlertIsPresent());

            var alertText = driver.SwitchTo().Alert();

            Assert.That(alertText.Text, Is.EqualTo("Product added."));
            Console.WriteLine(alertText.Text);

            driver.SwitchTo().Alert().Accept();

        }

        [Test, Order(4)]
        
        public void FinishPurchase()
        {
            var wait8 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait8.Until(ExpectedConditions.ElementToBeClickable(By.Id("cartur"))).Click();

            var wait9 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait9.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//button[@class='btn btn-success'])"))).Click();

            var wait10 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait10.Until(ExpectedConditions.ElementToBeClickable(By.Id("name"))).SendKeys("Agne");

            var country = driver.FindElement(By.Id("country"));
            var city = driver.FindElement(By.Id("city"));
            var CreditCard = driver.FindElement(By.Id("card"));
            var month = driver.FindElement(By.Id("month"));
            var year = driver.FindElement(By.Id("year"));
            var Button8 = driver.FindElement(By.XPath("(//button[@class='btn btn-primary'])[3]"));

            country.SendKeys("Lithuania");
            city.SendKeys("Kaunas");
            CreditCard.SendKeys("123456");
            month.SendKeys("01");
            year.SendKeys("2023");
            Button8.Click();

            var Button9 = driver.FindElement(By.XPath("//button[@class='confirm btn btn-lg btn-primary']"));
            Assert.IsTrue(driver.FindElement(By.XPath("//button[@class='confirm btn btn-lg btn-primary']")).Displayed);
            Console.WriteLine("Order is completed");

            Thread.Sleep(1000);
            Button9.Click();

        }
    }
}