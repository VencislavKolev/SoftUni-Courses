using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;

namespace P05.ChangeTownNamesCasing
{
    class Program
    {
        private const string ConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string countryInput = Console.ReadLine();

            StringBuilder output = new StringBuilder();

            var towns = new List<string>();
            string countryId = GetCountryId(countryInput, sqlConnection);
            bool isValidCountryId = false;
            if (countryId == null)
            {
                output.AppendLine("No town names were affected.");
            }
            else
            {
                string getTownsWithCountryIdQueryText = @"SELECT [Name]
                                                        FROM Towns AS t 
                                                        WHERE t.CountryCode = @countryId";

                using SqlCommand getTownsWithCountryIdCmd = new SqlCommand(getTownsWithCountryIdQueryText, sqlConnection);
                getTownsWithCountryIdCmd.Parameters.AddWithValue("@countryId", countryId);
                using SqlDataReader reader = getTownsWithCountryIdCmd.ExecuteReader();
                if (reader.HasRows)
                {
                    isValidCountryId = true;
                    while (reader.Read())
                    {
                        string townName = reader["Name"].ToString();
                        towns.Add(townName.ToUpper());
                    }
                }
                else
                {
                    output.AppendLine("No town names were affected.");
                }
            }

            if (isValidCountryId)
            {
                SqlCommand updateToUpperCmd = UpdateTownNamesToUpper(sqlConnection, output, towns, countryId);
            }
            Console.WriteLine(output.ToString().TrimEnd());
        }

        private static SqlCommand UpdateTownNamesToUpper(SqlConnection sqlConnection, StringBuilder output, List<string> towns, string countryId)
        {
            string updateTownNamesToUpperQueryText = @"UPDATE Towns
                                                                SET Name = UPPER(Name) WHERE CountryCode = @countryId";
            SqlCommand updateToUpperCmd = new SqlCommand(updateTownNamesToUpperQueryText, sqlConnection);
            updateToUpperCmd.Parameters.AddWithValue("@countryId", countryId);
            int affectedRows = updateToUpperCmd.ExecuteNonQuery();

            output.
                AppendLine($"{affectedRows} town names were affected.")
                .AppendLine(string.Join(", ", towns));
            return updateToUpperCmd;
        }

        private static string GetCountryId(string countryName, SqlConnection sqlConnection)
        {
            string getCountryIdQueryText = @"SELECT Id FROM Countries
                                            WHERE Name = @countryName";
            using SqlCommand getCountryIdCmd = new SqlCommand(getCountryIdQueryText, sqlConnection);
            getCountryIdCmd.Parameters.AddWithValue("@countryName", countryName);

            string countryId = getCountryIdCmd.ExecuteScalar()?.ToString();
            return countryId;
        }
    }
}
