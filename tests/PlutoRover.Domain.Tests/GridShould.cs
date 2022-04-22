using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlutoRover.Domain.Tests;

[TestClass]
public class GridShould
{
    [TestMethod]
    public void ShouldBeSquare()
    {
        const int size = 10;
        var grid = Grid.Square(size);

        Assert.IsTrue(grid.Height == grid.Width && grid.Width == size);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void InvalidSizeShouldThrowAnException()
    {
        const int invalidSize = -1;
        Grid.Square(invalidSize);
    }

    [DataTestMethod]
    [DataRow(10, 0, 0)]
    [DataRow(2, 1, 0)]
    [DataRow(2, 0, 1)]
    public void PositionShouldBeInside(int size, int x, int y)
    {
        var grid = Grid.Square(size);
        Assert.IsTrue(grid.IsInside(new Position(x, y)));
    }

    [DataTestMethod]
    [DataRow(10, -1, 0)]
    [DataRow(2, 2, 0)]
    [DataRow(2, 0, 2)]
    public void PositionShouldNotBeInside(int size, int x, int y)
    {
        var grid = Grid.Square(size);
        Assert.IsFalse(grid.IsInside(new Position(x, y)));
    }
}