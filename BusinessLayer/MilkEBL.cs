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
     public class MilkEBL
    {
        public IEnumerable<Milk> Milks
        {
            get
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Milk> milks = new List<Milk>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllMilk8", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Milk milk = new Milk();
                        milk.ID = Convert.ToInt32(rdr["ID"]);
                        milk.CowId = Convert.ToInt32(rdr["CowId"]);
                        milk.Date = Convert.ToDateTime(rdr["Date"]);
                        milk.Morning = Convert.ToInt32(rdr["Morning"]);
                        milk.Evening = Convert.ToInt32(rdr["Evening"]);
                        milk.Total = Convert.ToInt32(rdr["Total"]);
                        milk.Average = Convert.ToInt32(rdr["Average"]);

                        milks.Add(milk);
                    }
                }
                return milks;
            }
        }

        public void AddMilk(Milk milk)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spAddMilk8", con);
                cmd.CommandType = CommandType.StoredProcedure;

               
                SqlParameter paramCowId = new SqlParameter();
                paramCowId.ParameterName = "@CowId";
                paramCowId.Value = milk.CowId;
                cmd.Parameters.Add(paramCowId);

                SqlParameter paramDate = new SqlParameter();
                paramDate.ParameterName = "Date";
                paramDate.Value = milk.Date;
                cmd.Parameters.Add(paramDate);

                SqlParameter paramMorning = new SqlParameter();
                paramMorning.ParameterName = "@Morning";
                paramMorning.Value = milk.Morning;
                cmd.Parameters.Add(paramMorning);

                SqlParameter paramEvening = new SqlParameter();
                paramEvening.ParameterName = "@Evening";
                paramEvening.Value = milk.Evening;
                cmd.Parameters.Add(paramEvening);

                SqlParameter paramTotal = new SqlParameter();
                paramTotal.ParameterName = "@Total";
                paramTotal.Value = milk.Total;
                cmd.Parameters.Add(paramTotal);

                SqlParameter paramAverage = new SqlParameter();
                paramAverage.ParameterName = "@Average";
                paramAverage.Value = milk.Average;
                cmd.Parameters.Add(paramAverage);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveCowstatusemp(Milk milk)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveMilk8", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@ID";
                paramId.Value = milk.ID;
                cmd.Parameters.Add(paramId);

                SqlParameter paramCowId = new SqlParameter();
                paramCowId.ParameterName = "@CowId";
                paramCowId.Value = milk.CowId;
                cmd.Parameters.Add(paramCowId);

                SqlParameter paramDate = new SqlParameter();
                paramDate.ParameterName = "Date";
                paramDate.Value = milk.Date;
                cmd.Parameters.Add(paramDate);

                SqlParameter paramMorning = new SqlParameter();
                paramMorning.ParameterName = "@Morning";
                paramMorning.Value = milk.Morning;
                cmd.Parameters.Add(paramMorning);

                SqlParameter paramEvening = new SqlParameter();
                paramEvening.ParameterName = "@Evening";
                paramEvening.Value = milk.Evening;
                cmd.Parameters.Add(paramEvening);

                SqlParameter paramTotal = new SqlParameter();
                paramTotal.ParameterName = "@Total";
                paramTotal.Value = milk.Total;
                cmd.Parameters.Add(paramTotal);

                SqlParameter paramAverage = new SqlParameter();
                paramAverage.ParameterName = "@Average";
                paramAverage.Value = milk.Average;
                cmd.Parameters.Add(paramAverage);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteCowstatusemp(int id)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteMilk8", con);
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
