using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication4.Controllers
{
    public class ItemsController : Controller
    {
        private readonly WebApplication4Context _context;

        public ItemsController(WebApplication4Context context)
        {
            _context = context;
        }

        // Decalres the constant number of Items Per Page as 6
        public const int ITEMSPERPAGE = 6;

        public async Task<IActionResult> Index(int page = 1, int itemId = 1, bool displayPopUp = false, bool displaySizePicker = false)
        {
            ViewBag.displaySizePicker = displaySizePicker;






            //Finds the item in the database where the item has an id that matches the ItemId passed into the method and stores it the he view bag
            ViewBag.Item = _context.Item.Where(a => a.ItemId == itemId).FirstOrDefault();
            //Stores the value of the display pop-up boolean in the view bag 
            ViewBag.displayPopUp = displayPopUp;
            //Find all the items in the database as well as their category stored in a variable called items
            var Items = _context.Item.Include(i => i.Categorys);

            //Calculates the number of pages needed based on the number of products in the database.
            ViewBag.Pages = (int)Math.Ceiling((double)Items.Count() / ITEMSPERPAGE);

            //Stores the number of pages needed in the view bag.
            ViewBag.PageNUmber = page;

            //Stores the categorys in the database in the viewbag.
            ViewBag.Category = _context.Category;

            //Return the index view, skip the (page number passed into the method) -1 * 6 amount of items. Then take 6 items to list on the items view/page.
            return View(await Items.Skip((page - 1) * ITEMSPERPAGE).Take(ITEMSPERPAGE).ToListAsync());

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
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
     
        public async Task<IActionResult> Create([Bind("ItemId,Name,Price,CostToProduce,Description,CategoryId")] Item item, IFormFile Image)
        {
            item.ImageURL = "null";
            // Process the image if one was uploaded.
            if (Image != null && Image.Length > 0)
            {
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Ensure wwwroot/images exists.
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                item.ImageURL = "/images/" + fileName;  // Use forward slash for URLs.

            }


            if (!ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(item);
        }


        // GET: Items/Edit/5
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

            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "Name", item.CategoryId);
            return View(item);
        }

        // POST: Items/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Name,Price,CostToProduce,ImageURL,Description,CategoryId")] Item item, IFormFile Image)
        {
            if (id != item.ItemId)
            {
                return NotFound();
            }

            item.ImageURL = "null";
            // Process the image if one was uploaded.
            if (Image != null && Image.Length > 0)
            {
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                // Ensure wwwroot/images exists.
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                item.ImageURL = "/images/" + fileName;  // Use forward slash for URLs.

                _context.SaveChangesAsync();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Item.Any(e => e.ItemId == item.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

           
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "Name", item.CategoryId);
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
