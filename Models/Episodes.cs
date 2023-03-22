using System.ComponentModel.DataAnnotations;

namespace AdvancedDatabaseAndORMAssignment1.Models
{
    public class Episodes 
    {

        public int Id { get; set; }

        public string Name { get; set; }
       // [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH/mm/ss}")]
        [DataType(DataType.DateTime)]
        public DateTime AirDate { get; set; }


        [Required]
        [Range(0, int.MaxValue)]
        public int DurationSeconds { get; set; }


        public Podcast Podcast { get; set; }

        [Required]
        public int PodcastId { get; set; }
        public Episodes(string name, int durationSeconds, DateTime dateTime, int podcastId) 
        {
            Name = name;
            DurationSeconds = durationSeconds;
            AirDate = dateTime;
            PodcastId= podcastId;
        }

        public Episodes() { }
    }
}
