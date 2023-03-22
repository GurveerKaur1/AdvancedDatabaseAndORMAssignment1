using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class Artist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Artist Name must be between 3 to 200 characters", MinimumLength = 3)]
        public string Name { get; set; }


        public virtual HashSet<SongContributor> SongContributor { get; set; } = new HashSet<SongContributor>();
        public virtual HashSet<PodcastArtist> PodcastArtists { get; set; } = new HashSet<PodcastArtist>();

        public Artist( string name)
        {
            Name = name;
        }

        public Artist() { }
    }
}
