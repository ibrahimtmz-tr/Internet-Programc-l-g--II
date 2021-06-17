import { KategoriComponent } from './components/kategori/kategori.component';
import { HaberComponent } from './components/haber/haber.component';

import { HaberDialogComponent } from './components/dialogs/haber-dialog/haber-dialog.component';
import { AdminUyeComponent } from './components/admin-uye/admin-uye.component';
import { AdminYazarComponent } from './components/admin-yazar/admin-yazar.component';
import { AdminMainComponent } from './components/admin-main/admin-main.component';
import { AdminHaberComponent } from './components/admin-haber/admin-haber.component';
import { ApiService } from './services/api.service';

import { ConfirmDialogComponent } from './components/dialogs/confirm-dialog/confirm-dialog.component';
import { MyAlertService } from './services/myAlert.service';
import { AlertDialogComponent } from './components/dialogs/alert-dialog/alert-dialog.component';
import { MaterialModule } from './material.module';
import { HomeComponent } from './components/home/home.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MainNavComponent } from './components/main-nav/main-nav.component';
import { LoginComponent } from './components/login/login.component';
import { AdminKategoriComponent } from './components/admin-kategori/admin-kategori.component';
import { KategoriDialogComponent } from './components/dialogs/kategori-dialog/kategori-dialog.component';
import { AuthInterceptor } from './services/AuthInterceptor';
import { AuthGuard } from './services/AuthGuard';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MainNavComponent,
    LoginComponent,
    AdminHaberComponent,
    AdminMainComponent,
    AdminYazarComponent,
    AdminUyeComponent,
    AdminKategoriComponent,
    AlertDialogComponent,
    ConfirmDialogComponent,
    KategoriDialogComponent,
    HaberDialogComponent,
    HaberComponent,
    KategoriComponent



  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    HttpClientModule,
    ReactiveFormsModule
  ],
  entryComponents: [
    AlertDialogComponent,
    ConfirmDialogComponent,
    KategoriDialogComponent,
    HaberDialogComponent
  ],
  providers: [MyAlertService, ApiService,AuthGuard,
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true}],
  bootstrap: [AppComponent]
})
export class AppModule { }
