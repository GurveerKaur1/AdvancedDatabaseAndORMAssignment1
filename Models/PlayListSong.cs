namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class PlayListSong
    {
        public int Id { get; set; }

        public PlayList PlayList { get; set; }
        public int PlayListId { get; set; }

        public Song Song { get; set; }

        public int SongId { get; set;}

        public DateTime TimeAdded { get; set; }
        public PlayListSong(int playListId, int songId, DateTime timeAdded)
        {
           
            PlayListId = playListId;
            SongId = songId;
            TimeAdded = timeAdded;
        }

        public PlayListSong() { }


    }
}
