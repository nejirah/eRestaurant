using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eRestaurant.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KuponController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public KuponController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_dbContext.Kuponi.OrderByDescending(k=>k.KuponID).ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            return Ok(
                _dbContext.Kuponi.FirstOrDefault(k => k.KuponID == id)
                );
        }
    }
}
