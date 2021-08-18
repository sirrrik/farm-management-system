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
     public class RolesEBL
    {
        public IEnumerable<Roles> Roless
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Roles> roless = new List<Roles>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllrole4", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Roles roles = new Roles();
                        roles.ID = Convert.ToInt32(rdr["ID"]);
                        roles.role_id = Convert.ToInt32(rdr["role_id"]);
                        roles.role_name = rdr["role_name"].ToString();
                        roles.role_desc = rdr["role_desc"].ToString();
                        roless.Add(roles);
                    }
                }
                return roless;
            }
        }

        public void AddRoles(Roles roles)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spAddrole4", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramrole_id = new SqlParameter();
                paramrole_id.ParameterName = "@role_id";
                paramrole_id.Value = roles.role_id;
                cmd.Parameters.Add(paramrole_id);

                SqlParameter paramrole_name = new SqlParameter();
                paramrole_name.ParameterName = "@role_name";
                paramrole_name.Value = roles.role_name;
                cmd.Parameters.Add(paramrole_name);

                SqlParameter paramrole_desc = new SqlParameter();
                paramrole_desc.ParameterName = "@role_desc";
                paramrole_desc.Value = roles.role_desc;
                cmd.Parameters.Add(paramrole_desc);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveRoles(Roles roles)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveroles2", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ParamId = new SqlParameter();
                ParamId.ParameterName = "@ID";
                ParamId.Value = roles.ID;
                cmd.Parameters.Add(ParamId);

                SqlParameter paramrole_id = new SqlParameter();
                paramrole_id.ParameterName = "@role_id";
                paramrole_id.Value = roles.role_id;
                cmd.Parameters.Add(paramrole_id);

                SqlParameter paramrole_name = new SqlParameter();
                paramrole_name.ParameterName = "@role_name";
                paramrole_name.Value = roles.role_name;
                cmd.Parameters.Add(paramrole_name);

                SqlParameter paramrole_desc = new SqlParameter();
                paramrole_desc.ParameterName = "@role_desc";
                paramrole_desc.Value = roles.role_desc;
                cmd.Parameters.Add(paramrole_desc);
               
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteRoles(int id)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleterole4", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
