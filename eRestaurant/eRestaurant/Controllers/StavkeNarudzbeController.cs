using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StavkeNarudzbeController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StavkeNarudzbeController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_dbContext.StavkeNarudzbe
                .Where(p => p.NarudzbaID == id)
                .Include(p => p.Proizvod)
                .Include(p=> p.Proizvod.ProizvodiKategorije)
                .ToList());
        }

        [HttpPost]
        public ActionResult AddToCart([FromBody] StavkaNarudzbeAddViewModel x )
        {
            StavkeNarudzbe stavka = new StavkeNarudzbe
            {
                ProizvodID = x.ProizvodID,
                NarudzbaID = x.NarudzbaID,
                Cijena = x.Cijena,
                Kolicina = x.Kolicina,
                KuponID = x.KuponID
            };

            _dbContext.Add(stavka);
            _dbContext.SaveChanges();
            return Ok(stavka);
        }


        [HttpPost("{id}")]
        public ActionResult UpdateQuantity(int id, [FromBody] StavkeNarudzbeUpdateVM x)
        {
            StavkeNarudzbe? stavka = _dbContext.StavkeNarudzbe.FirstOrDefault(s => s.StavkeNarudzbeID == id);
            if (stavka == null)
                return BadRequest("pogresan ID");

            stavka.Kolicina = x.kolicina;

            _dbContext.SaveChanges();
            return Ok(stavka);
        }


        [HttpPost("{id}")]
        public ActionResult Delete(int id)
        {
            StavkeNarudzbe? stavka = _dbContext.StavkeNarudzbe.Find(id);
            if (stavka == null || id == 1)
                return BadRequest("pogresan ID");

            _dbContext.Remove(stavka);
            _dbContext.SaveChanges();

            return Ok(stavka);
        }
    }
}
