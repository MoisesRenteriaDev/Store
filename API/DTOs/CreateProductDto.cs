using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public string PictureUrl { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; }

        [Required]
        public string Brand { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity in stock must be least 1")]
        public int QuantityInStock { get; set; }
    }
}