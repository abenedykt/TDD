using System;
using Xunit;

namespace PizzaExample
{
    public class PizzaTests
    {
        [Fact]
        public void FirstTest()
        {
            // arrange 
            var order = new Order();

            // act
            order.Add(new OrderPosition("Arek", 8, "4 sery"));

            // assert
            Assert.True(order.IsValid());
        }
    }

    internal class OrderPosition
    {
        public OrderPosition(string name, int pieces, string pizzaName)
        {
            Name = name;
            Pieces = pieces;
            PizzaName = pizzaName;
        }

        public string Name { get; }
        public int Pieces { get; }
        public string PizzaName { get; }
    }

    internal class Order
    {
        internal void Add(OrderPosition orderPosition)
        {
        }

        internal bool IsValid()
        {
            return true;
        }
    }
}
