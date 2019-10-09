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

            Assert.AreEqual(10, openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].dt.ToString().Length);

            //// Convert unix to DateTime
            //DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //DateTime dtDate = origin.AddSeconds(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].dt);

            //// Check DateTime string is valid
            //DateTime parsedDate;
            //bool isValid = false;
            //isValid = DateTime.TryParse(dtDate.ToString(), out parsedDate);

            //Assert.IsTrue(isValid);
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
        // Atmospheric pressure on the sea level by default in hPa (hectopascal) +/- 500 from 1000 hPa
        [Test]
        public void PressureCheck()
        {
            Assert.That(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.pressure, Is.EqualTo(1000).Within(500));
        }
        // Atmospheric pressure on the sea level in hPa (hectopascal)
        [Test]
        public void SeaLevelCheck()
        {
            Assert.That(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.sea_level, Is.EqualTo(1000).Within(500));
        }
        // Atmospheric pressure on the ground level in hPa (hectopascal)
        [Test]
        public void GroundLevelCheck()
        {
            Assert.That(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.grnd_level, Is.EqualTo(1000).Within(500));
        }
        // Humidity, % Check that it is between 0 and 100
        [Test]
        public void HumidityCheck()
        {
            double humidityValue = openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.humidity;
            Assert.IsTrue(humidityValue >= 0 && humidityValue <= 100);
        }
        [Test]
        public void TempKfCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].main.temp_kf);
        }
        // Check that the weather id is valid 
        [Test]
        public void WeatherIdCheck()
        {
            // https://openweathermap.org/weather-conditions
            int[] weatherCodes = new int[] 
            {
                // Group 2xx: Thunderstorm
                200, 201, 202, 210, 211, 212, 221, 230, 231, 232,
                // Group 3xx: Drizzle
                300, 301, 302, 310, 311, 312, 313, 314, 321,
                // Group 5xx: Rain
                500, 501, 502, 503, 504, 511, 520, 521, 521, 522, 531,
                // Group 6xx: Snow
                600, 601, 602, 611, 612, 613, 615, 616, 620, 621, 622,
                // Group 7xx: Atmosphere
                701, 711, 721, 731, 741, 751, 761, 762, 771, 781,
                // Group 800: Clear
                800,
                // Group 80x: Clouds
                801, 802, 803, 804

            };
            Assert.Contains(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].weather[0].id, weatherCodes);
        }
        [Test]
        public void WeatherMainCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].weather[0].main);
        }
        [Test]
        public void WeatherDescriptionCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].weather[0].description);
        }
        [Test]
        public void WeatherIconCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].weather[0].icon);
        }
        // Cloudiness, % Check that it is between 0 and 100
        [Test]
        public void CloudsCheck()
        {
            double cloudinessValue = openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].clouds.all;
            Assert.IsTrue(cloudinessValue >= 0 && cloudinessValue <= 100);
        }
        // Check wind speed greater or equal to 0
        [Test]
        public void WindSpeedCheck()
        {
            Assert.GreaterOrEqual(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].wind.speed, 0);
        }
        //  Wind direction, degrees 0-360
        [Test]
        public void WindDegreeCheck()
        {
            double windSpeedValue = openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].wind.deg;
            Assert.IsTrue(windSpeedValue >= 0 && windSpeedValue <= 360);
        }
        // Rain volume for last 3 hours, mm
        [Test]
        public void RainCheck()
        {
            Assert.GreaterOrEqual(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].rain.threeh, 0);
        }
        [Test]
        public void SysCheck()
        {
            Assert.AreEqual("d", openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].sys.pod);
        }
        [Test]
        public void DtTextCheck()
        {
            //// Check DateTime string is valid
            //DateTime parsedDate;
            //bool isValid = false;
            //isValid = DateTime.TryParse(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].dt_txt, out parsedDate);
            //Assert.IsTrue(isValid);

            Assert.AreEqual(19, openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.list[0].dt_txt.ToString().Length);
        }
        [Test]
        public void CityIdCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.id);
        }
        [Test]
        public void CityNameCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.name);
        }
        [Test]
        public void CityCoordLatCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.coord.lat);
        }
        [Test]
        public void CityCoordLonCheck()
        {
            Assert.NotNull(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.coord.lon);
        }
        // Check that the country length is 2 e.g. us, ru, cn
        [Test]
        public void CityCountryCheck()
        {
            Assert.IsTrue(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.country.Length == 2);
        }
        // Check that the population is positive 
        [Test]
        public void CityPopulationCheck()
        {
            Assert.Positive(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.population);
        }
        // Check that the timezone is with valid range 
        [Test]
        public void CityTimezoneCheck()
        {
            double timeZoneValue = openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.timezone;
            Assert.IsTrue(timeZoneValue >= -43200 && timeZoneValue <= 50400);
        }
        // Check sunrise is past 4am
        [Test]
        public void CitySunriseCheck()
        { 
            // Convert unix to DateTime
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime sunriseDate = origin.AddSeconds(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.sunrise);

            Assert.GreaterOrEqual(sunriseDate.Hour, 4);
        }
        // Check sunset is past 4pm
        [Test]
        public void CitySunsetCheck()
        {
            // Convert unix to DateTime
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime sunsetDate = origin.AddSeconds(openWeatherMapForecastService.openWeatherMapForecastDTO.openWeatherMapForecastRoot.city.sunset);
            Assert.GreaterOrEqual(sunsetDate.Hour, 16);
        }
    }
}
