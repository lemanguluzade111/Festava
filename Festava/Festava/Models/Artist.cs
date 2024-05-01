using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festava.Models
{
    public class Artist
    {
        public int Id { get; set; }
       
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string Name { get; set; }
		[Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public string Music { get; set; }
        public string YoutubeChannel { get; set; }
        public bool IsDeactive { get; set; }


        public List<Schedule> Schedules { get; set; }

    }
}
