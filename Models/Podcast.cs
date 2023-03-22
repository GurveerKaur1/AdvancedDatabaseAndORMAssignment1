using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class Podcast
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Podcast Name must be between 3 to 200 characters", MinimumLength = 3)]
        public string Name { get; set; }

        public virtual HashSet<PodcastArtist> PodcastArtists { get; set; } = new HashSet<PodcastArtist>();

        public virtual HashSet<PodcastListener> PodcastListener { get; set; } = new HashSet<PodcastListener>();

        public virtual HashSet<Episodes> Episodes { get; set; } = new HashSet<Episodes>();

        public Podcast(string name)
        {
            Name = name;
        }

        public Podcast() { }
    }
}
