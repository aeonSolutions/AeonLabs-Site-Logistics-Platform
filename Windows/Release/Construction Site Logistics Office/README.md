## Visual Studio 
This is the last revision of the code before covid19 happened. Is fully working and it has bugs. It also has implemented automatic crash and diagnostics dump to the cloud database server. This allowed me to evaluate coding errors remotely even when times a construction worker, failed to mention it to me.

The visual studio solution has 3 projects:
- Construction Site Logistics Office : main program for office management of all activities
- Construction Site Logistics Office Setup : setup wizard for the Construction Site Logistics Office
- finnish : support file for cleanning the setup procedure on first run of the Construction Site Logistics Office

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

the test server for the Cloud API is currently located in : ~~http://www.aeonlabs.solutions/sitelogistics.construction/shared/csaml/api/index.php~~

for the setup wizard the Cloud API server is :  ~~http://www.aeonlabs.solutions/sitelogistics.construction~~

in the VB code (all projects; see state.vb file): /shared/csaml/api/index.php

##### username default credentials
- user: 123456789
- pass: 0000

## Requirements
Windows 10/11 ; .NET 4.7.2 / .NET 4.8


