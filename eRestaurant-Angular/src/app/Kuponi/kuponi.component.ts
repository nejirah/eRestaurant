import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {formatDate} from "@angular/common";
import {DatePipe} from "@angular/common";
import { MojConfig } from '../moj-config';

@Component({
  selector: 'app-root',
  templateUrl: './kuponi.component.html',
  styleUrls: ['./kuponi.component.css'],
  providers:[DatePipe]
})
export class KuponiComponent implements OnInit {
  
  constructor(private httpKlijent: HttpClient, private datePipe: DatePipe) {
   
  }

  ngOnInit(): void {
    this.preuzmi_podatke();
  }

  vrsta_kupona:string= "All";
  kuponi_podaci:any;
  newPodaci:any;
  danasnji_datum:any;
  filter_podaci: any="";
  alert_message:string="";
  isAlert:boolean=false;

  preuzmi_podatke(tipKategorije:any="All")
  {
    let token = MojConfig.http_opcije();
    return this.httpKlijent.get(MojConfig.adresa_servera + "/KuponiKorisnika/GetAll", token).subscribe(x=>{
      this.kuponi_podaci = x;
      this.newPodaci= this.kuponi_podaci;
    });
  }

  formatdate(datum: any) {
    const format = "dd/MM/yyyy";
    const locale = "en-US";
    return formatDate(datum, format, locale);
  }

  isDeactivationDatePast(datumDeaktivacije: Date): boolean {
    this.danasnji_datum=this.formatDateToISO(new Date());
    let changedDate= this.formatDateToISO(datumDeaktivacije);
    return new Date(changedDate)> new Date(this.danasnji_datum);
  }

  formatDateToISO(date: Date | null): string {
    if (date) {
      return this.datePipe.transform(date, 'yyyy-MM-ddTHH:mm:ss.SSSSSSS') || '';
    } else {
      return '';
    }
  }

  Update(x:any){
    let saljemo={
      kuponiKorisnikaID:x.kuponiKorisnikaID,
      kuponID:x.kuponID,
      korisnikID:x.korisnikID
    }
    this.httpKlijent.post(MojConfig.adresa_servera + "/KuponiKorisnika/Update/", saljemo).subscribe(x=>{
      this.alert_message= "Coupon activated"
      this.isAlert=true;

      setTimeout(() => {
        window.location.reload();
      }, 1000);
    });
  }

  preuzmi_kupone(tipKategorije:any){
    this.vrsta_kupona= tipKategorije;
    this.kuponi_podaci= this.newPodaci;

    if (this.vrsta_kupona == 'All' && this.filter_podaci != '') {
        this.kuponi_podaci= this.kuponi_podaci.filter((k:any)=> k.kupon.naziv.includes(this.filter_podaci));
    } 
    
    else if (this.vrsta_kupona == 'Active' && this.filter_podaci == '') {
        this.kuponi_podaci = this.kuponi_podaci.filter((k: any) => this.isDeactivationDatePast(k.kupon.datumDeaktivacije));
    } 
    
    else if (this.vrsta_kupona == 'Active' && this.filter_podaci != '') {
      this.kuponi_podaci = this.kuponi_podaci.filter((k: any) => this.isDeactivationDatePast(k.kupon.datumDeaktivacije) && k.kupon.naziv.includes(this.filter_podaci));
    } 
      
    else if (this.vrsta_kupona == 'Expired' && this.filter_podaci == '') {
      this.kuponi_podaci = this.kuponi_podaci.filter((k: any) => !this.isDeactivationDatePast(k.kupon.datumDeaktivacije));
    } 
    
    else if (this.vrsta_kupona == 'Expired' && this.filter_podaci != '') {
      this.kuponi_podaci = this.kuponi_podaci.filter((k: any) => !this.isDeactivationDatePast(k.kupon.datumDeaktivacije) && k.kupon.naziv.includes(this.filter_podaci));
    }
    else {
      this.kuponi_podaci= this.newPodaci;
    }
  }
  
}
