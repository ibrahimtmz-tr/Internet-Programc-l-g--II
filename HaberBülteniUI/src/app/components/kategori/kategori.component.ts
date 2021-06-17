import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Haber } from 'src/app/models/Haber';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-kategori',
  templateUrl: './kategori.component.html',
  styleUrls: ['./kategori.component.scss']
})
export class KategoriComponent implements OnInit {
  kategoriId:number;
  haberler:Haber[];
    constructor(
      public apiServis:ApiService,
      public route:ActivatedRoute,
    ) { }
  ngOnInit() {
    this.route.params.subscribe(p=>{
      if(p.kategoriId){
        this.kategoriId=p.kategoriId;
        this.HaberByKatId();
      }
          })
  }
  
  HaberByKatId(){
    this.apiServis.HaberListeByKatId(this.kategoriId).subscribe((d:Haber[])=>{
      this.haberler=d;
    });
  }
}
