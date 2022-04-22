using PlutoRover.Domain.Core;

namespace PlutoRover.Domain;

public class Grid
{
    private Grid(int w, int h)
    {
        Width = w;
        Height = h;
    }

    public int Width { get; }
    
    public int Height { get; }
    
    public static Grid Square(int size)
    {
        Check.IsTrue(size > 0, new ArgumentException("size has to be greater than 0", nameof(size)));
        return new Grid(size, size);
    }

    public bool IsInside(Position position)
    {
        return position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height;
    }
}