namespace Trans2QuikAdapter.Transactions.Helpers
{
    internal static class Extensions
    {
        public static string ByteToString(this byte[] array)
        {
            if (array == null)
            {
                return string.Empty;
            }

            return System.Text.Encoding.Default.GetString(array, 0, GetZeroIndex(array));
        }

        private static int GetZeroIndex(byte[] array)
        {
            int count = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                if (0 == array[i])
                {
                    count = i;
                    break;
                }
            }

            return count;
        }
    }
}
