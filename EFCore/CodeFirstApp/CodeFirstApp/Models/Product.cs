using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApp.Models
{
    public class Product
    {
        [Key] public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int? CategoryCId { get; set; } 
        [ForeignKey("CategoryCId")]

        public virtual Categories Category{ get; set;}
    }
}
