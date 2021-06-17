import { ApiService } from 'src/app/services/api.service';
import { Yazar } from './../../../models/Yazar';
import { Kategori } from './../../../models/Kategori';
import { Haber } from './../../../models/Haber';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { KategoriDialogComponent } from '../kategori-dialog/kategori-dialog.component';

@Component({
  selector: 'app-haber-dialog',
  templateUrl: './haber-dialog.component.html',
  styleUrls: ['./haber-dialog.component.scss']
})
export class HaberDialogComponent implements OnInit {
  dialogBaslik:string;
  islem:string;
  yeniKayit:Haber;
  frm: FormGroup;
  kategoriler:Kategori[];
  yazarlar:Yazar[];
  constructor(
    public dialogRef: MatDialogRef<HaberDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    public frmBuild: FormBuilder,
    public apiServis:ApiService
  ) {
    this.islem = data.islem;

    if (this.islem == 'ekle') {
      this.dialogBaslik = "Haber Ekle";
      this.yeniKayit = new Haber();
    }
    if (this.islem == 'duzenle') {
      this.dialogBaslik = "Haber Düzenle";
      this.yeniKayit = data.kayit;
    }
    this.frm = this.FormOlustur();
  }

  ngOnInit() {
    this.KategoriListele();
    this.YazarListele();
  }

  KategoriListele() {
    this.apiServis.KategoriListe().subscribe((d: Yazar[]) => {
      this.yazarlar = d;
    });
    
  }
  FormOlustur() {
    return this.frmBuild.group({
      HaberBaslik: [this.yeniKayit.haberBaslik],
      HaberOzet: [this.yeniKayit.haberOzet],
      Haberİçerik: [this.yeniKayit.haber],
      haberFoto: [this.yeniKayit.haberFoto],
      haberKategori: [this.yeniKayit.haberKategoriId],
      haberYazar: [this.yeniKayit.haberYazarId],
      
    });
  }
  YazarListele() {
    this.apiServis.YazarListe().subscribe((d: Kategori[]) => {
      this.kategoriler = d;
    });
}
}