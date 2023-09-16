using eRestaurant.Authentication.Models;
using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UplataController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UplataController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();

            return Ok( _dbContext.Narudzbe
                 .Include(s=>s.Uplata)
                 .Where(s=>s.KorisnikID== autentifikacijaToken.korisnickiNalogId)
                .OrderByDescending(s => s.UplataID)
                .ToList());

        }

        [HttpPost]
        public ActionResult Add([FromBody] UplateAddViewModel x)
        {
            var uplata = new Uplata
            {
                IznosZaUplatu = x.iznosZaUplatu,
                NacinPlacanja = "Cash",
                Datum= DateTime.Now
            };

            _dbContext.Add(uplata);
            _dbContext.SaveChanges();
            return Ok(uplata);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_dbContext.Uplate.FirstOrDefault(s => s.UplataID == id));
        }
    }
}
