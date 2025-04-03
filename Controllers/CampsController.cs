using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class CampsController : Controller
    {
        private readonly WebApplication4Context _context;

        public CampsController(WebApplication4Context context)
        {
            _context = context;
        }

        // GET: Camps

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = _context.Users.Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).First();
            var Camp = _context.Camp.Where(a => a.Year == user.YearLevel);
            return View(await Camp.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camp == null)
            {
                return NotFound();
            }

            ViewBag.studentsOnCamp = _context.Users.Where(a => a.CampId == id);

           


            

          

            return View(camp);
        }

        [Authorize]
        public async Task<IActionResult> Book(int Id)
        {
            var user = _context.Users.Where(a => a.Id == User.FindFirstValue(ClaimTypes.NameIdentifier)).First();

            user.CampId = Id;

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");

        }

        private async Task RedirectToAction(Func<Task<IActionResult>> index)
        {
            throw new NotImplementedException();
        }

        // GET: Camps/Create

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Camps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Startdate,peoplelimt,Year")] Camp camp)
        {
            if (!ModelState.IsValid)
            {
                camp.Enddate = camp.Startdate.AddDays(5);
                _context.Add(camp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(camp);
        }

        // GET: Camps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp.FindAsync(id);
            if (camp == null)
            {
                return NotFound();
            }
            return View(camp);
        }

        // POST: Camps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Startdate,Enddate,peoplelimt,Year")] Camp camp)
        {
            if (id != camp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(camp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampExists(camp.Id))
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
            return View(camp);
        }

        // GET: Camps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var camp = await _context.Camp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (camp == null)
            {
                return NotFound();
            }

            return View(camp);
        }

        // POST: Camps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var camp = await _context.Camp.FindAsync(id);
            if (camp != null)
            {
                _context.Camp.Remove(camp);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampExists(int id)
        {
            return _context.Camp.Any(e => e.Id == id);
        }
    }
}
