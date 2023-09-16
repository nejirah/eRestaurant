export class LoginInformacije {
    autentifikacijaToken: AutentifikacijaToken = {
      id: 0,
      vrijednost: "",
      korisnickiNalogId: 0,
      korisnickiNalog: { OsobaId: 0, Email: "", Username: "" },
      vrijemeEvidentiranja: new Date(),
      IPAdresa: "",
      twoFCode:"",
      twoFJelOtkljucano:false,
    };
    isLogiran: boolean = false;
  }
  
  export interface AutentifikacijaToken {
    id: number;
    vrijednost: string;
    korisnickiNalogId: number;
    korisnickiNalog: { OsobaId: number; Email: string; Username: string };
    vrijemeEvidentiranja: Date;
    IPAdresa: string;
    twoFCode:string;
    twoFJelOtkljucano:boolean;
  }
  
  export interface KorisnickiNalog {
    OsobaId:number;
    Email:string;
    Username:string;
  }

  export class Registracija{
    isRegistracija:boolean=false;
  }