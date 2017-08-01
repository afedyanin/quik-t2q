namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct OrderType
    {
        public string Name { get; set; }

        public OrderType(string name)
        {
            this.Name = name;
        }

        public static OrderType Limit => new OrderType("L");
        public static OrderType Market => new OrderType("M");
    }
}
