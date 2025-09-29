using System.ComponentModel.DataAnnotations;

namespace CodeFirstApp.Models
{
    public class Categories
    {
        [Key]
        public int CId { get; set; }
        public string CName { get; set; }
        public virtual ICollection <Product> Products { get; set; }

    }
}
