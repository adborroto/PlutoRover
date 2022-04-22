using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Domain.Tests;

[TestClass]
public class PositionShould
{
    [TestMethod]
    public void ShouldBeEqual()
    {
        var p1 = new Position(10, 10);
        var p2 = new Position(10, 10);

        Assert.AreEqual(p1, p2);
    }

    [TestMethod]
    public void ShouldNotBeEqual()
    {
        var p1 = new Position(0, 1);
        var p2 = new Position(10, 10);

        Assert.AreNotEqual(p1, p2);
    }

    [TestMethod]
    public void ShouldAddPosition()
    {
        var p1 = new Position(0, 1);
        var p2 = new Position(10, 10);
        var addition = p1 + p2;
        Assert.AreEqual(new Position(10, 11), addition);
    }

    [TestMethod]
    public void ShouldMultiplyPosition()
    {
        var p1 = new Position(1, 3);
        var addition = p1 * 3;
        Assert.AreEqual(new Position(3, 9), addition);
    }
}