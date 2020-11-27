using System.Collections.Generic;
using System.Linq;
using MoreLinq;

namespace PriceCalculationExercise
{
    public class BreadAndButterOffer : BaseOffer
    {
        //Buy 2 Butter and get a Bread at 50% off
        const int ButterBatchSize = 2;
        const decimal BreadDiscount = 0.5m;
        protected override IEnumerable<LineItem> GetLineItems(IEnumerable<Product> products)
        {
            var butters = products.Where(p => p.Name == nameof(Product.Butter));
            var butterBatches = GetFullBatches(butters, ButterBatchSize).ToList();
            var breads = products.Where(p => p.Name == nameof(Product.Bread)).Batch(1).ToList();
            return butterBatches.Zip(breads, (butters, breads) => new LineItem
            {
                Name = nameof(BreadAndButterOffer),
                Price = butters.Sum(b=>b.Price) + breads.Sum(p => p.Price) * BreadDiscount,
                Items = butters.Union(breads)
            });
        }
    }
}
