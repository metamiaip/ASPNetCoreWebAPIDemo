ASPNetCoreWebAPIDemo

-Use Visual Studio 2022, NetCore 6 to build

Install the Following NuGet Packages.

- Microsoft.EntityFrameworkCore.SqlServer: This package is used to interact with SQL Server from our C# and .Net Core.
- Microsoft.EntityFrameworkCore.Tools: This package is contained various commands like Add-Migration, Drop-Database, Get-DbContext, Get-Migration, Remove-Migration, Scaffold-DbContext, Script-Migration, Update-Database. In this article, we use Add-Migration and Update-Database commands.
- Microsoft.Extensions.Configuration: Using this NuGet package we can read data from our app setting file. We will get our connection string from the app setting file.

Build Steps:
1. Build Models\model class (i.e. your code first db table)
2. Build Models\modelContext class (example of dependencies injection)
3. Setup ConnectionString in appsettings.json
4. Add code in Program.cs to get connection strings
5. Open NuGet Package Manager Console: Add-Migration Init (you should see a new folder with some cs files generated in Migration folder)
6. PM> Update-Database
7. If no error returned, check DB, table should be created already
8. Build ViewModels\ResponseModel class for return message
9. Build Services\IEmployeeService interface and Services\EmployeeService to talk to database
10. Finally build Controllers\EmployeeController class to manage Get, Post, Delete Http request
11. Add builder.Services.AddScoped<IEmployeeService, EmployeeService>(); to Program.cs
12. Build solution and test by OpenAPI (Swagger)

-appsettings.json connection strings example
"ConnectionStrings": {
    "ConStr": "Server=tcp:jiptest.database.windows.net,1433;Initial Catalog=testdb;Persist Security Info=False;User ID={login};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30"
  }

