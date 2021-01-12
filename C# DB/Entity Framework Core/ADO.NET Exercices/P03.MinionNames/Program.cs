using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P03.MinionNames
{
    class Program
    {
        static void Main(string[] args)
        {

            using SqlConnection sqlConnection = new SqlConnection("Server=.;Database=MinionsDB;Integrated Security=true;");
            sqlConnection.Open();

            int villainId = int.Parse(Console.ReadLine());

            string result = GetMinionInfoForVillainId(sqlConnection, villainId);
            Console.WriteLine(result);

        }

        private static string GetMinionInfoForVillainId(SqlConnection sqlConnection, int villainId)
        {
            StringBuilder sb = new StringBuilder();

            string getVillainNameByIdQuery = "SELECT [Name] " +
                "FROM Villains " +
                "WHERE Villains.Id = @Id";

            SqlCommand sqlCommand = new SqlCommand(getVillainNameByIdQuery, sqlConnection);

            sqlCommand.Parameters.AddWithValue("@Id", villainId);

            string villainName = sqlCommand.ExecuteScalar()?.ToString();
            if (villainName != null)
            {
                sb.AppendLine($"Villain: {villainName}");

                string getMinionsForVillain = "SELECT m.[Name], m.Age " +
                    "FROM MinionsVillains AS mv " +
                    "JOIN Minions AS m ON mv.MinionId = m.Id " +
                    "WHERE mv.VillainId = @Id " +
                    "ORDER BY m.Name ASC";

                SqlCommand getMinionsCmd = new SqlCommand(getMinionsForVillain, sqlConnection);
                getMinionsCmd.Parameters.AddWithValue("@Id", villainId);

                using SqlDataReader reader = getMinionsCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    int row = 1;
                    while (reader.Read())
                    {
                        string minionName = reader["Name"]?.ToString();
                        string minionAge = reader["Age"]?.ToString();
                        sb.AppendLine($"{row++}. {minionName} {minionAge}");
                    }
                }
                else
                {
                    sb.AppendLine("(no minions)");
                }
            }
            else
            {
                sb.AppendLine($"No villain with ID {villainId} exists in the database.");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
