using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ConsoleApp.Models;
using System.Data.SqlClient;

namespace WebApplication.Models
{
    public class DBManager
    {
        
        const string ConnStr = "Data Source=DESKTOP-C0IK21H;Initial Catalog=storeDB;Integrated Security=True";
        public void NewActivity(Activity activity)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnStr);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("insert into PrgData values(@ID, @NAME)", sqlConnection);
            cmd.Parameters.AddWithValue("@ID", activity.PrgId);
            cmd.Parameters.AddWithValue("@NAME", activity.PrgName);


            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public List<Activity> GetActivities()
        {
            List<Activity> Activities = new List<Activity>();

            SqlConnection sqlConnection = new SqlConnection(ConnStr);

            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM PrgData");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Activity activity = new Activity
                    {
                        PrgId = reader.GetInt32(reader.GetOrdinal("PrgId")),
                        PrgName = reader.GetString(reader.GetOrdinal("PrgName")),
                    };
                    Activities.Add(activity);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return Activities;
        }
    }
    
    
}
