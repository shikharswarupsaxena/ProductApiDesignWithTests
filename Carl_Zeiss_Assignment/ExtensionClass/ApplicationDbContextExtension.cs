using System.Runtime.CompilerServices;
using Carl_Zeiss_Assignment.Data;


namespace Carl_Zeiss_Assignment.ExtensionClass
{
    public static class ApplicationDbContextExtension
    {

        private static readonly Random random = new Random();

        public static int GenerateUniqueProductID(this ApplicationDbContext context)
        {
            const int maxAttempts  = 10;
            for (int i = 0; i < maxAttempts; i++)
            {
                int productID = random.Next(100000, 999999);

                if (!context.Products.Any(p => p.ProductID == productID))
                {
                    return productID;
                }
            }

            throw new Exception("Could not generate Product id");
        }
    }
}
