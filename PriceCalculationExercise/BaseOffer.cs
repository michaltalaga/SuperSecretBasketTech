using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace PriceCalculationExercise
{
    public abstract class BaseOffer : IOffer
    {
        public (IEnumerable<LineItem> lineItems, IEnumerable<Product> remainingProducts) Process(IEnumerable<Product> products)
        {
            var lineItems = GetLineItems(products);
            var remaining = products.Except(lineItems.SelectMany(li => li.Items));
            return (lineItems, remaining);
        }
        protected abstract IEnumerable<LineItem> GetLineItems(IEnumerable<Product> products);
        protected static IEnumerable<IEnumerable<Product>> GetFullBatches(IEnumerable<Product> products, int size) => products.Batch(size).Where(b => b.Count() == size);
    }
}
