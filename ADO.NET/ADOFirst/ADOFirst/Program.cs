using Microsoft.Data.SqlClient;
using System.Runtime.InteropServices;

internal class Program
{
    private static SqlConnection sqlcon=null;
    private static void Main(string[] args)
    {
        create();
    }
    public static void getConnection() 
    {
        SqlConnection sqlcon = new SqlConnection("server=Vijit_Shetty;database=KANINIBATCH2;integrated security=true;trustservercertificate=true;");
        sqlcon.Open();
    }
    static void create() { 
        getConnection();
        SqlCommand cmd = new SqlCommand("create table Cars(carid int primary key,carname varchar(25),carprice decimal(7,2))",sqlcon);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Table Created");
        sqlcon.Close();
    }
    static void insert()
    {
        getConnection();
        Console.WriteLine("Enter the car data to be inserted");
        Console.WriteLine("Enter the car id:");
        int cid = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the car name:");
        string cname = Console.ReadLine();
        Console.WriteLine("Enter the car price:");
        decimal price = decimal.Parse(Console.ReadLine());
        SqlCommand cmd = new SqlCommand("insert into Cars values(@carid,@carname,@carprice)", sqlcon);
        cmd.Parameters.AddWithValue()    }
}