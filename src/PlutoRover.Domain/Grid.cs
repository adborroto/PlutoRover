namespace PlutoRover.Domain;

public class Grid
{
    public int Width { get; }
    public int Height { get; }

    private Grid(int w, int h)
    {
        Width = w;
        Height = h;
    }

    public static Grid Square(int size)
    {
        return new Grid(size, size);
    }

    public bool IsInside(Position position)
    {
        return position.X >= 0 && position.X < Width && position.Y >= 0 && position.Y < Height;
    }
}