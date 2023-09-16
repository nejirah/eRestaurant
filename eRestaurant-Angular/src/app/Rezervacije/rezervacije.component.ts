import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import { DatePipe, formatDate } from '@angular/common'
import { AutentifikacijaHelper } from '../helpers/autentifikacija-helper';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './rezervacije.component.html',
  styleUrls: ['./rezervacije.component.css']
})
export class RezervacijeComponent implements OnInit{
  rezervacije_podaci:any;
  odabrana_rezervacija: any= null;
  danasnji_datum:any;
  vrsta_rezervacija:string= "All";
  filter_podaci: any="";
  newPodaci:any;
  isAlert:boolean=false;
  alert_message:string="";
  myForm: FormGroup;
  isAlertError:boolean=false;
  alert_message_error:string="";

  constructor(private httpKlijent: HttpClient, private datePipe: DatePipe, private fb:FormBuilder) {
    this.myForm = this.fb.group({
      tablenumber: ['', [Validators.required, Validators.pattern(/^[1-9]$/)]],
      personnumber: ['', [Validators.required, Validators.pattern(/^[1-6]$/)]],
      date: ['', [Validators.required, this.futureDateValidator]],
      napomena: ['']
      // Other form controls
    });
  }

  preuzmi_podatke(tipKategorije:any="All")
  {
    let token = MojConfig.http_opcije();
    return this.httpKlijent.get(MojConfig.adresa_servera + "/Rezervacija/GetAll", token).subscribe(x=>{
      this.rezervacije_podaci = x;
      this.newPodaci= this.rezervacije_podaci;
    });
  }

  preuzmi_rezervaacije(tipKategorije:any){
    this.vrsta_rezervacija= tipKategorije;
    this.rezervacije_podaci= this.newPodaci;

    if (this.vrsta_rezervacija == 'All' && this.filter_podaci != '') {
        this.rezervacije_podaci= this.rezervacije_podaci.filter((r:any)=> r.rezervacijaID.toString().includes(this.filter_podaci));
    } 
    
    else if (this.vrsta_rezervacija == 'Pending' && this.filter_podaci == '') {
        this.rezervacije_podaci = this.rezervacije_podaci.filter((o: any) => o.status=='New' || o.status=='Updated');
    } 
    
    else if (this.vrsta_rezervacija == 'Pending' && this.filter_podaci != '') {
      this.rezervacije_podaci = this.rezervacije_podaci.filter((o: any) => (o.status=='New' || o.status=='Updated') && o.rezervacijaID.toString().includes(this.filter_podaci));
    } 
      
    else if (this.vrsta_rezervacija == 'Concluded' && this.filter_podaci == '') {
      this.rezervacije_podaci = this.rezervacije_podaci.filter((o: any) => o.status=='Concluded');
    } 
    
    else if (this.vrsta_rezervacija == 'Concluded' && this.filter_podaci != '') {
      this.rezervacije_podaci = this.rezervacije_podaci.filter((o: any) => o.status=='Concluded' && o.rezervacijaID.toString().includes(this.filter_podaci));
    }
    else {
      this.rezervacije_podaci= this.newPodaci;
    }
  }

  ngOnInit(): void {
    this.preuzmi_podatke();
  }

  Dodaj(){
    this.odabrana_rezervacija = {
      rezervacijaID:0,
      korisnikID: AutentifikacijaHelper.getLoginInfo().autentifikacijaToken.korisnickiNalogId,
      napomena:"",
      status:"New",
    }
  }

  Add() {
    if (this.myForm.valid) {
      this.httpKlijent.post(MojConfig.adresa_servera + "/Rezervacija/Add/", this.odabrana_rezervacija).subscribe(x => {
        this.alert_message = "Reservation successfully added."
        this.isAlert = true;
        
        setTimeout(() => {
          window.location.reload();
        }, 1000);
      });
    } else {
      this.alert_message_error = "Please fill in all required fields correctly.";
      this.isAlertError = true;
      setTimeout(() => {
        this.isAlertError=false;
      }, 3000);
    }
  }

  Delete(rezervacija: any){
    this.httpKlijent.post(MojConfig.adresa_servera+"/Rezervacija/Delete/" + rezervacija.rezervacijaID,rezervacija.rezervacijaID).subscribe((x=>{
      this.alert_message= "Reservation successfully deleted."
      this.isAlert=true;

      setTimeout(() => {
        window.location.reload();
      }, 1000);
    }))  
  }

  formatdate(datum: any) {
    const format = "dd/MM/yyyy";
    const locale = "en-US";
    return formatDate(datum, format, locale);
  }

  private futureDateValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const selectedDate = new Date(control.value);
    const currentDate = new Date();

    if (selectedDate < currentDate) {
      return { invalidDate: true };
    }

    return null;
  }

  isDatePast(datum: Date): boolean {
    this.danasnji_datum=this.formatDateToISO(new Date());
    let changedDate= this.formatDateToISO(datum);
    return new Date(changedDate)> new Date(this.danasnji_datum);
  }

  formatDateToISO(date: Date | null): string {
    if (date) {
      return this.datePipe.transform(date, 'yyyy-MM-ddTHH:mm:ss.SSSSSSS') || '';
    } else {
      return '';
    }
  }

}
