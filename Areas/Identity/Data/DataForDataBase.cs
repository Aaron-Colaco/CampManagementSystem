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
                        new Item { Name = "Running shoes", CategoryId = 1, ImageURL = "/images/test.png", Price = 2.00 },
                                                  new Item { Name = "Beanies", CategoryId = 5, ImageURL = "/images/test.png", Price = 1.00 },


                        // Outerwear
                        new Item { Name = "Raincoat", CategoryId = 2, ImageURL = "/images/test.png", Price = 6.00 },
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
                        new Item { Name = "Sleeping Bag (-3°C) and Liner (inc. cleaning)", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 },
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
new Stock { ItemId = 1, StockNumber = "", StockId = 1000020, OrderId = null, ShoeSizes = (ShoeSize)0, Brand = "", Notes = "" },
new Stock { ItemId = 1, StockNumber = "", StockId = 1000021, OrderId = null, ShoeSizes = (ShoeSize)0, Brand = "", Notes = "" },
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
new Stock { ItemId = 1, StockNumber = "", StockId = 1000038, OrderId = null, ShoeSizes = (ShoeSize)0, Brand = "", Notes = "" },
new Stock { ItemId = 1, StockNumber = "5B", StockId = 1000039, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | Iinside soles very worn, inside heels worn" },
new Stock { ItemId = 1, StockNumber = "5C", StockId = 1000040, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Hitec", Notes = "not suitable for camp" },
new Stock { ItemId = 1, StockNumber = "5D", StockId = 1000041, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08 | repair done to RH boot 'clasp' | Inside soles very worn | Inside heels worn" },
new Stock { ItemId = 1, StockNumber = "5E", StockId = 1000042, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 30.01.14" },
new Stock { ItemId = 1, StockNumber = "5F", StockId = 1000043, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 28.10.08" },
new Stock { ItemId = 1, StockNumber = "5G", StockId = 1000044, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "NEW 06.08.12" },
new Stock { ItemId = 1, StockNumber = "5H", StockId = 1000045, OrderId = null, ShoeSizes = (ShoeSize)50, Brand = "Skellerup Hiker", Notes = "Old" },
new Stock { ItemId = 1, StockNumber = "", StockId = 1000046, OrderId = null, ShoeSizes = (ShoeSize)0, Brand = "", Notes = "" },
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
new Stock { ItemId = 1, StockNumber = "", StockId = 1000103, OrderId = null, ShoeSizes = (ShoeSize)0, Brand = "", Notes = "" },
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







};

                   
                    context.Stock.AddRange(stockData);

                    context.SaveChanges();


                }
            }
        }
    }
}
