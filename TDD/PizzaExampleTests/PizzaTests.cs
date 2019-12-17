using System;
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

        [Fact]
        public void Example()
        {

            // coding without code structure

            var a = 1;
            var b = 3;
            var c = -50;

            var delta = b * b - (4 * a * c);

            if (delta > 0)
            {
                var x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                var x2 = (-b + Math.Sqrt(delta)) / (2 * a);
            }

        }


        [Fact]
        public void Billing_returns_name_and_price_for_each_person_on_the_order()
        {
            var testOrder = CreateTestOrder();

            var menu = new Menu();

            var billing = new Billing(menu);
            var bill = billing.Calculate(testOrder);

            Assert.Equal(20, bill["Arek"]);

            Assert.Equal(30, bill["Marek"]);
        }

        private static Order CreateTestOrder()
        {
            var exampleOrder = new Order();
            exampleOrder.Add(new OrderPosition("Arek", 4, "4 sery"));
            exampleOrder.Add(new OrderPosition("Marek", 4, "Poznanska"));
            return exampleOrder;
        }
    }

    internal class Menu
    {
        public IEnumerable<MenuPosition> Items => new[]{
            new MenuPosition("4 sery", 40),
            new MenuPosition("Poznanska", 60),
        };
    }

    public class MenuPosition
    {

        public MenuPosition(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public double Price { get; }
    }

    internal class Billing
    {
        private Menu _menu;

        public Billing(Menu menu)
        {
            _menu = menu;
        }

        internal Dictionary<string, double> Calculate(Order order)
        {
            var result = new Dictionary<string, double>();

            var bill = order.Positions
               .GroupBy(x => x.Name)
               .Select(g => new
               {
                   Name = g.Key,
                   Value = g.Sum(p => Price(p.PizzaName, p.Pieces))
               });

            foreach (var item in bill)
            {
                result.Add(item.Name, item.Value);
            }
            return result;
        }

        private double Price(string pizzaName, int pieces)
        {
            return _menu.Items.Single(i => i.Name == pizzaName).Price / 8.0 * pieces;
        }
    }
}
