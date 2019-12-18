using System;

namespace PizzaExample
{
    public class MenuPosition
    {
        public MenuPosition(string name, int price)
        {
            Name = name;
            if (price <= 0) throw new ArgumentException();
            Price = price;
        }

        public string Name { get; }
        public double Price { get; }
    }
}
