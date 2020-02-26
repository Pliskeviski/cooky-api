using Microsoft.EntityFrameworkCore;
using webapi_learning.Models;

namespace webapi_learning.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Character> Characters { get; set; }
    }
}
