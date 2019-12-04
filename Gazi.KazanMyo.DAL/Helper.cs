using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gazi.KazanMyo.DAL
{//DAL->Data Access Layer
    public class Helper : IDisposable
    {
        SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cstr"].ConnectionString);
        SqlCommand cmd = null;

        public int ExecuteNonQuery(string cmdtext, SqlParameter[] p)
        {
            cmd = new SqlCommand(cmdtext, cn);
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            OpenConnection();
            int sonuc = cmd.ExecuteNonQuery();                   
            return sonuc;
        }

        public SqlDataReader ExecuteReader(string cmdtext, SqlParameter[] p)
        {
            cmd = new SqlCommand(cmdtext, cn);
            if (p != null)
            {
                cmd.Parameters.AddRange(p);
            }
            OpenConnection();
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public DataTable MyDataTable(string cmdtext)
        {
            SqlDataAdapter da = new SqlDataAdapter(cmdtext, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
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

        public void Dispose()
        {
            if (cn != null && cmd != null)
            {
                cn.Dispose();
                cmd.Dispose();
            }
        }
    }
}
