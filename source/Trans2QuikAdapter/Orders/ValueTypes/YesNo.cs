namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct YesNo
    {
        public string Name { get; set; }
        public bool Value { get; set; }

        public YesNo(bool yes)
        {
            this.Value = yes;
            this.Name = this.Value ? "YES" : "NO";
        }

        public YesNo(string name)
        {
            this.Name = name;
            this.Value = string.Compare(name, Yes.Name, true) == 0;
        }

        public static YesNo Yes => new YesNo(true);
        public static YesNo No => new YesNo(false);
    }
}
