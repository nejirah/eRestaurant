import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import { DatePipe, formatDate } from '@angular/common'
import {FormatWidth, getLocaleDateTimeFormat} from "@angular/common";

@Component({
  selector: 'app-root',
  templateUrl: './uplate.component.html',
  styleUrls: ['./uplate.component.css']
})

export class UplateComponent implements OnInit {
  uplate_podaci:any;
  newPodaci:any;

  constructor(private httpKlijent: HttpClient, public datepipe: DatePipe) {
  }

  vrsta_uplate:string= "All";
  filter_podaci:any="";

  ngOnInit(): void {
    this.preuzmi_podatke();
  }

  preuzmi_podatke(tipKategorije:any="All")
  {
    let token = MojConfig.http_opcije();
    return this.httpKlijent.get(MojConfig.adresa_servera + "/Uplata/GetAll", token).subscribe(x=>{
      this.uplate_podaci = x;
      this.newPodaci= this.uplate_podaci;
      console.log(this.uplate_podaci);
    });
  }

  formatdate(datum: any) {
    const format = "dd/MM/yyyy";
    const locale = "en-US";
    return formatDate(datum, format, locale);
  }

  preuzmi_uplate(tipKategorije:any){
    this.vrsta_uplate= tipKategorije;
    this.uplate_podaci= this.newPodaci;

    if (this.vrsta_uplate == 'All' && this.filter_podaci != '') {
        this.uplate_podaci= this.uplate_podaci.filter((u:any)=> u.uplata.iznosZaUplatu.toString().includes(this.filter_podaci));
    } 
    
    else if (this.vrsta_uplate == 'Cash' && this.filter_podaci == '') {
      this.uplate_podaci = this.uplate_podaci.filter((u: any) => u.uplata.nacinPlacanja==='Cash');
    } 
    
    else if (this.vrsta_uplate == 'Cash' && this.filter_podaci != '') {
      this.uplate_podaci = this.uplate_podaci.filter((u: any) => u.uplata.nacinPlacanja=='Cash' && u.uplata.iznosZaUplatu.toString().includes(this.filter_podaci));
    } 
      
    else if (this.vrsta_uplate == 'Credit card' && this.filter_podaci == '') {
      this.uplate_podaci = this.uplate_podaci.filter((u: any) => u.uplata.nacinPlacanja=='Credit card');
    } 
    
    else if (this.vrsta_uplate == 'Credit card' && this.filter_podaci != '') {
      this.uplate_podaci = this.uplate_podaci.filter((u: any) => u.uplata.nacinPlacanja=='Credit card' && u.uplata.iznosZaUplatu.toString().includes(this.filter_podaci));
    }
    else {
      this.uplate_podaci= this.newPodaci;
    }
  }
  
}
