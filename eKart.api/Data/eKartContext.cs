using Microsoft.EntityFrameworkCore;

namespace eKart.Api.Data
{
    public class eKartContext: DbContext
    {
        public eKartContext(DbContextOptions options):base(options)
        {}
        public DbSet<Product> Products {get; set; }
    }
}