**Project description**

This is a sample .NET CORE web application that interacts with a Microsoft Fabric SQL Data Warehouse. The sample has functionality to add, update, and display the rows of a table in a Fabric SQL Data warehouse. 

**Features**

The application has a single form with three sections that can be run in a stepwise fashion:

- Step 1: Add Record - Fill out the fields, press the Insert button, and the values are added as a new row in the table.
- Step 2: Retrieve Records - Click the button to display the rows in the table. The list is refreshed when a row is added or updated.
- Step 3: Update Record - Enter the ID of the record to update (displayed in the section above), enter updated values, and press Update.

**Configuration instructions**

1. Create a Fabric SQL Data Warehouse.
2. Create a table in the Fabric SQL Data Warehouse named "YourTable", with two fields (Field1, Field2).

```sql
CREATE TABLE [SQL Data Warehouse 01].[dbo].[YourTable]
  (
  	[Id] [int]  NOT NULL,
  	[Field1] [varchar](100)  NULL,
  	[Field2] [varchar](100)  NULL
  )
GO
```
If you use a different table definition, update the source code accordingly.
   
3. Update appsettings.json, and/or appsettings.developer.json with the connection string to your Fabric SQL Data Warehouse. The portion that you should update is marked as follows: [your-fabric-connection-string].msit-datawarehouse.fabric.microsoft.com

**Run and Debug**

The easiest way to run and debug the project is to:
 - Clone the project into a folder on your local machine (or open in GitHub Codespaces)
 - Open the folder in Visual Studio Code
 - Follow the steps listed above to set the connection string.
 - Open a Bash Terminal Window
 - Type: dotnet run
   
Once the application starts:
 - Open a browser to the location specified in Terminal (e.g. http://localhost:8080"). This takes you to the web form.

 <img src="https://github.com/user-attachments/assets/a157e1be-5c43-42bb-ad06-75eba903eb2c" alt="description" width="476" height="345" style="border:1000px solid black;"/>


 The simplest way to use the sample application is to go step by step (add a row, display rows, update a row).
 
 As you perform each step, switch to Visual Studio Code and watch the Terminal window (the app has signficant tracing code).
   
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
