namespace CommonShims;

public static class MathExtensions
{
    extension(Math)
    {
        /// <summary>
        /// Clamps a value between a minimum and maximum value.
        /// </summary>
        public static T Clamp<T>(T value, T min, T max)
            where T : IComparable<T>
        {
            if (value.CompareTo(min) < 0)
                return min;

            if (value.CompareTo(max) > 0)
                return max;

            return value;
        }
    }
}
