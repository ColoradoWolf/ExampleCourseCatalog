# Jason's Example Course Catalog

## Intro

This project is a basic example of an simple course catalog, with courses broken into sections, which contain individual lessons.  The data is bare-bones, and is set up to be an example of how to structure a DB.  This project is built using ASP.NET Core Web Api and Entity Framework Core using C# and .NET 8.  All code was written and tested using Visual Studio 2022, Swagger UI, and Postman.

## About This Repo

This GitHub repository contains two branches:  `master` and `Seed-Data`.  Both branches are identical, except that `Seed-Data` contains a migration to populate the DB with simple starting data.  The root solution folder contains a small collection exported from Postman in JSON format.

## Configuration

For purposes of this app, all config settings are located in `appsettings.json` in the `CourseCatalogApi` project folder.  The API is currently configured to use https, which can be modified by changing the setting `UseHttps` in the `appsettings.json` file.

The API is currently configured to use a local SQL Server Express instance, and this can be configured via the `ConnectionStrings:DefaultConnection` setting in `appsettings.json`.

Changes to the URL used by the API may be made be editing the `launchSettings.json` file in the `CourseCatalogApi/Properties` folder.

## Setting up the DB

The `CourseCatalogDb` project has been implemented using Entity Framework Core with code-first migrations.  As mentioned above, the `Seed-Data` branch has an extra migration to populate the DB with simple seed data.

To create the DB (and populate seed data if using branch `Seed-Data`), follow these steps:

* **Using dotnet CLI**
    1. Navigate to the solution folder of this repo.
    2. Install the EF Core tools using the following command:

       > `dotnet tool install --global dotnet-ef`
       
        - Alternatively, if already installed, update EF Core tools using the following command:
          
          > `dotnet tool update`
          
    3. Install the latest `Microsoft.EntityFrameworkCore.Design` package using the following command:
   
       > `dotnet add package Microsoft.EntityFrameworkCore.Design`
       
    4. To create the DB and schema (and optionally seed the DB with data), use the following command:
       
       > `dotnet ef database update`

* **Using Visual Studio Package Manager Console**
    1. Open solution in Visual Studio and open Package Manager Console (`Tools -> NuGet Package Manager -> Package Manager Console`)
    2. Verify EF Core Tools are installed using command:

       > `Get-Help about_EntityFrameworkCore`

         - If not installed, run the following command:

           > `Install-Package Microsoft.EntityFrameworkCore.Tools`

         - If installed, update to latest version using following command:

           > `Update-Package Microsoft.EntityFrameworkCore.Tools`

    3. To create the DB and schema (and optionally seed the DB with data), use the following command:

       > `Update-Database`

The DB can be verified and validated using SQL Server Mgmt Studio or similar tool.

## Running the API

I have only run the API using the debugger within Visual Studio, using the https debug configuration (which uses HTTP.sys under the hood).  This API can be run under HTTP.sys and IIS, if desired.
