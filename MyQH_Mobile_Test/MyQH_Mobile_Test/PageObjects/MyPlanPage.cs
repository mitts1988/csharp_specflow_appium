using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyQH_Mobile_Test.PageObjects.MyPlanTab
{
    class MyPlanPage : BasePage
    {
        public AndroidElement overviewTabButton => Driver.FindElementByXPath("//*[@content-desc=\"Overview\"]");
        public AndroidElement careFinderTabButton => Driver.FindElementByXPath("//*[@content-desc=\"Care Finder\"]");
        public AndroidElement benefitsTabButton => Driver.FindElementByXPath("//*[@content-desc=\"Benefits\"]");
        public AndroidElement docutmentsTabButton => Driver.FindElementByXPath("//*[@content-desc=\"Documents\"]");
        public AndroidElement claimsTabButton => Driver.FindElementByXPath("//*[@content-desc=\"Claims\"]");
        public AndroidElement authorizationsTabButton => Driver.FindElementByXPath("//*[@content-desc=\"Authorizations\"]");
        public AndroidElement primaryDoctorTabButton => Driver.FindElementByXPath("//*[@content-desc=\"Primary Doctor\"]");
        public AndroidElement teladocTabButton => Driver.FindElementByXPath("//*[@content-desc=\"Teladoc\"]");

        public MyPlanPage() { }

        public void MyPlanTabs(string tab)
        {
            AndroidElement tabButton = tab switch
            {
                "overview" => overviewTabButton,
                "care finder" => careFinderTabButton,
                "benefits" => benefitsTabButton,
                "documents" => docutmentsTabButton,
                "claims" => claimsTabButton,
                "authorizations" => authorizationsTabButton,
                "primary doctor" => primaryDoctorTabButton,
                "teladoc" => teladocTabButton,
                _ => overviewTabButton,
            };
            tabButton.Click();
        }
    }
}
