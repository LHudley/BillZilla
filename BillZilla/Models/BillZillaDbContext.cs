using Microsoft.EntityFrameworkCore;

namespace BillZilla.Models
{
    public class BillZillaDbContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
    
        public BillZillaDbContext(DbContextOptions<BillZillaDbContext> options)
            : base(options)
        {

        }
    }
}
