using MyQH_Mobile_Test.PageObjects.MyPlanTab;
using MyQHMobileAutomation.PageObjects;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace MyQH_Mobile_Test.Steps
{
    [Binding]
    public sealed class NavigationSteps
    {
        HomePage _homePage;
        MyPlanPage _myPlanPage;

        public NavigationSteps()
        {
            _homePage = new HomePage();
            _myPlanPage = new MyPlanPage();
        }

        [Given(@"is on the Care Finder page")]
        public void GivenIsOnTheCareFinderPage()
        {
            _homePage.NavigateTo("my plan");
            _myPlanPage.MyPlanTabs("care finder");
        }
    }
}
