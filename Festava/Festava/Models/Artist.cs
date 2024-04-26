using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Festava.Models
{
    public class Artist
    {
        public int Id { get; set; }
       
        public string Image { get; set; }
        [Required]
        public string Name { get; set; }
		[Column(TypeName = "date")]
		public DateTime Birthdate { get; set; }
        public string Music { get; set; }
        public string YoutubeChannel { get; set; }
       
    }
}
