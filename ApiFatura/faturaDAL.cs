using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiFatura
{
    public class faturaDAL
    {
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-MJN8QB1\\SQLEXPRESS; Initial Catalog = faturaDB; Integrated Security = True");
        faturaModel fatura = new faturaModel();

        [HttpGet]
        public DataTable faturaBilgi(string id)
        {
            bgl.Open();
            string sql = string.Format(@"select F.faturaID,f.aboneID,f.guncelBorc,f.sonOdemeTarihi from tbl_fatura F inner join tbl_abone A on F.aboneID=A.aboneID where A.aboneNo={0}", id);
            SqlDataAdapter adp = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adp.InsertCommand = new SqlCommand(sql, bgl);
            adp.InsertCommand.ExecuteNonQuery();
            dt.TableName = "Bilgi";
            SqlCommand cmd = new SqlCommand("select F.faturaID, f.aboneID, f.guncelBorc, f.sonOdemeTarihi from tbl_fatura F inner join tbl_abone A on F.aboneID = A.aboneID where A.aboneNo ='"+id+"'", bgl);
            adp.SelectCommand = cmd; 
            adp.Fill(dt);
            //fatura.faturaID=Convert.ToInt32(dt.Rows[0]["faturaID"].ToString());
            //fatura.aboneID = Convert.ToInt32(dt.Rows[0]["aboneID"].ToString());
            //fatura.guncelBorc = Convert.ToDecimal(dt.Rows[0]["guncelBorc"].ToString());
            //fatura.sonOdemeTarihi = Convert.ToDateTime(dt.Rows[0]["sonOdemeTarihi"].ToString());
            bgl.Close();
            return dt;

        }

        [HttpGet]
        public bool FaturaOde(string id)
        {
            bgl.Open();
            SqlCommand cmd = new SqlCommand();
            string sql = string.Format(@"exec sp_PayBill {0}", id);
            SqlDataAdapter adp = new SqlDataAdapter();
            adp.InsertCommand = new SqlCommand(sql, bgl);
            adp.InsertCommand.ExecuteNonQuery();
            DataTable dt = new DataTable();
            dt.TableName = "Sİl";
            bgl.Close();
            return true;
        }


    }
}