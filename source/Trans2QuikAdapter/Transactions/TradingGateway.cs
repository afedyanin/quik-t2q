namespace Trans2QuikAdapter.Transactions
{
    using System;
    using System.Runtime.InteropServices;
    using Trans2QuikAdapter.Transactions.Entities;
    using Trans2QuikAdapter.Transactions.Enums;

    public class TradingGateway : IDisposable
    {
        private const uint CONST_MessageSize = 512U;

        private Action<Response> connectionStatusCallback;
        private GCHandle connectionStatusCallbackHandle;

        private Action<TransactionReply> transactionReplyCallback;
        private GCHandle transactionReplyCallbackHandle;  

        private Action<OrderStatus> orderStatusCallback;
        private GCHandle orderStatusCallbackHandle; 

        private Action<TradeStatus> tradeStatusCallback;
        private GCHandle tradeStatusCallbackHandle; 

        private bool disposed;

        public Response Connect(string path2Quik)
        {
            var errorMessage = new Byte[CONST_MessageSize];
            var errorCode = 0;
            var code = (ResponseCode)Import.Connect(path2Quik, ref errorCode, errorMessage, (uint)errorMessage.Length);
            return new Response(code, errorCode, errorMessage);
        }

        public Response Disconnect()
        {
            var errorMessage = new Byte[CONST_MessageSize];
            var errorCode = 0;
            var code = (ResponseCode)Import.Disconnect(ref errorCode, errorMessage, (uint)errorMessage.Length);
            return new Response(code, errorCode, errorMessage);
        }

        public Response IsDllConnected()
        {
            var errorMessage = new Byte[CONST_MessageSize];
            var errorCode = 0;
            var code = (ResponseCode)Import.IsDllConnected(ref errorCode, errorMessage, (uint)errorMessage.Length);
            return new Response(code, errorCode, errorMessage);
        }

        public Response IsQuikConnected()
        {
            var errorMessage = new Byte[CONST_MessageSize];
            var errorCode = 0;
            var code = (ResponseCode)Import.IsQuikConnected(ref errorCode, errorMessage, (uint)errorMessage.Length);
            return new Response(code, errorCode, errorMessage);
        }

        public Response SetConnectionStatusCallback(Action<Response> connectionStatusCallback)
        {
            this.connectionStatusCallback = connectionStatusCallback;
            var connCallback = new Import.ConnectionStatusCallback(ConnectionStatusCallbackImpl);

            if (this.connectionStatusCallbackHandle.IsAllocated)
            {
                this.connectionStatusCallbackHandle.Free();
            }

            this.connectionStatusCallbackHandle = GCHandle.Alloc(connCallback);

            var errorMessage = new Byte[CONST_MessageSize];
            var errorCode = 0;
            var code = (ResponseCode)Import.SetConnectionStatusCallback(connCallback, ref errorCode, errorMessage, (uint)errorMessage.Length);
            return new Response(code, errorCode, errorMessage);
        }

        public TransactionReply SendSyncTransaction(string transaction)
        {
            var errorMessage = new Byte[CONST_MessageSize];
            var errorCode = 0;
            var replyCode = 0;
            var transId = 0U;
            var orderNum= 0UL;
            var resultMessage = new Byte[CONST_MessageSize];

            var code = (ResponseCode)Import.SendSyncTransaction(
                transaction,
                ref replyCode,
                ref transId,
                ref orderNum,
                resultMessage,
                (uint)resultMessage.Length,
                ref errorCode, errorMessage, (uint)errorMessage.Length);

            return EntityFactory.CreateSyncTransactionReply(code, errorCode, errorMessage, replyCode, transId, orderNum, resultMessage);
        }

        public Response SetAsyncTransactionReplyCallback(Action<TransactionReply> replyCallback)
        {
            this.transactionReplyCallback = replyCallback;
            var transCallback = new Import.TransactionReplyCallback(TransactionReplyCallbackImpl);

            if (this.transactionReplyCallbackHandle.IsAllocated)
            {
                this.transactionReplyCallbackHandle.Free();
            }

            this.transactionReplyCallbackHandle = GCHandle.Alloc(transCallback);

            var errorMessage = new Byte[CONST_MessageSize];
            var errorCode = 0;
            var code = (ResponseCode)Import.SetTransactionReplyCallback(transCallback, ref errorCode, errorMessage, (uint)errorMessage.Length);
            return new Response(code, errorCode, errorMessage);
        }

        public Response SendAsyncTransaction(string transaction)
        {
            var errorMessage = new Byte[CONST_MessageSize];
            var errorCode = 0;
            var code = (ResponseCode)Import.SendAsyncTransaction(transaction, ref errorCode, errorMessage, (uint)errorMessage.Length);
            return new Response(code, errorCode, errorMessage);
        }

        public ResponseCode SubscribeOrders(string classCode, string securityCodes)
        {
            return (ResponseCode)Import.SubscribeOrders(classCode, securityCodes);
        }

        public ResponseCode UnSubscribeOrders()
        {
            return (ResponseCode)Import.UnsubscribeOrders();
        }

        public void StartOrders(Action<OrderStatus> orderStatusCallback)
        {
            this.orderStatusCallback = orderStatusCallback;
            var orderCallback = new Import.OrderStatusCallback(OrderStatusCallbackImpl);

            if (this.orderStatusCallbackHandle.IsAllocated)
            {
                this.orderStatusCallbackHandle.Free();
            }

            this.orderStatusCallbackHandle = GCHandle.Alloc(orderCallback);
            Import.StartOrders(orderCallback);
        }

        public ResponseCode SubscribeTrades(string classCode, string securityCodes)
        {
            return (ResponseCode)Import.SubscribeTrades(classCode, securityCodes);
        }

        public ResponseCode UnSubscribeTrades()
        {
            return (ResponseCode)Import.UnsubscribeTrades();
        }

        public void StartTrades(Action<TradeStatus> tradeStatusCallback)
        {
            this.tradeStatusCallback = tradeStatusCallback;
            var tradeCallback = new Import.TradeStatusCallback(TradeStatusCallbackImpl);

            if (this.tradeStatusCallbackHandle.IsAllocated)
            {
                this.tradeStatusCallbackHandle.Free();
            }

            this.tradeStatusCallbackHandle = GCHandle.Alloc(tradeCallback);
            Import.StartTrades(tradeCallback);
        }

        protected virtual void ConnectionStatusCallbackImpl(
            Int32 nConnectionEvent,
            Int32 nExtendedErrorCode,
            byte[] lpstrInfoMessage)
        {
            if (this.connectionStatusCallback == null)
            {
                return;
            }

            var response = new Response((ResponseCode)nConnectionEvent, nExtendedErrorCode, lpstrInfoMessage);
            this.connectionStatusCallback.Invoke(response);
        }

        protected virtual void TransactionReplyCallbackImpl(
            Int32 nTransactionResult,
            Int32 nTransactionExtendedErrorCode,
            Int32 nTransactionReplyCode,
            UInt32 dwTransId,
            UInt64 nOrderNum,
            [MarshalAs(UnmanagedType.LPStr)] string transactionReplyMessage,
            IntPtr pTransactionReplyDescriptor)
        {
            if (this.transactionReplyCallback == null)
            {
                return;
            }

            var txnReply = EntityFactory.CreateTransactionReplyExtended(
                nTransactionResult,
                nTransactionExtendedErrorCode,
                nTransactionReplyCode,
                dwTransId,
                nOrderNum,
                transactionReplyMessage,
                pTransactionReplyDescriptor);

            this.transactionReplyCallback.Invoke(txnReply);
        }

        protected virtual void OrderStatusCallbackImpl(
                Int32 nMode,
                Int32 dwTransId,
                UInt64 nOrderNum,
                [MarshalAs(UnmanagedType.LPStr)]string ClassCode,
                [MarshalAs(UnmanagedType.LPStr)]string SecCode,
                Double dPrice,
                Int64 nBalance,
                Double dValue,
                Int32 nIsSell,
                Int32 nStatus,
                IntPtr pOrderDescriptor)
        {
            if (this.orderStatusCallback == null)
            {
                return;
            }

            var orderStatus = EntityFactory.CreateOrderStatusExtended(
                nMode,
                dwTransId,
                nOrderNum,
                ClassCode,
                SecCode,
                dPrice,
                nBalance,
                dValue,
                nIsSell,
                nStatus,
                pOrderDescriptor);

            this.orderStatusCallback.Invoke(orderStatus);
        }

        protected virtual void TradeStatusCallbackImpl(
                Int32 nMode,
                UInt64 nNumber,
                UInt64 nOrderNumber,
                [MarshalAs(UnmanagedType.LPStr)]string ClassCode,
                [MarshalAs(UnmanagedType.LPStr)]string SecCode,
                Double dPrice,
                Int64 nQty,
                Double dValue,
                Int32 nIsSell,
                IntPtr pTradeDescriptor)
        {
            if (this.tradeStatusCallback == null)
            {
                return;
            }

            var tradeStatus = EntityFactory.CreateTradeStatusExtended(
                nMode,
                nNumber,
                nOrderNumber,
                ClassCode,
                SecCode,
                dPrice,
                nQty,
                dValue,
                nIsSell,
                pTradeDescriptor);

            this.tradeStatusCallback.Invoke(tradeStatus);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing)
            {
                if (this.connectionStatusCallbackHandle.IsAllocated)
                {
                    this.connectionStatusCallbackHandle.Free();
                }

                if (this.transactionReplyCallbackHandle.IsAllocated)
                {
                    this.transactionReplyCallbackHandle.Free();
                }

                if (this.orderStatusCallbackHandle.IsAllocated)
                {
                    this.orderStatusCallbackHandle.Free();
                }

                if (this.tradeStatusCallbackHandle.IsAllocated)
                {
                    this.tradeStatusCallbackHandle.Free();
                }

                this.disposed = true;
            }
        }
    }
}