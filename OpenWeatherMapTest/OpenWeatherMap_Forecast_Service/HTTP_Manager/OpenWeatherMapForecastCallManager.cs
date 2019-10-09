using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace OpenWeatherMapTest.OpenWeatherMap_Forecast_Service.HTTP_Manager
{
    class OpenWeatherMapForecastCallManager
    {
        readonly IRestClient restClient;
        public OpenWeatherMapForecastCallManager()
        {
            restClient = new RestClient(OpenWeatherMapConfig.BaseUrl);
        }
        public string GetForecast(String parameters)
        {
            var request = new RestRequest("/data/2.5/forecast?" + "q=London,gb" + "&" + OpenWeatherMapConfig.ApiUrlMod  + OpenWeatherMapConfig.ApiKey);
            var response = restClient.Execute(request, Method.GET);
            return response.Content;
        }
    }
}
