using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestaurant.Models
{
    public class Proizvod
    {
        [Key]
        public int ProizvodID { get; set; }
        public string NazivProizvoda { get; set; }
        public double PocetnaCijena { get; set; }
        public string Opis { get; set; }
        public float Recenzija { get; set; }
        public byte[]? Slika { get; set; }
        public string JedinicaMjere { get; set; }

        [ForeignKey(nameof(ProizvodiKategorije))]
        public int ProizvodiKategorijeID { get; set; }
        public ProizvodiKategorije ProizvodiKategorije { get; set; }
        public bool isFavorite { get; set; }

    }
}
