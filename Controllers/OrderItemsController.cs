using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: OrderItems/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItem
                .Include(o => o.Items)
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(m => m.OrderItemId == id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // GET: OrderItems/Create
        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name");
            ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId");
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderItemId,Quantity,OrderId,ItemId,CampId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", orderItem.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId", orderItem.OrderId);
            return View(orderItem);
        }

        // GET: OrderItems/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItem.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", orderItem.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId", orderItem.OrderId);
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderItemId,Quantity,OrderId,ItemId,CampId")] OrderItem orderItem)
        {
            if (id != orderItem.OrderItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemExists(orderItem.OrderItemId))
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
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name", orderItem.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Set<Order>(), "OrderId", "OrderId", orderItem.OrderId);
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItem = await _context.OrderItem
                .Include(o => o.Items)
                .Include(o => o.Orders)
                .FirstOrDefaultAsync(m => m.OrderItemId == id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var orderItem = await _context.OrderItem.FindAsync(id);
            if (orderItem != null)
            {
                _context.OrderItem.Remove(orderItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemExists(string id)
        {
            return _context.OrderItem.Any(e => e.OrderItemId == id);
        }
    }
}
