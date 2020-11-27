using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace PriceCalculationExercise
{
    public class SingleProductBulkOffer : BaseOffer
    {
        //Buy 3 Milk and get the 4th milk for free
        public SingleProductBulkOffer(string productName, int batchSize, int itemsFree = 1)
        {
            this.productName = productName;
            this.batchSize = batchSize;
            this.itemsFree = itemsFree;
        }
        private readonly string productName;
        private readonly int batchSize;
        private readonly int itemsFree;

        protected override IEnumerable<LineItem> GetLineItems(IEnumerable<Product> products)
        {
            var productsWithName = products.Where(p => p.Name == productName);
            var batches = GetFullBatches(productsWithName, batchSize);
            return batches.Select(batch => new LineItem
            {
                Name = $"{nameof(SingleProductBulkOffer)} - {productName}",
                Price = batch.First().Price * batchSize - batch.First().Price * itemsFree,
                Items = batch
            });
        }
    }
}
