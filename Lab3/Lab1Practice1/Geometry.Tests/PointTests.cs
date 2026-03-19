using FluentAssertions;
using Xunit;

namespace Geometry.Tests;

public class PointTests
{
    [Fact]
    public void Point_default_constructor_should_set_coordinates_to_zero()
    {
        var point = new Point();

        point.X.Should().Be(0);
        point.Y.Should().Be(0);
    }

    [Fact]
    public void Point_single_param_constructor_should_set_both_coordinates_to_same_value()
    {
        var point = new Point(5);

        point.X.Should().Be(5);
        point.Y.Should().Be(5);
    }

    [Fact]
    public void Point_xy_constructor_should_set_correct_coordinates()
    {
        var point = new Point(3, 4);

        point.X.Should().Be(3);
        point.Y.Should().Be(4);
    }

    [Fact]
    public void Point_Move_should_shift_coordinates_correctly()
    {
        var point = new Point(1, 2);

        point.Move(3, 4);

        point.X.Should().Be(4);
        point.Y.Should().Be(6);
    }

    [Fact]
    public void Point_Move_with_negative_values_should_decrease_coordinates()
    {
        var point = new Point(5, 5);

        point.Move(-2, -3);

        point.X.Should().Be(3);
        point.Y.Should().Be(2);
    }

    [Fact]
    public void Point_Distance_from_origin_should_return_correct_value()
    {
        var point = new Point(3, 4);

        var distance = point.Distance();

        distance.Should().Be(5);
    }

    [Fact]
    public void Point_Distance_from_zero_point_should_return_zero()
    {
        var point = new Point();

        var distance = point.Distance();

        distance.Should().Be(0);
    }
}
