import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AutentifikacijaHelper } from '../helpers/autentifikacija-helper';
import { Router } from '@angular/router';

interface Coupon {
  naziv: string;
  kategorija: string;
  popust: number;
}

interface CouponEntry {
  kuponiKorisnikaID: number;
  kupon: Coupon; // Assuming that Kupon is a property of type Coupon
  korisnikID: number;
  kuponID:number;
  korisnik: any; // You can replace 'any' with the actual type if available
  isUsed: boolean;
}

@Component({
  selector: 'app-root',
  templateUrl: './proizvodi.component.html',
  styleUrls: ['./proizvodi.component.css']
})

export class ProizvodiComponent implements OnInit{
  proizvodi_podaci:any = [];
  filter_proizvod: any;
  odabrani_proizvod: any;
  stavke_narudzbe_podaci:any;

  previewActivated:boolean=false;
  slikaBase64string: string = "";

  isCouponUsed:any;
  vrsta_proizvoda:string= "All";
  newPodaci:any;
  filter_podaci: any="";
  alert_message:string="";
  isAlert:boolean=false;
  isAlertError:boolean=false;
  alert_message_error:string="";
  odabrani_review:any=false;
  ocjenaProizvoda:any;
  myForm: FormGroup;
  isSastojci:any;
  sastojci_proizvoda:any;
  isNarudzba:any=false;
  kuponi_podaci:any;

  initalNaurzdba:any = {
    tipNarudzbe:"",
    ukupnaCijenaBezPopusta:0,
    popust:0,
    ukupnaCijena:0,
    statusNarudzbe:"New",
    datumNarudzbe:Date.now,
    korisnikID:AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
    radnikID:2,
    dostavljacID:2,
  }

  saljemo:any;

constructor(private httpKlijent: HttpClient, private fb:FormBuilder,  private router: Router) {
  this.myForm = this.fb.group({
    review: ['', [Validators.required, Validators.pattern(/^[1-5]+$/)]],
    // Other form controls
  });
}

  ngOnInit(): void {
    this.preuzmi_podatke();
    this.getKuponi();
  }

  preuzmi_podatke(tipKategorije:any="All"){
    let token = MojConfig.http_opcije();
      this.httpKlijent.get(MojConfig.adresa_servera + "/Proizvod/GetAll",token).subscribe((x: any) => {
        this.proizvodi_podaci=x;
        this.newPodaci= this.proizvodi_podaci;
      })
  }

  preuzmi_proizvode(tipKategorije:any){
    this.vrsta_proizvoda= tipKategorije;
    this.proizvodi_podaci= this.newPodaci;

    if (this.vrsta_proizvoda == 'All' && this.filter_podaci != '') {
        this.proizvodi_podaci= this.proizvodi_podaci.filter((p:any)=> p.nazivProizvoda.toLowerCase().includes(this.filter_podaci.toLowerCase()));
    } 
    
    else if (this.vrsta_proizvoda == 'Drinks' && this.filter_podaci == '') {
        this.proizvodi_podaci = this.proizvodi_podaci.filter((p: any) => p.proizvodiKategorije.nazivKategorije=="Drinks");
    } 
    
    else if (this.vrsta_proizvoda == 'Drinks' && this.filter_podaci != '') {
      this.proizvodi_podaci = this.proizvodi_podaci.filter((p: any) => p.proizvodiKategorije.nazivKategorije=="Drinks" && p.nazivProizvoda.toLowerCase().includes(this.filter_podaci.toLowerCase()));
    } 
      
    else if (this.vrsta_proizvoda == 'Food' && this.filter_podaci == '') {
      this.proizvodi_podaci = this.proizvodi_podaci.filter((p: any) => p.proizvodiKategorije.nazivKategorije=="Food");
    } 
    
    else if (this.vrsta_proizvoda == 'Food' && this.filter_podaci != '') {
      this.proizvodi_podaci = this.proizvodi_podaci.filter((p: any) => p.proizvodiKategorije.nazivKategorije=="Food" && p.nazivProizvoda.toLowerCase().includes(this.filter_podaci.toLowerCase()));
    } 

    else if (this.vrsta_proizvoda == 'Dessert' && this.filter_podaci == '') {
      this.proizvodi_podaci = this.proizvodi_podaci.filter((p: any) => p.proizvodiKategorije.nazivKategorije=="Dessert");
    } 
    
    else if (this.vrsta_proizvoda == 'Dessert' && this.filter_podaci != '') {
      this.proizvodi_podaci = this.proizvodi_podaci.filter((p: any) => p.proizvodiKategorije.nazivKategorije=="Dessert" && p.nazivProizvoda.toLowerCase().includes(this.filter_podaci.toLowerCase()));
    } 
    else {
      this.proizvodi_podaci= this.newPodaci;
    }
  }

