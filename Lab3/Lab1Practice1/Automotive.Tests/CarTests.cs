using FluentAssertions;
using Xunit;

namespace Automotive.Tests;

public class CarTests
{
    [Fact]
    public void Car_constructor_should_set_properties_correctly()
    {
        var car = new Car("Toyota", 50, 8);

        car.Brand.Should().Be("Toyota");
        car.TankCapacity.Should().Be(50);
        car.FuelConsumptionPer100Km.Should().Be(8);
    }

    [Fact]
    public void Car_initial_fuel_level_should_be_zero()
    {
        var car = new Car("Toyota", 50, 8);

        car.CurrentFuelLevel.Should().Be(0);
    }

    [Fact]
    public void Car_constructor_with_empty_brand_should_throw_ArgumentException()
    {
        var act = () => new Car("", 50, 8);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Car_constructor_with_zero_tankCapacity_should_throw_ArgumentOutOfRangeException()
    {
        var act = () => new Car("Toyota", 0, 8);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Car_constructor_with_zero_fuelConsumption_should_throw_ArgumentOutOfRangeException()
    {
        var act = () => new Car("Toyota", 50, 0);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Car_Refuel_should_increase_fuel_level()
    {
        var car = new Car("Toyota", 50, 8);

        car.Refuel(30);

        car.CurrentFuelLevel.Should().Be(30);
    }

    [Fact]
    public void Car_Refuel_should_not_exceed_tank_capacity()
    {
        var car = new Car("Toyota", 50, 8);

        car.Refuel(100);

        car.CurrentFuelLevel.Should().Be(50);
    }

    [Fact]
    public void Car_Refuel_with_zero_amount_should_throw_ArgumentOutOfRangeException()
    {
        var car = new Car("Toyota", 50, 8);

        var act = () => car.Refuel(0);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Car_Drive_should_increase_odometer()
    {
        var car = new Car("Toyota", 50, 10);
        car.Refuel(50);

        car.Drive(100);

        car.Odometer.Should().Be(100);
        car.TripOdometer.Should().Be(100);
    }

    [Fact]
    public void Car_Drive_should_decrease_fuel_level()
    {
        var car = new Car("Toyota", 50, 10);
        car.Refuel(50);

        car.Drive(100);

        car.CurrentFuelLevel.Should().Be(40);
    }

    [Fact]
    public void Car_Drive_with_not_enough_fuel_should_drive_only_possible_distance()
    {
        var car = new Car("Toyota", 50, 10);
        car.Refuel(5);

        car.Drive(200);

        car.Odometer.Should().Be(50);
        car.CurrentFuelLevel.Should().Be(0);
    }

    [Fact]
    public void Car_Drive_with_zero_kilometers_should_throw_ArgumentOutOfRangeException()
    {
        var car = new Car("Toyota", 50, 10);
        car.Refuel(50);

        var act = () => car.Drive(0);

        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Car_ResetTripOdometer_should_set_trip_to_zero()
    {
        var car = new Car("Toyota", 50, 10);
        car.Refuel(50);
        car.Drive(100);

        car.ResetTripOdometer();

        car.TripOdometer.Should().Be(0);
    }

    [Fact]
    public void Car_TripOdometer_should_reset_after_1000km()
    {
        var car = new Car("Toyota", 50, 10);

        car.Refuel(50);
        car.Drive(500);
        car.Refuel(50);
        car.Drive(500);

        car.TripOdometer.Should().Be(0);
    }
}
