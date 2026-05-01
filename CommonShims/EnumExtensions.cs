namespace CommonShims;

public static class EnumExtensions
{
    extension(Enum)
    {
        public static string[] GetNames<TEnum>() where TEnum : struct, Enum
            => Enum.GetNames(typeof(TEnum));
    }
}
