using PlutoRover.Domain;

namespace PlutoRover.Services;

public interface IRoverCommand
{
    void Execute(Rover rover);
    
    char CommandName { get; }
}