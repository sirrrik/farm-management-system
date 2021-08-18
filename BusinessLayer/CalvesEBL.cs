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
     public class CalvesEBL
    {
         public IEnumerable<Calves> Calvess
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Calves> calvess = new List<Calves>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllCalves", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Calves calves = new Calves();
                        calves.ID = Convert.ToInt32(rdr["ID"]);
                        calves.CalfID = Convert.ToInt32(rdr["CalfID"]);
                        calves.CowID = Convert.ToInt32(rdr["CowID"]);
                        calves.Gender = rdr["Gender"].ToString();
                        calves.Breed = rdr["Breed"].ToString();
                        calves.Health = rdr["Health"].ToString();
                        calves.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);

                        calvess.Add(calves);
                    }
                }
                return calvess;
            }
        }

         public void AddCalves(Calves calves)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spAddCalves", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramCalfID = new SqlParameter();
                paramCalfID.ParameterName = "@CalfID";
                paramCalfID.Value = calves.ID;
                cmd.Parameters.Add(paramCalfID);

                SqlParameter paramCowID = new SqlParameter();
                paramCowID.ParameterName = "@CowID";
                paramCowID.Value = calves.ID;
                cmd.Parameters.Add(paramCowID);

                SqlParameter paramNumber_of_Calves = new SqlParameter();
                paramNumber_of_Calves.ParameterName = "@Gender";
                paramNumber_of_Calves.Value = calves.Gender;
                cmd.Parameters.Add(paramNumber_of_Calves);

                SqlParameter paramProducing_Milk = new SqlParameter();
                paramProducing_Milk.ParameterName = "@Breed";
                paramProducing_Milk.Value = calves.Breed;
                cmd.Parameters.Add(paramProducing_Milk);

                SqlParameter paramComments = new SqlParameter();
                paramComments.ParameterName = "@Health";
                paramComments.Value = calves.Health;
                cmd.Parameters.Add(paramComments);

                SqlParameter paramDate = new SqlParameter();
                paramDate.ParameterName = "@BirthDate";
                paramDate.Value = calves.BirthDate;
                cmd.Parameters.Add(paramDate);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
         public void SaveCalves(Calves calves)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveCalves", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = calves.ID;
                cmd.Parameters.Add(paramId);

                SqlParameter paramCalfID = new SqlParameter();
                paramCalfID.ParameterName = "@CalfID";
                paramCalfID.Value = calves.CalfID;
                cmd.Parameters.Add(paramCalfID);

                SqlParameter paramCowID = new SqlParameter();
                paramCowID.ParameterName = "@CowID";
                paramCowID.Value = calves.CowID;
                cmd.Parameters.Add(paramCowID);

                SqlParameter paramNumber_of_Calves = new SqlParameter();
                paramNumber_of_Calves.ParameterName = "@Gender";
                paramNumber_of_Calves.Value = calves.Gender;
                cmd.Parameters.Add(paramNumber_of_Calves);

                SqlParameter paramProducing_Milk = new SqlParameter();
                paramProducing_Milk.ParameterName = "@Breed";
                paramProducing_Milk.Value = calves.Breed;
                cmd.Parameters.Add(paramProducing_Milk);

                SqlParameter paramComments = new SqlParameter();
                paramComments.ParameterName = "@Health";
                paramComments.Value = calves.Health;
                cmd.Parameters.Add(paramComments);

                SqlParameter paramBirthDate = new SqlParameter();
                paramBirthDate.ParameterName = "@BirthDate";
                paramBirthDate.Value = calves.BirthDate;
                cmd.Parameters.Add(paramBirthDate);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCalves(int id)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteCalves", con);
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
