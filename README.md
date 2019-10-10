# OpenWeatherMap API Test
## Table of Contents
* [Introduction](#introduction)
* [Implementation](#implementation)
* [Testing](#testing)
* [NuGet Packages](#nuget-packages)
* [Conclusion](#conclusion)
## Introduction
API testing for the [OpenWeatherMap.org](https://openweathermap.org/api) 5 day / 3 hour weather forecast. 

The aim of this project was to test the GET response output (in JSON) from the OpenWeatherMap API to check the recieved responses' validity. 

All tests were based on the weather forecast for London.
## NuGet Packages

 - [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) - Json .Net is a popular high-performance JSON framework for .NET
 - [NUnit](https://www.nuget.org/packages/NUnit/) - NUnit is a unit-testing framework for all .Net languages with a strong TDD focus.
 - [NUnit3TestAdapter](https://www.nuget.org/packages/NUnit3TestAdapter/) - NUnit 3 adapter for running tests in Visual Studio.
 - [RestSharp](https://www.nuget.org/packages/RestSharp/) - Simple REST and HTTP API Client

## Implementation
### OpenWeatherMapForecastService
The service class is an overarching class that creates instances of the data handling and http manager classes acting as an entry point for access.

The service will call the DeserializeForecast method in the DTO in order to deserialize the JSON response received from the CallManager 
### OpenWeatherMapForecastCallManager
Creates a new REST client to make requests to the API and return the response that is deserialized by the DTO.

To create the request, data is retrieved from the OpenWeatherMapConfig class which reads from the app settings in the App.config file
### OpenWeatherMapForecastDTO
The DTO (Data Transfer Object) acts only to pass the data from the response received to the data model, thus deserializing it.
### OpenWeatherMapForecastModel
Defines the data types that each data point received from the response will be converted to.
## Testing
To decide on what to test as well as to determine what would be needed in the model [Postman](https://www.getpostman.com/) was used to view the response received from the API.
### JSON Example of API Response:

    {
        "cod":  "200",        
        "message":  0.0121,        
        "cnt":  40,        
        "list":  [        
	        {        
		        "dt":  1570676400,       
		        "main":  {        
			        "temp":  281.27,        
			        "temp_min":  281.27,        
			        "temp_max":  282.63,        
			        "pressure":  1008.14,        
			        "sea_level":  1008.14,        
			        "grnd_level":  1003.37,        
			        "humidity":  80,        
			        "temp_kf":  -1.36        
			    },        
		        "weather":  [       
			        {        
				        "id":  800,        
				        "main":  "Clear",        
				        "description":  "clear sky",        
				        "icon":  "01n"        
			        }        
		        ],        
		        "clouds":  {        
			        "all":  0        
		        },        
		        "wind":  {        
			        "speed":  5.2,        
			        "deg":  260.476        
		        },        
		        "sys":  {        
			        "pod":  "n"        
		        },        
    			"dt_txt":  "2019-10-10 03:00:00"
	    	}
    	],
    	"city":  {    
	    "id":  2643743,    
	    "name":  "London",    
	    "coord":  {    
		    "lat":  51.5085,    
		    "lon":  -0.1258    
	    },    
	    "country":  "GB",    
	    "population":  1000000,    
	    "timezone":  3600,    
	    "sunrise":  1570688109,    
	    "sunset":  1570727985    
	    }    
	}
All data points would be tested as testing the content is the most important thing to test, the headers would also be tested to check the content type, connection and server.
### OpenWeatherMapForecastTests
Creates an instance of the service in order to run tests against it
### Tests run on data points
#### root
 - "cod" - Check for a successful web call 200
 - "message" - Check message greater than 0
 - "cnt" - Check number of lines returned is greater than 0

#### list
 Note: List is an array, only the first object in the array was tested
 - "dt" - Check date is correct length
 
**main**

*Check the temperature is within +/- 200 degrees Kelvin from 0 degrees celsius (273.15 Kelvin)*
 - "temp" - Check within valid Kelvin range
 - "temp_min" - Check within valid Kelvin range
 - "temp_max" - Check within valid Kelvin range
*Atmospheric pressure in hPa (hectopascal), check within +/- 500 from 1000 hPa*
 - "pressure" - Check within valid pressure range at sea level by default
 - "sea_level" - Check within valid pressure range at sea level
 - "grnd_level" - Check within valid pressure range at ground level
 - "humidity" - Measured in %. Check that it is between 0 and 100
 - "temp_kf" - Check not null
 
**weather**

Note: Weather is an array, only the first object in the array was tested
 - "id" - Check that id is a valid weather code ([Weather Codes](https://openweathermap.org/weather-conditions))
 - "main" - Check not null
 - "description" - Check not null
 - "icon" - Check not null
 
**clouds**

 - "all" - Measured in %. Check that it is between 0 and 100
**wind**

- "speed" - Check wind speed is greater than or equal to 0
- "deg" - Check that wind direction is between 0 and 360 degrees
**rain**

- "3h" - Serialized at runtime as variables cannot begin with a number. Since it may not have rained a null reference is checked first before then checking if rain is greater than or equal to 0
**sys** 

- "pod" - Check not null
 - "dt_text" - Check date is correct length
#### city
- "id" - Check not null
- "name" - Check not null

**coord**

- "lat" - Check not null
- "lon" - Check not null
- "country" - Check country length is 2 such as "GB" for Great Britain
- "population" - Check is positive
- "timezone" - Check within valid range -43200 for -12:00 and +50400 for +14:00
- "sunrise" - Check that time is past 4am
- "sunset" - Check that time is past 4pm
### Tests run on Headers
- Connection -  Check is keep-alive
- Content-Type - Check is JSON
- Server - Check is openresty
## Conclusion
Given more time more tests could have been written to test such things as data type as well as tests on multiple data points to ensure they are matching, for example testing that the city id and city name both relate to London. Overall I am satisfied with the amount of testing performed as the most important parts have been covered with at least 1 test on each data point. 
