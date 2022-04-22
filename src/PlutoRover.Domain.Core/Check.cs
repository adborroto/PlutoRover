namespace PlutoRover.Domain.Core;

public static class Check
{
    public static void NotNull(object o, Exception e)
    {
        if (o == null)
            throw e;
    }

    public static void IsTrue(bool condition, Exception e)
    {
        if (!condition)
            throw e;
    }
}