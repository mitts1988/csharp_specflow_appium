using MyQH_Mobile_Test.Properties;
using MyQHMobileAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using TechTalk.SpecFlow;

namespace MyQHMobileAutomation.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        private readonly LoginPage loginPage;
        private readonly HomePage homePage;

        public LoginSteps()
        {
            loginPage = new LoginPage();
            homePage = new HomePage();
        }

        [Given(@"user has logged in")]
        public void Login()
        {
            loginPage.Login(Users.email, Users.password);
            Assert.IsTrue(homePage.IsLoggedIn(), "Unable to validate user is logged in");
        }

        [When(@"user tries to log in with an incorrect email")]
        public void InvalidCredentialLogin()
        {
            loginPage.Login(Users.email + "asdf", Users.password);
        }

        [Then(@"an error message is displayed")]
        public void ThenAnErrorMessageIsDisplayed()
        {
            Assert.IsTrue(loginPage.LoginErrorIsDisplayed(), "Error isn't displayed correctly");
        }
    }
}
