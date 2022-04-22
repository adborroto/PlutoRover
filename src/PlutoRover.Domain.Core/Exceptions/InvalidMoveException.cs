namespace PlutoRover.Domain.Core;

public class InvalidMoveException : Exception
{
    public InvalidMoveException() : base("invalid move")
    {
    }
}