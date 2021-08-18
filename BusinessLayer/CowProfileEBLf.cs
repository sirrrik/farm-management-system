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
    public class CowProfileEBLf
    {
        public IEnumerable<CPemp> Cowprofiles
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<CPemp> Cowprofiles = new List<CPemp>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllCowProfiles1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        CPemp cowProfile = new CPemp();
                        cowProfile.ID = Convert.ToInt32(rdr["ID"]);
                        cowProfile.CowId = Convert.ToInt32(rdr["CowId"]);
                        cowProfile.Age = rdr["Age"].ToString();
                        cowProfile.Breed = rdr["Breed"].ToString();
                        cowProfile.Health = rdr["Health"].ToString();
                        cowProfile.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);


                        Cowprofiles.Add(cowProfile);
                    }
                }
                return Cowprofiles;
            }
        }
        public void AddCPemp(CPemp cpem)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddCPemp2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@CowId";
                paramId.Value = cpem.CowId;
                cmd.Parameters.Add(paramId);
                SqlParameter paramAge = new SqlParameter();
                paramAge.ParameterName = "@Age";
                paramAge.Value = cpem.Age;
                cmd.Parameters.Add(paramAge);
                SqlParameter paramBreed = new SqlParameter();
                paramBreed.ParameterName = "@Breed";
                paramBreed.Value = cpem.Breed;
                cmd.Parameters.Add(paramBreed);
                SqlParameter paramHealth = new SqlParameter();
                paramHealth.ParameterName = "@Health";
                paramHealth.Value = cpem.Health;
                cmd.Parameters.Add(paramHealth);
                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = cpem.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveCPemp(CPemp cpemp)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveCPemp1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter ParamId = new SqlParameter();
                ParamId.ParameterName = "@ID";
                ParamId.Value = cpemp.ID;
                cmd.Parameters.Add(ParamId);

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@CowId";
                paramId.Value = cpemp.CowId;
                cmd.Parameters.Add(paramId);
                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Age";
                paramName.Value = cpemp.Age;
                cmd.Parameters.Add(paramName);
                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Breed";
                paramGender.Value = cpemp.Breed;
                cmd.Parameters.Add(paramGender);
                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@Health";
                paramCity.Value = cpemp.Health;
                cmd.Parameters.Add(paramCity);
                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = cpemp.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCPemp(int id)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCPemp1", con);
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




