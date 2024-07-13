using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Products
    {

        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "PRODUCT NAME")]
        [StringLength(50)]
        public string Pname { get; set; }

        [Required]
        [Display(Name = "DESCRIPTION")]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "SUBJECT")]
        [StringLength(100)]
        public string Subject { get; set; }

        [Required]
        [Display(Name = "BRAND")]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [StringLength(50)]
        public string Pimage { get; set; }

        [Required]
        [Display(Name = "QUANTITY")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "PRICE")]
        public int Price { get; set; }

        [Required]
        public string Slug { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
