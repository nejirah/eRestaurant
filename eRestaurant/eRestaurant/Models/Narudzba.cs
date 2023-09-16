using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestaurant.Models
{
    public class Narudzba
    {
        [Key]
        public int NarudzbaID { get; set; }
        public string TipNarudzbe { get; set; }
        public double UkupnaCijenaBezPopusta { get; set; }
        public float Popust { get; set; }
        public double UkupnaCijena { get; set; }
        public string StatusNarudzbe { get; set; }
        public string? DodatnaNapomena { get; set; }
        public DateTime DatumNarudzbe { get; set; }

        [ForeignKey(nameof(KorisnikID))]
        public Korisnik Korisnik { get; set; }
        public int KorisnikID { get; set; }

        [ForeignKey(nameof(RadnikID))]
        public Radnik Radnik { get; set; }
        public int RadnikID { get; set; }

        [ForeignKey(nameof(DostavljacID))]
        public Radnik Dostavljac { get; set; }
        public int DostavljacID { get; set; }

        [ForeignKey(nameof(UplataID))]
        public Uplata? Uplata { get; set; }
        public int? UplataID { get; set; }
    }
}
