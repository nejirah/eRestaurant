import { HttpClient } from "@angular/common/http";
import { Component, EventEmitter, Output, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { MojConfig } from "../moj-config";
import { LoginInformacije } from "../helpers/login-informacije";
import { AutentifikacijaHelper } from "../helpers/autentifikacija-helper";
import { FormBuilder, FormGroup, NgForm, Validators } from "@angular/forms";

@Component({
    selector: 'app-registracija',
    templateUrl: './registracija.component.html',
    styleUrls: ['./registracija.component.css']
  })
  
  export class RegistracijaComponent {  
    firstName:any;
    lastName:any;
    username:any;
    email:any;
    password:any;
    phone:any;
    alert_message: any;
    isAlert: any;
    myForm: FormGroup;
    isAlertError:boolean=false;
    alert_message_error:string="";

    constructor(private httpKlijent: HttpClient, private router: Router, private fb:FormBuilder) {
        this.myForm = this.fb.group({
          firstname: ['', [Validators.required, Validators.pattern(/^[A-Z][A-Za-z]{2,}( [A-Z][A-Za-z]{2,})?$/)]],
          lastname: ['', [Validators.required, Validators.pattern(/^[A-Z][A-Za-z]{2,}$/)]],
          email: ['', [Validators.required, Validators.pattern(/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/)]],
          username: ['', [Validators.required, Validators.pattern(/^(?=.*[a-zA-Z])[a-zA-Z0-9._-]{3,}$/)]],
          phone: ['', [Validators.required, Validators.pattern(/^\+387\d{2}\d{3}\d{3,4}$/)]],
          password: ['', [Validators.required, Validators.pattern(/.{6,}/)]],
          // Other form controls
        });
    }

    btnRegistration() {
      let saljemo = {
        username: this.username,
        password: this.password,
        ime: this.firstName,
        prezime: this.lastName,
        brojTelefona: this.phone,
        email: this.email,
      };
    
      let loginsaljemo = {
        username: this.username,
        password: this.password,
      };
    
      this.httpKlijent.post(MojConfig.adresa_servera + "/Korisnik/Add/", saljemo).subscribe(
        (response) => {
          if (response) {
            // Check if the response contains an error message
            if (response.hasOwnProperty('error')) {
              this.alert_message = "Server is not responding"; // Use the error message sent from the server
              this.isAlert = true;
            } else {
              // Handle success message and navigation
              this.httpKlijent.post<LoginInformacije>(MojConfig.adresa_servera+ "/Authentication/Login", loginsaljemo)
        .subscribe((x:LoginInformacije) =>{
          if (x.isLogiran) {
            AutentifikacijaHelper.setLoginInfo(x) 
            this.alert_message= "Uspješno kreiranje korisničkog računa";
            this.isAlert=true;
            setTimeout(() => {
              this.router.navigateByUrl("/putanja-overview");
            }, 1000);
        }
        else
        {
          this.alert_message= "Nope";
          this.isAlert=true;
          const failedLoginInfo: LoginInformacije = {
            autentifikacijaToken: {
              id: 0,
              vrijednost: "",
              korisnickiNalogId: 0,
              korisnickiNalog: { OsobaId: 0, Email: "", Username: "" },
              vrijemeEvidentiranja: new Date(),
              IPAdresa: "",
              twoFCode:"",
              twoFJelOtkljucano:false,
            },
            isLogiran: false
          };
          AutentifikacijaHelper.setLoginInfo(failedLoginInfo);
        }
      });       
            }
          }
        },
        (error) => {
          // Handle error cases
          this.alert_message_error = "There is already user with that username"; // Display a general error message
          this.isAlertError = true;
        }
      );
    }
    

    login(){
      this.sendprop.emit();
    }
  
    @Output() sendprop = new EventEmitter();
}