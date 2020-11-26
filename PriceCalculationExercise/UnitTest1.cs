using System;
using System.Collections.Generic;
using Xunit;

namespace PriceCalculationExercise
{
    public class UnitTest1
    {
        [Fact]
        public void BasketStartsEmpty()
        {
            var basket = new Basket();
            Assert.Empty(basket.Items);
        }
    }

    public class Product
    {
    }

    public class Basket
    {
        public IEnumerable<Product> Items { get; }
    }

}
