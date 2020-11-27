using System.Collections.Generic;
using System.Diagnostics;

namespace PriceCalculationExercise
{
    [DebuggerDisplay("{Name}, {Price}")]
    public class LineItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<Product> Items { get; set; }
    }
}
