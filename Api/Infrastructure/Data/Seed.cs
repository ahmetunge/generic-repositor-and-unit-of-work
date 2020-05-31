using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Api.Core.Entities;
using Api.Infrastructure.Data.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Api.Infrastructure.Data
{
    public class Seed
    {
        public static async Task SeedAsync(EfCoreContext context, ILoggerFactory loggerFactory)
        {
            string basePath = @"D:\Projects\GenericRepository\Api\Infrastructure\Data\SeedData";

            try
            {
                if (!context.ProductBrands.Any())
                {
                    var brandsData = File.ReadAllText(Path.Combine(basePath, "brands.json"));

                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var brand in brands)
                    {
                        context.ProductBrands.Add(brand);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProductTypes.Any())
                {
                    var typesData =
                        File.ReadAllText(Path.Combine(basePath, "types.json"));

                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Products.Any())
                {
                    var productsData =
                        File.ReadAllText(Path.Combine(basePath, "products.json"));

                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        context.Products.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Seed>();
                logger.LogError(ex.Message);
            }

        }

    }
}