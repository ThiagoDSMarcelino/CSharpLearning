public class LinkedList<T>
{
    private LinkedListNode<T> first = null;
    private int index { get; set; } = 0;
    public int Lenght => index;
    public T this[int index]
    {
        get
        {
            if (first == null)
                throw new System.IndexOutOfRangeException();
            
            var crr = first;
            for (int i = 0; i < index; i++)
            {
                if (crr.Next == null)
                    throw new System.IndexOutOfRangeException();
                
                crr = crr.Next;
            }

            return crr.Value;
        }
        set
        {
            if (first == null)
                throw new System.IndexOutOfRangeException();
            
            var crr = first;
            for (int i = 0; i < index; i++)
            {
                if (crr.Next == null)
                    throw new System.IndexOutOfRangeException();
                
                crr = crr.Next;
            }

            crr.Value = value;
        }
    }
    public void Add(T value)
    {
        if (this.first == null)
        {
            first = new LinkedListNode<T>();
            first.Value = value;
            return;
        }

        var crr = first;
        while (crr.Next != null)
            crr = crr.Next;
        
        crr.Next = new LinkedListNode<T>();
        crr.Next.Value = value;
        this.index++;
    }
}