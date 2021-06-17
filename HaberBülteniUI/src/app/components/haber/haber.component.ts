import { Haber } from 'src/app/models/Haber';
import { ApiService } from 'src/app/services/api.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-haber',
  templateUrl: './haber.component.html',
  styleUrls: ['./haber.component.scss']
})
export class HaberComponent implements OnInit {
haberId:number;
haber:Haber;
  constructor(
    public apiServis:ApiService,
    public route:ActivatedRoute,
  ) { }

  ngOnInit() {
    this.route.params.subscribe(p=>{
if(p.haberId){
  this.haberId=p.haberId;
  this.HaberById();
}
    })
  }
HaberById(){
  this.apiServis.HaberListeById(this.haberId).subscribe((d:Haber)=> {
    this.haber=d;
  });
}
}
