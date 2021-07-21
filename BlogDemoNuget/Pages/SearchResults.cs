using AdvUITestLogger;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDemoNuget.Pages
{
    public class SearchResults
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="option">4 - Price (High > Low)</param>
        public static void SortItemsBy(IWebDriver driver, int option)
        {
            string optionStr= "";
            switch (option)
            {
                case 4: optionStr = "Price (High > Low)";
                    break;
            }
            driver.FindElement(By.Id("input-sort")).SendKeys(optionStr);
            AdvLogger.Current.LogMessage("Passed", driver);
        }

        public static void OpenItem(IWebDriver driver, int index)
        {
            driver.FindElement(By.XPath($"//div[@class='product-thumb'][{index}]//a")).Click();
            AdvLogger.Current.LogMessage("Passed", driver);
        }
    }
}
