namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class PodcastArtist
    {
        public int Id { get; set; }

        public Artist Artist { get; set; }
        public int ArtistId { get; set; }
        
        public Podcast Podcast { get; set; }

        public int PodcastId { get; set; }

        public PodcastArtist()
        {

        }
    }
}
