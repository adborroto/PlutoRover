using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlutoRover.Domain.Core;
using PlutoRover.Services;

namespace PlutoRover.Domain.Tests;

[TestClass]
public class RoverControlShould
{
    [DataTestMethod]
    [DataRow(0, 0, CardinalPoint.North, 0, 1)]
    [DataRow(0, 1, CardinalPoint.South, 0, 0)]
    [DataRow(1, 1, CardinalPoint.West, 0, 1)]
    [DataRow(1, 1, CardinalPoint.East, 2, 1)]
    public void RoverShouldMoveForward(int coordX, int coordY, CardinalPoint facing, int expectedX, int expectedY)
    {
        // Given a rover in a 5x5 grid
        var rover = new Rover(Grid.Square(5));
        rover.Land(coordX, coordY, facing);
        var control = new RoverControl(new DefaultRoverCommands(), rover);

        // When execute forward `f` command
        control.Execute("F");

        // Should move in the right direction
        Assert.AreEqual(new Location(expectedX, expectedY, facing), rover.Location);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidMoveException))]
    public void WhenMoveForwardOutsideGridShouldGetAnException()
    {
        // Given a rover in a 5x5 grid
        var rover = new Rover(Grid.Square(5));
        rover.Land(0, 0, CardinalPoint.South);
        var control = new RoverControl(new DefaultRoverCommands(), rover);

        // When execute forward `F` command
        control.Execute("F");
    }

    [DataTestMethod]
    [DataRow(0, 1, CardinalPoint.North, 0, 0)]
    [DataRow(1, 1, CardinalPoint.East, 0, 1)]
    [DataRow(1, 1, CardinalPoint.South, 1, 2)]
    [DataRow(1, 1, CardinalPoint.West, 2, 1)]
    public void RoverShouldMoveBackward(int coordX, int coordY, CardinalPoint facing, int expectedX, int expectedY)
    {
        // Given a rover in a 5x5 grid
        var rover = new Rover(Grid.Square(5));
        rover.Land(coordX, coordY, facing);
        var control = new RoverControl(new DefaultRoverCommands(), rover);

        // When execute backward `B` command
        control.Execute("B");

        // Should move in the right direction
        Assert.AreEqual(new Location(expectedX, expectedY, facing), rover.Location);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidMoveException))]
    public void WhenMoveBackwardOutsideGridShouldGetAnException()
    {
        // Given a rover in a 5x5 grid
        var rover = new Rover(Grid.Square(5));
        rover.Land(4, 4, CardinalPoint.South);
        var control = new RoverControl(new DefaultRoverCommands(), rover);

        // When execute forward `B` command
        control.Execute("B");
    }

    [TestMethod]
    public void ShouldMoveGivenTheCommand()
    {
        var rover = new Rover(Grid.Square(100));
        rover.Land(0, 0, CardinalPoint.North);

        var control = new RoverControl(new DefaultRoverCommands(), rover);
        control.Execute("FFRFF");

        Assert.AreEqual(new Location(2, 2, CardinalPoint.East), rover.Location);
    }

    [TestMethod]
    [ExpectedException(typeof(CommandNotFoundException))]
    public void GivenAndInvalidCommandShouldThrowException()
    {
        var rover = new Rover(Grid.Square(100));
        rover.Land(0, 0, CardinalPoint.North);

        var control = new RoverControl(new DefaultRoverCommands(), rover);
        control.Execute("X");
    }
}