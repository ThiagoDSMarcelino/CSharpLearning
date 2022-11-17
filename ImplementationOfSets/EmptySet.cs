public class EmptySet : Set
{
    public override bool IsIn(Set set) => false;
    public override bool Equals(object obj) => obj is EmptySet;
    public override Set Union(Set set) => set;
}