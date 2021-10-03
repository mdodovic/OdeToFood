# OdeToFood

Application for restaurants management, made in ASP.NET Core 5.0 Technology using SQL Server database.

### Features 

All restaurants can be shown.

Search restaurants by the name, or by a part of the name, can be done.

Add, Modify and Delete of restaurant is supported.


## SQL Server

### Desktop Docker

SQL Server image is created in Desktop Docker (Linux containers), using the following command:

```docker run --name sql_2017 -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=1Secure*Password1" -e "MSSQL_PID=Enterprise" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest```

Connection should be tested with command:

```docker exec -it sql_2017 /opt/mssql-tools/bin/sqlcmd -S localhost -U sa```

### Rider connection

In JedBrains.Rider IDE, database connection to created SQL Server should be established. Connection string that target specifid database for this project, called OdeToFoodDB, is the following:

```
"ConnectionStrings": {
    "OdeToFoodDb":"Data Source=localhost,1433;Database=OdeToFoodDB;User Id=sa;Password=1Secure*Password1;"
}
```

## Entity framework

Entity framework is used to set up migrations, and for database management.

Initially, this framework is not installed, hense it should be done using the following command:

```dotnet tool install --global dotnet-ef```

### Migrations

If the entity framework is installed, using c# classes, database tables is created using migrating command:

``` 
dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj
dotnet ef database update -s ..\OdeToFood\OdeToFood.csproj
```

