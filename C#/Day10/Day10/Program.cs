internal class Program
{
    private static void Main(string[] args)
    {

            try
            {
                using (var headphones = new Product(101, "Headphones", 99.99m))
                {
                    Console.WriteLine($"Using Product: {headphones.Name}");
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An exception occurred: {ex.Message}");
            }

            List<Product> products = new List<Product>
        {
            new Product(102, "Keyboard", 120.00m),
            new Product(103, "Mouse", 45.50m),
            new Product(104, "Monitor", 300.00m)
        };

            IEnumerable<Product> inMemoryQuery = products.Where(p => p.Price > 100);
            Console.WriteLine("\nUsing IEnumerable (in-memory):");
            foreach (var p in inMemoryQuery)
            {
                Console.WriteLine($" - {p.Name} (${p.Price})");
            }

            IQueryable<Product> queryable = products.AsQueryable();
            Console.WriteLine("\nUsing IQueryable (out-of-memory simulated):");
            IQueryable<Product> dbQuery = queryable.Where(p => p.Price > 100);

            foreach (var p in dbQuery)
            {
                Console.WriteLine($" - {p.Name} (${p.Price})");
            }
            Console.WriteLine("\nSorting products by price using IComparable:");
            products.Sort(); 
            foreach (var p in products)
            {
                Console.WriteLine($" - {p.Name} (${p.Price})");
            }

            foreach (var p in products)
            {
                p.Dispose();
            }
        }
    }
