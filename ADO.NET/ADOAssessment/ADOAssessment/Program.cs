using ADOAssessment;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        string choice;
        do
        {
            Console.WriteLine("\n--- Artist Database CRUD Operations Menu ---");
            Console.WriteLine("1. Insert Artist Data");
            Console.WriteLine("2. Update Artist Data");
            Console.WriteLine("3. Select artist data by name");
            Console.WriteLine("4. Insert Artwork Data ");
            Console.WriteLine("5. ");
            Console.WriteLine("6. Delete");
            Console.WriteLine("7. Count number of artists");
            Console.WriteLine("8. Search");

            Console.Write("Enter your choice: ");
            try
            {
                int ch = Convert.ToInt32(Console.ReadLine());
                CRUD c = new CRUD();
                switch (ch)
                {
                    case 1:
                        Console.Write("Enter Artist ID: ");
                        int artid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Artist Name: ");
                        string artname = Console.ReadLine();
                        Console.Write("Enter Country Name: ");
                        string countryname = Console.ReadLine();
                        Console.Write("Enter Birth Year: ");
                        int birthyear = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Inserting artist data...");                       
                        c.InsertArtist(artid, artname, countryname, birthyear);
                        break;
                    case 2:
                        Console.Write("Enter Artist ID for updating: ");
                        int artistId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Artist Name: ");
                        string aname = Console.ReadLine();
                        Console.Write("Enter Country Name: ");
                        string cname = Console.ReadLine();
                        Console.Write("Enter Birth Year: ");
                        int byear = Convert.ToInt32(Console.ReadLine());
                        c.UpdateArtist(artistId,aname,cname,byear);
                        break;
                    //case 3:
                    //    Console.Write("Enter Artist Name: ");
                    //    string Aname = Console.ReadLine();
                    //    var artist = c.GetArtworksByArtistName(Aname);
                    //    if (artist != null)
                    //    {
                    //        Console.WriteLine($"ID: {artist.Value.artistId}, Name: {artist.Value.Aname}, Country: {artist.Value.countryName}, Birth Year: {artist.Value.birthYear}");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine("Artist not found.");
                    //    }
                    //    break;
                    case 4:
                        Console.Write("Enter Artwork ID for insertion: ");
                        int artId = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Artist ID: ");
                        int Arid = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter Price:");
                        int price = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Type:");
                        string type = Console.ReadLine();
                        Console.Write("Enter Status:");
                        string status = Console.ReadLine();
                        c.InsertArtWork(artId, Arid, title, price, type, status);
                        break;
                    case 5:
    var artworks = c.GetArtworksByArtistName(""); 
    if (artworks.Count > 0)
    {
        foreach (var art in artworks)
        {
            Console.WriteLine($"Art ID: {art.artId}, Artist: {art.artistName}, Title: {art.title}, Price: {art.price}, Type: {art.type}, Status: {art.status}");
        }
    }
    else
    {
        Console.WriteLine("No artworks found.");
    }
    break;
                    case 6:
                        Console.WriteLine("Delete artist by:");
                        Console.WriteLine("1. Artist ");
                        Console.WriteLine("2. Artwork");
                        Console.Write("Enter your choice: ");
                        int deleteChoice = Convert.ToInt32(Console.ReadLine());
                        if (deleteChoice == 1)
                        {
                            Console.Write("Enter Artist Name: ");
                            string delName = Console.ReadLine();
                            c.DeleteArtist(delName);
                            Console.WriteLine("Artist deleted by name.");
                            
                        }
                        else if (deleteChoice == 2)
                        {
                            Console.Write("Enter Artwork Name: ");
                            string delaName = Console.ReadLine();
                            c.DeleteArtwork(delaName);
                            Console.WriteLine("Artwork deleted by name.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice for deletion.");
                        }


                        break;
                    case 7:
                        Console.WriteLine("The number of artists : " + c.CountArtists());
                        Console.WriteLine("The number of artworks : " + c.CountArtwork());
                        break;
                    case 8:
                        Console.Write("Enter search value: ");
                        string searchValue = Console.ReadLine();
                        var results = c.SearchArtworks(searchValue);
                        if (results.Count > 0)
                        {
                            foreach (var art in results)
                            {
                                Console.WriteLine($"Art ID: {art.artId}, Artist: {art.artistName}, Title: {art.title}, Price: {art.price}, Type: {art.type}, Status: {art.status}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No artworks found for the given search value.");
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 8");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nDo you want to perform another operation? (yes/no)");
            choice = Console.ReadLine();
        } while (choice != null && choice.Trim().Equals("yes", StringComparison.OrdinalIgnoreCase));
    }
}
