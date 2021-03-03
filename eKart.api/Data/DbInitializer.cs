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
                new Product{Name="Apple"},
                new Product{Name="Banana"},
                new Product{Name="Orange"},
                new Product{Name="Grape"},
                new Product{Name="Plum"},
                new Product{Name="Lime"},
                new Product{Name="Kiwi"}
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}