namespace Trans2QuikAdapter.Tests.Orders
{
    using System;
    using NUnit.Framework;
    using Trans2QuikAdapter.Orders;
    using Trans2QuikAdapter.Orders.ValueTypes;

    [TestFixture]
    public class OrderTests
    {
        [Test]
        public void CanCreateSimpleOrder()
        {
            var order = new OrderBuilder()
                .ClassCode("QJSIM")
                .SecCode("SBER")
                .Action(OrderAction.NewOrder)
                .Operation(Operation.Buy)
                .Quantity(1)
                .Price(120);

            var orderString = order.ToString();

            Assert.True(orderString.Contains("QJSIM"));
            Assert.True(orderString.Contains("SBER"));
            Assert.True(orderString.Contains(OrderAction.NewOrder.Name));
            Assert.True(orderString.Contains(Operation.Buy.Name));
            Assert.True(orderString.Contains(1.ToString()));
            Assert.True(orderString.Contains(120.ToString()));

#if DEBUG
            Console.WriteLine($"Order: {order}");
#endif
        }

        [Test]
        public void CanCreateMarketOrder()
        {

            var order = new OrderBuilder()
                .ClassCode("QJSIM")
                .SecCode("SBER")
                .Action(OrderAction.NewOrder)
                .Operation(Operation.Buy)
                .Quantity(35)
                .Price(120.45)
                .Type(OrderType.Market);

            var orderString = order.ToString();

            Assert.True(orderString.Contains("M"));

#if DEBUG
            Console.WriteLine($"Order: {order}");
#endif
        }

    }
}
