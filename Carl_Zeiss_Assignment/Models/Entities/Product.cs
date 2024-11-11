namespace Carl_Zeiss_Assignment.Models.Entities
{

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Product
    {

        [Key]
        public int ProductID { get; set; }
       
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
       
        [Required]
        public int StockAvailable { get; set; }

        public string Description { get; set; }

    }
}
