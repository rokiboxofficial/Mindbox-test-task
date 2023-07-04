namespace ShapeArea.Extensions;

internal static class DoubleExtensions
{
    public static bool ApproximatelyEquals(this double thisValue, double value, double epsilon)
    {
        var difference = Math.Abs(thisValue - value);

        return difference < epsilon;
    }
}