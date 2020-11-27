using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculationExercise
{
    public class NoOffer : IOffer
    {
        public (IEnumerable<LineItem> lineItems, IEnumerable<Product> remainingProducts) Process(IEnumerable<Product> products)
        {
            var lineItems = products.Select(p => new LineItem
            {
                Name = p.Name,
                Price = p.Price,
                Items = new[] { p }
            });
            return (lineItems, Array.Empty<Product>());
        }
    }
}
