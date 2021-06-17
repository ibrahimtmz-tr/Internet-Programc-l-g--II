using HaberBülteniAPİ.Models;
using HaberBülteniAPİ.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HaberBülteniAPİ.Controllers
{
    [EnableCors(origins: "http://localhost:4200",headers:"*", methods:"*")]
    public class ServisController : ApiController
    {
        HaberBülteniApiDBEntities db = new HaberBülteniApiDBEntities();
        SonucModel sonuc = new SonucModel();

        #region Kategori
        [HttpGet]
        [Route("api/kategoriliste")]
        public List<KategoriModel> KategoriListe()
        {
            List<KategoriModel> liste = db.Kategori.Select(x => new KategoriModel() {
                kategoriId=x.kategoriId,
                kategoriAd=x.kategoriAd
            }).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/kategoribyid/{KatId}")]
        public KategoriModel KategoriById(int KatId)
        {
            KategoriModel kayit= db.Kategori.Where(s => s.kategoriId == KatId).Select(x => new KategoriModel() {
            kategoriId=x.kategoriId,
            kategoriAd=x.kategoriAd
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/kategoriekle")]
        public SonucModel KategoriEkle(KategoriModel model)
        {
            if (db.Kategori.Count(s=>s.kategoriAd==model.kategoriAd) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kategori zaten mevcut.";
                return sonuc;
            }
            Kategori yeni= new Kategori();
            yeni.kategoriAd = model.kategoriAd;
            db.Kategori.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı.";

            return sonuc;
        }
        [HttpPut]
        [Route("api/kategoriduzenle")]
        public SonucModel KategoriDuzenle(KategoriModel model)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == model.kategoriId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Düzenleyeceğiniz kategori mevcut değil.";
                return sonuc;
            }
            kayit.kategoriAd = model.kategoriAd;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/kategorisil/{katId}")]
        public SonucModel KategoriSil(int KatId)
        {
            Kategori kayit = db.Kategori.Where(s => s.kategoriId == KatId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = " mevcut değil.";
                return sonuc;
            }
            if (db.Haber.Count(s=>s.haberKategoriId==KatId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde haber olan kategoriyi silmeden önce, kategoriye kayıtlı haberleri silmelisiniz.";
                return sonuc;
            }
            db.Kategori.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı.";

            return sonuc;
        }

        #endregion
        #region Haber
        [HttpGet]
        [Route("api/haberliste")]
        public List<HaberModel> HaberListe()
        {
            List<HaberModel> liste = db.Haber.Select(x => new HaberModel() {
                haberId=x.haberId,
                haberBaslik=x.haberBaslik,
                haber=x.haber,
                haberOzet=x.haberOzet,
                haberFoto=x.haberFoto,
                haberTarih=x.haberTarih,
                haberKategoriId=x.haberKategoriId,
                haberKategoriAdı=x.Kategori.kategoriAd,
                haberYazarId=x.haberYazarId,
                haberYazarAdı=x.Yazar.yazarAdSoyad
            
            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/haberlistesondakika/{s}")]
        public List<HaberModel> HaberListeSonDakika(int s)
        {
            List<HaberModel> liste = db.Haber.OrderByDescending(o => o.haberId).Take(s).Select(x => new HaberModel()
            {
                haberId = x.haberId,
                haberBaslik = x.haberBaslik,
                haber = x.haber,
                haberOzet = x.haberOzet,
                haberFoto = x.haberFoto,
                haberTarih = x.haberTarih,
                haberKategoriId = x.haberKategoriId,
                haberKategoriAdı = x.Kategori.kategoriAd,
                haberYazarId = x.haberYazarId,
                haberYazarAdı = x.Yazar.yazarAdSoyad

            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/haberbykatid/{katId}")]
        public List<HaberModel> HaberByKatId(int katId)
        {
            List<HaberModel> liste = db.Haber.Where(s=>s.haberKategoriId==katId).Select(x => new HaberModel()
            {
                haberId = x.haberId,
                haberBaslik = x.haberBaslik,
                haber = x.haber,
                haberOzet = x.haberOzet,
                haberFoto = x.haberFoto,
                haberTarih = x.haberTarih,
                haberKategoriId = x.haberKategoriId,
                haberKategoriAdı = x.Kategori.kategoriAd,
                haberYazarId = x.haberYazarId,
                haberYazarAdı = x.Yazar.yazarAdSoyad

            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/haberbyyazarid/{yazarId}")]
        public List<HaberModel> HaberByYazarId(int yazarId)
        {
            List<HaberModel> liste = db.Haber.Where(s => s.haberYazarId == yazarId).Select(x => new HaberModel()
            {
                haberId = x.haberId,
                haberBaslik = x.haberBaslik,
                haber = x.haber,
                haberOzet = x.haberOzet,
                haberFoto = x.haberFoto,
                haberTarih = x.haberTarih,
                haberKategoriId = x.haberKategoriId,
                haberKategoriAdı = x.Kategori.kategoriAd,
                haberYazarId = x.haberYazarId,
                haberYazarAdı = x.Yazar.yazarAdSoyad

            }).ToList();
            return liste;
        }
        [HttpGet]
        [Route("api/haberbyid/{haberId}")]
        public HaberModel HaberById(int haberId)
        {
            HaberModel kayit = db.Haber.Where(s => s.haberId == haberId).Select(x => new HaberModel() {
                haberId = x.haberId,
                haberBaslik = x.haberBaslik,
                haber = x.haber,
                haberOzet = x.haberOzet,
                haberFoto = x.haberFoto,
                haberTarih = x.haberTarih,
                haberKategoriId = x.haberKategoriId,
                haberKategoriAdı = x.Kategori.kategoriAd,
                haberYazarId = x.haberYazarId,
                haberYazarAdı = x.Yazar.yazarAdSoyad
            }).SingleOrDefault();
            return kayit;

        }
        [HttpPost]
        [Route("api/haberekle")]
        public SonucModel HaberEkle(HaberModel model)
        {
            if (db.Haber.Count(s=>s.haberBaslik==model.haberBaslik) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Girilen haber başlığı mevcuttur.";
                return sonuc;
            }
            Haber yeni = new Haber();
            yeni.haberBaslik = model.haberBaslik;
            yeni.haberOzet = model.haberOzet;
            yeni.haber = model.haber;
            yeni.haberFoto = model.haberFoto;
            yeni.haberKategoriId = model.haberKategoriId;
            yeni.haberYazarId = model.haberYazarId;
            yeni.haberTarih = model.haberTarih;
            db.Haber.Add(yeni);
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı.";
            return sonuc;
        }
        [HttpPut]
        [Route("api/haberduzenle")]
        public SonucModel HaberDuzenle(HaberModel model)
        {
            Haber kayit = db.Haber.Where(s => s.haberId == model.haberId).SingleOrDefault();

            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Haber bulunamadı.";
                return sonuc;
            }
            kayit.haberBaslik = model.haberBaslik;
            kayit.haberOzet = model.haberOzet;
            kayit.haber = model.haber;
            kayit.haberFoto = model.haberFoto;
            kayit.haberKategoriId = model.haberKategoriId;
            kayit.haberYazarId = model.haberYazarId;
            kayit.haberTarih = model.haberTarih;
            db.SaveChanges();

            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı.";
            return sonuc; 
        }
        [HttpDelete]
        [Route("api/habersil/{HaberId}")]
        public SonucModel HaberSil(int HaberId)
        {
            Haber kayit = db.Haber.Where(s => s.haberId == HaberId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayit mevcut değil.";
                return sonuc;
            }
            if (db.Yorum.Count(s => s.yorumHaberId == HaberId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üzerinde yorum olan haberi silmeden önce, habere ait yorumları silmelisiniz.";
                return sonuc;
            }
            db.Haber.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı.";

            return sonuc;
        }
        #endregion
        #region Yazar
        [HttpGet]
        [Route("api/yazarliste")]
        public List<YazarModel> YazarListe()
        {
            List<YazarModel> liste = db.Yazar.Select(x => new YazarModel()
            {
               yazarAdSoyad=x.yazarAdSoyad,
               yazarBilgi=x.yazarBilgi,
               yazarId=x.yazarId,
               yazarResim=x.yazarResim

            }).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/yazarbyid/{YazarId}")]
        public YazarModel YazarById(int YazarId)
        {
            YazarModel kayit = db.Yazar.Where(s => s.yazarId == YazarId).Select(x => new YazarModel()
            {
                yazarAdSoyad = x.yazarAdSoyad,
                yazarBilgi = x.yazarBilgi,
                yazarId = x.yazarId,
                yazarResim = x.yazarResim
            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/yazarekle")]
        public SonucModel YazarEkle(YazarModel model)
        {
            if (db.Yazar.Count(s => s.yazarAdSoyad == model.yazarAdSoyad) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Yazar zaten mevcut.";
                return sonuc;
            }
            Yazar yeni = new Yazar();
            yeni.yazarAdSoyad = model.yazarAdSoyad;
            yeni.yazarBilgi = model.yazarBilgi;
            yeni.yazarResim = model.yazarResim;
            db.Yazar.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Yazar Eklendi.";

            return sonuc;
        }
        [HttpPut]
        [Route("api/yazarduzenle")]
        public SonucModel YazarDuzenle(YazarModel model)
        {
            Yazar kayit = db.Yazar.Where(s => s.yazarId == model.yazarId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Yazar mevcut değil.";
                return sonuc;
            }
            kayit.yazarAdSoyad = model.yazarAdSoyad;
            kayit.yazarBilgi = model.yazarBilgi;
            kayit.yazarResim = model.yazarResim;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/yazarsil/{YazarId}")]
        public SonucModel YazarSil(int YazarId)
        {
            Yazar kayit = db.Yazar.Where(s => s.yazarId == YazarId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Yazar mevcut değil.";
                return sonuc;
            }
            if (db.Haber.Count(s => s.haberYazarId == YazarId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Yazarı silmeden önce, yazarın yazdığı haberleri silmelisiniz.";
                return sonuc;
            }
            db.Yazar.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı.";

            return sonuc;
        }
        #endregion
        #region Yorum
        [HttpGet]
        [Route("api/yorumliste")]
        public List<YorumModel> YorumListe()
        {
            List<YorumModel> liste = db.Yorum.Select(x => new YorumModel()
            {
                yorumId = x.yorumId,
                yorumIcerik = x.yorumIcerik,
                yorumUyeId = x.yorumUyeId,
                yorumHaberId = x.yorumHaberId,
                yorumTarih = x.yorumTarih,
                yorumUyeAd = x.Uye.uyeAd
            }).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/yorumbyhaberid/{HaberId}")]
        public List<YorumModel> YorumByHaberId(int HaberId)
        {
            List<YorumModel> liste = db.Yorum.Where(s => s.yorumHaberId == HaberId).Select(x => new YorumModel()
            {
               yorumId=x.yorumId,
               yorumIcerik=x.yorumIcerik,
               yorumUyeId=x.yorumUyeId,
               yorumHaberId=x.yorumHaberId,
               yorumTarih=x.yorumTarih,
               yorumUyeAd=x.Uye.uyeAd
            }).ToList();
            return liste;
        }
        [HttpPost]
        [Route("api/yorumekle")]
        public SonucModel YorumEkle(YorumModel model)
        {
            Yorum yeni = new Yorum();
            yeni.yorumIcerik = model.yorumIcerik;
            yeni.yorumUyeId = model.yorumUyeId;           
            yeni.yorumHaberId = model.yorumHaberId;
            yeni.yorumTarih = model.yorumTarih;

            db.Yorum.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Yorum Eklendi.";

            return sonuc;
        }
        [HttpPut]
        [Route("api/yorumduzenle/")]
        public SonucModel YorumDuzenle(YorumModel model)
        {
            Yorum kayit = db.Yorum.Where(s => s.yorumId == model.yorumId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Yorum mevcut değil.";
                return sonuc;
            }
            kayit.yorumIcerik = model.yorumIcerik;
            kayit.yorumHaberId = model.yorumHaberId;
            kayit.yorumUyeId = model.yorumUyeId;
            kayit.yorumTarih = model.yorumTarih;          

            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Yorum Düzenlendi";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/yorumsil/{YorumId}")]
        public SonucModel YorumSil(int YorumId)
        {
            Yorum kayit = db.Yorum.Where(s => s.yorumId == YorumId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Yorum mevcut değil.";
                return sonuc;
            }
            db.Yorum.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı.";

            return sonuc;
        }
        #endregion
        #region Üye
        [HttpGet]
        [Route("api/uyeliste")]
        public List<UyeModel> UyeListe()
        {
            List<UyeModel> liste = db.Uye.Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                uyeAd=x.uyeAd,
                uyeMail=x.uyeMail,
                uyeSifre=x.uyeSifre,
                uyeYetki=x.uyeYetki
                
            }).ToList();

            return liste;
        }
        [HttpGet]
        [Route("api/uyebyid/{UyeId}")]
        public UyeModel UyeById(int UyeID)
        {
            UyeModel kayit = db.Uye.Where(s => s.uyeId == UyeID).Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                uyeAd = x.uyeAd,
                uyeMail = x.uyeMail,
                uyeSifre = x.uyeSifre,
                uyeYetki = x.uyeYetki

            }).SingleOrDefault();
            return kayit;
        }
        [HttpPost]
        [Route("api/uyeekle")]
        public SonucModel UyeEkle(UyeModel model)
        {
            if (db.Uye.Count(s => s.uyeMail == model.uyeMail) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Bu maile kayıtlı hesap bulunmaktadır.";
                return sonuc;
            }
            Uye yeni = new Uye();
            yeni.uyeAd = model.uyeAd;
            yeni.uyeMail = model.uyeMail;
            yeni.uyeSifre = model.uyeSifre;
            yeni.uyeYetki = model.uyeYetki;

            db.Uye.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Üye Eklendi.";

            return sonuc;
        }
        [HttpPut]
        [Route("api/uyeduzenle")]
        public SonucModel UyeDuzenle(UyeModel model)
        {
            Uye kayit = db.Uye.Where(s => s.uyeId == model.uyeId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye mevcut değil.";
                return sonuc;
            }
            kayit.uyeAd = model.uyeAd;
            kayit.uyeMail = model.uyeMail;
            kayit.uyeSifre = model.uyeSifre;
            kayit.uyeYetki = model.uyeYetki;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı";
            return sonuc;
        }
        [HttpDelete]
        [Route("api/uyesil/{UyeId}")]
        public SonucModel UyeSil(int UyeId)
        {
            Uye kayit = db.Uye.Where(s => s.uyeId == UyeId).SingleOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Üye mevcut değil.";
                return sonuc;
            }
            if (db.Yorum.Count(s => s.yorumUyeId == UyeId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcıyı silmeden önce,kullanıcıya ait yorumları silmelisiniz.";
                return sonuc;
            }
            db.Uye.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "İşlem başarılı.";

            return sonuc;
        }
        #endregion

    }
}   
