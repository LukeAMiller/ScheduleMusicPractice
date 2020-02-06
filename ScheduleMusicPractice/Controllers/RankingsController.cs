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
        //userManager to get current user and his/her Id
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
            //creating new instance of a view model to present Count of upvotes in each category and current user's Rating
            RankingViewModel vm = new RankingViewModel();
            var user = await GetCurrentUserAsync();
            vm.rank = await _context.Ranking
                .Include(r => r.User).Where(r => r.User == user)
                .Include(r => r.learningMaterial).Include(r => r.learningMaterial.instrument).Include(r => r.learningMaterial.rankings)
                .FirstOrDefaultAsync(r => r.LearningMaterialId == id);
            //where the learning materials id of the ranking equals the give id parameter
            vm.user = user;
            //getting the correct information for the view model to have when it is presented to the user if the rank exists
            if (vm.rank != null)
            {
                vm.rankingLevel = await _context.RankingLevel.FirstOrDefaultAsync(r => r.RankingId == vm.rank.Id);

                //first i get the entries in the join table that have Correct LevelId and the ranking from join table has correct LM id and turn it into a list

                var beginner = await _context.RankingLevel.Where(rl => rl.LevelId == 1 && rl.ranking.LearningMaterialId == vm.rank.LearningMaterialId).ToListAsync();
                //then i get the count of the list i created and put it in the view model
                vm.BeginnerCount = beginner.Count();
                //i rinse and repeat this process for each category
                var intermediate = await _context.RankingLevel.Where(rl => rl.LevelId == 2 && rl.ranking.LearningMaterialId == vm.rank.LearningMaterialId).ToListAsync();
                vm.IntermediateCount = intermediate.Count();
                var advanced = await _context.RankingLevel.Where(rl => rl.LevelId == 3 && rl.ranking.LearningMaterialId == vm.rank.LearningMaterialId).ToListAsync();
                vm.AdvancedCount = advanced.Count();
                var Pro = await _context.RankingLevel.Where(rl => rl.LevelId == 4 && rl.ranking.LearningMaterialId == vm.rank.LearningMaterialId).ToListAsync();
                vm.ProCount = Pro.Count();
            }
            if (vm.rank == null)
            {
                return NotFound();
            }

            return View(vm);
        }

        // GET: Rankings/Create
        public IActionResult Create(int id)
        {
            //new instance of view model
            RankingViewModel vm = new RankingViewModel();
            // select list for each level 
     vm.Levels = _context.Level.Select(i => new SelectListItem
     {
         Value = i.Id.ToString(),
         Text = i.Name
     }).ToList();
            //a new instance of rank
            vm.rank = new Ranking();
            //setting the LM id to Param
            vm.rank.LearningMaterialId = id;
            //selected multiselect list
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
            //removing userid from state to make modelstate valid
            ModelState.Remove("Rank.UserId");
            if (ModelState.IsValid)
            {
               //setting user and user id to current user
                var user = await GetCurrentUserAsync();
                vm.rank.UserId = user.Id;
                // a new ranking level instance in view model
                vm.rankingLevel = new RankingLevel();
                _context.Add(vm.rank);

                await _context.SaveChangesAsync();
                //if the user selected one or more levels for learning materials add one or more ranking levels to database join table
                if (vm.SelectedLevelId != null)
                {
                    foreach (var rl in vm.SelectedLevelId)
                    {
                        var newRankingLevel = new RankingLevel();
                        newRankingLevel.RankingId = vm.rank.Id;
                        newRankingLevel.LevelId = rl;
                        _context.Add(newRankingLevel);
                    }
                }
               
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "LearningMaterials");
            }
     
            return View(vm);
        }

      

        // GET: Rankings/Edit/5
        //basically the same code as create
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
//makes sure that the rank exists
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

                    if (vm.SelectedLevelId != null)
                    {
                        foreach (var rl in vm.SelectedLevelId)
                        {
                            var newRankingLevel = new RankingLevel();
                            newRankingLevel.RankingId = vm.rank.Id;
                            newRankingLevel.LevelId = rl;
                            _context.Update(newRankingLevel);
                        }
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
