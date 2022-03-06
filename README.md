# FranksGarage
Frank's second hand car garage

## Project Configuration
There is steps you should be doing before run solution locally. 

### 1- DB Configuration
There is a DB file attached in source codes. If you want to use standart database, please update "FranksGarage.Data.API/appsettings.json" > "ConnectionStrings" > "DefaultConnection" section:
- **"Data Source"**: Database file location, must have been updated before run project. 
- **"Password"**: Pasword is already set but if you want to change please follow instructions below;
	- Delete "frankDB.db", "frankDB.db-shm", "frankDB.db-wal" files.
	- Open solution and on Visual Studio's Package Manager Console, run __"Update-Database "__. 
	- That's it, you can run project. API will auto fill data from "warehouses.json" file. 

### 2- URL Configuration
localhost and port adresses already set for project but if you want to change adresses, please follow steps below;
- "FranksGarage" project;
	- "launch.json": update addresses and ports for "FranksGarage" project.
	- "src/Api/AxiosBase.tsx": update baseUrl for "FranksGarage.Data.API" project
- "FranksGarage.Data.API" project;
	- "appsettings.json": update address and port for "FranksGarage" project.
	- "Properties/launchSettings.json": update addresses and ports for "FranksGarage.Data.API" project

## Change Log
For Phase 1;
- Added Data API layer,
- Added SqlLite DB with encyription
- Added If database empty populate data from mock json,
- Added Models and model data annotations.

Phase 1 continue: 
- Added React / Typescript project for UI
- Added Bootstrap functionality

End of Phase 1:
- Populating all vehicles from warehouses.
_____________________________________________________________
Phase 2;
- Redesigned vehicle list,
- Added IsLicensed filter to the results
- Vehicle Proxy Model Added
- Added GetById in Vehicles controller
- Added Google Maps support.
_____________________________________________________________
Phase 3;
- Added Shopping Cart,
- Vehicle Details, you can add to cart
- In cart you can remove from cart
- Cart shows total amount