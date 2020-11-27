using Xunit;
using System.Linq;

namespace PriceCalculationExercise
{
    public class PricingServiceAndFriendsTests
    {
        [Fact]
        public void IDidntCreateABasketAsInThisScenarioItWouldBeAThinWrapperOverAList()
        {
            Assert.Empty("Also I've went ahead and returned line items instead of just decimal. " +
                "I know I will need it. Else my code would be difficult to restructure (not the same as refactor).");
            Assert.Empty("Sorry. One big commit. I'd normally do small ones for most of it but I played too much with the domain.");
        }

        [Fact]
        public void AlsoItWasntActuallyTDDIPlayedALotWithDifferentConceptsToLearnTheDomainSeeVideoWhitePaperAndArticleForExplaination()
        {
            Assert.True("https://www.youtube.com/watch?v=KtHQGs3zFAM".Length > 0);
            Assert.True("https://rbcs-us.com/documents/Why-Most-Unit-Testing-is-Waste.pdf".Length > 0);
            Assert.True("https://dhh.dk/2014/tdd-is-dead-long-live-testing.html".Length > 0);
            Assert.Equal("The Cope >> Uncle Bob?", "Uncle Bob > The Cope");
        }


        [Theory]
        [InlineData("1*Bread,1*Butter,1*Milk", 2.95)]
        [InlineData("2*Butter,1*Bread,8*Milk", 9)]
        [InlineData("4*Milk", 3.45)]
        [InlineData("2*Butter,2*Bread", 3.10)]
        public void PricingServiceCalculatesTheTotalPrice_AkaTheTestThatActuallyMatters(string productsString, decimal expectedValue)
        {
            var products = ProductHelper.GetProducts(productsString);
            var pricingService = new PricingService();
            var lineItems = pricingService.GetLineItems(products);
            var totalPrice = lineItems.Sum(x => x.Price);
            Assert.Equal(expectedValue, totalPrice);
        }
    }
}
