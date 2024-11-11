using System.ComponentModel.DataAnnotations;

namespace Carl_Zeiss_Assignment.Models.Entities
{
    public class AddProductDTO
    {

        public int ProductID { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

      
        public int StockAvailable { get; set; }

        public string Description { get; set; }

    }
}
