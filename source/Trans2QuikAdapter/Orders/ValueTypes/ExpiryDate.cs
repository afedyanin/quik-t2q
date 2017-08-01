namespace Trans2QuikAdapter.Orders.ValueTypes
{
    using System;
    using Trans2QuikAdapter.Orders.Helpers;

    public struct ExpiryDate
    {
        public string Name { get; set; }

        public ExpiryDate(string name)
        {
            this.Name = name;
        }

        public ExpiryDate(DateTime date)
        {
            this.Name = date.ToString(Formats.DateFormat); 
        }

        public static ExpiryDate GTC => new ExpiryDate("GTC");
        public static ExpiryDate TODAY => new ExpiryDate("TODAY");

    }
}
