namespace AdvancedDatabaseAndORMAssignment1.Models.ViewModel
{
    public class DeleteSongInPlayListVM
    {
        public int? PlayListId { get; set; }

        public int? SongId { get; set; }

        public string? ViewMessage { get; set; }
        public DeleteSongInPlayListVM( int playListId, int songId)
        {
            PlayListId = playListId;
            SongId = songId;
        }
        public DeleteSongInPlayListVM() { }
    }
}
