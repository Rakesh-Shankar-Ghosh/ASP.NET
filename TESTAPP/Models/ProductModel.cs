using System.ComponentModel.DataAnnotations;

namespace TESTAPP.Models
{
    public class ProductModel
    {

        [Key]
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "Product name is required.")]
        public string Name { get; set; } = "";

        // Price of the product (integer)
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        public int Price { get; set; } = 0;

        // Availability of the product (boolean)
        public bool Availability { get; set; } = false;
    }
}
