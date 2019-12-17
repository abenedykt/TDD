namespace PizzaExample
{
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
}
