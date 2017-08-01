namespace Trans2QuikAdapter.Transactions.Entities
{
    using System;

    public class TradeStatus
    {
        public int Mode { get; set; }
        public ulong Number { get; set; }
        public ulong OrderNumber { get; set; }
        public string ClassCode { get; set; }
        public string SecCode { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
        public double Value { get; set; }
        public int IsSell { get; set; }
        public string Descriptor { get; set; }

        // Extended properties
        public int Date { get; set; }
        public int SettleDate { get; set; }
        public int Time { get; set; }
        public int IsMarginal { get; set; }
        public double AccuredInt { get; set; }
        public double Yield { get; set; }
        public double TsCommission { get; set; }
        public double ClearingCenterCommission { get; set; }
        public double ExchangeCommission { get; set; }
        public double TradingSystemCommission { get; set; }
        public double Price2 { get; set; }
        public double RepoRate { get; set; }
        public double RepoValue { get; set; }
        public double Repo2Value { get; set; }
        public double AccuredInt2 { get; set; }
        public int RepoTerm { get; set; }
        public double StartDiscount { get; set; }
        public double LowerDiscount { get; set; }
        public double UpperDiscount { get; set; }
        public int BlockSecurities { get; set; }
        public int Period { get; set; }
        public int TimeMicroSec { get; set; }
        public DateTime FileTime { get; set; }
        public int Kind { get; set; }
        public string Currency { get; set; }
        public string SettleCurrency { get; set; }
        public string SettleCode { get; set; }
        public string Account { get; set; }
        public string BrokerRef { get; set; }
        public string ClientCode { get; set; }
        public string UserId { get; set; }
        public string FirmId { get; set; }
        public string PartnerFirmId { get; set; }
        public string ExchangeCode { get; set; }
        public string TradeStationId { get; set; }
        public double BrokerCommission { get; set; }
        public int TransId { get; set; }
    }
}
