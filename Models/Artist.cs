namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class Artist
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public virtual HashSet<SongContributor> SongContributor { get; set; } = new HashSet<SongContributor>();
        public Artist( string name)
        {
            Name = name;
        }

        public Artist() { }
    }
}
