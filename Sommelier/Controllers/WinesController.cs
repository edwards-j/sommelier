using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sommelier.Data;
using Sommelier.Models;
using Sommelier.Models.ViewModels;

namespace Sommelier.Controllers
{
    public class WinesController : Controller
    {
        // Create variable to represent database
        private readonly ApplicationDbContext _context;

        // Create variable to represent User Data
        private readonly UserManager<ApplicationUser> _userManager;


        // Pass in arguments from private varaibles to be used publicly
        public WinesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // Create component to get current user from the _userManager variable
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Wines
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await GetCurrentUserAsync();

            var view = _context.Wine
                .Include(w => w.Winery)
                .Include(w => w.Variety);

            return View(await view.ToListAsync());  
        }

        // GET: Wines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine
                .Include(w => w.Winery)
                .Include(w => w.Variety)
                .FirstOrDefaultAsync(m => m.WineId == id);
            if (wine == null)
            {
                return NotFound();
            }

            return View(wine);
        }

        // GET: Wines/Create
        public async Task<IActionResult> Create()
        {
            //Gets current user and assigns them to a variable
            ApplicationUser user = await GetCurrentUserAsync();

            //Get all of the varieties from the database
            var AllVarieties = _context.Variety;

            //Get all of the wineries from the database
            var AllWineries = _context.Winery;

            //Create a select list of varieties
            List<SelectListItem> Varieties = new List<SelectListItem>();

            //Create a select list of wineries
            List<SelectListItem> Wineries = new List<SelectListItem>();

            //Create a view model
            CreateWineViewModel viewModel = new CreateWineViewModel();

            viewModel.User = user;

            // Loop over all of the varieties from the database
            foreach (var v in AllVarieties)
            {
                // Create a new select list item of li
                SelectListItem li = new SelectListItem
                {
                    // Give a value to li
                    Value = v.VarietyId.ToString(),
                    // Provide text to li
                    Text = v.Name
                };
                // Add li to Varieties list
                Varieties.Add(li);
            }

            //Attach the select list items to view model
            viewModel.Varieties = Varieties;

            // Loop over all of the wineries from the database
            foreach (var w in AllWineries)
            {
                // Create a new select list item of li
                SelectListItem li = new SelectListItem
                {
                    // Give a value to li
                    Value = w.WineryId.ToString(),
                    // Provide text to li
                    Text = w.Name
                };
                // Add li to Varieties list
                Wineries.Add(li);
            }

            // Insert starting position into varieties list
            Varieties.Insert(0, new SelectListItem
            {
                Text = "Assign a variety...",
                Value = ""
            });

            // Insert starting position into winery list
            Wineries.Insert(0, new SelectListItem
            {
                Text = "Assign a winery...",
                Value = ""
            });

            //Attach the select list items to view model
            viewModel.Wineries = Wineries;

            ViewData["User"] = new SelectList(_context.Users, "Id", "Id");

            //Pass view model to view
            return View(viewModel);
        }

        // POST: Wines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(CreateWineViewModel newWine)
        {
            var user = await GetCurrentUserAsync();

            // If the user is already in the ModelState
            // Remove user from model state
            ModelState.Remove("wine.User");
            ModelState.Remove("newWine.Wine.User");

            // If model state is valid
            if (ModelState.IsValid)
            {
                // Add the user back
                newWine.Wine.ApplicationUserId = user.Id;

                // Add the wine
                _context.Add(newWine.Wine);

                // Save changes to database
                await _context.SaveChangesAsync();

                // Redirect to details view with id of product made using new object
                return RedirectToAction(nameof(Details), new { id = newWine.Wine.WineId.ToString() });
            }
            return View(newWine);
        }

        // POST: Wines/CreateWinery
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> CreateWinery(CreateWineViewModel newWine)
        {
            var user = await GetCurrentUserAsync();

            // If the user is already in the ModelState
            // Remove user from model state
            ModelState.Remove("wine.User");
            ModelState.Remove("newWine.Wine.User");

            // If model state is valid
            if (ModelState.IsValid)
            {
                //If a user enters a new winery name
                if (newWine.Winery.Name != null)
                {
                    //Add that winery to the database
                    _context.Add(newWine.Winery);

                    await _context.SaveChangesAsync();
                }
                // Redirect to details view with id of product made using new object
                return RedirectToAction(nameof(Create));
            }
            return View(newWine);
        }

        // GET: Wines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine.FindAsync(id);
            if (wine == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wine.ApplicationUserId);
            return View(wine);
        }

        // POST: Wines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WineId,Name,WineryId,VarietyId,Year,ApplicationUserId,Favorite,Quantity")] Wine wine)
        {
            if (id != wine.WineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WineExists(wine.WineId))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wine.ApplicationUserId);
            return View(wine);
        }

        // GET: Wines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wine = await _context.Wine
                .Include(w => w.ApplicationUser)
                .Include(w => w.Winery)
                .Include(w => w.Variety)
                .FirstOrDefaultAsync(m => m.WineId == id);
            if (wine == null)
            {
                return NotFound();
            }

            return View(wine);
        }

        // POST: Wines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wine = await _context.Wine.FindAsync(id);
            _context.Wine.Remove(wine);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WineExists(int id)
        {
            return _context.Wine.Any(e => e.WineId == id);
        }
    }
}
