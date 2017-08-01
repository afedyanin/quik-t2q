namespace Trans2QuikAdapter.Tests.Orders
{
    using System;
    using NUnit.Framework;
    using Trans2QuikAdapter.Orders;
    using Trans2QuikAdapter.Orders.ValueTypes;

    [TestFixture]
    public class FormatTests
    {
        [Test]
        public void CanCreateDateString()
        {
            var date = new DateTime(2017, 5, 7, 0, 0, 0);
            var order = new OrderBuilder().SettleDate(date);
            var orderString = order.ToString();

#if DEBUG
            Console.WriteLine($"orderString={orderString}");
#endif
            Assert.True(orderString.Contains("20170507"));
        }

        [Test]
        public void CanCreateTimeString()
        {
            var time = new DateTime(2017, 5, 7, 13, 48, 39);
            var order = new OrderBuilder().ActiveToTime(time);
            var orderString = order.ToString();

#if DEBUG
            Console.WriteLine($"orderString={orderString}");
#endif
            Assert.True(orderString.Contains("134839"));
        }

        [TestCase(125.56)]
        [TestCase(3.897413)]
        [TestCase(0.0012)]
        [TestCase(34.100001)]
        [TestCase(12)]
        [TestCase(13.2)]
        public void CanCreatePriceString(double price)
        {
            var order = new OrderBuilder().Price(price);
            var orderString = order.ToString();
#if DEBUG
            Console.WriteLine($"price={price}  restored={price}");
            Console.WriteLine($"orderString={orderString}");
#endif
            Assert.True(orderString.Contains(price.ToString()));
        }

        [Test]
        public void CanSetSpecificExpiryDate()
        {
            var date = new DateTime(2017, 5, 7, 0, 0, 0);
            var expDate = new ExpiryDate(date);
            var order = new OrderBuilder().ExpiryDate(expDate);

            var orderString = order.ToString();

#if DEBUG
            Console.WriteLine($"orderString={orderString}");
#endif
            Assert.True(orderString.Contains("20170507"));
        }

        [Test]
        public void CanSetGTCExpiryDate()
        {
            var order = new OrderBuilder().ExpiryDate(ExpiryDate.GTC);
            var orderString = order.ToString();

#if DEBUG
            Console.WriteLine($"orderString={orderString}");
#endif
            Assert.True(orderString.Contains("GTC"));
        }

        [Test]
        public void CanSetYes()
        {
            var order = new OrderBuilder().MarketMakerOrder(true);
            var orderString = order.ToString();

#if DEBUG
            Console.WriteLine($"orderString={orderString}");
#endif
            Assert.True(orderString.Contains("YES"));
        }

        [Test]
        public void CanSetNo()
        {
            var order = new OrderBuilder().MarketMakerOrder(false);
            var orderString = order.ToString();

#if DEBUG
            Console.WriteLine($"orderString={orderString}");
#endif
            Assert.True(orderString.Contains("NO"));
        }
    }
}
