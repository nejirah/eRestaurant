import {Injectable} from "@angular/core";
import * as signalR from "@microsoft/signalr"
import {HttpClient} from "@angular/common/http";
import { MojConfig } from "../moj-config";

@Injectable({
  providedIn:"root"
})
export class SignalRProba1Servis{

  constructor(private httpKlijent: HttpClient) {
  }

  public poruka1 : any=null;
  public poruka2 : string = "Hello to you too :)";

  otvoriKanalWebSocket(){
      var connection = new signalR.HubConnectionBuilder()
        .withUrl('https://localhost:7129/poruke-hub-putanja')
        .build();

      connection.on('slanje_poruke1',(p:string)=>{
          this.poruka1 = p;
          let saljemo = {
            id:0,
            opis: this.poruka1
          };
          this.httpKlijent.post(MojConfig.adresa_servera + "/TestirajSignalR/Add/", saljemo).subscribe(x => {
          });
      });

      connection.start().then(()=>{
          console.log("Otvoren kanal WS.");
      });
  }

}