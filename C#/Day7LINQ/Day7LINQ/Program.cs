
using Day7LINQ;

internal class Program
{
    private static void Main(string[] args)
    {
        List<Movie> movies = new List<Movie>
        {
            new Movie { MovieId = 1, Title = "Inception", Genre = "Sci-Fi" },
            new Movie { MovieId = 2, Title = "The Godfather", Genre = "Crime" },
            new Movie { MovieId = 3, Title = "Interstellar", Genre = "Sci-Fi" }
        };

        List<Actor> actors = new List<Actor>
        {
            new Actor { ActorId = 1, ActorName = "Leonardo DiCaprio", MovieId = 1 },
            new Actor { ActorId = 2, ActorName = "Joseph Gordon-Levitt", MovieId = 1 },
            new Actor { ActorId = 3, ActorName = "Al Pacino", MovieId = 2 },
            new Actor { ActorId = 4, ActorName = "Marlon Brando", MovieId = 2 },
            new Actor { ActorId = 5, ActorName = "Matthew McConaughey", MovieId = 3 }
        };

        Console.WriteLine("--- Actor and Movie Title ---");
        var actorMovies = actors.Join(
            movies,
            actor => actor.MovieId,
            movie => movie.MovieId,
            (actor, movie) => new { actor.ActorName, movie.Title }
        );
        foreach (var item in actorMovies)
        {
            Console.WriteLine($"Actor: {item.ActorName}, Movie: {item.Title}");
        }
        Console.WriteLine();

        Console.WriteLine("--- Actor Count per Movie ---");
        var actorsPerMovie = actors.GroupBy(a => a.MovieId)
                                   .Select(g => new
                                   {
                                       MovieId = g.Key,
                                       ActorCount = g.Count()
                                   });
        foreach (var item in actorsPerMovie)
        {
            var movie = movies.FirstOrDefault(m => m.MovieId == item.MovieId);
            Console.WriteLine($"Movie: {movie.Title}, Actors: {item.ActorCount}");
        }
        Console.WriteLine();

        Console.WriteLine("--- Actors Grouped by Movie ---");
        var actorsByMovie = actors.GroupBy(a => a.MovieId);
        foreach (var group in actorsByMovie)
        {
            var movie = movies.FirstOrDefault(m => m.MovieId == group.Key);
            Console.WriteLine($"Movie: {movie.Title}");
            foreach (var actor in group)
            {
                Console.WriteLine($"  - {actor.ActorName}");
            }
        }
        Console.WriteLine();

        Console.WriteLine("--- Movies Ordered by Title ---");
        var moviesByTitle = movies.OrderBy(m => m.Title);
        foreach (var movie in moviesByTitle)
        {
            Console.WriteLine($"Title: {movie.Title}, Genre: {movie.Genre}");
        }
    }
    //List<Customer> customers = new List<Customer>
    //{
    //    new Customer { CustomerId = 1, Name = "Alice", City = "NY" },
    //    new Customer { CustomerId = 2, Name = "Bob", City = "LA" },
    //    new Customer { CustomerId = 3, Name = "Charlie", City = "NY" }
    //};

    //List<Order> orders = new List<Order>
    //{
    //    new Order { OrderId = 101, CustomerId = 1, Amount = 50.0 },
    //    new Order { OrderId = 102, CustomerId = 2, Amount = 120.5 },
    //    new Order { OrderId = 103, CustomerId = 1, Amount = 75.0 },
    //    new Order { OrderId = 104, CustomerId = 3, Amount = 200.0 },
    //    new Order { OrderId = 105, CustomerId = 2, Amount = 30.0 }
    //};

    //Console.WriteLine("--- Customer and Order Details ---");

    //var customerorders = from customer in customers
    //                     join order in orders
    //                     on customer.CustomerId equals order.CustomerId
    //                     select new { customer.Name, order.Amount };

    //foreach (var item in customerorders)
    //{
    //    Console.WriteLine($"Customer: {item.Name}, Amount: {item.Amount}");
    //}

    //Console.WriteLine();
    //Console.WriteLine("--- Total Order Amount per Customer ---");
    //var totalByCustomer = orders.GroupBy(o => o.CustomerId)
    //                            .Select(g => new
    //                            {
    //                                CustomerId = g.Key,
    //                                TotalAmount = g.Sum(o => o.Amount)
    //                            });
    //foreach (var item in totalByCustomer)
    //{
    //    var customer = customers.FirstOrDefault(c => c.CustomerId == item.CustomerId);
    //    Console.WriteLine($"Customer: {customer.Name}, Total: {item.TotalAmount}");
    //}
    //Console.WriteLine();
    //Console.WriteLine("--- Number of Orders per Customer ---");
    //var ordersPerCustomer = orders.GroupBy(o => o.CustomerId)
    //                              .Select(g => new
    //                              {
    //                                  CustomerId = g.Key,
    //                                  OrderCount = g.Count()
    //                              });
    //foreach (var item in ordersPerCustomer)
    //{
    //    var customer = customers.FirstOrDefault(c => c.CustomerId == item.CustomerId);
    //    Console.WriteLine($"Customer: {customer.Name}, Orders: {item.OrderCount}");
    //}
    //Console.WriteLine();
    //Console.WriteLine("--- Customers by Total Amount Spent (Descending) ---");
    //var customersByTotal = orders.GroupBy(o => o.CustomerId)
    //                             .Select(g => new
    //                             {
    //                                 CustomerId = g.Key,
    //                                 TotalSpent = g.Sum(o => o.Amount)
    //                             })
    //                             .OrderByDescending(x => x.TotalSpent);

    //foreach (var item in customersByTotal)
    //{
    //    var customer = customers.FirstOrDefault(c => c.CustomerId == item.CustomerId);
    //    Console.WriteLine($"Customer: {customer.Name}, Total Spent: {item.TotalSpent}");
    //}

    //        List<Student> students = new List<Student>
    //{
    //    new Student { RollNo = 1, Name = "Aarav", Department = "CSE", Marks = 95.5 },
    //    new Student { RollNo = 2, Name = "Priya", Department = "ECE", Marks = 88.0 },
    //    new Student { RollNo = 3, Name = "Rahul", Department = "CSE", Marks = 72.5 },
    //    new Student { RollNo = 4, Name = "Anjali", Department = "ME", Marks = 65.0 },
    //    new Student { RollNo = 5, Name = "Vikram", Department = "CSE", Marks = 91.0 },
    //    new Student { RollNo = 6, Name = "Sneha", Department = "ECE", Marks = 89.0 }
    //};
    //        Console.WriteLine("--- Students who scored above 90 ---");
    //        var toppers = students.Where(s => s.Marks > 90);
    //        foreach (var s in toppers)
    //        {
    //            Console.WriteLine($"Name: {s.Name}, Marks: {s.Marks}");
    //        }
    //        Console.WriteLine();
    //        string letter = "A";
    //        Console.WriteLine($"--- Students whose name starts with '{letter}' ---");
    //        var studentsA = students.Where(s => s.Name.StartsWith(letter));
    //        foreach (var student in studentsA)
    //        {
    //            Console.WriteLine($"Name: {student.Name}");
    //        }
    //        Console.WriteLine();
    //        Console.WriteLine("--- Students grouped by Department ---");
    //        var studDept = from s in students
    //                             group s by s.Department;
    //        foreach (var group in studDept)
    //        {
    //            Console.WriteLine($"Department: {group.Key}");
    //            foreach (var student in group)
    //            {
    //                Console.WriteLine($"  - {student.Name}");
    //            }
    //        }

}
