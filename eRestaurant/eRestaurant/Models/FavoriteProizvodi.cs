using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eRestaurant.Models
{
    public class FavoriteProizvodi
    {
        [Key]
        public int FavoritiKorisnikaID { get; set; }

        [ForeignKey(nameof(ProizvodID))]
        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }

        [ForeignKey(nameof(KorisnikID))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
