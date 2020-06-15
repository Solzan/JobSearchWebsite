# Introduction 

Job Search Website allow: <br/>
- Add job position and preview result post during creating,<br/>
- See all applications for job position,<br/>
- Open particular application to see details,<br/>
- Search application by name and id. <br/>
- Add companies and apply for particular job position<br/>

Application written in C# using ASP.NET MVC, list of the job offers is loading asynchronously via API using AJAX. Data are stored in SQL database, communication between Web App and 
SQL is done by Entity Framework. Controller capturing data from form - data are correctly passed from View to Controller. Form is validated on client and server site.

[link to website: https://jobportallabnet.azurewebsites.net/](https://jobportallabnet.azurewebsites.net/)<br/>
Code is stored in Repos folder ;)

# Integration with Azure
- User Authentication is done with Azure AD B2C<br/>
- Website is stored on Azure Web App<br/>
- Database  stored on Azure SQL Database<br/>
