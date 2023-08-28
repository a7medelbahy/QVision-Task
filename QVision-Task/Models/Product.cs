using System.ComponentModel.DataAnnotations;

namespace QVision_Task.Models
{
    public class Product
    {
        public int Id { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_ ]{3,30}$", ErrorMessage = "Enter Valid Product Name")]
        public string Name { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9_ ]{3,300}$", ErrorMessage = "Enter Valid Product Description")]

        public string Description { get; set; }

        [Range(0, int.MaxValue,ErrorMessage ="Price must be more than 0")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be more than 0")]

        public int StockQuantity { get; set;}

        [Expiration]
        public DateTime ExpirationDate { get; set; }
    }
}
