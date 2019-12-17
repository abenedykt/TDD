using System;
using Xunit;

namespace PizzaExample
{
    public class TestingWithoutStructure
    {
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

    }
}
