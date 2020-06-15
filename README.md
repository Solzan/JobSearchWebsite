# Introduction 
Job Search Website allow: 
-add job position and preview result post during creating,
-see all applications for job position,
-open particular application to see details,
-search application by name and id. 
-add companies and apply for particular job position

Application written in C# using ASP.NET MVC, list of the job offers is loading asynchronously via API using AJAX. Data are stored in SQL database, communication between Web App and 
SQL is done by Entity Framework. Form is validated on client and server site. Controller capturing data from form - data are correctly passed from View to Controller.

- [link to website: https://jobportallabnet.azurewebsites.net/](https://jobportallabnet.azurewebsites.net/)

# Integration with Azure
User Authentication is done with Azure AD B2C
Website is stored on Azure Web App
Database  stored on Azure SQL Database
