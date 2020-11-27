using System.Collections.Generic;
using System;

namespace PriceCalculationExercise
{
    public static class ProductHelper
    {
        #region ugly don't look
        public static IEnumerable<Product> GetProducts(string productsString)
        {
            var products = new List<Product>();
            foreach (var priceAndName in productsString.Split(',', StringSplitOptions.RemoveEmptyEntries))
            {
                var count = int.Parse(priceAndName.Split('*')[0]);
                var productName = priceAndName.Split('*')[1];
                for (int i = 0; i < count; i++)
                {
                    products.Add(GetProductFromName(productName));
                }
            }
            return products;
        }
        private static Product GetProductFromName(string name)
        {
            var productFactory = typeof(Product).GetProperty(name);
            return (Product)productFactory.GetValue(null);

        }
        #endregion
    }
}
