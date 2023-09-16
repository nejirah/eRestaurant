using System.Collections.Generic;
using System.Linq;
using eRestaurant.Data;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace eRestaurant.SignalR
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestirajSignalRController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHubContext<PorukeHub> _porukeHub;

        public TestirajSignalRController(ApplicationDbContext dbContext, IHubContext<PorukeHub> porukeHub)
        {
            this._dbContext = dbContext;
            _porukeHub = porukeHub;
        }
      

        [HttpGet]
        public async Task<ActionResult> PosaljiPoruku(string p)
        {
            await _porukeHub.Clients.All.SendAsync("slanje_poruke1", p);

            return Ok();
        }

        [HttpPost]
        public ActionResult Add(PorukeAddViewModel p)
        {
            var poruka = new Poruke
            {
                Opis = p.opis
            };

            _dbContext.Add(poruka);
            _dbContext.SaveChanges();
            return Ok(poruka);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_dbContext.Poruke.OrderByDescending(s => s.PorukaID).ToList());
        }


    }
}
