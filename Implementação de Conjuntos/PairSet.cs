public class PairSet : Set
{
    public PairSet(Set a, Set b)
    {
        A = a;
        B = b;
    }
    public Set A { get; set; }
    public Set B { get; set; }
    public override bool IsIn(Set set)
    {
        return A.Equals(set) || B.Equals(set);
    }
    public override bool Equals(object obj)
    {
        if (obj is PairSet pair)
        {
            return (pair.A.Equals(this.A) && pair.B.Equals(this.B))
                || (pair.A.Equals(this.B) && pair.B.Equals(this.A))
                || (pair.A.Equals(pair.B) && (pair.A.Equals(this.A) || pair.A.Equals(this.B)));
        }
        return false;
    }
}