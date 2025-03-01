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
    public class ItemsController : Controller
    {
        private readonly WebApplication4Context _context;

        public ItemsController(WebApplication4Context context)
        {
            _context = context;
        }



        public async Task<IActionResult> Search(string searchTerm)
        {

            //Finds all the products in the database whose name contains the search term which is passed into the search method storing it in a variable.
            var Results = _context.Item.Where(i => i.Name.Contains(searchTerm)).Include(i => i.Categorys);
            //Stores the categorys in the database in the viewbag.
            ViewBag.Category = _context.Category;
            //reutrn the Index view passing the reuslts.
            return View("Index", await Results.ToListAsync());
        }


        public async Task<IActionResult> FilterByCategroy(string category)
        {

            //Finds all the products in the database whose category name matches the category passed into the method 
            var Results = _context.Item.Where(i => i.Categorys.Name == category).Include(i => i.Categorys);
            //Stores the categorys in the database in the viewbag.
            ViewBag.Category = _context.Category;
            //reutrn the Index view passing the reuslts.
            return View("Index", await Results.ToListAsync());


        }













        // GET: Items
        public async Task<IActionResult> Index(int itemId = 1, bool displayPopUp = false)

        {
            ViewBag.Item = _context.Item.Where(a => a.ItemId == itemId ).FirstOrDefault();
            //Stores the value of the display pop-up boolean in the view bag 
            ViewBag.displayPopUp = displayPopUp;
            //Stores the categorys in the database in the viewbag.
            ViewBag.Category = _context.Category;

            return View(await _context.Item.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,Name,Price,CostToProduce,ImageURL,Description")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Name,Price,CostToProduce,ImageURL,Description")] Item item)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemId))
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
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemId == id);
        }
    }
}
