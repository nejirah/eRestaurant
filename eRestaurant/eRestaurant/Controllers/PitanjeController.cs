using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class PitanjeController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PitanjeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {

            return Ok( _dbContext.Pitanja
                .OrderByDescending(s => s.PitanjeID)
                .Include(k => k.Korisnik)
                .Include(r => r.Radnik)
                .ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_dbContext.Pitanja
                .Include(k=>k.Korisnik)
                .Include(r=>r.Radnik)
                .FirstOrDefault(s => s.PitanjeID == id));
        }

        [HttpPost]
        public ActionResult Add(PitanjeAddViewModel p)
        {
            Pitanje pitanje;
            if (p.pitanjeID == 0)
            {
                pitanje = new Pitanje
                {
                    PitanjeID = p.pitanjeID,
                    Status = "Unanswered"
                };
                _dbContext.Add(pitanje);
            }
            else
            {
                pitanje = _dbContext.Pitanja.FirstOrDefault(s => s.PitanjeID == p.pitanjeID);
            }

            if (pitanje == null)
                return BadRequest("pogresan ID");

            pitanje.Opis = p.opis;
            pitanje.Datum = DateTime.Now;
            pitanje.RadnikID = 2;
            pitanje.KorisnikID = p.korisnikID;

            _dbContext.SaveChanges();
            return Ok(pitanje);
        }

        [HttpPost("{id}")]
        public ActionResult Answer(int id, [FromBody] PitanjeUpdateViewModel x)
        {
            Pitanje? pitanje = _dbContext.Pitanja.FirstOrDefault(s => s.PitanjeID == id);
            if (pitanje == null)
                return BadRequest("pogresan ID");

            pitanje.Odgovor = x.odgovor;
            pitanje.Status = "Answered";

            _dbContext.SaveChanges();
            return GetById(id);
        }

        [HttpPost("{id}")]
        public ActionResult  Delete(int id)
        {
            Pitanje? pitanje = _dbContext.Pitanja.Find(id);
            if (pitanje == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(pitanje);
            _dbContext.SaveChanges();

            return Ok(pitanje);
        }
    }
}
