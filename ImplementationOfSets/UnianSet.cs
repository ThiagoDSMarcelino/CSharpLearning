public class UnionSet: Set
{
    public UnionSet(Set a, Set b)
    {
        A = a;
        B = b;
    }
    public Set A { get; set; }
    public Set B { get; set; }
    public override bool IsIn(Set set)
    {
        return A.IsIn(set) ||  B.IsIn(set);
    }
}