  update_ocjenu(x: any) {
    if (this.myForm.valid) {
      this.httpKlijent.post(MojConfig.adresa_servera + "/Proizvod/AddReview/" + x.id, x.id, this.ocjenaProizvoda).subscribe(response => {
        this.alert_message = "Review successfully left.";
        this.isAlert = true;
        this.odabrani_review = false;
        
        setTimeout(() => {
          window.location.reload();
        }, 1000);
      });
    } else {
      this.alert_message_error = "Please fill in the review form correctly.";
      this.isAlertError = true;
      
      setTimeout(() => {
        this.isAlertError = false;
      }, 3000);
    }
  }
  

  update_favorite(x:any){
    let token = MojConfig.http_opcije();
    this.httpKlijent.post(MojConfig.adresa_servera + "/Proizvod/MakeFavorite/" + x.id, x.id,token).subscribe(x=>{
      this.alert_message= "Successful update of favorites."
      this.isAlert=true;

      setTimeout(() => {
        window.location.reload();
      }, 1000);
    });
  }

  remove_favorite(x:any){
    let token = MojConfig.http_opcije();
    this.httpKlijent.post(MojConfig.adresa_servera + "/Proizvod/RemoveFavorite/" + x.id, x.id,token).subscribe(x=>{
      this.alert_message= "Successful update of favorites."
      this.isAlert=true;

      setTimeout(() => {
        window.location.reload();
      }, 1000);
    });
  }
  
  prikazi_sastojke(x:any){
    this.isSastojci=true;
    this.httpKlijent.get(MojConfig.adresa_servera + "/SastojciProizvoda/GetById/" + x.id, x.id).subscribe((x: any) => {
      this.sastojci_proizvoda=x;
    });
  }

  KreirajNarudzbu(){
    this.httpKlijent.post(MojConfig.adresa_servera + "/Narudzba/AddInitial/", this.initalNaurzdba).subscribe(x=>{
      this.isNarudzba=true;
      this.initalNaurzdba=x;
    });
  }

  Delete(){
    this.httpKlijent.post(MojConfig.adresa_servera+"/Narudzba/Delete/" + this.initalNaurzdba.narudzbaID, this.initalNaurzdba.narudzbaID).subscribe((x=>{
      this.initalNaurzdba = {
        tipNarudzbe: "",
        ukupnaCijenaBezPopusta: 0,
        popust: 0,
        ukupnaCijena: 0,
        statusNarudzbe: "New",
        datumNarudzbe: Date.now,
        korisnikID: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
        radnikID: 2,
        dostavljacID: 2,
      };
      this.isNarudzba=false;   
      this.stavke_narudzbe_podaci=null;
    }))  ;
  }

  DodajUKorpu(item:any){
    this.saljemo={
      narudzbaID:this.initalNaurzdba.narudzbaID,
      proizvodID:item.id,
      kolicina:1,
      cijena:item.pocetnaCijena,
      kuponID: null
    }

    this.httpKlijent.post(MojConfig.adresa_servera + "/StavkeNarudzbe/AddToCart/", this.saljemo).subscribe(x=>{
      this.getPodaciKorpe();
      });
  }

