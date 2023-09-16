using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RadnikController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public RadnikController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetById(int? id)
        {
            return Ok(_dbContext.Radnici.FirstOrDefault(s => s.OsobaID == id));
        }


    }
}
