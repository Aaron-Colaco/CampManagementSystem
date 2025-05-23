using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Stripe.Climate;
using WebApplication4.Data;
using WebApplication4.Migrations;
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
        public async Task<IActionResult> Index(string? SearchTerm)
        {
            var GearRequested = _context.OrderItem.Where(a => a.GearAssigned == false);
            var StockAvliable = _context.Stock.Where(a => a.OrderId == null);
         
            ViewBag.StockNumber = StockAvliable.Count();

            ViewBag.GearHire = _context.Stock.Count(a => a.OrderId != null);

            ViewBag.SearchTerm = SearchTerm; 
            var stock = _context.Stock.Include(s => s.order).ThenInclude(a => a.user).
                Include(a => a.Items).OrderBy(a => a.OrderId == null);

            if(SearchTerm != null)
            {
                var results = _context.Stock.Include(a => a.Items).Include(a => a.order).ThenInclude(a => a.user).Where( a => a.Items.Name.Contains(SearchTerm) ||a.order.UserId.Contains(SearchTerm) || a.order.user.Email.Contains(SearchTerm) || a.order.user.StudentNumber.Contains(SearchTerm) || a.order.user.FirstName.Contains(SearchTerm));



                return View(await results.ToListAsync());
            }

       

            return View(await stock.ToListAsync());
        }
        public async Task<IActionResult> AS(string id)
        {
            var order = _context.Order.Where(a => a.OrderId == id).FirstOrDefault();
            var listOrderItems =  _context.OrderItem.Include(o => o.Items).Include(o => o.Orders).Where(a => a.OrderId == id && a.GearAssigned == false);

            var StockAvliable = _context.Stock.Where(a => a.order.UserId == null);
            var GearRequested = listOrderItems.Where(a => a.GearAssigned == false);

      

            ViewBag.Stock = StockAvliable;
            ViewBag.OrderId = id;

            ViewBag.Status = order.StatusId;

            ViewBag.StockGiven = _context.Stock.Count(a => a.order.UserId == order.UserId);

            ViewBag.UserSID = order.UserId;
            var userstock = _context.Stock.Where(a => a.order.UserId == order.UserId).Include(a => a.Items);


            ViewBag.GearRequestedNumber = _context.OrderItem.Where(a => a.OrderId == id).Sum(a => a.Quantity);


            ViewBag.StockNumber = StockAvliable.Count();

            ViewBag.UserStock = userstock;

            ViewBag.OrderStatus = order.StatusId;

            return View(await listOrderItems.ToArrayAsync());






        }
        public async Task<IActionResult> Confirm(string OrderId)
        {
            var order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();
            order.StatusId = 4;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Orders");


        }



        public async Task<IActionResult> a2(int StockId, string OrderId)
        {
           var stock = _context.Stock.Where(a => a.StockId == StockId).FirstOrDefault();
            var order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();

            stock.OrderId = OrderId;
            _context.SaveChanges();



            var GearRequested = _context.OrderItem.Where(a => a.OrderId == OrderId);
            var UserStock = _context.Stock.Where(a => a.OrderId == order.UserId).Include(a => a.Items);

    

            var itemreq = GearRequested.Where(a => a.ItemId == stock.ItemId).FirstOrDefault();



            if(itemreq.Quantity == 1)
            {
                itemreq.GearAssigned = true;
                _context.SaveChanges();
            }
            else 
            {

                int UserItems = _context.Stock.Where(a => a.Items.ItemId == stock.ItemId && a.order.UserId == order.UserId).Count();

                if(itemreq.Quantity == UserItems)
                {
                    itemreq.GearAssigned = true;
                    _context.SaveChanges();
                }

            }

            @ViewBag.Status = order.status;
            return RedirectToAction("AS",new { id = OrderId });
        }

        public async Task <IActionResult> UA(int StockId, string? OrderId, string? SearchTerm)
        {
            var stock = _context.Stock.Where(a => a.StockId == StockId).FirstOrDefault();
            var GearRequested = _context.OrderItem.Where(a => a.OrderId == OrderId);
            var OrderStock = _context.Stock.Where(a => a.StockId == StockId).FirstOrDefault();

            string Id = OrderStock.OrderId;


            var Gear = GearRequested.Where(a => a.ItemId == stock.ItemId).FirstOrDefault();


            _context.SaveChanges();

            if (OrderId != null)
            {

                Gear.GearAssigned = false;
                stock.OrderId = null;
                _context.SaveChanges();

                return RedirectToAction("AS", new { id = OrderId });
            }
            else
            {
                
                stock.OrderId = null;
                _context.SaveChanges();

                var order = _context.Order.Where(a => a.OrderId == Id).FirstOrDefault();

                var Stock = _context.Stock.Where(a => a.OrderId == Id);

                if(!Stock.Any())
                {
                    order.StatusId = 3;
                    _context.SaveChanges();
                }



                return RedirectToAction("Index", new {SearchTerm = SearchTerm });
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
                .Include(s => s.order).ThenInclude(a => a.user)
                .FirstOrDefaultAsync(m => m.StockId == id);
            if (stock == null)
            {
                return NotFound();
            }

            return View(stock);
        }


        public async Task<IActionResult> PickItem()
        {
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "Name");
            return View();
        }
        public async Task<IActionResult> PickedItem(int itemId)
        {
          var item =  _context.Item.Where(a => a.ItemId == itemId).FirstOrDefault();

            ViewBag.Cat = item.CategoryId;

            ViewBag.ItemId = itemId;

            ViewBag.Name = item.Name;


            return View();

            
           

        }

        // GET: Stocks/Create


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockId,ItemId,UserId,ClothingSizes,ShoeSizes")] Stock stock, int NumberToAdd, string ClothingSizes, string ShoeSizes)
        {

            var items = _context.Stock.Where(a => a.ItemId == stock.ItemId);

            int stockId;
            if (items != null)
            {
                stockId = items.Max(a => a.StockId);
            }
            else
            {
              //  base for new items for exaample ItemId=1 10000, ItemId=2  20000
                stockId = stock.ItemId * 10000;
            }

            
                // add NumberToAdd new records
                for (int i = 1; i <= NumberToAdd; i++)
                {
                    while (_context.Stock.Any(a => a.StockId == stockId))
                    {
                        stockId++;
                    }


                if (ClothingSizes != null)
                {
                    _context.Stock.Add(new Stock
                    {

                        ClothingSizes = stock.ClothingSizes,
                        StockId = stockId,
                        ItemId = stock.ItemId,
                        OrderId = null
                    });
                }

                if (ShoeSizes  != null)
                {
                    _context.Stock.Add(new Stock
                    {

                        ShoeSizes = stock.ShoeSizes,
                        StockId = stockId,
                        ItemId = stock.ItemId,
                        OrderId = null
                    });

                }

       

        await _context.SaveChangesAsync();
                stockId++;
            }

                
                return RedirectToAction(nameof(Index));
            


         
        }


        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Item = _context.Stock.Where(a => a.StockId == id).Include(a => a.Items).FirstOrDefault();


            var item = _context.Item.Where(a => a.ItemId == Item.ItemId).FirstOrDefault();
            ViewBag.Cat = item.CategoryId;

            ViewBag.ItemId = id;

            ViewBag.Name = item.Name;


            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ImageURL", stock.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", stock.OrderId);
            return View(stock);
        }

        // POST: Stocks1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,ItemId,OrderId,ClothingSizes,ShoeSizes")] Stock stock)
        {
            if (id != stock.StockId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
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
            ViewData["ItemId"] = new SelectList(_context.Item, "ItemId", "ImageURL", stock.ItemId);
            ViewData["OrderId"] = new SelectList(_context.Order, "OrderId", "OrderId", stock.OrderId);
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
                .Include(s => s.order.user)
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
