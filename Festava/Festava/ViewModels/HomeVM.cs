using Festava.Models;

namespace Festava.ViewModels
{
    public class HomeVM
    {
        public List <Title>Titles { get; set; }
        public About About { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Price> Prices { get; set; }
    }
}
