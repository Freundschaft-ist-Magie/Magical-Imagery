using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services
{
    public static class SeedService
    {
        public static async Task SeedDb(this ApplicationDbContext context)
        {
            if (context.Products.Any())
                return;

            var licences = await SeedLicences(context);
            await SeedProducts(context, licences);
            await context.SaveChangesAsync();
        }

        private static async Task<List<Licence>> SeedLicences(ApplicationDbContext context)
        {
            List<Licence> licences = [ 
                new()
                { 
                    Id = 1,
                    Name = "MIT",
                },
                new()
                {
                    Id = 2,
                    Name = "Non-Commercial",
                },
            ];
            await context.AddRangeAsync(licences);
            return licences;
        }

        private static async Task SeedProducts(ApplicationDbContext context, IEnumerable<Licence> licences)
        {
            List<Product> products = [
                new()
                {
                    Id = 1,
                    Name = "Flüsternde Schatten",
                    Price = 130,
                    Width = 1920,
                    Height = 1080,
                    LicenceId = licences.First().Id,
                },
                new()
                {
                    Id = 2,
                    Name = "Ewige Dämmerung",
                    Price = 60,
                    Width = 1920,
                    Height = 1080,
                    LicenceId = licences.Last().Id,
                },
            ];
            await context.AddRangeAsync(products);
        }
    }
}
