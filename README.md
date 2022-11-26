# Books-Management-System

This project is built using C#, NET Core 3.1, React and TypeScript, for database SQL is used.<br />
This project consists of multiple projects with same operation but built differently as web app, windows app, API project, React app, <br />
feel free to contribute and use it.
# Contents of the project
- API Project for Book Management system
- React app which calls the API defined in the API Project for performing operations
- Web app for Book Management system
- Windows app for Book Management System
# Requirements for setup
- Visual studio with .NET Core 3.1 
- Node for running react App 
- Microsoft SQL Server Management Studio 
# How to setup
- Clone/Downlaod this Repository to local.
- Install a sql client and execute the script in **DB_script.sql**.
- You need to create login user in database manually, once you create the database and tables from the script file, run the insert command and pass value as (username,password, isadmin).<br />
in place of isadmin please choose **1** if you want the user to be admin and **0** for non admin user.
**For example**:<br >
``` sql
                --for admin user
                INSERT INTO lUsers VALUES('admin','admin',1)
                -- for non admin user
                INSERT INTO lUsers VALUES('shashank','shashank',0)
```
- Connect the dataBase and get the connection string to make the project communicate with your database.
- Open **bool-manager-application/bookManager.sln**.
- Replace the connection string to your connection string.
- For **api-book-manager** and **web-book-manager** project replace the connection string in **appsetting.js** with your database connection string.
- For **windows-app-book-manager** project replace the connection string in **ConnectionString.js** with your database connection string.
- Right click on a project that you want to run and select **Set as startup**, and Build the project.
- Run the project.
- **Note**: Dont choose **IISExpress** when running project, chose the other configuration which you see in the Run Dropdown.
# For Running React App
- Run the **api-book-manager** project.
- copy the url/port of the api project when its running.
- Open **.env** file in **react-app-book-manager** folder.
- replace the URL with the url your api project is running.
- Open command prompt inside **react-app-book-manager** folder.
- Execute **npm install**
- After the above command is executed with no errors.
- Execute **npm start**
- This should compile the  project and run it if no errors are occured.
# Reach me
If you face any issue when running or if there are any suggestions please comment or reach me out at my socials <br />
<br />
                **Twitter/Linkedin/Instagram/ @iybshashank**