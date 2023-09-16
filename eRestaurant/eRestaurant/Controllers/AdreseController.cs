using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdreseController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AdreseController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Add([FromBody] KorisnickeAdreseAddViewModel x)
        {
            KorisnickeAdrese adresa;
            if (x.id == 0)
            {
                adresa = new KorisnickeAdrese
                {
                    KorickaAdresaID = x.id
                };
                _dbContext.Add(adresa);
            }
            else
            {
                adresa = _dbContext.KorisnickeAdrese.FirstOrDefault(s => s.KorickaAdresaID == x.id);
            }

            if (adresa == null)
                return BadRequest("pogresan ID");

            adresa.NazivAdreseStanovanja = x.nazivAdreseStanovanja;
            adresa.BrojUlice = x.brojUlice;
            adresa.PostanskiBroj = x.postanskiBroj;
            adresa.KorisnikID = x.korisnikID;

            _dbContext.SaveChanges();
            return Ok(adresa);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_dbContext.KorisnickeAdrese
                .OrderBy(a => a.KorickaAdresaID)
                .Include(k => k.Korisnik)
                .ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_dbContext.KorisnickeAdrese
                .Include(k=>k.Korisnik)
                .FirstOrDefault(s => s.KorickaAdresaID == id));
        }

        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            KorisnickeAdrese? adresa = _dbContext.KorisnickeAdrese.Find(id);

            if(adresa==null || id == 1)
            {
                return BadRequest("pogresan ID");
            }

            _dbContext.Remove(adresa);
            _dbContext.SaveChanges();
            return Ok(adresa);
        }
    }
}
