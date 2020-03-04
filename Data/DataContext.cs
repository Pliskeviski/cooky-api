using Cooky.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Cooky.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        //public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
