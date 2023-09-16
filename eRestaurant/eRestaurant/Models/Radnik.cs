using eRestaurant.Authentication.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestaurant.Models
{
    [Table("Radnici")]
    public class Radnik:KorisnickiNalog
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string? Slika { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public DateTime? DatumZavrsetkaRadnogOdnosa { get; set; }
        public string Zvanje { get; set; }
        public string JMBG { get; set; }
        public string Spol { get; set; }
        public string Pozicija { get; set; }
        public string? PoslovniBrojTelefona { get; set; }
        public string? KategorijaVozacke { get; set; }
        public string? PrevoznoSredstvo { get; set; }
        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}
