using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace eRestaurant.Authentication.Models
{
    public class AuthenticationToken
    {
        [Key]
        public int id { get; set; }
        public string vrijednost { get; set; }

        [ForeignKey(nameof(korisnickiNalog))]
        public int korisnickiNalogId { get; set; }
        public KorisnickiNalog korisnickiNalog { get; set; }
        public DateTime vrijemeEvidentiranja { get; set; }
        public string IPAdresa { get; set; }

        [JsonIgnore]
        public string TwoFCode { get; set; }
        public bool TwoFJelOtkljucano { get; set; }
    }
}
