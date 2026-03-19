using FluentAssertions;
using Xunit;

namespace Geometry.Tests;

public class PolygonalChainTests
{
    [Fact]
    public void PolygonalChain_without_midpoints_length_should_equal_segment_length()
    {
        var chain = new PolygonalChain(new Point(0, 0), new Point(3, 4));

        var length = chain.Length;

        length.Should().Be(5);
    }

    [Fact]
    public void PolygonalChain_with_midpoint_length_should_be_sum_of_segments()
    {
        var chain = new PolygonalChain(new Point(0, 0), new Point(6, 0));
        chain.AddMidpoint(new Point(3, 0));

        var length = chain.Length;

        length.Should().Be(6);
    }

    [Fact]
    public void PolygonalChain_Move_should_shift_all_points()
    {
        var chain = new PolygonalChain(new Point(0, 0), new Point(4, 0));
        chain.AddMidpoint(new Point(2, 0));

        chain.Move(1, 1);

        chain.Start.X.Should().Be(1);
        chain.Start.Y.Should().Be(1);
        chain.End.X.Should().Be(5);
        chain.End.Y.Should().Be(1);
    }

    [Fact]
    public void PolygonalChain_ToString_without_midpoints_should_return_correct_format()
    {
        var chain = new PolygonalChain(new Point(1, 2), new Point(3, 4));

        var result = chain.ToString();

        result.Should().Be("(1,2),(3,4)");
    }

    [Fact]
    public void PolygonalChain_ToString_with_midpoints_should_include_all_points()
    {
        var chain = new PolygonalChain(new Point(0, 0), new Point(4, 0));
        chain.AddMidpoint(new Point(2, 0));

        var result = chain.ToString();

        result.Should().Be("(0,0),(2,0),(4,0)");
    }
}
