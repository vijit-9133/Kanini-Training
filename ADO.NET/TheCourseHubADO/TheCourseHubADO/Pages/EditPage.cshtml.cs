using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using TheCourseHubADO.Models;

namespace TheCourseHubADO.Pages
{
    public class EditPageModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public EditPageModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        [BindProperty]
        public Student Student { get; set; }

        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var sql = "SELECT StudId, Fname, Lname, Email, EnrollmentDate, DOB, City, Country, ActiveCourseCount FROM Students WHERE StudId = @id";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                Student = new Student
                                {
                                    StudId = reader.GetInt32(reader.GetOrdinal("StudId")),
                                    Fname = reader.GetString(reader.GetOrdinal("Fname")),
                                    Lname = reader.IsDBNull(reader.GetOrdinal("Lname")) ? null : reader.GetString(reader.GetOrdinal("Lname")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate")),
                                    DOB = reader.IsDBNull(reader.GetOrdinal("DOB")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DOB")),
                                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
                                    Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? null : reader.GetString(reader.GetOrdinal("Country")),
                                    ActiveCourseCount = reader.IsDBNull(reader.GetOrdinal("ActiveCourseCount")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ActiveCourseCount"))
                                };
                            }
                            else
                            {
                                return NotFound();
                            }
                        }
                    }
                }
                return Page();
            }
            catch (Exception ex)
            {
                Message = $"Error loading student data: {ex.Message}";
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var sql = "UPDATE Students SET Fname = @Fname, Lname = @Lname, Email = @Email, EnrollmentDate = @EnrollmentDate, DOB = @DOB, City = @City, Country = @Country, ActiveCourseCount = @ActiveCourseCount WHERE StudId = @StudId";
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@Fname", Student.Fname);
                        command.Parameters.AddWithValue("@Lname", Student.Lname ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Email", Student.Email);
                        command.Parameters.AddWithValue("@EnrollmentDate", Student.EnrollmentDate);
                        command.Parameters.AddWithValue("@DOB", Student.DOB ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@City", Student.City ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Country", Student.Country ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ActiveCourseCount", Student.ActiveCourseCount ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@StudId", Student.StudId);
                        await command.ExecuteNonQueryAsync();
                    }
                }
                TempData["Message"] = "Student updated successfully!";
                return RedirectToPage("/Home");
            }
            catch (Exception ex)
            {
                Message = $"Error updating student: {ex.Message}";
                return Page();
            }
        }
    }
}
