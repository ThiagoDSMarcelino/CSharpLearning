public class EmptySet : Set
{
    public override bool IsIn(Set set)
    {
        return false;
    }
    public override bool Equals(object obj)
    {
        return obj is EmptySet;
    }
    public override Set Union(Set set)
    {
        return set;
    }
    override Intersec
}