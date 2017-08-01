namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct Operation
    {
        public string Name { get; set; }

        public Operation(string name)
        {
            this.Name = name;
        }

        public static Operation Buy => new Operation("B");
        public static Operation Sell => new Operation("S");
    }
}
