using FluentAssertions;
using ShapeArea.Shapes;

namespace ShapeArea.Tests.UnitTests;

public class TriangleTests
{
    [Theory]
    [InlineData(2, 1, 1)]
    [InlineData(1, 2, 1)]
    [InlineData(1, 1, 2)]
    [InlineData(3, 1, 1)]
    [InlineData(1, 3, 1)]
    [InlineData(1, 1, 3)]
    [InlineData(-3, -4, -2)]
    public void WhenCreatingTriangle_AndTriangleInequalityViolated_ThenShouldThrowArgumentException(double a, double b, double c)
    {
        // Act.
        var act = () => new Triangle(a, b, c);

        // Assert.
        act.Should().ThrowExactly<ArgumentException>();
    }

    [Theory]
    [InlineData(3, 4, 5)]
    [InlineData(160, 231, 281)]
    [InlineData(133, 156, 205)]
    [InlineData(32, 255, 257)]
    [InlineData(65, 72, 97)]
    [InlineData(252, 275, 373)]
    [InlineData(4795, 8772, 9997)]
    [InlineData(40000, 73005, 83245)]
    public void WhenGettingIsRight_AndTriangleIsRight_ThenIsRightShouldBeTrue(double a, double b, double c)
    {
        // Arrange.
        var triangle = new Triangle(a, b, c);

        // Act.
        var isRight = triangle.IsRight();

        // Assert.
        isRight.Should().BeTrue();
    }

    [Theory]
    [InlineData(3, 4, 5.000009)]
    [InlineData(160, 231, 281.000009)]
    [InlineData(133, 156, 205.000009)]
    [InlineData(32, 255, 257.000009)]
    [InlineData(65, 72, 97.000009)]
    [InlineData(252, 275, 373.000009)]
    [InlineData(4795, 8772, 9997.000009)]
    [InlineData(40000, 73005, 83245.000009)]
    public void WhenGettingIsRight_AndTriangleIsNotRight_ThenIsRightShouldBeFalse(double a, double b, double c)
    {
        // Arrange.
        var triangle = new Triangle(a, b, c);

        // Act.
        var isRight = triangle.IsRight();

        // Assert.
        isRight.Should().BeFalse();
    }

    [Theory]
    [InlineData(3, 4, 5, 6)]
    [InlineData(10_000, 15_000, 20_000, 72618437.741389)]
    public void WhenGettingArea_ThenAreaShouldBeCorrect(double a, double b, double c, double expectedArea)
    {
        // Arrange.
        var triangle = new Triangle(a, b, c);

        // Act.
        var area = triangle.GetArea();

        // Assert.
        area.Should().BeApproximately(expectedArea, 1e-6);
    }
}