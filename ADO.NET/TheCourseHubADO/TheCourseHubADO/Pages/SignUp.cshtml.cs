using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using TheCourseHubADO.Models;
using Microsoft.Data.SqlClient;


namespace TheCourseHubADO.Pages
{
    public class SignUpModel : PageModel
    {
        private string _connstring = "";
        [BindProperty]
        public User NewUser { get; set; }

        public string Message { get; set; }

        public SignUpModel(IConfiguration config)
        {
            _connstring = config.GetConnectionString("DefaultConnection");
        }
        
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Check if the model is valid based on the data annotations in User.cs
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                using (var connection = new SqlConnection(_connstring))
                {
                    connection.Open();

                    // Check if a user with the same username or email already exists.
                    string checkSql = "SELECT COUNT(*) FROM Users WHERE Username = @Username OR Email = @Email";
                    using (var checkCommand = new SqlCommand(checkSql, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Username", NewUser.Username);
                        checkCommand.Parameters.AddWithValue("@Email", NewUser.Email);

                        int existingUsers = (int)checkCommand.ExecuteScalar();
                        if (existingUsers > 0)
                        {
                            Message = "A user with this username or email already exists.";
                            return Page();
                        }
                    }

                    // Insert the new user into the database.
                    string insertSql = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
                    using (var insertCommand = new SqlCommand(insertSql, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Username", NewUser.Username);
                        insertCommand.Parameters.AddWithValue("@Email", NewUser.Email);
                        // NOTE: In a real app, hash the password here before saving!
                        insertCommand.Parameters.AddWithValue("@Password", NewUser.Password);

                        insertCommand.ExecuteNonQuery();
                    }
                }

                // Redirect to the sign-in page on successful registration.
                return RedirectToPage("/SignIn");
            }
            catch (Exception ex)
            {
                // Log the exception (e.g., using a logging framework) and display a user-friendly message.
                Message = $"An error occurred during sign up: {ex.Message}";
                return Page();
            }
        }
    }
}

