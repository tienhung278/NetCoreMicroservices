using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> products)
    {
        var existProduct = products.Find(product => true).Any();
        if (!existProduct)
        {
            products.InsertManyAsync(GetPreConfiguredProducts());
        }
    }

    private static IEnumerable<Product> GetPreConfiguredProducts()
    {
        return new List<Product>()
        {
            new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Name 1",
                Category = "Category 1",
                Summary = "Summary 1",
                Description = "Description 1",
                ImageFile = "ImageFile 1",
                Price = 1M
            },
            new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Name 2",
                Category = "Category 2",
                Summary = "Summary 2",
                Description = "Description 2",
                ImageFile = "ImageFile 2",
                Price = 2M
            },
            new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Name 3",
                Category = "Category 3",
                Summary = "Summary 3",
                Description = "Description 3",
                ImageFile = "ImageFile 3",
                Price = 3M
            },
            new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Name 4",
                Category = "Category 4",
                Summary = "Summary 4",
                Description = "Description 4",
                ImageFile = "ImageFile 4",
                Price = 4M
            },
            new Product()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Name 5",
                Category = "Category 5",
                Summary = "Summary 5",
                Description = "Description 5",
                ImageFile = "ImageFile 5",
                Price = 5M
            }
        };
    }
}