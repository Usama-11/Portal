using Microsoft.EntityFrameworkCore;
using Portal.API.Models;

namespace Portal.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Admin> Admin {get; set;}
        public DbSet<Student> Students { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}