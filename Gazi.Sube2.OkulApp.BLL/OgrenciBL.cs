using Gazi.KazanMyo.DAL;
using Gazi.Sube2.OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazi.Sube2.OkulApp.BLL
{
    public class OgrenciBL:IDisposable
    {
        Helper hlp = new Helper();
        public bool OgrenciEkle(Ogrenci ogr)
        {
            SqlParameter[] p = { new SqlParameter("@Ad", ogr.Ad), new SqlParameter("@Soyad", ogr.Soyad), new SqlParameter("@Numara", ogr.Numara), new SqlParameter("@SinifId", 1) };
            int sonuc = hlp.ExecuteNonQuery("Insert into tblOgrenciler values(@Ad,@Soyad,@Numara,@SinifId)", p);  
            return sonuc > 0;
        }

        public Ogrenci OgrenciBul(int numara)
        {
            SqlParameter[] p = { new SqlParameter("@Numara", numara) };
            SqlDataReader dr = hlp.ExecuteReader("Select Ad,Soyad,Numara,SinifId from tblOgrenciler Where Numara=@Numara", p);
            Ogrenci o = null;
            if (dr.Read())
            {
                o = new Ogrenci();
                o.Ad = dr["Ad"].ToString();
                o.Soyad = dr["Soyad"].ToString();
                o.Numara = dr["Numara"].ToString();
                o.Sinifid = Convert.ToInt32(dr["SinifId"]);
            }
            dr.Close();
           
            return o;
        }

        public void Dispose()
        {
            hlp.Dispose();
        }
    }
}
