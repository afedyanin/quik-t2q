namespace Trans2QuikAdapter.Tests.Transactions
{
    using System;
    using NUnit.Framework;
    using Trans2QuikAdapter.Transactions;
    using Trans2QuikAdapter.Transactions.Enums;

    // Для запуска тестов нужен Quik-Junior (Демо-версия) с включенной обработкой внешних транзакций
    [TestFixture, Explicit]
    public class TradingGatewayTests
    {
        private const string CONST_QUIK_PATH = @"C:\QUIK-Junior";
        private TradingGateway gateway;

        [SetUp]
        public void Setup()
        {
            this.gateway = new TradingGateway();
            var res = this.gateway.Connect(CONST_QUIK_PATH);
        }

        [TearDown]
        public void TearDown()
        {
            this.gateway.Dispose();
        }

        [Test]
        public void CanDisconnect()
        {
            var res = this.gateway.Disconnect();
#if DEBUG
            Console.WriteLine($"{res.Code}: {res.ExtendedCode} - {res.Message}");
#endif
            Assert.True(res.Code == ResponseCode.SUCCESS);
        }

        [Test]
        public void CanConnectToQuik()
        {
            this.gateway.Disconnect();
            var res = this.gateway.Connect(CONST_QUIK_PATH);
#if DEBUG
            Console.WriteLine($"{res.Code}: {res.ExtendedCode} - {res.Message}");
#endif
            Assert.True(res.Code == ResponseCode.SUCCESS);
        }

        [Test]
        public void CanCheckIfDllConnected()
        {
            var res = this.gateway.IsDllConnected();
#if DEBUG
            Console.WriteLine($"{res.Code}: {res.ExtendedCode} - {res.Message}");
#endif
            Assert.True(res.Code == ResponseCode.DLL_CONNECTED);
        }

        [Test]
        public void CanCheckIfQuikConnected()
        {
            var res = this.gateway.IsQuikConnected();
#if DEBUG
            Console.WriteLine($"{res.Code}: {res.ExtendedCode} - {res.Message}");
#endif
            Assert.True(res.Code == ResponseCode.QUIK_CONNECTED);
        }

        [Test]
        public void CanSetConnectionStatusCallback()
        {
            var res = this.gateway.SetConnectionStatusCallback((rsp) =>
                {
#if DEBUG
                    Console.WriteLine($"{rsp.Code}: {rsp.ExtendedCode} - {rsp.Message}");
#endif
                    Assert.True(rsp.Code == ResponseCode.DLL_DISCONNECTED);
                });

            Assert.True(res.Code == ResponseCode.SUCCESS);

            this.gateway.Disconnect();
        }

        [Test]
        public void SyncTransactionWithWrongFormatReturnsWrongSyntax()
        {
            var reply = this.gateway.SendSyncTransaction("txn");
#if DEBUG
            Console.WriteLine($"{reply.ToJson()}");
#endif
            Assert.True(reply.Response.Code == ResponseCode.WRONG_SYNTAX);
        }

        [Test]
        public void SyncTransactionWithGoodFormatReturnsOk()
        {
            var tran = "TRANS_ID=102; ACTION=NEW_ORDER; CLASSCODE=QJSIM; SECCODE=SBER; OPERATION=B; PRICE=120; ACCOUNT=NL0011100043; QUANTITY=1;";

            var reply = this.gateway.SendSyncTransaction(tran);
#if DEBUG
            Console.WriteLine($"{reply.ToJson()}");
#endif
            Assert.True(reply.Response.Code == ResponseCode.SUCCESS);
        }
    }
}
