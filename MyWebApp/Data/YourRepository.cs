using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;
using System.Threading.Tasks;

namespace MyWebApp.Data
{
    public class YourRepository
    {
        private readonly YourDbContext _context;

        public YourRepository(YourDbContext context)
        {
            _context = context;
        }

        public async Task InsertAsync(YourEntity entity)
        {
            var sql = "INSERT INTO YourTable (Field1, Field2) VALUES (@p0, @p1)";
            await _context.Database.ExecuteSqlRawAsync(sql, entity.Field1, entity.Field2);
        }
    }
}