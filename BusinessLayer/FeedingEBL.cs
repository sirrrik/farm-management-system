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
     public class FeedingEBL
    {
         public IEnumerable<Feeding> Feedings
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Feeding> feedings = new List<Feeding>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllFeeding1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Feeding feeding = new Feeding();
                        feeding.ID = Convert.ToInt32(rdr["ID"]);
                        feeding.Feeding_id = Convert.ToInt32(rdr["Feeding_id"]);
                        feeding.Housing_id = Convert.ToInt32(rdr["Housing_id"]);
                        feeding.CowID = Convert.ToInt32(rdr["CowID"]);
                        feeding.food_id = Convert.ToInt32(rdr["food_id"]);
                        feeding.quantity = rdr["quantity"].ToString();
                        
                        

                        feedings.Add(feeding);
                    }
                }
                return feedings;
            }
        }

         public void AddFeeding(Feeding feeding)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spAddFeeding1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFeeding_id = new SqlParameter();
                paramFeeding_id.ParameterName = "@Feeding_id";
                paramFeeding_id.Value = feeding.Feeding_id;
                cmd.Parameters.Add(paramFeeding_id);

                SqlParameter paramHousing_id = new SqlParameter();
                paramHousing_id.ParameterName = "@Housing_id";
                paramHousing_id.Value = feeding.Housing_id;
                cmd.Parameters.Add(paramHousing_id);

                SqlParameter paramCowID = new SqlParameter();
                paramCowID.ParameterName = "@CowID";
                paramCowID.Value = feeding.CowID;
                cmd.Parameters.Add(paramCowID);

                SqlParameter paramfood_id = new SqlParameter();
                paramfood_id.ParameterName = "@food_id";
                paramfood_id.Value = feeding.food_id;
                cmd.Parameters.Add(paramfood_id);

                SqlParameter paramquantity = new SqlParameter();
                paramquantity.ParameterName = "@quantity";
                paramquantity.Value = feeding.quantity;
                cmd.Parameters.Add(paramquantity);

              
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
         public void SaveFeeding(Feeding feeding)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveFeeding1", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = feeding.ID;
                cmd.Parameters.Add(paramId);

                SqlParameter paramFeeding_id = new SqlParameter();
                paramFeeding_id.ParameterName = "@Feeding_id";
                paramFeeding_id.Value = feeding.Feeding_id;
                cmd.Parameters.Add(paramFeeding_id);

                SqlParameter paramHousing_id = new SqlParameter();
                paramHousing_id.ParameterName = "@Housing_id";
                paramHousing_id.Value = feeding.Housing_id;
                cmd.Parameters.Add(paramHousing_id);

                SqlParameter paramCowID = new SqlParameter();
                paramCowID.ParameterName = "@CowID";
                paramCowID.Value = feeding.CowID;
                cmd.Parameters.Add(paramCowID);

                SqlParameter paramfood_id = new SqlParameter();
                paramfood_id.ParameterName = "@food_id";
                paramfood_id.Value = feeding.food_id;
                cmd.Parameters.Add(paramfood_id);

                SqlParameter paramquantity = new SqlParameter();
                paramquantity.ParameterName = "@quantity";
                paramquantity.Value = feeding.quantity;
                cmd.Parameters.Add(paramquantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteFeeding(int id)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteFeeding", con);
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
