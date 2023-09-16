using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eRestaurant.Models
{
    public class KuponiKorisnika
    {
        [Key]
        public int KuponiKorisnikaID { get; set; }

        [ForeignKey(nameof(KuponID))]
        public int KuponID { get; set; }
        public Kupon Kupon { get; set; }

        [ForeignKey(nameof(KorisnikID))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public bool isUsed { get; set; }
        public bool isActivated { get; set; }
    }
}
