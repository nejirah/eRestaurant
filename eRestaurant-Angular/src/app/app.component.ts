import { Component } from '@angular/core';
import { LoginInformacije } from './helpers/login-informacije';
import { AutentifikacijaHelper } from './helpers/autentifikacija-helper';
import {Router} from "@angular/router";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'eRestaurant-Angular';
  isRegistracija:any=false;

  constructor(private httpKlijent: HttpClient,private router: Router) {
  }

  loginInfo():LoginInformacije {
    return AutentifikacijaHelper.getLoginInfo();
  }

  recprop(){
    this.isRegistracija=true;
  }

  recpropreg(){
    this.isRegistracija=false;
  }
  
}
