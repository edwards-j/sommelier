using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Sommelier.Data;
using Sommelier.Models;
using Sommelier.Models.ViewModels;

namespace Sommelier.Controllers
{
    public class FoodsController : Controller
    {
        // Create variable to represent database
        private readonly ApplicationDbContext _context;

        // Create variable to represent User Data
        private readonly UserManager<ApplicationUser> _userManager;


        // Pass in arguments from private varaibles to be used publicly
        public FoodsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        // Create component to get current user from the _userManager variable
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Foods
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Food.ToListAsync());
        }

        // GET: Foods/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await GetCurrentUserAsync();

            FoodPairingViewModel viewModel = new FoodPairingViewModel();

            var food = await _context.Food
                .FirstOrDefaultAsync(m => m.FoodId == id);

            viewModel.Food = food;

            var wine = await _context.Wine
                .Where(w => w.ApplicationUserId == user.Id)
                .Include(w => w.Winery)
                .Include(w => w.Variety)
                    .ThenInclude(v => v.Category)
                        .ThenInclude(c => c.FoodCategory)
                        .Where(w => w.Variety.Category.FoodCategory.Any(fc => fc.FoodId == id))
                .ToListAsync()
                ;
                

            viewModel.Wines = wine;

            var Categories = await _context.FoodCategory
                .Include(fc => fc.Category)
                .Where(fc => fc.FoodId == id)
                .ToListAsync();

            List<string> names = Categories.Select(fc => fc.Category.Name).ToList();
            
            if (names.Count() == 2)
            {
                viewModel.FoodCategories = names.Join(" or ");
            }

            if (names.Count() > 2)
            {
                names.Insert(names.Count() - 1, "or");

                viewModel.FoodCategories = names.Join(", ");

                var lastComma = viewModel.FoodCategories.LastIndexOf(", ");

                viewModel.FoodCategories = viewModel.FoodCategories.Remove(lastComma, 1);
            }

            if (viewModel.Wines.Count == 0 && names.Count() == 2)
            {
                return View("NoWineFound", viewModel);
            } else if (viewModel.Wines.Count == 0)
            {
               

                viewModel.FoodCategories = names.Join(", ");

                var lastComma = viewModel.FoodCategories.LastIndexOf(", ");

                viewModel.FoodCategories = viewModel.FoodCategories.Remove(lastComma, 1);

                return View("NoWineFound", viewModel);
            }

            return View(viewModel);
        }
        

        // GET: Foods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FoodId,Name")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Food.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }

        // POST: Foods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FoodId,Name")] Food food)
        {
            if (id != food.FoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(food);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodExists(food.FoodId))
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
            return View(food);
        }

        // GET: Foods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Food
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await _context.Food.FindAsync(id);
            _context.Food.Remove(food);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodExists(int id)
        {
            return _context.Food.Any(e => e.FoodId == id);
        }
    }
}
