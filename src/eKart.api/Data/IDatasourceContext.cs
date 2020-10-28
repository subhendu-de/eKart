using System;
using Microsoft.EntityFrameworkCore;

namespace eKart.Api.Data
{
    public interface IDatasourceContext: IDisposable
    {
        DbSet<Product> Products{ get; set; }
        int SaveChanges();
    }
}