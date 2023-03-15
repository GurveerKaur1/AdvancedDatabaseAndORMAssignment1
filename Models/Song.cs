namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class Song
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int DurationSeconds { get; set; }

        public Album Album { get; set; }
        public int AlbumId { get; set; }

        public virtual HashSet<SongContributor> SongContributor { get; set; } = new HashSet<SongContributor>();
        public virtual HashSet<PlayListSong> PlayListSongs { get; set; } = new HashSet<PlayListSong> { };
        public Song(string title, int durationSeconds, int albumId)
        {
            
            Title = title;
            DurationSeconds = durationSeconds;
            AlbumId = albumId;
        }

        public Song() { }
    }
}
