using Xunit;

namespace PizzaExample
{
    public class ValueObjectsExample
    {
        [Fact]
        public void ExampleMethodTest()
        {
            ExampleMethod("Arek", "Kowalski");
            ExampleMethod("Kowalski", "Arek");
        }


        public void ExampleMethod(string name, string surname)
        {

        }
    }
}
