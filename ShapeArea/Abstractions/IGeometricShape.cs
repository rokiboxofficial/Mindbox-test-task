namespace ShapeArea.Abstractions;

/// <summary>
/// Provides functionality to get area of geometric shape.
/// </summary>
public interface IGeometricShape
{
    /// <summary>
    /// Gets the area of this shape.
    /// </summary>
    public double GetArea();
}