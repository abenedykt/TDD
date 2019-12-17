using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PizzaExample
{
    public class PizzaTests
    {
        private readonly Order _order;

        public PizzaTests()
        {
            _order = new Order();
        }

        [Fact]
        public void When_one_person_orders_8_pieces_then_order_is_valid()
        {
            // act
            _order.Add(new OrderPosition("Arek", 8, "4 sery"));

            // assert
            Assert.True(_order.IsValid());
        }

        [Fact]
        public void When_sum_of_pieces_is_not_divisible_by_8_order_is_not_valid()
        {
            _order.Add(new OrderPosition("Jarek", 3, "4 sery"));

            Assert.False(_order.IsValid()); 
        }

        [Fact]
        public void When_two_people_order_total_8_pieces_of_differet_pizza_and_not_half_half_order_is_invalid()
        {
            // AAA
            _order.Add(new OrderPosition("Arek", 3, "4 sery"));
            _order.Add(new OrderPosition("Marek", 5, "Poznanska"));

            Assert.False(_order.IsValid());
        }

        [Fact]
        public void When_two_people_order_four_pieces_of_different_types_order_is_valid()
        {
            // AAA
            _order.Add(new OrderPosition("Arek", 4, "4 sery"));
            _order.Add(new OrderPosition("Marek", 4, "Poznanska"));

            Assert.True(_order.IsValid());
        }

        [Fact]
        public void When_three_people_order_4_pieces_of_different_pizzas_each_order_is_not_valid()
        {
            // AAA
            _order.Add(new OrderPosition("Arek", 4, "4 sery"));
            _order.Add(new OrderPosition("Marek", 4, "Poznanska"));
            _order.Add(new OrderPosition("Jarek", 4, "Cappriciosa"));

            Assert.False(_order.IsValid());
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
        private readonly IList<OrderPosition> _positions = new List<OrderPosition>();

        internal void Add(OrderPosition position)
        {
            _positions.Add(position);
        }

        internal bool IsValid()
        {
            return _positions.Sum(p=>p.Pieces) % 8 == 0 &&  _positions
                .GroupBy(x => x.PizzaName)
                .Select(g => new
                {
                    PizzaName = g.Key,
                    TotalPieces = g.Sum(x => x.Pieces)
                })
                .All(g => g.TotalPieces % 4 == 0);
        }
    }
}
