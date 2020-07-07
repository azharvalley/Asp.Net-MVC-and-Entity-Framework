# Asp.Net MVC and Entity-Framework

CRUD Web Application with Asp.Net MVC and Entity Framework

Project is built on Visual Studio 2019 and Created using:
- ASP.NET MVC
- C#.NET
- Entity Framework
- SQL
- Stored Procedures. 




**You will require SQL Server Database on your local machine**
---------------------------------------------------------------------------------------
>Create a Database. Execute the SQL Script (TablesAndStoredProcedures.sql) inside the folder (DatabaseScript)

>Replace your connectionString in the web.config file of the project.

```
<connectionStrings>
    <add name="CalendarEventEntities" 
         connectionString="metadata=res://*/Models.CalendarEvents.csdl|res://*/Models.CalendarEvents.ssdl|res://*/Models.CalendarEvents.msl;
         provider=System.Data.SqlClient;provider connection string=&quot;
         data source=YouServerName;initial catalog=YourDataBaseName;user id=DatabaseUserName;password=DataBasePassword;
         MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
  </connectionStrings>
  ```

>Enter your Server, Database name, User ID and Password in the connectionstring. 

--------------------------------------------------------------------------------------------------------------------------
When you run this project and if you get Internal server error
--------------------------------------------------------------------------------------------------------------------------
Could not find a part of the path ***D:\git\Asp.Net-MVC-and-Entity-Framework-master\OpenCMS\bin\roslyn\csc.exe***

Then you can install Roslyn package to the project vusing NuGet package 

*Install-Package Microsoft.CodeAnalysis*

--------------------------------------------------------------------------------------------------------------------


