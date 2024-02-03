# ProductManagement
1-Dowmload Repo 
2-Open Visual Studio (.Net 5 Must Be Dowmloaded)
2- Set "ProductManagement.Web" as starter project to navegate through Views or set "ProductManagement.Api" as starter project to view Swagger.html
3-Replace the followin lines in appsetting.json file with credintials that matches your SQL-Server
    "ApplicationConnection": "Server=.; Database=ProductManagementDB;User id=sa; Password=123456789; MultipleActiveResultSets=true; TrustServerCertificate=True",
    "IdentityConnection": "Server=.; Database=ProductManagementDB;User id=sa; Password=123456789; MultipleActiveResultSets=true; TrustServerCertificate=True"
4-run the command "update-database -context ApplicationDbContext" to create catalog tables, Note to select "ProductManagement.Infrastructure" project for this command
5-run the command "update-database -context IdentityContext" to create Idinity tables, Note to select "ProductManagement.Infrastructure" project for this command
6-Run the project
7- login with default super admin with the follwing cridinyials
  Email: superadmin@gmail.com
  Password: 123Pa$$word!
