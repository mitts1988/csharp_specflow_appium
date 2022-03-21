using MyQH_Mobile_Test.PageObjects;
using MyQH_Mobile_Test.Properties;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyQHMobileAutomation.PageObjects
{
    class HomePage : BasePage
    {
        AndroidElement WelcomeMessage => Driver.FindElementByAndroidUIAutomator("UiSelector().text(\"Welcome, " + Users.firstName +"!\")");
        
        public HomePage() { }
        public bool IsLoggedIn()
        {
            return WelcomeMessage.Displayed;
        }

        public void homePageTab(string destination)
        {

        }
    }
}