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
                }
            }
        }
    }
}
