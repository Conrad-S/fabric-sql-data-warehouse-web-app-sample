using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Get the connection string from appsettings.json 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

try
{
    using (var connection = new SqlConnection(connectionString))
    {
        connection.Open();
        Console.WriteLine("Connection successful!");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Connection failed: {ex.Message}");
}

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register YourDbContext with the dependency injection container
builder.Services.AddDbContext<YourDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Your}/{action=UpdateForm}/{id?}");

app.Run();