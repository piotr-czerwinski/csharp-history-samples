using System.Collections;

namespace CSharpHistorySamples;

internal static partial class V10
{
    internal static void PropertyPatternImprovement()
    {
        WriteFirstLineInSample("Property Pattern Improvement");

        var circle = new Circle(new Point(1, 0), 3);
        WriteLine($"Is the circle centre at the origin: {CentreInOrigin(circle)}");

        static bool CentreInOrigin(Circle circle)
        {
            return circle is Circle
            {
                Centre.X: 0,
                Centre.Y: 0,
            };

            /* Before C# 10 nesting was required:
            return circle is Circle
            {
                Centre:
                {
                    X: 0,
                    Y: 0,
                }
            };
            */
        }
    }

    private record Circle(Point Centre, int Radius);
    private record Point(int X, int Y);
}
