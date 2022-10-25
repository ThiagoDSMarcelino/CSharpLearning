public abstract class Set
{
    public abstract bool IsIn(Set set);
    public virtual Set Union(Set set)
    {
        UnionSet unionSet = new UnionSet(this, set);
        return unionSet;
    }
    public virtual Set Intersect(Set set)
    {
        IntersectSet unionSet = new IntersectSet(this, set);
        return unionSet;
    }
}