using MyQH_Mobile_Test.Utilities.DataModels;
using Newtonsoft.Json;
using System;
using NUnit.Framework;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Linq;

namespace MyQH_Mobile_Test.Utilities
{
    

    class ApiService
    {
        private static readonly string baseURL = "https://memberapitest.quantum-health.com/";
        private static string MobileLogin()
        {
            string urlRoute = "api/credential/mobilelogin";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            //POST method
            var loginBody = new LoginBody() { userName = "kindred@dev3.com", password = "Password!23", groupId = 0 };

            var response = client.PostAsJsonAsync(urlRoute, loginBody).Result;
            Assert.IsTrue(response.IsSuccessStatusCode, "API call failed - login - " + 
                response.StatusCode + " " + response.Content.ReadAsStringAsync().Result);
            
            // Parse the response body for the token
            LoginResponse loginResponse = response.Content.ReadAsAsync<LoginResponse>().Result;
            string token = loginResponse.token;

            //Cleanup
            client.Dispose();

            return token;
        }

        public static CareFinderResponse FacilitySearchByName(string searchTerm, string zip)
        {
            HttpClient client = SetupRequest();
            string urlRoute = "api/providersearch/facilitysearch";
            
            //create search request body
            Sorts sort1 = new Sorts() { SortProperty = "overallQualityIndicator", SortDirection = "Ascending" };
            Sorts sort2 = new Sorts() { SortProperty = "displayDistanceNumeric", SortDirection = "Ascending" };
            Sorts sort3 = new Sorts() { SortProperty = "displayName", SortDirection = "Ascending" };
            Sorts[] sorts = { sort1, sort2, sort3 };
            var careFinderRequestBody = new CareFinderRequest()
            {
                Name = searchTerm,
                Zip = zip,
                Distance = 10,
                PageSize = 10,
                PageNumber = 1,
                Sorts = sorts,
                InitialSearch = true
            };

            //executes the POST request
            var response = client.PostAsJsonAsync(urlRoute, careFinderRequestBody).Result;

            Assert.IsTrue(response.IsSuccessStatusCode, "API call failed - Search By Name - " + 
                response.StatusCode + " " +  response.Content.ReadAsStringAsync().Result);

            //parse response
            dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
            CareFinderResponse searchResponse = new CareFinderResponse()
            {
                DisplayName = jsonResponse.facilities[0].displayName,
                AddressLine1 = jsonResponse.facilities[0].addressLine1,
                AddressLine2 = jsonResponse.facilities[0].addressLine2,
                Telephone = jsonResponse.facilities[0].telephone,
                City = jsonResponse.facilities[0].city,
                DisplayDistance = jsonResponse.facilities[0].displayDistance,
                State = jsonResponse.facilities[0].state,
                Zip = jsonResponse.facilities[0].zip,
                Type = jsonResponse.facilities[0].type
            };

            //Cleanup
            client.Dispose();
            return searchResponse;
        }

        public static CareFinderResponse FacilitySearchByType(string facilityType, string zip)
        {
            HttpClient client = SetupRequest();
            string urlRoute = "api/providersearch/facilitysearch";

            string facilityTypeId = GetFacilityTypeId(facilityType);
            
            //create search request body
            Sorts sort1 = new Sorts() { SortProperty = "overallQualityIndicator", SortDirection = "Ascending" };
            Sorts sort2 = new Sorts() { SortProperty = "displayDistanceNumeric", SortDirection = "Ascending" };
            Sorts sort3 = new Sorts() { SortProperty = "displayName", SortDirection = "Ascending" };
            Sorts[] sorts = { sort1, sort2, sort3 };
            var careFinderRequestBody = new CareFinderRequest()
            {
                FacilityTypeId = facilityTypeId,
                FacilityTypeName = facilityType,
                Zip = zip,
                Distance = 10,
                PageSize = 10,
                PageNumber = 1,
                Sorts = sorts,
                InitialSearch = true
            };

            //executes the POST request
            var response = client.PostAsJsonAsync(urlRoute, careFinderRequestBody).Result;


            Assert.IsTrue(response.IsSuccessStatusCode, "API call failed - Search By Name - " +
                response.StatusCode + " " + response.Content.ReadAsStringAsync().Result);
            //var searchResponse = response.Content.ReadAsStringAsync().Result;

            //parse response
            dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);
            CareFinderResponse searchResponse = new CareFinderResponse()
            {
                DisplayName = jsonResponse.facilities[0].displayName,
                AddressLine1 = jsonResponse.facilities[0].addressLine1,
                AddressLine2 = jsonResponse.facilities[0].addressLine2,
                Telephone = jsonResponse.facilities[0].telephone,
                City = jsonResponse.facilities[0].city,
                DisplayDistance = jsonResponse.facilities[0].displayDistance,
                State = jsonResponse.facilities[0].state,
                Zip = jsonResponse.facilities[0].zip,
                Type = jsonResponse.facilities[0].type
            };

            //Cleanup
            client.Dispose();
            return searchResponse;
        }

        private static HttpClient SetupRequest()
        {
            //get the auth token and add it tp header
            string token = MobileLogin();

            //Sets up request
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "QH-ApiAuth " + token);
            return client;
        }

        private static string GetFacilityTypeId(string facilityType)
        {
            HttpClient client = SetupRequest();
            string urlRoute = "api/providersearch/facilitytypes";
            
            var response = client.GetAsync(urlRoute).Result;
            /*dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result);*/

            string result = "";
            if (response.IsSuccessStatusCode)
            {
                var facilityTypes = response.Content.ReadAsAsync<IEnumerable<FacilityType>>().Result;
                foreach (FacilityType f in facilityTypes)
                {
                    if (f.name == facilityType)
                    {
                        result = f.hcbbKey;
                    }
                }
            }
            return result;
        }

        public static string GetRandomFacilityType()
        {
            HttpClient client = SetupRequest();
            string urlRoute = "api/providersearch/facilitytypes";

            var response = client.GetAsync(urlRoute).Result;
            string result = "";
            if (response.IsSuccessStatusCode)
            {
                var temp = response.Content.ReadAsAsync<IEnumerable<FacilityType>>().Result;
                List<FacilityType> facilityTypes = new List<FacilityType>();
                foreach (FacilityType f in temp)
                {
                    facilityTypes.Add(f);
                }
                int randIndex = (new Random()).Next(0, facilityTypes.Count());
                Console.WriteLine(randIndex);
                result = facilityTypes[randIndex].name;

            }
            return result;
        }
    }
}
