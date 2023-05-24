[Open Software Caralog](https://github.com/aeonSolutions/aeonlabs-open-software-catalogue)  >>  [Construction Site Remote Logistics Platform](https://github.com/aeonSolutions/AeonLabs-Site-Logistics-Platform/blob/main/README.md)  >> Remote Construction Site Logistics 

[![Telegram](https://img.shields.io/badge/join-telegram-blue.svg?style=for-the-badge)](https://t.me/+W4rVVa0_VLEzYmI0)
 [![WhatsApp](https://img.shields.io/badge/join-whatsapp-green.svg?style=for-the-badge)](https://chat.whatsapp.com/FkNC7u83kuy2QRA5sqjBVg) 
 [![Donate](https://img.shields.io/badge/donate-$-brown.svg?style=for-the-badge)](http://paypal.me/mtpsilva)
 [![Say Thanks](https://img.shields.io/badge/Say%20Thanks-!-yellow.svg?style=for-the-badge)](https://saythanks.io/to/mtpsilva)
![](https://img.shields.io/github/last-commit/aeonSolutions/PCB-Prototyping-Catalogue?style=for-the-badge)
[![Open Source Love svg1](https://badges.frapsoft.com/os/v1/open-source.svg?v=103)](#)
[![GitHub Forks](https://img.shields.io/github/forks/aeonSolutions/PCB-Prototyping-Catalogue.svg?style=social&label=Fork&maxAge=2592000)](https://www.github.com/aeonSolutions/PCB-Prototyping-Catalogue/fork)
[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat&label=Contributions&colorA=red&colorB=black	)](#)
[<img src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" data-canonical-src="https://cdn.buymeacoffee.com/buttons/v2/default-yellow.png" height="30" />](https://www.buymeacoffee.com/migueltomas)
![](https://views.whatilearened.today/views/github/aeonSolutions/AeonLabs-Home-Automation-Smart-Coffee-MAchine-Addon.svg) 

# Remote Construction Site Logistics 

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


