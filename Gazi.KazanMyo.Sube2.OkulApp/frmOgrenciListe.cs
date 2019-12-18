using Gazi.Sube2.OkulApp.BLL;
using Gazi.Sube2.OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gazi.KazanMyo.Sube2.OkulApp
{
    public partial class frmOgrenciListe : Form
    {//ORM-Object Relational Mapping

        DataTable dt;
        public frmOgrenciListe()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            //Mapping
        }

        private void FrmOgrenciListe_Load(object sender, EventArgs e)
        {
            OgrenciBL ob = new OgrenciBL();
            dt = ob.OgrenciTablosu();
            dataGridView1.DataSource = dt;

            SinifBL sb = new SinifBL();
            clmSinif.DisplayMember = "Sinifad";
            clmSinif.ValueMember = "Sinifid";
            clmSinif.DataSource = sb.SinifListesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            OgrenciBL obl = new OgrenciBL();
            foreach (DataRow item in dt.Rows)
            {
                Ogrenci o = new Ogrenci();
                o.Ad = item["Ad"].ToString();
                o.Soyad = item["Soyad"].ToString();
                o.Numara = item["Numara"].ToString();
                o.Sinifid = Convert.ToInt32(item["SinifId"]);
                switch (item.RowState)
                {
                    case DataRowState.Added:
                        obl.OgrenciEkle(o);
                        break;
                    case DataRowState.Deleted:
                        obl.OgrenciSil((int)item["OgrenciId", DataRowVersion.Original]);
                        break;
                    case DataRowState.Modified:
                        o.Ogrenciid = (int)item["OgrenciId"];
                        obl.OgrenciGuncelle(o);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
