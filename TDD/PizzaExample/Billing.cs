using System.Collections.Generic;
using System.Linq;

namespace PizzaExample
{
    public class Billing
    {
        private readonly Menu _menu;

        public Billing(Menu menu)
        {
            _menu = menu;
        }

        public Dictionary<string, double> Calculate(Order order)
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
