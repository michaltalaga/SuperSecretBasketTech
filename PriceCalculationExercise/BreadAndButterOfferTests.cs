using Xunit;
using System.Linq;

namespace PriceCalculationExercise
{
    public class BreadAndButterOfferTests
    {
        [Theory]
        [InlineData("2*Butter,1*Bread", 1, 0)]
        [InlineData("3*Butter,1*Bread", 1, 1)]
        [InlineData("2*Butter,2*Bread", 1, 1)]
        [InlineData("4*Butter,2*Bread", 2, 0)]
        [InlineData("1*Butter,1*Bread", 0, 2)]
        public void ReturnsLineItemsAndRemainingProductsForEachFullBatch(string productsString, int expectedLineItemsCount, int expectedRemaining)
        {
            var products = ProductHelper.GetProducts(productsString);
            var offer = new BreadAndButterOffer();
            var result = offer.Process(products);
            Assert.Equal(expectedLineItemsCount, result.lineItems.Count());
            Assert.Equal(expectedRemaining, result.remainingProducts.Count());
        }

        [Theory]
        [InlineData("2*Butter,1*Bread", 2.10)]
        [InlineData("3*Butter,1*Bread", 2.10)]
        [InlineData("2*Butter,2*Bread", 2.10)]
        [InlineData("4*Butter,2*Bread", 4.20)]
        [InlineData("1*Butter,1*Bread", 0)]
        public void BatchPriceCalculatedCorrectly(string productsString, decimal expectedTotalPrice)
        {
            var products = ProductHelper.GetProducts(productsString);
            var offer = new BreadAndButterOffer();
            var result = offer.Process(products);
            Assert.Equal(expectedTotalPrice, result.lineItems.Sum(li => li.Price));
        }
    }
}
