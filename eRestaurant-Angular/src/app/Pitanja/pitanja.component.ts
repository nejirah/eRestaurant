import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import { DatePipe, formatDate } from '@angular/common'
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AutentifikacijaHelper } from '../helpers/autentifikacija-helper';

@Component({
  selector: 'app-root',
  templateUrl: './pitanja.component.html',
  styleUrls: ['./pitanja.component.css']
})
export class PitanjaComponent implements OnInit{
  pitanja_podaci:any;
  odabrano_pitanje:any=null;
  vrsta_pitanja:string= "All";
  newPodaci:any;
  isAlert:boolean=false;
  alert_message:string="";
  filter_podaci:any="";
  myForm: FormGroup;
  isAlertError:boolean=false;
  alert_message_error:string="";
  trenutni_korisnik= AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId

  constructor(private httpKlijent: HttpClient, public datepipe:DatePipe, private fb:FormBuilder) {
    this.myForm = this.fb.group({
      question: ['', [Validators.required, Validators.pattern(/.{10,}/)]],
      // Other form controls
    });
  }

  ngOnInit(): void {
    this.preuzmipodatke();
  }

  preuzmipodatke(tipKategorije:any="All"){
    return this.httpKlijent.get(MojConfig.adresa_servera + "/Pitanje/GetAll").subscribe(x=>{
      this.pitanja_podaci = x;
      this.newPodaci= this.pitanja_podaci;  
    });
  }

  preuzmi_pitanja(tipKategorije: any) {
    this.vrsta_pitanja= tipKategorije;
    this.pitanja_podaci= this.newPodaci;

    if (this.vrsta_pitanja == 'All' && this.filter_podaci != '') {
        this.pitanja_podaci= this.pitanja_podaci.filter((p:any)=> p.opis.toLowerCase().includes(this.filter_podaci.toLowerCase()));
    } 
    
    else if (this.vrsta_pitanja == 'Answered' && this.filter_podaci == '') {
        this.pitanja_podaci = this.pitanja_podaci.filter((p: any) => p.status=='Answered');
    } 
    
    else if (this.vrsta_pitanja == 'Answered' && this.filter_podaci != '') {
      this.pitanja_podaci = this.pitanja_podaci.filter((p: any) => p.status=='Answered' && p.opis.toLowerCase().includes(this.filter_podaci.toLowerCase()));
    } 
      
    else if (this.vrsta_pitanja == 'Unanswered' && this.filter_podaci == '') {
      this.pitanja_podaci = this.pitanja_podaci.filter((p: any) => p.status=='Unanswered');
    } 
    
    else if (this.vrsta_pitanja == 'Unanswered' && this.filter_podaci != '') {
      this.pitanja_podaci = this.pitanja_podaci.filter((p: any) => p.status=='Unanswered' && p.opis.toLowerCase().includes(this.filter_podaci.toLowerCase()));
    }
    else {
      this.pitanja_podaci= this.newPodaci;
    }
  }

  Delete(pitanje: any){
    this.httpKlijent.post(MojConfig.adresa_servera+"/Pitanje/Delete/" + pitanje.pitanjeID ,pitanje.pitanjeID).subscribe((x=>{
      this.alert_message= "Question successfully deleted."
      this.isAlert=true;
    
    setTimeout(() => {
      window.location.reload();
    }, 1000);
    }))
  }

  Add() {
    this.odabrano_pitanje.korisnikID=this.trenutni_korisnik;
    if (this.myForm.valid) {
      this.httpKlijent.post(MojConfig.adresa_servera + "/Pitanje/Add/", this.odabrano_pitanje).subscribe(x => {
        this.alert_message = "Question successfully added."
        this.isAlert = true;
        
        setTimeout(() => {
          window.location.reload();
        }, 1000);
      });
    } else {
      this.alert_message_error = "Please fill in all required fields correctly.";
      this.isAlertError = true;
      setTimeout(() => {
        this.isAlertError = false;
      }, 3000);
    }
  }
  

  formatdate(datum: any) {
    const format = "dd/MM/yyyy";
    const locale = "en-US";
    return formatDate(datum, format, locale);
  }

  Dodaj(){
    this.odabrano_pitanje = {
      pitanjeID:0,
      korisnikID:1,
    }
  }
}
