**Project description**

This is a sample .NET CORE web application that adds rows to a table in a Microsoft Fabric SQL Data Warehouse.  

**Features**

The application has a single form with two input fields. Enter values in the fields, press the Insert button, and the values are added to the Fabric SQL Data Warehouse table.  


**Configuration instructions**

If you use naming different than the names below, update the source code accordingly.

1. Create a Fabric SQL Data Warehouse named "SQL Data Warehouse 01".
2. Create a table in the Fabric SQL Data Warehouse named "YourTable", with two fields (Field1, Field2):

```sql
CREATE TABLE [SQL Data Warehouse 01].[dbo].[YourTable]
  (
  	[Id] [int]  NOT NULL,
  	[Field1] [varchar](100)  NULL,
  	[Field2] [varchar](100)  NULL
  )
GO
```
   
4. Update appsettings.json with the connection string to your Fabric SQL Data Warehouse.  

**Run and Debug**

The easiest way to run and debug the project is to:
 - Clone the project into a folder on your local machine (or open in GitHub Codespaces)
 - Open the project in Visual Studio Code
 - Open a Bash Terminal Window
 - Type: dotnet run
   
Once the application starts:
 - Open a browser to the location specified in Terminal (e.g. http://localhost:8080"). This takes you to the web form.

 <img src="https://github.com/user-attachments/assets/a5730c87-ce32-42b0-8265-78ceb7d52754" alt="description" width="305" height="221" style="border:1000px solid black;"/>

 - Enter values in the fields and press the Insert button.
 - Switch to Visual Studio Code and watch the Terminal window (the app has tracing code added).
   
 - Successful tracing looks similar to the following:
``` markdown
info: MyWebApp.Controllers.YourController[0]
    UpdateForm GET method called.
info: MyWebApp.Controllers.YourController[0]
    Insert POST method called.
info: MyWebApp.Controllers.YourController[0]
    Model is valid. Field1: First Name, Field2: Last Name

info: Microsoft.EntityFrameworkCore.Database.Command[20101]
      
    SET NOCOUNT ON;
    INSERT INTO [YourTable] ([Id], [Field1], [Field2])
        VALUES (@p0, @p1, @p2);
        info: MyWebApp.Controllers.YourController[0]
    Database insert successful.
        info: MyWebApp.Controllers.YourController[0]
    UpdateForm GET method called.
```