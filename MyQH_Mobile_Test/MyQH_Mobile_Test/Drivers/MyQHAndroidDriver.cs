using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;

namespace MyQHMobileAutomation.Drivers
{
    class MyQHAndroidDriver
    {
        public static AndroidDriver<AndroidElement> Driver;

        

        public static void InitializeDriver()
        {
            AppiumOptions driverOptions = SetCapabilities();
            Driver = new AndroidDriver<AndroidElement>(new Uri("http://localhost:4723/wd/hub"), driverOptions);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        public static void Quit()
        {
            Driver.Quit();
        }

        private static AppiumOptions SetCapabilities()
        {
            AppiumOptions driverOptions = new AppiumOptions();
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "12");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Real Phone");
            driverOptions.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            driverOptions.AddAdditionalCapability("appPackage", "com.yourcarecoordinators.android.app");
            driverOptions.AddAdditionalCapability("appActivity", "com.quantumhealth.android.app.activity.AuthenticationActivity");
            return driverOptions;
        }

        public static AndroidElement ScrollToElementByResourceId(String id)
        {
            return Driver.FindElementByAndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().resourceId(\"{id}\"))");
        }
        public static AndroidElement ScrollToElementByText(String text)
        {
            return Driver.FindElementByAndroidUIAutomator($"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"{text}\"))");
        }
    }
}
