namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class PodcastListener
    {
        public int Id { get; set; }

        public Podcast Podcast { get; set; }

        public int PodcastId { get; set; }

        public ListenerLists ListenerLists { get; set; }

        public int ListenerListsId { get; set; }

        public PodcastListener(int podcastId, int ListenerId)
        {
            PodcastId = podcastId;
            ListenerListsId= ListenerId;
        }
        public PodcastListener() { }
    }
}
