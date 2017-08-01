namespace Trans2QuikAdapter.Transactions
{
    using System;
    using System.Runtime.InteropServices;
    using Trans2QuikAdapter.Transactions.Entities;
    using Trans2QuikAdapter.Transactions.Enums;
    using Trans2QuikAdapter.Transactions.Helpers;

    internal static class EntityFactory
    {
        public static TransactionReply CreateSyncTransactionReply(
            ResponseCode responseCode,
            Int32 extendedErrorCode,
            byte[] errorMessage,
            Int32 replyCode,
            UInt32 transId,
            UInt64 orderNum,
            byte[] resultMessage)
        {
            return new TransactionReply
            {
                Response = new Response(responseCode, extendedErrorCode, errorMessage),
                ReplyCode = replyCode,
                TransId = transId,
                OrderNum = orderNum,
                Message = resultMessage.ByteToString()
            };
        }

        public static TransactionReply CreateTransactionReply(
            Int32 nTransactionResult,
            Int32 nTransactionExtendedErrorCode,
            Int32 nTransactionReplyCode,
            UInt32 dwTransId,
            UInt64 nOrderNum,
            [MarshalAs(UnmanagedType.LPStr)] string transactionReplyMessage,
            IntPtr pTransactionReplyDescriptor)
        {
            var txnReply = new TransactionReply
            {
                Response = new Response((ResponseCode)nTransactionResult, nTransactionExtendedErrorCode, null),
                ReplyCode = nTransactionReplyCode,
                TransId = dwTransId,
                OrderNum = nOrderNum,
                Message = transactionReplyMessage,
                Descriptor = Ptr2Str(pTransactionReplyDescriptor)
            };

            return txnReply;
        }

        public static TransactionReply CreateTransactionReplyExtended(
            Int32 nTransactionResult,
            Int32 nTransactionExtendedErrorCode,
            Int32 nTransactionReplyCode,
            UInt32 dwTransId,
            UInt64 nOrderNum,
            [MarshalAs(UnmanagedType.LPStr)] string transactionReplyMessage,
            IntPtr pTransactionReplyDescriptor)
        {
            var txnReply = CreateTransactionReply(
                nTransactionResult,
                nTransactionExtendedErrorCode,
                nTransactionReplyCode,
                dwTransId,
                nOrderNum,
                transactionReplyMessage,
                pTransactionReplyDescriptor);

            return FillTransactionReplyExtendedProps(txnReply, pTransactionReplyDescriptor);
        }

        private static TransactionReply FillTransactionReplyExtendedProps(TransactionReply txnReply, IntPtr pTransactionReplyDescriptor)
        {
            txnReply.ClassCode = Ptr2Str(Import.TxnReplyGetClassCode(pTransactionReplyDescriptor));
            txnReply.SecCode = Ptr2Str(Import.TxnReplyGetSecCode(pTransactionReplyDescriptor));
            txnReply.Price = Import.TxnReplyGetPrice(pTransactionReplyDescriptor);
            txnReply.Quantity = Import.TxnReplyGetQuantity(pTransactionReplyDescriptor);
            txnReply.Balance = Import.TxnReplyGetBalance(pTransactionReplyDescriptor);
            txnReply.FrimId = Ptr2Str(Import.TxnReplyGetFirmId(pTransactionReplyDescriptor));
            txnReply.Account = Ptr2Str(Import.TxnReplyGetAccount(pTransactionReplyDescriptor));
            txnReply.ClientCode = Ptr2Str(Import.TxnReplyGetClientCode(pTransactionReplyDescriptor));
            txnReply.BrokerRef = Ptr2Str(Import.TxnReplyGetBrokerRef(pTransactionReplyDescriptor));
            txnReply.ExchangeCode = Ptr2Str(Import.TxnReplyGetExchangeCode(pTransactionReplyDescriptor));

            return txnReply;
        }

        public static OrderStatus CreateOrderStatus(
            Int32 nMode,
            Int32 dwTransId,
            UInt64 nOrderNum,
            [MarshalAs(UnmanagedType.LPStr)]string classCode,
            [MarshalAs(UnmanagedType.LPStr)]string secCode,
            Double dPrice,
            Int64 nBalance,
            Double dValue,
            Int32 nIsSell,
            Int32 nStatus,
            IntPtr pOrderDescriptor)
        {
            var orderStatus = new OrderStatus
            {
                Mode = nMode,
                TransId = dwTransId,
                Number = nOrderNum,
                ClassCode = classCode,
                SecCode = secCode,
                Price = dPrice,
                Balance = nBalance,
                Value = dValue,
                IsSell = nIsSell,
                Status = nStatus,
                Descriptor = Ptr2Str(pOrderDescriptor)
            };

            return orderStatus;
        }

        public static OrderStatus CreateOrderStatusExtended(
            Int32 nMode,
            Int32 dwTransId,
            UInt64 nOrderNum,
            [MarshalAs(UnmanagedType.LPStr)]string classCode,
            [MarshalAs(UnmanagedType.LPStr)]string secCode,
            Double dPrice,
            Int64 nBalance,
            Double dValue,
            Int32 nIsSell,
            Int32 nStatus,
            IntPtr pOrderDescriptor)
        {
            var orderStatus = CreateOrderStatus(
                nMode, 
                dwTransId, 
                nOrderNum, 
                classCode, 
                secCode, 
                dPrice, 
                nBalance, 
                dValue, 
                nIsSell, 
                nStatus, 
                pOrderDescriptor);

            return FillOrderStatusExtendedProps(orderStatus, pOrderDescriptor);
        }

        private static OrderStatus FillOrderStatusExtendedProps(OrderStatus orderStatus, IntPtr pOrderDescriptor)
        {
            orderStatus.Quantity = Import.OrderGetQuantity(pOrderDescriptor);
            orderStatus.Date = Import.OrderGetDate(pOrderDescriptor);
            orderStatus.Time = Import.OrderGetTime(pOrderDescriptor);
            orderStatus.TimeMicroSec = Import.OrderGetDateTime(pOrderDescriptor, (int)OrderTime.Microsec);
            orderStatus.WithdrawDate = Import.OrderGetDateTime(pOrderDescriptor, (int)OrderTime.WithdrawQuikDate);
            orderStatus.WithdrawTime = Import.OrderGetWithdrawTime(pOrderDescriptor);
            orderStatus.WithdrawTimeMicroSec = Import.OrderGetDateTime(pOrderDescriptor, (int)OrderTime.WithDrawMicrosec);
            orderStatus.ActivationTime = Import.OrderGetActivationTime(pOrderDescriptor);
            orderStatus.Expiry = Import.OrderGetExpiry(pOrderDescriptor);
            orderStatus.AccuredInt = Import.OrderGetAccuredInt(pOrderDescriptor);
            orderStatus.Yield = Import.OrderGetYield(pOrderDescriptor);
            orderStatus.Uid = Import.OrderGetUid(pOrderDescriptor);
            orderStatus.VisibleQuantity = Import.OrderGetVisibleQuantity(pOrderDescriptor);
            orderStatus.Period = Import.OrderGetPeriod(pOrderDescriptor);
            orderStatus.FileTime = GetDateTime(Import.OrderGetFileTime(pOrderDescriptor));
            orderStatus.WithdrawFileTime = GetDateTime(Import.OrderGetWithdrawFileTime(pOrderDescriptor));
            orderStatus.ValueEntryType = Import.OrderGetValueEntryType(pOrderDescriptor);
            orderStatus.ExtendedFlags = Import.OrderGetExtendedFlags(pOrderDescriptor);
            orderStatus.MinQuantity = Import.OrderGetMinQuantity(pOrderDescriptor);
            orderStatus.ExecType = Import.OrderGetExecType(pOrderDescriptor);
            orderStatus.AvgPrice = Import.OrderGetAvgPrice(pOrderDescriptor);

            try
            {
                orderStatus.UserId = Ptr2Str(Import.OrderGetUserId(pOrderDescriptor));
                orderStatus.Account = Ptr2Str(Import.OrderGetAccount(pOrderDescriptor));
                orderStatus.BrokerRef = Ptr2Str(Import.OrderGetBrokerRef(pOrderDescriptor));
                orderStatus.ClientCode = Ptr2Str(Import.OrderGetClientCode(pOrderDescriptor));
                orderStatus.FirmId = Ptr2Str(Import.OrderGetFirmId(pOrderDescriptor));
                orderStatus.RejectReason = Ptr2Str(Import.OrderGetRejectReason(pOrderDescriptor));
            }
            catch (AccessViolationException)
            {
                // TODO: Handle exception
            }

            return orderStatus;
        }

        public static TradeStatus CreateTradeStatus(
                Int32 nMode,
                UInt64 nNumber,
                UInt64 nOrderNumber,
                [MarshalAs(UnmanagedType.LPStr)]string classCode,
                [MarshalAs(UnmanagedType.LPStr)]string secCode,
                Double dPrice,
                Int64 nQty,
                Double dValue,
                Int32 nIsSell,
                IntPtr pTradeDescriptor)
        {
            var tradeStatus = new TradeStatus
            {
                Mode = nMode,
                Number = nNumber,
                OrderNumber = nOrderNumber,
                ClassCode = classCode,
                SecCode = secCode,
                Price = dPrice,
                Quantity = nQty,
                Value = dValue,
                IsSell = nIsSell,
                Descriptor = Ptr2Str(pTradeDescriptor)
            };

            return tradeStatus;
        }

        public static TradeStatus CreateTradeStatusExtended(
                Int32 nMode,
                UInt64 nNumber,
                UInt64 nOrderNumber,
                [MarshalAs(UnmanagedType.LPStr)]string classCode,
                [MarshalAs(UnmanagedType.LPStr)]string secCode,
                Double dPrice,
                Int64 nQty,
                Double dValue,
                Int32 nIsSell,
                IntPtr pTradeDescriptor)
        {
            var tradeStatus = CreateTradeStatus(
                nMode, 
                nNumber, 
                nOrderNumber, 
                classCode, 
                secCode, 
                dPrice, 
                nQty, 
                dValue, 
                nIsSell, 
                pTradeDescriptor);

            return FillTradeStatusExtendedProps(tradeStatus, pTradeDescriptor);
        }

        private static TradeStatus FillTradeStatusExtendedProps(TradeStatus tradeStatus, IntPtr pTradeDescriptor)
        {
            tradeStatus.Date = Import.TradeGetDate(pTradeDescriptor);
            tradeStatus.SettleDate = Import.TradeGetSettleDate(pTradeDescriptor);
            tradeStatus.Time = Import.TradeGetTime(pTradeDescriptor);
            tradeStatus.IsMarginal = Import.TradeGetIsMarginal(pTradeDescriptor);
            tradeStatus.AccuredInt = Import.TradeGetAccuredInt(pTradeDescriptor);
            tradeStatus.Yield = Import.TradeGetYield(pTradeDescriptor);
            tradeStatus.TsCommission = Import.TradeGetTsCommission(pTradeDescriptor);
            tradeStatus.ClearingCenterCommission = Import.TradeGetClearingCenterCommission(pTradeDescriptor);
            tradeStatus.ExchangeCommission = Import.TradeGetExchangeCommission(pTradeDescriptor);
            tradeStatus.TradingSystemCommission = Import.TradeGetTradingSystemCommission(pTradeDescriptor);
            tradeStatus.Price2 = Import.TradeGetPrice2(pTradeDescriptor);
            tradeStatus.RepoRate = Import.TradeGetRepoRate(pTradeDescriptor);
            tradeStatus.RepoValue = Import.TradeGetRepoValue(pTradeDescriptor);
            tradeStatus.Repo2Value = Import.TradeGetRepo2Value(pTradeDescriptor);
            tradeStatus.AccuredInt2 = Import.TradeGetAccuredInt2(pTradeDescriptor);
            tradeStatus.RepoTerm = Import.TradeGetRepoTerm(pTradeDescriptor);
            tradeStatus.StartDiscount = Import.TradeGetStartDiscount(pTradeDescriptor);
            tradeStatus.LowerDiscount = Import.TradeGetLowerDiscount(pTradeDescriptor);
            tradeStatus.UpperDiscount = Import.TradeGetUpperDiscount(pTradeDescriptor);
            tradeStatus.BlockSecurities = Import.TradeGetBlockSecurities(pTradeDescriptor);
            tradeStatus.Period = Import.TradeGetPeriod(pTradeDescriptor);
            tradeStatus.TimeMicroSec = Import.TradeGetDateTime(pTradeDescriptor, (int)TradeTime.Microsec);
            tradeStatus.FileTime = GetDateTime(Import.TradeGetFileTime(pTradeDescriptor));
            tradeStatus.Kind = Import.TradeGetKind(pTradeDescriptor);
            tradeStatus.Currency = Ptr2Str(Import.TradeGetCurrency(pTradeDescriptor));
            tradeStatus.SettleCurrency = Ptr2Str(Import.TradeGetSettleCurrency(pTradeDescriptor));
            tradeStatus.SettleCode = Ptr2Str(Import.TradeGetSettleCode(pTradeDescriptor));
            tradeStatus.Account = Ptr2Str(Import.TradeGetAccount(pTradeDescriptor));
            tradeStatus.BrokerRef = Ptr2Str(Import.TradeGetBrokerRef(pTradeDescriptor));
            tradeStatus.ClientCode = Ptr2Str(Import.TradeGetClientCode(pTradeDescriptor));
            tradeStatus.UserId = Ptr2Str(Import.TradeGetUserId(pTradeDescriptor));
            tradeStatus.FirmId = Ptr2Str(Import.TradeGetFirmId(pTradeDescriptor));
            tradeStatus.PartnerFirmId = Ptr2Str(Import.TradeGetPartnerFirmId(pTradeDescriptor));
            tradeStatus.ExchangeCode = Ptr2Str(Import.TradeGetExchangeCode(pTradeDescriptor));
            tradeStatus.TradeStationId = Ptr2Str(Import.TradeGetTradeStationId(pTradeDescriptor));
            tradeStatus.BrokerCommission = Import.TradeGetBrokerCommission(pTradeDescriptor);
            tradeStatus.TransId = Import.TradeGetTransId(pTradeDescriptor);

            return tradeStatus;
        }

        private static string Ptr2Str(IntPtr ptr)
        {
            return Marshal.PtrToStringAnsi(ptr);
        }

        private static DateTime GetDateTime(System.Runtime.InteropServices.ComTypes.FILETIME filetime)
        {
            long high = filetime.dwHighDateTime;
            long ft = (high << 32) + filetime.dwLowDateTime;

            return DateTime.FromFileTimeUtc(ft);
        }
    }
}
