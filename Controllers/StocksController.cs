using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stripe.Climate;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class StocksController : Controller
    {
        private readonly WebApplication4Context _context;

        public StocksController(WebApplication4Context context)
        {
            _context = context;
        }

        // GET: Stocks
        public async Task<IActionResult> Index()
        {
            var GearRequested = _context.OrderItem.Where(a => a.GearAssigned == false);
            var StockAvliable = _context.Stock.Where(a => a.UserId == null);
         
            ViewBag.StockNumber = StockAvliable.Count();

            ViewBag.GearRequestedNumber = GearRequested.Sum(a => a.Quantity);

            var webApplication4Context = _context.Stock.Include(s => s.user).Include(a => a.Items);
            return View(await webApplication4Context.ToListAsync());
        }
        public async Task<IActionResult> AS(string id)
        {
            var order = _context.Order.Where(a => a.OrderId == id).FirstOrDefault();
            var listOrderItems =  _context.OrderItem.Include(o => o.Items).Include(o => o.Orders).Where(a => a.OrderId == id);

            var StockAvliable = _context.Stock.Where(a => a.UserId == null);
            var GearRequested = listOrderItems.Where(a => a.GearAssigned == false);

            ViewBag.Stock = StockAvliable;

            var userstock = _context.Stock.Where(a => a.UserId == order.UserId).Include(a => a.Items);


            ViewBag.GearRequestedNumber = GearRequested.Sum(a => a.Quantity) - userstock.Count();


            ViewBag.StockNumber = StockAvliable.Count();

            ViewBag.UserStock = userstock;

            return View(await listOrderItems.ToArrayAsync());






        }
        public async Task<IActionResult> a2(int StockId, string OrderId)
        {
           var stock = _context.Stock.Where(a => a.StockId == StockId).FirstOrDefault();
            var order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();

            stock.UserId = order.UserId;
            _context.SaveChanges();



            var GearRequested = _context.OrderItem.Where(a => a.OrderId == OrderId);
            var UserStock = _context.Stock.Where(a => a.UserId == order.UserId).Include(a => a.Items);

    

            var itemreq = GearRequested.Where(a => a.ItemId == stock.ItemId).FirstOrDefault();



            if(itemreq.Quantity == 1)
            {
                itemreq.GearAssigned = true;
            }
            else 
            {
                int UserItems = UserStock.Where(a => a.StockId == StockId).Count();

                if(itemreq.Quantity == UserItems)
                {
                    itemreq.GearAssigned = true;
                }

            }

          
            return RedirectToAction("AS",new { id = OrderId });
        }

        public async Task <IActionResult> UA(int StockId, string? OrderId)
        {
            var stock = _context.Stock.Where(a => a.StockId == StockId).FirstOrDefault();

            stock.UserId = null;

            _context.SaveChanges();

            if (OrderId != null)
            {
                return RedirectToAction("AS", new { id = OrderId });
            }
            else
            {
                return RedirectToAction("Index");
            }

        }



        // GET: Stocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.user)
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // GET: Stocks/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Stocks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockId,ItemId,UserId")] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(stock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", stock.UserId);
            return View(stock);
        }

        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", stock.UserId);
            return View(stock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,ItemId,UserId")] Stock stock)
        {
            if (id != stock.StockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StockExists(stock.StockId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", stock.UserId);
            return View(stock);
        }

        // GET: Stocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.user)
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stock = await _context.Stock.FindAsync(id);
            if (stock != null)
            {
                _context.Stock.Remove(stock);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.StockId == id);
        }
    }
}
