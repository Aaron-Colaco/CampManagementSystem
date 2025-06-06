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
                          new Item { Name = "Beanies", CategoryId = 5, ImageURL = "/images/test.png", Price = 1.00 },
                        new Item { Name = "Running shoes", CategoryId = 1, ImageURL = "/images/test.png", Price = 2.00 },

                        // Outerwear
                        new Item { Name = "Raincoat", CategoryId = 2, ImageURL = "/images/test.png", Price = 6.00 },
                        new Item { Name = "Overtrousers - wet weather pants", CategoryId = 2, ImageURL = "/images/test.png", Price = 6.00 },

                        // Tops
                        new Item { Name = "Long sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Short sleeved vest - woollen or poly pro", CategoryId = 3, ImageURL = "/images/test.png", Price = 2.00 },
                         new Item { Name = "Bush shirt or polar fleece", CategoryId = 3, ImageURL = "/images/test.png", Price = 3.00 },
                        new Item { Name = "Woollen jumper", CategoryId = 3, ImageURL = "/images/test.png", Price = 3.00 },
                      

                        new Item { Name = "Backpacks", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 }

                        // Bottoms
                        new Item { Name = "Long johns - woollen or poly pro", CategoryId = 4, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Trackpants", CategoryId = 4, ImageURL = "/images/test.png", Price = 1.00 },
                        new Item { Name = "Shorts", CategoryId = 4, ImageURL = "/images/test.png", Price = 1.00 },

                        // Accessories
                      
                        new Item { Name = "Woollen mittens", CategoryId = 5, ImageURL = "/images/test.png", Price = 2.00 },
                        new Item { Name = "Woollen socks", CategoryId = 5, ImageURL = "/images/test.png", Price = 3.00 },

                        // Sleeping Gear
                        new Item { Name = "Sleeping Bag (-3°C) and Liner (inc. cleaning)", CategoryId = 6, ImageURL = "/images/test.png", Price = 22.00 }
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
    new Stock { ItemId = 2, StockId = 2000001, StockNumber = "1", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.Medium, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000002, StockNumber = "2", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.Medium, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000003, StockNumber = "3", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.Small, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000004, StockNumber = "4", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.Small, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000005, StockNumber = "5", Brand = "", Colour = "Brown", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000006, StockNumber = "6", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.Large, Notes = "Not returned Trip 30 Training Week Tineka van Houten. Charged. Paid.", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000007, StockNumber = "7", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000008, StockNumber = "8", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000009, StockNumber = "9", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000010, StockNumber = "10", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000011, StockNumber = "11", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000012, StockNumber = "12", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000013, StockNumber = "13", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000014, StockNumber = "14", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.Medium, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000015, StockNumber = "15", Brand = "", Colour = "Pink", ClothingSizes = Stock.ClothingSize.Medium, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000016, StockNumber = "16", Brand = "", Colour = "Pink", ClothingSizes = Stock.ClothingSize.Medium, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000017, StockNumber = "17", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000018, StockNumber = "18", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.Medium, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000019, StockNumber = "19", Brand = "", Colour = "White", ClothingSizes = Stock.ClothingSize.Small, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000020, StockNumber = "20", Brand = "", Colour = "White", ClothingSizes = Stock.ClothingSize.Medium, Notes = "", OrderId = null },
    new Stock { ItemId = 2, StockId = 2000021, StockNumber = "21", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.Large, Notes = "", OrderId = null },

                        //backpacks

                        new Stock { ItemId = 10, StockId = 2000001, StockNumber = "1", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Throw Away", OrderId = null },
new Stock { ItemId = 10, StockId = 2000002, StockNumber = "2", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Throw Away", OrderId = null },
new Stock { ItemId = 10, StockId = 2000003, StockNumber = "3", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000004, StockNumber = "4", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000005, StockNumber = "5", Brand = "Kathmandu Cotinga 25L", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000006, StockNumber = "6", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000007, StockNumber = "7", Brand = "Kathmandu Cotinga 25L", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000008, StockNumber = "8", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000009, StockNumber = "9", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Throw Away", OrderId = null },
new Stock { ItemId = 10, StockId = 2000010, StockNumber = "10", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000011, StockNumber = "11", Brand = "Great Outdoors Daytripper 35", Colour = "Purple", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000012, StockNumber = "12", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Throw Away", OrderId = null },
new Stock { ItemId = 10, StockId = 2000013, StockNumber = "13", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000014, StockNumber = "14", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Throw Away", OrderId = null },
new Stock { ItemId = 10, StockId = 2000015, StockNumber = "15", Brand = "Kjathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000016, StockNumber = "16", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000017, StockNumber = "17", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000018, StockNumber = "18", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000019, StockNumber = "19", Brand = "Kathmandu Cotinga 25L", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000020, StockNumber = "20", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000021, StockNumber = "21", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000022, StockNumber = "22", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000023, StockNumber = "23", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Purchased Mar 2006", OrderId = null },
new Stock { ItemId = 10, StockId = 2000024, StockNumber = "24", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Purchased Mar 2006, front becoming thin", OrderId = null },
new Stock { ItemId = 10, StockId = 2000025, StockNumber = "25", Brand = "Great Outdoors Daytripper 35", Colour = "Purple", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000026, StockNumber = "26", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000027, StockNumber = "27", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Throw Away", OrderId = null },
new Stock { ItemId = 10, StockId = 2000028, StockNumber = "28", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "missing", OrderId = null },
new Stock { ItemId = 10, StockId = 2000029, StockNumber = "29", Brand = "Great Outdoors Daytripper 35", Colour = "Purple", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000030, StockNumber = "30", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000031, StockNumber = "31", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Throw Away", OrderId = null },
new Stock { ItemId = 10, StockId = 2000032, StockNumber = "32", Brand = "Kathmandu", Colour = "Green", ClothingSizes = Stock.ClothingSize.Standard, Notes = "Mar-06", OrderId = null },
new Stock { ItemId = 10, StockId = 2000033, StockNumber = "33", Brand = "Great Outdoors Daytripper 35", Colour = "Purple", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000034, StockNumber = "34", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000035, StockNumber = "35", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null },
new Stock { ItemId = 10, StockId = 2000036, StockNumber = "36", Brand = "Great Outdoors Daytripper 35", Colour = "Purple", ClothingSizes = Stock.ClothingSize.Standard, Notes = "", OrderId = null }

//bush shirt 
                        new Stock { ItemId = 8, StockId = 200001, StockNumber = "1", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200002, StockNumber = "2", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200003, StockNumber = "3", Brand = "", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200004, StockNumber = "4", Brand = "", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200005, StockNumber = "5", Brand = "", Colour = "Brown/White", ClothingSizes = Stock.ClothingSize.3XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200006, StockNumber = "6", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200007, StockNumber = "7", Brand = "", Colour = "Red/Green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200008, StockNumber = "8", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200009, StockNumber = "9", Brand = "", Colour = "Blue/Black - NEW 22.01.16", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200010, StockNumber = "10", Brand = "", Colour = "Green/black", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200011, StockNumber = "11", Brand = "", Colour = "Blue/Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200012, StockNumber = "12", Brand = "", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200013, StockNumber = "13", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200014, StockNumber = "14", Brand = "", Colour = "Green/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200015, StockNumber = "15", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200016, StockNumber = "16", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200017, StockNumber = "17", Brand = "", Colour = "Green - NEW 14.08.18", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200018, StockNumber = "18", Brand = "", Colour = "Brown - NEW 14.08.18", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200019, StockNumber = "19", Brand = "", Colour = "Black/Grey", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200020, StockNumber = "20", Brand = "", Colour = "Black/Grey - NEW 29.08.18", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200021, StockNumber = "21", Brand = "", Colour = "Threw away 25.07.23", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200022, StockNumber = "22", Brand = "", Colour = "Green/Red/Yellow", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200023, StockNumber = "23", Brand = "", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200024, StockNumber = "24", Brand = "", Colour = "Mauve/Red", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200025, StockNumber = "25", Brand = "", Colour = "brown - NEW 2019", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200026, StockNumber = "26", Brand = "", Colour = "Pink/Yellow", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200027, StockNumber = "27", Brand = "", Colour = "Pink/Yellow/green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200028, StockNumber = "28", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200029, StockNumber = "29", Brand = "", Colour = "Brown/White L) arm back stain", ClothingSizes = Stock.ClothingSize.3XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200030, StockNumber = "30", Brand = "", Colour = "Blue/Green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200031, StockNumber = "", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200032, StockNumber = "", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200033, StockNumber = "NUMBER", Brand = "", Colour = "COLOR", ClothingSizes = Stock.ClothingSize.SIZE, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200034, StockNumber = "61", Brand = "", Colour = "Red/Yellow", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200035, StockNumber = "62", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200036, StockNumber = "63", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200037, StockNumber = "64", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200038, StockNumber = "65", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200039, StockNumber = "66", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200040, StockNumber = "67", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200041, StockNumber = "68", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200042, StockNumber = "69", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200043, StockNumber = "70", Brand = "", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200044, StockNumber = "71", Brand = "", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200045, StockNumber = "72", Brand = "", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200046, StockNumber = "73", Brand = "", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200047, StockNumber = "74", Brand = "", Colour = "Olive/Brown", ClothingSizes = Stock.ClothingSize.XL, Notes = "missing", OrderId = null },				
new Stock { ItemId = 8, StockId = 200048, StockNumber = "75", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.3XL, Notes = "missing", OrderId = null },				
new Stock { ItemId = 8, StockId = 200049, StockNumber = "76", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200050, StockNumber = "77", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.3XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200051, StockNumber = "78", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200052, StockNumber = "79", Brand = "", Colour = "green/brown", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200053, StockNumber = "80", Brand = "", Colour = "Brown/White", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200054, StockNumber = "81", Brand = "", Colour = "Grey/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200055, StockNumber = "82", Brand = "", Colour = "Blue/Navy", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200056, StockNumber = "83", Brand = "", Colour = "Green/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200057, StockNumber = "84", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XL, Notes = "missing", OrderId = null },				
new Stock { ItemId = 8, StockId = 200058, StockNumber = "85", Brand = "", Colour = "Blue/Brown", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200059, StockNumber = "86", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200060, StockNumber = "137", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200061, StockNumber = "142", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200062, StockNumber = "143", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.XL, Notes = "missing", OrderId = null },				
new Stock { ItemId = 8, StockId = 200063, StockNumber = "NUMBER", Brand = "", Colour = "COLOR", ClothingSizes = Stock.ClothingSize.SIZE, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200064, StockNumber = "31", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200065, StockNumber = "32", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200066, StockNumber = "33", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200067, StockNumber = "34", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200068, StockNumber = "35", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200069, StockNumber = "36", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200070, StockNumber = "37", Brand = "", Colour = "Grey/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200071, StockNumber = "38", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200072, StockNumber = "39", Brand = "", Colour = "Blue/Green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200073, StockNumber = "40", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200074, StockNumber = "41", Brand = "", Colour = "Black/White", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200075, StockNumber = "42", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200076, StockNumber = "43", Brand = "", Colour = "Blue DONATED 09.08.22", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200077, StockNumber = "44", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200078, StockNumber = "45", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200079, StockNumber = "46", Brand = "", Colour = "Blue/Grey", ClothingSizes = Stock.ClothingSize.S, Notes = "missing", OrderId = null },				
new Stock { ItemId = 8, StockId = 200080, StockNumber = "47", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200081, StockNumber = "48", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200082, StockNumber = "49", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200083, StockNumber = "50", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200084, StockNumber = "51", Brand = "", Colour = "Blue - NEW 08.05.20", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200085, StockNumber = "52", Brand = "", Colour = "Blue/Black", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200086, StockNumber = "53", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200087, StockNumber = "54", Brand = "", Colour = "Black/Grey", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200088, StockNumber = "55", Brand = "", Colour = "Blue/Red", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200089, StockNumber = "56", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200090, StockNumber = "57", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200091, StockNumber = "58", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200092, StockNumber = "59", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },				
new Stock { ItemId = 8, StockId = 200093, StockNumber = "60", Brand = "", Colour = "Red/Black", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },				

//jumpers 
            new Stock { ItemId = 9, StockId = 7000001, StockNumber = "1", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "2", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "3", Brand = "", Colour = "Navy/Green", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "5", Brand = "", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "6", Brand = "", Colour = "Navy/Green", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "7", Brand = "", Colour = "green army", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "8", Brand = "", Colour = "Brown", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "9", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "10", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "11", Brand = "", Colour = "navy", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "12", Brand = "", Colour = "green/black", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "13", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "14", Brand = "", Colour = "brown dark", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "15", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "16", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "17", Brand = "", Colour = "Mottled", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "19", Brand = "", Colour = "Grey, donated", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "20", Brand = "", Colour = "white", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "21", Brand = "", Colour = "rust", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "22", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "23", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "24", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "25", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "26", Brand = "", Colour = "burgundy", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "27", Brand = "", Colour = "Brown", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "", Brand = "", Colour = "", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "28", Brand = "", Colour = "black/red", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "29", Brand = "", Colour = "red", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "31", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "32", Brand = "", Colour = "green", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "33", Brand = "", Colour = "Avcol navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "34", Brand = "", Colour = "army", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "36", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "37", Brand = "", Colour = "navy", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "38", Brand = "", Colour = "Throw away", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "39", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "40", Brand = "", Colour = "maroon, black sq", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "41", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "42", Brand = "", Colour = "mustard", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "43", Brand = "", Colour = "fawn", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "44", Brand = "", Colour = "purple", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "45", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "46", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "47", Brand = "", Colour = "Green donated2024", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "48", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "49", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "50", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "51", Brand = "", Colour = "brown zip", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "53", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "54", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "55", Brand = "", Colour = "grey", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "56", Brand = "", Colour = "Throw Away", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "57", Brand = "", Colour = "07.11.22 Green with white flowers.", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "58", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "59", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "60", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "61", Brand = "", Colour = "green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "62", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "63", Brand = "", Colour = "pink", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "64", Brand = "", Colour = "purple variagated", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "65", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "66", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "67", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "68", Brand = "", Colour = "grey Ac", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "69", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "70", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "71", Brand = "", Colour = "Creamy grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "72", Brand = "", Colour = "Avcol navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "73", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "74", Brand = "", Colour = "grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "75", Brand = "", Colour = "purple", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "77", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "78", Brand = "", Colour = "Cream", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "79", Brand = "", Colour = "green/blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "80", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "81", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "82", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "83", Brand = "", Colour = "Brown/Orange", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "85", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "86", Brand = "", Colour = "Charcoal/green", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "87", Brand = "", Colour = "natural", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "88", Brand = "", Colour = "charcoal", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "89", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "90", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "91", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "92", Brand = "", Colour = "charcoal", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "93", Brand = "", Colour = "Charcoal", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "94", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "95", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "96", Brand = "", Colour = "Brown", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "97", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "99", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "100", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "77", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "78", Brand = "", Colour = "Cream", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "79", Brand = "", Colour = "green/blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "80", Brand = "", Colour = "Orange", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "81", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "82", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "83", Brand = "", Colour = "Brown/Orange", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "85", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "86", Brand = "", Colour = "Charcoal/green", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "87", Brand = "", Colour = "natural", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "88", Brand = "", Colour = "charcoal", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "89", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "90", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "91", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "92", Brand = "", Colour = "charcoal", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "93", Brand = "", Colour = "Charcoal", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "95", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "96", Brand = "", Colour = "Brown", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "97", Brand = "", Colour = "brown", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "99", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "100", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "126", Brand = "", Colour = "Navy blue", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "127", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "128", Brand = "", Colour = "black", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "129", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.3XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "130", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.3XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "131", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.4XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "132", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "133", Brand = "", Colour = "beige", ClothingSizes = Stock.ClothingSize.2XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "134", Brand = "", Colour = "navy", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "136", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "137", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "138", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "139", Brand = "", Colour = "multi", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "141", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "142", Brand = "", Colour = "green", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "143", Brand = "", Colour = "navy – HB", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "144", Brand = "", Colour = "blue", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "145", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "146", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "147", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "148", Brand = "", Colour = "pink", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "149", Brand = "", Colour = "olive-WH", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "150", Brand = "", Colour = "navy-WH", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "151", Brand = "", Colour = "oatmeal-WH", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "152", Brand = "", Colour = "maroon", ClothingSizes = Stock.ClothingSize.XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "153", Brand = "", Colour = "Peacock Blue", ClothingSizes = Stock.ClothingSize.4XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "154", Brand = "", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.4XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "155", Brand = "", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.4XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "156", Brand = "", Colour = "Maroon", ClothingSizes = Stock.ClothingSize.4XL, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "157", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "158", Brand = "", Colour = "Grey/Multi", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "159", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "160", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "161", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "162", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "163", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "164", Brand = "", Colour = "Cream", ClothingSizes = Stock.ClothingSize.S, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "165", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "166", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "168", Brand = "", Colour = "Grey", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "169", Brand = "", Colour = "not allocated", ClothingSizes = Stock.ClothingSize., Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "170", Brand = "", Colour = "Black", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "171", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "172", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "173", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "177", Brand = "", Colour = "Navy", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "178", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "179", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "180", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.L, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "181", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "182", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "183", Brand = "", Colour = "Red", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "188", Brand = "", Colour = "Blue", ClothingSizes = Stock.ClothingSize.2XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "194", Brand = "", Colour = "Avcol Navy", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "199", Brand = "", Colour = "Lilac", ClothingSizes = Stock.ClothingSize.XS, Notes = "", OrderId = null },
new Stock { ItemId = 9, StockId = 7000001, StockNumber = "206", Brand = "", Colour = "Green", ClothingSizes = Stock.ClothingSize.M, Notes = "", OrderId = null },            


                        
                        
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
