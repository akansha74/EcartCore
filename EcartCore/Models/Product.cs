using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcartCore.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal SalePrice { get; set; }
        public int Qty { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }
        [ForeignKey("Brand")]
        public int? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
    }
}
