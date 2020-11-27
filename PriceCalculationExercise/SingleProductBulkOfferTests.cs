using Xunit;
using System.Linq;

namespace PriceCalculationExercise
{
    public class SingleProductBulkOfferTests
    {
        [Theory]
        [InlineData("4*Milk", 4, 1, 0)]
        [InlineData("4*Milk", 5, 0, 4)]
        [InlineData("4*Milk", 2, 2, 0)]
        [InlineData("5*Milk", 2, 2, 1)]
        public void ReturnsLineItemsAndRemainingProductsForEachFullBatch(string productsString, int batchSize, int expectedLineItemsCount, int expectedRemaining)
        {
            var products = ProductHelper.GetProducts(productsString);
            var offer = new SingleProductBulkOffer(products.First().Name, batchSize);
            var result = offer.Process(products);
            Assert.Equal(expectedLineItemsCount, result.lineItems.Count());
            Assert.Equal(expectedRemaining, result.remainingProducts.Count());
        }

        [Theory]
        [InlineData("4*Milk", 4, 3.45)]
        [InlineData("5*Milk", 4, 3.45)]
        [InlineData("10*Milk", 4, 6.90)]
        public void BatchPriceCalculatedCorrectly(string productsString, int batchSize, decimal expectedTotalPrice)
        {
            var products = ProductHelper.GetProducts(productsString);
            var offer = new SingleProductBulkOffer(products.First().Name, batchSize);
            var result = offer.Process(products);
            Assert.Equal(expectedTotalPrice, result.lineItems.Sum(li => li.Price));
        }
        
    }
}
