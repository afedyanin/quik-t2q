namespace Trans2QuikAdapter.Transactions.Entities
{
    using System;

    public class OrderStatus
    {
        public int Mode { get; set; }
        public int TransId { get; set; }
        public ulong Number { get; set; }
        public string ClassCode { get; set; }
        public string SecCode { get; set; }
        public double Price { get; set; }
        public long Balance { get; set; }
        public double Value { get; set; }
        public int IsSell { get; set; }
        public int Status { get; set; }
        public string Descriptor { get; set; }

        // Extended properties
        public long Quantity { get; set; }
        public int Date { get; set; }
        public int Time { get; set; }
        public int TimeMicroSec { get; set; }
        public int WithdrawDate { get; set; }
        public int WithdrawTime { get; set; }
        public int WithdrawTimeMicroSec { get; set; }
        public int ActivationTime { get; set; }
        public int Expiry { get; set; }
        public double AccuredInt { get; set; }
        public double Yield { get; set; }
        public int Uid { get; set; }
        public long VisibleQuantity { get; set; }
        public int Period { get; set; }
        public DateTime FileTime { get; set; }
        public DateTime WithdrawFileTime { get; set; }
        public string UserId { get; set; }
        public string Account { get; set; }
        public string BrokerRef { get; set; }
        public string ClientCode { get; set; }
        public string FirmId { get; set; }
        public int ValueEntryType { get; set; }
        public int ExtendedFlags { get; set; }
        public long MinQuantity { get; set; }
        public int ExecType { get; set; }
        public double AvgPrice { get; set; }
        public string RejectReason { get; set; }
    }
}
