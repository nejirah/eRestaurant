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
   
        public class NarudzbaController : ControllerBase
        {
            private readonly ApplicationDbContext _dbContext;

            public NarudzbaController(ApplicationDbContext dbContext)
            {
                this._dbContext = dbContext;
            }

            [HttpGet]
            public ActionResult GetAll()
            {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();
                var data = _dbContext.Narudzbe
                        .OrderByDescending(s => s.NarudzbaID)
                        .Where(s=>s.KorisnikID== autentifikacijaToken.korisnickiNalogId)
                        .Include(k=>k.Korisnik)
                        .Include(r=>r.Radnik)
                        .Include(d=>d.Dostavljac)
                        .Include(u=>u.Uplata);
                    return Ok(data.ToList());
            }

            [HttpGet("{id}")]
            public ActionResult GetById(int id)
            {
                return Ok(_dbContext.Narudzbe
                    .Include(k => k.Korisnik)
                    .Include(r => r.Radnik)
                    .Include(d => d.Dostavljac)
                    .Include(u => u.Uplata)
                    .FirstOrDefault(s => s.NarudzbaID == id));
            }

            [HttpPost]
            public ActionResult Add([FromBody] NarudzbaAddVM x)
            {

                Narudzba narudzba= _dbContext.Narudzbe.FirstOrDefault(n=>n.NarudzbaID==x.narudzbaID);
                if (narudzba == null)
                    return BadRequest("pogresan ID");

                narudzba.TipNarudzbe = x.TipNarudzbe;
                narudzba.StatusNarudzbe = "New";
                narudzba.UkupnaCijenaBezPopusta = x.UkupnaCijenaBezPopusta;
                narudzba.Popust = x.Popust;
                narudzba.UkupnaCijena = x.UkupnaCijena;
                narudzba.DodatnaNapomena = x.DodatnaNapomena;
                narudzba.KorisnikID = x.KorisnikID;
                narudzba.RadnikID=x.RadnikID;
                narudzba.UplataID = x.UplataID;
                narudzba.DostavljacID = x.DostavljacID;

                _dbContext.SaveChanges();
                return Ok(narudzba);
            }


        [HttpPost]
        public ActionResult AddInitial([FromBody] NarudzbaAddVM x)
        {
            var novaNarudzba = new Narudzba
            {
                TipNarudzbe = "Online",
                StatusNarudzbe = "New",
                UkupnaCijenaBezPopusta = 0,
                Popust = 0,
                UkupnaCijena = 0,
                DodatnaNapomena = "",
                DatumNarudzbe = DateTime.Now,
                KorisnikID = x.KorisnikID,
                RadnikID = 2,
                DostavljacID = 3,
            };

            _dbContext.Add(novaNarudzba);
            _dbContext.SaveChanges();
            return Ok(novaNarudzba);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Narudzba? narudzba = _dbContext.Narudzbe.Find(id);

            if (narudzba == null || id == 1)
                return BadRequest("pogresan ID");

            var stavkeNarudzbe = _dbContext.StavkeNarudzbe.Where(p => p.NarudzbaID == id);
            _dbContext.StavkeNarudzbe.RemoveRange(stavkeNarudzbe);

            _dbContext.Remove(narudzba);

            _dbContext.SaveChanges();
            return Ok(narudzba);
        }
    }
}
