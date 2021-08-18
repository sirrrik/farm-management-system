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
    public class FoodEBL
    {
        public IEnumerable<Food> Foods
            {
                get
                {
                    string connectionString =
                    ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    List<Food> foods = new List<Food>();
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        SqlCommand cmd = new SqlCommand("spGetAllFood_items1", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlDataReader rdr = cmd.ExecuteReader();
                        while (rdr.Read())
                        {
                            Food food = new Food();
                            food.ID = Convert.ToInt32(rdr["ID"]);
                            food.food_id = Convert.ToInt32(rdr["food_id"]);
                            food.food_name = rdr["food_name"].ToString();
                            food.quantity = rdr["quantity"].ToString();
                            foods.Add(food);
                        }
                    }
                    return foods;
                }
            }

        public void AddFood(Food food)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {

                SqlCommand cmd = new SqlCommand("spAddFood_items1", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramfood_id = new SqlParameter();
                paramfood_id.ParameterName = "@food_id";
                paramfood_id.Value = food.food_id;
                cmd.Parameters.Add(paramfood_id);

                SqlParameter paramfood_name = new SqlParameter();
                paramfood_name.ParameterName = "@food_name";
                paramfood_name.Value = food.food_name;
                cmd.Parameters.Add(paramfood_name);

                SqlParameter paramquantity = new SqlParameter();
                paramquantity.ParameterName = "@quantity";
                paramquantity.Value = food.quantity;
                cmd.Parameters.Add(paramquantity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void SaveFood(Food food)
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spSaveFood_items1", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter paramId = new SqlParameter();
                    paramId.ParameterName = "@ID";
                    paramId.Value = food.ID;
                    cmd.Parameters.Add(paramId);

                    SqlParameter paramfood_id = new SqlParameter();
                    paramfood_id.ParameterName = "@food_id";
                    paramfood_id.Value = food.food_id;
                    cmd.Parameters.Add(paramfood_id);

                    SqlParameter paramfood_name = new SqlParameter();
                    paramfood_name.ParameterName = "@food_name";
                    paramfood_name.Value = food.food_name;
                    cmd.Parameters.Add(paramfood_name);

                    SqlParameter paramquantity = new SqlParameter();
                    paramquantity.ParameterName = "@quantity ";
                    paramquantity.Value = food.quantity;
                    cmd.Parameters.Add(paramquantity);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            public void DeleteFood(int id)
            {
                string connectionString =
                ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteFood_items", con);
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
