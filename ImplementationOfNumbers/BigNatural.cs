using System;
public class BigNatural : IComparable, IDisposable
{
    private ulong a;
    private ulong b;

    public int CompareTo(object? obj)
    {
        if (obj == null)
            throw new InvalidOperationException();
        if (obj is BigNatural bn)
        {
            if (this.b > bn.b)
                return 1;
            else if (this.b < bn.b)
                return -1;
            else
                return (int)(this.a - bn.a);
        }
        else if (obj is int i)
        {
            if (this.b > 0)
                return 1;
            if (i < 0)
                return 1;
            return (int)(a - (ulong)i);
        }
        else if (obj is ulong u)
        {
            if (this.b > 0)
                return 1;
            return (int)(a - u);
        }
        throw new InvalidOperationException();
    }

    public override string ToString() => 
        b.ToString("00000000000000000000") +
        a.ToString("0000000000000000000");
    
    public static BigNatural Parse(string str)
    {
        int splitCharacter = str.Length - 19;
        if (splitCharacter < 0)
            splitCharacter = 0;
        var parta = str.Substring(splitCharacter,
            str.Length - splitCharacter);
        var partb = str.Substring(0, splitCharacter);

        BigNatural bg = new BigNatural();
        bg.a = ulong.Parse(parta);
        if (partb.Length > 0)
            bg.b = ulong.Parse(partb);
        return bg;
    }

    public void Dispose() { }

    public static BigNatural operator +(BigNatural n1, BigNatural n2)
    {
        BigNatural result = new BigNatural();
        result.b = n1.b + n2.b;
        result.b = n1.a + n2.a;

        return result;
    }

    public static bool operator ==(BigNatural n1, BigNatural n2) => n1.CompareTo(n2) == 0;

    public static bool operator !=(BigNatural n1, BigNatural n2) => n1.CompareTo(n2) != 0;

    public static explicit operator BigNatural(int i)
    {
        BigNatural n = new BigNatural();
        n.a = (ulong)i;
        return n;
    }

    // public static implicit operator BigNatural(int i)
    // {
    //     BigNatural n = new BigNatural();
    //     n.a = (ulong)i;
    //     return n;
    // }
}