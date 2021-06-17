import { KategoriComponent } from './components/kategori/kategori.component';
import { HaberComponent } from './components/haber/haber.component';

import { AdminYazarComponent } from './components/admin-yazar/admin-yazar.component';
import { AdminUyeComponent } from './components/admin-uye/admin-uye.component';
import { AdminHaberComponent } from './components/admin-haber/admin-haber.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AdminMainComponent } from './components/admin-main/admin-main.component';
import { AdminKategoriComponent } from './components/admin-kategori/admin-kategori.component';
import { AuthGuard } from './services/AuthGuard';


const routes: Routes = [
  {
    path: '',
    component: HomeComponent
  },

  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'haber/:haberId',
    component: HaberComponent
  },
  {
    path: 'kategori/:kategoriId',
    component: KategoriComponent
  },
  {
    path: 'admin',
    component: AdminMainComponent,
    canActivate:[AuthGuard],
    data:{
      yetkiler:["admin"],
      gerigit:"/"
    }
  },
  {
    path: 'admin/kategori',
    component: AdminKategoriComponent,
    canActivate:[AuthGuard],
    data:{
      yetkiler:["Admin"],
      gerigit:"/"
    }
  },
  {
    path: 'admin/haber',
    component: AdminHaberComponent,
    data:{
      yetkiler:["Admin"],
      gerigit:"/"
    }
    
  },
  {
    path: 'admin/uye',
    component: AdminUyeComponent,
    data:{
      yetkiler:["Admin"],
      gerigit:"/"
    }
  },
  {
    path: 'admin/yazar',
    component: AdminYazarComponent,
    data:{
      yetkiler:["Admin"],
      gerigit:"/"
    }
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
