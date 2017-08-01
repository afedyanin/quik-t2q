# Quik-T2Q #

Trans2Quik API C# Library

Коннектор к торговому терминалу ARQA QUIK (Квик), который делает доступным API транзакций из .NET (C#)

Требования к системе

* Платформа x64 
* Windows 7 или выше
* .Net Framework 4.5.2 или выше
* версия Рабочего места QUIK 7.0 и выше

Sample code:

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


## NuGet

[NuGet package](https://www.nuget.org/packages/Trans2QuikAdapter)

To install Trans2QuikAdapter, run the following command in the Package Manager Console


    PM> Install-Package Trans2QuikAdapter

       
## Quik

QUIK workstation and trademark are owned by ARQA Technologies. This project is not affiliated with the company in any way.

## Links

[QUIK - Файловый архив](https://arqatech.com/ru/support/files/) 

[API импорта транзакций 1.3 x64 (для версии Рабочего места QUIK 7.0 и выше)](https://arqatech.com/upload/iblock/80a/Trans2QuikAPI_1.3_x64.zip) 


