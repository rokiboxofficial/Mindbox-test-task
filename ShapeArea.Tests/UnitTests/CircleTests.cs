using FluentAssertions;
using ShapeArea.Shapes;

namespace ShapeArea.Tests.UnitTests;

public class CircleTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void WhenCreatingCircle_AndRadiusEqualsToOrLessThan0_ThenShouldThrowArgumentOutOfRangeException(double radius)
    {
        // Act.
        var act = () => new Circle(radius);

        // Assert.
        act.Should().ThrowExactly<ArgumentOutOfRangeException>();
    }


    [Theory]
    [InlineData(1, Math.PI)]
    [InlineData(4, 16 * Math.PI)]
    public void WhenGettingArea_ThenAreaShouldBeCorrect(double radius, double expectedArea)
    {
        // Arrange.
        var circle = new Circle(radius);

        // Act.
        var area = circle.GetArea();

        // Assert.
        area.Should().BeApproximately(expectedArea, 1e-6);
    }
}