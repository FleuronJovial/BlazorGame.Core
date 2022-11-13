namespace BlazorGame.Core.Utils
{
    public static class EnumUtils
    {
        public static IEnumerable<TEnum> GetAllValues<TEnum>()
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
        }
    }
}