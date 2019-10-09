using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace OpenWeatherMapTest
{
    class OpenWeatherMapConfig
    {
        public static readonly String BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly String ApiKey = ConfigurationManager.AppSettings["api_key"];
        public static readonly String ApiUrlMod = ConfigurationManager.AppSettings["api_key_url_mod"];
        public static readonly String ForecastLocation = ConfigurationManager.AppSettings["forecast_location"];
    }
}
