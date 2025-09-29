// Program.cs
using HandsOn;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    private static readonly string connectionString = "Server=Vijit_Shetty;Database=KANINIBATCH2;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;";

    static async Task Main(string[] args)
    {
        Console.WriteLine("Application started. Fetching employee data...");

        try
        {
            List<Employee> employees = await GetEmployeesAsync();

            Console.WriteLine("\nEmployee data received. The following employees were found:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"EmpNo: {emp.EmpNo}, Name: {emp.FName} {emp.LName}, Job: {emp.Job}, Salary: {emp.Salary}");
            }
        }
        catch (DataAccessException dae)
        {
            Console.WriteLine($"\nA data access error occurred: {dae.Message}");
            if (dae.InnerException != null)
            {
                Console.WriteLine($"Root cause (Inner Exception): {dae.InnerException.Message}");
                Console.WriteLine($"Type: {dae.InnerException.GetType().Name}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn unexpected application error occurred: {ex.Message}");
        }

        Console.WriteLine("\nApplication finished.");
    }

    static async Task<List<Employee>> GetEmployeesAsync()
    {
        var employees = new List<Employee>();
        string sqlQuery = "SELECT empno, fname, lname, job, salary FROM emp1";

        try
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sqlQuery, connection))
            {
                await connection.OpenAsync();

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        employees.Add(new Employee
                        {
                            EmpNo = reader.GetString(0),
                            FName = reader.GetString(1),
                            LName = reader.GetString(2),
                            Job = reader.GetString(3),
                            Salary = reader.GetDecimal(4)
                        });
                    }
                }
            }
        }
        catch (SqlException ex)
        {
            Console.WriteLine("Caught a SqlException. Re-throwing as a DataAccessException.");
            throw new DataAccessException("Could not retrieve employee data from the database.", ex);
        }

        return employees;
    }
}