using PlutoRover.Domain.Core;

namespace PlutoRover.Domain;

public class Direction : ValueObject
{
    private CardinalPoint[] _cardinalPoints = new[]
        {CardinalPoint.North, CardinalPoint.East, CardinalPoint.South, CardinalPoint.West};

    private int _direction;

    private Direction(int direction)
    {
        _direction = direction;
    }

    public static Direction NewFacing(CardinalPoint facing)
    {
        return new Direction((int)facing);
    }

    public Direction SpinRight()
    {
        return new Direction((_direction + 1) % 4);
    }

    public Direction SpinLeft()
    {
        return new Direction(((_direction + 4) - 1) % 4);
    }

    public CardinalPoint Facing => _cardinalPoints[_direction];

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return _direction;
    }

    public override string ToString()
    {
        return _cardinalPoints[_direction].ToString();
    }
}

public enum CardinalPoint
{
    North = 0,
    East,
    South,
    West,
}