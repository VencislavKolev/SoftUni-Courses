using System;
using Microsoft.Data.SqlClient;

namespace ADO.NET_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection sqlConnection = new SqlConnection("Server=.;Database=SoftUni;Integrated Security=true"))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT FirstName, Salary, LastName FROM Employees WHERE FirstName LIKE 'N%'", sqlConnection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string firstName = (string)reader["FirstName"];
                        decimal salary = (decimal)reader["Salary"];
                        string lastName = (string)reader["LastName"];

                        Console.WriteLine($"{firstName} {salary} {lastName}");
                    }
                }
                SqlCommand updateSalary = new SqlCommand(
                    "UPDATE Employees SET Salary = Salary * 1.1", sqlConnection);
                int rowsAffected = updateSalary.ExecuteNonQuery();
                Console.WriteLine(rowsAffected);

                var reader2 = sqlCommand.ExecuteReader();
                using (reader2)
                {
                    while (reader2.Read())
                    {
                        string firstName = (string)reader2["FirstName"];
                        decimal salary = (decimal)reader2["Salary"];
                        string lastName = (string)reader2["LastName"];

                        Console.WriteLine($"{firstName} {salary} {lastName}");
                    }
                }
            }
        }
    }
}
