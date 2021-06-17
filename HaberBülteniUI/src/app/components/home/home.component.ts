import { ApiService } from 'src/app/services/api.service';
import { Component, OnInit } from '@angular/core';
import { Haber } from 'src/app/models/Haber';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
haberler:Haber[];
  constructor(
    public apiServis:ApiService
  ) { }

  ngOnInit() {
this.HaberListele();
  }
HaberListele(){
this.apiServis.HaberListe().subscribe((d:Haber[])=>{
this.haberler=d;
})
}

}
