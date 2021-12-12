## Setup Instructions for the Windows 10/11 Apps
- Setup Git in Visual Studio 2022
- Install All the Nuget Packages that may be missing using the NuGet package manager


#### Requiered Nuget Pachages
- AutoUpdate.NET
- ClosedXML
- newtonsoft.Json

## App Global environment varibales
there is a global env. file located in modules/state.vb

## Test user Login credentials
the test server for the Cloud API is located in : http://www.aeonlabs.solutions/sitelogistics.construction/shared/csaml/api/index.php

- user: 123456789
- pass: 0000

## Requirements
Windows 10/11 ; .NET 4.7.2 / .NET 4.8

## Visual Studio 
The visual studio solution has 3 projects:
- Construction Site Logistics Office : main program for office management of all activities
- Construction Site Logistics Office Setup : setup wizard for the Construction Site Logistics Office
- finnish : support file for cleanning the setup procedure on first run of the Construction Site Logistics Office
