using System.Collections.Generic;

namespace PizzaExample
{
    public interface IMenu
    {
        IEnumerable<MenuPosition> Items { get; }
    }
}