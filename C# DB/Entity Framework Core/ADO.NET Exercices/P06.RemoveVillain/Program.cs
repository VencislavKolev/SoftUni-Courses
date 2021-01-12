using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P06.RemoveVillain
{
    class Program
    {
        private const string ConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string villainId = Console.ReadLine();

            string result = RemoveVillainById(sqlConnection, villainId);
            Console.WriteLine(result);

        }

        private static string RemoveVillainById(SqlConnection sqlConnection, string villainId)
        {
            StringBuilder sb = new StringBuilder();
            using SqlTransaction transaction = sqlConnection.BeginTransaction();

            string getVillainNameQueryText = @"SELECT Name 
                                               FROM Villains
                                               WHERE Id = @villainId";
            SqlCommand getVillainName = new SqlCommand(getVillainNameQueryText, sqlConnection);
            getVillainName.Parameters.AddWithValue("@villainId", villainId);
            getVillainName.Transaction = transaction;

            string villainName = getVillainName.ExecuteScalar()?.ToString();
            if (villainName == null)
            {
                sb.AppendLine("No such villain was found.");
            }
            else
            {
                try
                {
                    string deleteFromMinionsVillainsQueryText = @"
                                           DELETE FROM MinionsVillains
                                           WHERE VillainId = @villainId";
                    SqlCommand releaseMinions = new SqlCommand(deleteFromMinionsVillainsQueryText, sqlConnection);
                    releaseMinions.Parameters.AddWithValue("@villainId", villainId);
                    releaseMinions.Transaction = transaction;

                    int affectedRows = releaseMinions.ExecuteNonQuery();

                    string deleteFromVillainsQueryText = @"
                                                DELETE FROM Villains
                                                WHERE Id = @villainId";
                    SqlCommand deleteFromVillainsCmd = new SqlCommand(deleteFromVillainsQueryText, sqlConnection);
                    deleteFromVillainsCmd.Parameters.AddWithValue("@villainId", villainId);
                    deleteFromVillainsCmd.Transaction = transaction;


                    transaction.Commit();

                    sb.AppendLine($"{villainName} was deleted.")
                        .AppendLine($"{affectedRows} minions were released.");
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception rollBackEx)
                    {
                        sb.AppendLine(rollBackEx.Message);
                    }
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
