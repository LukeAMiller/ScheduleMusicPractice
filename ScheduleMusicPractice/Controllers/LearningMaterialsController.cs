using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScheduleMusicPractice.Data;
using ScheduleMusicPractice.Models;
using ScheduleMusicPractice.Models.ViewModels;

namespace ScheduleMusicPractice.Controllers
{
    public class LearningMaterialsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<User> _userManager;
        public LearningMaterialsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: LearningMaterials
        public async Task<IActionResult> Index()
        { var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.LearningMaterial.Include(l => l.instrument).Include(l => l.rankings);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LearningMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningMaterial = await _context.LearningMaterial
                .Include(l => l.instrument)
                .FirstOrDefaultAsync(m => m.id == id);
            if (learningMaterial == null)
            {
                return NotFound();
            }

            return View(learningMaterial);
        }

        // GET: LearningMaterials/Create
        public IActionResult Create()
        {
            LearningMaterialViewModel vm = new LearningMaterialViewModel();
            vm.instruments = _context.Instrument.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();
            vm.instruments.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose an Instrument"
            });

            return View(vm);
        }

        // POST: LearningMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LearningMaterialViewModel vm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vm.learningMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Id", vm.learningMaterial.instrument.Name);
            return View(vm.learningMaterial);
        }

        // GET: LearningMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LearningMaterialViewModel vm = new LearningMaterialViewModel();
            var learningMaterial = await _context.LearningMaterial.FindAsync(id);
            if (learningMaterial == null)
            {
                return NotFound();
            }
            vm.learningMaterial = learningMaterial;
            vm.instruments = _context.Instrument.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name

            }).ToList();
            vm.instruments.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose an Instrument"
            });
            return View(vm);
        }

        // POST: LearningMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, LearningMaterialViewModel vm)
        {
            if (id != vm.learningMaterial.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vm.learningMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearningMaterialExists(vm.learningMaterial.id))
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
         return View(vm.learningMaterial);
        }

        // GET: LearningMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learningMaterial = await _context.LearningMaterial
                .Include(l => l.instrument)
                .FirstOrDefaultAsync(m => m.id == id);
            if (learningMaterial == null)
            {
                return NotFound();
            }

            return View(learningMaterial);
        }

        // POST: LearningMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var learningMaterial = await _context.LearningMaterial.FindAsync(id);
            _context.LearningMaterial.Remove(learningMaterial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LearningMaterialExists(int id)
        {
            return _context.LearningMaterial.Any(e => e.id == id);
        }
    }
}
