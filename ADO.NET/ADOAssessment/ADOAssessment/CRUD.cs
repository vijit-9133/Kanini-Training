using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace ADOAssessment
{
    internal class CRUD : Program
    {
        private const string ConnectionString = "server=Vijit_Shetty;database=ADOAssessment;integrated security=true;trustservercertificate=true;";
        private SqlConnection con = new SqlConnection(ConnectionString);
        public void InsertData()
        {
        }

        public void InsertArtist(int artistId, string artistName, string countryName, int birthYear)
        {
            string query = "INSERT INTO ARTIST  VALUES (@aid, @aname, @cname, @birthyear)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@aid", artistId);
                cmd.Parameters.AddWithValue("@aname", artistName);
                cmd.Parameters.AddWithValue("@cname", countryName);
                cmd.Parameters.AddWithValue("@birthyear", birthYear);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void UpdateArtist(int artistId, string artistName, string countryName, int birthYear)
        {

            string query = "UPDATE ARTIST SET aname = @aname, cname = @cname, birthyear = @birthyear WHERE aid = @aid";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@aid", artistId);
                cmd.Parameters.AddWithValue("@aname", artistName);
                cmd.Parameters.AddWithValue("@cname", countryName);
                cmd.Parameters.AddWithValue("@birthyear", birthYear);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public (int artistId, string Aname, string countryName, int birthYear)? GetArtistByName(string @Aname)
        {
            string query = "SELECT aid, aname, cname, birthyear FROM ARTIST WHERE aname = @Aname";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@aname", Aname);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var id = reader.GetInt32(0);
                        var name = reader.GetString(1);
                        var country = reader.GetString(2);
                        var birthYear = reader.GetInt32(3);
                        //con.Close();
                        return (id, name, country, birthYear);
                    }
                }
                con.Close();
            }
            return null;
        }
        public void InsertArtWork(int artId, int artistId, string title, int price, string type, string status)
        {
            string query = "INSERT INTO ARTWORK (artid, aid, title, price, type, status) VALUES (@artid, @aid, @title, @price, @type, @status)";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@artid", artId);
                cmd.Parameters.AddWithValue("@aid", artistId);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@status", status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DisplayArtWork(string @aname)
        {
            string query = "SELECT artid, aid, title, price, type, status FROM ARTWORK WHERE title = @title";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@art", @aname);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine($"Art ID: {reader.GetInt32(0)}");
                        Console.WriteLine($"Artist ID: {reader.GetInt32(1)}");
                        Console.WriteLine($"Title: {reader.GetString(2)}");
                        Console.WriteLine($"Price: {reader.GetInt32(3)}");
                        Console.WriteLine($"Type: {reader.GetString(4)}");
                        Console.WriteLine($"Status: {reader.GetString(5)}");
                    }
                    else
                    {
                        Console.WriteLine("Artwork not found.");
                    }
                }
                con.Close();
            }
        }
        public int CountArtists()
        {
            int count = 0;
            using (SqlCommand cmd = new SqlCommand("CountArtist", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                count = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return count;
        }
        public int CountArtwork()
        {
            int count = 0;
            using (SqlCommand cmd = new SqlCommand("CountArtwork", con))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                count = (int)cmd.ExecuteScalar();
                con.Close();
            }
            return count;
        }
        public void DeleteArtist(string artistName = null)
        {
            string query;

            if (!string.IsNullOrWhiteSpace(artistName))
            {
                query = "DELETE FROM ARTIST WHERE aname = @aname";
            }
            else
            {
                throw new ArgumentException("No input provided.");
            }

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@aname", artistName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void DeleteArtwork(string artworkName = null)
        {
            string query;

            if (!string.IsNullOrWhiteSpace(artworkName))
            {
                query = "DELETE FROM ARTWORK WHERE title = @artname";
            }
            else
            {
                throw new ArgumentException("No input provided.");
            }

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@artname", artworkName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public List<(int artId, string artistName, string title, int price, string type, string status)> GetArtworksByArtistName(string artistName)
        {
            var artworks = new List<(int, string, string, int, string, string)>();
            string query = @"
        SELECT AW.artid, AR.aname, AW.title, AW.price, AW.type, AW.status
        FROM ARTWORK AW
        INNER JOIN ARTIST AR ON AW.aid = AR.aid";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int artId = reader.GetInt32(0);
                        string aName = reader.GetString(1);
                        string title = reader.GetString(2);
                        int price = reader.GetInt32(3);
                        string type = reader.GetString(4);
                        string status = reader.GetString(5);
                        artworks.Add((artId, aName, title, price, type, status));
                    }
                }
                con.Close();
            }
            return artworks;
        }
        public List<(int artId, string artistName, string title, int price, string type, string status)> SearchArtworks(string searchValue)
        {
            var artworks = new List<(int, string, string, int, string, string)>();
            string query = @"
        SELECT AW.artid, AR.aname, AW.title, AW.price, AW.type, AW.status
        FROM ARTWORK AW
        INNER JOIN ARTIST AR ON AW.aid = AR.aid
        WHERE AW.type = @search OR AW.status = @search OR AW.title = @search";

            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@search", searchValue);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int artId = reader.GetInt32(0);
                        string aName = reader.GetString(1);
                        string title = reader.GetString(2);
                        int price = reader.GetInt32(3);
                        string type = reader.GetString(4);
                        string status = reader.GetString(5);
                        artworks.Add((artId, aName, title, price, type, status));
                    }
                }
                con.Close();
            }
            return artworks;
        }
    }
}

