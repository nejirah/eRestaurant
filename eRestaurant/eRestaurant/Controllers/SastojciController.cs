using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SastojciController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public SastojciController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll(string? naziv_sastojka)
        {
            return Ok( _dbContext.Sastojci
                .Where(x => naziv_sastojka == null || (x.Naziv.Contains(naziv_sastojka))).OrderByDescending(s => s.SastojakID)
                .Include(s => s.SastojciKategorije)
                .Include(d=>d.Dobavljac)
                .ToList());
        }
    }
}
