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
            Bul(int.Parse(txtOgrenciNo.Text.Trim()));
        }

        void Bul(int numara)
        {
            try
            {
                cn = new SqlConnection(@"Data Source=.;Initial Catalog=TestDb1;Integrated Security=true");

                SqlParameter[] p = { new SqlParameter("@Numara", numara) };

                SqlCommand cmd = new SqlCommand("Select OgrenciId,Ad,Soyad,Numara from tblOgrenciler where Numara=@Numara", cn);

                cmd.Parameters.AddRange(p);
                OpenConnection();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    //MessageBox.Show($"Ad:{dr["Ad"].ToString()}\nSoyad:{dr["Soyad"]}\nNumara:{dr["Numara"]}\nOgrenciId:{dr["OgrenciId"]}");
                    Form1 frm = (Form1)Application.OpenForms["Form1"];

                    frm.txtAd.Text = dr["Ad"].ToString();
                    frm.txtSoyad.Text = dr["Soyad"].ToString();
                    frm.txtNumara.Text = dr["Numara"].ToString();
                }
                else
                {
                    MessageBox.Show("Öğrenci  bulunamadı!");
                }
                dr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }


        void OpenConnection()
        {


            try
            {
                if (cn != null && cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        void CloseConnection()
        {
            try
            {
                if (cn != null && cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}
