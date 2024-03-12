namespace Splitter.Commensality.Models;

public struct Tip(int porcetange)
{
    public int Porcetange { get; set; } = porcetange;

    public static Tip Create(int porcetange)
    {
        if (porcetange < 0 || porcetange > 100)
            throw new ArgumentException("cannot be less than 0 or greater than 100", nameof(porcetange));

        return new(porcetange);
    }

    public static decimal operator +(decimal value, Tip tip) => value + (value * tip.Porcetange / 100);


    public static implicit operator Tip(int v) => new(v);
}
