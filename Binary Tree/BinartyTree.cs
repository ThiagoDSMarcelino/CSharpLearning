public class BinaryTree<T>
    where T : IComparable<T>
{
    public T Value { get; private set; }
    public BinaryTree<T>? Left { get; private set; } = null;
    public BinaryTree<T>? Right { get; private set; } = null;
    public void Add(T value)
    {
        if (this.Value is null || this.Value.CompareTo(default(T)) == 0)
            this.Value = value;
        else if (this.Value.CompareTo(value) <= 0)
        {
            this.Left = new BinaryTree<T>();
            this.Left.Add(value);
        }
        else
        {
            this.Right = new BinaryTree<T>();
            this.Right.Add(value);
        }
    }
    public bool Contains(T value)
    {
        if (this.Value.CompareTo(value) == 0)
            return true;
        else if (this.Left != null && this.Value.CompareTo(value) < 0)
            return this.Left.Contains(value);
        else if (this.Right != null && this.Value.CompareTo(value) > 0)
            return this.Right.Contains(value);
        else
            return false;
    }
}