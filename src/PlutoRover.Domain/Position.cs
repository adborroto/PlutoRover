using PlutoRover.Domain.Core;

namespace PlutoRover.Domain;

public class Position : ValueObject
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public static Position operator +(Position p1, Position p2)
    {
        Check.NotNull(p1, new InvalidOperationException());
        Check.NotNull(p2, new InvalidOperationException());

        return new Position(p1.X + p2.X, p1.Y + p2.Y);
    }

    public static Position operator *(Position p1, int factor)
    {
        Check.NotNull(p1, new InvalidOperationException());

        return new Position(p1.X * factor, p1.Y * factor);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return X;
        yield return Y;
    }
}