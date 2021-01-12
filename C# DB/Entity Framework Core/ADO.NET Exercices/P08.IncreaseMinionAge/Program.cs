using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P08.IncreaseMinionAge
{
    class Program
    {
        private const string ConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string[] minionIds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var minionId in minionIds)
            {
                IncrementAge(sqlConnection, minionId);

                string minionName = GetMinionName(sqlConnection,minionId);

                MakeNameTitleCase(sqlConnection, minionName, minionId);
            }

            StringBuilder output = new StringBuilder();

            string getNameAgeQueryText = @"SELECT Name,Age
                                           FROM MinionsNA";
            using SqlCommand getNameAgeCmd = new SqlCommand(getNameAgeQueryText, sqlConnection);
            using SqlDataReader reader = getNameAgeCmd.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["Name"].ToString();
                string age = reader["Age"].ToString();
                output.AppendLine($"{name} {age}");
            }
            Console.WriteLine(output.ToString().TrimEnd());
        }

        private static void MakeNameTitleCase(SqlConnection sqlConnection, string minionName, string minionId)
        {
            string updateNameQueryText = null;
            if (minionName.Contains(" "))
            {
                //   int whiteSpaceIndex = minionName.IndexOf(" ") + 1;
                updateNameQueryText = @"
                             UPDATE MinionsNA
                             SET Name = 
                                UPPER(LEFT(Name,1)) + 
                                LOWER(SUBSTRING(Name,2,CHARINDEX(' ',[Name]) -1)) +
                                UPPER(LEFT(SUBSTRING(Name,CHARINDEX(' ', [Name])+1,LEN(Name)),1)) +
                                LOWER(SUBSTRING(Name,CHARINDEX(' ', [Name])+2,LEN(Name)))
                              WHERE Id=@Id";
            }
            else
            {
                updateNameQueryText = @"UPDATE MinionsNA
                                                SET Name=UPPER(LEFT(Name,1))+LOWER(SUBSTRING(Name,2,LEN(Name)))
                                                WHERE Id = @Id"; ;
            }

            SqlCommand updateNameCmd = new SqlCommand(updateNameQueryText, sqlConnection);
            updateNameCmd.Parameters.AddWithValue("@Id", minionId);
            updateNameCmd.ExecuteNonQuery();
        }

        private static string GetMinionName(SqlConnection sqlConnection,string minionId)
        {
            string getNameQueryText = @"SELECT Name
                                            FROM MinionsNA
                                            WHERE Id = @Id";
            SqlCommand getNameCmd = new SqlCommand(getNameQueryText, sqlConnection);
            getNameCmd.Parameters.AddWithValue("@Id", minionId);
            string minionName = getNameCmd.ExecuteScalar().ToString();
            return minionName;
        }

        private static void IncrementAge(SqlConnection sqlConnection, string minionId)
        {
            string incrementAgeQueryText = @"UPDATE MinionsNA
                                                SET Age = Age + 1
                                                WHERE Id = @Id";
            SqlCommand incrementAgeCmd = new SqlCommand(incrementAgeQueryText, sqlConnection);
            incrementAgeCmd.Parameters.AddWithValue("@Id", minionId);

            incrementAgeCmd.ExecuteNonQuery();
        }
    }
}
