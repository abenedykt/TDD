using System.Collections.Generic;
using System.Linq;

namespace PizzaExample
{
    public class Billing
    {
        private readonly IMenu _menu;

        public Billing(IMenu menu)
        {
            _menu = menu;
        }

        public IEnumerable<BillItem> Calculate(Order order)
        {
            return order.Positions
               .GroupBy(x => x.Name)
               .Select(g => new BillItem(
                    g.Key,
                   g.Sum(p => Price(p.PizzaName, p.Pieces))
               ));
        }

        private double Price(string pizzaName, int pieces)
        {
            return _menu.Items.Single(i => i.Name == pizzaName).Price / 8.0 * pieces;
        }
    }

    public class BillItem
    {

        public BillItem(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public double Value { get; }
    }
}
