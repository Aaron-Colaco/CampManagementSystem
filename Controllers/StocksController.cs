using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Completion;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
using static WebApplication4.Models.Stock;

namespace WebApplication4.Controllers
{
    public class StocksController : Controller
    {
        private readonly WebApplication4Context _context;

        public StocksController(WebApplication4Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStockNumber(string StockNumber, int Id, string searchTerm, int? Page)
        {
            var stock = _context.Stock.Where(a => a.StockId == Id).FirstOrDefault();

            if (stock != null)
            {
                
                stock.StockNumber = StockNumber;
                 await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", new {searchTerm = searchTerm, page = Page });
        }

        public async Task<IActionResult> UpdateShoeSize(string s, int Id, string searchTerm, int? Page)
        {
            var stock = _context.Stock.FirstOrDefault(a => a.StockId == Id);

            if (stock != null)
            {
                stock.ShoeSizes = (ShoeSize)Enum.Parse(typeof(ShoeSize), s);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { searchTerm = searchTerm, page = Page });

        }

        public async Task<IActionResult> UpdateSize(string s, int Id, string searchTerm, int? Page)
        {
            if (Page == null || Page < 1)
            {
                Page = 1;
            }

            var stock = _context.Stock.FirstOrDefault(a => a.StockId == Id);

            if (stock != null)
            {
                // Convert string to enum and assign
                stock.ClothingSizes = (ClothingSize)Enum.Parse(typeof(ClothingSize), s);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index", new { searchTerm = searchTerm, page = Page });

        }


        private const int PageSize = 50;
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchTerm, int? page, int Filter = 0)
        {
            if (page == null || page < 1)
            {
                page = 1;
            }

         
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentSort = sortOrder;

            ViewBag.Filter = Filter;
            ViewBag.CurrentFilter = searchTerm;
            ViewBag.SearchTerm = searchTerm;


            var x = _context.Stock
                .Include(s => s.Items)
                .Include(s => s.order)
                    .ThenInclude(o => o.user)
                .AsNoTracking();

            if (Filter == 1)
            {
                x = x.OrderByDescending(a => a.OrderId != null);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                string searchLower = searchTerm.ToLower();

                x = x.Where(s =>
                    (s.Items != null && s.Items.Name != null && s.Items.Name.ToLower().Contains(searchLower)) ||
                    (s.order != null && s.order.user != null && (
                        (s.order.UserId != null && s.order.UserId.ToString().ToLower().Contains(searchLower)) ||
                        (s.order.user.Email != null && s.order.user.Email.ToLower().Contains(searchLower)) ||
                        (s.order.user.StudentNumber != null && s.order.user.StudentNumber.ToLower().Contains(searchLower)) ||
                        (s.order.user.FirstName != null && s.order.user.FirstName.ToLower().Contains(searchLower)) ||
                        (s.order.OrderId.ToString().ToLower() == searchLower)
                    ))
                );
            }




            var stockStats = await _context.Stock
                .GroupBy(s => s.OrderId == null)
                .Select(g => new { IsAvailable = g.Key, Count = g.Count() })
                .ToListAsync();


            ViewBag.SearchTerm = searchTerm;
            ViewBag.Page = page;
            ViewBag.StockNumber = stockStats.FirstOrDefault(x => x.IsAvailable)?.Count ?? 0;
            ViewBag.GearHire = stockStats.FirstOrDefault(x => !x.IsAvailable)?.Count ?? 0;
            ViewBag.Count = x.Count();
            int pageIndex = page ?? 1;
            var paginatedList = await PaginatedList<Stock>.CreateAsync(x, pageIndex, PageSize);

            return View(paginatedList);
        }



        public async Task<IActionResult> AS(string id)
        {
            var order = _context.Order.Where(a => a.OrderId == id).Include(a => a.user).FirstOrDefault();
            var listOrderItems =  _context.OrderItem.Include(o => o.Items).Include(o => o.Orders).Where(a => a.OrderId == id && a.GearAssigned == false);

            var StockAvliable = _context.Stock.Where(a => a.order.UserId == null);
            var GearRequested = listOrderItems.Where(a => a.GearAssigned == false);

            ViewBag.FirstName = order.user.FirstName;
            ViewBag.LastName = order.user.LastName;

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Confirm(string OrderId)
        {
            var order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();
            order.StatusId = 4;
            await _context.SaveChangesAsync();
            return RedirectToAction("Invoice", "Orders", new {id = OrderId});


        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> a2(int StockId, string OrderId, string orderitemId)
        {
            if (StockId == 0)
            {
                var orderitem = _context.OrderItem.Where(a => a.OrderItemId == orderitemId).FirstOrDefault();

                var tempStock = new Stock
                {
                    ItemId = orderitem.ItemId,
                    OrderId = OrderId

                };
                _context.Stock.Add(tempStock);
                _context.SaveChanges();




                

                if (orderitem.Quantity == 1)
                {
                    orderitem.GearAssigned = true;
                    _context.SaveChanges();
                }
                else
                {
                    int UserItems = _context.Stock.Where(a => a.ItemId == orderitem.ItemId && a.OrderId == OrderId).Count();

                    if (orderitem.Quantity <= UserItems)
                    {
                        orderitem.GearAssigned = true;
                        _context.SaveChanges();
                    }

                }





            }
            else
            {
                var stock = _context.Stock.Where(a => a.StockId == StockId).FirstOrDefault();
                var order = _context.Order.Where(a => a.OrderId == OrderId).FirstOrDefault();

                stock.OrderId = OrderId;
                _context.SaveChanges();



                var GearRequested = _context.OrderItem.Where(a => a.OrderId == OrderId);
                var UserStock = _context.Stock.Where(a => a.OrderId == order.UserId).Include(a => a.Items);





                string shoeSize = stock.ShoeSizes?.ToString();
                string clothingSize = stock.ClothingSizes?.ToString();

                var itemreq = GearRequested.Where(a => a.ItemId == stock.ItemId && (a.SizesReq == shoeSize || a.SizesReq == clothingSize)).FirstOrDefault();



                if (itemreq.Quantity == 1)
                {
                    itemreq.GearAssigned = true;
                    _context.SaveChanges();
                }
                else
                {





                    int UserItems = _context.Stock.Where(a => a.ItemId == stock.ItemId && a.order.UserId == order.UserId).Count();

                    if (itemreq.Quantity <= UserItems)
                    {
                        
                        itemreq.GearAssigned = true;
                        _context.SaveChanges();
                    }

                }


            }
                return RedirectToAction("AS", new { id = OrderId });
            
        }

            [Authorize(Roles = "Admin")]
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
                if (stock.StockNumber == null || string.IsNullOrWhiteSpace(stock.StockNumber))
                {
                    _context.Stock.Remove(stock);
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

                if (stock.StockNumber == null || string.IsNullOrWhiteSpace(stock.StockNumber))
                {
                    _context.Stock.Remove(stock);
                }


                _context.SaveChanges();


                return RedirectToAction("Index", new {SearchTerm = SearchTerm });
            }

        }



        // GET: Stocks/Details/5
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StockId,ItemId,UserId,ClothingSizes,ShoeSizes,Brand,Colour,Notes")] Stock stock, int NumberToAdd, string ClothingSizes, string ShoeSizes)
        {

            var items = _context.Stock.Where(a => a.ItemId == stock.ItemId).Include(a => a.Items);
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id, string? SearchTerm, int? Page)
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

            ViewBag.Page = Page;
            ViewBag.SearchTerm = SearchTerm;

           
            

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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("StockId,OrderId,ClothingSizes,ShoeSizes,StockNumber,Colour,Brand,Notes")] Stock stock, int ItemId, string? SearchTerm, int? Page)
        {



            var stockNumberExists = _context.Stock.AsNoTracking().Where(a => a.ItemId == ItemId).FirstOrDefault();




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
                return RedirectToAction("Index", new {page = Page, searchTerm = SearchTerm});
                }
                return View(stock);
            
         

            
        }


        // GET: Stocks/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id, string? SearchTerm, int? Page)
        {
            if (Page == null || Page < 1)
            {
                Page = 1;
            }

            ViewBag.Page = Page;
            ViewBag.SearchTerm = SearchTerm;
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.Stock
                .Include(s => s.Items)
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id, int Page, string SearchTerm)
        {

            ViewBag.Page = Page;
            ViewBag.SearchTerm = SearchTerm;
            var stock = await _context.Stock.FindAsync(id);
            if (stock != null)
            {
                _context.Stock.Remove(stock);
            }
            if (Page == null || Page < 1)
            {
                Page = 1;
            }


            await _context.SaveChangesAsync();
            return RedirectToAction("Index", new { page = Page, searchTerm = SearchTerm });

        }

        private bool StockExists(int id)
        {
            return _context.Stock.Any(e => e.StockId == id);
        }
    }
}
