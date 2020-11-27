using System.Collections.Generic;

namespace PriceCalculationExercise
{
    public interface IOffer
    {
        (IEnumerable<LineItem> lineItems, IEnumerable<Product> remainingProducts) Process(IEnumerable<Product> products);
    }
}
