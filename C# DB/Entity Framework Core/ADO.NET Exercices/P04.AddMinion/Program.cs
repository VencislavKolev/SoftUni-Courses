using System;
using System.Text;
using Microsoft.Data.SqlClient;

namespace P04.AddMinion
{
    class Program
    {
        private const string ConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true;";
        static void Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();

            string[] minionInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string[] minionInfo = minionInput[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);


            string[] villainInput = Console.ReadLine().Split(": ", StringSplitOptions.RemoveEmptyEntries);
            string[] villainInfo = villainInput[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string result = AddMinionToDatabase(sqlConnection, minionInfo, villainInfo);

            Console.WriteLine(result);
        }

        private static string AddMinionToDatabase(SqlConnection sqlConnection, string[] minionInfo, string[] villainInfo)
        {
            StringBuilder output = new StringBuilder();

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string minionTown = minionInfo[2];
            //string countryCode = "1";

            string villainName = villainInfo[0];

            string townId = EnsureTownIdExists(sqlConnection, minionTown, output);
            string villainId = EnsureVillainIdExists(sqlConnection, villainName, output);

            InsertMinion(minionName, minionAge, townId, sqlConnection);
            string minionId = GetMinionId(sqlConnection, minionName);
            
            AddMinionToVillain(minionId, villainId, minionName, villainName, sqlConnection, output);

            return output.ToString().TrimEnd();
        }

        private static void InsertMinion(string minionName, int minionAge, string townId, SqlConnection sqlConnection)
        {
            string insertMinionQueryText = @"INSERT INTO Minions(Name,Age,TownId)
                                             VALUES(@name, @age, @townId)";
            SqlCommand insertMinionCmd = new SqlCommand(insertMinionQueryText, sqlConnection);
            insertMinionCmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@name",minionName),
                new SqlParameter("@age",minionAge),
                new SqlParameter("@townId",townId)
            });
            insertMinionCmd.ExecuteNonQuery();
        }

        private static void AddMinionToVillain(string minionId, string villainId, string minionName, string villainName, SqlConnection sqlConnection, StringBuilder output)
        {
            string insertIntoMinionsVillainsQueryText = @"INSERT INTO MinionsVillains
                                                        VALUES (@minionId,@villainId)";
            using SqlCommand insertCmd = new SqlCommand(insertIntoMinionsVillainsQueryText, sqlConnection);
            insertCmd.Parameters.AddRange(new[]
            {
                new SqlParameter("@minionId",minionId),
                new SqlParameter("@villainId",villainId)
            });
            insertCmd.ExecuteNonQuery();
            output.AppendLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static string GetMinionId(SqlConnection sqlConnection, string minionName)
        {
            string getMinionIdQueryText = @"SELECT [Id] FROM Minions 
                                            WHERE [Name] = @minionName";

            SqlCommand getMinionIdCmd = new SqlCommand(getMinionIdQueryText, sqlConnection);
            getMinionIdCmd.Parameters.AddWithValue("@minionName", minionName);

            string minionId = getMinionIdCmd.ExecuteScalar().ToString();
            return minionId;
        }


        private static string EnsureVillainIdExists(SqlConnection sqlConnection, string villainName, StringBuilder output)
        {
            string getVillainIdQueryText = @"SELECT [Id] FROM Villains
                                            WHERE [Name] = @villainName";

            using SqlCommand getVillainIdCmd = new SqlCommand(getVillainIdQueryText, sqlConnection);
            getVillainIdCmd.Parameters.AddWithValue("villainName", villainName);

            string villainId = getVillainIdCmd.ExecuteScalar()?.ToString();
            if (villainId == null)
            {
                string evilFactorId = GetEvilFactorId(sqlConnection);

                string insertVillainQueryText = @"INSERT INTO Villains
                                      VALUES (@villainName, @evilFactorId)";

                using SqlCommand insertVillainCmd = new SqlCommand(insertVillainQueryText, sqlConnection);
                //insertVillainCmd.Parameters.AddWithValue("villainName", villainName);
                insertVillainCmd.Parameters.AddRange(new[]
                {
                    new SqlParameter("@villainName", villainName),
                    new SqlParameter("@evilFactorId",evilFactorId)
                });

                insertVillainCmd.ExecuteNonQuery();

                villainId = getVillainIdCmd.ExecuteScalar().ToString();
                output.AppendLine($"Villain {villainName} was added to the database.");
            }
            return villainId;
        }

        private static string GetEvilFactorId(SqlConnection sqlConnection)
        {
            string getEvilFactorIdQueryText = @"SELECT [Id] 
                                                FROM EvilnessFactors
                                                WHERE [Name] = 'Evil'";
            SqlCommand getEvilFactorCmd = new SqlCommand(getEvilFactorIdQueryText, sqlConnection);

            string evilFactorId = getEvilFactorCmd.ExecuteScalar().ToString();
            return evilFactorId;
        }

        private static string EnsureTownIdExists(SqlConnection sqlConnection, string minionTown, StringBuilder output)
        {
            string getTownIdQueryText = @"SELECT [Id] FROM Towns
                                            WHERE [Name] = @townName";

            using SqlCommand getTownIdCmd = new SqlCommand(getTownIdQueryText, sqlConnection);
            getTownIdCmd.Parameters.AddWithValue("@townName", minionTown);

            string townId = getTownIdCmd.ExecuteScalar()?.ToString();

            if (townId == null)
            {
                string insertTownQueryText = @"INSERT INTO Towns
                                               VALUES (@townName, 1)";
                using SqlCommand insertTownCmd = new SqlCommand(insertTownQueryText, sqlConnection);
                insertTownCmd.Parameters.AddWithValue("@townName", minionTown);

                insertTownCmd.ExecuteNonQuery();

                townId = getTownIdCmd.ExecuteScalar().ToString();

                output.AppendLine($"Town {minionTown} was added to the database.");
            }
            return townId;
        }
    }
}