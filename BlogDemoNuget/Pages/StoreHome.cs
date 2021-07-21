using AdvUITestLogger;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemoNuget.Pages
{
    public class StoreHome
    {
        public static void SearchItem(IWebDriver driver, string searchStr)
        {
            driver.FindElement(By.Name("search")).SendKeys(searchStr + Keys.Enter);
            AdvLogger.Current.LogMessage("Passed", driver);
        }

        public static void LoadStoreHome(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Url = "https://demo.opencart.com/";
            AdvLogger.Current.LogMessage("Passed", driver);
        }
    }
}
