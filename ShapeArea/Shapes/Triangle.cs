using ShapeArea.Abstractions;
using ShapeArea.Extensions;

namespace ShapeArea.Shapes;

/// <summary>
/// Provides a simple geometric triangle.
/// </summary>
public sealed class Triangle : IGeometricShape
{
    /// <exception cref="ArgumentException">
    /// Thrown when triangle inequality is violated
    /// </exception>
    /// <param name="a">The first side of triangle.</param>
    /// <param name="b">The second side of triangle.</param>
    /// <param name="c">The third side of triangle.</param>
    public Triangle(double a, double b, double c)
    {
        if (!IsTriangleExists(a, b, c))
            throw new ArgumentException($"Triangle inequality for triangle with sides A: {a} B: {b} C: {c} is violated");

        A = a;
        B = b;
        C = c;
    }

    /// <summary>
    /// Gets the first side of the triangle defined by this <see cref='ShapeArea.Shapes.Triangle'/>.
    /// </summary>
    public double A { get; }

    /// <summary>
    /// Gets the second side of the triangle defined by this <see cref='ShapeArea.Shapes.Triangle'/>.
    /// </summary>
    public double B { get; }

    /// <summary>
    /// Gets the third side of the triangle defined by this <see cref='ShapeArea.Shapes.Triangle'/>.
    /// </summary>
    public double C { get; }

    /// <summary>
    /// Gets the area of the triangle defined by this <see cref='ShapeArea.Shapes.Triangle'/>.
    /// </summary>
    public double GetArea()
    {
        var perimeter = A + B + C;
        var halfPerimeter = perimeter / 2;
        var area = Math.Sqrt(halfPerimeter * (halfPerimeter - A) * (halfPerimeter - B) * (halfPerimeter - C));

        return area;
    }

    /// <summary>
    /// Checks if the triangle defined by this <see cref='ShapeArea.Shapes.Triangle'/> is a right triangle.
    /// </summary>
    public bool IsRight()
    {
        const double epsilon = 1e-6;

        return (A * A + B * B).ApproximatelyEquals(C * C, epsilon) ||
               (A * A + C * C).ApproximatelyEquals(B * B, epsilon) ||
               (C * C + B * B).ApproximatelyEquals(A * A, epsilon);
    }

    private bool IsTriangleExists(double a, double b, double c)
        => a + b > c && a + c > b && c + b > a;
}