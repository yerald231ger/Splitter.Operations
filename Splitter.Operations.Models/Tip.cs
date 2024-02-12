namespace Splitter.Operations.Models;

public struct Tip
{
    public int Porcetange { get; set; }

    public static Tip Create(int porcetange)
    {
        if (porcetange < 0 || porcetange > 100)
        {
            throw new ArgumentException("cannot be less than 0 or greater than 100", nameof(porcetange));
        }

        return new Tip
        {
            Porcetange = porcetange
        };
    }

    public static decimal operator +(decimal value, Tip tip)
    {
        return value + (value * tip.Porcetange / 100);
    }

    public static implicit operator Tip(int v)
    {
        return new Tip { Porcetange = v };
    }
}
