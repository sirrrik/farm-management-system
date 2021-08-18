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
    public class SalesEBL
    {
        public IEnumerable<Sales> Saless
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Sales> saless = new List<Sales>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllsale4", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Sales sales = new Sales();
                        sales.ID = Convert.ToInt32(rdr["ID"]);
                        sales.CowId = Convert.ToInt32(rdr["CowId"]);
                        sales.Date = Convert.ToDateTime(rdr["Date"]);
                        sales.Amount = rdr["Amount"].ToString();
                        saless.Add(sales);
                    }
                }
                return saless;
            }
        }

        public void AddSales(Sales sales)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spAddsale4", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramCowId = new SqlParameter();
                paramCowId.ParameterName = "@CowId";
                paramCowId.Value = sales.CowId;
                cmd.Parameters.Add(paramCowId);

                SqlParameter paramDate = new SqlParameter();
                paramDate.ParameterName = "@Date";
                paramDate.Value = sales.Date;
                cmd.Parameters.Add(paramDate);

                SqlParameter paramAmount = new SqlParameter();
                paramAmount.ParameterName = "@Amount";
                paramAmount.Value = sales.Amount;
                cmd.Parameters.Add(paramAmount); 
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveSales(Sales sales)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSavesale4", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = sales.ID;
                cmd.Parameters.Add(paramId);


                SqlParameter paramCowId = new SqlParameter();
                paramCowId.ParameterName = "@CowId";
                paramCowId.Value = sales.CowId;
                cmd.Parameters.Add(paramCowId);

                SqlParameter paramDate = new SqlParameter();
                paramDate.ParameterName = "@Date";
                paramDate.Value = sales.Date;
                cmd.Parameters.Add(paramDate);

                SqlParameter paramAmount = new SqlParameter();
                paramAmount.ParameterName = "@Amount";
                paramAmount.Value = sales.Amount;
                cmd.Parameters.Add(paramAmount); 
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteSales(int id)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletesale4", con);
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
