using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eRestaurant.Migrations
{
    public partial class izmjenaBaze : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dobavljaci",
                columns: table => new
                {
                    DobavljacID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKompanije = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojUgovora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KontaktOsoba = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobavljaci", x => x.DobavljacID);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickiNalog",
                columns: table => new
                {
                    OsobaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickiNalog", x => x.OsobaID);
                });

            migrationBuilder.CreateTable(
                name: "Kuponi",
                columns: table => new
                {
                    KuponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumAktivacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumDeaktivacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Popust = table.Column<float>(type: "real", nullable: false),
                    Deaktiviran = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kuponi", x => x.KuponID);
                });

            migrationBuilder.CreateTable(
                name: "Meniji",
                columns: table => new
                {
                    MeniID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumOdobrenjaMenija = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIstekaMenija = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DodatnaNapomena = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meniji", x => x.MeniID);
                });

            migrationBuilder.CreateTable(
                name: "ProizvodiKategorije",
                columns: table => new
                {
                    ProizvodiKategorijeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivKategorije = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProizvodiKategorije", x => x.ProizvodiKategorijeID);
                });

            migrationBuilder.CreateTable(
                name: "SastojciKategorije",
                columns: table => new
                {
                    SastojciKategorijeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SastojciKategorije", x => x.SastojciKategorijeID);
                });

            migrationBuilder.CreateTable(
                name: "Uplate",
                columns: table => new
                {
                    UplataID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IznosZaUplatu = table.Column<double>(type: "float", nullable: false),
                    NacinPlacanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojKartice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplate", x => x.UplataID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    OsobaID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.OsobaID);
                    table.ForeignKey(
                        name: "FK_Korisnici_KorisnickiNalog_OsobaID",
                        column: x => x.OsobaID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "OsobaID");
                });

            migrationBuilder.CreateTable(
                name: "Radnici",
                columns: table => new
                {
                    OsobaID = table.Column<int>(type: "int", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumZaposlenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetkaRadnogOdnosa = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Zvanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JMBG = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Spol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pozicija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoslovniBrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategorijaVozacke = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrevoznoSredstvo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnici", x => x.OsobaID);
                    table.ForeignKey(
                        name: "FK_Radnici_KorisnickiNalog_OsobaID",
                        column: x => x.OsobaID,
                        principalTable: "KorisnickiNalog",
                        principalColumn: "OsobaID");
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    ProizvodID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivProizvoda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PocetnaCijena = table.Column<double>(type: "float", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recenzija = table.Column<int>(type: "int", nullable: false),
                    Slika = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    JedinicaMjere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProizvodiKategorijeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.ProizvodID);
                    table.ForeignKey(
                        name: "FK_Proizvodi_ProizvodiKategorije_ProizvodiKategorijeID",
                        column: x => x.ProizvodiKategorijeID,
                        principalTable: "ProizvodiKategorije",
                        principalColumn: "ProizvodiKategorijeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StavkeMenia",
                columns: table => new
                {
                    StavkeMeniaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    MeniID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeMenia", x => x.StavkeMeniaID);
                    table.ForeignKey(
                        name: "FK_StavkeMenia_Meniji_MeniID",
                        column: x => x.MeniID,
                        principalTable: "Meniji",
                        principalColumn: "MeniID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StavkeMenia_ProizvodiKategorije_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "ProizvodiKategorije",
                        principalColumn: "ProizvodiKategorijeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sastojci",
                columns: table => new
                {
                    SastojakID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KolicinaNaStanju = table.Column<int>(type: "int", nullable: false),
                    DobavljacID = table.Column<int>(type: "int", nullable: false),
                    SastojciKategorijeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastojci", x => x.SastojakID);
                    table.ForeignKey(
                        name: "FK_Sastojci_Dobavljaci_DobavljacID",
                        column: x => x.DobavljacID,
                        principalTable: "Dobavljaci",
                        principalColumn: "DobavljacID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Sastojci_SastojciKategorije_SastojciKategorijeID",
                        column: x => x.SastojciKategorijeID,
                        principalTable: "SastojciKategorije",
                        principalColumn: "SastojciKategorijeID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "KorisnickeAdrese",
                columns: table => new
                {
                    KorickaAdresaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivAdreseStanovanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojUlice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostanskiBroj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KorisnickeAdrese", x => x.KorickaAdresaID);
                    table.ForeignKey(
                        name: "FK_KorisnickeAdrese_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Narudzbe",
                columns: table => new
                {
                    NarudzbaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipNarudzbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UkupnaCijenaBezPopusta = table.Column<double>(type: "float", nullable: false),
                    Popust = table.Column<float>(type: "real", nullable: false),
                    UkupnaCijena = table.Column<double>(type: "float", nullable: false),
                    StatusNarudzbe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DodatnaNapomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CijenaBezPDV = table.Column<double>(type: "float", nullable: false),
                    PDV = table.Column<int>(type: "int", nullable: false),
                    UkupnaCijenaSaPDV = table.Column<double>(type: "float", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false),
                    DostavljacID = table.Column<int>(type: "int", nullable: false),
                    UplataID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzbe", x => x.NarudzbaID);
                    table.ForeignKey(
                        name: "FK_Narudzbe_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Narudzbe_Radnici_DostavljacID",
                        column: x => x.DostavljacID,
                        principalTable: "Radnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Narudzbe_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Narudzbe_Uplate_UplataID",
                        column: x => x.UplataID,
                        principalTable: "Uplate",
                        principalColumn: "UplataID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Pitanja",
                columns: table => new
                {
                    PitanjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitanja", x => x.PitanjeID);
                    table.ForeignKey(
                        name: "FK_Pitanja_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Pitanja_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacije",
                columns: table => new
                {
                    RezervacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumRezervacije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojOsoba = table.Column<int>(type: "int", nullable: false),
                    BrojStola = table.Column<int>(type: "int", nullable: false),
                    Napomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacije", x => x.RezervacijaID);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Rezervacije_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SanitarneDeratizacije",
                columns: table => new
                {
                    SanitarnaDeratizacijaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumInspekcije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BrojUgovora = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumOvjere = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DodatnaNapomena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PDF = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PrilozenPDF = table.Column<bool>(type: "bit", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanitarneDeratizacije", x => x.SanitarnaDeratizacijaID);
                    table.ForeignKey(
                        name: "FK_SanitarneDeratizacije_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Inventari",
                columns: table => new
                {
                    InventarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StanjeNaSkladistu = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SastojakID = table.Column<int>(type: "int", nullable: false),
                    RadnikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventari", x => x.InventarID);
                    table.ForeignKey(
                        name: "FK_Inventari_Radnici_RadnikID",
                        column: x => x.RadnikID,
                        principalTable: "Radnici",
                        principalColumn: "OsobaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Inventari_Sastojci_SastojakID",
                        column: x => x.SastojakID,
                        principalTable: "Sastojci",
                        principalColumn: "SastojakID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SastojciProizvoda",
                columns: table => new
                {
                    SastojciProizvodaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    SastojakID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SastojciProizvoda", x => x.SastojciProizvodaID);
                    table.ForeignKey(
                        name: "FK_SastojciProizvoda_Proizvodi_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_SastojciProizvoda_Sastojci_SastojakID",
                        column: x => x.SastojakID,
                        principalTable: "Sastojci",
                        principalColumn: "SastojakID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "StavkeNarudzbe",
                columns: table => new
                {
                    StavkeNarudzbeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cijena = table.Column<double>(type: "float", nullable: false),
                    DodatnaNapomena = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Popust = table.Column<float>(type: "real", nullable: false),
                    NarudzbaID = table.Column<int>(type: "int", nullable: false),
                    ProizvodID = table.Column<int>(type: "int", nullable: false),
                    KuponID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeNarudzbe", x => x.StavkeNarudzbeID);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbe_Kuponi_KuponID",
                        column: x => x.KuponID,
                        principalTable: "Kuponi",
                        principalColumn: "KuponID");
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbe_Narudzbe_NarudzbaID",
                        column: x => x.NarudzbaID,
                        principalTable: "Narudzbe",
                        principalColumn: "NarudzbaID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_StavkeNarudzbe_Proizvodi_ProizvodID",
                        column: x => x.ProizvodID,
                        principalTable: "Proizvodi",
                        principalColumn: "ProizvodID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventari_RadnikID",
                table: "Inventari",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Inventari_SastojakID",
                table: "Inventari",
                column: "SastojakID");

            migrationBuilder.CreateIndex(
                name: "IX_KorisnickeAdrese_KorisnikID",
                table: "KorisnickeAdrese",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_DostavljacID",
                table: "Narudzbe",
                column: "DostavljacID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_KorisnikID",
                table: "Narudzbe",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_RadnikID",
                table: "Narudzbe",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzbe_UplataID",
                table: "Narudzbe",
                column: "UplataID");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanja_KorisnikID",
                table: "Pitanja",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Pitanja_RadnikID",
                table: "Pitanja",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvodi_ProizvodiKategorijeID",
                table: "Proizvodi",
                column: "ProizvodiKategorijeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_KorisnikID",
                table: "Rezervacije",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacije_RadnikID",
                table: "Rezervacije",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_SanitarneDeratizacije_RadnikID",
                table: "SanitarneDeratizacije",
                column: "RadnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Sastojci_DobavljacID",
                table: "Sastojci",
                column: "DobavljacID");

            migrationBuilder.CreateIndex(
                name: "IX_Sastojci_SastojciKategorijeID",
                table: "Sastojci",
                column: "SastojciKategorijeID");

            migrationBuilder.CreateIndex(
                name: "IX_SastojciProizvoda_ProizvodID",
                table: "SastojciProizvoda",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_SastojciProizvoda_SastojakID",
                table: "SastojciProizvoda",
                column: "SastojakID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeMenia_MeniID",
                table: "StavkeMenia",
                column: "MeniID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeMenia_ProizvodID",
                table: "StavkeMenia",
                column: "ProizvodID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbe_KuponID",
                table: "StavkeNarudzbe",
                column: "KuponID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbe_NarudzbaID",
                table: "StavkeNarudzbe",
                column: "NarudzbaID");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeNarudzbe_ProizvodID",
                table: "StavkeNarudzbe",
                column: "ProizvodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventari");

            migrationBuilder.DropTable(
                name: "KorisnickeAdrese");

            migrationBuilder.DropTable(
                name: "Pitanja");

            migrationBuilder.DropTable(
                name: "Rezervacije");

            migrationBuilder.DropTable(
                name: "SanitarneDeratizacije");

            migrationBuilder.DropTable(
                name: "SastojciProizvoda");

            migrationBuilder.DropTable(
                name: "StavkeMenia");

            migrationBuilder.DropTable(
                name: "StavkeNarudzbe");

            migrationBuilder.DropTable(
                name: "Sastojci");

            migrationBuilder.DropTable(
                name: "Meniji");

            migrationBuilder.DropTable(
                name: "Kuponi");

            migrationBuilder.DropTable(
                name: "Narudzbe");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Dobavljaci");

            migrationBuilder.DropTable(
                name: "SastojciKategorije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Radnici");

            migrationBuilder.DropTable(
                name: "Uplate");

            migrationBuilder.DropTable(
                name: "ProizvodiKategorije");

            migrationBuilder.DropTable(
                name: "KorisnickiNalog");
        }
    }
}
