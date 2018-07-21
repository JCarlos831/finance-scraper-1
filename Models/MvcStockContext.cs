using Microsoft.EntityFrameworkCore;

namespace finance_scraper_1.Models
{
    public class MvcStockContext : DbContext
    {
            public MvcStockContext (DbContextOptions<MvcStockContext> options)
                : base(options)
            {
            }

            public DbSet<finance_scraper_1.Models.Stocks> Stocks { get; set; }
    }
}