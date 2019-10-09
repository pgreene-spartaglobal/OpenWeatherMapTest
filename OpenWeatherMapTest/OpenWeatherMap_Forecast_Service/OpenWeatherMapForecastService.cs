using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using OpenWeatherMapTest.OpenWeatherMap_Forecast_Service.Data_Handling;
using OpenWeatherMapTest.OpenWeatherMap_Forecast_Service.HTTP_Manager;

namespace OpenWeatherMapTest.OpenWeatherMap_Forecast_Service
{
    class OpenWeatherMapForecastService
    {
        // We need DTO
        public OpenWeatherMapForecastDTO openWeatherMapForecastDTO = new OpenWeatherMapForecastDTO();
        // We need Call Manager
        public OpenWeatherMapForecastCallManager openWeatherMapForecastCallManager = new OpenWeatherMapForecastCallManager();
        public String Parameters { get; set; }
        // We need JObject
        public JObject OpenWeatherMapForecastJSON;
        public OpenWeatherMapForecastService()
        {
            openWeatherMapForecastDTO.DeserializeForecast(openWeatherMapForecastCallManager.GetForecast(Parameters));
            OpenWeatherMapForecastJSON = JObject.Parse(openWeatherMapForecastCallManager.GetForecast(Parameters));
        }
    }
}
