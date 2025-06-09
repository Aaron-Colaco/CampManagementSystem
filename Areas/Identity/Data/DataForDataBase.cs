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

                        new Item { Name = "Running shoes", CategoryId = 1, ImageURL = "/images/test.png", Price = 2.00 },
                                                  new Item { Name = "Beanies", CategoryId = 5, ImageURL = "/images/test.png", Price = 1.00 },


                        // Outerwear
                        new Item { Name = "Overtrousers - wet weather pants", CategoryId = 2, ImageURL = "/images/test.png", Price = 6.00 },

                        // Tops
                        new Item { Name = "Long sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Short sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },
                         new Item { Name = "Bush shirt or polar fleece", CategoryId = 3, ImageURL = "/images/test.png", Price = 3.00 },
                        new Item { Name = "Woollen jumper", CategoryId = 3, ImageURL = "/images/test.png", Price = 3.00 },
                      

                        new Item { Name = "Backpacks", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 },

                        // Bottoms
                        new Item { Name = "Long johns - woollen or poly pro", CategoryId = 4, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Trackpants", CategoryId = 4, ImageURL = "/images/test.png", Price = 1.00 },
                        new Item { Name = "Shorts", CategoryId = 4, ImageURL = "/images/test.png", Price = 1.00 },

                        // Accessories
                      
                        new Item { Name = "Woollen mittens", CategoryId = 5, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Woollen socks", CategoryId = 5, ImageURL = "/images/test.png", Price = 3.00 },

                        // Sleeping Gear
                          new Item { Name = "Day Pack", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 }
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










































};

                   
                    context.Stock.AddRange(stockData);

                    context.SaveChanges();


                }
            }
        }
    }
}
