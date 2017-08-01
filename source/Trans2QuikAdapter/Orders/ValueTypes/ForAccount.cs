namespace Trans2QuikAdapter.Orders.ValueTypes
{
    public struct  ForAccount
    {
        public string Name { get; set; }

        public ForAccount(string name)
        {
            this.Name = name;
        }

        public static ForAccount OwnOwn => new ForAccount("OWNOWN");
        public static ForAccount OwnCli => new ForAccount("OWNCLI");
        public static ForAccount OwnDup => new ForAccount("OWNDUP");
        public static ForAccount CliCli => new ForAccount("CLICLI");
    }
}
