# OdeToFood

Application for restaurants management, made in ASP.NET Core 5.0 Technology using SQL Server database.

### Features 

All restaurants can be shown.

Search restaurants by the name, or by a part of the name, can be done.

Add, Modify and Delete of restaurant is supported.


## SQL Server

### Desktop Docker

An SQL Server image is created in Desktop Docker (Linux containers), using the following command:

```
docker run --name sql_2017 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=1Secure*Password1" -e "MSSQL_PID=Enterprise" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

Connection should be tested with the command:

```
docker exec -it sql_2017 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa
```

### Rider connection

In JetBrains.Rider IDE, database connection to created SQL Server should be established. The connection string that targets the specified database for this project, called OdeToFoodDB, is the following:

```
"ConnectionStrings": {
    "OdeToFoodDb":"Data Source=localhost,1433;Database=OdeToFoodDB;User Id=sa;Password=1Secure*Password1;"
}
```

## Entity framework

Entity framework is used to set up migrations, and for database management.

Initially, this framework is not installed, hence it should be done using the following commands:

```
dotnet tool install --global dotnet-ef
dotnet tool update --global dotnet-ef
```

### Migrations

If the entity framework is installed, using c# classes, database tables are migrated using the commands:

``` 
dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj
dotnet ef database update -s ..\OdeToFood\OdeToFood.csproj
```

## Api

### Api Contoller

Initially, the ```aspnet-codegenerator``` is not installed, hence it should be done using the following commands:

```
dotnet tool install -g dotnet-aspnet-codegenerator
dotnet tool update -g dotnet-aspnet-codegenerator
```

RestaurantsController encapsulate methods invoked by different get and post (with parameters) requests for specific, ```api/...```, path. In order to add this controller execute following command:

```
dotnet aspnet-codegenerator controller -api -name RestaurantsController --model OdeToFood.Core.Restaurant --dataContext OdeToFood.Data.OdeToFoodDbContext 
```