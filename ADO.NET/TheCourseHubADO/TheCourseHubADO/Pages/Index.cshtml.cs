//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.Data.SqlClient;
//using TheCourseHubADO.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System;

//namespace TheCourseHubADO.Pages
//{
//    public class IndexModel : PageModel
//    {
//        private readonly IConfiguration _configuration;
//        private readonly string _connectionString;

//        // Binds the new student form data to this property
//        [BindProperty]
//        public Student NewStudent { get; set; }

//        // Binds the search bar input to this property
//        [BindProperty(SupportsGet = true)]
//        public string SearchTerm { get; set; }

//        public List<Student> Students { get; set; } = new List<Student>();
//        public string Message { get; set; }

//        // Constructor to get the connection string from configuration
//        public IndexModel(IConfiguration configuration)
//        {
//            _configuration = configuration;
//            _connectionString = _configuration.GetConnectionString("DefaultConnection");
//        }

//        // Handles the initial GET request to display all students
//        public async Task OnGetAsync()
//        {

//            try
//            {
//                using (var connection = new SqlConnection(_connectionString))
//                {
//                    await connection.OpenAsync();
//                    var sql = "SELECT StudId, Fname, Lname, Email, EnrollmentDate, DOB, City, Country, ActiveCourseCount FROM Students";

//                    // Add search filtering if a search term is provided
//                    if (!string.IsNullOrEmpty(SearchTerm))
//                    {
//                        sql += " WHERE Fname LIKE @SearchTerm OR Lname LIKE @SearchTerm OR Email LIKE @SearchTerm";
//                    }

//                    using (var command = new SqlCommand(sql, connection))
//                    {
//                        if (!string.IsNullOrEmpty(SearchTerm))
//                        {
//                            command.Parameters.AddWithValue("@SearchTerm", "%" + SearchTerm + "%");
//                        }
//                        using (var reader = await command.ExecuteReaderAsync())
//                        {
//                            while (await reader.ReadAsync())
//                            {
//                                Students.Add(new Student
//                                {
//                                    StudId = reader.GetInt32(reader.GetOrdinal("StudId")),
//                                    Fname = reader.IsDBNull(reader.GetOrdinal("Fname")) ? null : reader.GetString(reader.GetOrdinal("Fname")),
//                                    Lname = reader.IsDBNull(reader.GetOrdinal("Lname")) ? null : reader.GetString(reader.GetOrdinal("Lname")),
//                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
//                                    EnrollmentDate = (DateTime)(reader.IsDBNull(reader.GetOrdinal("EnrollmentDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("EnrollmentDate"))),
//                                    DOB = reader.IsDBNull(reader.GetOrdinal("DOB")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DOB")),
//                                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
//                                    Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? null : reader.GetString(reader.GetOrdinal("Country")),
//                                    ActiveCourseCount = reader.IsDBNull(reader.GetOrdinal("ActiveCourseCount")) ? (int?)null : reader.GetInt32(reader.GetOrdinal("ActiveCourseCount"))
//                                });
//                            }
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Message = $"An error occurred: {ex.Message}";
//            }
//        }

//        // Handles the form submission to add a new student
//        public async Task<IActionResult> OnPostAddStudentAsync()
//        {
//            if (!ModelState.IsValid)
//            {
//                // Re-fetch students to display the page with validation errors
//                await OnGetAsync();
//                return Page();
//            }

//            try
//            {
//                using (var connection = new SqlConnection(_connectionString))
//                {
//                    await connection.OpenAsync();
//                    var sql = "INSERT INTO Students (Fname, Lname, Email, EnrollmentDate, DOB, City, Country, ActiveCourseCount) VALUES (@Fname, @Lname, @Email, @EnrollmentDate, @DOB, @City, @Country, @ActiveCourseCount)";
//                    using (var command = new SqlCommand(sql, connection))
//                    {
//                        command.Parameters.AddWithValue("@Fname", NewStudent.Fname);
//                        command.Parameters.AddWithValue("@Lname", NewStudent.Lname ?? (object)DBNull.Value);
//                        command.Parameters.AddWithValue("@Email", NewStudent.Email ?? (object)DBNull.Value);
//                        command.Parameters.AddWithValue("@EnrollmentDate", NewStudent.EnrollmentDate);
//                        command.Parameters.AddWithValue("@DOB", NewStudent.DOB ?? (object)DBNull.Value);
//                        command.Parameters.AddWithValue("@City", NewStudent.City ?? (object)DBNull.Value);
//                        command.Parameters.AddWithValue("@Country", NewStudent.Country ?? (object)DBNull.Value);
//                        command.Parameters.AddWithValue("@ActiveCourseCount", NewStudent.ActiveCourseCount ?? (object)DBNull.Value);
//                        await command.ExecuteNonQueryAsync();
//                    }
//                }
//                TempData["Message"] = "Student added successfully!";
//                return RedirectToPage();
//            }
//            catch (Exception ex)
//            {
//                Message = $"An error occurred while adding the student: {ex.Message}";
//                await OnGetAsync();
//                return Page();
//            }
//        }

//        // Handles the form submission to delete a student
//        public async Task<IActionResult> OnPostDeleteStudentAsync(int id)
//        {
//            try
//            {
//                using (var connection = new SqlConnection(_connectionString))
//                {
//                    await connection.OpenAsync();

//                    // Step 1: Delete all records from Enrollments table that reference the student.
//                    var deleteEnrollmentsSql = "DELETE FROM Enrollments WHERE StudId = @id";
//                    using (var deleteEnrollmentsCommand = new SqlCommand(deleteEnrollmentsSql, connection))
//                    {
//                        deleteEnrollmentsCommand.Parameters.AddWithValue("@id", id);
//                        await deleteEnrollmentsCommand.ExecuteNonQueryAsync();
//                    }

//                    // Step 2: Delete the student from the Students table.
//                    var deleteStudentSql = "DELETE FROM Students WHERE StudId = @id";
//                    using (var deleteStudentCommand = new SqlCommand(deleteStudentSql, connection))
//                    {
//                        deleteStudentCommand.Parameters.AddWithValue("@id", id);
//                        await deleteStudentCommand.ExecuteNonQueryAsync();
//                    }
//                }
//                TempData["Message"] = "Student deleted successfully!";
//                return RedirectToPage();
//            }
//            catch (Exception ex)
//            {
//                Message = $"An error occurred while deleting the student: {ex.Message}";
//                await OnGetAsync();
//                return Page();
//            }
//        }
//    }
//}
