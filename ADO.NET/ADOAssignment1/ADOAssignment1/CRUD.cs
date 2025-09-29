using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ADOAssignment1
{
    internal class CRUD : Program
    {
        private const string ConnectionString = "server=Vijit_Shetty;database=KANINIBATCH2;integrated security=true;trustservercertificate=true;";
        public static void CreateTable()
        {
            string createTableQuery = "CREATE TABLE Cars(carId INT PRIMARY KEY, carname VARCHAR(50), price DECIMAL(10,2))";
            using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand(createTableQuery, sqlcon))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Table 'Cars' created successfully.");
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2714)
                    {
                        Console.WriteLine("The table 'Cars' already exists.");
                    }
                    else
                    {
                        Console.WriteLine($"Database error: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred during table creation: {ex.Message}");
                }
            }
        }

        public static void AddCar()
        {
            try
            {
                Console.WriteLine("\nEnter car details:");
                Console.Write("Car ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Car Name: ");
                string carName = Console.ReadLine();
                Console.Write("Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                string insertQuery = "INSERT INTO Cars (carId, carname, price) VALUES (@carId, @carname, @price)";

                using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@carId", id);
                        cmd.Parameters.AddWithValue("@carname", carName);
                        cmd.Parameters.AddWithValue("@price", price);

                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Car record inserted successfully.");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format. Please ensure ID and price are numbers.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) 
                {
                    Console.WriteLine("A car with this ID already exists. Please use a unique ID.");
                }
                else
                {
                    Console.WriteLine($"Database error: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding a car: {ex.Message}");
            }
        }
        public static void DisplayCars()
        {
            string selectQuery = "SELECT carId, carname, price FROM Cars";

            using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand(selectQuery, sqlcon))
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (!sdr.HasRows)
                            {
                                Console.WriteLine("No cars found in the table.");
                                return;
                            }

                            Console.WriteLine("\n--- Car List ---");
                            while (sdr.Read())
                            {
                                Console.WriteLine($"ID: {sdr["carId"]}, Name: {sdr["carname"]}, Price: {sdr["price"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while displaying cars: {ex.Message}");
                }
            }
        }
        public static void UpdateCar()
        {
            try
            {
                Console.Write("Enter the ID of the car to update: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter the new price: ");
                decimal newPrice = decimal.Parse(Console.ReadLine());

                string updateQuery = "UPDATE Cars SET price = @price WHERE carId = @id";

                using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand(updateQuery, sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@price", newPrice);
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Car updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No car found with that ID.");
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please ensure ID and price are numbers.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating a car: {ex.Message}");
            }
        }
        public static void DeleteCar()
        {
            try
            {
                Console.Write("Enter the ID of the car to delete: ");
                int id = int.Parse(Console.ReadLine());

                string deleteQuery = "DELETE FROM Cars WHERE carId = @id";

                using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, sqlcon))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Car deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("No car found with that ID.");
                        }
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting a car: {ex.Message}");
            }
        }
        public static void SearchCar()
        { 
            Console.WriteLine("Search by: 1. Car ID  2. Car Name");
            Console.Write("Enter choice (1 or 2): ");
            string choice = Console.ReadLine();
            string searchQuery = "";
            SqlParameter param = null;
            if (choice == "1")
            {
                Console.Write("Enter Car ID: ");
                if (!int.TryParse(Console.ReadLine(), out int carId))
                {
                    Console.WriteLine("Invalid Car ID.");
                    return;
                }
                searchQuery = "SELECT carId, carname, price FROM Cars WHERE carId = @value";
                param = new SqlParameter("@value", carId);
            }
            else if (choice == "2")
            {
                Console.Write("Enter Car Name: ");
                string carName = Console.ReadLine();
                searchQuery = "SELECT carId, carname, price FROM Cars WHERE carname LIKE @value";
                param = new SqlParameter("@value", "%" + carName + "%");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
                return;
            }

            using (SqlConnection sqlcon = new SqlConnection(ConnectionString))
            {
                try
                {
                    sqlcon.Open();
                    using (SqlCommand cmd = new SqlCommand(searchQuery, sqlcon))
                    {
                        cmd.Parameters.Add(param);
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if (!sdr.HasRows)
                            {
                                Console.WriteLine("No matching car found.");
                                return;
                            }
                            Console.WriteLine("\n--- Search Results ---");
                            while (sdr.Read())
                            {
                                Console.WriteLine($"ID: {sdr["carId"]}, Name: {sdr["carname"]}, Price: {sdr["price"]}");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while searching for a car: {ex.Message}");
                }
            }
        }

    }

}
