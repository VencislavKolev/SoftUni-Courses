using System;
using System.Data;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P09.IncreaseAgeStoredProcedure
{
    class Program
    {
        private const string ConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string minionId = Console.ReadLine();

            ExecuteStoredProcedure(sqlConnection, minionId);

            string getNameAgeQueryText = @"SELECT Name,Age
                                            FROM MinionsNA
                                            WHERE Id = @minionId";
            SqlCommand getNameAgeCmd = new SqlCommand(getNameAgeQueryText, sqlConnection);
            getNameAgeCmd.Parameters.AddWithValue("@minionId", minionId);

            StringBuilder sb = new StringBuilder();

            using SqlDataReader reader = getNameAgeCmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["Name"]?.ToString();
                string age = reader["Age"]?.ToString();
                sb.AppendLine($"{name} - {age} years old");
            }

            Console.WriteLine(sb.ToString().TrimEnd());
        }

        private static void ExecuteStoredProcedure(SqlConnection sqlConnection, string minionId)
        {
            SqlCommand execProcCmd = new SqlCommand("usp_GetOlder", sqlConnection);
            execProcCmd.CommandType = CommandType.StoredProcedure;
            execProcCmd.Parameters.AddWithValue("@minionId", minionId);
            execProcCmd.ExecuteNonQuery();
        }
    }
}