  UpdateKolicinu(item:any,value:any){
    let q= parseInt(value.target.value, 10);
    let saljemo ={
      id:item.stavkeNarudzbeID,
      kolicina:q
    }
    this.httpKlijent.post(MojConfig.adresa_servera + "/StavkeNarudzbe/UpdateQuantity/"+ item.stavkeNarudzbeID,saljemo).subscribe(x=>{
      this.getPodaciKorpe();
    });

  }

  getPodaciKorpe(){
    this.httpKlijent.get(MojConfig.adresa_servera + "/StavkeNarudzbe/GetById/" + this.initalNaurzdba.narudzbaID, this.initalNaurzdba.narudzbaID).subscribe((x: any) => {
      this.stavke_narudzbe_podaci=x;
    });
  }

  saljemoKupon:any={
    kuponID:0,
    korisnikID:  AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId
  }

  calculateTotalPrice(): number {
    let totalPrice = 0;
    let totalPriceWithoutDiscount = 0;
    let discounts = 0;
    const usedCategories = new Set<string>(); // Set to keep track of used categories
  
    if (this.stavke_narudzbe_podaci != null) {
      for (const x of this.stavke_narudzbe_podaci) {
        const itemPrice = x.proizvod.pocetnaCijena;
        totalPriceWithoutDiscount += itemPrice * x.kolicina;
  
        const category = x.proizvod.proizvodiKategorije.nazivKategorije;
        if (!usedCategories.has(category)) { // Check if category is not used
          const coupon: CouponEntry = this.kuponi_podaci.find((entry: CouponEntry) =>
            entry.kupon.kategorija === category ||
            entry.kupon.naziv.includes(x.proizvod.naziv)
          );
          
          if (coupon) {
            usedCategories.add(category); // Mark category as used
            const discount = coupon.kupon.popust / 100;
            discounts+=discount;
            this.initalNaurzdba.popust = discounts;
            const discountedPrice = itemPrice - itemPrice * discount;
            totalPrice += discountedPrice * x.kolicina;
            this.saljemoKupon.kuponID=coupon.kuponID;
          } else {
            totalPrice += itemPrice * x.kolicina;
          }
        } 
        else {
          totalPrice += itemPrice * x.kolicina; // Category already used, no discount
        }
      }
    }
    
    this.initalNaurzdba.ukupnaCijena = totalPrice;
    this.initalNaurzdba.ukupnaCijenaBezPopusta = totalPriceWithoutDiscount;
    return totalPrice;
  }
  
  DodajNarudzbu(){
    let uplata={
      uplataID:0,
      iznosZaUplatu:this.initalNaurzdba.ukupnaCijena,
    }

    this.httpKlijent.post(MojConfig.adresa_servera+ "/Uplata/Add/", uplata).subscribe((x:any)=>{
      this.initalNaurzdba.uplataID=x.uplataID;
      this.httpKlijent.post(MojConfig.adresa_servera + "/KuponiKorisnika/UpdateUsage/", this.saljemoKupon).subscribe(x=>{
      });
        this.httpKlijent.post(MojConfig.adresa_servera + "/Narudzba/Add/", this.initalNaurzdba).subscribe(x=>{
        this.alert_message= "Successful order creation."
        this.isAlert=true;
        setTimeout(() => {
          window.location.reload();
        }, 1000);
        });
    });

  }

  removeFromCart(x:any){
    this.httpKlijent.post(MojConfig.adresa_servera+"/StavkeNarudzbe/Delete/" + x.stavkeNarudzbeID, x.stavkeNarudzbeID).subscribe((x=>{
      this.getPodaciKorpe();
    }))   
  }

  getKuponi(){
    let token = MojConfig.http_opcije();
    return this.httpKlijent.get(MojConfig.adresa_servera + "/KuponiKorisnika/GetAllActive", token).subscribe(x=>{
      this.kuponi_podaci = x;
    });
  }

  get_slika(x: any) { //get slika za odabrani_proizvod
    return MojConfig.adresa_servera + "/Proizvod/GetSlika/" + x.id;
  }
}