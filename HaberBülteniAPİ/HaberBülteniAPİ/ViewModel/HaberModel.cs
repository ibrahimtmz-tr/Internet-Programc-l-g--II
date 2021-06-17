using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberBülteniAPİ.ViewModel
{
    public class HaberModel
    {
        public int haberId { get; set; }
        public string haberBaslik { get; set; }
        public string haberOzet { get; set; }
        public string haber { get; set; }
        public string haberFoto { get; set; }
        public int haberYazarId { get; set; }
        public int haberKategoriId { get; set; }
        public string haberKategoriAdı { get; set; }
        public string haberYazarAdı { get; set; }
        public string haberTarih { get; set; }
    }
}