using WebApplication4.Models;
using System;
using System.Linq;
using WebApplication4.Data;

namespace WebApplication4.Areas.Identity.Data
{
    public class DataForDataBase
    {
        // This method will add data to your database
        public static void Initialize(WebApplication4Context context)
        {
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
                    new Item { Name = "Boots", CategoryId = 1, ImageURL = "", Price = 6.00 },
                    new Item { Name = "Running shoes", CategoryId = 1, ImageURL = "", Price = 2.00 },
 
                    // Outerwear
                    new Item { Name = "Raincoat", CategoryId = 2, ImageURL = "", Price = 6.00 },
                    new Item { Name = "Overtrousers - wet weather pants", CategoryId = 2, ImageURL = "", Price = 6.00 },
 
                    // Tops
                    new Item { Name = "Long sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "", Price = 2.00 },
                    new Item { Name = "Short sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "", Price = 2.00 },
                    new Item { Name = "Woollen jumper", CategoryId = 3, ImageURL = "", Price = 3.00 },
                    new Item { Name = "Bush shirt or polar fleece", CategoryId = 3, ImageURL = "", Price = 3.00 },
 
                    // Bottoms
                    new Item { Name = "Long johns - woollen or poly pro", CategoryId = 4, ImageURL = "", Price = 2.00 },
                    new Item { Name = "Trackpants", CategoryId = 4, ImageURL = "", Price = 1.00 },
                    new Item { Name = "Shorts", CategoryId = 4, ImageURL = "", Price = 1.00 },
 
                    // Accessories
                    new Item { Name = "Woollen Hats", CategoryId = 5, ImageURL = "", Price = 1.00 },
                    new Item { Name = "Woollen mittens", CategoryId = 5, ImageURL = "", Price = 2.00 },
                    new Item { Name = "Woollen socks", CategoryId = 5, ImageURL = "", Price = 3.00 },
 
                    // Sleeping Gear
                    new Item { Name = "Sleeping Bag (-3°C) and Liner (inc. cleaning)", CategoryId = 6, ImageURL = "", Price = 22.00 }
                };

                context.Item.AddRange(ItemsData);
                context.SaveChanges();
            }
        }
    }
}
