using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using AssignmentRazor.Model;

namespace AssignmentRazor.Pages
{
    public class CarsModel : PageModel
    {
        private const string connstring = "server=Vijit_Shetty;database=KANINIBATCH2;integrated security=true;trustservercertificate=true;";
        public List<Cars>? Cars = new List<Cars>();
        [BindProperty]
        public int Carid { get; set; }
        [BindProperty]
        public string Carname { get; set; }
        [BindProperty]
        public decimal price { get; set; }
        [BindProperty]
        public string? Message { get; set; }
        public void Load()
        {
            using (SqlConnection sqlcon = new SqlConnection(connstring))
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("GetAllDetails", sqlcon))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlDataReader sd = cmd.ExecuteReader();
                    while (sd.Read())
                    {

                        Cars cr = new Cars();
                        cr.Carid = int.Parse(sd[0].ToString());
                        cr.Carname = sd[1].ToString();

                        cr.Price = Decimal.Parse(sd[2].ToString());

                        Cars.Add(cr);
                    }
                }
            }
        }
        public void OnGet()
        {
            Load();
        }
        public void OnPost()
        {
            Insert();
            Load();
        }
        public void Insert()
        {
            using (SqlConnection sqlcon = new SqlConnection(connstring))
            {
                sqlcon.Open();
                using (SqlCommand cmd = new SqlCommand("AddCar", sqlcon))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CarId", Carid);
                    cmd.Parameters.AddWithValue("@CarName", Carname);
                    cmd.Parameters.AddWithValue("@CarPrice", price);
                    cmd.ExecuteNonQuery();
                    Message = "Record Inserted";

                }
            }
        }
    }
}
