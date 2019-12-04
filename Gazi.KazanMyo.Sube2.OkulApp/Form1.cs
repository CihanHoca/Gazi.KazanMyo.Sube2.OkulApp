
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
            ogrenciid = 0;
            btnVazgec.Visible = false;
            btnKaydet.Text = "Ekle";
            btnSil.Visible = false;
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult cvp = MessageBox.Show("Emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cvp == DialogResult.No) return;

            OgrenciBL obl = new OgrenciBL();
            try
            {
                if (obl.OgrenciSil(ogrenciid))
                {
                    MessageBox.Show("Silme Başarılı'");
                }
                else
                {
                    MessageBox.Show("Silme Hatalı!!");
                }
                Temizle();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                obl.Dispose();
            }
        }

        private void TxtAd_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        int[] turkce = {252,287,351,231,246,305,304,220,286,350,199,214 };

        int[] ozelkarakter = { 8, 32 };

        private void Txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!((e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122) || turkce.Contains(e.KeyChar)||ozelkarakter.Contains(e.KeyChar)))
            //{
            //    e.Handled = true;
            //}
            e.Handled = KarakterKontrol(e.KeyChar);
        }
        bool KarakterKontrol(char c)
        {
            if (!((c >= 65 && c <= 90) || (c >= 97 && c <= 122) || turkce.Contains(c) || ozelkarakter.Contains(c)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string ascii = string.Empty;
            for (int i = 0; i < txtSoyad.Text.Length; i++)
            {
                ascii += txtSoyad.Text[i].ToString()+"-"+((int)txtSoyad.Text[i]).ToString()+"\n";
            }
            MessageBox.Show(ascii);
        }
    }
}
