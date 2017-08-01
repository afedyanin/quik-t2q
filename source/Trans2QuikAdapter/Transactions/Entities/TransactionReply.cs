namespace Trans2QuikAdapter.Transactions.Entities
{
    public class TransactionReply
    {
        public Response Response { get; set; } 

        public int ReplyCode { get; set; }
        public uint TransId { get; set; }
        public ulong OrderNum { get; set; }
        public string Message { get; set; }
        public string Descriptor { get; set; }

        // Extended properies
        public string ClassCode { get; set; }
        public string SecCode { get; set; }
        public double Price { get; set; }
        public long Quantity { get; set; }
        public long Balance { get; set; }
        public string FrimId { get; set; }
        public string Account { get; set; }
        public string ClientCode { get; set; }
        public string BrokerRef { get; set; }
        public string ExchangeCode { get; set; }
    }
}
