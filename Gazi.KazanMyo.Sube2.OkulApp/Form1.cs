
using Gazi.Sube2.OkulApp.BLL;
using Gazi.Sube2.OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazi.KazanMyo.Sube2.OkulApp
{
    public partial class Form1 : Form
    {
        public int ogrenciid = 0;
        public Form1()
        {
            InitializeComponent();

        }
        //Sql Injection
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbSiniflar.SelectedIndex == 0)
            {
                MessageBox.Show("Sınıf Seçiniz!");
                return;
            }

            OgrenciBL obl = new OgrenciBL();
            try
            {
                Ogrenci ogrenci = new Ogrenci();
                ogrenci.Ad = txtAd.Text.Trim();
                ogrenci.Soyad = txtSoyad.Text.Trim();
                ogrenci.Numara = txtNumara.Text.Trim();
                ogrenci.Ogrenciid = ogrenciid;
                ogrenci.Sinifid = (int)cmbSiniflar.SelectedValue;

                if (ogrenciid == 0)
                {
                    if (obl.OgrenciEkle(ogrenci))
                    {
                        MessageBox.Show("Ekleme Başarılı");
                    }
                }
                else
                {
                    MessageBox.Show(obl.OgrenciGuncelle(ogrenci) ? "Başarılı" : "Başarısız");
                    ogrenciid = 0;
                }

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
            finally
            {
                Temizle();
                obl.Dispose();
            }
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            frmOgrenciAra frm = new frmOgrenciAra(this);
            frm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SinifBL sb = new SinifBL();
            cmbSiniflar.DisplayMember = "Sinifad";
            cmbSiniflar.ValueMember = "Sinifid";
            cmbSiniflar.DataSource = sb.SinifListesi();
            sb.Dispose();
        }

        void Temizle()
        {
            foreach (Control item in this.Controls["pnlTextbox"].Controls)
            {
                item.Text = string.Empty;
            }
            cmbSiniflar.SelectedIndex = 0;
        }
    }
}
