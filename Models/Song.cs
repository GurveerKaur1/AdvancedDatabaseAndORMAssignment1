using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class Song
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Song Title must be between 3 to 200 characters", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int DurationSeconds { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int TrackNumber { get; set; }

       
        public Album? Album { get; set; }

        [Required]
        public int AlbumId { get; set; }

        
        public virtual HashSet<SongContributor> SongContributor { get; set; } = new HashSet<SongContributor>();
        public virtual HashSet<PlayListSong> PlayListSongs { get; set; } = new HashSet<PlayListSong> { };
        public Song(string title, int durationSeconds, int albumId, int trackNumber)
        {
            
            Title = title;
            DurationSeconds = durationSeconds;
            AlbumId = albumId;
            TrackNumber = trackNumber;
        }

        public Song() { }
    }
}
