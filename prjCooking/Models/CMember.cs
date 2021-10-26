using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prjCooking.Models
{
    public class CMember
    {
        public int fId { get; set; }
        public string 信箱 { get; set; }
        public string 密碼 { get; set; }
        public string 姓名 { get; set; }
        public int 性別 { get; set; }

        private void executeSql(string sql, List<SqlParameter> paras)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\dbCooking.mdf;integrated security=True";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            if (paras != null)
            {
                foreach (SqlParameter p in paras)
                    cmd.Parameters.Add(p);
            }
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void create(t會員 m)
        {
            dbCookingEntities db = new dbCookingEntities();

            

            List<SqlParameter> paras = new List<SqlParameter>();
            string sql = "INSERT INTO t會員 (";
            if (!string.IsNullOrEmpty(m.f會員信箱))
                sql += " f會員信箱 ,";
            if (!string.IsNullOrEmpty(m.f會員密碼))
                sql += " f會員密碼 ,";
            if (!string.IsNullOrEmpty(m.f會員姓名))
                sql += " f會員姓名 ,";
            if (!string.IsNullOrEmpty(m.f性別.ToString()))
                sql += " f性別 ,";
            if (sql.Trim().Substring(sql.Trim().Length - 1, 1) == ",")
                sql = sql.Trim().Substring(0, sql.Trim().Length - 1);
            sql += " )VALUES(";
            if (!string.IsNullOrEmpty(m.f會員信箱))
            {
                sql += " @K_Email ,";
                paras.Add(new SqlParameter("K_Email", (object)m.f會員信箱));
            }
            if (!string.IsNullOrEmpty(m.f會員密碼))
            {
                sql += " @K_Pwd ,";
                paras.Add(new SqlParameter("K_Pwd", (object)m.f會員密碼));
            }
            if (!string.IsNullOrEmpty(m.f會員姓名))
            {
                sql += " @K_Name ,";
                paras.Add(new SqlParameter("K_Name", (object)m.f會員姓名));
            }
            if (!string.IsNullOrEmpty(m.f性別.ToString()))
            {
                sql += " @K_Gender ,";
                paras.Add(new SqlParameter("K_Gender", (object)m.f性別));
            }
            if (sql.Trim().Substring(sql.Trim().Length - 1, 1) == ",")
                sql = sql.Trim().Substring(0, sql.Trim().Length - 1);
            sql += "  )";
            executeSql(sql, paras);
        }

    }
}