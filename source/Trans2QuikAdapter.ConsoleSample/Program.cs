namespace Trans2QuikAdapter.ConsoleSample
{
    using System;
    using Newtonsoft.Json;
    using Trans2QuikAdapter.Orders;
    using Trans2QuikAdapter.Orders.ValueTypes;
    using Trans2QuikAdapter.Transactions;

    static class Program
    {
        private const string CONST_QUIK_PATH = @"C:\QUIK-Junior";

        static void Main(string[] args)
        {
            Console.WriteLine("Start processing transaction...");

            using (var gateway = new TradingGateway())
            {
                Console.WriteLine($"Connecting to {CONST_QUIK_PATH}");
                var response = gateway.Connect(CONST_QUIK_PATH);
                Console.WriteLine($"Connection response: {response.ToJson()}");

                gateway.SubscribeOrders("", "");
                gateway.SubscribeTrades("", "");

                gateway.StartOrders((order) => { Console.WriteLine($"Order: {order.ToJson()}"); });
                gateway.StartTrades((trade) => { Console.WriteLine($"Trade: {trade.ToJson()}"); });

                var tradeOrder = new OrderBuilder()
                    .TransId(14)
                    .Action(OrderAction.NewOrder)
                    .ClassCode("QJSIM")
                    .SecCode("SBER")
                    .Operation(Operation.Buy)
                    .Price(0.0)
                    .Quantity(37)
                    .Account("NL0011100043")
                    .Type(OrderType.Market);

                gateway.SendAsyncTransaction(tradeOrder.ToString());
            }

            Console.WriteLine("Press ENTER to exit...");
            Console.ReadLine();
        }

        public static string ToJson(this object entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}
