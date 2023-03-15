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
    public class PlayListsController : Controller
    {
        private readonly AdvancedDatabaseAndORMAssignment1Context _context;

        public PlayListsController(AdvancedDatabaseAndORMAssignment1Context context)
        {
            _context = context;
        }

        // GET: PlayLists
        public async Task<IActionResult> Index()
        {
              return View(await _context.PlayList.ToListAsync());
        }

        // GET: PlayLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PlayList == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList.Include(a => a.PlayListSongs).ThenInclude(a => a.Song)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playList == null)
            {
                return NotFound();
            }
            //var runTime = await _context.PlayList.ToListAsync().Sum(a => a.RunTime);
            return View(playList);
        }

        // GET: PlayLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlayLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] PlayList playList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(playList);
        }

        // GET: PlayLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PlayList == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList.FindAsync(id);
            if (playList == null)
            {
                return NotFound();
            }
            return View(playList);
        }

        // POST: PlayLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] PlayList playList)
        {
            if (id != playList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(playList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayListExists(playList.Id))
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
            return View(playList);
        }

        // GET: PlayLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PlayList == null)
            {
                return NotFound();
            }

            var playList = await _context.PlayList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (playList == null)
            {
                return NotFound();
            }

            return View(playList);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PlayList == null)
            {
                return Problem("Entity set 'AdvancedDatabaseAndORMAssignment1Context.PlayList'  is null.");
            }
            var playList = await _context.PlayList.FindAsync(id);
            if (playList != null)
            {
                _context.PlayList.Remove(playList);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       
        [HttpGet]
       public async Task<IActionResult> DeleteSongsInPlayList( int playListId, int songId)
        {
           // return View(vm);
           DeleteSongInPlayListVM vm = new DeleteSongInPlayListVM(playListId, songId);
            return View(vm);
           
        }

        [HttpPost]

        public async Task<IActionResult> DeleteSongsInPlayList(DeleteSongInPlayListVM vm, int playListId, int songId)
        {
            vm.SongId = songId;
            vm.PlayListId = playListId;
            if (vm.PlayListId != null || vm.SongId != null)
            {
                if (!_context.PlayListSong.Any(ca => ca.SongId == songId))
                {
                    PlayListSong playListSong = await _context.PlayListSong.FirstOrDefaultAsync(c => c.SongId == songId && c.PlayListId == playListId);
                  Song song = _context.Song.FirstOrDefault(c => c.Id == songId);
                  PlayList playList = _context.PlayList.FirstOrDefault(c => c.Id == playListId);

                    
                   
                    _context.Song.Remove(song);
                   await _context.SaveChangesAsync();


                    vm.ViewMessage = $"Successfully deleted {song.Title} ";


                }
                else
                {
                    vm.ViewMessage = "Selected song is deleted";
                }
                return View(vm);
        }
            else
            {
                throw new Exception("Error Message");
    }


}

        [HttpGet]

        public async Task<IActionResult> GetSongInArtist(int artistId, int albumId)
        {
            SongContributor songContributor = _context.SongContributor.FirstOrDefault(a => a.ArtistId == artistId && a.Song.AlbumId == albumId);

            GetSongInArtistVM vm = new GetSongInArtistVM(_context.Song.ToList(), artistId, albumId);
            return View(vm);
        }
        private bool PlayListExists(int id)
        {
          return _context.PlayList.Any(e => e.Id == id);
        }
    }
}
