using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Stripe.Climate;
using WebApplication4.Data;
using WebApplication4.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DatePicker()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Dashboard(DateTime Date1, DateTime Date2)
        {
            ViewBag.Date1 = Date1;
            ViewBag.Date2 = Date2;

            var orderItemData = _context.OrderItem.Where(a => a.Orders.OrderTime >= Date1 && a.Orders.OrderTime <= Date2).Where(a => a.Orders.StatusId != 1).Include(a => a.Items);
            var orderData = _context.Order.Where(a => a.OrderTime >= Date1 && a.OrderTime <= Date2).Where(a => a.StatusId != 1);


            ViewBag.TotalMoney = orderItemData.Sum(a => a.Items.Price * a.Quantity);

            ViewBag.ItemsHired = orderItemData.Count();

            ViewBag.Orders = orderData.Count();

            var topItems = orderItemData
    .GroupBy(a => new { a.Items.Name }) 
    .Select(g => new {
        ItemName = g.Key.Name,
        TotalQuantity = g.Sum(x => x.Quantity)
    })
    .OrderByDescending(x => x.TotalQuantity)
  
    .ToList();
            var itemProfits = orderItemData
    .GroupBy(a => new { a.Items.Name, a.Items.Price })
    .Select(g => new {
        ItemName = g.Key.Name,
        Quantity = g.Sum(x => x.Quantity),
        Profit = g.Key.Price * g.Sum(x => x.Quantity)
    })
    .OrderByDescending(x => x.Profit)

    .ToList();

            ViewBag.ItemProfitLabels = itemProfits.Select(x => x.ItemName).ToList();
            ViewBag.ItemProfits = itemProfits.Select(x => x.Profit).ToList();
            ViewBag.ItemProfitTable = itemProfits;

            ViewBag.TopItems = topItems;

            ViewBag.TopItemLabels = topItems.Select(x => x.ItemName).ToList();
            ViewBag.TopItemQuantities = topItems.Select(x => x.TotalQuantity).ToList();

            return View();
        }



            [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Invoice(string id, string? SearchTerm, int Status = 0, int page = 1)
        {
            ViewBag.OrderId = id;

            ViewBag.Order = _context.Order.Where(a => a.OrderId == id).FirstOrDefault();

            var Order = _context.Order.Where(a => a.OrderId == id).FirstOrDefault();

            var orderUser = _context.Users.FirstOrDefault(u => u.Id == Order.UserId);

            ViewBag.StudentNumber = orderUser.StudentNumber;

            ViewBag.orderUser = orderUser;

            var Stock = _context.Stock.Where(a => a.OrderId == id).Include(a => a.Items);

            return View(await Stock.ToListAsync());

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Amend(string id, string? SearchTerm, int Status = 0, int page = 1)
        {
            var Order = _context.Order.Where(a => a.OrderId == id).FirstOrDefault();    

            Order.StatusId = 5; // Set the status to 5
            _context.Update(Order);
           await _context.SaveChangesAsync();
           return RedirectToAction("CreateOrder", new { orderId = id });
        }

        private const int PageSize = 50;

        // GET: Orders
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index(string? SearchTerm, int Status, int? page)
        {
            if (page == null || page < 1)
            {
                page = 1;
            }

          

            ViewBag.CurrentFilter = SearchTerm;
            ViewBag.SearchTerm = SearchTerm;

            ViewBag.Status = Status;
            ViewBag.Page = page;




            var OrderData = from a in _context.Order
                            select a;



            if (User.IsInRole("Admin"))
            {
                OrderData = OrderData.Where(a => a.StatusId != 1).Include(o => o.status).Include(a => a.user);

                if(SearchTerm != null)
                {
                   OrderData = OrderData.Where(a => a.user.FirstName.Contains(SearchTerm) || a.user.StudentNumber == SearchTerm || a.user.Email.Contains(SearchTerm)).Include(a => a.user);
                }
                if (Status != 0)
                {
                  OrderData =  OrderData.Where(a => a.StatusId == Status).Include(a => a.user);
                }
                else
                {
                    OrderData = OrderData.Where(a => a.StatusId != 3).Include(a => a.user);

                }

            }
           

           await OrderData.OrderByDescending(a => a.OrderTime).ToListAsync();


            ViewBag.SearchTerm = SearchTerm;
            ViewBag.Page = page;
           
            ViewBag.Count = OrderData.Count();
            int pageIndex = page ?? 1;
            var paginatedList = await PaginatedList<Order>.CreateAsync(OrderData, pageIndex, PageSize);

            return View(paginatedList);

        }

        // GET: Orders/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(string id, string? SearchTerm, int Status = 0, int page = 1)
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(string firstName, string lastName, string studentNumber)
        {
            if (ModelState.IsValid)
            {
                User user = null;

                // Try to get the user or create them if not found
                do
                {
                    user = _context.Users.FirstOrDefault(a => a.StudentNumber == studentNumber && a.FirstName == firstName && a.LastName == lastName);

                    if (user == null)
                    {
                        user = new User
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            StudentNumber = studentNumber,
                            Email = "Ac" + studentNumber + "@avcol.school.nz"
                            
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
                    StatusId = 5,
                    
                };

                _context.Order.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("CreateOrder", new { orderId = order.OrderId });

            }

            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Confirm(string OrderId)
        {
            var Order = _context.Order.Where(a => a.OrderId == OrderId).Include(a => a.user).FirstOrDefault();

            Order.StatusId = 2;

           await  _context.SaveChangesAsync();

            return RedirectToAction("AS","Stocks", new {id = Order.OrderId});

        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateOrder(string OrderId, int? ItemId)
        {


            ViewBag.OrderId = OrderId;

            ViewBag.Order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();

            var Order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();

            var orderUser = _context.Users.FirstOrDefault(u => u.Id == Order.UserId);
           
                ViewBag.StudentNumber = orderUser.StudentNumber;

            ViewBag.orderUser = orderUser;


            var Items = _context.Item.Include(i => i.Categorys);


       

            var StockAvliable = await _context.Stock
                .AsNoTracking()
                .Where(a => a.OrderId == null)
                .OrderBy(a => a.ItemId)
                .ThenBy(a => a.ClothingSizes)
                .Select(a => new { a.ShoeSizes, a.ClothingSizes, a.ItemId })
                .ToListAsync(); 

ViewBag.Stock = StockAvliable;

            ViewBag.OrderItems = _context.OrderItem.Where(a => a.OrderId == OrderId);

            ViewBag.ItemId = ItemId;


            var itemsInOrder = _context.OrderItem.Where(a => a.OrderId == OrderId).Include(a => a.Items);



            ViewBag.Items = itemsInOrder;

           

            //Set the total Price of the order to the sum of the( items Price * Items Quantity) in the var itemsInOrder.
            Order.TotalPrice = (decimal)itemsInOrder.Sum(a => a.Items.Price * a.Quantity);

            _context.SaveChanges();

            return View(await Items.ToListAsync());

        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddItem(string OrderId, int ItemId, string Size)
        {
            var ExistingItem = _context.OrderItem.Where(a => a.ItemId == ItemId && a.SizesReq == Size && a.OrderId == OrderId).FirstOrDefault();


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

      


            return RedirectToAction("CreateOrder", new { orderId = OrderId, ItemId = ItemId });

        }



        // GET: Orders/Edit/5
      

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id, [Bind("OrderId,OrderTime,HireEndDate,TotalPrice,UserId,StatusId")] Order order, string? SearchTerm, int Status = 0, int page = 1)
        {

            ViewBag.SearchTerm = SearchTerm;
            ViewBag.Status = Status;
            ViewBag.Page = page;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id, string? SearchTerm, int Status = 0, int page = 1)
        {
            ViewBag.SearchTerm = SearchTerm;
            ViewBag.Status = Status;
            ViewBag.Page = page;
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.status).Include(a => a.user)
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
        public async Task<IActionResult> DeleteConfirmed(string id, string OrderId, string? SearchTerm, int Status = 0, int page = 1)
        {
            var userStock = _context.Stock.Where(a => a.OrderId == id);

            foreach (var item in userStock)
            {
                item.OrderId = null; // Unassign the stock from the order
            }
            _context.SaveChangesAsync();

            ViewBag.SearchTerm = SearchTerm;
            ViewBag.Status = Status;
            ViewBag.Page = page;
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { SearchTerm = SearchTerm, Status = Status, page = page });

        }

        public async Task<IActionResult> DeleteItem(int ItemId, string OrderId,string? SearchTerm, int Status = 0, int page = 1)
        {
            ViewBag.SearchTerm = SearchTerm;
            ViewBag.Status = Status;
            ViewBag.Page = page;

            var orderItemToRemove = _context.OrderItem.Where(a => a.OrderId == OrderId && a.ItemId == ItemId).FirstOrDefault();
            if (orderItemToRemove != null)
            {
                _context.OrderItem.Remove(orderItemToRemove);
                await _context.SaveChangesAsync();
            }

            // Redirect action to Open Cart
            return RedirectToAction("CreateOrder", new { orderId = OrderId });
        }
        public async Task<IActionResult> UnassingAll(string id, string? SearchTerm, int Status = 0, int page = 1)
        {
            foreach (var item in await _context.Stock.Where(a => a.OrderId == id).ToListAsync())
            {
                if (item.StockNumber == null || string.IsNullOrWhiteSpace(item.StockNumber))
                {
                    var temptoremove = _context.Stock.Where(a => a.StockId == item.StockId).FirstOrDefault();
                   
                        _context.Stock.Remove(temptoremove);

                    _context.SaveChanges();
                }


                item.OrderId = null;
            }
            var order = _context.Order.Where(a => a.OrderId == id).Include(a => a.user).FirstOrDefault();
            order.StatusId = 3;
            TempData["SuccessMessage"] = order.user.FirstName + " has returned their items successfully.";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { SearchTerm = SearchTerm, Status = Status, page = page });



        }


        private bool OrderExists(string id)
        {
            return _context.Order.Any(e => e.OrderId == id);
        }
    }
}
