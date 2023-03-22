using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class Album
    {
        public int Id { get; set; }

        [Required]
        [StringLength(25, ErrorMessage = "Title must be between 3 to 25 characters", MinimumLength = 3)]
        public string Title { get; set; }

        public Album(string title)
        {
            Title = title;
        }

        public virtual HashSet<Song> Songs { get; set; } = new HashSet<Song>();
        public Album() { }
    }
}
