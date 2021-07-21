using AdvUITestLogger;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlogDemoNuget.Pages
{
    public class ItemPage
    {
        public static void GotoReviews(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//a[contains(text(),\"Reviews\")]")).Click();
            AdvLogger.Current.LogMessage("Passed", driver);
        }

        public static void PostAReview(IWebDriver driver, string Name, string Review, int Raiting)
        {
            driver.FindElement(By.Name("name")).SendKeys(Name);
            driver.FindElement(By.Name("text")).SendKeys(Review);
            driver.FindElement(By.XPath($"//input[@name='rating' and @value='{Raiting}']")).Click();
            driver.FindElement(By.Id("button-review")).Click();

            AdvLogger.Current.LogMessage("Passed", driver);
        }

        public static string GetReviewMessage(IWebDriver driver)
        {
            Thread.Sleep(2000);
            var elem = driver.FindElement(By.XPath("//div[@class='alert alert-success alert-dismissible']"));
            return elem.Text;
        }
    }
}
