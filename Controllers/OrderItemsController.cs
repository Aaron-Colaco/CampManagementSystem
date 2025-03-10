using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class OrderItemsController : Controller
    {
        private readonly WebApplication4Context _context;

        public OrderItemsController(WebApplication4Context context)
        {
            _context = context;
        }

        // GET: OrderItems
        public async Task<IActionResult> Index()
        {
            var webApplication4Context = _context.OrderItem.Include(o => o.Items).Include(o => o.Orders);
            return View(await webApplication4Context.ToListAsync());
        }




        public async Task<IActionResult> OpenCart()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectPermanent("/Identity/Account/Register");
            }

            //Calls the GetOrder Method and stores the return value in a Variable called order.
            var Order = await GetOrder();
            //returns the index view pasiing the Order Variable
            return View("Index", Order);
        }




        //This method returns a lsit of type orderItem
        public async Task<List<OrderItem>> GetOrder()
        {
            //gets the order id from the return method CheckUserOrders.
            string orderId = await CheckUserOrders();
            // Find all ordered Items with that orderId, including their related items and orders.                 
            var listOrderItems = await _context.OrderItem.Include(o => o.Items).Include(o => o.Orders).Where(a => a.OrderId == orderId).ToListAsync();

            //return this list to the caller Method.
            return listOrderItems;
        }
        public async Task<string> CheckUserOrders()
        {

            //Find the id of the Cusotomer that is logged in
            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // Find a order in the database where the cusotmer id of the order equals the id of the logged in user.
            var UserOrder = _context.Order.Where(a => a.user.Id == UserId).FirstOrDefault();

            //If user has no orders, or no order with the status of one
            if (UserOrder == null)
            {
                //Create new order
                var NewOrder = new Models.Order
                {
                    //set the customer id to the id of the cureently logined in user.
                    UserId = UserId,
                    StatusId = 1,// set the status id to one.
                    OrderTime = DateTime.Now // set the order time to the current time now
                };
                //Add the new order to the database and save changes.
                _context.Order.Add(NewOrder);
                await _context.SaveChangesAsync();

                //return the string Order Id of the new order
                return NewOrder.OrderId;
            }
            else
            // if the user already as a order where the statusid is one 
            {
                //return the stirng OrderId of the exisitng Order.
                return (UserOrder.OrderId);
            }
        }







        public async Task<IActionResult> AddToCart(int itemId)
        {

            //If user is not logined in redrict to to Register page
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectPermanent("/Identity/Account/Register");
            }
m


            //make sure user is logged in before accesing the method

            //This method returns a string
            // Call the CheckUserOrders method and store the return vlaue in a string called orderId
            string orderId = await CheckUserOrders();

            // Call the Items In order method and store the return values in a var.
            var itemsInOrder = await GetOrder();

            //If the sum of the items in a user order is >= 35
            if (itemsInOrder.Sum(a => a.Quantity) >= 35)
            {
                ViewBag.CartFull = 1;
                //return to Index method passing in the order id as well as true for the cartfull parameter
                return RedirectToAction("Index", new { id = orderId, CartFull = true });
            }

            //Find if any items in the order where the itemId is the same as the itemid passed into the method
            var ExistingItem = itemsInOrder.Where(a => a.ItemId == itemId).FirstOrDefault();



            //If item Exist in order
            if (ExistingItem != null)
            {
                //increase the quantity by 1
                ExistingItem.Quantity++;
            }
            else // If item is not in order add new item
            {

                var OrderItem = new OrderItem
                {
                    //Set the OrderId to the orderId string, the ItemId to the itemId passed into the method and the quantity to one.

                    OrderId = orderId,
                    ItemId = itemId,
                    Quantity = 1
                };
                // add the new Orderitem details to the database
                _context.OrderItem.Add(OrderItem);
            }
            // Save changes
            await _context.SaveChangesAsync();

            //Find the Order where the OrderId is equal to the orderId string.
            var Order = _context.Order.Where(a => a.OrderId == orderId).First();

            // Call the Items In order method again to update the var itemsInOrder
            itemsInOrder = await GetOrder();

            //Set the total Price of the order to the sum of the( items Price * Items Quantity) in the var itemsInOrder.
            Order.TotalPrice = (decimal)itemsInOrder.Sum(a => a.Items.Price * a.Quantity);

            //save changes
            await _context.SaveChangesAsync();

            //Redirect to the items index action passing true for the display pop up parameter and ItemId for the item parrameter.
            return RedirectToAction("Index", "Items", new { displayPopUp = true, item = itemId });
        }



    }
}