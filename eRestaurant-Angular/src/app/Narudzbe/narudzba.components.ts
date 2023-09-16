import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { MojConfig } from '../moj-config';
import { formatDate } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './narudzba.component.html',
  styleUrls: ['./narudzba.component.css']
})

export class NarudzbaComponent implements OnInit{

  vrsta_narudzbe:string= "All";
  filter_podaci:any="";
  narudzba_podaci:any;
  newPodaci:any;
  odabrana_narudzba:any;
  stavke_narudzbe:any;

  constructor(private httpKlijent: HttpClient) {
  }
  
  ngOnInit(): void {
    this.preuzmi_podatke();
  }
  
  preuzmi_podatke(tipKategorije:any="All"){
    let token = MojConfig.http_opcije();
    return this.httpKlijent.get(MojConfig.adresa_servera + "/Narudzba/GetAll",token).subscribe(x=>{
      this.narudzba_podaci = x;
      this.newPodaci= this.narudzba_podaci;
    });
  }

  preuzmi_narudzbe(tipKategorije:any){
    this.vrsta_narudzbe= tipKategorije;
    this.narudzba_podaci= this.newPodaci;

    if (this.vrsta_narudzbe == 'All' && this.filter_podaci != '') {
        this.narudzba_podaci= this.narudzba_podaci.filter((r:any)=> r.narudzbaID.toString().includes(this.filter_podaci));
    } 
    
    else if (this.vrsta_narudzbe == 'Pending' && this.filter_podaci == '') {
        this.narudzba_podaci = this.narudzba_podaci.filter((o: any) => o.statusNarudzbe=='New' || o.statusNarudzbe=='Updated');
    } 
    
    else if (this.vrsta_narudzbe == 'Pending' && this.filter_podaci != '') {
      this.narudzba_podaci = this.narudzba_podaci.filter((o: any) => (o.statusNarudzbe=='New' || o.statusNarudzbe=='Updated') && o.narudzbaID.toString().includes(this.filter_podaci));
    } 
      
    else if (this.vrsta_narudzbe == 'Concluded' && this.filter_podaci == '') {
      this.narudzba_podaci = this.narudzba_podaci.filter((o: any) => o.statusNarudzbe=='Concluded');
    } 
    
    else if (this.vrsta_narudzbe == 'Concluded' && this.filter_podaci != '') {
      this.narudzba_podaci = this.narudzba_podaci.filter((o: any) => o.statusNarudzbe=='Concluded' && o.narudzbaID.toString().includes(this.filter_podaci));
    }
    else {
      this.narudzba_podaci= this.newPodaci;
    }
  }

  formatdate(datum: any) {
    const format = "dd/MM/yyyy";
    const locale = "en-US";
    return formatDate(datum, format, locale);
  }

  odaberi_narudzbu(x:any){
    this.httpKlijent.get(MojConfig.adresa_servera + "/StavkeNarudzbe/GetById/" + x.narudzbaID, x.narudzbaID).subscribe((p: any) => {
      this.stavke_narudzbe=p;
      this.odabrana_narudzba=x;
    });
  }

}