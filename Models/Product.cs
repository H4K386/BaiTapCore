using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _0306241284_NguyenKhanhHuy.Models
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public bool Status { get; set; } = true;

        public Category? Category { get; set; }
    }
}
