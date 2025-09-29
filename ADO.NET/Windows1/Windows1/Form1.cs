using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace Windows1
{
    public partial class Form1 : Form
    {
        private static SqlConnection sqlcon;
        private static SqlCommand cmd;
        static void getCon()
        {
            sqlcon = new SqlConnection("server=Vijit_Shetty;database=KANINIBATCH2;integrated security=true;trustservercertificate=true;");
            sqlcon.Open();


        }

        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            string selectQuery = "SELECT carId, carname, price FROM Cars";

            getCon();
            {
                try
                {

                    using (SqlCommand cmd = new SqlCommand(selectQuery, sqlcon))
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(sdr);
                            dataGridView1.DataSource = dt;

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while displaying cars: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectQuery = "SELECT * FROM Cars";
            getCon();
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(selectQuery, sqlcon))
                    {
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            DataTable dt1 = new DataTable();
                            dt1.Load(sdr);
                            dataGridView1.DataSource = dt1;

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while displaying cars: {ex.Message}");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Add a car in the records
            getCon();
            int id = int.Parse(txtid.Text);
            string cname = txtname.Text;
            decimal price = decimal.Parse(txtprice.Text);
            cmd = new SqlCommand("AddCar", sqlcon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@carId", id);
            cmd.Parameters.AddWithValue("@carname", cname);
            cmd.Parameters.AddWithValue("@Carprice", price);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            MessageBox.Show("Record inserted");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getCon();
            int id = int.Parse(txtid.Text);
            string selectquery = "select * from Cars where carid=@carid";
            cmd = new SqlCommand(selectquery, sqlcon);
            cmd.Parameters.AddWithValue("@carid", id);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                txtname.Text = sdr["carname"].ToString();
                txtprice.Text = sdr["price"].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getCon();
            string selectquery = "select count(*) from Cars";
            cmd = new SqlCommand(selectquery, sqlcon);
            int count = (int)cmd.ExecuteScalar();
            MessageBox.Show("Total No. of Cars: " + count);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                getCon();
                int id = int.Parse(txtid.Text);
                string cname = txtname.Text;
                decimal price = decimal.Parse(txtprice.Text);
                cmd = new SqlCommand("UpdateCarDetails", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carId", id);
                cmd.Parameters.AddWithValue("@CarName", cname);
                cmd.Parameters.AddWithValue("@CarPrice", price);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Record updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                getCon();
                int id = int.Parse(txtid.Text);
                cmd = new SqlCommand("DeleteCarDetails", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carId", id);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                MessageBox.Show("Record deleted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
        
    