**Project description**
This is a sample .NET CORE web application that adds rows to a table in a Microsoft Fabric SQL Data Warehouse.

**Features**
The application has a single form with two input fields. Enter values in the field, press the button, and the values are added to the Fabric SQL Data Warehouse table.

**Configuration instructions**
1. Create a Fabric SQL Data Warehouse.
2. Create a table in the Fabric SQL Data Warehouse:

```sql
CREATE TABLE [SQL Data Warehouse 01].[dbo].[YourTable]
  (
  	[Id] [int]  NOT NULL,
  	[Field1] [varchar](100)  NULL,
  	[Field2] [varchar](100)  NULL
  )
GO
```

   Note: This assumes that the SQL Data Warehouse is named "SQL Data Warehouse 01".
         IF you change the name of the warehouse, table name, or field values, must update the source code accordingly.
   
4. Update appsettings.json with the connection string to your Fabric SQL Data Warehouse.

**Debugging **
The easiest way to run and debug the project is to:
 - Open the project in Visual Studio Code
 - Open a Bash Terminal Window
 - Type: DOT NET RUN

Once the application starts:
 - Open a browser to the location specified in Terminal (e.g. http://localhost:8080"). This takes you to the form.
 - Enter values in the fields and press the Insert button.
 - Go to Visual Studio Code and watch the Terminal window (the app has tracing enabled).

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
