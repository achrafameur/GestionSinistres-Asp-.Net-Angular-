namespace Insurise.Crosscutting.Extensions;

public static class IntExtensions
{
    public static int GetRandom(this int value)
    {
        var rand = new Random();
        return rand.Next(value);
    }
}