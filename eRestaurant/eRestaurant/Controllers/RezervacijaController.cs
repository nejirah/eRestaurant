using eRestaurant.Authentication.Models;
using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace eRestaurant.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class RezervacijaController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RezervacijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {

            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();

            return Ok(_dbContext.Rezervacije
                .OrderByDescending(s => s.RezervacijaID)
                .Where(s=>s.KorisnikID== autentifikacijaToken.korisnickiNalogId)
                .Include(k => k.Korisnik)
                .Include(r => r.Radnik))
                ;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_dbContext.Rezervacije
                .Include(k => k.Korisnik)
                .Include(r => r.Radnik)
                .FirstOrDefault(s => s.RezervacijaID == id));
        }

        [HttpPost]
        public ActionResult Add(RezervacijaAddViewModel k)
        {

            Rezervacija rezervacija;
            if (k.rezervacijaID == 0)
            {
                rezervacija = new Rezervacija
                {
                    RezervacijaID = k.rezervacijaID,
                    Status= "New"
                };
                _dbContext.Add(rezervacija);
            }
            else
            {
                rezervacija = _dbContext.Rezervacije.FirstOrDefault(s => s.RezervacijaID == k.rezervacijaID);
                rezervacija.Status = "Updated";
            }

            if (rezervacija == null)
                return BadRequest("pogresan ID");

            rezervacija.DatumRezervacije = k.datumRezervacije;
            rezervacija.BrojOsoba = k.brojOsoba;
            rezervacija.BrojStola = k.brojStola;
            rezervacija.Napomena = k.napomena;
            rezervacija.KorisnikID = k.korisnikID;
            rezervacija.RadnikID = 2;

            _dbContext.SaveChanges();
            return Ok(rezervacija);
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            Rezervacija? rezervacija = _dbContext.Rezervacije.Find(id);

            if (rezervacija == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(rezervacija);

            _dbContext.SaveChanges();
            return Ok(rezervacija);
        }
    }
}
                                                                                                                                                                         