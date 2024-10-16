using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.Models;
using MyWebApp.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyWebApp.Controllers
{
    public class YourController : Controller
    {
        private readonly ILogger<YourController> _logger;
        private readonly YourDbContext _context;

        public YourController(ILogger<YourController> logger, YourDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult UpdateForm()
        {
            _logger.LogInformation("UpdateForm GET method called.");
            var records = _context.YourEntities.ToList();
            ViewBag.RetrieveMessage = records.Any() ? "Records retrieved successfully!" : "No records found.";
            ViewBag.InsertMessage = TempData["InsertMessage"];
            ViewBag.UpdateMessage = TempData["UpdateMessage"];
            return View(records);
        }

        [HttpPost]
        public async Task<IActionResult> Insert(YourModel model)
        {
            _logger.LogInformation("Insert POST method called.");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid. Field1: {Field1}, Field2: {Field2}", model.Field1, model.Field2);

                // Generate a unique ID
                var maxId = _context.YourEntities.Max(e => (int?)e.Id) ?? 0;
                var newId = maxId + 1;

                // Insert logic using raw SQL command
                try
                {
                    var sql = "INSERT INTO YourTable (Id, Field1, Field2) VALUES (@p0, @p1, @p2)";
                    await _context.Database.ExecuteSqlRawAsync(sql, newId, model.Field1, model.Field2);
                    _logger.LogInformation("Database insert successful.");
                    TempData["InsertMessage"] = "Record inserted successfully!";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error inserting into the database.");
                    ModelState.AddModelError(string.Empty, "An error occurred while inserting into the database.");
                    TempData["InsertMessage"] = "Error inserting record.";
                }

                return RedirectToAction("UpdateForm");
            }
            _logger.LogWarning("Model is invalid.");
            return View("UpdateForm", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(YourModel model)
        {
            _logger.LogInformation("Update POST method called.");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid. Field1: {Field1}, Field2: {Field2}", model.Field1, model.Field2);

                // Update logic using raw SQL command
                try
                {
                    var sql = "UPDATE YourTable SET Field1 = @p0, Field2 = @p1 WHERE Id = @p2";
                    await _context.Database.ExecuteSqlRawAsync(sql, model.Field1, model.Field2, model.Id);
                    _logger.LogInformation("Database update successful.");
                    TempData["UpdateMessage"] = "Record updated successfully!";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error updating the database.");
                    ModelState.AddModelError(string.Empty, "An error occurred while updating the database.");
                    TempData["UpdateMessage"] = "Error updating record.";
                }

                return RedirectToAction("UpdateForm");
            }
            _logger.LogWarning("Model is invalid.");
            return View("UpdateForm", model);
        }
    }
}