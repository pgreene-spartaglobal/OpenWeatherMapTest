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

All data points would be tested as testing the content is the most important thing to test
### OpenWeatherMapForecastTests


## Conclusion
