using Microsoft.EntityFrameworkCore;
using webAPI.Models;

namespace webAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options ): base(options) 
        {
            
        }
        public DbSet<MonAn> MonAn { get; set; }
        public DbSet<ThucDon>ThucDon { get; set; }
    }
}
