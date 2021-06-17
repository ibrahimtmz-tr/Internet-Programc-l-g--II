import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialogRef, MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Haber } from 'src/app/models/Haber';
import { Kategori } from 'src/app/models/Kategori';
import { Sonuc } from 'src/app/models/Sonuc';
import { Yazar } from 'src/app/models/Yazar';
import { ApiService } from 'src/app/services/api.service';
import { MyAlertService } from 'src/app/services/myAlert.service';
import { ConfirmDialogComponent } from '../dialogs/confirm-dialog/confirm-dialog.component';
import { HaberDialogComponent } from '../dialogs/haber-dialog/haber-dialog.component';
import { KategoriDialogComponent } from '../dialogs/kategori-dialog/kategori-dialog.component';

@Component({
  selector: 'app-admin-haber',
  templateUrl: './admin-haber.component.html',
  styleUrls: ['./admin-haber.component.scss']
})
export class AdminHaberComponent implements OnInit {
  kategoriler: Kategori[];
  haberler: Haber[];
  yazarlar: Yazar[];
  dataSource: any;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatSort;
  displayedColumns = ['haberBaslik','detay'];
  dialogRef: MatDialogRef<HaberDialogComponent>;
  dialogRefConfirm: MatDialogRef<ConfirmDialogComponent>;
  constructor(
    public apiServis: ApiService,
    public alert: MyAlertService,
    public matDialog: MatDialog
  ) { }

  ngOnInit() {
    this.HaberListele();
  }

  HaberListele() {
    this.apiServis.HaberListe().subscribe((d: Haber[]) => {
      this.haberler = d;
      this.dataSource = new MatTableDataSource(this.haberler);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }
  Ekle() {
    var yeniKayit: Haber = new Haber();
    this.dialogRef = this.matDialog.open(HaberDialogComponent, {
      width: '400px',
      data: {
        kayit: yeniKayit,
        islem: 'ekle'
      }
    });
    this.dialogRef.afterClosed().subscribe(d => {
      if (d) {
        this.apiServis.KategoriEkle(d).subscribe((s: Sonuc) => {
          this.alert.AlertUygula(s);
          if (s.islem) {
            this.HaberListele();
          }
        });
      }
    });
  }



  Sil(kayit: Haber) {
    this.dialogRefConfirm = this.matDialog.open(ConfirmDialogComponent, {
      width: '400px'
    });
    this.dialogRefConfirm.componentInstance.dialogMesaj = kayit.haberBaslik + " Haber Silinicektir onaylıyor musunuz?";

    this.dialogRefConfirm.afterClosed().subscribe(d => {
      if (d) {

        this.apiServis.KategoriSil(kayit.haberId).subscribe((s: Sonuc) => {
          this.alert.AlertUygula(s);
          if (s.islem) {
            this.HaberListele();
          }
        });
      }
    });

  }
  KategoriListele() {
    this.apiServis.KategoriListe().subscribe((d: Kategori[]) => {
      this.kategoriler = d;
      this.dataSource = new MatTableDataSource(this.kategoriler);
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }
}