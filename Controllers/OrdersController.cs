using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe.Climate;
using WebApplication4.Data;
using WebApplication4.Migrations;
using WebApplication4.Models;
using Order = WebApplication4.Models.Order;

namespace WebApplication4.Controllers
{
    public class OrdersController : Controller
    {
        private readonly WebApplication4Context _context;

        public OrdersController(WebApplication4Context context)
        {
            _context = context;
        }

        
        // GET: Orders
        public async Task<IActionResult> Index(string? SearchTerm, int Status)
        {

            var GearRequested = _context.OrderItem.Where(a => a.GearAssigned == false && a.Orders.StatusId != 1);

            ViewBag.GearRequested = GearRequested.Sum(a => a.Quantity);



            var OrderData = from a in _context.Order
                            select a;



            //If user is a admin return all orders where th status id is not one and inlcude the related customers.
            if (User.IsInRole("Admin"))
            {
                OrderData = OrderData.Where(a => a.StatusId != 1).Include(o => o.status).Include(a => a.user);

                if(SearchTerm != null)
                {
                   OrderData = OrderData.Where(a => a.user.FirstName.Contains(SearchTerm) || a.user.StudentNumber == SearchTerm || a.user.Email.Contains(SearchTerm));
                }
                if (Status != 0)
                {
                  OrderData =  OrderData.Where(a => a.StatusId == Status);
                }

            }
            else // if user is not admin only display their order, by using thier id to find only orders that belong to them(the logged in user).
            {
                OrderData = OrderData.Include(o => o.status).Include(a => a.user).Where(a => a.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            }


            return View(await OrderData.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(string id)
        {

            var test = _context.Order.Where(a => a.OrderId == id && a.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (!User.IsInRole("Admin") && test == null)
            {
                throw new Exception();
            }

            //find order bassed on the id passed into the method

            var order = await _context.Order
                .Include(o => o.status)
                .Include(a => a.user)

                .FirstOrDefaultAsync(m => m.OrderId == id);

            // return order to details page
            return View(order);
        }


        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(string firstName, string lastName, string studentNumber)
        {
            if (ModelState.IsValid)
            {
                User user = null;

                // Try to get the user or create them if not found
                do
                {
                    user = _context.Users.FirstOrDefault(a => a.StudentNumber == studentNumber);

                    if (user == null)
                    {
                        user = new User
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            StudentNumber = studentNumber
                        };

                        _context.Users.Add(user);
                        await _context.SaveChangesAsync();
                    }

                } while (user == null); // Repeat until user is created and retrieved

                // Now create a new Order for this user
                var order = new Order
                {
                    UserId = user.Id,
                    OrderTime = DateTime.Now,
                    StatusId = 1,
                    
                };

                _context.Order.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("CreateOrder", new { orderId = order.OrderId });

            }

            return View();
        }
        public async Task<IActionResult> CreateOrder(string OrderId)
        {
            ViewBag.OrderId = OrderId;

            ViewBag.Order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();

            var Order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();

            var orderUser = _context.Users.FirstOrDefault(u => u.Id == Order.UserId);
           
                ViewBag.StudentNumber = orderUser.StudentNumber;

            ViewBag.orderUser = orderUser;


            var Items = _context.Item.Include(i => i.Categorys);

            var StockAvliable = _context.Stock;

            ViewBag.Stock = StockAvliable;

            ViewBag.OrderItems = _context.OrderItem.Where(a => a.OrderId == OrderId);

            


            return View(await Items.ToListAsync());

        }
        public async Task<IActionResult> AddItem(string OrderId, int ItemId, string Size)
        {
            var ExistingItem = _context.OrderItem.Where(a => a.ItemId == ItemId && a.SizesReq == Size).FirstOrDefault();



            if (ExistingItem != null)
            {
                ExistingItem.Quantity++;
            }
            else 
            {

                var OrderItem = new OrderItem
                {
                    OrderId = OrderId,
                    ItemId = ItemId,
                    Quantity = 1,
                    GearAssigned = false,
                    SizesReq = Size

                };
                // add the new Orderitem details to the database
                _context.OrderItem.Add(OrderItem);
            }
            
            
            

            //save changes
            await _context.SaveChangesAsync();

            //Find the Order where the OrderId is equal to the orderId string.
            var Order = _context.Order.Where(a => a.OrderId == OrderId).First();

            // Call the Items In order method again to update the var itemsInOrder
            var itemsInOrder = _context.OrderItem.Where(a => a.OrderId == OrderId).Include(a => a.Items);

            //Set the total Price of the order to the sum of the( items Price * Items Quantity) in the var itemsInOrder.
            Order.TotalPrice = (decimal)itemsInOrder.Sum(a => a.Items.Price * a.Quantity);

            //save changes
            await _context.SaveChangesAsync();


            return RedirectToAction("CreateOrder", new { orderId = OrderId });

        }



        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "Id", "Id", order.StatusId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderId,OrderTime,HireEndDate,TotalPrice,UserId,StatusId")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "Id", "Id", order.StatusId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.status)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(string id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
