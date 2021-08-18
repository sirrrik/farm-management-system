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
     public class MedicineEBL
    {
         public IEnumerable<Medicine> Medicines
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Medicine> medicines = new List<Medicine>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllMedicine1", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Medicine medicine = new Medicine();
                        medicine.ID = Convert.ToInt32(rdr["ID"]);
                        medicine.med_id = Convert.ToInt32(rdr["med_id"]);
                        medicine.med_name = rdr["med_name"].ToString();
                        medicine.med_cost = Convert.ToInt32(rdr["med_cost"]);
                        medicine.quantity = rdr["quantity"].ToString();
                       

                        medicines.Add(medicine);
                    }
                }
                return medicines;
            }
        }

         public void AddMedicine(Medicine medicine)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spAddMedicine", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter parammed_id = new SqlParameter();
                parammed_id.ParameterName = "@med_id";
                parammed_id.Value = medicine.med_id;
                cmd.Parameters.Add(parammed_id);

                SqlParameter parammed_name = new SqlParameter();
                parammed_name.ParameterName = "@med_name";
                parammed_name.Value = medicine.med_name;
                cmd.Parameters.Add(parammed_name);

                SqlParameter parammed_cost = new SqlParameter();
                parammed_cost.ParameterName = "@med_cost";
                parammed_cost.Value = medicine.med_cost;
                cmd.Parameters.Add(parammed_cost);

                SqlParameter paramquantity = new SqlParameter();
                paramquantity.ParameterName = "@quantity";
                paramquantity.Value = medicine.quantity;
                cmd.Parameters.Add(paramquantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveMedicine(Medicine medicine)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveMedcine", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = medicine.ID;
                cmd.Parameters.Add(paramId);

                SqlParameter parammed_id = new SqlParameter();
                parammed_id.ParameterName = "@med_id";
                parammed_id.Value = medicine.med_id;
                cmd.Parameters.Add(parammed_id);

                SqlParameter parammed_name = new SqlParameter();
                parammed_name.ParameterName = "@med_name";
                parammed_name.Value = medicine.med_name;
                cmd.Parameters.Add(parammed_name);

                SqlParameter parammed_cost = new SqlParameter();
                parammed_cost.ParameterName = "@med_cost";
                parammed_cost.Value = medicine.med_cost;
                cmd.Parameters.Add(parammed_cost);

                SqlParameter paramquantity = new SqlParameter();
                paramquantity.ParameterName = "@quantity";
                paramquantity.Value = medicine.quantity;
                cmd.Parameters.Add(paramquantity);

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
                SqlCommand cmd = new SqlCommand("spDeleteMedicine", con);
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
