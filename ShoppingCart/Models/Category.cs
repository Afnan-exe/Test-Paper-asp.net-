using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Models
{
    public class Category
    {


        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "CATEGORY NAME")]
        public string CatName { get; set; }
        [Required]
        [StringLength(30)]
        public string slug { get; set; }
        [Display(Name = "AVAILABILITY")]
        public bool Availability { get; set; }

    }
}
