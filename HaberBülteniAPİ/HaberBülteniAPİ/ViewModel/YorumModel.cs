using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HaberBülteniAPİ.ViewModel
{
    public class YorumModel
    {
        public int yorumId { get; set; }
        public string yorumIcerik { get; set; }
        public int yorumUyeId { get; set; }
        public string yorumUyeAd { get; set; }
        public int yorumHaberId { get; set; }
        public string yorumTarih { get; set; }
    }
}