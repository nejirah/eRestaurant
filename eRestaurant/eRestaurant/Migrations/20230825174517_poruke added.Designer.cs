﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eRestaurant.Data;

#nullable disable

namespace eRestaurant.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230825174517_poruke added")]
    partial class porukeadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eRestaurant.Authentication.Models.AuthenticationToken", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("IPAdresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwoFCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFJelOtkljucano")
                        .HasColumnType("bit");

                    b.Property<int>("korisnickiNalogId")
                        .HasColumnType("int");

                    b.Property<string>("vrijednost")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("vrijemeEvidentiranja")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.HasIndex("korisnickiNalogId");

                    b.ToTable("AutentikacijaToken");
                });

            modelBuilder.Entity("eRestaurant.Authentication.Models.KorisnickiNalog", b =>
                {
                    b.Property<int>("OsobaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OsobaID"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OsobaID");

                    b.ToTable("KorisnickiNalog");
                });

            modelBuilder.Entity("eRestaurant.Authentication.Models.LogKretanjePoSistemu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ExceptionMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IPAdresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("PostData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QueryPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Vrijeme")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isException")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikID");

                    b.ToTable("LogKretanjePoSistemu");
                });

            modelBuilder.Entity("eRestaurant.Models.Dobavljac", b =>
                {
                    b.Property<int>("DobavljacID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DobavljacID"), 1L, 1);

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrojUgovora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KontaktOsoba")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivKompanije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DobavljacID");

                    b.ToTable("Dobavljaci");
                });

            modelBuilder.Entity("eRestaurant.Models.Inventar", b =>
                {
                    b.Property<int>("InventarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InventarID"), 1L, 1);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("RadnikID")
                        .HasColumnType("int");

                    b.Property<int>("SastojakID")
                        .HasColumnType("int");

                    b.Property<int>("StanjeNaSkladistu")
                        .HasColumnType("int");

                    b.HasKey("InventarID");

                    b.HasIndex("RadnikID");

                    b.HasIndex("SastojakID");

                    b.ToTable("Inventari");
                });

            modelBuilder.Entity("eRestaurant.Models.KorisnickeAdrese", b =>
                {
                    b.Property<int>("KorickaAdresaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KorickaAdresaID"), 1L, 1);

                    b.Property<string>("BrojUlice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("NazivAdreseStanovanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostanskiBroj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KorickaAdresaID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("KorisnickeAdrese");
                });

            modelBuilder.Entity("eRestaurant.Models.Kupon", b =>
                {
                    b.Property<int>("KuponID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KuponID"), 1L, 1);

                    b.Property<bool>("Aktiviran")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DatumAktivacije")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumDeaktivacije")
                        .HasColumnType("datetime2");

                    b.Property<string>("Kategorija")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Popust")
                        .HasColumnType("real");

                    b.HasKey("KuponID");

                    b.ToTable("Kuponi");
                });

            modelBuilder.Entity("eRestaurant.Models.Meni", b =>
                {
                    b.Property<int>("MeniID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeniID"), 1L, 1);

                    b.Property<DateTime?>("DatumIstekaMenija")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumOdobrenjaMenija")
                        .HasColumnType("datetime2");

                    b.Property<string>("DodatnaNapomena")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeniID");

                    b.ToTable("Meniji");
                });

            modelBuilder.Entity("eRestaurant.Models.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NarudzbaID"), 1L, 1);

                    b.Property<DateTime>("DatumNarudzbe")
                        .HasColumnType("datetime2");

                    b.Property<string>("DodatnaNapomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DostavljacID")
                        .HasColumnType("int");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<float>("Popust")
                        .HasColumnType("real");

                    b.Property<int>("RadnikID")
                        .HasColumnType("int");

                    b.Property<string>("StatusNarudzbe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipNarudzbe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("UkupnaCijena")
                        .HasColumnType("float");

                    b.Property<double>("UkupnaCijenaBezPopusta")
                        .HasColumnType("float");

                    b.Property<int?>("UplataID")
                        .HasColumnType("int");

                    b.HasKey("NarudzbaID");

                    b.HasIndex("DostavljacID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("RadnikID");

                    b.HasIndex("UplataID");

                    b.ToTable("Narudzbe");
                });

            modelBuilder.Entity("eRestaurant.Models.Pitanje", b =>
                {
                    b.Property<int>("PitanjeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PitanjeID"), 1L, 1);

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("Odgovor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RadnikID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PitanjeID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("RadnikID");

                    b.ToTable("Pitanja");
                });

            modelBuilder.Entity("eRestaurant.Models.Poruke", b =>
                {
                    b.Property<int>("PorukaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PorukaID"), 1L, 1);

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PorukaID");

                    b.ToTable("Poruke");
                });

            modelBuilder.Entity("eRestaurant.Models.Proizvod", b =>
                {
                    b.Property<int>("ProizvodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProizvodID"), 1L, 1);

                    b.Property<string>("JedinicaMjere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NazivProizvoda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PocetnaCijena")
                        .HasColumnType("float");

                    b.Property<int>("ProizvodiKategorijeID")
                        .HasColumnType("int");

                    b.Property<float>("Recenzija")
                        .HasColumnType("real");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("isFavorite")
                        .HasColumnType("bit");

                    b.HasKey("ProizvodID");

                    b.HasIndex("ProizvodiKategorijeID");

                    b.ToTable("Proizvodi");
                });

            modelBuilder.Entity("eRestaurant.Models.ProizvodiKategorije", b =>
                {
                    b.Property<int>("ProizvodiKategorijeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProizvodiKategorijeID"), 1L, 1);

                    b.Property<string>("NazivKategorije")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProizvodiKategorijeID");

                    b.ToTable("ProizvodiKategorije");
                });

            modelBuilder.Entity("eRestaurant.Models.Rezervacija", b =>
                {
                    b.Property<int>("RezervacijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RezervacijaID"), 1L, 1);

                    b.Property<int>("BrojOsoba")
                        .HasColumnType("int");

                    b.Property<int>("BrojStola")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatumRezervacije")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RadnikID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RezervacijaID");

                    b.HasIndex("KorisnikID");

                    b.HasIndex("RadnikID");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("eRestaurant.Models.SanitarnaDeratizacija", b =>
                {
                    b.Property<int>("SanitarnaDeratizacijaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanitarnaDeratizacijaID"), 1L, 1);

                    b.Property<string>("BrojUgovora")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumInspekcije")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumOvjere")
                        .HasColumnType("datetime2");

                    b.Property<string>("DodatnaNapomena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PDF")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("PrilozenPDF")
                        .HasColumnType("bit");

                    b.Property<int>("RadnikID")
                        .HasColumnType("int");

                    b.HasKey("SanitarnaDeratizacijaID");

                    b.HasIndex("RadnikID");

                    b.ToTable("SanitarneDeratizacije");
                });

            modelBuilder.Entity("eRestaurant.Models.Sastojak", b =>
                {
                    b.Property<int>("SastojakID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SastojakID"), 1L, 1);

                    b.Property<int>("DobavljacID")
                        .HasColumnType("int");

                    b.Property<int>("KolicinaNaStanju")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SastojciKategorijeID")
                        .HasColumnType("int");

                    b.HasKey("SastojakID");

                    b.HasIndex("DobavljacID");

                    b.HasIndex("SastojciKategorijeID");

                    b.ToTable("Sastojci");
                });

            modelBuilder.Entity("eRestaurant.Models.SastojciKategorije", b =>
                {
                    b.Property<int>("SastojciKategorijeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SastojciKategorijeID"), 1L, 1);

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SastojciKategorijeID");

                    b.ToTable("SastojciKategorije");
                });

            modelBuilder.Entity("eRestaurant.Models.SastojciProizvoda", b =>
                {
                    b.Property<int>("SastojciProizvodaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SastojciProizvodaID"), 1L, 1);

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.Property<int>("SastojakID")
                        .HasColumnType("int");

                    b.HasKey("SastojciProizvodaID");

                    b.HasIndex("ProizvodID");

                    b.HasIndex("SastojakID");

                    b.ToTable("SastojciProizvoda");
                });

            modelBuilder.Entity("eRestaurant.Models.StavkeMenia", b =>
                {
                    b.Property<int>("StavkeMeniaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StavkeMeniaID"), 1L, 1);

                    b.Property<int>("MeniID")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("StavkeMeniaID");

                    b.HasIndex("MeniID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("StavkeMenia");
                });

            modelBuilder.Entity("eRestaurant.Models.StavkeNarudzbe", b =>
                {
                    b.Property<int>("StavkeNarudzbeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StavkeNarudzbeID"), 1L, 1);

                    b.Property<double>("Cijena")
                        .HasColumnType("float");

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int?>("KuponID")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaID")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodID")
                        .HasColumnType("int");

                    b.HasKey("StavkeNarudzbeID");

                    b.HasIndex("KuponID");

                    b.HasIndex("NarudzbaID");

                    b.HasIndex("ProizvodID");

                    b.ToTable("StavkeNarudzbe");
                });

            modelBuilder.Entity("eRestaurant.Models.Uplata", b =>
                {
                    b.Property<int>("UplataID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UplataID"), 1L, 1);

                    b.Property<string>("BrojKartice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<double>("IznosZaUplatu")
                        .HasColumnType("float");

                    b.Property<string>("NacinPlacanja")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UplataID");

                    b.ToTable("Uplate");
                });

            modelBuilder.Entity("eRestaurant.Models.Korisnik", b =>
                {
                    b.HasBaseType("eRestaurant.Authentication.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Korisnici");
                });

            modelBuilder.Entity("eRestaurant.Models.Radnik", b =>
                {
                    b.HasBaseType("eRestaurant.Authentication.Models.KorisnickiNalog");

                    b.Property<string>("BrojTelefona")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumZaposlenja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DatumZavrsetkaRadnogOdnosa")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KategorijaVozacke")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PoslovniBrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pozicija")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrevoznoSredstvo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Spol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zvanje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Radnici");
                });

            modelBuilder.Entity("eRestaurant.Authentication.Models.AuthenticationToken", b =>
                {
                    b.HasOne("eRestaurant.Authentication.Models.KorisnickiNalog", "korisnickiNalog")
                        .WithMany()
                        .HasForeignKey("korisnickiNalogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("korisnickiNalog");
                });

            modelBuilder.Entity("eRestaurant.Authentication.Models.LogKretanjePoSistemu", b =>
                {
                    b.HasOne("eRestaurant.Authentication.Models.KorisnickiNalog", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eRestaurant.Models.Inventar", b =>
                {
                    b.HasOne("eRestaurant.Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.Sastojak", "Sastojak")
                        .WithMany()
                        .HasForeignKey("SastojakID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Radnik");

                    b.Navigation("Sastojak");
                });

            modelBuilder.Entity("eRestaurant.Models.KorisnickeAdrese", b =>
                {
                    b.HasOne("eRestaurant.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("eRestaurant.Models.Narudzba", b =>
                {
                    b.HasOne("eRestaurant.Models.Radnik", "Dostavljac")
                        .WithMany()
                        .HasForeignKey("DostavljacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.Uplata", "Uplata")
                        .WithMany()
                        .HasForeignKey("UplataID");

                    b.Navigation("Dostavljac");

                    b.Navigation("Korisnik");

                    b.Navigation("Radnik");

                    b.Navigation("Uplata");
                });

            modelBuilder.Entity("eRestaurant.Models.Pitanje", b =>
                {
                    b.HasOne("eRestaurant.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Radnik");
                });

            modelBuilder.Entity("eRestaurant.Models.Proizvod", b =>
                {
                    b.HasOne("eRestaurant.Models.ProizvodiKategorije", "ProizvodiKategorije")
                        .WithMany()
                        .HasForeignKey("ProizvodiKategorijeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProizvodiKategorije");
                });

            modelBuilder.Entity("eRestaurant.Models.Rezervacija", b =>
                {
                    b.HasOne("eRestaurant.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("Radnik");
                });

            modelBuilder.Entity("eRestaurant.Models.SanitarnaDeratizacija", b =>
                {
                    b.HasOne("eRestaurant.Models.Radnik", "Radnik")
                        .WithMany()
                        .HasForeignKey("RadnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Radnik");
                });

            modelBuilder.Entity("eRestaurant.Models.Sastojak", b =>
                {
                    b.HasOne("eRestaurant.Models.Dobavljac", "Dobavljac")
                        .WithMany()
                        .HasForeignKey("DobavljacID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.SastojciKategorije", "SastojciKategorije")
                        .WithMany()
                        .HasForeignKey("SastojciKategorijeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dobavljac");

                    b.Navigation("SastojciKategorije");
                });

            modelBuilder.Entity("eRestaurant.Models.SastojciProizvoda", b =>
                {
                    b.HasOne("eRestaurant.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.Sastojak", "Sastojak")
                        .WithMany()
                        .HasForeignKey("SastojakID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proizvod");

                    b.Navigation("Sastojak");
                });

            modelBuilder.Entity("eRestaurant.Models.StavkeMenia", b =>
                {
                    b.HasOne("eRestaurant.Models.Meni", "Meni")
                        .WithMany()
                        .HasForeignKey("MeniID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.ProizvodiKategorije", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meni");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("eRestaurant.Models.StavkeNarudzbe", b =>
                {
                    b.HasOne("eRestaurant.Models.Kupon", "Kupon")
                        .WithMany()
                        .HasForeignKey("KuponID");

                    b.HasOne("eRestaurant.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eRestaurant.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kupon");

                    b.Navigation("Narudzba");

                    b.Navigation("Proizvod");
                });

            modelBuilder.Entity("eRestaurant.Models.Korisnik", b =>
                {
                    b.HasOne("eRestaurant.Authentication.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("eRestaurant.Models.Korisnik", "OsobaID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("eRestaurant.Models.Radnik", b =>
                {
                    b.HasOne("eRestaurant.Authentication.Models.KorisnickiNalog", null)
                        .WithOne()
                        .HasForeignKey("eRestaurant.Models.Radnik", "OsobaID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
