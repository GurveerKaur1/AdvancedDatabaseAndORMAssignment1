using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvancedDatabaseAndORMAssignment1.Models.ViewModel
{
    public class AddToPlaylistVM
    {
        public HashSet<SelectListItem> PlayLists { get; set; } = new HashSet<SelectListItem>();

        public int? PlayListId { get; set; }
        public int? SongId { get; set; }
        public string? ViewMessage { get; set; }

        public void PopulateLists(IEnumerable<PlayList> playLists)
        {

            foreach (PlayList p in playLists)
            {
                PlayLists.Add(new SelectListItem($"{p.Name}", p.Id.ToString()));
            }

        }
        public AddToPlaylistVM(IEnumerable<PlayList> playLists, int Id)
        {
            PopulateLists(playLists);
            SongId = Id;
        }

        public AddToPlaylistVM() { }
    }
}
