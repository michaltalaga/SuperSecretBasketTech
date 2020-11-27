using Xunit;
using System.Linq;

namespace PriceCalculationExercise
{
    public class NoOfferTests
    {
        [Theory]
        [InlineData("1*Bread", 1)]
        [InlineData("2*Bread", 2)]
        [InlineData("1*Bread,2*Milk", 3)]
        [InlineData("", 0)]
        public void ReturnsLineItemForEachProduct(string productsString, int expectedCount)
        {
            var products = ProductHelper.GetProducts(productsString);
            var offer = new NoOffer();
            var result = offer.Process(products);
            Assert.Equal(expectedCount, result.lineItems.Count());
        }
        [Fact]
        public void ResultMatchesProduct()
        {
            var offer = new NoOffer();
            var milk = Product.Milk;
            var result = offer.Process(new[] { milk }).lineItems.First();
            Assert.Equal(milk.Name, result.Name);
            Assert.Equal(milk.Price, result.Price);
            Assert.Contains(milk, result.Items);
        }

    }
}
