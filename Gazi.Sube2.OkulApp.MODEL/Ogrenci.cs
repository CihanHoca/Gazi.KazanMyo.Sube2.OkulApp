using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazi.Sube2.OkulApp.MODEL
{
    public class Ogrenci
    {
        public int Ogrenciid { get; set; }

        string ad;
        string soyad;
        public string Numara { get; set; }
        public string Ad { get => ad; set => ad = value.ToUpper(); }
        public string Soyad { get => soyad; set => soyad = value.ToUpper(); }

        public int Sinifid { get; set; }

    }
}
