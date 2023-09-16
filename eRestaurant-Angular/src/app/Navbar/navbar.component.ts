import { Component } from "@angular/core";
import { MojConfig } from "../moj-config";
import { LoginInformacije } from "../helpers/login-informacije";
import { AutentifikacijaHelper } from "../helpers/autentifikacija-helper";
import { Router } from "@angular/router";
import {HttpClient} from "@angular/common/http";
import { SignalRProba1Servis } from "../_servisi/signal-r-proba1-servis.service";


@Component({
    selector: 'app-navbar',
    templateUrl: './navbar.component.html',
    styleUrls: ['./navbar.component.css']
  })
  
  export class NavbarComponent {

    notifikacija_podaci:any;
    prikaziNotifikacija:boolean=false;

    constructor(private httpKlijent: HttpClient,private router: Router, public  probaServis: SignalRProba1Servis) {
      probaServis.otvoriKanalWebSocket();
    }

    ngOnInit(): void {
      this.get_notifikacije();
    }

    logoutButton() {
      let token = MojConfig.http_opcije();
      const logoutinfo: LoginInformacije = {
        autentifikacijaToken: {
          id: 0,
          vrijednost: "",
          korisnickiNalogId: 0,
          korisnickiNalog: { OsobaId: 0, Email: "", Username: "" },
          vrijemeEvidentiranja: new Date(),
          IPAdresa: "",
          twoFCode: "",
          twoFJelOtkljucano:false,
        },
        isLogiran: false
      };
      AutentifikacijaHelper.setLoginInfo(logoutinfo);
  
      this.httpKlijent.post(MojConfig.adresa_servera + "/Authentication/Logout/", null, token)
        .subscribe((x: any) => {
        });
  
      this.router.navigateByUrl("/");
    }

    get_notifikacije(){
      return this.httpKlijent.get(MojConfig.adresa_servera + "/TestirajSignalR/GetAll").subscribe(x=>{
        this.notifikacija_podaci = x;
      });
    }
  
    prikazi_notifikacije(){
      this.get_notifikacije();
      if(this.prikaziNotifikacija==false){
        this.prikaziNotifikacija=true;
      }
      else{
        this.prikaziNotifikacija=false;
        this.probaServis.poruka1=null;
      }
    }
  }