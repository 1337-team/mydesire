using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mydesire.Data;
using mydesire.Models;

namespace mydesire.Controllers
{
    [Authorize]
    public class WishesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
            
        public WishesController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        [AllowAnonymous]
        // GET: Wishes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Wishes.Include(w => w.Perfomer).Include(w => w.Status);
            return View(await applicationDbContext.ToListAsync());
        }

        [AllowAnonymous]
        // GET: Wishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wish = await _context.Wishes
                .Include(w => w.Perfomer)
                .Include(w => w.Status)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (wish == null)
            {
                return NotFound();
            }

            return View(wish);
        }
        public async Task<IActionResult> Perform(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wish = await _context.Wishes
                .Include(w => w.Perfomer)
                .Include(w => w.Status)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (wish == null)
            {
                return NotFound();
            }

            wish.Perfomer = await _userManager.GetUserAsync(User);
            wish.Status = await _context.Statuses.SingleOrDefaultAsync(s => s.Name == "Выполняется");

            //TODO: мб сделать спец. страницу, что-то типа "Грац, теперь иди выполняй!" ну или всплывашку такую
            return RedirectToAction(nameof(Index));
        }


        // GET: Wishes/Create
        public IActionResult Create()
        {
            ViewData["PerfomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id");
            return View();
        }

        // POST: Wishes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Photo,OpenDate,CloseDate")] Wish wish)
        {
            if (ModelState.IsValid)
            {
                wish.Issuer = await _userManager.GetUserAsync(User);
                wish.Status = await _context.Statuses.SingleOrDefaultAsync(s => s.Name == "Ожидает исполнителя");

                _context.Add(wish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["StatusSelectList"] = new SelectList(_context.Statuses, "Id", "Name", wish.StatusId);
            return View(wish);
        }

        // GET: Wishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wish = await _context.Wishes.SingleOrDefaultAsync(m => m.Id == id);
            if (wish == null)
            {
                return NotFound();
            }
            ViewData["PerfomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wish.PerfomerId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", wish.StatusId);
            return View(wish);
        }

        // POST: Wishes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Photo,OpenDate,CloseDate,StatusId,PerfomerId")] Wish wish)
        {
            if (id != wish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishExists(wish.Id))
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
            ViewData["PerfomerId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wish.PerfomerId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "Id", wish.StatusId);
            return View(wish);
        }

        // GET: Wishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wish = await _context.Wishes
                .Include(w => w.Perfomer)
                .Include(w => w.Status)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (wish == null)
            {
                return NotFound();
            }

            return View(wish);
        }

        // POST: Wishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wish = await _context.Wishes.SingleOrDefaultAsync(m => m.Id == id);
            _context.Wishes.Remove(wish);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishExists(int id)
        {
            return _context.Wishes.Any(e => e.Id == id);
        }
    }
}
