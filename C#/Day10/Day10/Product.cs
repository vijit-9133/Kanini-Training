using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Product : IDisposable, IComparable<Product>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    private StreamWriter _logWriter;

    public Product(int id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;

        try
        {
            _logWriter = new StreamWriter("product_log.txt", true);
            _logWriter.WriteLine($"Product created: {Name}");
            _logWriter.Flush();
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error creating Product: Could not access 'product_log.txt'. {ex.Message}");
        }
    }
    public void Dispose()
    {
        Console.WriteLine($"Disposing of Product: {Name}");
        if (_logWriter != null)
        {
            _logWriter.Dispose();
            _logWriter = null;
        }
        GC.SuppressFinalize(this);
    }
    public int CompareTo(Product other)
    {
        if (other == null) return 1;
        return this.Price.CompareTo(other.Price);
    }
}