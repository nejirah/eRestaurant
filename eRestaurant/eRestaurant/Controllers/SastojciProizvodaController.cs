using eRestaurant.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SastojciProizvodaController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SastojciProizvodaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(_dbContext.SastojciProizvoda
                .Where(p => p.ProizvodID ==id)
                .Include(p => p.Sastojak).ToList());
        }
    }
}
