import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import {RouterModule} from "@angular/router";
import {RezervacijeComponent} from "./Rezervacije/rezervacije.component";
import {ProizvodiComponent} from "./Proizvodi/proizvodi.component";
import {HttpClientModule} from "@angular/common/http";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import { DatePipe } from '@angular/common';
import {PitanjaComponent} from "./Pitanja/pitanja.component";
import {UplateComponent} from "./Uplate/uplate.component";
import {KuponiComponent} from "./Kuponi/kuponi.component";
import { NarudzbaComponent } from './Narudzbe/narudzba.components';
import { OverviewComponent } from './Overview/overview.component';
import { MarketingComponent } from './Marketing/marketing.component';
import { LoginComponent } from './Login/login.component';
import { NavbarComponent } from './Navbar/navbar.component';
import { RegistracijaComponent } from './Registracija/registracija.component';
import { TwoFComponent } from './twof/twof.component';

@NgModule({
  declarations: [
    AppComponent,
    RezervacijeComponent,
    ProizvodiComponent,
    PitanjaComponent,
    UplateComponent,
    KuponiComponent,
    NarudzbaComponent,
    OverviewComponent,
    MarketingComponent,
    LoginComponent,
    NavbarComponent,
    RegistracijaComponent,
    TwoFComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'putanja-rezervacije', component: RezervacijeComponent},
      {path: 'putanja-proizvodi', component: ProizvodiComponent},
      {path:'putanja-pitanja', component: PitanjaComponent},
      {path:'putanja-uplate', component: UplateComponent},
      {path:'putanja-kuponi', component: KuponiComponent},
      {path:'putanja-narudzbe', component: NarudzbaComponent},
      {path:'putanja-overview', component: OverviewComponent},
      {path:'login', component:LoginComponent},
      {path: 'putanja-registracija', component: RegistracijaComponent},
      {path: 'putanja-twof', component: TwoFComponent}
      //dodati ovdje komponentu
    ]),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
