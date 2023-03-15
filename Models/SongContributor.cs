namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class SongContributor
    {
        public int Id { get; set; }

        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

        public Song Song { get; set; }
        public int SongId { get; set;}

        public SongContributor(int artistId,int songId)
        {
           
            ArtistId = artistId;
           
            SongId = songId;
        }

        public SongContributor() { }
    }
}
