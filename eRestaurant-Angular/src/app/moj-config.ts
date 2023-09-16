import { AutentifikacijaHelper } from "./helpers/autentifikacija-helper";
import { AutentifikacijaToken } from "./helpers/login-informacije";

export  class MojConfig{
  static adresa_servera="https://localhost:7129";
  static http_opcije= function (){

    let autentifikacijaToken:AutentifikacijaToken = AutentifikacijaHelper.getLoginInfo().autentifikacijaToken;
    let mojtoken = "";

    if (autentifikacijaToken!=null)
      mojtoken = autentifikacijaToken.vrijednost;
    return {
        headers: {
        'autentifikacija-token': mojtoken,
      }
    };
}
}
