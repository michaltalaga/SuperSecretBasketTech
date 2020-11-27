using System.Collections.Generic;

namespace PriceCalculationExercise
{
    public class PricingService
    {
        List<IOffer> offers = new();
        public PricingService()
        {
            // inject this
            offers.Add(new BreadAndButterOffer());
            offers.Add(new SingleProductBulkOffer(nameof(Product.Milk), 4));
            // but this should always be here
            offers.Add(new NoOffer());
        }
        public IEnumerable<LineItem> GetLineItems(IEnumerable<Product> products)
        {
            var lineItems = new List<LineItem>();
            foreach (var offer in offers)
            {
                var result = offer.Process(products);
                lineItems.AddRange(result.lineItems);
                products = result.remainingProducts;
            }
            return lineItems;
        }


    }
}
