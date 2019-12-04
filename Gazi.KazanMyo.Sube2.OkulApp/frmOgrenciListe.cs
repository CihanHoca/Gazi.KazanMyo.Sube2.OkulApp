using Gazi.Sube2.OkulApp.BLL;
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
    {
        public frmOgrenciListe()
        {
            InitializeComponent();
        }

        private void FrmOgrenciListe_Load(object sender, EventArgs e)
        {
            OgrenciBL ob = new OgrenciBL();
            dataGridView1.DataSource = ob.OgrenciTablosu();
        }
    }
}
