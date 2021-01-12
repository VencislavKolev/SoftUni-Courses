using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P07.PrintAllMinionNames
{
    class Program
    {
        private const string ConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            StringBuilder result = new StringBuilder();
            var minionNames = GetMinions(sqlConnection);
            for (int i = 0; i < minionNames.Count / 2; i++)
            {
                result.AppendLine(minionNames[i]);
                result.AppendLine(minionNames[minionNames.Count - 1 - i]);
            }
            if (minionNames.Count % 2 != 0)
            {
                int middleIndex = minionNames.Count / 2;
                result.AppendLine(minionNames[middleIndex]);
            }
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static List<string> GetMinions(SqlConnection sqlConnection)
        {
            List<string> minions = new List<string>();

            string getMinionNamesQueryText = @"SELECT Name FROM Minions";
            SqlCommand getMinionsCmd = new SqlCommand(getMinionNamesQueryText, sqlConnection);
            using SqlDataReader reader = getMinionsCmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["Name"]?.ToString();
                minions.Add(name);
            }
            return minions;
        }
    }
}
