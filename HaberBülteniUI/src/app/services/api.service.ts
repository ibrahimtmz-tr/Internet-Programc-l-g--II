import { Yazar } from './../models/Yazar';
import { Yorum } from './../models/Yorum';
import { Uye } from './../models/Uye';
import { Haber } from './../models/Haber';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Kategori } from '../models/Kategori';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  apiUrl = "https://localhost:44376/api/";
  constructor(
    public http: HttpClient
  ) { }

  /*Auth Başlangıç */
  tokenAl(kadi: string, parola: string) {
    var data = "username=" + kadi + "&password=" + parola + "&grant_type=password";
    var reqHeader = new HttpHeaders({ "Content-Type": "application/x-www-form-urlencoded" });
    return this.http.post(this.apiUrl + "token", data, { headers: reqHeader });
  }

  oturumKontrol() {
    if (localStorage.getItem("token")) {
      return true;
    }
    else{
      return false;
    }
  }
  yetkiKontrol(yetkiler) {
    var uyeYetkileri: string[] = JSON.parse(localStorage.getItem("uyeYetki"));
    var sonuc: boolean = false;
    if (uyeYetkileri) {
      yetkiler.forEach(element => {
        if (uyeYetkileri.indexOf(element) > -1) {
          sonuc = true;
          return false;
        }
      });

    }

    return sonuc;
  }


  /*Auth Bitiş */

/* Api Başlangıç */
KategoriListe(){
  return this.http.get(this.apiUrl+"kategoriliste")
}
KategoriById(katId:number){
  return this.http.get(this.apiUrl+"kategoribyid/"+katId);
}
KategoriEkle(kat:Kategori){
  return this.http.post(this.apiUrl+"/kategoriekle", kat);
}
KategoriDuzenle(kat:Kategori){
  return this.http.put(this.apiUrl+"/kategoriduzenle", kat);
}
KategoriSil(katId:number){
  return this.http.delete(this.apiUrl+"kategorisil/"+ katId);
}
HaberListe(){
  return this.http.get(this.apiUrl+"haberliste")
}
HaberListeByKatId(katId:number){
  return  this.http.get(this.apiUrl+"/haberbykatid/"+katId)
}
HaberListeByYazarId(yazarId:number){
  return this.http.get(this.apiUrl+"/haberbyyazarid/"+yazarId)
}
HaberListeById(haberId:number){
  return this.http.get(this.apiUrl+"/haberbyid/"+haberId)
}
HaberListeSonDakika(s:number){
  return this.http.get(this.apiUrl+"/haberlistesondakika/"+s)
}
HaberEkle(haber:Haber){
  return this.http.post(this.apiUrl+"/haberekle", haber)
}
HaberDuzenle(haber:Haber){
  return this.http.put(this.apiUrl+"/haberduzenle", haber);
}
HaberSil(haberId:number){
  return this.http.delete(this.apiUrl+"/habersil"+ haberId);
}
UyeListe(){
  return this.http.get(this.apiUrl+"/uyeliste")
}
UyeById(uyeId:number){
  return  this.http.get(this.apiUrl+"uyebyid/"+uyeId);
}
UyeEkle(uye:Uye){
  return this.http.post(this.apiUrl+"/uyeekle", uye)
}
UyeDuzenle(uye:Uye){
  return this.http.put(this.apiUrl+"/uyeduzenle", uye);
}
UyeSil(uyeId:number){
  return this.http.delete(this.apiUrl+"/uyesil"+ uyeId);
}
YorumListe(){
  return this.http.get(this.apiUrl+"/yorumliste")
}
YorumListeByHaberId(haberId:number){
  return  this.http.get(this.apiUrl+"/yorumbyhaberid/"+haberId)
}
YorumEkle(yorum:Yorum){
  return this.http.post(this.apiUrl+"/yorumekle", yorum)
}
YorumDuzenle(yorumId:number){
  return this.http.put(this.apiUrl+"/yorumduzenle", yorumId);
}
YorumSil(yorumId:number){
  return this.http.delete(this.apiUrl+"/yorumsil"+ yorumId);
}
YazarListe(){
  return this.http.get(this.apiUrl+"/yazarliste")
}
YazarById(yazarId:number){
  return this.http.get(this.apiUrl+"/yazarbyid/"+yazarId)
}
YazarEkle(yazar:Yazar){
  return this.http.post(this.apiUrl+"/yazarekle", Yazar)
}
YazarDuzenle(yazar:Yazar){
  return this.http.put(this.apiUrl+"/yazarduzenle", yazar);
}
YazarSil(yazarId:number){
  return this.http.delete(this.apiUrl+"/yazarsil"+ yazarId);
}
}
