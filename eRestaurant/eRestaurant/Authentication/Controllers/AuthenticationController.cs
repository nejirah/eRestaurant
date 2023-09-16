using eRestaurant.Authentication.Models;
using eRestaurant.Authentication.ViewModels;
using eRestaurant.Data;
using eRestaurant.Helper;
using eRestaurant.Models;
using eRestaurant.ViewModels;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;
using static FIT_Api_Examples.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;

namespace eRestaurant.Authentication.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthenticationController:ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthenticationController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{code}")]
        public ActionResult Otkljucaj(string code)
        {
            var korisnickiNalog = HttpContext.GetLoginInfo().korisnickiNalog;
            var nesto = HttpContext.GetLoginInfo();

            if (korisnickiNalog == null)
            {
                return BadRequest("korisnik nije logiran");
            }

            var token = _dbContext.AutentikacijaToken.FirstOrDefault(s => s.TwoFCode == code && s.korisnickiNalogId == korisnickiNalog.OsobaID);
            if (token != null)
            {
                token.TwoFJelOtkljucano = true;
                _dbContext.SaveChanges();
                return Ok(token);
            }

            return BadRequest("pogresan URL");
        }

        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] LoginViewModel x)
        {
            //1- provjera logina
            KorisnickiNalog? logiraniKorisnik = _dbContext.KorisnickiNalog
                .FirstOrDefault(k =>
                 k.Username == x.username && k.Password == x.password);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return new LoginInformacije(null);
            }

            //2- generisati random string
            string randomString = TokenGenerator.Generate(10);
            string twoFCode = TokenGenerator.Generate(4);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AuthenticationToken()
            {
                IPAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "",
                vrijednost = randomString,
                korisnickiNalog = logiraniKorisnik,
                vrijemeEvidentiranja = DateTime.Now,
                TwoFCode = twoFCode
            };

            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();

            EmailLog.uspjesnoLogiranKorisnik(noviToken, Request.HttpContext);

            //4- vratiti token string
            return new LoginInformacije(noviToken);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return BadRequest();

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<AuthenticationToken?> Get()
        {
            AuthenticationToken? autentifikacijaToken = HttpContext.GetAuthToken();

            return autentifikacijaToken;
        }

    }
}
