﻿using System;
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
using System.IO;
namespace ScheduleMusicPractice.Controllers
{

    public class PracticeSessionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<User> _userManager;
        public PracticeSessionsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = context;
        }
        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        // GET: PracticeSessions
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();
            var applicationDbContext = _context.PracticeSession.Include(p => p.Instrument).Include(p => p.PracticeMethod).Include(p => p.user).Where(p=> p.UserId == user.Id).OrderBy(item => item.dateTime);
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PracticeSessions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practiceSession = await _context.PracticeSession
                .Include(p => p.Instrument)
                .Include(p => p.PracticeMethod)
                .Include(p => p.user)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (practiceSession == null)
            {
                return NotFound();
            }

            return View(practiceSession);
        }

        // GET: PracticeSessions/Create
        public IActionResult Create()
        {
            ScheduleASession vm = new ScheduleASession();
            vm.ListOfInstruments = _context.Instrument.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();
            vm.ListOfPracticeMethods = _context.PracticeMethod.Select(i => new SelectListItem
            {
                Value = i.Id.ToString(),
                Text = i.Name
            }).ToList();
            vm.ListOfInstruments.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose an Instrument"
            });
            vm.ListOfPracticeMethods.Insert(0, new SelectListItem()
            {
                Value = "0",
                Text = "Please choose your method of Practicing"
            });
            return View(vm);
        }

        // POST: PracticeSessions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleASession vm)
        {
            ModelState.Remove("PracticeSession.UserId");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                vm.practiceSession.UserId = user.Id;
                _context.Add(vm.practiceSession);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = vm.practiceSession.Id.ToString() });
            }
         return View(vm);
        }

        // GET: PracticeSessions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practiceSession = await _context.PracticeSession.FindAsync(id);
            if (practiceSession == null)
            {
                return NotFound();
            }
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Id", practiceSession.InstrumentId);
            ViewData["PracticeMethodId"] = new SelectList(_context.PracticeMethod, "Id", "Id", practiceSession.PracticeMethodId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", practiceSession.UserId);
            return View(practiceSession);
        }

        // POST: PracticeSessions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,dateTime,InstrumentId,PracticeMethodId")] PracticeSession practiceSession)
        {
            if (id != practiceSession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(practiceSession);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracticeSessionExists(practiceSession.Id))
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
            ViewData["InstrumentId"] = new SelectList(_context.Instrument, "Id", "Id", practiceSession.InstrumentId);
            ViewData["PracticeMethodId"] = new SelectList(_context.PracticeMethod, "Id", "Id", practiceSession.PracticeMethodId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", practiceSession.UserId);
            return View(practiceSession);
        }

        // GET: PracticeSessions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practiceSession = await _context.PracticeSession
                .Include(p => p.Instrument)
                .Include(p => p.PracticeMethod)
                .Include(p => p.user)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (practiceSession == null)
            {
                return NotFound();
            }

            return View(practiceSession);
        }

        // POST: PracticeSessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var practiceSession = await _context.PracticeSession.FindAsync(id);
            _context.PracticeSession.Remove(practiceSession);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracticeSessionExists(int id)
        {
            return _context.PracticeSession.Any(e => e.Id == id);
        }
    }
}
