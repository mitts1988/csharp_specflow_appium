using MyQH_Mobile_Test.PageObjects;
using MyQHMobileAutomation.Drivers;
using OpenQA.Selenium.Appium.Android;

namespace MyQHMobileAutomation.PageObjects
{
    class LoginPage : BasePage
    {
        private AndroidElement EmailAddresssTextField => Driver.FindElementById("authentication_email_editText");
        private AndroidElement PasswordTextField => Driver.FindElementById("authentication_password_editText");
        private AndroidElement LoginButton => Driver.FindElementById("authentication_button");
        private AndroidElement ErrorMessageTitle => Driver.FindElementById("alertTitle");
        private AndroidElement ErrorMessageText => Driver.FindElementById("android:id/message");
        private AndroidElement ErrorMessageTryAgainButton => Driver.FindElementById("android:id/button2");

        public LoginPage() { }

        public void Login(string email, string password)
        {
            EmailAddresssTextField.SendKeys(email);
            PasswordTextField.SendKeys(password);
            LoginButton.Click();
        }

        public bool LoginErrorIsDisplayed()
        {
            string expectedErrorMessageText = "There was a problem logging you in. Please contact a Care Coordinator for additional information.";
            string expectedErrorMessageTitle = "Error";
            string expectedErrorMessageButtonText = "TRY AGAIN";
            // FYI error message is hard coded and doesn't come from API
            return ErrorMessageText.GetAttribute("text").Equals(expectedErrorMessageText) &&
                ErrorMessageText.Displayed &&
                ErrorMessageTitle.GetAttribute("text").Equals(expectedErrorMessageTitle) &&
                ErrorMessageTitle.Displayed &&
                ErrorMessageTryAgainButton.GetAttribute("text").Equals(expectedErrorMessageButtonText) &&
                ErrorMessageTryAgainButton.Displayed;
        }
    }
}
