using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Domain.Tests;

[TestClass]
public class LocationShould
{
    [TestMethod]
    public void ShouldBeEqual()
    {
        var l1 = new Location(1, 0, CardinalPoint.North);
        var l2 = new Location(1, 0, CardinalPoint.North);
        Assert.AreEqual(l1, l2);
    }

    [TestMethod]
    public void ShouldNotBeEqual()
    {
        var l1 = new Location(1, 0, CardinalPoint.North);
        var l2 = new Location(1, 0, CardinalPoint.East);
        Assert.AreNotEqual(l1, l2);
    }

    [TestMethod]
    public void ShouldUpdateDirection()
    {
        var l1 = new Location(1, 0, CardinalPoint.North);
        l1.UpdateDirection(Direction.NewFacing(CardinalPoint.South));

        Assert.AreEqual(CardinalPoint.South, l1.Direction.Facing);
    }
}