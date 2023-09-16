import {Component, EventEmitter, Output} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import { LoginInformacije } from '../helpers/login-informacije';
import { MojConfig } from '../moj-config';
import { AutentifikacijaHelper } from '../helpers/autentifikacija-helper';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent {

  txtLozinka: any;
  txtKorisnickoIme: any;
  isRegistracija:boolean=false;
  isAlertError:boolean=false;
  alert_message_error:string="";

  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  ngOnInit(): void {
  }

  btnLogin() {
    let saljemo = {
      username:this.txtKorisnickoIme,
      password: this.txtLozinka
    };
    this.httpKlijent.post<LoginInformacije>(MojConfig.adresa_servera+ "/Authentication/Login", saljemo)
      .subscribe((x:LoginInformacije) =>{
        if (x.isLogiran) {
          AutentifikacijaHelper.setLoginInfo(x);
          setTimeout(() => {
            this.router.navigateByUrl("/putanja-twof");
          }, 3000);
        }
        else
        {
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
          this.alert_message_error= "Username or password is not correct";
          this.isAlertError=true;
        }
      });
  }

  registracija(){
    this.sendprop.emit();
  }

  @Output() sendprop = new EventEmitter();
}