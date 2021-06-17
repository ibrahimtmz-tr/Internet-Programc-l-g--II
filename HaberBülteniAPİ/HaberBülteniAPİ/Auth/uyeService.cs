using HaberBülteniAPİ.Models;
using HaberBülteniAPİ.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberBülteniAPİ.Auth
{
    public class uyeService
    {
        HaberBülteniApiDBEntities db = new HaberBülteniApiDBEntities();
        public UyeModel UyeOturumAc(string kadi, string parola)
        {
            UyeModel uye = db.Uye.Where(s => s.uyeMail == kadi && s.uyeSifre == parola).Select(x => new UyeModel()
            {
                uyeId = x.uyeId,
                uyeAd = x.uyeAd,
                uyeMail = x.uyeMail,
                uyeSifre = x.uyeSifre,
                uyeYetki = x.uyeYetki

            }).SingleOrDefault();
            return uye;
        }
    }


}