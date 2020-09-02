﻿namespace AnorocMobileApp.Models
{
    public class Constants
    {

        /*public static bool IsDev = true;
        public static readonly string GoogleClientID = "googleID on google project .apps.googleusercontent.com";
        public static readonly string GoogleClientSecret = "google secret on google project";
       
        public static readonly string FacebookAppID = "985395151878298";*/
        public static readonly string googleAPIKey = "//KEY HERE//";
        public static readonly string clientID = $"{googleAPIKey}.apps.googleusercontent.com";
        public static readonly string redirectUrl = $"com.googleusercontent.apps.{googleAPIKey}:/oauth2redirect";
        public static readonly string AnorocURI = "https://192.168.43.196:5001/";
         public static bool IsDev = true;
        public static readonly string GoogleClientID = "googleID on google project .apps.googleusercontent.com";
        public static readonly string GoogleClientSecret = "google secret on google project";
       
        public static readonly string FacebookAppID = "985395151878298";

        public static readonly string GooglePlacesApiAutoCompleteUrl =
            "https://maps.googleapis.com/maps/api/place/autocomplete/json?key={0}&input={1}&components=country:za";

        public static readonly string AzureFuzzySearchUrl =
            "https://atlas.microsoft.com/search/fuzzy/json?api-version=1.0&query={0}&subscription-key={1}&countrySet=ZA&limit=5";
    }

}
