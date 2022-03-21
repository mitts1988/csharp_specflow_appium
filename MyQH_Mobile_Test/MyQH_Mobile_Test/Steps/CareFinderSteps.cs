using MyQH_Mobile_Test.PageObjects;
using MyQH_Mobile_Test.Utilities;
using MyQH_Mobile_Test.Utilities.DataModels;
using MyQHMobileAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace MyQH_Mobile_Test.Steps
{
    [Binding]
    class CareFinderSteps
    {
        CareFinderPage _careFinderPage;
        CareFinderResponse _searchResponse;

        public CareFinderSteps()
        {
            _careFinderPage = new CareFinderPage();
        }

        [When(@"user searches Care Finder for a (.*) with (.*) near (.*)")]
        public void WhenUserSearchesForAProviderByName(string searchType, string searchTerm, string zip)
        {
            switch (searchType)
            {
                case "facilityByType":
                    if(searchTerm == "random")
                    {
                        searchTerm = ApiService.GetRandomFacilityType();
                        Console.WriteLine(searchTerm);
                    }
                    zip = _careFinderPage.SearchFacilityByType(searchTerm, zip);
                    _searchResponse = ApiService.FacilitySearchByType(searchTerm, zip);
                    break;
                case "procedureByName":
                    break;
                case "procedureByNameOrNPI":
                    break;
                case "providerBySpecialty":
                    break;
                default:
                    //default covers facilityByName
                    zip = _careFinderPage.SearchFacilityByName(searchTerm, zip);
                    _searchResponse = ApiService.FacilitySearchByName(searchTerm, zip);
                    break;
            }
        }

        [Then(@"results displayed match the API call results")]
        public void ThenResultsAreDisplayed()
        {            
            Assert.IsTrue(_careFinderPage.ValidateSearchResults(_searchResponse), "Search results are incorrect");
        }
    }
}
