using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.Models;
using MyWebApp.Data;

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
            return View();
        }

        [HttpPost]
        public IActionResult Insert(YourModel model)
        {
            _logger.LogInformation("Insert POST method called.");
            if (ModelState.IsValid)
            {
                _logger.LogInformation("Model is valid. Field1: {Field1}, Field2: {Field2}", model.Field1, model.Field2);

                // Your insert logic here
                try
                {
                    var entity = new YourEntity
                    {
                        Field1 = model.Field1,
                        Field2 = model.Field2
                    };
                    _context.YourEntities.Add(entity);
                    _context.SaveChanges();
                    _logger.LogInformation("Database insert successful.");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error inserting into the database.");
                    ModelState.AddModelError(string.Empty, "An error occurred while inserting into the database.");
                }

                return RedirectToAction("UpdateForm");
            }
            _logger.LogWarning("Model is invalid.");
            return View("UpdateForm", model);
        }
    }
}