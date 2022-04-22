namespace PlutoRover.Domain;

public class RoverHasNotLandedException : Exception
{
    public RoverHasNotLandedException() : base("rover has not landed")
    {
    }
}