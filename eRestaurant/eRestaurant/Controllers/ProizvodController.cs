using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eRestaurant.Helper;
using eRestaurant.Authentication.Models;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProizvodController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public ProizvodController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();
            int korisnikID = autentifikacijaToken.korisnickiNalogId;

            var favoriteProductIds = _dbContext.FavoritiKorisnika
                .Where(k => k.KorisnikID == korisnikID)
                .Select(k => k.ProizvodID)
                .ToList();

            var proizvodinf = _dbContext.Proizvodi
                .Include(p => p.ProizvodiKategorije)
                .Where(p => !favoriteProductIds.Contains(p.ProizvodID))
                .OrderByDescending(p => !favoriteProductIds.Contains(p.ProizvodID))
                .ToList();

            var proizvodif = _dbContext.Proizvodi
                .Include(p => p.ProizvodiKategorije)
                .Where(p => favoriteProductIds.Contains(p.ProizvodID))
                .OrderByDescending(p => p.isFavorite)
                .ToList();

            var proizvodi = proizvodif.Concat(proizvodinf).ToList();

            var proizvodiVM = proizvodi.Select(p => new ProizvodGetAllVM()
            {
                id = p.ProizvodID,
                nazivProizvoda = p.NazivProizvoda,
                pocetnaCijena = p.PocetnaCijena,
                opis = p.Opis,
                recenzija = p.Recenzija,
                jedinicaMjere = p.JedinicaMjere,
                proizvodiKategorije = p.ProizvodiKategorije,
                slika = p.Slika,
                isFavorite = favoriteProductIds.Contains(p.ProizvodID) ? true : p.isFavorite,
            });

            return Ok(proizvodiVM);
        }


        [HttpGet("{id}")]

        public ActionResult GetById(int id)
        {
            return Ok(_dbContext.Proizvodi
                .Include(s => s.ProizvodiKategorije)
                .FirstOrDefault(s => s.ProizvodID == id)); ;
        }

        [HttpGet("{id}")]
        public ActionResult GetSlika(int id)
        {
            byte[] bajtovi_slike = _dbContext.Proizvodi.Find(id).Slika;
            if (bajtovi_slike == null || bajtovi_slike.Length == 0)
            {
                bajtovi_slike = System.IO.File.ReadAllBytes("Images/image.png");
            }

            return File(bajtovi_slike, "image/png");
        }

        [HttpPost("{id}")]
        public ActionResult MakeFavorite(int id)
        {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();
            int korisnikID = autentifikacijaToken.korisnickiNalogId;

            var p = new FavoriteProizvodi
            {
                ProizvodID = id,
                KorisnikID = korisnikID
            };

            _dbContext.Add(p);
            _dbContext.SaveChanges();
            return GetAll();
        }

        [HttpPost("{id}")]
        public ActionResult RemoveFavorite(int id)
        {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();
            int korisnikID = autentifikacijaToken.korisnickiNalogId;

            FavoriteProizvodi p = _dbContext.FavoritiKorisnika.Where(k => k.KorisnikID == korisnikID && k.ProizvodID == id).FirstOrDefault();
            
            if (p == null)
                return BadRequest("Pogresan id");

            _dbContext.Remove(p);
            _dbContext.SaveChanges();
            return GetAll();
        }



        [HttpPost("{id}")]
        public ActionResult AddReview(int id, int number )
        {
            Proizvod? proizvod = _dbContext.Proizvodi.FirstOrDefault(s => s.ProizvodID == id);
            if (proizvod == null)
                return BadRequest("pogresan ID");
            int numberOfUsers = _dbContext.Korisnici.Count();
            proizvod.Recenzija = (proizvod.Recenzija * numberOfUsers + number) / (numberOfUsers + 1);
           
            _dbContext.SaveChanges();
            return Ok(proizvod);
        }

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] ProizvodUpdateVM x)
        {
            Proizvod? proizvod = _dbContext.Proizvodi.Include(s => s.ProizvodiKategorije).FirstOrDefault(s => s.ProizvodID == id);

            if (proizvod == null)
                return BadRequest("pogresan ID");

            proizvod.Slika = x.SlikaNovaBase64.ParsirajBase64();

            _dbContext.SaveChanges();
            return GetById(id);
        }

    }
}
