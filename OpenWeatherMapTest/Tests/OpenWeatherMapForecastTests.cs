using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenWeatherMapTest.OpenWeatherMap_Forecast_Service;

namespace OpenWeatherMapTest.Tests
{
    [TestFixture]
    class OpenWeatherMapForecastTests
    {
        OpenWeatherMapForecastService openWeatherMapForecastService = new OpenWeatherMapForecastService();
        public OpenWeatherMapForecastTests()
        {
            openWeatherMapForecastService.Parameters = "q=London,gb";
        }
    }
}
