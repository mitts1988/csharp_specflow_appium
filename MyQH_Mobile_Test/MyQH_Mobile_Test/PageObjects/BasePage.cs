using MyQHMobileAutomation.Drivers;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyQH_Mobile_Test.PageObjects
{
    class BasePage
    {
        public AndroidDriver<AndroidElement> Driver;

        // Buttons that appear on most pages
        public AndroidElement profileButton => Driver.FindElementById("profile_image_button");
        public AndroidElement idCardButton => Driver.FindElementById("get_id_card_button");
        public AndroidElement homeTabButton => Driver.FindElementByAccessibilityId("Home");
        public AndroidElement myPlanTabButton => Driver.FindElementByAccessibilityId("My Plan");
        public AndroidElement myHealthTabButton => Driver.FindElementByAccessibilityId("My Health");
        public AndroidElement scheduleCallButton => Driver.FindElementById("connect_floating_action_button");

        public BasePage()
        {
            Driver = MyQHAndroidDriver.Driver;
        }

        public void NavigateTo(string desiredButton)
        {
            AndroidElement button = desiredButton switch
            {
                "profile" => profileButton,
                "id card" => idCardButton,
                "home" => homeTabButton,
                "my plan" => myPlanTabButton,
                "my health" => myHealthTabButton,
                "schedule call" => scheduleCallButton,
                _ => homeTabButton,
            };
            button.Click();
        }
    }
}
