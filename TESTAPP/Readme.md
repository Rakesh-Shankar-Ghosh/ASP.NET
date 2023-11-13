# PROJECT SET-UP
- use visual stido 2022 and SQL Server for dataBase
- always choose the project react with asp.net mvc
- you can also choose MVC project later u can add a folder frontend where react laies (Recommanded than above one)
- MVC framework 6.0/7.0 which is equvallent as node 15.0/16.0
- Developer PowerShell is equvalent to powerShell (Find this from view terminal)
- Programm.cs is = Server.js
- you can change localhost port of backendfrom Properties->lunchsetting.json and othersinformation which is equvalent to pakege.jason
- cd Testapp then
- now use "dotnet build" cmd for build (on DeveloperPowerSheel)
- Then type "dotnet run" for starting the backendapplication
- above two points are equvalent to "dotnet watch run" which is equvalent to nodemon
- make sure if u want not to use username and password just instal SQL server as it isdo not change anything and must use Windows authentication because it does not need user name and password
- Make sure that your programm.cs is net and clean

# FOLDER STRUCTURE
- make as it is ur way the MVC folder structure though it has built in but 80%
- actually dont need view folder

# IMPORTANT PACKGES
- for adding a packges right click on Dependecies and select neget packges and install waht u want for ur project
- u can also use powersheel cmd (but not recomnded coz u have UI for this)
- Microsoft.EntityFramework.Core.Design and Microsoft.EntityFramework.Core.SQLserver is must needed for asp.net project

# DATABASE MODEL AND CONNECTIONS
- connection are shown in Project with databae Context approch
- model instance if u write FirstName -> "firstname" will save in database
- and when u have to fetch data u have to write obj.firstname not obj.FirstName, so wise decision is to make model instance like firstname not FirstName
- after create a model must have to do migration

# DTABASE MIGRATION
- dotnet tool install --global dotnet-ef
- dotnet ef migrations add <NAME> example: dotnet ef migrations add StudentCreate
- dotnet ef database update
- in future if u want to add another field name EmailAddress then, dotnet ef migrations add AddEmailAddressField and then dotnet ef database update
- thats all if error get help from CHATGPT

# SET FRONTEND ADDRESS URL IN BACKEND
- must attach frontend localhost's url inside appsetting.json (shown in project)

# SET BACKTEND ADDRESS URL IN FRONTEND
- REACT_APP_API = must the url of backend's localhost

# REST OF THINGS
- rest of things are shown inside project like controllers,routes,middleware, db connection files etc






