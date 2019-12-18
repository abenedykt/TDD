using System.Linq;
using NSubstitute;
using Xunit;

namespace PizzaExample
{
    public class BillingTests
    {
        [Fact]
        public void Billing_returns_name_and_price_for_each_person_on_the_order()
        {
            var testOrder = CreateTestOrder();

            var menu = Substitute.For<IMenu>(); 
            menu.Items.Returns(new[]{
                new MenuPosition("4 sery", 40),
                new MenuPosition("Poznanska", 60),
                new MenuPosition("Warszawsa", 60),
                new MenuPosition("Krakowska", 60),
                new MenuPosition("Łódzka", 60),
            });

            var billing = new Billing(menu);
            var x = billing.Calculate(testOrder);
            var bill = x.ToList();

            Assert.Equal("Arek", bill[0].Name);
            Assert.Equal(20, bill[0].Value);

            Assert.Equal("Marek", bill[1].Name);
            Assert.Equal(30, bill[1].Value);
        }

        private static Order CreateTestOrder()
        {
            var exampleOrder = new Order();
            exampleOrder.Add(new OrderPosition("Arek", 4, "4 sery"));
            exampleOrder.Add(new OrderPosition("Marek", 4, "Poznanska"));
            return exampleOrder;
        }
    }
}
