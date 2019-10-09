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
        // Check for successful web call 200
        [Test]
        public void WebCallSuccessCheck()
        {
            Assert.AreEqual(200, openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.cod);
        }
        // Check for message parameter
        [Test]
        public void MessageCheck()
        {
            Assert.Greater(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.message, 0);
        }
        // Number of lines returned by this API call, check for return
        [Test]
        public void CountCheck()
        {
            Assert.Greater(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.cnt, 0);
        }
    }
}
