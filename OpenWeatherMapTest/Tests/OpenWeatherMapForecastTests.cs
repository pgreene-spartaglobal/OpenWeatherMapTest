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
        }
        // Check for successful web call 200
        [Test]
        public void WebCallSuccessCheck()
        {
            Assert.AreEqual(200, openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.cod);
        }
        // Check for message parameter - Check for return greater than 0
        [Test]
        public void MessageCheck()
        {
            Assert.Greater(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.message, 0);
        }
        // Number of lines returned by this API call - Check for return greater than 0
        [Test]
        public void CountCheck()
        {
            Assert.Greater(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.cnt, 0);
        }
        // list.dt Time of data forecasted, unix, UTC - Check for valid unix format
        [Test]
        public void DTCheck()
        {
            // Convert unix to DateTime
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime dtDate = origin.AddSeconds(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].dt);

            // Check DateTime string is valid
            DateTime parsedDate;
            bool isValid = false;
            isValid = DateTime.TryParse(dtDate.ToString(), out parsedDate);

            Assert.IsTrue(isValid);
        }
        // Temperature is stored in degrees Kelvin by default
        // Check the temperature is within +/- 200 degrees Kelvin from 0 degrees celsius (273.15 Kelvin)
        [Test]
        public void TempCheck()
        {
            Assert.That(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.temp, Is.EqualTo(273.15).Within(200));
        }
        [Test]
        public void TempMinCheck()
        {
            Assert.That(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.temp_min, Is.EqualTo(273.15).Within(200));
        }
        [Test]
        public void TempMaxCheck()
        {
            Assert.That(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.temp_max, Is.EqualTo(273.15).Within(200));
        }
        [Test]
        public void PressureCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.pressure);
        }
        [Test]
        public void SeaLevelCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.sea_level);
        }
        [Test]
        public void GroundLevelCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.grnd_level);
        }
        [Test]
        public void HumidityCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.humidity);
        }
        [Test]
        public void TempKfCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.temp_kf);
        }
    }
}
