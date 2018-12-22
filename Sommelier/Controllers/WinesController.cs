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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ApplicationUser user = await GetCurrentUserAsync();

            List<Wine> view = await _context.Wine
                .Include(w => w.Variety)
                .Include(w => w.Winery)
                .OrderByDescending(w => w.WineId)
                .Where(w => w.ApplicationUserId == user.Id)
                .ToListAsync();

            return View(view);
        }

        // GET: Wines/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WineDetailsViewModel viewModel = new WineDetailsViewModel();

            var wine = await _context.Wine
                .Include(w => w.Winery)
                .Include(w => w.Variety)
                .FirstOrDefaultAsync(m => m.WineId == id);

            if (wine == null)
            {
                return NotFound();
            }

            var foods = await _context.Food
                .Include(f => f.FoodCategory)
                    .ThenInclude(fc => fc.Category)
                        .ThenInclude(c => c.Variety)
                            .ThenInclude(v => v.Wines)
                .Where(f => f.FoodCategory.Any(fc => fc.CategoryId == wine.Variety.CategoryId))
                .ToListAsync()
                ;

            viewModel.Wine = wine;
            viewModel.Foods = foods;

            return View(viewModel);
        }

        // GET: Wines/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            //Gets current user and assigns them to a variable
            ApplicationUser user = await GetCurrentUserAsync();

            //Get all of the varieties from the database
            var AllVarieties = _context.Variety;

            //Get all of the wineries from the database
            var AllWineries = _context.Winery.OrderBy(w => w.Name);

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
            Wineries.Insert(0, new SelectListItem
            {
                Text = "Select an existing winery...",
                Value = ""
            });

            // Insert starting position into varieties list
            Varieties.Insert(0, new SelectListItem
            {
                Text = "Assign a variety...",
                Value = ""
            });

            //Insert Wine categories to make options easier to read
            Varieties.Insert(1, new SelectListItem
            {
                Text = "--- Dry Whites ---",
                Value = ""
            });

            Varieties.Insert(7, new SelectListItem
            {
                Text = "--- Sweet Whites ---",
                Value = ""
            });

            Varieties.Insert(13, new SelectListItem
            {
                Text = "--- Rich Whites ---",
                Value = ""
            });

            Varieties.Insert(18, new SelectListItem
            {
                Text = "--- Sparkling ---",
                Value = ""
            });

            Varieties.Insert(23, new SelectListItem
            {
                Text = "--- Light Reds ---",
                Value = ""
            });

            Varieties.Insert(28, new SelectListItem
            {
                Text = "--- Medium Reds ---",
                Value = ""
            });

            Varieties.Insert(35, new SelectListItem
            {
                Text = "--- Bold Reds ---",
                Value = ""
            });

            Varieties.Insert(41, new SelectListItem
            {
                Text = "--- Dessert ---",
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

            //Checks to see if the newly added wine is already in the database 
            List<Wine> ExistingWine = await _context.Wine
                .Include(w => w.Variety)
                .Include(w => w.Winery)
                .Where(w => w.Name == newWine.Wine.Name && w.WineryId == newWine.Wine.WineryId && w.VarietyId == newWine.Wine.VarietyId && w.Year == newWine.Wine.Year)
                .Where(w => w.ApplicationUserId == user.Id)
                .ToListAsync();

            //If the wine already exists, this code allows the user to to update their current inventory with the amount of bottles they were going to add
            if(ExistingWine.Count > 0)
            {
                UpdateBottleCountViewModel viewModel = new UpdateBottleCountViewModel();

                viewModel.existingWine = ExistingWine;

                viewModel.newWine = newWine;

                return View("WineExists", viewModel);
            }

            //If the wine doesn't exist, add it to the database 
            if (ExistingWine.Count == 0)
            {
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

            var wine = await _context.Wine
                .Include(w => w.Winery)
                .Include(w => w.Variety)
                .FirstOrDefaultAsync(m => m.WineId == id);
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
        [Authorize]
        public async Task<IActionResult> Edit(int id, Wine wine)
        {
            if (id != wine.WineId)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();

            if (ModelState.IsValid)
            {
                try
                {
                    wine.ApplicationUserId = user.Id;

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

                WineDetailsViewModel viewModel = new WineDetailsViewModel();

                var updatedWine = await _context.Wine
                .Include(w => w.Winery)
                .Include(w => w.Variety)
                .FirstOrDefaultAsync(m => m.WineId == id);

                if (wine == null)
                {
                    return NotFound();
                }

                var foods = await _context.Food
                    .Include(f => f.FoodCategory)
                        .ThenInclude(fc => fc.Category)
                            .ThenInclude(c => c.Variety)
                                .ThenInclude(v => v.Wines)
                    .Where(f => f.FoodCategory.Any(fc => fc.CategoryId == updatedWine.Variety.CategoryId))
                    .ToListAsync()
                    ;

                viewModel.Wine = updatedWine;
                viewModel.Foods = foods;

                return View("Details", viewModel);
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.ApplicationUsers, "Id", "Id", wine.ApplicationUserId);
            return View(wine);
        }

        // GET: Wines/Delete/5
        [Authorize]
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
        [Authorize]
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

        //GET: Wines/RemoveFromCellar/5
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> RemoveBottleConfirm(int? id)
        {
            RemoveBottleConfirmViewModel viewModel = new RemoveBottleConfirmViewModel();

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

        //POST: Wines/RemoveFromCellar/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RemoveBottle(int id)
        {
            var wine = await _context.Wine.FindAsync(id);

            wine.Quantity--;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //GET: Wines?search="Pinot"
        public async Task<IActionResult> Search(string search)
        {
            ApplicationUser user = await GetCurrentUserAsync();

            SearchWineViewModel viewModel = new SearchWineViewModel();

            List<Wine> wines = await _context.Wine
                .Include(w => w.Variety)
                .Include(w => w.Winery)
                .OrderByDescending(w => w.WineId)
                .Where(w => w.ApplicationUserId == user.Id)
                .Where(w => w.Variety.Name.Contains(search) || w.Winery.Name.Contains(search))
                .ToListAsync();

            viewModel.Wines = wines;
            viewModel.searchTerm = search;

            return View(viewModel);
        }

        //POST:
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateQuantity(int id, UpdateBottleCountViewModel updatedWine)
        {
            var wine = await _context.Wine.FindAsync(id);

            wine.Quantity += updatedWine.newWine.Wine.Quantity;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
