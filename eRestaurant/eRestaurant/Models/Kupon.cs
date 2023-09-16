using System.ComponentModel.DataAnnotations;

namespace eRestaurant.Models
{
    public class Kupon
    {
        [Key]
        public int KuponID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime DatumAktivacije { get; set; }
        public DateTime DatumDeaktivacije { get; set; }
        public float Popust { get; set; }
        public string? Kategorija { get; set; }
    }
}
