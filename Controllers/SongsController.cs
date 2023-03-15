using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdvancedDatabaseAndORMAssignment1.Data;
using AdvancedDatabaseAndORMAssignment1.Models;
using AdvancedDatabaseAndORMAssignment1.Models.ViewModel;

namespace AdvancedDatabaseAndORMAssignment1.Controllers
{
    public class SongsController : Controller
    {
        private readonly AdvancedDatabaseAndORMAssignment1Context _context;

        public SongsController(AdvancedDatabaseAndORMAssignment1Context context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            var advancedDatabaseAndORMAssignment1Context = _context.Song.Include(s => s.Album);
            return View(await advancedDatabaseAndORMAssignment1Context.ToListAsync());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Id");
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,DurationSeconds,AlbumId")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Id", song.AlbumId);
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Id", song.AlbumId);
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,DurationSeconds,AlbumId")] Song song)
        {
            if (id != song.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.Id))
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
            ViewData["AlbumId"] = new SelectList(_context.Set<Album>(), "Id", "Id", song.AlbumId);
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        public async Task<IActionResult> DeleteSongs(int? id)
        {
            if (id == null || _context.Song == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .Include(s => s.Album)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Song == null)
            {
                return Problem("Entity set 'AdvancedDatabaseAndORMAssignment1Context.Song'  is null.");
            }
            var song = await _context.Song.FindAsync(id);
            if (song != null)
            {
                _context.Song.Remove(song);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> AddToPlayList(int Id)
        {
            AddToPlaylistVM vm = new AddToPlaylistVM(_context.PlayList.ToList(), Id);
            return View(vm);

        }

        [HttpPost]

        public async Task<IActionResult> AddToPlayList(AddToPlaylistVM vm , int Id)
        {
            if(vm.PlayListId != null || vm.SongId != null)
            {
                if(!_context.PlayListSong.Any(ca => ca.PlayListId == vm.PlayListId && ca.SongId == Id ))
                {
                    PlayListSong playListSong = new PlayListSong();
                    PlayList playList = _context.PlayList.First(p => p.Id == vm.PlayListId);
                    Song song = _context.Song.First(s => s.Id == Id);

                    playListSong.PlayList = playList;
                    playListSong.Song = song;

                    _context.PlayListSong.Add(playListSong);
                   await _context.SaveChangesAsync();
                    vm.ViewMessage = $"Successfully added  to {playList.Name}";
                }
                else
                {
                    vm.ViewMessage = "Selected Song already added to selectd playlist";
                }
                vm.PopulateLists(_context.PlayList.ToList());
                return View(vm);
            }
            else
            {
                throw new Exception("Error");
            }

         
        }

        private bool SongExists(int id)
        {
          return _context.Song.Any(e => e.Id == id);
        }
    }
}
