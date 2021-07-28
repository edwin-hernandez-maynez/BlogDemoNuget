using AdvUITestLogger;
using BlogDemoNuget.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BlogDemoNuget
{
    [TestFixture]
    public class OpenCartTests
    {
        //CREATE A TEST CONTEXT
        //private TestContext testContextInstance;
        //public TestContext TestContext
        //{
        //    get { return testContextInstance; }
        //    set { testContextInstance = value; }
        //}

        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new ChromeDriver(@"C:\Users\edwinh\source\repos\BlogDemoNuget\BlogDemoNuget");
            

            //INITIALIZE LOGGER:
            AdvLogger.imageSize = 400;                                  //In Pixels. Default is 300
            AdvLogger.includeSnapshootsForPassAndError = true;          //Only Pass and Error levels include snapshots. Default is true
            AdvLogger.onHoverImageSizeAsPercentageOfWindow = 50;        //How big you want your screenhots to expant to. Default is 100% of browser screen width.
            AdvLogger.Current.LOGLEVEL = 3;                             //Logger will include only messages at specified level or above. Level=1 means no filters
                                                                        //levels: 1=info, 2-passed, 3-warning, 4-error
            
                                                

        }

        [Test]
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

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
            var fileName = AdvLogger.Current.EndLogging(TestContext.CurrentContext);
            System.Diagnostics.Process.Start("explorer.exe", fileName);

        }
    }
}
