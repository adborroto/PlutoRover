namespace PlutoRover.Services;

public interface IRoverControl
{
    /// <summary>
    /// Execute command over rover
    /// </summary>
    /// <param name="commands">List of commands</param>
    void Execute(string commands);
}