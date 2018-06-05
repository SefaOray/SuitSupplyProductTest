# SuitSupplyProductTest

# The API

API is built with .Net Core 2.0. Project can be opened with Visual Studio 2017.

# UI

UI is built with Angular 4. Because it's in a folder and not a solution item, it won't show up in Visual Studio. I recommend Visual Studio Code as IDE for Angular projects. 

UI Project can be found in `SuitSupplyProductTestUI` folder

To run UI project

* Install [NodeJs](https://nodejs.org/en/)
* Install [Angular-Cli](https://cli.angular.io/)
* Navigate to UI folder `cd SuitSupplyProductTestUI`
* Install dependencies `npm install package.json`
* Run the app `ng serve`
* Navigate to `http://localhost:4200`

# Requirement checklist

* .Net Core is used
* MsSql and EF used
* Swagger documentation can be found at /swagger 
* Angular SPA 
* Services and Data layers are scalable and reusable as nuget packages
* n layer architecture is used
* Unit tests for controller and business layer is provided
* Different version of method calls supported via API versioning
