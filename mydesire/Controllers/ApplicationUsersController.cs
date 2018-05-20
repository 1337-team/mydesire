using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace mydesire.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authorization;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using mydesire.Data;
    using mydesire.Models;
    using Microsoft.AspNetCore.Identity;

    namespace isudns.Controllers
    {
        [Authorize]
        public class ApplicationUsersController : Controller
        {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public ApplicationUsersController(UserManager<ApplicationUser> userManager,
                RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
            {
                _context = context;
                _userManager = userManager;
                _roleManager = roleManager;
            }

            // GET: ApplicationUsers
            [Authorize(Roles = "admin")]
            public async Task<IActionResult> Index()
            {
                return View(await _context.ApplicationUsers
                    //.Where(u => u.UserName != "admin@gmail.com")
                    .OrderByDescending(u => u.Rating)
                    .ToListAsync());
            }

            [AllowAnonymous]
            // GET: ApplicationUsers/Details/5
            public async Task<IActionResult> Details(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var applicationUser = await _context.ApplicationUsers
                    .Include(u => u.MyWishes)
                        .ThenInclude(w => w.Status)

                    .Include(u => u.MyWishesToPerform)
                        .ThenInclude(w => w.Issuer)
                    .Include(u => u.MyWishesToPerform)
                        .ThenInclude(w => w.Status)

                    .SingleOrDefaultAsync(m => m.Id == id);
                if (applicationUser == null)
                {
                    return NotFound();
                }

                return View(applicationUser);
            }


            // GET: ApplicationUsers/Edit/5
            public async Task<IActionResult> Edit(string id)
            {
                //if (id != User?.Claims?.Where(c => c?.Type == "nameidentifier").SingleOrDefault().Value)
                //    return Json("q");
                if (!(_userManager.GetUserId(User) == id || User.IsInRole("admin")))
                {
                    return RedirectToAction("AccessDenied", "Account");
                }
                if (id == null)
                {
                    return NotFound();
                }

                var applicationUser = await _context.ApplicationUsers/*.Include(u => u.Articles)*/.SingleOrDefaultAsync(m => m.Id == id);
                if (applicationUser == null)
                {
                    return NotFound();
                }
                return View(applicationUser);
            }

            // POST: ApplicationUsers/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(string id, /*[Bind("Name,Position,DateOfBirth,JobStartDate,Rating")]*/ ApplicationUser applicationUser)
            {
                if (id != applicationUser.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //applicationUser.ConcurrencyStamp = Guid.NewGuid().ToString();
                        //applicationUser.ConcurrencyStamp = null;

                        _context.Update(applicationUser);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ApplicationUserExists(applicationUser.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Details), new { id });
                }
                return View(applicationUser);
            }

            [Authorize(Roles = "admin")]
            // GET: ApplicationUsers/Delete/5
            public async Task<IActionResult> Delete(string id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var applicationUser = await _context.ApplicationUsers
                    .SingleOrDefaultAsync(m => m.Id == id);
                if (applicationUser == null)
                {
                    return NotFound();
                }

                return View(applicationUser);
            }

            // POST: ApplicationUsers/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(string id)
            {
                var applicationUser = await _context.ApplicationUsers.SingleOrDefaultAsync(m => m.Id == id);
                _context.ApplicationUsers.Remove(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool ApplicationUserExists(string id)
            {
                return _context.ApplicationUsers.Any(e => e.Id == id);
            }
        }
    }

}