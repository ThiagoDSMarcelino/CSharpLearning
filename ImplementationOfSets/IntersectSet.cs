public class IntersectSet: Set
{
    public IntersectSet(Set a, Set b)
    {
        A = a;
        B = b;
    }
    public Set A { get; set; }
    public Set B { get; set; }
    public override bool IsIn(Set set) => A.IsIn(set) && B.IsIn(set);
}