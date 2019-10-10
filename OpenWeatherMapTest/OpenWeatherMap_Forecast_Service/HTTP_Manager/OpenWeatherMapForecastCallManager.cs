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
        public IRestResponse restResponse { get; set; }
        public OpenWeatherMapForecastCallManager()
        {
            restClient = new RestClient(OpenWeatherMapConfig.BaseUrl);
        }
        public string GetForecast()
        {
            // Generate a new request based on the values set in the config
            var request = new RestRequest("/data/2.5/forecast?" + OpenWeatherMapConfig.ForecastLocation + "&" + OpenWeatherMapConfig.ApiUrlMod + OpenWeatherMapConfig.ApiKey);
            var response = restClient.Execute(request, Method.GET);
            restResponse = response;
            return response.Content;
        }
    }
}
