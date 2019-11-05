using Gazi.KazanMyo.DAL;
using Gazi.Sube2.OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazi.Sube2.OkulApp.BLL
{
    public class OgrenciBL
    {
        public bool OgrenciEkle(Ogrenci ogr)
        {
            Helper hlp = new Helper();
            SqlParameter[] p = { new SqlParameter("@Ad", ogr.Ad), new SqlParameter("@Soyad", ogr.Soyad), new SqlParameter("@Numara", ogr.Numara),new SqlParameter("@SinifId",1) };
            return hlp.ExecuteNonQuery("Insert into tblOgrenciler values(@Ad,@Soyad,@Numara,@SinifId)", p) > 0;
        }
    }
}
