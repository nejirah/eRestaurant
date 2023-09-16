using eRestaurant.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eRestaurant.Authentication.Models
{
    [Table("KorisnickiNalog")]
    public class KorisnickiNalog
    {
        [Key]
        public int OsobaID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public Korisnik? Korisnik => this as Korisnik;
        [JsonIgnore]
        public Radnik? Radnik => this as Radnik;
    }
}
