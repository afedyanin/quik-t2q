namespace Trans2QuikAdapter.Transactions
{
    using System;
    using System.Runtime.InteropServices;

    internal static class Import
    {
        private const string DLL_NAME = "TRANS2QUIK.DLL";

        #region connection
        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_CONNECT", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Connect(
            string lpcstrConnectionParamsString,
            ref Int32 pnExtendedErrorCode,
            byte[] lpstrErrorMessage,
            UInt32 dwErrorMessageSize);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_DISCONNECT", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Disconnect(
            ref Int32 pnExtendedErrorCode,
            byte[] lpstrErrorMessage,
            UInt32 dwErrorMessageSize);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_IS_DLL_CONNECTED", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 IsDllConnected(
            ref Int32 pnExtendedErrorCode,
            byte[] lpstrErrorMessage,
            UInt32 dwErrorMessageSize);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_IS_QUIK_CONNECTED", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 IsQuikConnected(
             ref Int32 pnExtendedErrorCode,
             byte[] lpstrErrorMessage,
             UInt32 dwErrorMessageSize);

        public delegate void ConnectionStatusCallback(
            Int32 nConnectionEvent, 
            Int32 nExtendedErrorCode, 
            byte[] lpstrInfoMessage);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_SET_CONNECTION_STATUS_CALLBACK", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 SetConnectionStatusCallback(
            ConnectionStatusCallback pfConnectionStatusCallback,
            ref Int32 pnExtendedErrorCode,
            byte[] lpstrErrorMessage,
            UInt32 dwErrorMessageSize);

        #endregion

        #region transactions

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_SEND_SYNC_TRANSACTION", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 SendSyncTransaction(
            string lpstTransactionString,
            ref Int32 pnReplyCode,
            ref UInt32 pdwTransId,
            ref UInt64 pnOrderNum,
            byte[] lpstrResultMessage,
            UInt32 dwResultMessageSize,
            ref Int32 pnExtendedErrorCode,
            byte[] lpstrErrorMessage,
            UInt32 dwErrorMessageSize);


        public delegate void TransactionReplyCallback(
            Int32 nTransactionResult,
            Int32 nTransactionExtendedErrorCode,
            Int32 nTransactionReplyCode,
            UInt32 dwTransId,
            UInt64 dOrderNum,
            [MarshalAs(UnmanagedType.LPStr)] string transactionReplyMessage,
            IntPtr pTransReplyDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_SET_TRANSACTIONS_REPLY_CALLBACK", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 SetTransactionReplyCallback(
            TransactionReplyCallback pfTransactionReplyCallback,
            ref Int32 pnExtendedErrorCode,
            byte[] lpstrErrorMessage,
            UInt32 dwErrorMessageSize);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_SEND_ASYNC_TRANSACTION", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 SendAsyncTransaction(
            [MarshalAs(UnmanagedType.LPStr)]string transactionString,
            ref Int32 nExtendedErrorCode,
            byte[] lpstrErrorMessage,
            UInt32 dwErrorMessageSize);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_CLASS_CODE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TxnReplyGetClassCode(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_SEC_CODE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TxnReplyGetSecCode(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_PRICE", CallingConvention = CallingConvention.StdCall)]
        public static extern Double TxnReplyGetPrice(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_QUANTITY", CallingConvention = CallingConvention.StdCall)]
        public static extern Int64 TxnReplyGetQuantity(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_BALANCE", CallingConvention = CallingConvention.StdCall)]
        public static extern Int64 TxnReplyGetBalance(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_FIRMID", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TxnReplyGetFirmId(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_ACCOUNT", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TxnReplyGetAccount(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_CLIENT_CODE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TxnReplyGetClientCode(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_BROKERREF", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TxnReplyGetBrokerRef(IntPtr tradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRANSACTION_REPLY_EXCHANGE_CODE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TxnReplyGetExchangeCode(IntPtr tradeDescriptor);
        #endregion

        #region orders
        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_SUBSCRIBE_ORDERS", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 SubscribeOrders(
                [MarshalAs(UnmanagedType.LPStr)]string class_code,
                [MarshalAs(UnmanagedType.LPStr)]string sec_code);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_UNSUBSCRIBE_ORDERS", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 UnsubscribeOrders();

        public delegate void OrderStatusCallback(
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
                IntPtr pOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_START_ORDERS", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 StartOrders(OrderStatusCallback pfOrderStatusCallback);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_QTY", CallingConvention = CallingConvention.StdCall)]
        public static extern Int64 OrderGetQuantity(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_DATE", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetDate(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_TIME", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetTime(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_DATE_TIME", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetDateTime(IntPtr nOrderDescriptor, Int32 nTimeType);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_ACTIVATION_TIME", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetActivationTime(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_WITHDRAW_TIME", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetWithdrawTime(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_EXPIRY", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetExpiry(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_ACCRUED_INT", CallingConvention = CallingConvention.StdCall)]
        public static extern double OrderGetAccuredInt(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_YIELD", CallingConvention = CallingConvention.StdCall)]
        public static extern double OrderGetYield(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_UID", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetUid(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_VISIBLE_QTY",  CallingConvention = CallingConvention.StdCall)]
        public static extern Int64 OrderGetVisibleQuantity(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_PERIOD", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetPeriod(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_FILETIME", CallingConvention = CallingConvention.StdCall)]
        public static extern System.Runtime.InteropServices.ComTypes.FILETIME OrderGetFileTime(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_WITHDRAW_FILETIME", CallingConvention = CallingConvention.StdCall)]
        public static extern System.Runtime.InteropServices.ComTypes.FILETIME OrderGetWithdrawFileTime(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_USERID", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr OrderGetUserId(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_ACCOUNT", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr OrderGetAccount(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_BROKERREF", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr OrderGetBrokerRef(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_CLIENT_CODE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr OrderGetClientCode(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_FIRMID", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr OrderGetFirmId(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_VALUE_ENTRY_TYPE", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetValueEntryType(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_EXTENDED_FLAGS", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetExtendedFlags(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_MIN_QTY", CallingConvention = CallingConvention.StdCall)]
        public static extern Int64 OrderGetMinQuantity(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_EXEC_TYPE", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 OrderGetExecType(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_AWG_PRICE", CallingConvention = CallingConvention.StdCall)]
        public static extern double OrderGetAvgPrice(IntPtr nOrderDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_ORDER_REJECT_REASON", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr OrderGetRejectReason(IntPtr nOrderDescriptor);

        #endregion

        #region trades

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_SUBSCRIBE_TRADES", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 SubscribeTrades(
                [MarshalAs(UnmanagedType.LPStr)]string class_code,
                [MarshalAs(UnmanagedType.LPStr)]string sec_code);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_UNSUBSCRIBE_TRADES", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 UnsubscribeTrades();


        public delegate void TradeStatusCallback(
                Int32 nMode,
                UInt64 nNumber,
                UInt64 nOrderNumber,
                [MarshalAs(UnmanagedType.LPStr)]string ClassCode,
                [MarshalAs(UnmanagedType.LPStr)]string SecCode,
                Double dPrice,
                Int64 nQty,
                Double dValue,
                Int32 nIsSell,
                IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_START_TRADES", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 StartTrades(TradeStatusCallback pfTradeStatusCallback);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_DATE", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetDate(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_SETTLE_DATE", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetSettleDate(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_TIME", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetTime(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_IS_MARGINAL", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetIsMarginal(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_ACCRUED_INT", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetAccuredInt(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_YIELD", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetYield(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_TS_COMMISSION", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetTsCommission(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_CLEARING_CENTER_COMMISSION", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetClearingCenterCommission(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_EXCHANGE_COMMISSION", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetExchangeCommission(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_TRADING_SYSTEM_COMMISSION", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetTradingSystemCommission(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_PRICE2", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetPrice2(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_REPO_RATE", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetRepoRate(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_REPO_VALUE", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetRepoValue(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_REPO2_VALUE", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetRepo2Value(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_ACCRUED_INT2", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetAccuredInt2(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_REPO_TERM", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetRepoTerm(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_START_DISCOUNT", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetStartDiscount(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_LOWER_DISCOUNT", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetLowerDiscount(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_UPPER_DISCOUNT", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetUpperDiscount(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_BLOCK_SECURITIES", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetBlockSecurities(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_PERIOD", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetPeriod(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_DATE_TIME", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetDateTime(IntPtr pTradeDescriptor, Int32 nTimeType);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_FILETIME", CallingConvention = CallingConvention.StdCall)]
        public static extern System.Runtime.InteropServices.ComTypes.FILETIME TradeGetFileTime(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_KIND", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetKind(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_CURRENCY", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetCurrency(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_SETTLE_CURRENCY", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetSettleCurrency(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_SETTLE_CODE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetSettleCode(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_ACCOUNT", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetAccount(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_BROKERREF", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetBrokerRef(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_CLIENT_CODE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetClientCode(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_USERID", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetUserId(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_FIRMID", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetFirmId(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_PARTNER_FIRMID", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetPartnerFirmId(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_EXCHANGE_CODE", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetExchangeCode(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_STATION_ID", CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr TradeGetTradeStationId(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_BROKER_COMMISSION", CallingConvention = CallingConvention.StdCall)]
        public static extern double TradeGetBrokerCommission(IntPtr pTradeDescriptor);

        [DllImport(DLL_NAME, EntryPoint = "TRANS2QUIK_TRADE_TRANSID", CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 TradeGetTransId(IntPtr pTradeDescriptor);

        #endregion
    }
}
