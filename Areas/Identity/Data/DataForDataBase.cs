using WebApplication4.Models;
using Microsoft.AspNetCore.Builder; // Ensure this namespace is included
using Microsoft.Extensions.DependencyInjection; // Needed for service resolution
using WebApplication4.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Areas.Identity.Data
{
    public class DataForDataBase
    {
        // This method will add data to your database
        public static void AddData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<WebApplication4Context>();

                // Ensure the database is created, consider using Migrate() for production
                context.Database.EnsureCreated(); // Use context.Database.Migrate() for production

                // Add categories to the database
                if (!context.Category.Any())
                {
                    var Categories = new Category[]
                    {
                        new Category { Name = "Footwear" },
                        new Category { Name = "Outerwear" },
                        new Category { Name = "Tops" },
                        new Category { Name = "Bottoms" },
                        new Category { Name = "Accessories" },
                        new Category { Name = "Sleeping Gear" }
                    };

                    context.Category.AddRange(Categories);
                    context.SaveChanges();
                }

      




                // Add items to the database
                if (!context.Item.Any())
                {
                    var ItemsData = new Item[]
                    {
                        // Footwear
                        new Item { Name = "Boots", CategoryId = 1, ImageURL = "/images/test.png", Price = 6.00 },
                        new Item { Name = "Running shoes", CategoryId = 1, ImageURL = "/images/test.png", Price = 2.00 },

                        // Outerwear
                        new Item { Name = "Raincoat", CategoryId = 2, ImageURL = "/images/test.png", Price = 6.00 },
                        new Item { Name = "Overtrousers - wet weather pants", CategoryId = 2, ImageURL = "/images/test.png", Price = 6.00 },

                        // Tops
                        new Item { Name = "Long sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Short sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Woollen jumper", CategoryId = 3, ImageURL = "/images/test.png", Price = 3.00 },
                        new Item { Name = "Bush shirt or polar fleece", CategoryId = 3, ImageURL = "/images/test.png", Price = 3.00 },

                        // Bottoms
                        new Item { Name = "Long johns - woollen or poly pro", CategoryId = 4, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Trackpants", CategoryId = 4, ImageURL = "/images/test.png", Price = 1.00 },
                        new Item { Name = "Shorts", CategoryId = 4, ImageURL = "/images/test.png", Price = 1.00 },

                        // Accessories
                        new Item { Name = "Woollen Hats", CategoryId = 5, ImageURL = "/images/test.png", Price = 1.00 },
                        new Item { Name = "Woollen mittens", CategoryId = 5, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Woollen socks", CategoryId = 5, ImageURL = "/images/test.png", Price = 3.00 },

                        // Sleeping Gear
                        new Item { Name = "Sleeping Bag (-3°C) and Liner (inc. cleaning)", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 }
                    };


                    var StatusData = new Status[]
                   {
                    new Status{Name = "Pending"},//1
                    new Status{Name = "Processing"},
                    new Status{Name ="returned"},
                    new Status{Name ="unreturned"},
                    new Status{Name = "AdminOrder"},


                   };
                    context.Status.AddRange(StatusData);
                    context.SaveChanges();





                    context.Item.AddRange(ItemsData);
                    context.SaveChanges();


                    var stockData = new Stock[]
{
    new Stock { ItemId = 1, StockId = 1000001, OrderId = null },
    new Stock { ItemId = 1, StockId = 1000002, OrderId = null },
    new Stock { ItemId = 1, StockId = 1000003, OrderId = null },
    new Stock { ItemId = 1, StockId = 1000004, OrderId = null },

    new Stock { ItemId = 2, StockId = 1000011, OrderId = null },
    new Stock { ItemId = 2, StockId = 1000012, OrderId = null },
    new Stock { ItemId = 2, StockId = 1000013, OrderId = null },
    new Stock { ItemId = 2, StockId = 1000014, OrderId = null },

    new Stock { ItemId = 3, StockId = 1000021, OrderId = null },
    new Stock { ItemId = 3, StockId = 1000022, OrderId = null },
    new Stock { ItemId = 3, StockId = 1000023, OrderId = null },
    new Stock { ItemId = 3, StockId = 1000024, OrderId = null },

    new Stock { ItemId = 4, StockId = 1000031, OrderId = null },
    new Stock { ItemId = 4, StockId = 1000032, OrderId = null },
    new Stock { ItemId = 4, StockId = 1000033, OrderId = null },
    new Stock { ItemId = 4, StockId = 1000034, OrderId = null },

    new Stock { ItemId = 5, StockId = 1000041, OrderId = null },
    new Stock { ItemId = 5, StockId = 1000042, OrderId = null },
    new Stock { ItemId = 5, StockId = 1000043, OrderId = null },
    new Stock { ItemId = 5, StockId = 1000044, OrderId = null },

    new Stock { ItemId = 6, StockId = 1000051, OrderId = null },
    new Stock { ItemId = 6, StockId = 1000052, OrderId = null },
    new Stock { ItemId = 6, StockId = 1000053, OrderId = null },
    new Stock { ItemId = 6, StockId = 1000054, OrderId = null },

    new Stock { ItemId = 7, StockId = 1000061, OrderId = null },
    new Stock { ItemId = 7, StockId = 1000062, OrderId = null },
    new Stock { ItemId = 7, StockId = 1000063, OrderId = null },
    new Stock { ItemId = 7, StockId = 1000064, OrderId = null },

    new Stock { ItemId = 8, StockId = 1000071, OrderId = null },
    new Stock { ItemId = 8, StockId = 1000072, OrderId = null },
    new Stock { ItemId = 8, StockId = 1000073, OrderId = null },
    new Stock { ItemId = 8, StockId = 1000074, OrderId = null },

    new Stock { ItemId = 9, StockId = 1000081, OrderId = null },
    new Stock { ItemId = 9, StockId = 1000082, OrderId = null },
    new Stock { ItemId = 9, StockId = 1000083, OrderId = null },
    new Stock { ItemId = 9, StockId = 1000084, OrderId = null },

    new Stock { ItemId = 10, StockId = 1000091, OrderId = null },
    new Stock { ItemId = 10, StockId = 1000092, OrderId = null },
    new Stock { ItemId = 10, StockId = 1000093, OrderId = null },
    new Stock { ItemId = 10, StockId = 1000094, OrderId = null },

    new Stock { ItemId = 11, StockId = 1000101, OrderId = null },
    new Stock { ItemId = 11, StockId = 1000102, OrderId = null },
    new Stock { ItemId = 11, StockId = 1000103, OrderId = null },
    new Stock { ItemId = 11, StockId = 1000104, OrderId = null },

    new Stock { ItemId = 12, StockId = 1000111, OrderId = null },
    new Stock { ItemId = 12, StockId = 1000112, OrderId = null },
    new Stock { ItemId = 12, StockId = 1000113, OrderId = null },
    new Stock { ItemId = 12, StockId = 1000114, OrderId = null },

    new Stock { ItemId = 13, StockId = 1000121, OrderId = null },
    new Stock { ItemId = 13, StockId = 1000122, OrderId = null },
    new Stock { ItemId = 13, StockId = 1000123, OrderId = null },
    new Stock { ItemId = 13, StockId = 1000124, OrderId = null },

    new Stock { ItemId = 14, StockId = 1000131, OrderId = null },
    new Stock { ItemId = 14, StockId = 1000132, OrderId = null },
    new Stock { ItemId = 14, StockId = 1000133, OrderId = null },
    new Stock { ItemId = 14, StockId = 1000134, OrderId = null },

    new Stock { ItemId = 15, StockId = 1000141, OrderId = null },
    new Stock { ItemId = 15, StockId = 1000142, OrderId = null },
    new Stock { ItemId = 15, StockId = 1000143, OrderId = null },
    new Stock { ItemId = 15, StockId = 1000144, OrderId = null },

    
};

                   
                    context.Stock.AddRange(stockData);

                    context.SaveChanges();


                }
            }
        }
    }
}
