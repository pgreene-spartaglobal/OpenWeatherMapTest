using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace OpenWeatherMapTest.OpenWeatherMap_Forecast_Service.Data_Handling
{
    class OpenWeatherMapForecastDTO
    {
        public OpenWeatherMapForecastRoot openWeatherMapForecastRoot { get; set; }
        public void DeserializeForecast(String OpenWeatherMapForecastResponse)
        {
            openWeatherMapForecastRoot = JsonConvert.DeserializeObject<OpenWeatherMapForecastRoot>(OpenWeatherMapForecastResponse);
        }
    }
}
