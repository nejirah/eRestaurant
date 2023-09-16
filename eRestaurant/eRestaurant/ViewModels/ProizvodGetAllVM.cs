using eRestaurant.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestaurant.ViewModels
{
    public class ProizvodGetAllVM
    {
        public int id { get; set; }
        public string nazivProizvoda { get; set; }
        public double pocetnaCijena { get; set; }
        public string opis { get; set; }
        public float recenzija { get; set; }
        public byte[]? slika { get; set; }
        public string jedinicaMjere { get; set; }
        public ProizvodiKategorije proizvodiKategorije { get; set; }
        public bool isFavorite { get; set; }
    }
}
