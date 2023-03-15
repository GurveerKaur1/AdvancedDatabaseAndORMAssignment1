using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedDatabaseAndORMAssignment1.Data;
using AdvancedDatabaseAndORMAssignment1.Models;

namespace AdvancedDatabaseAndORMAssignment1.Controllers
{
    public class SongContributorsController : Controller
    {
        private readonly AdvancedDatabaseAndORMAssignment1Context _context;

        public SongContributorsController(AdvancedDatabaseAndORMAssignment1Context context)
        {
            _context = context;
        }

        // GET: SongContributors
        public async Task<IActionResult> Index()
        {
            var advancedDatabaseAndORMAssignment1Context = _context.SongContributor.Include(s => s.Artist).Include(s => s.Song);
            return View(await advancedDatabaseAndORMAssignment1Context.ToListAsync());
        }

        // GET: SongContributors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SongContributor == null)
            {
                return NotFound();
            }

            var songContributor = await _context.SongContributor
                .Include(s => s.Artist)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songContributor == null)
            {
                return NotFound();
            }

            return View(songContributor);
        }

        // GET: SongContributors/Create
        public IActionResult Create()
        {
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id");
            ViewData["SongId"] = new SelectList(_context.Song, "Id", "Id");
            return View();
        }

        // POST: SongContributors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArtistId,SongId")] SongContributor songContributor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(songContributor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", songContributor.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Song, "Id", "Id", songContributor.SongId);
            return View(songContributor);
        }

        // GET: SongContributors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SongContributor == null)
            {
                return NotFound();
            }

            var songContributor = await _context.SongContributor.FindAsync(id);
            if (songContributor == null)
            {
                return NotFound();
            }
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", songContributor.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Song, "Id", "Id", songContributor.SongId);
            return View(songContributor);
        }

        // POST: SongContributors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArtistId,SongId")] SongContributor songContributor)
        {
            if (id != songContributor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(songContributor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongContributorExists(songContributor.Id))
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
            ViewData["ArtistId"] = new SelectList(_context.Artist, "Id", "Id", songContributor.ArtistId);
            ViewData["SongId"] = new SelectList(_context.Song, "Id", "Id", songContributor.SongId);
            return View(songContributor);
        }

        // GET: SongContributors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SongContributor == null)
            {
                return NotFound();
            }

            var songContributor = await _context.SongContributor
                .Include(s => s.Artist)
                .Include(s => s.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (songContributor == null)
            {
                return NotFound();
            }

            return View(songContributor);
        }

        // POST: SongContributors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SongContributor == null)
            {
                return Problem("Entity set 'AdvancedDatabaseAndORMAssignment1Context.SongContributor'  is null.");
            }
            var songContributor = await _context.SongContributor.FindAsync(id);
            if (songContributor != null)
            {
                _context.SongContributor.Remove(songContributor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongContributorExists(int id)
        {
          return _context.SongContributor.Any(e => e.Id == id);
        }
    }
}
