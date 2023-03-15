namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Album(string title)
        {
            Title = title;
        }

        public virtual HashSet<Song> Songs { get; set; } = new HashSet<Song>();
        public Album() { }
    }
}
