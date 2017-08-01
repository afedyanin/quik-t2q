namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct Units
    {
        public string Name { get; set; }

        public Units(string name)
        {
            this.Name = name;
        }

        public static Units Percents => new Units("PERCENTS");
        public static Units PriceUnits => new Units("PRICE_UNITS");
    }
}
