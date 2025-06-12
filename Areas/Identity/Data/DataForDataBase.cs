using WebApplication4.Data;
using WebApplication4.Models;
using static WebApplication4.Models.Stock;

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
new Item { Name = "Sleeping Bag", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 },
new Item { Name = "Jumper", CategoryId = 3, ImageURL = "/images/test.png", Price = 3.00 },
new Item { Name = "Raincoat", CategoryId = 2, ImageURL = "/images/test.png", Price = 6.00 },

new Item { Name = "Bush Shirt", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },
new Item { Name = "Long Johns Polypro", CategoryId = 4, ImageURL = "/images/test.png", Price = 2.00 },
new Item { Name = "Long Johns Woolen", CategoryId = 4, ImageURL = "/images/test.png", Price = 2.00 },

new Item { Name = "Day Pack", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 },

new Item { Name = "Shorts", CategoryId = 4, ImageURL = "/images/test.png", Price = 1.00 },

new Item { Name = "Trackpants", CategoryId = 4, ImageURL = "/images/test.png", Price = 1.00 },

new Item { Name = "Long Sleeved Vest - Polypro", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },

new Item { Name = "Short Sleeved Vest - Polypro", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },
new Item { Name = "Short Sleeved Vest - Woolen", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },

new Item { Name = "Overnight Pack", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 },

// Outerwear
new Item { Name = "Overtrousers - Wet Weather Pants", CategoryId = 2, ImageURL = "/images/test.png", Price = 6.00 },

// Tops
new Item { Name = "Beanies", CategoryId = 5, ImageURL = "/images/test.png", Price = 1.00 },

new Item { Name = "Polar Fleece", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },

// Accessories
new Item { Name = "Woolen Mittens", CategoryId = 5, ImageURL = "/images/test.png", Price = 2.00 },
new Item { Name = "Woolen Socks", CategoryId = 5, ImageURL = "/images/test.png", Price = 3.00 }

