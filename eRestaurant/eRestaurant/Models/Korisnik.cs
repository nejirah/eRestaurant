using eRestaurant.Authentication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestaurant.Models
{
    [Table("Korisnici")]
    public class Korisnik:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string? Slika { get; set; }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
