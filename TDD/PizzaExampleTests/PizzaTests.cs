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
}
