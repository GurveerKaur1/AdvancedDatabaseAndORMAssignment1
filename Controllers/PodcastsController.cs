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
using Microsoft.CodeAnalysis.Options;

namespace AdvancedDatabaseAndORMAssignment1.Controllers
{
    public class PodcastsController : Controller
    {
        private readonly AdvancedDatabaseAndORMAssignment1Context _context;

        public PodcastsController(AdvancedDatabaseAndORMAssignment1Context context)
        {
            _context = context;
        }

        // GET: Podcasts
        public async Task<IActionResult> Index(int? ListenerListId)
        {
            if(ListenerListId == null) { 


              return _context.Podcasts != null ? 
                          View(await _context.Podcasts.ToListAsync()) :
                          Problem("Entity set 'AdvancedDatabaseAndORMAssignment1Context.Podcasts'  is null.");
            }else
                {
                var advancedDatabaseAndORMAssignment1Context =  _context.Podcasts.Where(p => p.PodcastListener.Any(c => c.ListenerListsId == ListenerListId));
                return _context.Podcasts != null ?
                         View(advancedDatabaseAndORMAssignment1Context) :
                         Problem("Entity set 'AdvancedDatabaseAndORMAssignment1Context.Podcasts'  is null.");
            }
        }

        // GET: Podcasts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Podcasts == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcasts.Include(c => c.Episodes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcast == null)
            {
                return NotFound();
            }

            return View(podcast);
        }

        // GET: Podcasts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Podcasts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Podcast podcast)
        {
            if (ModelState.IsValid)
            {
                _context.Add(podcast);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(podcast);
        }

        // GET: Podcasts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Podcasts == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcasts.FindAsync(id);
            if (podcast == null)
            {
                return NotFound();
            }
            return View(podcast);
        }

        // POST: Podcasts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Podcast podcast)
        {
            if (id != podcast.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(podcast);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PodcastExists(podcast.Id))
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
            return View(podcast);
        }

        // GET: Podcasts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Podcasts == null)
            {
                return NotFound();
            }

            var podcast = await _context.Podcasts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (podcast == null)
            {
                return NotFound();
            }

            return View(podcast);
        }

        // POST: Podcasts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Podcasts == null)
            {
                return Problem("Entity set 'AdvancedDatabaseAndORMAssignment1Context.Podcasts'  is null.");
            }
            var podcast = await _context.Podcasts.FindAsync(id);
            if (podcast != null)
            {
                _context.Podcasts.Remove(podcast);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public async Task<IActionResult> AddToListener(int Id)
        {
           
            AddToListenerListVM vm = new AddToListenerListVM(_context.ListenerLists.Include(c => c.PodcastListener).ThenInclude(c => c.Podcast).Where(c => c.PodcastListener.All(c => c.PodcastId !=Id)).ToList(), Id);
            return View(vm);

        }

        [HttpPost]
        public async Task<IActionResult> AddToListener(AddToListenerListVM vm, int id)
        {
            if (vm.ListenerListId != null || vm.PodcastId != null)
            {
                if (!_context.PodcastListeners.Any(ca => ca.ListenerListsId == vm.ListenerListId && ca.PodcastId == id))
                {
                    PodcastListener podcastListener = new PodcastListener();
                    Podcast podcast = _context.Podcasts.First(p => p.Id == id);
                    ListenerLists listenerLists = _context.ListenerLists.First(l => l.Id == vm.ListenerListId);
                   podcastListener.ListenerLists = listenerLists;
                   podcastListener.Podcast = podcast;
                  
                    _context.PodcastListeners.Add(podcastListener);
                    await _context.SaveChangesAsync();
                    vm.ViewMessage = $"Successfully added {listenerLists.Name}  to {podcast.Name}";
                }
                else
                {
                    vm.ViewMessage = "Selected Song already added to selectd playlist";
                }
                vm.PopulateLists(_context.ListenerLists.Include(c => c.PodcastListener).ThenInclude(c => c.Podcast).Where(c => c.PodcastListener.All(c => c.PodcastId != id)).ToList());
                return View(vm);
            }
            else
            {
                throw new Exception("Error");
            }


        }
        [HttpPost]
        public IActionResult Sort(int Id, string sort)
        {
            List<Episodes> episodes = _context.Episodes.Where(s=> s.PodcastId == Id).ToList();

            string text = sort;
            foreach(Episodes episode in episodes)
            {
                SelectListItem item = new SelectListItem(); 
                if(sort == "Reverse-Chronological")
                {
                    return View(episodes.OrderByDescending(l => l.AirDate).ToList());

                }
                else
                {
                    return View(episodes.OrderBy(l => l.AirDate).ToList());
                }
            }
            return View(episodes);
        }


       
        private bool PodcastExists(int id)
        {
          return (_context.Podcasts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
