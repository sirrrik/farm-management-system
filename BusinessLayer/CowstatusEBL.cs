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
   public class CowstatusEBL
   {
       public IEnumerable<Cowstatusemp> Cowstatusemps
       {
           get
           {
               string connectionString =
               ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
               List<Cowstatusemp> cowstatusemps = new List<Cowstatusemp>();
               using (SqlConnection con = new SqlConnection(connectionString))
               {
                   SqlCommand cmd = new SqlCommand("spGetAllCowstatuemps", con);
                   cmd.CommandType = CommandType.StoredProcedure;
                   con.Open();
                   SqlDataReader rdr = cmd.ExecuteReader();
                   while (rdr.Read())
                   {
                       Cowstatusemp cowstatusemp = new Cowstatusemp();
                       cowstatusemp.ID = Convert.ToInt32(rdr["ID"]);
                       cowstatusemp.CowID = Convert.ToInt32(rdr["CowId"]);
                       cowstatusemp.Number_of_Calves = rdr["Number_of_Calves"].ToString();
                       cowstatusemp.Producing_Milk = rdr["Producing_Milk"].ToString();
                       cowstatusemp.Comments = rdr["Comments"].ToString();
                       
                       cowstatusemps.Add(cowstatusemp);
                   }
               }
               return cowstatusemps;
           }
       }

       public void AddCowstatusemp(Cowstatusemp cowstatusemp)
       {
           string connectionString =
           ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
           using (SqlConnection con = new SqlConnection(connectionString))
           {

               SqlCommand cmd = new SqlCommand("spAddCowstatueemp1", con);
               cmd.CommandType = CommandType.StoredProcedure;

               SqlParameter paramId = new SqlParameter();
               paramId.ParameterName = "@CowId";
               paramId.Value = cowstatusemp.CowID;
               cmd.Parameters.Add(paramId);

               SqlParameter paramNumber_of_Calves = new SqlParameter();
               paramNumber_of_Calves.ParameterName= "@Number_of_Calves";
               paramNumber_of_Calves.Value = cowstatusemp.Number_of_Calves;
               cmd.Parameters.Add(paramNumber_of_Calves);

               SqlParameter paramProducing_Milk = new SqlParameter();
               paramProducing_Milk.ParameterName = "@Producing_Milk";
               paramProducing_Milk.Value = cowstatusemp.Producing_Milk;
               cmd.Parameters.Add(paramProducing_Milk);

               SqlParameter paramComments = new SqlParameter();
               paramComments.ParameterName = "@Comments";
               paramComments.Value = cowstatusemp.Comments;
               cmd.Parameters.Add(paramComments);
               con.Open();
               cmd.ExecuteNonQuery();
           }
       }
       public void SaveCowstatusemp(Cowstatusemp cowstatusemp)
       {
           string connectionString =
           ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
           using (SqlConnection con = new SqlConnection(connectionString))
           {
               SqlCommand cmd = new SqlCommand("spSaveCowstatussemp", con);
               cmd.CommandType = CommandType.StoredProcedure;

               SqlParameter paramId = new SqlParameter();
               paramId.ParameterName = "@ID";
               paramId.Value = cowstatusemp.ID;
               cmd.Parameters.Add(paramId);

               SqlParameter paramCowId = new SqlParameter();
               paramCowId.ParameterName = "@CowId";
               paramCowId.Value = cowstatusemp.CowID;
               cmd.Parameters.Add(paramCowId);


               SqlParameter paramNumber_of_Calves = new SqlParameter();
               paramNumber_of_Calves.ParameterName = "@Number_of_Calves";
               paramNumber_of_Calves.Value = cowstatusemp.Number_of_Calves;
               cmd.Parameters.Add(paramNumber_of_Calves);
               SqlParameter paramProducing_Milk = new SqlParameter();
               paramProducing_Milk.ParameterName = "@Producing_Milk";
               paramProducing_Milk.Value = cowstatusemp.Producing_Milk;
               cmd.Parameters.Add(paramProducing_Milk);
               SqlParameter paramComments = new SqlParameter();
               paramComments.ParameterName = "@Comments";
               paramComments.Value = cowstatusemp.Comments;
               cmd.Parameters.Add(paramComments);
              
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
               SqlCommand cmd = new SqlCommand("spDeleteCowstatussemp", con);
               cmd.CommandType = CommandType.StoredProcedure;
               SqlParameter paramId = new SqlParameter();
               paramId.ParameterName = "@Id";
               paramId.Value = id;
               cmd.Parameters.Add(paramId);
               con.Open();
               cmd.ExecuteNonQuery();
           }
       }



   }
}
        

        

