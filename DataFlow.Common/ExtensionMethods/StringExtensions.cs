namespace DataFlow.Common.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string NullIfWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? null : value;
        }
    }
}
