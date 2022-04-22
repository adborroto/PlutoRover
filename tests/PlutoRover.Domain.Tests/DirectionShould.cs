using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Domain.Tests;

[TestClass]
public class DirectionShould
{
    [TestMethod]
    public void ShouldBeEqual()
    {
        var d1 = Direction.NewFacing(CardinalPoint.East);
        var d2 = Direction.NewFacing(CardinalPoint.East);
        Assert.AreEqual(d1, d2);
    }

    [TestMethod]
    public void ShouldNotBeEqual()
    {
        var d1 = Direction.NewFacing(CardinalPoint.North);
        var d2 = Direction.NewFacing(CardinalPoint.East);

        Assert.AreNotEqual(d1, d2);
    }

    [DataTestMethod]
    [DataRow(CardinalPoint.North, CardinalPoint.East)]
    [DataRow(CardinalPoint.East, CardinalPoint.South)]
    [DataRow(CardinalPoint.South, CardinalPoint.West)]
    [DataRow(CardinalPoint.West, CardinalPoint.North)]
    public void ShouldSpinRight(CardinalPoint facing, CardinalPoint expected)
    {
        var direction = Direction.NewFacing(facing);
        var newDirection = direction.SpinRight();
        Assert.AreEqual(Direction.NewFacing(expected), newDirection);
    }

    [DataTestMethod]
    [DataRow(CardinalPoint.North, CardinalPoint.West)]
    [DataRow(CardinalPoint.East, CardinalPoint.North)]
    [DataRow(CardinalPoint.South, CardinalPoint.East)]
    [DataRow(CardinalPoint.West, CardinalPoint.South)]
    public void ShouldSpinLeft(CardinalPoint facing, CardinalPoint expected)
    {
        var direction = Direction.NewFacing(facing);
        var newDirection = direction.SpinLeft();
        Assert.AreEqual(Direction.NewFacing(expected), newDirection);
    }
}