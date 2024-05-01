namespace Festava.Models
{
    public class Schedule
    {
        public int Id { get; set; }   
        public string Day { get; set; }
        public string Name { get; set; }
        public string Time { get; set; } 
       
       


        public bool IsDeactive { get; set; }
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

    }
}
