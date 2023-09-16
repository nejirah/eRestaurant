using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eRestaurant.Authentication.Models
{
    public class LogKretanjePoSistemu
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Korisnik))]
        public int? KorisnikID { get; set; }
        public KorisnickiNalog? Korisnik { get; set; }
        public string? QueryPath { get; set; }
        public string? PostData { get; set; }
        public DateTime Vrijeme { get; set; }
        public string? IPAdresa { get; set; }
        public string? ExceptionMessage { get; set; }
        public bool isException { get; set; }
    }
}
