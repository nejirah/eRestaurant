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
    public class KuponiKorisnikaController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KuponiKorisnikaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Update([FromBody] KuponiKorisnikaUpdateViewModel x )
        {

            KuponiKorisnika? kupon = _dbContext.KuponiKorisnika.Where(s => s.KuponID == x.kuponID && s.KorisnikID == x.korisnikID).FirstOrDefault();

            if (kupon == null)
                return BadRequest("pogresan ID");

            kupon.isActivated = true;

            _dbContext.SaveChanges();
            return Ok(kupon);
        }

        [HttpGet]
        public ActionResult GetAllActive()
        {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();

            return Ok(_dbContext.KuponiKorisnika
                .Where(k => k.isActivated == true && k.Kupon.DatumDeaktivacije > DateTime.Now && k.isUsed==false && k.KorisnikID == autentifikacijaToken.korisnickiNalogId)
                .OrderByDescending(k => k.KuponID)
                .Include(k => k.Kupon)
                .Include(k => k.Korisnik)
                .ToList()) ;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();

            return Ok(_dbContext.KuponiKorisnika
                .Where(k=>k.KorisnikID== autentifikacijaToken.korisnickiNalogId)
                .Include(k=>k.Kupon)
                .Include(k=>k.Korisnik)
                .OrderByDescending(k => k.KuponID).ToList());
        }

        [HttpPost]
        public ActionResult UpdateUsage([FromBody] KuponiKorisnikaUpdateViewModel x)
        {
            KuponiKorisnika? kupon = _dbContext.KuponiKorisnika.Where(s => s.KuponID == x.kuponID && s.KorisnikID == x.korisnikID).FirstOrDefault();

            if (kupon == null)
                return BadRequest("pogresan ID");

            kupon.isUsed = true;

            _dbContext.SaveChanges();
            return Ok(kupon);
        }
    }
}
