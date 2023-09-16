using eRestaurant.Data;
using eRestaurant.Helper;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KorisnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            return Ok(_dbContext.Korisnici.FirstOrDefault(s => s.OsobaID == id));
        }

        [HttpPost]
        public ActionResult Add(KorisnikAddViewModel k)
        {
            var existingUsername = _dbContext.Korisnici.FirstOrDefault(s => s.Username == k.username);
            if (existingUsername != null)
            {
                return BadRequest("Username already exists");
            }

            Korisnik korisnik;
            if (k.id == 0)
            {
                korisnik = new Korisnik { 
                OsobaID= k.id
                };
                _dbContext.Add(korisnik);
            }
            else
            {
                korisnik = _dbContext.Korisnici.FirstOrDefault(s => s.OsobaID == k.id);
            }

            if (korisnik == null)
                return BadRequest("pogresan ID");

            korisnik.Ime = k.ime;
            korisnik.Prezime = k.prezime;
            korisnik.Username = k.username;
            korisnik.Email = k.email;
            korisnik.BrojTelefona = k.brojTelefona;
            korisnik.Slika = k.slika;
            korisnik.Password = k.password;

            _dbContext.SaveChanges();

            var activeCoupons = _dbContext.Kuponi.Where(c => c.DatumDeaktivacije>DateTime.Now).ToList();
            foreach (var coupon in activeCoupons)
            {
                var kuponiKorisnika = new KuponiKorisnika
                {
                    KorisnikID = korisnik.OsobaID,
                    KuponID = coupon.KuponID
                };
                _dbContext.Add(kuponiKorisnika);
            }


            _dbContext.SaveChanges();
            return Ok(korisnik);
        }      
    }
}
