using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient;
using TheCourseHubADO.Models;

namespace TheCourseHubADO.Pages
{
    public class SignInModel : PageModel
    {
        private string _connstring = "";
        [BindProperty]
        public InputModel Input { get; set; }

        public string Message { get; set; }
        public SignInModel(IConfiguration config)
        {
            _connstring = config.GetConnectionString("DefaultConnection");
        }
        
        public class InputModel
        {
            [Required(ErrorMessage = "Username is required.")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                using (var connection = new SqlConnection(_connstring))
                {
                    connection.Open();

                    string sql = "SELECT Password FROM Users WHERE Username = @Username";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Username", Input.Username);
                        object result = command.ExecuteScalar();

                        string storedPassword = result != null ? result.ToString() : null;

                        if (storedPassword != null && storedPassword == Input.Password)
                        {
                            // In a real app, you would set a session or cookie here to keep the user authenticated.
                            //TempData["Message"] = "Sign In Successful!";                            // Redirect to a dashboard or home page.
                            return RedirectToPage("/Home");
                        }
                        else
                        {
                            Message = "Invalid username or password.";
                            return Page();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Message = $"An error occurred during sign in: {ex.Message}";
                return Page();
            }

        }
    }
}

