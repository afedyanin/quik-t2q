namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct StopPriceCondition
    {
        public string Name { get; set; }

        public StopPriceCondition(string name)
        {
            this.Name = name;
        }

        public static StopPriceCondition LessOrEqual => new StopPriceCondition("<=");
        public static StopPriceCondition GreaterOrEqual => new StopPriceCondition(">=");
    }
}
