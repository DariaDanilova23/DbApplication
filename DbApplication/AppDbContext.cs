using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace DbApplication
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options) { }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Departments> Departments { get; set; }

    }
}
