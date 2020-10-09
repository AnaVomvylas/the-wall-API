# The Wall - API
This was the API for [The Wall](https://github.com/AnaVomvylas/the-wall) before deciding to use AWS Lambdas and DynamoDB instead.

## General info
This is a .NET Core REST API that uses JWT authentication. A token is returned on successful login, which can be used to access protected routes.

## Table of Contents
* [Services](#services)
* [Middleware](#middleware)
* [Controllers](#controllers)

## Services

#### JwtService

* GenerateSecurityToken 
Returns a JWT Token signed with a private key. The claim used is the username and the encryption algorithm is Sha256.

#### UserService

* CRUD functions 
For mongoDB database, using the MongoDB.Driver library.

* Authenticate
Returns true if username and password exist in the users document.

## Middleware

#### AuthenticationMiddleware
Adds token validation for controllers with the ```$ [Authorize]``` property. 

## Controllers

#### sampleTokenController
Mock controller to test the JWT service

* GET - api/sampleToken
Returns a new JWT token with "fakeUsername" as username claim

#### UsersController

* POST - users/authenticate
Calls the Authenticate function of the [User Service](#userservice).
Returns user credentials and JWT token if successful.

#### WeatherForecastController
Template controller that comes from project creation.
Added the ```$ [Authorize]``` property to test the [Authentication Middleware](#authenticationmiddleware)

* GET - /weatherforecast

