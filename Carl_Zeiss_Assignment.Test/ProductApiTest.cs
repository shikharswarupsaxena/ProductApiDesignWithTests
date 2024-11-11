using Carl_Zeiss_Assignment.Data;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Carl_Zeiss_Assignment.Models.Entities;

namespace Carl_Zeiss_Assignment.Test
{
    public class ProductApiTest
    {

        private readonly ApplicationDbContext _Inmemorycontext;

        public ProductApiTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "ProductApiTestDb").Options;

            _Inmemorycontext = new ApplicationDbContext(options);
        }

        [Fact]
        public async Task GetAllProducts_ShouldReturnListOfProducts()
        {
            // Arrange

            _Inmemorycontext.Products.Add(new Product { Name = "Product 1", Price = 100, StockAvailable = 20, Description = "Description" });
            _Inmemorycontext.Products.Add(new Product { Name = "Product 2", Price = 200, StockAvailable = 30, Description = "Description" });
            _Inmemorycontext.SaveChangesAsync();

            // Act
            var products = await _Inmemorycontext.Products.ToListAsync();

            // Assert
            Assert.Equal(3, products.Count);
            Assert.Contains(products, p => p.Name == "Product 1");
            Assert.Contains(products, p => p.Name == "Product 2");
           
        }
        [Fact]
        public async Task CreateProduct_ShouldAddProductToDatabase()
        {
            // Arrange
            var product = new Product
            {
                ProductID = 1,
                Name = "Test Product",
                Price = 100,
                StockAvailable = 50,
                Description = "Description"
            };

            // Act
            _Inmemorycontext.Products.Add(product);
            await _Inmemorycontext.SaveChangesAsync();

            // Assert
            var savedProduct = await _Inmemorycontext.Products.FindAsync(product.ProductID);
            Assert.NotNull(savedProduct);
            Assert.Equal("Test Product", savedProduct.Name);
            Assert.Equal(100, savedProduct.Price);
            Assert.Equal(50, savedProduct.StockAvailable);
        }

        [Fact]
        public async Task DeleteProduct_ShouldRemoveProductFromDatabase()
        {
            // Arrange
            var product = new Product { Name = "Product to Delete", Price = 100, StockAvailable = 20, Description = "Description" };
            _Inmemorycontext.Products.Add(product);
            await _Inmemorycontext.SaveChangesAsync();

            // Act
            _Inmemorycontext.Products.Remove(product);
            await _Inmemorycontext.SaveChangesAsync();

            // Assert
            var deletedProduct = await _Inmemorycontext.Products.FindAsync(product.ProductID);
            Assert.Null(deletedProduct);
        }

        [Fact]
        public async Task UpdateProduct_ShouldModifyProductDetails()
        {
            // Arrange
            var product = new Product { Name = "Old Product", Price = 100, StockAvailable = 20, Description = "Description" };
            _Inmemorycontext.Products.Add(product);
            await _Inmemorycontext.SaveChangesAsync();

            // Act
            product.Name = "Updated Product";
            product.Price = 120;
            _Inmemorycontext.Products.Update(product);
            await _Inmemorycontext.SaveChangesAsync();

            // Assert
            var updatedProduct = await _Inmemorycontext.Products.FindAsync(product.ProductID);
            Assert.Equal("Updated Product", updatedProduct.Name);
            Assert.Equal(120, updatedProduct.Price);
        }
    }
}