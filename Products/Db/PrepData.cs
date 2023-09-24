using Prducts.Db;
using Products.Models;

namespace Products.Db;

public static class PrepData
{

    public static void PrePopulate(IApplicationBuilder app)
    {
        using (var seviceScoped = app.ApplicationServices.CreateScope())
        {
            SeedData(seviceScoped.ServiceProvider.GetService<ProductDbContext>());
        }
    }

    private static void SeedData(ProductDbContext context)
    {
        if (!context.Products.Any())
        {

            Console.WriteLine("--> Seeding Data...");
            context.Products.AddRange(
                new Product()
                {
                    Name = "T-shirt",
                    Price = 15.99m,
                    Quantity = 50,
                    Size = "M",
                    Description = "A t-shirt designed for young men"
                },
                new Product()
                {
                    Name = "Sneakers",
                    Price = 22.99m,
                    Quantity = 25,
                    Size = "42",
                    Description = "Shoes for young men"
                },
                new Product()
                {
                    Name = "Sunglasses",
                    Price = 8.99m,
                    Quantity = 100,
                    Size = "22",
                    Description = "Sunglasses designed for women"
                }

            );
            context.SaveChanges();

        }
        else
        {
            Console.WriteLine("--> The Data have already been seeded");
        }
    }
}