namespace Festava.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Day { get; set; }
        public string FirstEventName { get; set; }
        public DateTime FirstEventTime { get; set; }
        public string FirstArtistName { get; set; }
        public string SecondEventName { get; set;}
        public DateTime SecondEventTime { get; set; }
        public string SecondArtistName { get; set; }

    }
}
