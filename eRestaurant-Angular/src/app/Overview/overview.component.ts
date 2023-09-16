import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import { DatePipe } from '@angular/common'

@Component({
  selector: 'app-overview',
  templateUrl: './overview.component.html',
  styleUrls: ['./overview.component.css']
})
export class OverviewComponent implements OnInit{

  constructor(private httpKlijent: HttpClient, public datepipe:DatePipe) {
  }

  ngOnInit(): void {
    
  }

}