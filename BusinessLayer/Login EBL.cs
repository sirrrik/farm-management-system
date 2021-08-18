using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Login_EBL
    {
        public int CheckUserLogin (Login login)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("uspLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@UserID", login.UserID));
                cmd.Parameters.Add(new SqlParameter("@UserName", login.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", login.Password));
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}