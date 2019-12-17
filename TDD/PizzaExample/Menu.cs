using System.Collections.Generic;

namespace PizzaExample
{
    public class Menu
    {
        public IEnumerable<MenuPosition> Items => new[]{
            new MenuPosition("4 sery", 40),
            new MenuPosition("Poznanska", 60),
        };
    }
}
