using System.ComponentModel.DataAnnotations;

namespace eRestaurant.Models
{
    public class Poruke
    {
        [Key]
        public int PorukaID { get; set; }
        public string Opis { get; set; }
    }
}
