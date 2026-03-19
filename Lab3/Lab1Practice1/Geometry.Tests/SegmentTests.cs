using FluentAssertions;
using Xunit;

namespace Geometry.Tests;

public class SegmentTests
{
    [Fact]
    public void Segment_should_have_correct_Start_point()
    {
        var start = new Point(1, 2);
        var end = new Point(4, 6);

        var segment = new Segment(start, end);

        segment.Start.X.Should().Be(1);
        segment.Start.Y.Should().Be(2);
    }

    [Fact]
    public void Segment_should_have_correct_End_point()
    {
        var start = new Point(1, 2);
        var end = new Point(4, 6);

        var segment = new Segment(start, end);

        segment.End.X.Should().Be(4);
        segment.End.Y.Should().Be(6);
    }

    [Fact]
    public void Segment_Length_should_return_correct_value()
    {
        var start = new Point(0, 0);
        var end = new Point(3, 4);

        var segment = new Segment(start, end);

        segment.Length.Should().Be(5);
    }

    [Fact]
    public void Segment_Length_of_zero_segment_should_be_zero()
    {
        var point = new Point(2, 3);

        var segment = new Segment(point, point);

        segment.Length.Should().Be(0);
    }
}
