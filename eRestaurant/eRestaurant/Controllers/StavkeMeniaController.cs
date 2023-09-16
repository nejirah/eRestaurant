using eRestaurant.Data;
using eRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class StavkeMeniaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public StavkeMeniaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // dohvacati proizvode
        [HttpGet("{id}")]
        public ActionResult GetAllFromMenu(int id) {
            return Ok(
                _dbContext.StavkeMenia
                .Where(m => m.MeniID == id)
                .Include(p => p.Proizvod)
                ); ;
        }
    }
}
