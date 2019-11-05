using Gazi.Sube2.OkulApp.BLL;
using Gazi.Sube2.OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazi.KazanMyo.Sube2.OkulApp
{
    public partial class Form1 : Form
    {

        SqlConnection cn = null;
        public Form1()
        {
            InitializeComponent();
            
        }
        //Sql Injection
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                OgrenciBL obl = new OgrenciBL(); 
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Ad = txtAd.Text.Trim();
                ogrenci.Soyad = txtSoyad.Text.Trim();
                ogrenci.Numara = txtNumara.Text.Trim();
                MessageBox.Show(obl.OgrenciEkle(ogrenci)?"Başarılı":"Başarısız");
            }
            catch (SqlException ex)
            {               
                switch (ex.Number)
                {
                    case 245:
                        MessageBox.Show("Numara girişinde hata");
                        break;
                    default:
                        MessageBox.Show("Veritabanı hatası!" + ex.Number);
                        break;
                }
            }
            catch (Exception)
            {              
                MessageBox.Show("Bir hata oluştu..");
            }           
        }

       

        private void BtnAra_Click(object sender, EventArgs e)
        {
            
            frmOgrenciAra frm = new frmOgrenciAra(this);
            frm.Show();
        }
    }
}
