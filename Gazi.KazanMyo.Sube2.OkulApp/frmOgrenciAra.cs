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
    public partial class frmOgrenciAra : Form
    {
        SqlConnection cn = null;
        private Form1 form1;

        public frmOgrenciAra()
        {
            InitializeComponent();
        }

        public frmOgrenciAra(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void BtnAra_Click(object sender, EventArgs e)
        {
            OgrenciBL obl = new OgrenciBL();
            Ogrenci ogr = obl.OgrenciBul(int.Parse(txtOgrenciNo.Text));

            if (ogr==null)
            {
                MessageBox.Show("Öğrenci Bulunamadı!");
            }
            else
            {
                form1.txtAd.Text = ogr.Ad;
                form1.txtSoyad.Text = ogr.Soyad;
                form1.txtNumara.Text = ogr.Numara;
                form1.ogrenciid = ogr.Ogrenciid;
                form1.cmbSiniflar.SelectedValue = ogr.Sinifid;
                form1.btnVazgec.Visible = true;
                form1.btnKaydet.Text = "Güncelle";
                form1.btnSil.Visible = true;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items)
            {
                MessageBox.Show(item.ToString());
            }
        }
    }
}
