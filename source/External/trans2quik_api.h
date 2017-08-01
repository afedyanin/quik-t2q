#pragma once

#ifdef TRANS2QUIK_EXPORTS
#define TRANS2QUIK_API __declspec (dllexport)
#pragma message ("TRANS2QUIK_API defined as __declspec (dllexport)")
#else
//#pragma message ("TRANS2QUIK_API defined as __declspec (dllimport)")
#define TRANS2QUIK_API __declspec (dllimport)
#endif

#ifdef __cplusplus
extern "C" {
#endif

typedef __int64 Quantity;
typedef unsigned __int64 EntityNumber;
typedef intptr_t OrderDescriptor;
typedef intptr_t TradeDescriptor;
typedef intptr_t TransactionReplyDescriptor;

typedef void (__stdcall *TRANS2QUIK_CONNECTION_STATUS_CALLBACK) (
							long nConnectionEvent
							, long nExtendedErrorCode
							, LPCSTR lpcstrInfoMessage);

typedef void (__stdcall *TRANS2QUIK_TRANSACTION_REPLY_CALLBACK) (
							long nTransactionResult
							, long nTransactionExtendedErrorCode
							, long nTransactionReplyCode
							, DWORD dwTransId
							, EntityNumber nOrderNum
							, LPCSTR lpcstrTransactionReplyMessage
							, TransactionReplyDescriptor transReplyDescriptor);

typedef void (__stdcall *TRANS2QUIK_ORDER_STATUS_CALLBACK) (
							long nMode
							, DWORD dwTransID
							, EntityNumber dNumber
							, LPCSTR ClassCode
							, LPCSTR SecCode
							, double dPrice
							, Quantity  nBalance
							, double dValue
							, long nIsSell
							, long nStatus
							, OrderDescriptor orderDescriptor);

typedef void (__stdcall *TRANS2QUIK_TRADE_STATUS_CALLBACK)      (
							long nMode
							, EntityNumber dNumber
							, EntityNumber dOrderNumber
							, LPCSTR ClassCode
							, LPCSTR SecCode
							, double dPrice
							, Quantity nQty
							, double dValue
							, long nIsSell
							, TradeDescriptor tradeDescriptor);


//typedef void (__stdcall *TRANS2QUIK_CONNECTION_STATUS_CALLBACK) (long nConnectionEvent, long nExtendedErrorCode, LPSTR lpstrInfoMessage);
//typedef void (__stdcall *TRANS2QUIK_TRANSACTION_REPLY_CALLBACK) (long nTransactionResult, long nTransactionExtendedErrorCode, long nTransactionReplyCode, DWORD dwTransId, double dOrderNum, LPSTR lpstrTransactionReplyMessage);

#define TRANS2QUIK_SUCCESS						0
#define TRANS2QUIK_FAILED						1
#define TRANS2QUIK_QUIK_TERMINAL_NOT_FOUND		2
#define TRANS2QUIK_DLL_VERSION_NOT_SUPPORTED	3
#define TRANS2QUIK_ALREADY_CONNECTED_TO_QUIK	4
#define TRANS2QUIK_WRONG_SYNTAX					5
#define TRANS2QUIK_QUIK_NOT_CONNECTED			6
#define TRANS2QUIK_DLL_NOT_CONNECTED			7
#define TRANS2QUIK_QUIK_CONNECTED				8
#define TRANS2QUIK_QUIK_DISCONNECTED			9
#define TRANS2QUIK_DLL_CONNECTED				10
#define TRANS2QUIK_DLL_DISCONNECTED				11
#define TRANS2QUIK_MEMORY_ALLOCATION_ERROR		12
#define TRANS2QUIK_WRONG_CONNECTION_HANDLE		13
#define TRANS2QUIK_WRONG_INPUT_PARAMS			14

#define ORDER_QUIKDATE                          0
#define ORDER_QUIKTIME                          1  
#define ORDER_MICROSEC                          2
#define ORDER_WITHDRAW_QUIKDATE                 3
#define ORDER_WITHDRAW_QUIKTIME                 4
#define ORDER_WITHDRAW_MICROSEC                 5

long TRANS2QUIK_API __stdcall TRANS2QUIK_SEND_SYNC_TRANSACTION (LPSTR lpstTransactionString, long* pnReplyCode, PDWORD pdwTransId, EntityNumber* pnOrderNum, LPSTR lpstrResultMessage, DWORD dwResultMessageSize, long* pnExtendedErrorCode, LPSTR lpstErrorMessage, DWORD dwErrorMessageSize);
long TRANS2QUIK_API __stdcall TRANS2QUIK_SEND_ASYNC_TRANSACTION (LPSTR lpstTransactionString, long* pnExtendedErrorCode, LPSTR lpstErrorMessage, DWORD dwErrorMessageSize);
long TRANS2QUIK_API __stdcall TRANS2QUIK_CONNECT (LPSTR lpstConnectionParamsString, long* pnExtendedErrorCode, LPSTR lpstrErrorMessage, DWORD dwErrorMessageSize);
long TRANS2QUIK_API __stdcall TRANS2QUIK_DISCONNECT (long* pnExtendedErrorCode, LPSTR lpstrErrorMessage, DWORD dwErrorMessageSize);
long TRANS2QUIK_API __stdcall TRANS2QUIK_SET_CONNECTION_STATUS_CALLBACK (TRANS2QUIK_CONNECTION_STATUS_CALLBACK pfConnectionStatusCallback, long* pnExtendedErrorCode, LPSTR lpstrErrorMessage, DWORD dwErrorMessageSize);
long TRANS2QUIK_API __stdcall TRANS2QUIK_SET_TRANSACTIONS_REPLY_CALLBACK (TRANS2QUIK_TRANSACTION_REPLY_CALLBACK pfTransactionReplyCallback, long* pnExtendedErrorCode, LPSTR lpstrErrorMessage, DWORD dwErrorMessageSize);
long TRANS2QUIK_API __stdcall TRANS2QUIK_IS_QUIK_CONNECTED (long* pnExtendedErrorCode, LPSTR lpstrErrorMessage, DWORD dwErrorMessageSize);
long TRANS2QUIK_API __stdcall TRANS2QUIK_IS_DLL_CONNECTED (long* pnExtendedErrorCode, LPSTR lpstrErrorMessage, DWORD dwErrorMessageSize);

long TRANS2QUIK_API __stdcall TRANS2QUIK_SUBSCRIBE_ORDERS (LPSTR ClassCode, LPSTR Seccodes);
long TRANS2QUIK_API __stdcall TRANS2QUIK_UNSUBSCRIBE_ORDERS ();
long TRANS2QUIK_API __stdcall TRANS2QUIK_START_ORDERS (TRANS2QUIK_ORDER_STATUS_CALLBACK pfnOrderStatusCallback);

Quantity TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_QTY (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_DATE (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_TIME (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_ACTIVATION_TIME (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_WITHDRAW_TIME (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_EXPIRY (OrderDescriptor orderDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_ACCRUED_INT (OrderDescriptor orderDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_YIELD (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_UID (OrderDescriptor orderDescriptor);

Quantity  TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_VISIBLE_QTY (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_PERIOD (OrderDescriptor orderDescriptor);
FILETIME TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_FILETIME (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_DATE_TIME (OrderDescriptor orderDescriptor, long nTimeType);
FILETIME TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_WITHDRAW_FILETIME (OrderDescriptor orderDescriptor);

long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_VALUE_ENTRY_TYPE(OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_EXTENDED_FLAGS(OrderDescriptor orderDescriptor);
Quantity  TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_MIN_QTY (OrderDescriptor orderDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_EXEC_TYPE(OrderDescriptor orderDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_AWG_PRICE (OrderDescriptor orderDescriptor);

LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_USERID (OrderDescriptor orderDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_ACCOUNT (OrderDescriptor orderDescriptor); 
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_BROKERREF (OrderDescriptor orderDescriptor); 
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_CLIENT_CODE (OrderDescriptor orderDescriptor); 
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_FIRMID (OrderDescriptor orderDescriptor); 
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_ORDER_REJECT_REASON (OrderDescriptor orderDescriptor);


long TRANS2QUIK_API __stdcall TRANS2QUIK_SUBSCRIBE_TRADES (LPSTR ClassCode, LPSTR Seccodes);
long TRANS2QUIK_API __stdcall TRANS2QUIK_UNSUBSCRIBE_TRADES ();
long TRANS2QUIK_API __stdcall TRANS2QUIK_START_TRADES(TRANS2QUIK_TRADE_STATUS_CALLBACK pfnTradeStatusCallback);

long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_DATE (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_SETTLE_DATE (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_TIME (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_IS_MARGINAL (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_ACCRUED_INT (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_YIELD (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_TS_COMMISSION (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_CLEARING_CENTER_COMMISSION (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_EXCHANGE_COMMISSION (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_TRADING_SYSTEM_COMMISSION (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_PRICE2 (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_REPO_RATE (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_REPO_VALUE (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_REPO2_VALUE (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_ACCRUED_INT2 (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_REPO_TERM (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_START_DISCOUNT (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_LOWER_DISCOUNT (TradeDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_UPPER_DISCOUNT (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_BLOCK_SECURITIES (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_PERIOD (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_KIND (TradeDescriptor tradeDescriptor);

#define TRADE_QUIKDATE                          0
#define TRADE_QUIKTIME                          1
#define TRADE_MICROSEC                          2

FILETIME TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_FILETIME (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_DATE_TIME (TradeDescriptor tradeDescriptor, long nTimeType);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_BROKER_COMMISSION (TradeDescriptor tradeDescriptor);
long TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_TRANSID (TradeDescriptor tradeDescriptor);

LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_CURRENCY (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_SETTLE_CURRENCY (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_SETTLE_CODE (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_ACCOUNT (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_BROKERREF (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_CLIENT_CODE (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_USERID (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_FIRMID (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_PARTNER_FIRMID (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_EXCHANGE_CODE (TradeDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRADE_STATION_ID (TradeDescriptor tradeDescriptor);

//////////////////////////////////////////////////////////////////////////
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_CLASS_CODE (TransactionReplyDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_SEC_CODE (TransactionReplyDescriptor tradeDescriptor);
double TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_PRICE (TransactionReplyDescriptor tradeDescriptor);
Quantity TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_QUANTITY (TransactionReplyDescriptor tradeDescriptor);
Quantity TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_BALANCE (TransactionReplyDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_FIRMID (TransactionReplyDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_ACCOUNT (TransactionReplyDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_CLIENT_CODE (TransactionReplyDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_BROKERREF (TransactionReplyDescriptor tradeDescriptor);
LPTSTR TRANS2QUIK_API __stdcall TRANS2QUIK_TRANSACTION_REPLY_EXCHANGE_CODE (TransactionReplyDescriptor tradeDescriptor);

#ifdef __cplusplus
}
#endif
