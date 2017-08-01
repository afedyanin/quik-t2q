namespace Trans2QuikAdapter.Transactions
{
    using Trans2QuikAdapter.Transactions.Enums;
    using Trans2QuikAdapter.Transactions.Helpers;

    public class Response
    {
        public ResponseCode Code { get; }
        public int ExtendedCode { get; }
        public string Message { get; }

        public Response(ResponseCode code, int extendedCode, byte[] messageBytes)
        {
            this.Code = code;
            this.ExtendedCode = extendedCode;
            this.Message = messageBytes.ByteToString();
        }
    }
}
