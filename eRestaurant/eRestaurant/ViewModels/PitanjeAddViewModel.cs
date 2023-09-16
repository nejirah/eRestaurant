using eRestaurant.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestaurant.ViewModels
{
    public class PitanjeAddViewModel
    {
        public int pitanjeID { get; set; }
        public string opis { get; set; }
        public int korisnikID { get; set; }
        public int radnikID { get; set; }
    }
}
