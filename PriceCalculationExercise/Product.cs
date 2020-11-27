using System.Diagnostics;

namespace PriceCalculationExercise
{
    [DebuggerDisplay("{Name}, {Price}")]
    public class Product
    {
        public static Product Butter => new Product(nameof(Butter), 0.80m);
        public static Product Milk => new Product(nameof(Milk), 1.15m);
        public static Product Bread => new Product(nameof(Bread), 1m);

        public string Name { get; }
        public decimal Price { get; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
