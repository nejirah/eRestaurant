import { Component, OnInit } from '@angular/core';
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import { AutentifikacijaHelper } from '../helpers/autentifikacija-helper';

@Component({
    selector: 'app-twof',
    templateUrl: './twof.component.html',
    styleUrls: ['./twof.component.css']
  })

export class TwoFComponent implements OnInit {

  code: string="";
  constructor(private httpKlijent: HttpClient, private router: Router, ) { }

  ngOnInit(): void {
  }

  otkljucaj() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Authentication/Otkljucaj/" + this.code, MojConfig.http_opcije()).subscribe((x:any) =>{
      let saljemo={
        autentifikacijaToken:x,
        isLogiran:true
      }     
      console.log(saljemo);
      AutentifikacijaHelper.setLoginInfo(saljemo);
      this.router.navigateByUrl("/putanja-overview");
    });
  }
}