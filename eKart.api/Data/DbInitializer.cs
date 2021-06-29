using System.Linq;
using System.Threading.Tasks;

namespace eKart.Api.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(eKartContext context)
        {
            await context.Database.EnsureCreatedAsync();

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
            await context.SaveChangesAsync();
        }
    }
}