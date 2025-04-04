using WebApplication4.Models;
using Microsoft.AspNetCore.Builder; // Ensure this namespace is included
using Microsoft.Extensions.DependencyInjection; // Needed for service resolution
using WebApplication4.Data;
using System.Linq;

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

                var camps = new[]
{
    // Camps for Year 10
    new Camp
    {
        Startdate = new DateTime(2025, 06, 01),
        Enddate = new DateTime(2025, 06, 07),
        peoplelimt = 30,
        Year = 10,
    },
    new Camp
    {
        Startdate = new DateTime(2025, 06, 08),
        Enddate = new DateTime(2025, 06, 14),
        peoplelimt = 30,
        Year = 10,
      
    },
    new Camp
    {
        Startdate = new DateTime(2025, 06, 15),
        Enddate = new DateTime(2025, 06, 21),
     peoplelimt = 30,
        Year = 10,
      
    },

    // Camps for Year 12
    new Camp
    {
        Startdate = new DateTime(2025, 07, 01),
        Enddate = new DateTime(2025, 07, 07),
        peoplelimt = 30,
        Year = 12,
      
    },
    new Camp
    {
        Startdate = new DateTime(2025, 07, 08),
        Enddate = new DateTime(2025, 07, 14),
 peoplelimt = 30,
        Year = 12,

    },
    new Camp
    {
        Startdate = new DateTime(2025, 07, 15),
        Enddate = new DateTime(2025, 07, 21),
    peoplelimt = 30,
        Year = 12,
    
    },

    // Camps for Year 13
    new Camp
    {
        Startdate = new DateTime(2025, 08, 01),
        Enddate = new DateTime(2025, 08, 07),
         peoplelimt = 30,
        Year = 13,

    },
    new Camp
    {
        Startdate = new DateTime(2025, 08, 08),
        Enddate = new DateTime(2025, 08, 14),
        peoplelimt = 30,
        Year = 13,
      
    },
    new Camp
    {
        Startdate = new DateTime(2025, 08, 15),
        Enddate = new DateTime(2025, 08, 21),
       peoplelimt = 30,
        Year = 13,
    
    }
};

                context.Camp.AddRange(camps);
                context.SaveChanges();





                // Add items to the database
                if (!context.Item.Any())
                {
                    var ItemsData = new Item[]
                    {
                        // Footwear
                        new Item { Name = "Boots", CategoryId = 1, ImageURL = " ", Price = 6.00 },
                        new Item { Name = "Running shoes", CategoryId = 1, ImageURL = " ", Price = 2.00 },

                        // Outerwear
                        new Item { Name = "Raincoat", CategoryId = 2, ImageURL = " ", Price = 6.00 },
                        new Item { Name = "Overtrousers - wet weather pants", CategoryId = 2, ImageURL = " ", Price = 6.00 },

                        // Tops
                        new Item { Name = "Long sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "", Price = 2.00 },
                        new Item { Name = "Short sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "", Price = 2.00 },
                        new Item { Name = "Woollen jumper", CategoryId = 3, ImageURL = " ", Price = 3.00 },
                        new Item { Name = "Bush shirt or polar fleece", CategoryId = 3, ImageURL = "", Price = 3.00 },

                        // Bottoms
                        new Item { Name = "Long johns - woollen or poly pro", CategoryId = 4, ImageURL = "", Price = 2.00 },
                        new Item { Name = "Trackpants", CategoryId = 4, ImageURL = " ", Price = 1.00 },
                        new Item { Name = "Shorts", CategoryId = 4, ImageURL = " ", Price = 1.00 },

                        // Accessories
                        new Item { Name = "Woollen Hats", CategoryId = 5, ImageURL = " ", Price = 1.00 },
                        new Item { Name = "Woollen mittens", CategoryId = 5, ImageURL = " ", Price = 2.00 },
                        new Item { Name = "Woollen socks", CategoryId = 5, ImageURL = " ", Price = 3.00 },

                        // Sleeping Gear
                        new Item { Name = "Sleeping Bag (-3°C) and Liner (inc. cleaning)", CategoryId = 6, ImageURL = " ", Price = 22.00 }
                    };


                    var StatusData = new Status[]
                   {
                    new Status{Name = "Pending"},
                    new Status{Name = "Processing"},
                    new Status{Name ="returned"},
                    new Status{Name ="unreturned"}

                   };
                    context.Status.AddRange(StatusData);
                    context.SaveChanges();


                    var CampData = new Camp[]
                    {
                            new Camp
                            {
                                
                                Enddate= DateTime.Now,
                                Startdate = DateTime.Now,
                                peoplelimt = 1,
                                Year = 11
                            }


                    };


                    context.Camp.AddRange(CampData);
                    context.SaveChanges();


                    context.Item.AddRange(ItemsData);
                    context.SaveChanges();


                    var stockData = new Stock[]
{
    new Stock { ItemId = 1, StockId = 1000001, UserId = null },
    new Stock { ItemId = 1, StockId = 1000002, UserId = null },
    new Stock { ItemId = 1, StockId = 1000003, UserId = null },
    new Stock { ItemId = 1, StockId = 1000004, UserId = null },

    new Stock { ItemId = 2, StockId = 1000011, UserId = null },
    new Stock { ItemId = 2, StockId = 1000012, UserId = null },
    new Stock { ItemId = 2, StockId = 1000013, UserId = null },
    new Stock { ItemId = 2, StockId = 1000014, UserId = null },

    new Stock { ItemId = 3, StockId = 1000021, UserId = null },
    new Stock { ItemId = 3, StockId = 1000022, UserId = null },
    new Stock { ItemId = 3, StockId = 1000023, UserId = null },
    new Stock { ItemId = 3, StockId = 1000024, UserId = null },

    new Stock { ItemId = 4, StockId = 1000031, UserId = null },
    new Stock { ItemId = 4, StockId = 1000032, UserId = null },
    new Stock { ItemId = 4, StockId = 1000033, UserId = null },
    new Stock { ItemId = 4, StockId = 1000034, UserId = null },

    new Stock { ItemId = 5, StockId = 1000041, UserId = null },
    new Stock { ItemId = 5, StockId = 1000042, UserId = null },
    new Stock { ItemId = 5, StockId = 1000043, UserId = null },
    new Stock { ItemId = 5, StockId = 1000044, UserId = null },

    new Stock { ItemId = 6, StockId = 1000051, UserId = null },
    new Stock { ItemId = 6, StockId = 1000052, UserId = null },
    new Stock { ItemId = 6, StockId = 1000053, UserId = null },
    new Stock { ItemId = 6, StockId = 1000054, UserId = null },

    new Stock { ItemId = 7, StockId = 1000061, UserId = null },
    new Stock { ItemId = 7, StockId = 1000062, UserId = null },
    new Stock { ItemId = 7, StockId = 1000063, UserId = null },
    new Stock { ItemId = 7, StockId = 1000064, UserId = null },

    new Stock { ItemId = 8, StockId = 1000071, UserId = null },
    new Stock { ItemId = 8, StockId = 1000072, UserId = null },
    new Stock { ItemId = 8, StockId = 1000073, UserId = null },
    new Stock { ItemId = 8, StockId = 1000074, UserId = null },

    new Stock { ItemId = 9, StockId = 1000081, UserId = null },
    new Stock { ItemId = 9, StockId = 1000082, UserId = null },
    new Stock { ItemId = 9, StockId = 1000083, UserId = null },
    new Stock { ItemId = 9, StockId = 1000084, UserId = null },

    new Stock { ItemId = 10, StockId = 1000091, UserId = null },
    new Stock { ItemId = 10, StockId = 1000092, UserId = null },
    new Stock { ItemId = 10, StockId = 1000093, UserId = null },
    new Stock { ItemId = 10, StockId = 1000094, UserId = null },

    new Stock { ItemId = 11, StockId = 1000101, UserId = null },
    new Stock { ItemId = 11, StockId = 1000102, UserId = null },
    new Stock { ItemId = 11, StockId = 1000103, UserId = null },
    new Stock { ItemId = 11, StockId = 1000104, UserId = null },

    new Stock { ItemId = 12, StockId = 1000111, UserId = null },
    new Stock { ItemId = 12, StockId = 1000112, UserId = null },
    new Stock { ItemId = 12, StockId = 1000113, UserId = null },
    new Stock { ItemId = 12, StockId = 1000114, UserId = null },

    new Stock { ItemId = 13, StockId = 1000121, UserId = null },
    new Stock { ItemId = 13, StockId = 1000122, UserId = null },
    new Stock { ItemId = 13, StockId = 1000123, UserId = null },
    new Stock { ItemId = 13, StockId = 1000124, UserId = null },

    new Stock { ItemId = 14, StockId = 1000131, UserId = null },
    new Stock { ItemId = 14, StockId = 1000132, UserId = null },
    new Stock { ItemId = 14, StockId = 1000133, UserId = null },
    new Stock { ItemId = 14, StockId = 1000134, UserId = null },

    new Stock { ItemId = 15, StockId = 1000141, UserId = null },
    new Stock { ItemId = 15, StockId = 1000142, UserId = null },
    new Stock { ItemId = 15, StockId = 1000143, UserId = null },
    new Stock { ItemId = 15, StockId = 1000144, UserId = null },

    new Stock { ItemId = 16, StockId = 1000151, UserId = null },
    new Stock { ItemId = 16, StockId = 1000152, UserId = null },
    new Stock { ItemId = 16, StockId = 1000153, UserId = null },
    new Stock { ItemId = 16, StockId = 1000154, UserId = null },

    new Stock { ItemId = 17, StockId = 1000161, UserId = null },
    new Stock { ItemId = 17, StockId = 1000162, UserId = null },
    new Stock { ItemId = 17, StockId = 1000163, UserId = null },
    new Stock { ItemId = 17, StockId = 1000164, UserId = null },

    new Stock { ItemId = 18, StockId = 1000171, UserId = null },
    new Stock { ItemId = 18, StockId = 1000172, UserId = null },
    new Stock { ItemId = 18, StockId = 1000173, UserId = null },
    new Stock { ItemId = 18, StockId = 1000174, UserId = null },

    new Stock { ItemId = 19, StockId = 1000181, UserId = null },
    new Stock { ItemId = 19, StockId = 1000182, UserId = null },
    new Stock { ItemId = 19, StockId = 1000183, UserId = null },
    new Stock { ItemId = 19, StockId = 1000184, UserId = null },

    new Stock { ItemId = 20, StockId = 1000191, UserId = null },
    new Stock { ItemId = 20, StockId = 1000192, UserId = null },
    new Stock { ItemId = 20, StockId = 1000193, UserId = null },
    new Stock { ItemId = 20, StockId = 1000194, UserId = null }
};


                    context.Stock.AddRange(stockData);
                    context.SaveChanges();


                }
            }
        }
    }
}
