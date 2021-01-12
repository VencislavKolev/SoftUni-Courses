using System;
using Microsoft.Data.SqlClient;

namespace P02.Villain_Names
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using SqlConnection sqlConnection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true;");
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(
                "SELECT v.Name AS VillainName, COUNT(mv.VillainId) AS MinionsCount " +
                "FROM Villains AS v " +
                "LEFT JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
                "GROUP BY v.Name, mv.VillainId " +
                "HAVING COUNT(mv.VillainId " +
                "ORDER BY mv.VillainId DESC", sqlConnection);
            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                string villainName = reader["VillainName"].ToString();
                string minionsCount = reader["MinionsCount"].ToString();
                Console.WriteLine($"{villainName} - {minionsCount}");
            }
        }
    }
}
