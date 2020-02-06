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
    public class RankingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<User> _userManager;
        public RankingsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: Rankings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Ranking.Include(r => r.User).Include(r => r.learningMaterial);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Rankings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            RankingViewModel vm = new RankingViewModel();
            var user = await GetCurrentUserAsync();
            vm.rank = await _context.Ranking
                .Include(r => r.User).Where(r => r.User == user)
                .Include(r => r.learningMaterial).Include(r => r.learningMaterial.instrument).Include(r => r.learningMaterial.rankings)
                .FirstOrDefaultAsync(r => r.LearningMaterialId == id);
            
            vm.user = user;
            vm.rankingLevel = await _context.RankingLevel.FirstOrDefaultAsync(r => r.RankingId == vm.rank.Id);
            var beginner = await _context.RankingLevel.Where(rl => rl.LevelId == 1 && rl.ranking.LearningMaterialId == vm.rank.LearningMaterialId).ToListAsync();
                vm.BeginnerCount = beginner.Count();
            var intermediate = await _context.RankingLevel.Where(rl => rl.LevelId == 2 && rl.ranking.LearningMaterialId == vm.rank.LearningMaterialId).ToListAsync();
            vm.IntermediateCount = intermediate.Count();
            var advanced = await _context.RankingLevel.Where(rl => rl.LevelId == 3 && rl.ranking.LearningMaterialId == vm.rank.LearningMaterialId).ToListAsync();
            vm.AdvancedCount = advanced.Count();
            var Pro = await _context.RankingLevel.Where(rl => rl.LevelId == 4 && rl.ranking.LearningMaterialId == vm.rank.LearningMaterialId).ToListAsync();
            vm.ProCount = Pro.Count();
            if (vm.rank == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: Rankings/Create
        public IActionResult Create(int id)
        {
            RankingViewModel vm = new RankingViewModel();
     vm.Levels = _context.Level.Select(i => new SelectListItem
     {
         Value = i.Id.ToString(),
         Text = i.Name
     }).ToList();
            vm.Levels.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose one or more levels that you believe this is good for"
            });
            vm.rank = new Ranking();
            vm.rank.LearningMaterialId = id;
            vm.SelectedLevelId = _context.RankingLevel.Include(rl => rl.Level).Where(rl => rl.RankingId == vm.rank.Id).Select(rl => rl.LevelId).ToList();
            return View(vm);
        }

        // POST: Rankings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, RankingViewModel vm)
        {
            ModelState.Remove("Rank.UserId");
            if (ModelState.IsValid)
            {
               
                var user = await GetCurrentUserAsync();
                vm.rank.UserId = user.Id;
                vm.rankingLevel = new RankingLevel();
                _context.Add(vm.rank);

                await _context.SaveChangesAsync();
                foreach (var rl in vm.SelectedLevelId)
                {
                    var newRankingLevel = new RankingLevel();
                    newRankingLevel.RankingId = vm.rank.Id;
                    newRankingLevel.LevelId = rl;
                          _context.Add(newRankingLevel);
                }
               
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "LearningMaterials");
            }
     
            return View(vm);
        }

      

        // GET: Rankings/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            RankingViewModel vm = new RankingViewModel();
            vm.Levels = _context.Level.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();
            vm.Levels.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose one or more levels that you believe this is good for"
            });
            vm.rank = new Ranking();
            vm.rank.LearningMaterialId = id;
            vm.SelectedLevelId = _context.RankingLevel.Include(rl => rl.Level).Where(rl => rl.RankingId == vm.rank.Id).Select(rl => rl.LevelId).ToList();
            vm.rank = await _context.Ranking.FindAsync(id);
            if (vm.rank == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: Rankings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, RankingViewModel vm)
        {
            if (id != vm.rank.Id)
            {
                return NotFound();
            }
            
            ModelState.Remove("UserId");
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await GetCurrentUserAsync();
                    vm.rank.UserId = user.Id;
                    _context.Update(vm.rank);
                    await _context.SaveChangesAsync();
                    foreach (var rl in vm.SelectedLevelId)
                    {
                        var newRankingLevel = new RankingLevel();
                        newRankingLevel.RankingId = vm.rank.Id;
                        newRankingLevel.LevelId = rl;
                        _context.Update(newRankingLevel);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RankingExists(vm.rank.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "LearningMaterials");
            }
            return View(vm);
        }

        // GET: Rankings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ranking = await _context.Ranking
                .Include(r => r.User)
                .Include(r => r.learningMaterial)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ranking == null)
            {
                return NotFound();
            }

            return View(ranking);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ranking = await _context.Ranking.FindAsync(id);
            _context.Ranking.Remove(ranking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RankingExists(int id)
        {
            return _context.Ranking.Any(e => e.Id == id);
        }
    }
}
