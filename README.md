# ASP ASPIRE + GRPC Sample project
* This is a sample project that shows how to use the GRPC library with ASP.NET ASPIRE
* The project is based on the GRPC sample project from Microsoft
# Deploy to azure container app service
 * Need to have an azure account with subscription
 * Run these command in terminal	
```
azd init
azd up
```


# Deploy to k9s
## Install k9s

> widget install k9s

## Install aspirate 
>dotnet tool install -g aspirate --prerelease

## Go to WeatherApp.AppHost folder

```
cd WeatherApp.AppHost

aspirate init

aspirate generate

aspirate apply
```
## Run k9s in terminal
``` sh
k9s
Port forward web application
Shift + F > OK
 ```





