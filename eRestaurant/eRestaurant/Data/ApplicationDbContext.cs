using eRestaurant.Authentication.Models;
using eRestaurant.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eRestaurant.Data
{
    public class ApplicationDbContext:DbContext
    {

        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Sastojak> Sastojci { get; set; }
        public DbSet<SastojciKategorije> SastojciKategorije { get; set; }
        public DbSet<Dobavljac> Dobavljaci { get; set; }
        public DbSet<Inventar> Inventari { get; set; }
        public DbSet<Kupon> Kuponi { get; set; }
        public DbSet<Meni> Meniji { get; set; }
        public DbSet<Pitanje> Pitanja { get; set; }
        public DbSet<Radnik> Radnici { get; set; }
        public DbSet<SanitarnaDeratizacija> SanitarneDeratizacije { get; set; }
        public DbSet<SastojciProizvoda> SastojciProizvoda { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<KorisnickeAdrese> KorisnickeAdrese { get; set; }
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<ProizvodiKategorije> ProizvodiKategorije { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<StavkeMenia> StavkeMenia { get; set; }
        public DbSet<StavkeNarudzbe> StavkeNarudzbe { get; set; }
        public DbSet<Uplata> Uplate { get; set; }
        public DbSet<AuthenticationToken> AutentikacijaToken { get; set; }
        public DbSet<LogKretanjePoSistemu> LogKretanjePoSistemu { get; set; }
        public DbSet<Poruke> Poruke { get; set; }
        public DbSet<KuponiKorisnika> KuponiKorisnika { get; set; }
        public DbSet<FavoriteProizvodi> FavoritiKorisnika { get; set; }

        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
    }
}
