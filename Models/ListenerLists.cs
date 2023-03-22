using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class ListenerLists
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Listener Lists must be between 3 to 200 characters", MinimumLength = 3)]
        public string Name { get; set; }

        public virtual HashSet<PodcastListener> PodcastListener { get; set; } = new HashSet<PodcastListener>();


        public ListenerLists(string name)
        {
            Name = name;
        }
        public ListenerLists()
        {

        }
    }
}
