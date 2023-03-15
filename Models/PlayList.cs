namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class PlayList
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual HashSet<PlayListSong> PlayListSongs { get; set; } = new HashSet<PlayListSong> { };

        public PlayList(string name)
        {
            Name = name;
        }

        public PlayList() { }
    }
}
