using Marten.Schema;

namespace Catalog.API.Data;

public class CatalogInitialData : IInitialData
{
    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        using var session = store.LightweightSession();

        if (await session.Query<Product>().AnyAsync())
            return;

        // Marten UPSERT will cater for existing records.
        session.Store<Product>(GetPreconfiguredProducts());
        await session.SaveChangesAsync();
    }

    private static IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>
    {

            new Product
            {
                Id = new Guid("1292a0fd-6954-4851-a200-698445b81ee0"),
                Name = "Apple iPhone 14",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Latest Apple iPhone with advanced features.",
                ImageFile = "iphone14.jpg",
                Price = 999.99M
            },
            new Product
            {
                Id = new Guid("06ff9a7e-47e6-44c7-8e49-a1e0c3b05c9d"),
                Name = "Samsung Galaxy S22",
                Category = new List<string> { "Smartphones", "Electronics" },
                Description = "Flagship smartphone from Samsung.",
                ImageFile = "galaxy_s22.jpg",
                Price = 899.99M
            },
            new Product
            {
                Id = new Guid("6bb6b8c8-400f-4e16-92a7-88fc85873ab4"),
                Name = "Sony WH-1000XM4",
                Category = new List<string> { "Headphones", "Electronics" },
                Description = "Noise-cancelling over-ear headphones.",
                ImageFile = "sony_wh1000xm4.jpg",
                Price = 349.99M
            },
            new Product
            {
                Id = new Guid("b1c2d3e4-f5a6-7b8c-9d0e-f1a2b3c4d5e6"),
                Name = "Dell XPS 13",
                Category = new List<string> { "Laptops", "Computers" },
                Description = "Compact and powerful laptop from Dell.",
                ImageFile = "dell_xps_13.jpg",
                Price = 1299.99M
            },
            new Product
            {
                Id = new Guid("c2d3e4f5-a6b7-8c9d-0e1f-2a3b4c5d6e7f"),
                Name = "Apple MacBook Pro 16",
                Category = new List<string> { "Laptops", "Computers" },
                Description = "High-performance laptop with M1 chip.",
                ImageFile = "macbook_pro_16.jpg",
                Price = 2399.99M
            }
    };
}
