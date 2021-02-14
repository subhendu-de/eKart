using System;
using System.Linq;

namespace eKart.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(eKartContext context)
        {
            context.Database.EnsureCreated();

            if (context.Products.Any())
            {
                return;
            }

            var products = new Product[]
            {
                new Product{Name="Apple"}
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}