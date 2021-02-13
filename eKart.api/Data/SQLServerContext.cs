using System;
using Microsoft.EntityFrameworkCore;

namespace eKart.Api.Data
{
    public class SQLServerContext: DbContext, IDatasourceContext
    {
        public SQLServerContext(DbContextOptions options):base(options)
        {}
        public DbSet<Product> Products {get; set; }
    }
}