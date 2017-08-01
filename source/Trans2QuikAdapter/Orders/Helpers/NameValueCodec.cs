namespace Trans2QuikAdapter.Orders.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NameValueCodec
    {
        protected IDictionary<string, string> Items { get; set; }

        public NameValueCodec() : this(new Dictionary<string, string>())
        {
        }

        public NameValueCodec(IDictionary<string, string> initialDictionary)
        {
            this.Items = initialDictionary;
        }

        public string Encode()
        {
            var sb = new StringBuilder();

            foreach (var key in this.Items.Keys)
            {
                sb.AppendFormat($"{key}={this.Items[key]};");
            }

            return sb.ToString().TrimEnd(';');
        }

        public bool ContainsKey(string key)
        {
            return this.Items.ContainsKey(key);
        }

        public string Get(string key, string defaultValue = "")
        {
            var trimmedKey = string.IsNullOrEmpty(key) ? string.Empty : key.Trim();
            return this.ContainsKey(trimmedKey) ? this.Items[trimmedKey] : defaultValue;
        }

        public void Add(string key, string value, bool skipEmptyValue = true)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Key cannot be empty.", nameof(key));
            }

            if (skipEmptyValue && string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            if (this.ContainsKey(key))
            {
                this.Items[key] = value;
            }
            else
            {
                this.Items.Add(key, value);
            }
        }

        public IDictionary<string, string> GetItems()
        {
            return this.Items;
        }
    }
}
