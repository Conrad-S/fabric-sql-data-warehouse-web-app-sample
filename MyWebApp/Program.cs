using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using Microsoft.Data.SqlClient;

var connectionString = "Server=x6eps4xrq2xudenlfv6naeo3i4-hq2ehbsctyvu7npl3u5xrg4hfq.msit-datawarehouse.fabric.microsoft.com,1433;Initial Catalog=SQL Data Warehouse 01;Authentication=Active Directory Interactive;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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

var builder = WebApplication.CreateBuilder(args);

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