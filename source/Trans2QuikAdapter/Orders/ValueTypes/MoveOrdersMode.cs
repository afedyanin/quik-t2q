namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct MoveOrdersMode
    {
        public string Name { get; set; }

        public MoveOrdersMode(string name)
        {
            this.Name = name;
        }

        public static MoveOrdersMode DontChangeQuantity => new MoveOrdersMode("0");
        public static MoveOrdersMode UseNewQuantity => new MoveOrdersMode("1");
        public static MoveOrdersMode KillBothIfAnyDifference => new MoveOrdersMode("2");
    }
}
