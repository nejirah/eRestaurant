using eRestaurant.Authentication;
using eRestaurant.Data;
using eRestaurant.Models;
using Microsoft.AspNetCore.Mvc;

namespace eRestaurant.Testni_Podaci
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class TestniPodaciController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TestniPodaciController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var Dobavljac = new List<Dobavljac>();
            var Korisnik = new List<Korisnik>();
            var KorisnickeAdrese = new List<KorisnickeAdrese>();
            var Kupon = new List<Kupon>();
            var Meni = new List<Meni>();
            var Radnik = new List<Radnik>();
            var Proizvod = new List<Proizvod>();
            var Narudzba = new List<Narudzba>();
            var Pitanje = new List<Pitanje>();
            var ProizvodiKategorije = new List<ProizvodiKategorije>();
            var Rezervacija = new List<Rezervacija>();
            var Sastojak = new List<Sastojak>();
            var SastojciKategorije = new List<SastojciKategorije>();
            var SastojciProizvoda = new List<SastojciProizvoda>();
            var StavkeMenia = new List<StavkeMenia>();
            var StavkeNarudzbe = new List<StavkeNarudzbe>();
            var Uplata = new List<Uplata>();

            Dobavljac.Add(new Dobavljac { BrojTelefona = "+387 61 555 123", BrojUgovora = "AS556FF525165", KontaktOsoba = "Ivo Ivic", NazivKompanije = "Komapnija 1" });
            Korisnik.Add(new Korisnik { Username = "Korisnik1", Email = "korisnik.1@gmail.com", Password = "111123", Ime = "Suljo", Prezime = "Suljic", BrojTelefona = "+387 61 554 987" });

            _dbContext.AddRange(Dobavljac);
            _dbContext.AddRange(Korisnik);
            _dbContext.SaveChanges();


            Kupon.Add(new Kupon { DatumAktivacije= DateTime.Now, DatumDeaktivacije= DateTime.Now, Popust=20});
            KorisnickeAdrese.Add(new KorisnickeAdrese { KorisnikID = 1, BrojUlice = "10", NazivAdreseStanovanja = "Ulica branilaca", PostanskiBroj = "71000" });
            Meni.Add(new Meni { DatumIstekaMenija = DateTime.Now, DatumOdobrenjaMenija = DateTime.Now });
            Radnik.Add(new Radnik { Username = "Korisnik2", Email = "korisnik.2@gmail.com", Password = "111123", Pozicija="Konobar", BrojTelefona="+387 63 225 883", DatumZaposlenja= DateTime.Now, Ime="Mujo", Prezime="Mujic", JMBG="0201003665987", Spol="Muski", Zvanje="Maturant gimnazije" });
            Radnik.Add(new Radnik { Username = "Dostavljac", Email = "korisnik.dostavljac@gmail.com", Password = "111123", Pozicija = "Dostavljac", BrojTelefona = "+387 63 225 883", DatumZaposlenja = DateTime.Now, Ime = "Pero", Prezime = "Peric", JMBG = "0201003665987", Spol = "Muski", Zvanje = "Maturant gimnazije" });
            Radnik.Add(new Radnik { Username = "Administrator", Email = "korisnik.administrator@gmail.com", Password = "111123", Pozicija = "Administrator", BrojTelefona = "+387 63 225 883", DatumZaposlenja = DateTime.Now, Ime = "Hiro", Prezime = "Hiric", JMBG = "0201003665987", Spol = "Muski", Zvanje = "Diplomirani ekonomista" });

            _dbContext.AddRange(Kupon);
            _dbContext.AddRange(KorisnickeAdrese);
            _dbContext.AddRange(Meni);
            _dbContext.AddRange(Radnik);
            _dbContext.SaveChanges();

            Uplata.Add(new Uplata { Datum = DateTime.Now, NacinPlacanja = "Gotovina", IznosZaUplatu = 30 });
            _dbContext.AddRange(Uplata);
            _dbContext.SaveChanges();

            Narudzba.Add(new Narudzba {  DatumNarudzbe = DateTime.Now, DostavljacID = 3, KorisnikID = 1, RadnikID = 2, StatusNarudzbe = "New", TipNarudzbe = "New", Popust = 0, UkupnaCijena = 25.9, UkupnaCijenaBezPopusta = 25.9, UplataID = 1 });
            Pitanje.Add(new Pitanje { KorisnikID = 1, RadnikID = 4, Datum = DateTime.Now, Opis = "Pitanje1", Status = "Neodgovoreno" });
            ProizvodiKategorije.Add(new ProizvodiKategorije { NazivKategorije = "Pice" });
            _dbContext.AddRange(Narudzba);
            _dbContext.AddRange(Pitanje);
            _dbContext.AddRange(ProizvodiKategorije);
            _dbContext.SaveChanges();

            Proizvod.Add(new Proizvod { JedinicaMjere = "200 ml", NazivProizvoda = "Coca cola", Opis = "Osvjezavajuce gazirano pice", PocetnaCijena = 2.5, ProizvodiKategorijeID = 1, Recenzija = 4 });
            Rezervacija.Add(new Rezervacija { BrojOsoba = 4, BrojStola = 1, DatumRezervacije = DateTime.Now, KorisnikID = 1, RadnikID = 2, Status = "New" });
            _dbContext.AddRange(Proizvod);
            _dbContext.AddRange(Rezervacija);
            _dbContext.SaveChanges();

            SastojciKategorije.Add(new SastojciKategorije { Naziv = "Prašak" });
            _dbContext.AddRange(SastojciKategorije);
            _dbContext.SaveChanges();

            Sastojak.Add(new Sastojak { DobavljacID = 1, KolicinaNaStanju = 4, Naziv = "Šećer", SastojciKategorijeID = 1 });
            _dbContext.AddRange(SastojciProizvoda);
            _dbContext.SaveChanges();
            
            SastojciProizvoda.Add(new SastojciProizvoda { ProizvodID = 1, SastojakID = 1 });
            StavkeMenia.Add(new StavkeMenia { ProizvodID = 1, MeniID = 1 });
            StavkeNarudzbe.Add(new StavkeNarudzbe { KuponID = 1, Kolicina = 3, NarudzbaID = 1, ProizvodID = 1, Cijena = 7.5 });
            _dbContext.AddRange(StavkeMenia);
            _dbContext.AddRange(StavkeNarudzbe);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
