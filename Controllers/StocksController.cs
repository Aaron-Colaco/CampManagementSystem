using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Stripe.Climate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Migrations;
using WebApplication4.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication4.Controllers
{
    public class StocksController : Controller
    {
        private readonly WebApplication4Context _context;

        public StocksController(WebApplication4Context context)
        {
            _context = context;
        }
       

private const int PageSize = 50;


        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
                page = 1;
            else
                searchString = currentFilter;

            ViewBag.CurrentFilter = searchString;

            var query = _context.Stock.AsNoTracking();

            // Filtering (check for null navigation props)
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(s =>
                    s.Items.Name.Contains(searchString) ||
                    (s.order != null && (
                        s.order.UserId.Contains(searchString) ||
                        s.order.user.Email.Contains(searchString) ||
                        s.order.user.StudentNumber.Contains(searchString) ||
                        s.order.user.FirstName.Contains(searchString) ||
                        s.order.OrderId.ToString() == searchString
                    ))
                );
            }

           

            // Summary counts
            ViewBag.StockNumber = await _context.Stock.CountAsync(s => s.OrderId == null);
            ViewBag.GearHire = await _context.Stock.CountAsync(s => s.OrderId != null);

            // Paging
            int pageIndex = page ?? 1;
            var paginatedList = await PaginatedList<Stock>.CreateAsync(
                query
                .Include(s => s.Items)
                .Include(s => s.order)
                    .ThenInclude(o => o.user),
                pageIndex, PageSize);

            return View(paginatedList);
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
            var userstock = _context.Stock.Where(a => a.order.OrderId == order.OrderId).Include(a => a.Items);


            ViewBag.GearRequestedNumber = _context.OrderItem.Where(a => a.OrderId == id).Sum(a => a.Quantity);


            ViewBag.StockNumber = StockAvliable.Count();

            ViewBag.UserStock = userstock;

            ViewBag.OrderStatus = order.StatusId;

            if (order.StatusId == 4)
            {
                return RedirectToAction("Index", new {SearchTerm = order.OrderId} );

            }


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

           

            

            string shoeSize = stock.ShoeSizes?.ToString();
            string clothingSize = stock.ClothingSizes?.ToString();

            var itemreq = GearRequested.Where(a => a.ItemId == stock.ItemId &&(a.SizesReq == shoeSize || a.SizesReq == clothingSize)).FirstOrDefault();



            if (itemreq.Quantity == 1)
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
                if (Gear != null)
                {
                    Gear.GearAssigned = false;
                    stock.OrderId = null;
                    _context.SaveChanges();
                }

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
        public async Task<IActionResult> Create([Bind("StockId,ItemId,UserId,ClothingSizes,ShoeSizes,Brand,Colour,Notes")] Stock stock, int NumberToAdd, string ClothingSizes, string ShoeSizes)
        {

            var items = _context.Stock.Where(a => a.ItemId == stock.ItemId);
            string stockNumber = "1";
            int st = 1;
           if (items.Any())
            {
                if (items.First().Items.CategoryId != 1)
                {
                    st = (int)items.Max(a => Convert.ToInt64(stockNumber));
                }
                else
                {
                    stockNumber = "EnterSize(Edit)";
                }
            }

           

            
                // add NumberToAdd new records
                for (int i = 1; i <= NumberToAdd; i++)
                {
                    

                if (ClothingSizes != null)
                {
                    _context.Stock.Add(new Stock
                    {

                        ClothingSizes = stock.ClothingSizes,
                        StockNumber = st.ToString(),
                        ItemId = stock.ItemId,
                        Colour = stock.Colour,
                        Brand = stock.Brand,
                        OrderId = null,
                        Notes = stock.Notes

                    });
                    st ++;
                }

                if (ShoeSizes  != null)
                {
                    _context.Stock.Add(new Stock
                    {

                        ShoeSizes = stock.ShoeSizes,
                        ItemId = stock.ItemId,
                        OrderId = null,
                        StockNumber = stock.StockNumber

                    });

                }

       

        await _context.SaveChangesAsync();

            }


            return RedirectToAction(nameof(Index));
            


         
        }


        // GET: Stocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.BrandOptions = _context.Stock.Select(s => s.Brand).Distinct().ToList(); 

            ViewBag.ColourOptions = _context.Stock.Select(s => s.Colour).Distinct().ToList();


            if (id == null)
            {
                return NotFound();
            }

            var Item = _context.Stock.Where(a => a.StockId == id).Include(a => a.Items).FirstOrDefault();


            var item = _context.Item.Where(a => a.ItemId == Item.ItemId).FirstOrDefault();
            ViewBag.Cat = item.CategoryId;

            ViewBag.ItemId = item.ItemId;

            ViewBag.Name = item.Name;

           
            

            var stock = await _context.Stock.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            ViewBag.Notes = stock.Notes;
            return View(stock);
        }

        // POST: Stocks1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,OrderId,ClothingSizes,ShoeSizes,StockNumber,Colour,Brand,Notes")] Stock stock, int ItemId)
        {



            var stockNumberExists = _context.Stock.Where(a => a.ItemId == ItemId).FirstOrDefault();




                if (id != stock.StockId)
                {
                    return NotFound();
                }

                if (!ModelState.IsValid)
                {
                    try
                    {

                    if (!string.IsNullOrEmpty(stock.StockNumber))
                    {
                        stock.StockNumber = stock.StockNumber.ToUpper();
                    }


                    stock.ItemId = ItemId;
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
