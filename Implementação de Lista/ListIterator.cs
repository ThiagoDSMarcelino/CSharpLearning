using System.Collections.Generic;

public class ListIterator<T> : IEnumerator<T>
{
    private List<T> list;
    int index = -1;
    public ListIterator(List<T> list) => this.list = list;
    public object Current => list[index];

    T IEnumerator<T>.Current => throw new System.NotImplementedException();

    public bool MoveNext()
    {
        this.index++;
        return index < this.list.Length;
    }

    public void Reset() => index = -1;
}