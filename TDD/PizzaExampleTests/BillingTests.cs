using Xunit;

namespace PizzaExample
{
    public class BillingTests
    {
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
}
