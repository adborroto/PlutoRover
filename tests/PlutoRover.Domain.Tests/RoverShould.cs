using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Domain.Tests;

[TestClass]
public class RoverShould
{
    
    [TestMethod]
    public void WhenLandShouldUpdateRoverLocation()
    {
        var rover = new Rover(Grid.Square(10));
        rover.Land(1, 1, CardinalPoint.North);

        Assert.AreEqual(new Location(1, 1, CardinalPoint.North), rover.Location);
    }

    [TestMethod]
    public void ShouldMoveForward()
    {
        var rover = GivenALandedRoverFacingNorth();
        rover.MoveForward();
        Assert.AreEqual(new Location(1, 2, CardinalPoint.North), rover.Location);
    }

    [TestMethod]
    public void ShouldMoveBackward()
    {
        var rover = GivenALandedRoverFacingNorth();
        rover.MoveBackward();
        Assert.AreEqual(new Location(1, 0, CardinalPoint.North), rover.Location);
    }

    [TestMethod]
    public void ShouldMoveTurnRight()
    {
        var rover = GivenALandedRoverFacingNorth();
        rover.TurnRight();
        Assert.AreEqual(new Location(1, 1, CardinalPoint.East), rover.Location);
    }

    [TestMethod]
    public void ShouldMoveTurnLeft()
    {
        var rover = GivenALandedRoverFacingNorth();
        rover.TurnLeft();
        Assert.AreEqual(new Location(1, 1, CardinalPoint.West), rover.Location);
    }

    [TestMethod]
    [ExpectedException(typeof(RoverHasNotLandedException))]
    public void WhenRoverHasNotLandedShouldThrowAnException()
    {
        var rover = new Rover(Grid.Square(10));
        rover.MoveBackward();
    }
    
    [TestMethod]
    public void WhenLandsShouldHasLandedTrue()
    {
        var rover = new Rover(Grid.Square(10));
        rover.Land(1, 1, CardinalPoint.North);

        Assert.IsTrue(rover.HasLanded);
    }

    private static Rover GivenALandedRoverFacingNorth()
    {
        var rover = new Rover(Grid.Square(10));
        rover.Land(1, 1, CardinalPoint.North);
        return rover;
    }
}