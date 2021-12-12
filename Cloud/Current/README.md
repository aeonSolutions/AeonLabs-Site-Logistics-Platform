# Setup Instructions
- upload the Cloud/Current folder to the web server 
- install the Database file in csaml/system/MySQL_DataBase.sql (https://github.com/aeonSolutions/Site-Logistics-Platform/tree/main/Cloud/Current/csaml/system)

#### Default Database settings
The default configuration setup to access the database is:

$DbHost='localhost';

$DbUser='shared_csaml_usr';

$DbPassword='dragon@1522';

$DbName='shared_csaml';

in file csamsl/system/settings.php (https://github.com/aeonSolutions/Site-Logistics-Platform/tree/main/Cloud/Current/csaml/system)

#### API access address
the API can be reached at :

[domain name]/[folders]/csaml/api/index.php
