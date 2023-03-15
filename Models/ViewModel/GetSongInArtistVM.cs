using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvancedDatabaseAndORMAssignment1.Models.ViewModel
{
    public class GetSongInArtistVM
    {
        public HashSet<SelectListItem> Songs { get; set; } = new HashSet<SelectListItem>();

        public int ArtistId { get; set; }
         public int AlbumId { get; set; }
        public int SongId { get; set; } 

        public void PopulateLists(IEnumerable<Song> songs)
        {

            foreach (Song p in songs)
            {
                Songs.Add(new SelectListItem($"{p.Title}", p.Id.ToString()));
            }

        }

        public GetSongInArtistVM(IEnumerable<Song> songs, int artistId, int albumId)
        {
            PopulateLists(songs);
            ArtistId = artistId;
            AlbumId = albumId;
        }
       public GetSongInArtistVM() { }
    }
}
