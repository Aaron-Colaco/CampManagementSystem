using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

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
        public async Task<IActionResult> Index()
        {

            var GearRequested = _context.OrderItem.Where(a => a.GearAssigned == false && a.Orders.StatusId != 1);

            ViewBag.GearRequested = GearRequested.Sum(a => a.Quantity);

            var OrderData = _context.Order.Include(o => o.status).Include(a => a.user).Where(a => a.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier));

        
            //If user is a admin return all orders where th status id is not one and inlcude the related customers.
            if (User.IsInRole("Admin"))
            {
                OrderData = OrderData.Where(a => a.StatusId != 1).Include(o => o.status).Include(a => a.user);

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
                .Include(a => a.UserId)

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
        public async Task<IActionResult> Create([Bind("OrderId,OrderTime,HireEndDate,TotalPrice,UserId,StatusId")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StatusId"] = new SelectList(_context.Set<Status>(), "Id", "Id", order.StatusId);
            return View(order);
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
