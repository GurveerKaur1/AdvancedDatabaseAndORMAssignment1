using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class PlayList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "PlayList Name must be between 3 to 200 characters", MinimumLength = 3)]
        public string Name { get; set; }

        public virtual HashSet<PlayListSong> PlayListSongs { get; set; } = new HashSet<PlayListSong> { };

        public PlayList(string name)
        {
            Name = name;
        }

        public PlayList() { }
    }
}
