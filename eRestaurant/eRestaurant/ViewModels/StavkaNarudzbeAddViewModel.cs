using eRestaurant.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestaurant.ViewModels
{
    public class StavkaNarudzbeAddViewModel
    {
        public double Cijena { get; set; }
        public int Kolicina { get; set; }
        public int NarudzbaID { get; set; }
        public int ProizvodID { get; set; }
        public int? KuponID { get; set; }

    }
}
