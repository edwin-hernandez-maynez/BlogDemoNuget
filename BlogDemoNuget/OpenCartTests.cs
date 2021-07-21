using AdvUITestLogger;
using BlogDemoNuget.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BlogDemoNuget
{
    [TestClass]
    public class OpenCartTests
    {
        //CREATE A TEST CONTEXT
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        IWebDriver driver;

        [TestInitialize]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\Users\edwinh\source\repos\BlogDemoNuget\BlogDemoNuget");
            

            //INITIALIZE LOGGER:
            AdvLogger.imageSize = 400;
            AdvLogger.includeSnapshootsForPassAndError = true;
            AdvLogger.onHoverImageSizeAsPercentageOfWindow = 50;
            AdvLogger.Current.LOGLEVEL = 3;     //Logger will include only messages at specified level or above. Level=1 means no filters
                                                //levels: 1=info, 2-passed, 3-warning, 4-error
            
                                                

        }

        [TestMethod]
        public void OpenCart_ValidateReviewSubmision()
        {
            AdvLogger.Current.InsertDividerForNewTest();

            StoreHome.LoadStoreHome(driver);

            StoreHome.SearchItem(driver, "iphone");

            SearchResults.SortItemsBy(driver, 4);

            SearchResults.OpenItem(driver, 1);

            ItemPage.GotoReviews(driver);

            ItemPage.PostAReview(driver
                , "UITester", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam eget nisi a nunc varius dictum at sit amet diam. Donec posuere gravida dui vitae elementum. In efficitur sodales erat a consectetu"
                , 4);

            string msg = ItemPage.GetReviewMessage(driver);

            Assert.AreEqual("Thank you for your review. It has been submitted to the webmaster for approval.", msg);
            
            AdvLogger.Current.LogMessage("Info", driver, "Validation passed");

            AdvLogger.Current.LogMessage("Info", driver, "REACHED END OF TEST CASE");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
            var fileName = AdvLogger.Current.EndLogging(TestContext);
            System.Diagnostics.Process.Start("explorer.exe", fileName);

        }
    }
}
