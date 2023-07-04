using ShapeArea.Abstractions;

namespace ShapeArea.Shapes;

/// <summary>
/// Provides a simple geometric circle.
/// </summary>
public sealed class Circle : IGeometricShape
{
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when radius is equal to or less than 0.
    /// </exception>
    /// <param name="a">The radius of circle.</param>
    public Circle(double radius)
    {
        if(radius <= 0)
            throw new ArgumentOutOfRangeException($"Circle with radius: {radius} is undefined");

        Radius = radius;
    }

    /// <summary>
    /// Gets the radius of the circle defined by this <see cref='ShapeArea.Shapes.Circle'/>.
    /// </summary>
    public double Radius { get; }

    /// <summary>
    /// Gets the area of the circle defined by this <see cref='ShapeArea.Shapes.Circle'/>.
    /// </summary>
    public double GetArea()
        => Math.PI * Radius * Radius;
}