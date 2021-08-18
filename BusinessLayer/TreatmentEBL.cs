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
     public class TreatmentEBL
    {
         public IEnumerable<Treatment> Treatments
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Treatment> treatments = new List<Treatment>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllTreatment2", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Treatment treatment = new Treatment();
                        treatment.ID = Convert.ToInt32(rdr["ID"]);
                        treatment.treatment_id = Convert.ToInt32(rdr["treatment_id"]);
                        treatment.treatment_name = rdr["treatment_name"].ToString();
                        treatment.treatment_med = rdr["treatment_med"].ToString();
                        treatment.treatment_type = rdr["treatment_type"].ToString();
                        treatment.cost = Convert.ToInt32(rdr["cost"]);

                        treatments.Add(treatment);
                    }
                }
                return treatments;
            }
        }

         public void AddTreatment(Treatment treatment)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spAddTreatment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramtreatment_id = new SqlParameter();
                paramtreatment_id.ParameterName = "@treatment_id";
                paramtreatment_id.Value = treatment.treatment_id;
                cmd.Parameters.Add(paramtreatment_id);

                SqlParameter paramtreatment_name = new SqlParameter();
                paramtreatment_name.ParameterName = "@treatment_name";
                paramtreatment_name.Value = treatment.treatment_name;
                cmd.Parameters.Add(paramtreatment_name);

                SqlParameter paramtreatment_med = new SqlParameter();
                paramtreatment_med.ParameterName = "@treatment_med";
                paramtreatment_med.Value = treatment.treatment_med;
                cmd.Parameters.Add(paramtreatment_med);

                SqlParameter paramtreatment_type = new SqlParameter();
                paramtreatment_type.ParameterName = "@treatment_type";
                paramtreatment_type.Value = treatment.treatment_type;
                cmd.Parameters.Add(paramtreatment_type);

                SqlParameter paramcost = new SqlParameter();
                paramcost.ParameterName = "@cost";
                paramcost.Value = treatment.cost;
                cmd.Parameters.Add(paramcost);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
         public void SaveTreatment(Treatment treatment)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveTreatment", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = treatment.ID;
                cmd.Parameters.Add(paramId);


                SqlParameter paramtreatment_id = new SqlParameter();
                paramtreatment_id.ParameterName = "@treatment_id";
                paramtreatment_id.Value = treatment.treatment_id;
                cmd.Parameters.Add(paramtreatment_id);

                SqlParameter paramtreatment_name = new SqlParameter();
                paramtreatment_name.ParameterName = "@treatment_name ";
                paramtreatment_name.Value = treatment.treatment_name;
                cmd.Parameters.Add(paramtreatment_name);

                SqlParameter paramtreatment_med = new SqlParameter();
                paramtreatment_med.ParameterName = "@treatment_med";
                paramtreatment_med.Value = treatment.treatment_med;
                cmd.Parameters.Add(paramtreatment_med);

                SqlParameter paramtreatment_type = new SqlParameter();
                paramtreatment_type.ParameterName = "@treatment_type";
                paramtreatment_type.Value = treatment.treatment_type;
                cmd.Parameters.Add(paramtreatment_type);

                SqlParameter paramcost = new SqlParameter();
                paramcost.ParameterName = "@cost";
                paramcost.Value = treatment.cost;
                cmd.Parameters.Add(paramcost);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
         public void DeleteTreatment(int id)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteTreatment2", con);
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