// Sleeping Gear

                    };

                    context.Item.AddRange(ItemsData);
                    context.SaveChanges();

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





                 


                    var stockData = new Stock[]
{
    new Stock { ItemId = 1, StockNumber = "3A", StockId = 1000001, OrderId = null, ShoeSizes = (ShoeSize)30, Brand = "Van Walk suede", Notes = "" },
new Stock { ItemId = 1, StockNumber = "3B", StockId = 1000002, OrderId = null, ShoeSizes = (ShoeSize)30, Brand = "Asolo suede", Notes = "" },
new Stock { ItemId = 1, StockNumber = "3C", StockId = 1000003, OrderId = null, ShoeSizes = (ShoeSize)30, Brand = "Torpedo Keppler size36", Notes = "NEW 22.04.16 | put in stock 31.08.17" },
new Stock { ItemId = 1, StockNumber = "3D", StockId = 1000004, OrderId = null, ShoeSizes = (ShoeSize)30, Brand = "Torpedo Keppler size36", Notes = "NEW 22.04.16 | put in stock 31.08.17" },
new Stock { ItemId = 1, StockNumber = "3E", StockId = 1000005, OrderId = null, ShoeSizes = (ShoeSize)30, Brand = "Torpedo Keppler size36", Notes = "NEW 22.04.16 | put in stock 31.08.17" },
new Stock { ItemId = 1, StockNumber = "3F", StockId = 1000006, OrderId = null, ShoeSizes = (ShoeSize)30, Brand = "Torpedo Keppler size36", Notes = "NEW 22.04.16 | put in stock 31.08.17" },
new Stock { ItemId = 1, StockNumber = "3.5 A", StockId = 1000007, OrderId = null, ShoeSizes = (ShoeSize)35, Brand = "Merrell", Notes = "NEW 06.05.15" },
new Stock { ItemId = 1, StockNumber = "3.5 B", StockId = 1000008, OrderId = null, ShoeSizes = (ShoeSize)35, Brand = "Merrell", Notes = "NEW 06.05.15" },
new Stock { ItemId = 1, StockNumber = "3.5 C", StockId = 1000009, OrderId = null, ShoeSizes = (ShoeSize)35, Brand = "Torpedo Keppler size37", Notes = "NEW 22.04.16 | put in stock 31.08.17" },
new Stock { ItemId = 1, StockNumber = "3.5 D", StockId = 1000010, OrderId = null, ShoeSizes = (ShoeSize)35, Brand = "Torpedo Keppler size37", Notes = "NEW 22.04.16 | put in stock 31.08.17" },
new Stock { ItemId = 1, StockNumber = "3.5 E", StockId = 1000011, OrderId = null, ShoeSizes = (ShoeSize)35, Brand = "Torpedo Keppler size37", Notes = "NEW 22.04.16 | put in stock 31.08.17" },
new Stock { ItemId = 1, StockNumber = "4A", StockId = 1000012, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "4B", StockId = 1000013, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "Inside sole very worn" },
new Stock { ItemId = 1, StockNumber = "4C", StockId = 1000014, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "Inside sole very worn" },
new Stock { ItemId = 1, StockNumber = "4D", StockId = 1000015, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "" },
new Stock { ItemId = 1, StockNumber = "4E", StockId = 1000016, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Kathmandu Ortholite", Notes = "Donated 20.3.20" },
new Stock { ItemId = 1, StockNumber = "4F", StockId = 1000017, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "" },
new Stock { ItemId = 1, StockNumber = "4G", StockId = 1000018, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "" },
new Stock { ItemId = 1, StockNumber = "4H", StockId = 1000019, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Torpedo Keppler ", Notes = "NEW 22.04.16 | put in stock 14.11.17" },
new Stock { ItemId = 1, StockNumber = "4K", StockId = 1000022, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Asolo leather", Notes = "" },
new Stock { ItemId = 1, StockNumber = "4L", StockId = 1000023, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skelleerup Hiker", Notes = "New30.01.24" },
new Stock { ItemId = 1, StockNumber = "4M", StockId = 1000024, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "Inside sole worn. Edging around toe (outside) wearing" },
new Stock { ItemId = 1, StockNumber = "4N", StockId = 1000025, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "4O", StockId = 1000026, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "Inside sole worn" },
new Stock { ItemId = 1, StockNumber = "4P", StockId = 1000027, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "4Q", StockId = 1000028, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "" },
new Stock { ItemId = 1, StockNumber = "4R", StockId = 1000029, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "4S", StockId = 1000030, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "" },
new Stock { ItemId = 1, StockNumber = "4T", StockId = 1000031, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Ecolight Suede", Notes = "Donated 8.11.19" },
new Stock { ItemId = 1, StockNumber = "4U", StockId = 1000032, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "4V", StockId = 1000033, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "4W", StockId = 1000034, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "4X", StockId = 1000035, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "4Y", StockId = 1000036, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Skellerup Hiker", Notes = "Old one" },
new Stock { ItemId = 1, StockNumber = "4Z", StockId = 1000037, OrderId = null, ShoeSizes = (ShoeSize)40, Brand = "Hiker brown", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "5B", StockId = 1000039, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Iinside soles very worn, inside heels worn" },
new Stock { ItemId = 1, StockNumber = "5C", StockId = 1000040, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Hitec", Notes = "not suitable for camp" },
new Stock { ItemId = 1, StockNumber = "5D", StockId = 1000041, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | repair done to RH boot 'clasp' | Inside soles very worn | Inside heels worn" },
new Stock { ItemId = 1, StockNumber = "5E", StockId = 1000042, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "5F", StockId = 1000043, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "5G", StockId = 1000044, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "5H", StockId = 1000045, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "Old" },
new Stock { ItemId = 1, StockNumber = "5J", StockId = 1000047, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "" },
new Stock { ItemId = 1, StockNumber = "5K", StockId = 1000048, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "5L", StockId = 1000050, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "5M", StockId = 1000051, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "5N", StockId = 1000052, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Timberland Gor-Tex", Notes = "NEW 20.8.21" },
new Stock { ItemId = 1, StockNumber = "5O", StockId = 1000053, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Inside soles worn | Inside heels worn" },
new Stock { ItemId = 1, StockNumber = "5P", StockId = 1000054, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "5Q", StockId = 1000055, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "5R", StockId = 1000056, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "5S", StockId = 1000057, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerhup Hiker", Notes = "Inside soles very worn" },
new Stock { ItemId = 1, StockNumber = "5T", StockId = 1000058, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerhup Hiker", Notes = "Inside soles very worn" },
new Stock { ItemId = 1, StockNumber = "5U", StockId = 1000059, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Hitec", Notes = "Skellerup Hiker 30.01.24" },
new Stock { ItemId = 1, StockNumber = "5V", StockId = 1000060, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerhup Hiker", Notes = "" },
new Stock { ItemId = 1, StockNumber = "5W", StockId = 1000061, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerhup Hiker", Notes = "Inside soles worn" },
new Stock { ItemId = 1, StockNumber = "5X", StockId = 1000062, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerhup Hiker", Notes = "" },
new Stock { ItemId = 1, StockNumber = "5Y", StockId = 1000063, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerhup Hiker", Notes = "Inside soles very worn" },
new Stock { ItemId = 1, StockNumber = "5Z", StockId = 1000064, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerhup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "5.5 A", StockId = 1000065, OrderId = null, ShoeSizes = (ShoeSize)55, Brand = "Hiker brown", Notes = "" },
new Stock { ItemId = 1, StockNumber = "5.5 C", StockId = 1000066, OrderId = null, ShoeSizes = (ShoeSize)55, Brand = "Removed 14.03.16", Notes = "" },
new Stock { ItemId = 1, StockNumber = "5.5 D", StockId = 1000067, OrderId = null, ShoeSizes = (ShoeSize)55, Brand = "British Adventure suede", Notes = "" },
new Stock { ItemId = 1, StockNumber = "5.5 E", StockId = 1000068, OrderId = null, ShoeSizes = (ShoeSize)55, Brand = "Removed 11.12.15", Notes = "" },
new Stock { ItemId = 1, StockNumber = "6A", StockId = 1000069, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Inside soles very worn | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "6B", StockId = 1000070, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Torpedo 7 Routeburn", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "6C", StockId = 1000071, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hiker brown", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "6D", StockId = 1000072, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hiker brown", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "6E", StockId = 1000073, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Woodman", Notes = "New Donated 2022" },
new Stock { ItemId = 1, StockNumber = "6F", StockId = 1000074, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "6G", StockId = 1000075, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Throw away", Notes = "" },
new Stock { ItemId = 1, StockNumber = "6H", StockId = 1000076, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "6I", StockId = 1000077, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hiker brown", Notes = "New16.10.23" },
new Stock { ItemId = 1, StockNumber = "6J", StockId = 1000078, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hitec", Notes = "Tongue flaking | inside heel worn" },
new Stock { ItemId = 1, StockNumber = "6K", StockId = 1000079, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hitec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "6A", StockId = 1000080, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Inside soles very worn | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "6B", StockId = 1000081, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Torpedo 7 Routeburn", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "6C", StockId = 1000082, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hiker brown", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "6D", StockId = 1000083, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hiker brown", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "6E", StockId = 1000084, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Woodman", Notes = "New Donated 2022" },
new Stock { ItemId = 1, StockNumber = "6F", StockId = 1000085, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "6G", StockId = 1000086, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Throw away", Notes = "" },
new Stock { ItemId = 1, StockNumber = "6H", StockId = 1000087, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "6I", StockId = 1000088, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hiker brown", Notes = "New16.10.23" },
new Stock { ItemId = 1, StockNumber = "6J", StockId = 1000089, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hitec", Notes = "Tongue flaking | inside heel worn" },
new Stock { ItemId = 1, StockNumber = "6K", StockId = 1000090, OrderId = null, ShoeSizes = (ShoeSize)60, Brand = "Hitec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "6.5 E", StockId = 1000091, OrderId = null, ShoeSizes = (ShoeSize)65, Brand = "Removed 11.08.15", Notes = "TO BE REPLACED" },
new Stock { ItemId = 1, StockNumber = "6.5 F", StockId = 1000092, OrderId = null, ShoeSizes = (ShoeSize)65, Brand = "Removed 23.01.17", Notes = "TO BE REPLACED" },
new Stock { ItemId = 1, StockNumber = "7A", StockId = 1000093, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | inside soles very worn | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "7B", StockId = 1000094, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12 | inside soles very worn | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "7C", StockId = 1000095, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "7D", StockId = 1000096, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "7E", StockId = 1000097, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "7F", StockId = 1000098, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Hitec", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "7G", StockId = 1000099, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Hitec", Notes = "New 15.10.24" },
new Stock { ItemId = 1, StockNumber = "7H", StockId = 1000100, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "7I", StockId = 1000101, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Throw Away", Notes = "" },
new Stock { ItemId = 1, StockNumber = "7J", StockId = 1000102, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Hiker brown", Notes = "New 16.10.23" },
new Stock { ItemId = 1, StockNumber = "7L", StockId = 1000104, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "NEW  30.01.24" },
new Stock { ItemId = 1, StockNumber = "7M", StockId = 1000105, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "New 28.10.08" },
new Stock { ItemId = 1, StockNumber = "7N", StockId = 1000106, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | inside soles worn | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "7O", StockId = 1000107, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "New 16.10.23" },
new Stock { ItemId = 1, StockNumber = "7P", StockId = 1000108, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "7Q", StockId = 1000109, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "7R", StockId = 1000110, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "7S", StockId = 1000111, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "7T", StockId = 1000112, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Hiker Brown", Notes = "New 16.10.24" },
new Stock { ItemId = 1, StockNumber = "7U", StockId = 1000113, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Hiker brown 16.10.23 New", Notes = "16.10.23" },
new Stock { ItemId = 1, StockNumber = "7V", StockId = 1000114, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Hiker Brown", Notes = "New 16.1023" },
new Stock { ItemId = 1, StockNumber = "7W", StockId = 1000115, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Inside heels wearing" },
new Stock { ItemId = 1, StockNumber = "7X", StockId = 1000116, OrderId = null, ShoeSizes = (ShoeSize)70, Brand = "", Notes = "Throw away 2024" },
new Stock { ItemId = 1, StockNumber = "8A", StockId = 1000117, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Skellerup Hiker", Notes = "NEW 08.02.10 | inside soles very worn | inside heels worn | repair work done to R) boot" },
new Stock { ItemId = 1, StockNumber = "8B", StockId = 1000118, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Skellerup Hiker", Notes = "NEW 09.06.22" },
new Stock { ItemId = 1, StockNumber = "8C", StockId = 1000119, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hiker brown", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "8D", StockId = 1000120, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "8E", StockId = 1000121, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Skellerup Hiker", Notes = "NEW 09.06.22" },
new Stock { ItemId = 1, StockNumber = "8F", StockId = 1000122, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Gore-Tex", Notes = "2022 donated" },
new Stock { ItemId = 1, StockNumber = "8G", StockId = 1000123, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hiker brown", Notes = "New 16.10.23" },
new Stock { ItemId = 1, StockNumber = "8H", StockId = 1000124, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "New Balance Rugged Outback", Notes = "" },
new Stock { ItemId = 1, StockNumber = "8I", StockId = 1000125, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "8J", StockId = 1000126, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Skellerup Hiker", Notes = "inside soles very worn | inside heels very worn" },
new Stock { ItemId = 1, StockNumber = "8K", StockId = 1000127, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Inside soles very worn | inside heels very worn | repair work done on R) boot" },
new Stock { ItemId = 1, StockNumber = "8L", StockId = 1000128, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "8M", StockId = 1000129, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hiker brown", Notes = "30.01.14" },
new Stock { ItemId = 1, StockNumber = "8N", StockId = 1000130, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hitec", Notes = "New 23.10. 2024" },
new Stock { ItemId = 1, StockNumber = "8O", StockId = 1000131, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "8P", StockId = 1000132, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Viking Green", Notes = "" },
new Stock { ItemId = 1, StockNumber = "8Q", StockId = 1000133, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hiker brown", Notes = "New . 26010.23" },
new Stock { ItemId = 1, StockNumber = "8K", StockId = 1000134, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Inside soles very worn | inside heels very worn | repair work done on R) boot" },
new Stock { ItemId = 1, StockNumber = "8L", StockId = 1000135, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "8M", StockId = 1000136, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hiker brown", Notes = "30.01.14" },
new Stock { ItemId = 1, StockNumber = "8N", StockId = 1000137, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hitec", Notes = "New 23.10. 2024" },
new Stock { ItemId = 1, StockNumber = "8O", StockId = 1000138, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "8P", StockId = 1000139, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Viking Green", Notes = "" },
new Stock { ItemId = 1, StockNumber = "8Q", StockId = 1000140, OrderId = null, ShoeSizes = (ShoeSize)80, Brand = "Hiker brown", Notes = "New . 26010.23" },
new Stock { ItemId = 1, StockNumber = "9A", StockId = 1000141, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "9B", StockId = 1000142, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "9C", StockId = 1000143, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Hi-Tec Altitude", Notes = "29.02.24" },
new Stock { ItemId = 1, StockNumber = "9D", StockId = 1000144, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Hi-Tec Purple", Notes = "NEW 10.11.21" },
new Stock { ItemId = 1, StockNumber = "9E", StockId = 1000145, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Hi Tec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "9F", StockId = 1000146, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Hi Tec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "9G", StockId = 1000147, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Inside soles very wron | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "9H", StockId = 1000148, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | inside heels worn | new soles" },
new Stock { ItemId = 1, StockNumber = "9I", StockId = 1000149, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | inside soles worn | inside heels very worn" },
new Stock { ItemId = 1, StockNumber = "9J", StockId = 1000150, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "9K", StockId = 1000151, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Hi Tec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "9L", StockId = 1000152, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Hi Tec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "9M", StockId = 1000153, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Garmont ", Notes = "Donated 03.02.22" },
new Stock { ItemId = 1, StockNumber = "9N", StockId = 1000154, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Hi Tec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "9O", StockId = 1000155, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Hi Tec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "9P", StockId = 1000156, OrderId = null, ShoeSizes = (ShoeSize)90, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | inside soles very worn | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "10A", StockId = 1000157, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "10B", StockId = 1000158, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Skellerup Hiker", Notes = "NEW 09.06.22" },
new Stock { ItemId = 1, StockNumber = "10C", StockId = 1000159, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "10D", StockId = 1000160, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "10E", StockId = 1000161, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec", Notes = "NEW 4.10.24" },
new Stock { ItemId = 1, StockNumber = "10F", StockId = 1000162, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12 | inside soles worn" },
new Stock { ItemId = 1, StockNumber = "10G", StockId = 1000163, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec", Notes = "NEW 4.10.24" },
new Stock { ItemId = 1, StockNumber = "10H", StockId = 1000164, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Skellerup Hiker", Notes = "NEW 20.04.15 | inside soles and heels wearing" },
new Stock { ItemId = 1, StockNumber = "10I", StockId = 1000165, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 14.03.18" },
new Stock { ItemId = 1, StockNumber = "10J", StockId = 1000166, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "10K", StockId = 1000167, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec", Notes = "" },
new Stock { ItemId = 1, StockNumber = "10L", StockId = 1000168, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec", Notes = "Throw away 2024" },
new Stock { ItemId = 1, StockNumber = "10M", StockId = 1000169, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec brown", Notes = "" },
new Stock { ItemId = 1, StockNumber = "10N", StockId = 1000170, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Skellerup Hiker", Notes = "NEW 8.11.2019 | repair work on R) boot | inside soles worn" },
new Stock { ItemId = 1, StockNumber = "10O", StockId = 1000171, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "10P", StockId = 1000172, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "10Q", StockId = 1000173, OrderId = null, ShoeSizes = (ShoeSize)100, Brand = "Throw away", Notes = "" },
new Stock { ItemId = 1, StockNumber = "11A", StockId = 1000174, OrderId = null, ShoeSizes = (ShoeSize)110, Brand = "Torpedo Routeburn Ortholite", Notes = "NEW 22.04.16 | put in stock 23.08.17" },
new Stock { ItemId = 1, StockNumber = "11B", StockId = 1000175, OrderId = null, ShoeSizes = (ShoeSize)110, Brand = "Skellerup Hiker", Notes = "NEW 09.06.22" },
new Stock { ItemId = 1, StockNumber = "11C", StockId = 1000176, OrderId = null, ShoeSizes = (ShoeSize)110, Brand = "Hitec", Notes = "NEW 11.10.24" },
new Stock { ItemId = 1, StockNumber = "11D", StockId = 1000177, OrderId = null, ShoeSizes = (ShoeSize)110, Brand = "Skellerup Hiker", Notes = "BoNEWught 08.02.10 | inside soles very worn | inside heels very worn | repair work on L) boot" },
new Stock { ItemId = 1, StockNumber = "11E", StockId = 1000178, OrderId = null, ShoeSizes = (ShoeSize)110, Brand = "Skellerup Hiker", Notes = "NEW 09.06.22" },
new Stock { ItemId = 1, StockNumber = "11F", StockId = 1000179, OrderId = null, ShoeSizes = (ShoeSize)110, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | inside soles worn | inside heels very worn " },
new Stock { ItemId = 1, StockNumber = "11G", StockId = 1000180, OrderId = null, ShoeSizes = (ShoeSize)110, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12 | inside heels worn" },
new Stock { ItemId = 1, StockNumber = "12A", StockId = 1000181, OrderId = null, ShoeSizes = (ShoeSize)120, Brand = "Skellerup Hiker", Notes = "NEW 22.2.22" },
new Stock { ItemId = 1, StockNumber = "12B", StockId = 1000182, OrderId = null, ShoeSizes = (ShoeSize)120, Brand = "Skellerup Hiker", Notes = "NEW 22.02.22" },
new Stock { ItemId = 1, StockNumber = "12C", StockId = 1000183, OrderId = null, ShoeSizes = (ShoeSize)120, Brand = "Hi Tec Altitude brown", Notes = "Bought 15.05.17 | put in stock 09.06.17 | toes scuffed" },
new Stock { ItemId = 1, StockNumber = "12D", StockId = 1000184, OrderId = null, ShoeSizes = (ShoeSize)120, Brand = "Skellerup Hiker", Notes = "NEW 22.02.22" },
new Stock { ItemId = 1, StockNumber = "12E", StockId = 1000185, OrderId = null, ShoeSizes = (ShoeSize)120, Brand = "Skellerup Hiker", Notes = "NEW 09.06.22" },
new Stock { ItemId = 1, StockNumber = "12F", StockId = 1000186, OrderId = null, ShoeSizes = (ShoeSize)120, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | inside soles worn" },
new Stock { ItemId = 1, StockNumber = "13A", StockId = 1000187, OrderId = null, ShoeSizes = (ShoeSize)130, Brand = "Hi-Tec Altitude Brown ", Notes = "NEW 23.02.16 | toes scuffed" },
new Stock { ItemId = 1, StockNumber = "13B", StockId = 1000188, OrderId = null, ShoeSizes = (ShoeSize)130, Brand = "Hi-Tec Altitude brown", Notes = "NEW 18.05.17 | put in stock 18.05.17 | toes scuffed" },
new Stock { ItemId = 1, StockNumber = "13C", StockId = 1000189, OrderId = null, ShoeSizes = (ShoeSize)130, Brand = "Hi-Tec Altitude brown", Notes = "NEW 21.05.17 | put in stock 09.06.17" },
new Stock { ItemId = 1, StockNumber = "13D", StockId = 1000190, OrderId = null, ShoeSizes = (ShoeSize)130, Brand = "Brown", Notes = "03.02.22" },
new Stock { ItemId = 1, StockNumber = "14A", StockId = 1000191, OrderId = null, ShoeSizes = (ShoeSize)140, Brand = "Brown Hi Tec", Notes = "3.09.24" },

//sleeping bag 
new Stock { ItemId = 2, StockId = 200001, StockNumber = "1", Brand = "Macpac", Colour = "Blk/sea grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200002, StockNumber = "2", Brand = "Macpac", Colour = "Blk/sea grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200003, StockNumber = "3", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200004, StockNumber = "4", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200005, StockNumber = "5", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200006, StockNumber = "6", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200007, StockNumber = "7", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200008, StockNumber = "8", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200009, StockNumber = "9", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200010, StockNumber = "10", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200011, StockNumber = "11", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200012, StockNumber = "12", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200013, StockNumber = "13", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200014, StockNumber = "14", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200015, StockNumber = "15", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200016, StockNumber = "16", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200017, StockNumber = "17", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200018, StockNumber = "18", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200019, StockNumber = "19", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200020, StockNumber = "20", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200021, StockNumber = "21", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200022, StockNumber = "22", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200023, StockNumber = "23", Brand = "Macpac", Colour = "Blu/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200024, StockNumber = "24", Brand = "Macpac", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200025, StockNumber = "25", Brand = "Macpac", Colour = "Blk/sea grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200026, StockNumber = "26", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200027, StockNumber = "27", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200028, StockNumber = "28", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200029, StockNumber = "29", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200030, StockNumber = "30", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200031, StockNumber = "31", Brand = "Macpac", Colour = "Purple/Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200032, StockNumber = "32", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200033, StockNumber = "33", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200034, StockNumber = "34", Brand = "Macpac", Colour = "Grey/Back", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200035, StockNumber = "35", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200036, StockNumber = "36", Brand = "Macpac", Colour = "Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200037, StockNumber = "37", Brand = "Macpac", Colour = "Blk/ Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200038, StockNumber = "38", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },


new Stock { ItemId = 2, StockId = 200039, StockNumber = "39", Brand = "Macpac", Colour = "Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },

new Stock { ItemId = 2, StockId = 200040, StockNumber = "40", Brand = "Torpedo", Colour = "Orange/Red/Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3C", OrderId = null },
new Stock { ItemId = 2, StockId = 200041, StockNumber = "41", Brand = "Torpedo", Colour = "Orange/Red/Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3C", OrderId = null },
new Stock { ItemId = 2, StockId = 200042, StockNumber = "42", Brand = "Torpedo", Colour = "Orange/Red/Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3C", OrderId = null },
new Stock { ItemId = 2, StockId = 200043, StockNumber = "43", Brand = "Torpedo", Colour = "Orange/Red/Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3C", OrderId = null },
new Stock { ItemId = 2, StockId = 200044, StockNumber = "44", Brand = "Torpedo", Colour = "Orange/Red/Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3", OrderId = null },
new Stock { ItemId = 2, StockId = 200045, StockNumber = "44A", Brand = "Torpedo", Colour = "Orange/Red/Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3C", OrderId = null },
new Stock { ItemId = 2, StockId = 200046, StockNumber = "45", Brand = "Torpedo", Colour = "Orange/Red/Black", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3C", OrderId = null },
new Stock { ItemId = 2, StockId = 200047, StockNumber = "46", Brand = "Macpac", Colour = "Purple", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-10", OrderId = null },


new Stock { ItemId = 2, StockId = 200048, StockNumber = "47", Brand = "Macpac", Colour = "Blk/Sea Grn", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Temp:-3C", OrderId = null },

//jumper
new Stock { ItemId = 3, StockId = 300002, StockNumber = "1", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300003, StockNumber = "2", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300004, StockNumber = "3", Brand = "", Colour = "Navy/Green", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300006, StockNumber = "5", Brand = "", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300007, StockNumber = "6", Brand = "", Colour = "Navy/Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300008, StockNumber = "7", Brand = "", Colour = "green army", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300009, StockNumber = "8", Brand = "", Colour = "Brown", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300010, StockNumber = "9", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300011, StockNumber = "10", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300012, StockNumber = "11", Brand = "", Colour = "navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300013, StockNumber = "12", Brand = "", Colour = "green/black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300014, StockNumber = "13", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300015, StockNumber = "14", Brand = "", Colour = "brown dark", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 3, StockId = 300016, StockNumber = "15", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 3, StockId = 300017, StockNumber = "16", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300018, StockNumber = "17", Brand = "", Colour = "Mottled", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300019, StockNumber = "19", Brand = "", Colour = "Grey, donated", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300020, StockNumber = "20", Brand = "", Colour = "white", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300021, StockNumber = "21", Brand = "", Colour = "rust", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300022, StockNumber = "22", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300023, StockNumber = "23", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300024, StockNumber = "24", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300025, StockNumber = "25", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300026, StockNumber = "26", Brand = "", Colour = "burgundy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300027, StockNumber = "27", Brand = "", Colour = "Brown", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300028, StockNumber = "28", Brand = "", Colour = "black/red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300029, StockNumber = "29", Brand = "", Colour = "red", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300031, StockNumber = "31", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300032, StockNumber = "32", Brand = "", Colour = "green", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300033, StockNumber = "33", Brand = "", Colour = "Avcol navy", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300034, StockNumber = "34", Brand = "", Colour = "army", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300035, StockNumber = "36", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300036, StockNumber = "37", Brand = "", Colour = "navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300037, StockNumber = "38", Brand = "", Colour = "Throw away", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300038, StockNumber = "39", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300039, StockNumber = "40", Brand = "", Colour = "maroon, black sq", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300040, StockNumber = "41", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300041, StockNumber = "42", Brand = "", Colour = "mustard", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300042, StockNumber = "43", Brand = "", Colour = "fawn", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300043, StockNumber = "44", Brand = "", Colour = "purple", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300044, StockNumber = "45", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300045, StockNumber = "46", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300046, StockNumber = "47", Brand = "", Colour = "Green donated2024", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300047, StockNumber = "48", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300048, StockNumber = "49", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300049, StockNumber = "50", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300050, StockNumber = "51", Brand = "", Colour = "brown zip", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 3, StockId = 300052, StockNumber = "53", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300053, StockNumber = "54", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300054, StockNumber = "55", Brand = "", Colour = "grey", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 3, StockId = 300055, StockNumber = "56", Brand = "", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300056, StockNumber = "57", Brand = "", Colour = "07.11.22 Green with white flowers.", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300057, StockNumber = "58", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300058, StockNumber = "59", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300059, StockNumber = "60", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300060, StockNumber = "61", Brand = "", Colour = "green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300062, StockNumber = "63", Brand = "", Colour = "pink", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300063, StockNumber = "64", Brand = "", Colour = "purple variagated", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300064, StockNumber = "65", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300065, StockNumber = "66", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300066, StockNumber = "67", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300067, StockNumber = "68", Brand = "", Colour = "grey Ac", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300068, StockNumber = "69", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300069, StockNumber = "70", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300070, StockNumber = "71", Brand = "", Colour = "Creamy grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300071, StockNumber = "72", Brand = "", Colour = "Avcol navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300073, StockNumber = "74", Brand = "", Colour = "grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300074, StockNumber = "75", Brand = "", Colour = "purple", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300075, StockNumber = "77", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300076, StockNumber = "78", Brand = "", Colour = "Cream", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300077, StockNumber = "79", Brand = "", Colour = "green/blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300078, StockNumber = "80", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300079, StockNumber = "81", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300080, StockNumber = "82", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300081, StockNumber = "83", Brand = "", Colour = "Brown/Orange", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300082, StockNumber = "85", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300083, StockNumber = "86", Brand = "", Colour = "Charcoal/green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300084, StockNumber = "87", Brand = "", Colour = "natural", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300085, StockNumber = "88", Brand = "", Colour = "charcoal", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300086, StockNumber = "89", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300087, StockNumber = "90", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300088, StockNumber = "91", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300089, StockNumber = "92", Brand = "", Colour = "charcoal", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300090, StockNumber = "93", Brand = "", Colour = "Charcoal", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 3, StockId = 300092, StockNumber = "95", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300093, StockNumber = "96", Brand = "", Colour = "Brown", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300094, StockNumber = "97", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300095, StockNumber = "99", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300096, StockNumber = "100", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300097, StockNumber = "101", Brand = "", Colour = "Navy/Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300098, StockNumber = "102", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300099, StockNumber = "103", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300102, StockNumber = "106", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300103, StockNumber = "107", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },


new Stock { ItemId = 3, StockId = 300105, StockNumber = "108", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300106, StockNumber = "109", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 3, StockId = 300107, StockNumber = "111", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300108, StockNumber = "112", Brand = "", Colour = "tan", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300109, StockNumber = "113", Brand = "", Colour = "Pink", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300110, StockNumber = "114", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300111, StockNumber = "115", Brand = "", Colour = "white", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300112, StockNumber = "116", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300113, StockNumber = "117", Brand = "", Colour = "charcoal - NEW 2019", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300114, StockNumber = "118", Brand = "", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300116, StockNumber = "119", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300117, StockNumber = "120", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300119, StockNumber = "122", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300120, StockNumber = "123", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300121, StockNumber = "124", Brand = "", Colour = "red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300122, StockNumber = "125", Brand = "", Colour = "green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300123, StockNumber = "101", Brand = "", Colour = "Navy/Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300124, StockNumber = "102", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300125, StockNumber = "103", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300128, StockNumber = "106", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300129, StockNumber = "107", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },


new Stock { ItemId = 3, StockId = 300131, StockNumber = "108", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300132, StockNumber = "109", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 3, StockId = 300133, StockNumber = "111", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300134, StockNumber = "112", Brand = "", Colour = "tan", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300135, StockNumber = "113", Brand = "", Colour = "Pink", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300136, StockNumber = "114", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300137, StockNumber = "115", Brand = "", Colour = "white", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300138, StockNumber = "116", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300139, StockNumber = "117", Brand = "", Colour = "charcoal ", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300140, StockNumber = "118", Brand = "", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300142, StockNumber = "119", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300143, StockNumber = "120", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300145, StockNumber = "122", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300146, StockNumber = "123", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300147, StockNumber = "124", Brand = "", Colour = "red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300148, StockNumber = "125", Brand = "", Colour = "green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300149, StockNumber = "101", Brand = "", Colour = "Navy/Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300150, StockNumber = "102", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300151, StockNumber = "103", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300154, StockNumber = "106", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300155, StockNumber = "107", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },


new Stock { ItemId = 3, StockId = 300157, StockNumber = "108", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300158, StockNumber = "109", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 3, StockId = 300159, StockNumber = "111", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300160, StockNumber = "112", Brand = "", Colour = "tan", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300161, StockNumber = "113", Brand = "", Colour = "Pink", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300162, StockNumber = "114", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300163, StockNumber = "115", Brand = "", Colour = "white", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300164, StockNumber = "116", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300165, StockNumber = "117", Brand = "", Colour = "charcoal", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300166, StockNumber = "118", Brand = "", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300168, StockNumber = "119", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300169, StockNumber = "120", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300171, StockNumber = "122", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 3, StockId = 300172, StockNumber = "123", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300173, StockNumber = "124", Brand = "", Colour = "red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300174, StockNumber = "125", Brand = "", Colour = "green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 3, StockId = 300175, StockNumber = "177", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300176, StockNumber = "178", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300177, StockNumber = "179", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300178, StockNumber = "180", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 3, StockId = 300179, StockNumber = "181", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300180, StockNumber = "182", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 3, StockId = 300181, StockNumber = "183", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300182, StockNumber = "188", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XXS, OrderId = null },
new Stock { ItemId = 3, StockId = 300183, StockNumber = "194", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 3, StockId = 300184, StockNumber = "199", Brand = "", Colour = "Lilac", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },


// raincoat
new Stock { ItemId = 4, StockId = 400001, StockNumber = "1", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400002, StockNumber = "2", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400003, StockNumber = "3", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400004, StockNumber = "4", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400005, StockNumber = "5", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400006, StockNumber = "6", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400007, StockNumber = "7", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400008, StockNumber = "8", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400009, StockNumber = "9", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400010, StockNumber = "10", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400011, StockNumber = "11", Colour = "BLK ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400012, StockNumber = "12", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400013, StockNumber = "13", Colour = "BLU/BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400014, StockNumber = "14", Colour = "BLU/BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400015, StockNumber = "15", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "Meg's Demo Bag", OrderId = null },
new Stock { ItemId = 4, StockId = 400016, StockNumber = "16", Colour = "GRN/BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400017, StockNumber = "17", Colour = "GRN/BLK ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400018, StockNumber = "18", Colour = "BLK New ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400019, StockNumber = "19", Colour = "BLU/BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400020, StockNumber = "20", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400021, StockNumber = "21", Colour = "BLK New", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400022, StockNumber = "22", Colour = "GRN/BLK ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400023, StockNumber = "23", Colour = "GRN/BLK ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400024, StockNumber = "24", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400025, StockNumber = "25", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400026, StockNumber = "26", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400027, StockNumber = "27", Colour = "GRN/BLK ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400028, StockNumber = "28", Colour = "BLK",ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400029, StockNumber = "29", Colour = "BLK New ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400030, StockNumber = "30", Colour = "GRN/BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400031, StockNumber = "31", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400032, StockNumber = "32", Colour = "GRN/BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400033, StockNumber = "33", Colour = "Grn/ Blk ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400034, StockNumber = "34", Colour = "GRN/BLK ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400035, StockNumber = "35", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400036, StockNumber = "71", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 9.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400037, StockNumber = "72", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 9.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400038, StockNumber = "73", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 9.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400039, StockNumber = "74", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "NEW 24.11.21", OrderId = null },
new Stock { ItemId = 4, StockId = 400040, StockNumber = "75", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, Notes = "13.06.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400041, StockNumber = "76", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "New 9.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400042, StockNumber = "77", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400043, StockNumber = "78", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400044, StockNumber = "79", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400045, StockNumber = "80", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400046, StockNumber = "81", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400047, StockNumber = "83", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400048, StockNumber = "84", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400049, StockNumber = "85", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400050, StockNumber = "86", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null},
new Stock { ItemId = 4, StockId = 400051, StockNumber = "87", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400052, StockNumber = "88", Colour = "Throw away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400053, StockNumber = "90", Colour = "", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400054, StockNumber = "91", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400055, StockNumber = "92", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400056, StockNumber = "93", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400057, StockNumber = "94", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400058, StockNumber = "95", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400059, StockNumber = "96", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400060, StockNumber = "97", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400061, StockNumber = "98", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400062, StockNumber = "99", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400063, StockNumber = "100", Colour = "GN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400064, StockNumber = "101", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400065, StockNumber = "161", Colour = "Teal ", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400066, StockNumber = "221", Colour = "Teal ", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400067, StockNumber = "251", Colour = "Teal ", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400068, StockNumber = "861", Colour = "", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400069, StockNumber = "36", Colour = "BLU/BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400070, StockNumber = "37", Colour = "BLU/BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400071, StockNumber = "38", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400072, StockNumber = "39", Colour = "RED", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400073, StockNumber = "40", Colour = "Black ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400074, StockNumber = "41", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400075, StockNumber = "42", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400076, StockNumber = "43", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400077, StockNumber = "44", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400078, StockNumber = "45", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400079, StockNumber = "46", Colour = "NAVY/ GREEN - NEW 24.11.21", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400080, StockNumber = "47", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400081, StockNumber = "48", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400082, StockNumber = "49", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400083, StockNumber = "50", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400084, StockNumber = "51", Colour = "NAVY/ GREEN - NEW 04.09.18", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400085, StockNumber = "52", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400086, StockNumber = "53", Colour = "NAVY/ GREEN - NEW 24.11.21", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400087, StockNumber = "54", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 9.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400088, StockNumber = "55", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 06.07.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400089, StockNumber = "56", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 23.06.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400090, StockNumber = "57", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400091, StockNumber = "58", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 9.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400092, StockNumber = "59", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 17.06.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400093, StockNumber = "60", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 21.06.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400094, StockNumber = "61", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 13.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400095, StockNumber = "62", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 17.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400096, StockNumber = "63", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 23.06.22; Not R Trip 5. 2023", OrderId = null },
new Stock { ItemId = 4, StockId = 400097, StockNumber = "64", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 6.7.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400098, StockNumber = "65", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 21.06.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400099, StockNumber = "66", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 9.6.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400100, StockNumber = "67", Colour = "Grn/Blk 12.06.24", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400101, StockNumber = "68", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 16.06.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400102, StockNumber = "69", Colour = "NAVY/ GREEN - NEW 24.11.21", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400103, StockNumber = "70", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "New 23.06.22", OrderId = null },
new Stock { ItemId = 4, StockId = 400104, StockNumber = "102", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400105, StockNumber = "103", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400106, StockNumber = "104", Colour = "Blu/Blk", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400107, StockNumber = "105", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400108, StockNumber = "106", Colour = "NAVY/ GREEN - NEW 24.11.21", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400109, StockNumber = "107", Colour = "NAVY/GREEN - NEW 24.11.21", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400110, StockNumber = "108", Colour = "New 2024", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400111, StockNumber = "109", Colour = "GRN", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400112, StockNumber = "110", Colour = "New 2024", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400113, StockNumber = "111", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400114, StockNumber = "113", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400115, StockNumber = "114", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400116, StockNumber = "115", Colour = "New 2024", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400117, StockNumber = "116", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400118, StockNumber = "117", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400119, StockNumber = "118", Colour = "GRN", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400120, StockNumber = "119", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400121, StockNumber = "120", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400122, StockNumber = "121", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400123, StockNumber = "122", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400124, StockNumber = "123", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400125, StockNumber = "124", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400126, StockNumber = "125", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400127, StockNumber = "126", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400128, StockNumber = "127", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400129, StockNumber = "128", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400130, StockNumber = "129", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400131, StockNumber = "130", Colour = "RED", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400132, StockNumber = "131", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400133, StockNumber = "132", Colour = "GRN", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400134, StockNumber = "151", Colour = "RED", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400135, StockNumber = "110", Colour = "Orange", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400136, StockNumber = "111", Colour = "Orange", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 4, StockId = 400137, StockNumber = "112", Colour = "Orange", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },

//bush shirt
new Stock { ItemId = 5, StockId = 500001, StockNumber = "1", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500002, StockNumber = "3", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500003, StockNumber = "4", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500004, StockNumber = "5", Colour = "Brown/White", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 5, StockId = 500005, StockNumber = "6", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500006, StockNumber = "8", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500007, StockNumber = "9", Colour = "Blue/Black ", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500008, StockNumber = "10", Colour = "Green/black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500009, StockNumber = "11", Colour = "Blue/Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500010, StockNumber = "12", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500011, StockNumber = "13", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500012, StockNumber = "14", Colour = "Green/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500013, StockNumber = "15", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500014, StockNumber = "17", Colour = "Green ", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500015, StockNumber = "18", Colour = "Brown ", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500016, StockNumber = "19", Colour = "Black/Grey", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500017, StockNumber = "20", Colour = "Black/Grey ", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500018, StockNumber = "22", Colour = "Green/Red/Yellow", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500019, StockNumber = "23", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500020, StockNumber = "24", Colour = "Mauve/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500021, StockNumber = "25", Colour = "brown ", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500022, StockNumber = "26", Colour = "Pink/Yellow", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500023, StockNumber = "27", Colour = "Pink/Yellow/green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500024, StockNumber = "29", Colour = "Brown/White L) arm back stain", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 5, StockId = 500025, StockNumber = "30", Colour = "Blue/Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500026, StockNumber = "61", Colour = "Red/Yellow", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500027, StockNumber = "62", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500028, StockNumber = "63", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500029, StockNumber = "64", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500030, StockNumber = "65", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500031, StockNumber = "66", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500032, StockNumber = "67", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500033, StockNumber = "68", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500034, StockNumber = "69", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500035, StockNumber = "70", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500036, StockNumber = "71", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500037, StockNumber = "72", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 5, StockId = 500038, StockNumber = "73", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 5, StockId = 500039, StockNumber = "76", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500040, StockNumber = "77", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 5, StockId = 500041, StockNumber = "78", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 5, StockId = 500042, StockNumber = "79", Colour = "green/brown", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500043, StockNumber = "80", Colour = "Brown/White", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 5, StockId = 500044, StockNumber = "81", Colour = "Grey/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500045, StockNumber = "82", Colour = "Blue/Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500046, StockNumber = "83", Colour = "Green/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500047, StockNumber = "85", Colour = "Blue/Brown", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500048, StockNumber = "86", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 5, StockId = 500049, StockNumber = "137", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500050, StockNumber = "142", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500051, StockNumber = "31", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500052, StockNumber = "32", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500053, StockNumber = "33", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 5, StockId = 500054, StockNumber = "34", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500055, StockNumber = "35", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500056, StockNumber = "36", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 5, StockId = 500057, StockNumber = "37", Colour = "Grey/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500058, StockNumber = "38", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500059, StockNumber = "39", Colour = "Blue/Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500060, StockNumber = "40", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500061, StockNumber = "41", Colour = "Black/White", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 5, StockId = 500062, StockNumber = "42", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500063, StockNumber = "43", Colour = "Blue ", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500064, StockNumber = "45", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500065, StockNumber = "47", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500066, StockNumber = "48", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500067, StockNumber = "49", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500068, StockNumber = "50", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500069, StockNumber = "51", Colour = "Blue ", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500070, StockNumber = "52", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500071, StockNumber = "53", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500072, StockNumber = "54", Colour = "Black/Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500073, StockNumber = "55", Colour = "Blue/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500074, StockNumber = "56", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500075, StockNumber = "57", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 5, StockId = 500076, StockNumber = "58", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 5, StockId = 500077, StockNumber = "59", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 5, StockId = 500078, StockNumber = "60", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },


//long jhons polly pro 
                        new Stock { ItemId = 6, StockId = 600002, StockNumber = "1", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600003, StockNumber = "2", Colour = "Purple", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600004, StockNumber = "3", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600005, StockNumber = "4", Colour = "Black - NEW 05.02.20", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600006, StockNumber = "5", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600007, StockNumber = "6", Colour = "Emerald", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600008, StockNumber = "7", Colour = "Mix Colour", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600009, StockNumber = "8", Colour = "Blue ", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600010, StockNumber = "9", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600011, StockNumber = "10", Colour = "Blue 2", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600012, StockNumber = "11", Colour = "Blue/White", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600013, StockNumber = "12", Colour = "Purple/Blk", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600014, StockNumber = "13", Colour = "Teal", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600015, StockNumber = "14", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600016, StockNumber = "15", Colour = "Striped", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600017, StockNumber = "16", Colour = "Blue/black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600018, StockNumber = "17", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600019, StockNumber = "18", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600020, StockNumber = "19", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600021, StockNumber = "20", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600022, StockNumber = "21", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600023, StockNumber = "22", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600024, StockNumber = "23", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600025, StockNumber = "25", Colour = "Purple/Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600026, StockNumber = "26", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600027, StockNumber = "27", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600028, StockNumber = "28", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600029, StockNumber = "29", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600030, StockNumber = "151", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600031, StockNumber = "152", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600032, StockNumber = "159", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 6, StockId = 600033, StockNumber = "197", Colour = "Blue ", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600034, StockNumber = "198", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600035, StockNumber = "199", Colour = "Black ", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600036, StockNumber = "200", Colour = "Black ", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600037, StockNumber = "258", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600038, StockNumber = "30", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600039, StockNumber = "31", Colour = "Teal/Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600040, StockNumber = "32", Colour = "Maroon/ Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600041, StockNumber = "33", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600042, StockNumber = "34", Colour = "White", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600043, StockNumber = "35", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600044, StockNumber = "36", Colour = "Blue/Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600045, StockNumber = "37", Colour = "White", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 6, StockId = 600046, StockNumber = "38", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600047, StockNumber = "39", Colour = "Black Altica", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 6, StockId = 600048, StockNumber = "40", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600049, StockNumber = "41", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600050, StockNumber = "42", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600051, StockNumber = "43", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600052, StockNumber = "44", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600053, StockNumber = "45", Colour = "White", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600054, StockNumber = "46", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 6, StockId = 600055, StockNumber = "47", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600056, StockNumber = "48", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600057, StockNumber = "49", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600058, StockNumber = "50", Colour = "Grey stripes", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600059, StockNumber = "51", Colour = "Pink", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600060, StockNumber = "52", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600061, StockNumber = "53", Colour = "Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600062, StockNumber = "54", Colour = "Nvy/ Blu/ Wht striped", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600063, StockNumber = "55", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600064, StockNumber = "56", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600065, StockNumber = "57", Colour = "Purple", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600066, StockNumber = "58", Colour = "Striped", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 6, StockId = 600067, StockNumber = "59", Colour = "Black - NEW 20.03.20", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 6, StockId = 600068, StockNumber = "60", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 6, StockId = 600069, StockNumber = "61", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 6, StockId = 600070, StockNumber = "62", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600071, StockNumber = "63", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600072, StockNumber = "64", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600073, StockNumber = "65", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600074, StockNumber = "88", Colour = "Striped", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 6, StockId = 600075, StockNumber = "89", Colour = "Striped", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
//long jhons wool
new Stock { ItemId = 7, StockId = 700002, StockNumber = "1", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700003, StockNumber = "2", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700004, StockNumber = "3", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700005, StockNumber = "4", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700006, StockNumber = "5", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700007, StockNumber = "6", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700008, StockNumber = "7", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700009, StockNumber = "8", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700010, StockNumber = "9", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700011, StockNumber = "10", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700012, StockNumber = "11", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700013, StockNumber = "12", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700014, StockNumber = "13", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700015, StockNumber = "14", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700016, StockNumber = "15", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700017, StockNumber = "16", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700018, StockNumber = "17", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700019, StockNumber = "18", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700020, StockNumber = "19", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700021, StockNumber = "20", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700022, StockNumber = "21", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700023, StockNumber = "22", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700024, StockNumber = "23", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700025, StockNumber = "24", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700026, StockNumber = "25", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700027, StockNumber = "26", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700028, StockNumber = "27", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700029, StockNumber = "28", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700030, StockNumber = "29", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700031, StockNumber = "30", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700032, StockNumber = "31", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700033, StockNumber = "32", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700034, StockNumber = "33", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700035, StockNumber = "34", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700036, StockNumber = "35", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700037, StockNumber = "36", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700038, StockNumber = "37", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700039, StockNumber = "38", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700040, StockNumber = "39", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700041, StockNumber = "40", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700042, StockNumber = "41", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700043, StockNumber = "42", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700044, StockNumber = "43", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700045, StockNumber = "44", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700046, StockNumber = "45", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700047, StockNumber = "46", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700048, StockNumber = "47", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700049, StockNumber = "48", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700050, StockNumber = "49", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700051, StockNumber = "50", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 7, StockId = 700052, StockNumber = "51", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700053, StockNumber = "52", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700054, StockNumber = "53", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700055, StockNumber = "54", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700056, StockNumber = "55", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700057, StockNumber = "56", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700058, StockNumber = "57", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700059, StockNumber = "58", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700060, StockNumber = "59", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700061, StockNumber = "60", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700062, StockNumber = "61", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700063, StockNumber = "62", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700064, StockNumber = "63", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700065, StockNumber = "64", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700066, StockNumber = "65", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700067, StockNumber = "67", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700068, StockNumber = "68", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700069, StockNumber = "69", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700070, StockNumber = "70", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700071, StockNumber = "71", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700072, StockNumber = "72", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700073, StockNumber = "73", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700074, StockNumber = "74", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700075, StockNumber = "75", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700076, StockNumber = "76", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700077, StockNumber = "77", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700078, StockNumber = "78", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700079, StockNumber = "79", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700080, StockNumber = "80", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700081, StockNumber = "81", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700082, StockNumber = "82", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700083, StockNumber = "83", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700084, StockNumber = "84", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700085, StockNumber = "85", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700086, StockNumber = "86", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700087, StockNumber = "87", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700088, StockNumber = "88", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700089, StockNumber = "89", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700090, StockNumber = "90", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700091, StockNumber = "91", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 7, StockId = 700092, StockNumber = "92", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700093, StockNumber = "93", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700094, StockNumber = "94", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700095, StockNumber = "95", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700096, StockNumber = "96", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700097, StockNumber = "97", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700099, StockNumber = "99", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700100, StockNumber = "100", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700101, StockNumber = "101", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700102, StockNumber = "102", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700103, StockNumber = "103", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700104, StockNumber = "104", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700105, StockNumber = "105", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700106, StockNumber = "106", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700107, StockNumber = "107", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700108, StockNumber = "108", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700109, StockNumber = "109", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700110, StockNumber = "110", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700111, StockNumber = "111", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700112, StockNumber = "112", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700113, StockNumber = "113", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700114, StockNumber = "114", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700115, StockNumber = "115", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700116, StockNumber = "116", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700117, StockNumber = "117", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700118, StockNumber = "118", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700119, StockNumber = "119", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700120, StockNumber = "120", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700121, StockNumber = "121", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700122, StockNumber = "122", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700123, StockNumber = "123", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700124, StockNumber = "124", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700125, StockNumber = "125", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700126, StockNumber = "126", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700127, StockNumber = "127", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700128, StockNumber = "128", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700129, StockNumber = "129", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700130, StockNumber = "130", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 7, StockId = 700131, StockNumber = "131", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700132, StockNumber = "132", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700133, StockNumber = "133", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700134, StockNumber = "134", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700135, StockNumber = "135", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700136, StockNumber = "136", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700137, StockNumber = "137", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700138, StockNumber = "138", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700139, StockNumber = "139", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700140, StockNumber = "140", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700141, StockNumber = "141", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700142, StockNumber = "142", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700143, StockNumber = "143", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700144, StockNumber = "144", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700145, StockNumber = "145", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700146, StockNumber = "146", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700147, StockNumber = "147", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700148, StockNumber = "148", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700149, StockNumber = "149", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700150, StockNumber = "150", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700151, StockNumber = "151", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700152, StockNumber = "152", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700153, StockNumber = "153", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700154, StockNumber = "154", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700155, StockNumber = "155", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700156, StockNumber = "156", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700157, StockNumber = "157", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700158, StockNumber = "158", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700159, StockNumber = "159", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700160, StockNumber = "160", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700161, StockNumber = "161", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700162, StockNumber = "162", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700163, StockNumber = "163", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700164, StockNumber = "164", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700165, StockNumber = "165", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700166, StockNumber = "166", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700167, StockNumber = "167", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 7, StockId = 700168, StockNumber = "168", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },

new Stock { ItemId = 7, StockId = 700171, StockNumber = "171", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700172, StockNumber = "172", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700173, StockNumber = "173", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700174, StockNumber = "174", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700175, StockNumber = "175", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700176, StockNumber = "176", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700177, StockNumber = "177", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700178, StockNumber = "178", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700179, StockNumber = "179", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700180, StockNumber = "180", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700181, StockNumber = "181", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700182, StockNumber = "182", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700183, StockNumber = "183", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700184, StockNumber = "184", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700185, StockNumber = "185", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700186, StockNumber = "186", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700187, StockNumber = "187", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700188, StockNumber = "188", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700189, StockNumber = "189", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700190, StockNumber = "190", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700191, StockNumber = "191", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700192, StockNumber = "192", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 7, StockId = 700193, StockNumber = "193", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700194, StockNumber = "194", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700195, StockNumber = "195", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700196, StockNumber = "196", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700197, StockNumber = "197", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700198, StockNumber = "198", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700199, StockNumber = "199", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700200, StockNumber = "200", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700201, StockNumber = "201", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700202, StockNumber = "202", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700203, StockNumber = "203", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700204, StockNumber = "204", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700205, StockNumber = "205", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700206, StockNumber = "206", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700207, StockNumber = "207", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700208, StockNumber = "208", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700209, StockNumber = "209", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700210, StockNumber = "210", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700211, StockNumber = "211", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700212, StockNumber = "212", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700213, StockNumber = "213", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700214, StockNumber = "214", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700215, StockNumber = "215", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700216, StockNumber = "216", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700217, StockNumber = "217", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700218, StockNumber = "218", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700219, StockNumber = "219", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700220, StockNumber = "220", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700221, StockNumber = "221", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700222, StockNumber = "228", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 7, StockId = 700223, StockNumber = "238", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700224, StockNumber = "239", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700225, StockNumber = "240", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700226, StockNumber = "241", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700227, StockNumber = "246", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 7, StockId = 700228, StockNumber = "251", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700229, StockNumber = "258", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700230, StockNumber = "261", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 7, StockId = 700231, StockNumber = "266", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700232, StockNumber = "267", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 7, StockId = 700233, StockNumber = "287", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 7, StockId = 700234, StockNumber = "387", ClothingSizes = Stock.ClothingSize.L, OrderId = null },



//day pack

new Stock { ItemId = 8, StockId =8000001, StockNumber = "3", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "5", Brand = "Kathmandu ", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "7", Brand = "Kathmandu ", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "8", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "10", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "11", Brand = "Great Outdoors ", Colour ="Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "15", Brand = "Kjathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "16", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "17", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "18", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "19", Brand = "Kathmandu ", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "21", Brand = "", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "22", Brand = "", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "23", Brand = "", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "24", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "25", Brand = "Great Outdoors ", Colour ="Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "26", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "29", Brand = "Great Outdoors ", Colour ="Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "30", Brand = "", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "32", Brand = "Kathmandu", Colour ="Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "33", Brand = "Great Outdoors ", Colour ="Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

new Stock { ItemId = 8, StockId =8000001, StockNumber = "36", Brand = "Great Outdoors ", Colour ="Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },

//shorts

new Stock { ItemId = 9, StockId = 900001, StockNumber = "2", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900002, StockNumber = "4", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900003, StockNumber = "6", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900004, StockNumber = "7", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900005, StockNumber = "8", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900006, StockNumber = "9", Colour = "Red", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900007, StockNumber = "10", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900008, StockNumber = "11", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900009, StockNumber = "12", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900010, StockNumber = "13", Colour = "Stripes", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900011, StockNumber = "14", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900012, StockNumber = "16", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900013, StockNumber = "17", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900014, StockNumber = "18", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900015, StockNumber = "20", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },

new Stock { ItemId = 9, StockId = 900016, StockNumber = "21", Colour = "Cream", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },

new Stock { ItemId = 9, StockId = 900017, StockNumber = "22", Colour = "Black/White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900018, StockNumber = "24", Colour = "Black/white", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },

new Stock { ItemId = 9, StockId = 900019, StockNumber = "25", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900020, StockNumber = "26", Colour = "Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900021, StockNumber = "27", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900022, StockNumber = "28", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900023, StockNumber = "29", Colour = "Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900024, StockNumber = "30", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900025, StockNumber = "31", Colour = "Grey", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900026, StockNumber = "32", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900027, StockNumber = "33", Colour = "Blue/Black/White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900028, StockNumber = "34", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900029, StockNumber = "35", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900030, StockNumber = "36", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900031, StockNumber = "37", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900032, StockNumber = "38", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900033, StockNumber = "39", Colour = "Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900034, StockNumber = "40", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900035, StockNumber = "41", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900036, StockNumber = "42", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900037, StockNumber = "43", Colour = "Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900038, StockNumber = "44", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900039, StockNumber = "45", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900040, StockNumber = "46", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900041, StockNumber = "47", Colour = "Grey", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900042, StockNumber = "48", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900043, StockNumber = "49", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900044, StockNumber = "50", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900045, StockNumber = "51", Colour = "Pink Hawaii", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900046, StockNumber = "52", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900047, StockNumber = "53", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900048, StockNumber = "54", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900049, StockNumber = "55", Colour = "Red", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900050, StockNumber = "56", Colour = "Green/Yellow", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900051, StockNumber = "57", Colour = "Grey/Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900052, StockNumber = "58", Colour = "Blue/Stingrays", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900053, StockNumber = "59", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900054, StockNumber = "60", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900055, StockNumber = "61", Colour = "Grey", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900056, StockNumber = "62", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900057, StockNumber = "63", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900058, StockNumber = "64", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900059, StockNumber = "65", Colour = "Pink", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900060, StockNumber = "66", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900061, StockNumber = "67", Colour = "Black/ Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900062, StockNumber = "68", Colour = "Grey/Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900063, StockNumber = "69", Colour = "Grey", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900064, StockNumber = "70", Colour = "Turquoise", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900065, StockNumber = "71", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900066, StockNumber = "72", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900067, StockNumber = "73", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900068, StockNumber = "74", Colour = "Black/White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900069, StockNumber = "75", Colour = "Blue Checker", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900070, StockNumber = "76", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900071, StockNumber = "77", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900072, StockNumber = "78", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900073, StockNumber = "79", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },

new Stock { ItemId = 9, StockId = 900074, StockNumber = "80", Colour = "Black/Orange", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900075, StockNumber = "81", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900076, StockNumber = "82", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900077, StockNumber = "83", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900078, StockNumber = "84", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900079, StockNumber = "85", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900080, StockNumber = "86", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },

new Stock { ItemId = 9, StockId = 900081, StockNumber = "87", Colour = "Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900082, StockNumber = "88", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900083, StockNumber = "89", Colour = "Green", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900084, StockNumber = "90", Colour = "Purple", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900085, StockNumber = "91", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900086, StockNumber = "92", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900087, StockNumber = "93", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900088, StockNumber = "94", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900089, StockNumber = "95", Colour = "Org/Blk", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900090, StockNumber = "96", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900091, StockNumber = "97", Colour = "Yellow", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900092, StockNumber = "98", Colour = "Black/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900093, StockNumber = "99", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900094, StockNumber = "100", Colour = "Black/Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900095, StockNumber = "127", Colour = "Black/Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900096, StockNumber = "129", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },

new Stock { ItemId = 9, StockId = 900097, StockNumber = "152", Colour = "Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900098, StockNumber = "153", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900099, StockNumber = "132", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900100, StockNumber = "130", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900101, StockNumber = "131", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900102, StockNumber = "134", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900103, StockNumber = "133", Colour = "Blue/White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 9, StockId = 900104, StockNumber = "135", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },

new Stock { ItemId = 9, StockId = 900105, StockNumber = "136", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 9, StockId = 900106, StockNumber = "137", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },

new Stock { ItemId = 9, StockId = 900107, StockNumber = "146A", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 9, StockId = 900108, StockNumber = "146B", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

//track pants 


new Stock { ItemId = 10, StockId = 1000001, StockNumber = "1", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000002, StockNumber = "2", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },



new Stock { ItemId = 10, StockId = 1000003, StockNumber = "3", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },



new Stock { ItemId = 10, StockId = 1000004, StockNumber = "4", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },



new Stock { ItemId = 10, StockId = 1000005, StockNumber = "6", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },



new Stock { ItemId = 10, StockId = 1000006, StockNumber = "9", Colour = "Cream", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000007, StockNumber = "10", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000008, StockNumber = "12", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000009, StockNumber = "13", Colour = "Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },



new Stock { ItemId = 10, StockId = 1000010, StockNumber = "14", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000011, StockNumber = "15", Colour = "Mar", ClothingSizes = Stock.ClothingSize.L, OrderId = null },



new Stock { ItemId = 10, StockId = 1000012, StockNumber = "16", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },



new Stock { ItemId = 10, StockId = 1000013, StockNumber = "18", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },



new Stock { ItemId = 10, StockId = 1000014, StockNumber = "19", Colour = "Grey", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000015, StockNumber = "20", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },

new Stock { ItemId = 10, StockId = 1000016, StockNumber = "21", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 10, StockId = 1000017, StockNumber = "22", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 10, StockId = 1000018, StockNumber = "23", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 10, StockId = 1000019, StockNumber = "24", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000020, StockNumber = "26", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 10, StockId = 1000021, StockNumber = "27", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 10, StockId = 1000022, StockNumber = "30", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },



new Stock { ItemId = 10, StockId = 1000023, StockNumber = "31", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },



new Stock { ItemId = 10, StockId = 1000024, StockNumber = "32", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000025, StockNumber = "33", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000026, StockNumber = "34", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },

new Stock { ItemId = 10, StockId = 1000027, StockNumber = "35", Colour = "  Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },

new Stock { ItemId = 10, StockId = 1000028, StockNumber = "36", Colour = " Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000029, StockNumber = "37", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 10, StockId = 1000030, StockNumber = "38", Colour = " Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 10, StockId = 1000031, StockNumber = "39", Colour = "  Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 10, StockId = 1000032, StockNumber = "40", Colour = "Brown", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 10, StockId = 1000033, StockNumber = "41", Colour = " Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },

new Stock { ItemId = 10, StockId = 1000034, StockNumber = "42", Colour = " Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 10, StockId = 1000035, StockNumber = "43", Colour = "Brown", ClothingSizes = Stock.ClothingSize.S, OrderId = null },

new Stock { ItemId = 10, StockId = 1000036, StockNumber = "44", Colour = "Grey", ClothingSizes = Stock.ClothingSize.S, OrderId = null },



new Stock { ItemId = 10, StockId = 1000037, StockNumber = "46", Colour = " Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },


//vest polypro long selvle spoly pro
                        new Stock { ItemId = 11, StockId = 1100001, StockNumber = "1", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100002, StockNumber = "2", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100003, StockNumber = "3", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100004, StockNumber = "4", Colour = "Cream", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100005, StockNumber = "5", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100006, StockNumber = "6", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100007, StockNumber = "7", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100008, StockNumber = "8", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100009, StockNumber = "9", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100010, StockNumber = "10", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100011, StockNumber = "11", Colour = "Blu/Blk stripe", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100012, StockNumber = "12", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100013, StockNumber = "13", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100014, StockNumber = "14", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100015, StockNumber = "15", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100016, StockNumber = "16", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100017, StockNumber = "17", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100018, StockNumber = "18", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100019, StockNumber = "19", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100020, StockNumber = "20", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100021, StockNumber = "21", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100022, StockNumber = "22", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100023, StockNumber = "23", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100024, StockNumber = "24", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100025, StockNumber = "25", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100026, StockNumber = "26", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100027, StockNumber = "27", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100028, StockNumber = "28", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100029, StockNumber = "29", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100030, StockNumber = "30", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100031, StockNumber = "31", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100032, StockNumber = "32", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100033, StockNumber = "33", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100034, StockNumber = "34", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100035, StockNumber = "35", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100036, StockNumber = "36", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100037, StockNumber = "37", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100038, StockNumber = "38", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100039, StockNumber = "40", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100040, StockNumber = "41", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100041, StockNumber = "42", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100042, StockNumber = "43", Colour = "Striped Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100043, StockNumber = "44", Colour = "Rainbow", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100044, StockNumber = "45", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100045, StockNumber = "46", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100046, StockNumber = "47", Colour = "Striped Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100047, StockNumber = "48", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100048, StockNumber = "49", Colour = "Striped Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100049, StockNumber = "50", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100050, StockNumber = "51", Colour = "Striped Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100051, StockNumber = "52", Colour = "Striped Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100052, StockNumber = "53", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100053, StockNumber = "54", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100054, StockNumber = "55", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100055, StockNumber = "56", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100056, StockNumber = "57", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100057, StockNumber = "58", Colour = "Striped Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100058, StockNumber = "59", Colour = "Striped Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100059, StockNumber = "61", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100060, StockNumber = "62", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100061, StockNumber = "63", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100062, StockNumber = "65", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100063, StockNumber = "67", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100064, StockNumber = "68", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100065, StockNumber = "69", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100066, StockNumber = "71", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100067, StockNumber = "72", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100068, StockNumber = "73", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100069, StockNumber = "76", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100070, StockNumber = "77", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100071, StockNumber = "80", Colour = "Pink", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100072, StockNumber = "81", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100073, StockNumber = "82", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100074, StockNumber = "85", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100075, StockNumber = "86", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100076, StockNumber = "87", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100077, StockNumber = "89", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100078, StockNumber = "90", Colour = "Blue Striped", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100080, StockNumber = "92", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100081, StockNumber = "93", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100082, StockNumber = "94", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100083, StockNumber = "95", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100084, StockNumber = "96", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100085, StockNumber = "98", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100086, StockNumber = "99", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100087, StockNumber = "100", Colour = "Light Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100088, StockNumber = "101", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100089, StockNumber = "102", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100090, StockNumber = "103", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100091, StockNumber = "104", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100092, StockNumber = "105", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100093, StockNumber = "106", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100094, StockNumber = "107", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100095, StockNumber = "108", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100096, StockNumber = "109", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100097, StockNumber = "110", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100098, StockNumber = "111", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100099, StockNumber = "112", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100100, StockNumber = "113", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100101, StockNumber = "114", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100102, StockNumber = "115", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100103, StockNumber = "116", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100104, StockNumber = "117", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100105, StockNumber = "119", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 11, StockId = 1100106, StockNumber = "121", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100107, StockNumber = "122", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100108, StockNumber = "123", Colour = "Blue/stp", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100109, StockNumber = "124", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100110, StockNumber = "125", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100111, StockNumber = "126", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100112, StockNumber = "127", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100113, StockNumber = "128", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100114, StockNumber = "129", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100115, StockNumber = "130", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100116, StockNumber = "131", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100117, StockNumber = "133", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100118, StockNumber = "134", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100119, StockNumber = "135", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100120, StockNumber = "136", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100121, StockNumber = "139", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100122, StockNumber = "140", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100123, StockNumber = "141", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100124, StockNumber = "143", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100125, StockNumber = "144", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100126, StockNumber = "145", Colour = "Pur/Blk Stripe", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100127, StockNumber = "146", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100128, StockNumber = "147", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100129, StockNumber = "148", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100130, StockNumber = "149", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100131, StockNumber = "150", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100132, StockNumber = "151", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100133, StockNumber = "152", Colour = "Nvy/Org", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100134, StockNumber = "153", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100135, StockNumber = "154", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100136, StockNumber = "155", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100137, StockNumber = "156", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100138, StockNumber = "158", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100139, StockNumber = "160", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100140, StockNumber = "161", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100141, StockNumber = "162", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100142, StockNumber = "163", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100143, StockNumber = "164", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100144, StockNumber = "165", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100145, StockNumber = "166", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100146, StockNumber = "167", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100147, StockNumber = "168", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100148, StockNumber = "169", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100149, StockNumber = "170", Colour = "Throw away", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100150, StockNumber = "171", Colour = "Throw away", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100151, StockNumber = "173", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100152, StockNumber = "174", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100153, StockNumber = "175", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100154, StockNumber = "177", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100155, StockNumber = "178", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100156, StockNumber = "180", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100157, StockNumber = "181", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100158, StockNumber = "182", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100159, StockNumber = "183", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100160, StockNumber = "184", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100161, StockNumber = "186", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100162, StockNumber = "187", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100163, StockNumber = "188", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100164, StockNumber = "189", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100165, StockNumber = "190", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100166, StockNumber = "191", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100167, StockNumber = "192", Colour = "Brick", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100168, StockNumber = "193", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100169, StockNumber = "194", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100170, StockNumber = "195", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100171, StockNumber = "196", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100172, StockNumber = "197", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100173, StockNumber = "198", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100174, StockNumber = "199", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100175, StockNumber = "200", Colour = "Brick", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100176, StockNumber = "201", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100177, StockNumber = "202", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100178, StockNumber = "203", Colour = "BLUE", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100179, StockNumber = "204", Colour = "blue stripe", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100180, StockNumber = "205", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100181, StockNumber = "206", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100182, StockNumber = "207", Colour = "Nvy/Org", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100183, StockNumber = "208", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100184, StockNumber = "209", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100185, StockNumber = "210", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100186, StockNumber = "211", Colour = "Purple/Black Stp", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100187, StockNumber = "212", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100188, StockNumber = "213", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100189, StockNumber = "214", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100190, StockNumber = "215", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100191, StockNumber = "216", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100192, StockNumber = "217", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100193, StockNumber = "218", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100194, StockNumber = "219", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100195, StockNumber = "222", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100196, StockNumber = "223", Colour = "Gry/Nvy/Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 11, StockId = 1100197, StockNumber = "225", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100198, StockNumber = "226", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100199, StockNumber = "227", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100200, StockNumber = "230", Colour = "Blue Stripe", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100201, StockNumber = "231", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100202, StockNumber = "232", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100203, StockNumber = "233", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100204, StockNumber = "234", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100205, StockNumber = "235", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100206, StockNumber = "236", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100207, StockNumber = "238", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100208, StockNumber = "239", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100209, StockNumber = "240", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100210, StockNumber = "242", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100211, StockNumber = "243", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100212, StockNumber = "244", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100213, StockNumber = "245", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100214, StockNumber = "246", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100215, StockNumber = "247", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100216, StockNumber = "248", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100217, StockNumber = "249", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100218, StockNumber = "250", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100219, StockNumber = "251", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100220, StockNumber = "252", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100221, StockNumber = "253", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100222, StockNumber = "254", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100223, StockNumber = "255", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100224, StockNumber = "256", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100225, StockNumber = "257", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100226, StockNumber = "258", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100227, StockNumber = "259", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100228, StockNumber = "260", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100229, StockNumber = "261", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100230, StockNumber = "262", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100231, StockNumber = "263", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100232, StockNumber = "264", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100233, StockNumber = "265", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100234, StockNumber = "266", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100235, StockNumber = "267", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100236, StockNumber = "268", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100237, StockNumber = "269", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100238, StockNumber = "272", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100239, StockNumber = "273", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100240, StockNumber = "275", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100241, StockNumber = "277", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100242, StockNumber = "281", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100243, StockNumber = "285", Colour = "Olive", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100244, StockNumber = "288", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100245, StockNumber = "290", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100246, StockNumber = "291", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100247, StockNumber = "293", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100248, StockNumber = "294", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100249, StockNumber = "295", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100250, StockNumber = "296", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100251, StockNumber = "299", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100252, StockNumber = "301", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100253, StockNumber = "302", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100254, StockNumber = "303", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100255, StockNumber = "304", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100256, StockNumber = "305", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100257, StockNumber = "306", Colour = "Black ", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100258, StockNumber = "307", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100259, StockNumber = "308", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100260, StockNumber = "322", Colour = "Blue Crew", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 11, StockId = 1100261, StockNumber = "324", Colour = "Black Zip", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 11, StockId = 1100262, StockNumber = "325", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100263, StockNumber = "326", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100264, StockNumber = "327", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100265, StockNumber = "328", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100266, StockNumber = "329", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100267, StockNumber = "330", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 11, StockId = 1100268, StockNumber = "331", Colour = "Black", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },


//short poly pro
 new Stock { ItemId = 12, StockId = 1200001, StockNumber = "1", Colour = "", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200002, StockNumber = "4", Colour = "Navy", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200003, StockNumber = "6", Colour = "White", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200004, StockNumber = "7", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200005, StockNumber = "8", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200006, StockNumber = "9", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200007, StockNumber = "10", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200008, StockNumber = "11", Colour = "Blue/White", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200009, StockNumber = "12", Colour = "Purple", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200010, StockNumber = "13", Colour = "Rainbow", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200011, StockNumber = "19", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200012, StockNumber = "20", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200013, StockNumber = "21", Colour = "Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200014, StockNumber = "26", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200015, StockNumber = "27", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200016, StockNumber = "29", Colour = "Red", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200017, StockNumber = "32", Colour = "White", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200018, StockNumber = "35", Colour = "Merino      Green", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200019, StockNumber = "36", Colour = "Merino Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200020, StockNumber = "39", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200021, StockNumber = "40", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200022, StockNumber = "41", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200023, StockNumber = "44", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200024, StockNumber = "46", Colour = "Green/Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200025, StockNumber = "52", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200026, StockNumber = "54", Colour = "Blue/White", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200027, StockNumber = "56", Colour = "Pink", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200028, StockNumber = "57", Colour = "Merino Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200029, StockNumber = "58", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200030, StockNumber = "59", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200031, StockNumber = "60", Colour = "pink - NEW 02.05.20", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200032, StockNumber = "61", Colour = "Black 09.08.22", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200033, StockNumber = "64", Colour = "Blue/Yellow", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200034, StockNumber = "70", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200035, StockNumber = "71", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200036, StockNumber = "82", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },											
new Stock { ItemId = 12, StockId = 1200037, StockNumber = "83", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											                       


// ss wollen
                        new Stock { ItemId = 13, StockId = 1300041, StockNumber = "1", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300042, StockNumber = "4", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300043, StockNumber = "6", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300044, StockNumber = "7", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300045, StockNumber = "8", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300046, StockNumber = "9", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300047, StockNumber = "10", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300048, StockNumber = "11", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300049, StockNumber = "12", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300050, StockNumber = "13", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300051, StockNumber = "19", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300052, StockNumber = "20", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300053, StockNumber = "21", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300054, StockNumber = "26", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300055, StockNumber = "27", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300056, StockNumber = "29", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 13, StockId = 1300057, StockNumber = "32", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 13, StockId = 1300058, StockNumber = "35", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 13, StockId = 1300059, StockNumber = "36", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300060, StockNumber = "39", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 13, StockId = 1300061, StockNumber = "40", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300062, StockNumber = "41", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300063, StockNumber = "44", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300064, StockNumber = "46", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300065, StockNumber = "52", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300066, StockNumber = "54", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 13, StockId = 1300067, StockNumber = "56", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 13, StockId = 1300068, StockNumber = "57", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300069, StockNumber = "58", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300070, StockNumber = "59", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300071, StockNumber = "60", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300072, StockNumber = "61", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300073, StockNumber = "64", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 13, StockId = 1300074, StockNumber = "70", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 13, StockId = 1300075, StockNumber = "71", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 13, StockId = 1300076, StockNumber = "82", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 13, StockId = 1300077, StockNumber = "83", ClothingSizes = Stock.ClothingSize.M, OrderId = null },


                        


//overnight packs
new Stock { ItemId =14, StockId = 1400275, StockNumber = "1", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400276, StockNumber = "2", Brand = "Berg Outdoor", Colour = "Red  ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400277, StockNumber = "3", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400278, StockNumber = "5", Brand = "Berg Outdoor", Colour = "Red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400279, StockNumber = "6", Brand = "Berg Outdoor", Colour = "Green  ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400280, StockNumber = "7", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400281, StockNumber = "8", Brand = "Deuter", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400282, StockNumber = "9", Brand = "Berg Outdoor", Colour = "Red  ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400283, StockNumber = "10", Brand = "Berg Outdoor", Colour = "Grey  ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400284, StockNumber = "11", Brand = "Doyles", Colour = "Turquoise", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400285, StockNumber = "12", Brand = "East Cape", Colour = "Purple  Doyles", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400286, StockNumber = "13", Brand = "Great Outdoor", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400287, StockNumber = "14", Brand = "Great Outdoor", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400288, StockNumber = "15", Brand = "deuter", Colour = "green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400289, StockNumber = "16", Brand = "Kathmandu", Colour = "Red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400290, StockNumber = "17", Brand = "East Cape", Colour = "Purple  Doyles", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400291, StockNumber = "18", Brand = "Berg Outdoor", Colour = "Red  ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400292, StockNumber = "19", Brand = "Great Outdoor", Colour = "Silver  R& R", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400293, StockNumber = "20", Brand = "Rhino", Colour = "Black/Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400294, StockNumber = "21", Brand = "Great Outdoor", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400295, StockNumber = "22", Brand = "Great Outdoor", Colour = "Silver  R & R", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400296, StockNumber = "23", Brand = "Great Outdoor", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400297, StockNumber = "24", Brand = "Mtn Designs", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400298, StockNumber = "25", Brand = "Great Outdoor", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400299, StockNumber = "26", Brand = "Rhino", Colour = "Grey/Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400300, StockNumber = "27", Brand = "Rhino", Colour = "Grey/Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400301, StockNumber = "28", Brand = "Rhino", Colour = "Grey/Purple", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400302, StockNumber = "29", Brand = "detuer", Colour = "green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400303, StockNumber = "30", Brand = "East Cape", Colour = "Purple/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400304, StockNumber = "31", Brand = "Mtn Designs", Colour = "Grey/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400305, StockNumber = "32", Brand = "Berg Outdoor", Colour = "Grey  ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400306, StockNumber = "33", Brand = "Berg Outdoor", Colour = "Green  ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400307, StockNumber = "34", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400308, StockNumber = "35", Brand = "Berg Outdoor", Colour = "Red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400309, StockNumber = "37", Brand = "Eye", Colour = "Black/grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400310, StockNumber = "38", Brand = "Fairydown", Colour = "Green/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400311, StockNumber = "39", Brand = "Deuter", Colour = "Geen", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400312, StockNumber = "40", Brand = "Berg Outdoor", Colour = "Red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400313, StockNumber = "41", Brand = "Great Outdoor", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400314, StockNumber = "42", Brand = "Asivik", Colour = "Blue/Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400315, StockNumber = "43", Brand = "deuter", Colour = "red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400316, StockNumber = "44", Brand = "deuter", Colour = "red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400317, StockNumber = "45", Brand = "deuter", Colour = "red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400318, StockNumber = "46", Brand = "Fairydown", Colour = "Green/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400319, StockNumber = "47", Brand = "deuter", Colour = "red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400320, StockNumber = "48", Brand = "deuter", Colour = "blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400321, StockNumber = "49", Brand = "deuter", Colour = "blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400322, StockNumber = "50", Brand = "Deuter", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400323, StockNumber = "51 - 55", Brand = "", Colour = "Not Allocated", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400324, StockNumber = "56", Brand = "deuter", Colour = "blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400325, StockNumber = "57 - 62", Brand = "", Colour = "Not Allocated", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400326, StockNumber = "63", Brand = "Deuter", Colour = "Red/Blk/Marune", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400327, StockNumber = "64", Brand = "Berg Outdoor", Colour = " Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400328, StockNumber = "65", Brand = "East Cape", Colour = "Purple/Black ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400329, StockNumber = "66", Brand = "Great Outdoor", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400330, StockNumber = "58", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400331, StockNumber = "67", Brand = "Trailmaster", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400332, StockNumber = "68", Brand = "East Cape", Colour = "Purple  Doyles", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400333, StockNumber = "69", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400334, StockNumber = "70", Brand = "East Cape", Colour = "Black  Doyles", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400335, StockNumber = "71", Brand = "Hallmark", Colour = "Purple/Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400336, StockNumber = "72", Brand = "East Cape", Colour = "Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400337, StockNumber = "73", Brand = "Great Outdoors", Colour = "Bue/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400338, StockNumber = "74", Brand = "Fairydown", Colour = "Yellow", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400339, StockNumber = "75", Brand = "Fairydown", Colour = "Yellow", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400340, StockNumber = "76", Brand = "Fairydown", Colour = "Green/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400341, StockNumber = "77", Brand = "East Cape", Colour = "Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400342, StockNumber = "78", Brand = "Fairydown", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400343, StockNumber = "79", Brand = "Fairydown", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400344, StockNumber = "80", Brand = "Fairydown", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400345, StockNumber = "81", Brand = "Fairydown", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400346, StockNumber = "82", Brand = "Fairydown", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400347, StockNumber = "83", Brand = "Fairydown", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400348, StockNumber = "84", Brand = "No make", Colour = "Yellow/Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400349, StockNumber = "85", Brand = "Hallmark", Colour = "Grey/Red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400350, StockNumber = "86", Brand = "Karrimor", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400351, StockNumber = "88", Brand = "First Light", Colour = "Red", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400352, StockNumber = "89", Brand = "Kathmandu", Colour = "Navy/Black", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400353, StockNumber = "90", Brand = "Trailmaster", Colour = "Blue/Teal", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400354, StockNumber = "91", Brand = "Kathmandu", Colour = "Red/Black       ", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400355, StockNumber = "A", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400356, StockNumber = "B", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400357, StockNumber = "C", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400358, StockNumber = "D", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													
new Stock { ItemId =14, StockId = 1400359, StockNumber = "E", Brand = "Mtn Designs", Colour = "Blue", ClothingSizes = Stock.ClothingSize.Standard, OrderId = null },													                        

                        //over trousers
                        new Stock { ItemId = 15, StockId = 1500002, StockNumber = "1", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500003, StockNumber = "2", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500004, StockNumber = "3", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500005, StockNumber = "4", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500006, StockNumber = "5", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500007, StockNumber = "6", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500008, StockNumber = "8", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500009, StockNumber = "9", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500010, StockNumber = "10", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500011, StockNumber = "12", Brand = "", Colour = "Blk", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500012, StockNumber = "13", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500013, StockNumber = "14", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500014, StockNumber = "15", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500015, StockNumber = "16", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500016, StockNumber = "17", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500017, StockNumber = "18", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500018, StockNumber = "19", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500019, StockNumber = "21", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500020, StockNumber = "22", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500021, StockNumber = "24", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500022, StockNumber = "25", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500023, StockNumber = "27", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500024, StockNumber = "28", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500025, StockNumber = "29", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500026, StockNumber = "30", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500027, StockNumber = "61", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500028, StockNumber = "62", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500029, StockNumber = "63", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500030, StockNumber = "64", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500031, StockNumber = "65", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500032, StockNumber = "66", Brand = "", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500033, StockNumber = "67", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500034, StockNumber = "68", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500035, StockNumber = "69", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500036, StockNumber = "70", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500037, StockNumber = "71", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500038, StockNumber = "72", Brand = "", Colour = "Navy  Green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500039, StockNumber = "73", Brand = "", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500040, StockNumber = "74", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500041, StockNumber = "o145", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500042, StockNumber = "77", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500043, StockNumber = "78", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500044, StockNumber = "80", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500045, StockNumber = "81", Brand = "", Colour = "NAVY/ GREEN ", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500046, StockNumber = "82", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500047, StockNumber = "83", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500048, StockNumber = "84", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500049, StockNumber = "o116", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500050, StockNumber = "86", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500051, StockNumber = "87", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500052, StockNumber = "88", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500053, StockNumber = "117", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500054, StockNumber = "119", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500055, StockNumber = "120", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500056, StockNumber = "121", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XXXL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500057, StockNumber = "123", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XXXL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500058, StockNumber = "126", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500059, StockNumber = "127", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500060, StockNumber = "128", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500061, StockNumber = "129", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500062, StockNumber = "131", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500063, StockNumber = "132", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500064, StockNumber = "133", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500065, StockNumber = "134", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500066, StockNumber = "135", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500067, StockNumber = "136", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500068, StockNumber = "31", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500069, StockNumber = "32", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500070, StockNumber = "33", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500071, StockNumber = "34", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500072, StockNumber = "35", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500073, StockNumber = "36", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500074, StockNumber = "37", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500075, StockNumber = "38", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500076, StockNumber = "39", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500077, StockNumber = "40", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500078, StockNumber = "41", Brand = "", Colour = "BLK  ", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500079, StockNumber = "42", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500080, StockNumber = "43", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500081, StockNumber = "44", Brand = "", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500082, StockNumber = "45", Brand = "", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500083, StockNumber = "46", Brand = "", Colour = "BLK ", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500084, StockNumber = "48", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500085, StockNumber = "49", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500086, StockNumber = "50", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500087, StockNumber = "51", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500088, StockNumber = "52", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500089, StockNumber = "53", Brand = "", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500090, StockNumber = "54", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500091, StockNumber = "55", Brand = "", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500092, StockNumber = "56", Brand = "", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500093, StockNumber = "57", Brand = "", Colour = "NAVY/ GREEN", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500094, StockNumber = "58", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500095, StockNumber = "59", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500096, StockNumber = "60", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500097, StockNumber = "o148", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500098, StockNumber = "90", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500099, StockNumber = "91", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500100, StockNumber = "92", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500101, StockNumber = "93", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500102, StockNumber = "94", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500103, StockNumber = "o135", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500104, StockNumber = "96", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500105, StockNumber = "97", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500106, StockNumber = "o147", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500107, StockNumber = "99", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500108, StockNumber = "100", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500109, StockNumber = "o140", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500110, StockNumber = "102", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500111, StockNumber = "103", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500112, StockNumber = "104", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500113, StockNumber = "105", Brand = "", Colour = "BLK", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500114, StockNumber = "106", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500115, StockNumber = "107", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500116, StockNumber = "108", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500117, StockNumber = "109", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500118, StockNumber = "110", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500119, StockNumber = "111", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500120, StockNumber = "112", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500121, StockNumber = "113", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500122, StockNumber = "114", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500123, StockNumber = "115", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500124, StockNumber = "116", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500125, StockNumber = "o45", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500126, StockNumber = "o48", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500127, StockNumber = "o50", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500128, StockNumber = "o51", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500129, StockNumber = "o105", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500130, StockNumber = "o111", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500131, StockNumber = "o114", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500132, StockNumber = "o124", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500133, StockNumber = "o125", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500134, StockNumber = "o133", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500135, StockNumber = "o136", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500136, StockNumber = "o142", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 15, StockId = 1500137, StockNumber = "118", Brand = "", Colour = "NAVY", ClothingSizes = Stock.ClothingSize.XXL, Notes = "", OrderId = null },

                        //Beanies - Polar Fleece
             new Stock { ItemId = 16, StockId = 1600001, StockNumber = "1", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600002, StockNumber = "2", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600003, StockNumber = "3", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600004, StockNumber = "4", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600005, StockNumber = "5", Colour = "Brown", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600006, StockNumber = "7", Colour = "Red", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600007, StockNumber = "8", Colour = "Orange", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600008, StockNumber = "9", Colour = "Orange", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600009, StockNumber = "10", Colour = "Orange", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600010, StockNumber = "11", Colour = "Orange", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600011, StockNumber = "12", Colour = "Orange", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600012, StockNumber = "13", Colour = "Orange", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600013, StockNumber = "14", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600014, StockNumber = "15", Colour = "Pink", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600015, StockNumber = "16", Colour = "Pink", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600016, StockNumber = "17", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600017, StockNumber = "18", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600018, StockNumber = "19", Colour = "White", ClothingSizes = Stock.ClothingSize.S, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600019, StockNumber = "20", Colour = "White", ClothingSizes = Stock.ClothingSize.M, OrderId = null },											
new Stock { ItemId = 16, StockId = 1600020, StockNumber = "21", Colour = "Grey", ClothingSizes = Stock.ClothingSize.L, OrderId = null },											


//polar 
   new Stock { ItemId = 17, StockId = 1700001, StockNumber = "1", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700002, StockNumber = "2", Colour = "Green-WH", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700003, StockNumber = "3", Colour = "Green-WH", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700004, StockNumber = "4", Colour = "Green-WH", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700005, StockNumber = "5", Colour = "Green-WH", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700006, StockNumber = "6", Colour = "Blue-WH", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700007, StockNumber = "7", Colour = "Blue-WH", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700008, StockNumber = "8", Colour = "Blue-WH", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700009, StockNumber = "9", Colour = "Blue-WH", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700010, StockNumber = "10", Colour = "Blue-WH", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700011, StockNumber = "11", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700012, StockNumber = "12", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700013, StockNumber = "13", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700014, StockNumber = "14", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700015, StockNumber = "15", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700016, StockNumber = "16", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700017, StockNumber = "17", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700018, StockNumber = "18", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700019, StockNumber = "19", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XXXXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700020, StockNumber = "20", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700021, StockNumber = "22", Colour = "Yellow", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700022, StockNumber = "23", Colour = "Char-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700023, StockNumber = "24", Colour = "Char-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700024, StockNumber = "25", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700025, StockNumber = "26", Colour = "Olive-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700026, StockNumber = "27", Colour = "Olive-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700027, StockNumber = "28", Colour = "Orange/Blk", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700028, StockNumber = "29", Colour = "Grn/Prpl", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700029, StockNumber = "30", Colour = "Blue/Chocolate 2", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700030, StockNumber = "31", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700031, StockNumber = "63", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700032, StockNumber = "64", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700033, StockNumber = "65", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700034, StockNumber = "66", Colour = "red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700035, StockNumber = "67", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700036, StockNumber = "68", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700037, StockNumber = "69", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700038, StockNumber = "70", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700039, StockNumber = "71", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700040, StockNumber = "72", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700041, StockNumber = "73", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700042, StockNumber = "74", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700043, StockNumber = "77", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700044, StockNumber = "78", Colour = "Black", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700045, StockNumber = "79", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700046, StockNumber = "80", Colour = "BLK/BLU", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700047, StockNumber = "81", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700048, StockNumber = "82", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700049, StockNumber = "84", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700050, StockNumber = "85", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700051, StockNumber = "86", Colour = "Black", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700052, StockNumber = "87", Colour = "Olive Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700053, StockNumber = "89", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700054, StockNumber = "117", Colour = "Grey", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700055, StockNumber = "118", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700056, StockNumber = "119", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700057, StockNumber = "120", Colour = "Grey", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700058, StockNumber = "121", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700059, StockNumber = "123", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700060, StockNumber = "124", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700061, StockNumber = "125", Colour = "Grey", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700062, StockNumber = "126", Colour = "Brown", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700063, StockNumber = "127", Colour = "Navy NEW 22.08.18", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700064, StockNumber = "128", Colour = "Navy NEW 22.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700065, StockNumber = "129", Colour = "Black NEW 22.08.18", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700066, StockNumber = "130", Colour = "Black NEW 22.08.18", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700067, StockNumber = "131", Colour = "Black/Grey", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700068, StockNumber = "132", Colour = "Blue NEW 27.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700069, StockNumber = "133", Colour = "Blue NEW 27.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700070, StockNumber = "134", Colour = "Blue NEW 27.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700071, StockNumber = "135", Colour = "Blue NEW 27.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700072, StockNumber = "136", Colour = "Blue NEW 28.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700073, StockNumber = "137", Colour = "Blue NEW 28.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700074, StockNumber = "138", Colour = "Blue NEW 28.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700075, StockNumber = "139", Colour = "Blue NEW 28.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700076, StockNumber = "140", Colour = "Blue NEW 28.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700077, StockNumber = "141", Colour = "Blue NEW 28.08.18", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700078, StockNumber = "32", Colour = "Olive-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700079, StockNumber = "33", Colour = "Olive-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700080, StockNumber = "35", Colour = "Olive-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700081, StockNumber = "36", Colour = "Olive-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700082, StockNumber = "37", Colour = "Chocolate", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700083, StockNumber = "38", Colour = "Grey-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700084, StockNumber = "39", Colour = "Navy-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700085, StockNumber = "40", Colour = "Tan-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700086, StockNumber = "41", Colour = "White", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700087, StockNumber = "42", Colour = "Plum", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700088, StockNumber = "43", Colour = "Olive-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700089, StockNumber = "44", Colour = "Olive-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700090, StockNumber = "45", Colour = "Navy-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700091, StockNumber = "46", Colour = "Plum-WH", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700092, StockNumber = "47", Colour = "Plum-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700093, StockNumber = "48", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700094, StockNumber = "49", Colour = "Blue-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700095, StockNumber = "50", Colour = "Grey", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700096, StockNumber = "51", Colour = "Yell-WH", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700097, StockNumber = "52", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700098, StockNumber = "53", Colour = "Gn - Dorln", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700099, StockNumber = "54", Colour = "Gn - Dorln", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700100, StockNumber = "55", Colour = "Blue/yellow", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700101, StockNumber = "56", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700102, StockNumber = "57", Colour = "Grn/Blk", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700103, StockNumber = "58", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700104, StockNumber = "59", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700105, StockNumber = "60", Colour = "Blue/red", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700106, StockNumber = "61", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700107, StockNumber = "62", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700108, StockNumber = "90", Colour = "Grey", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700109, StockNumber = "91", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700110, StockNumber = "92", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700111, StockNumber = "93", Colour = "Blue 10.2.22", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700112, StockNumber = "94", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700113, StockNumber = "95", Colour = "Grn/Red/Blu Multi", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700114, StockNumber = "96", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700115, StockNumber = "97", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700116, StockNumber = "98", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700117, StockNumber = "99", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700118, StockNumber = "100", Colour = "Purple", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700119, StockNumber = "101", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700120, StockNumber = "102", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700121, StockNumber = "103", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700122, StockNumber = "104", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700123, StockNumber = "105", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XXL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700124, StockNumber = "106", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700125, StockNumber = "107", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700126, StockNumber = "108", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700127, StockNumber = "109", Colour = "Grn/Nvy", ClothingSizes = Stock.ClothingSize.XL, OrderId = null },
new Stock { ItemId = 17, StockId = 1700128, StockNumber = "110", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700129, StockNumber = "111", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700130, StockNumber = "112", Colour = "Orange", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700131, StockNumber = "113", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700132, StockNumber = "114", Colour = "Navy", ClothingSizes = Stock.ClothingSize.M, OrderId = null },
new Stock { ItemId = 17, StockId = 1700133, StockNumber = "115", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, OrderId = null },
new Stock { ItemId = 17, StockId = 1700134, StockNumber = "116", Colour = "Purple", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700135, StockNumber = "142", Colour = "BLACK", ClothingSizes = Stock.ClothingSize.S, OrderId = null },
new Stock { ItemId = 17, StockId = 1700136, StockNumber = "143", Colour = "GREY", ClothingSizes = Stock.ClothingSize.XS, OrderId = null },
new Stock { ItemId = 17, StockId = 1700137, StockNumber = "144", Colour = "Blue donated2024", ClothingSizes = Stock.ClothingSize.S, OrderId = null }                     




























};

                   
                    context.Stock.AddRange(stockData);

                    context.SaveChanges();


                }
            }
        }
    }
}
