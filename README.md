# _Machine factory database_

#### By _Evgeniya Meshuris_

#### _This is an application to create a Database of machines and engineers for the machine factory_

## Technologies Used

* _C#_
* _HTML_
* _CSS_
* _REPL_
* _.NET_
* _MVC_
* _Razor_
* _MySQL WorkBench_

## Description

_This is an application to create a Database for machine factory. The application allows to add a list of machines and an engineers for each machine. Application allows to Edit, Delete machine and engineers._

## Setup/Installation Requirements

* _Copy the git repository url from the "code" drop down on this github page_
* _Open a terminal program & navigate to your desktop_
* _Clone the repository using the copied URL and the "git clone" command_
* _In the terminal program, navigate to the root directory of the newly created file called "Factory.Solution"_
* _From the root directory, navigate to the directory named "Factory.Solution"_
* _In the root directory, confirm there is a .gitignore file. Add: */obj, */bin, */.vscode, */appsettings.json _
* _Create an appsetting.json file at the root directory*_
* _Open the appsetting.json file and enter: { "ConnectionStrings": { "DefaultConnection": "Server=localhost;Port=3306;database=[Database-Name];uid=root;pwd=[Your-Password;" } }_
* _Make sure you updated Database-Name and a Password_
* _Open MySQL WorkBench and In the Navigator > Administration window, select Data Import/Restore_
* _Select Import from Self-Contained File_
* _Use .sql file type that is located the root directory _
* _Navigate to the tab called Import Progress and click Start Import at the bottom right corner of the window_
* _run dotnet add package Microsoft.EntityFrameworkCore -version for your computer_
* _run dotnet add package Pomelo.EntityFrameworkCore.MySql-version for your computer_
* _run dotnet add package Microsoft.EntityFrameworkCore.Proxies-version for your computer_
* _Navigate to the directory named "Factory". In this directory run the command "dotnet restore; dotnet build ; dotnet watch run"_

## Known Bugs

* _No known issues_


## License

Licensed under the [MIT License](LICENSE)

Copyright (c) _2022_ _Evgeniya Meshuris_