using MyQH_Mobile_Test.PageObjects.MyPlanTab;
using MyQH_Mobile_Test.Utilities.DataModels;
using MyQHMobileAutomation.Drivers;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using System;

namespace MyQH_Mobile_Test.PageObjects
{
    class CareFinderPage : MyPlanPage
    {
        private AndroidElement CardiologySpecialty => Driver.FindElementByAndroidUIAutomator("new UiSelector().text(\"Cardiology\")");
        private AndroidElement FacilityByName => Driver.FindElementByAndroidUIAutomator("new UiSelector().text(\"Facility by Name\")");
        private AndroidElement FacilityByType => Driver.FindElementByAndroidUIAutomator("new UiSelector().text(\"Facility by Type\")");
        public AndroidElement FacilityTypes => MyQHAndroidDriver.ScrollToElementByResourceId("dd-facilitytypes");
        public AndroidElement ListView => MyQHAndroidDriver.ScrollToElementByResourceId("btn-list");
        public AndroidElement MapView => MyQHAndroidDriver.ScrollToElementByResourceId("btn-map");
        public AndroidElement NewSearchButton => MyQHAndroidDriver.ScrollToElementByResourceId("btn-new-search");
        public AndroidElement ProcedureSearchResultsList => MyQHAndroidDriver.ScrollToElementByText("Procedure Search Results");
        private AndroidElement ProcedureByName => Driver.FindElementByAndroidUIAutomator("new UiSelector().text(\"Procedure by Name\")");
        private AndroidElement ProviderByNameNPI => Driver.FindElementByAndroidUIAutomator("new UiSelector().text(\"Provider by Name or NPI\")");
        private AndroidElement ProviderBySpecialty => Driver.FindElementByAndroidUIAutomator("new UiSelector().text(\"Provider by Specialty\")");
        private AndroidElement ProviderDistanceSort => Driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().className(\"android.widget.Button\").text(\"Distance\"))");
        private AndroidElement ProviderNameSort => Driver.FindElementByAndroidUIAutomator("new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().className(\"android.widget.Button\").text(\"Provider\"))");
        private AndroidElement SearchType => MyQHAndroidDriver.ScrollToElementByResourceId("dd-searchtype");
        public AndroidElement ProviderQualitySort => MyQHAndroidDriver.ScrollToElementByResourceId("header_quality_ranking");
        public AndroidElement ProviderSpecialties => MyQHAndroidDriver.ScrollToElementByResourceId("dd-searchspecialties");
        public AndroidElement ResultList => MyQHAndroidDriver.ScrollToElementByResourceId("tbl_results_list");
        public AndroidElement RefineResults => MyQHAndroidDriver.ScrollToElementByResourceId("btn-filter");
        public AndroidElement SearchButton => MyQHAndroidDriver.ScrollToElementByResourceId("btn-submit-search");
        public AndroidElement SearchTerm => MyQHAndroidDriver.ScrollToElementByResourceId("input-searchterm");
        public AndroidElement SearchZip => MyQHAndroidDriver.ScrollToElementByResourceId("input-zip");
        private AndroidElement SearchResult0Name => MyQHAndroidDriver.ScrollToElementByResourceId("link_displayname_0");
        private AndroidElement SearchResult0Address => MyQHAndroidDriver.ScrollToElementByResourceId("link_address_0");
        private AndroidElement SearchResult0Phone => MyQHAndroidDriver.ScrollToElementByResourceId("txt_phone_0");
        private AndroidElement SearchResult0Distance => MyQHAndroidDriver.ScrollToElementByResourceId("txt_distance_0");
        private AndroidElement SearchResult0Type => MyQHAndroidDriver.ScrollToElementByResourceId("txt_facilitytype_0");
        
        public CareFinderPage(){ }

        public string SearchFacilityByName(string searchTerm, string zip)
        {
            Assert.AreEqual(SearchButton.GetAttribute("enabled"), "false");
            SearchType.Click();
            FacilityByName.Click();
            if (zip != "default")
            {
                SearchZip.Clear();
                SearchZip.SendKeys(zip);
            }
            else
            {
                zip = SearchZip.GetAttribute("text");
            }
            SearchTerm.SendKeys(searchTerm);
            SearchTerm.Click();
            Driver.HideKeyboard();
            SearchButton.Click();
            return zip;
        }
        public string SearchFacilityByType(string searchTerm, string zip)
        {
            Assert.AreEqual(SearchButton.GetAttribute("enabled"), "false");
            SearchType.Click();
            FacilityByType.Click();
            if (zip != "default")
            {
                SearchZip.Clear();
                SearchZip.SendKeys(zip);
            }
            else
            {
                zip = SearchZip.GetAttribute("text");
            }
            FacilityTypes.Click();
            MyQHAndroidDriver.ScrollToElementByText($"{searchTerm}").Click();
            SearchButton.Click();
            return zip;
        }


        public bool ValidateSearchResults(CareFinderResponse searchResponse)
        {
            bool correctName = SearchResult0Name.GetAttribute("content-desc").Equals(searchResponse.DisplayName);

            string expectedAddress = searchResponse.AddressLine1;
            if (searchResponse.AddressLine2 != "")
            {
                expectedAddress += ", " + searchResponse.AddressLine2;
            }
            expectedAddress += " " + searchResponse.City + ", " + searchResponse.State + " " + searchResponse.Zip;
            bool correctAddress = SearchResult0Address.GetAttribute("content-desc").Equals(expectedAddress);

            bool correctPhone = SearchResult0Phone.FindElementByAndroidUIAutomator($"new UiSelector().text(\"{searchResponse.Telephone}\")").Displayed;
            bool correctDistance = SearchResult0Distance.GetAttribute("text").Equals(searchResponse.DisplayDistance);
            bool correctType = SearchResult0Type.GetAttribute("text").Equals(searchResponse.Type);
            return correctName && correctAddress && correctPhone && correctDistance && correctType;
        }
    }
}
