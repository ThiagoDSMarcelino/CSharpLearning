using System;
using System.Collections;
using System.Collections.Generic;

public class List<T> : IEnumerable<T>
{
    private T[] values = new T[10];
    private int index = 0;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.index)
                throw new IndexOutOfRangeException();
            return values[index];
        }
        set
        {
            if (index < 0 || index >= this.index)
                throw new IndexOutOfRangeException();
            values[index] = value;
        }
    }
    public int Length => this.index;
    public void Add(T value)
    {
        if (this.index == values.Length)
        {
            T[] newValues = new T[values.Length * 2];
            for (int i = 0; i < values.Length; i++)
                newValues[i] = values[i];
            this.values = newValues;
        }

        values[this.index] = value;
        this.index++;
    }

    public System.Collections.Generic.IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> Enumerator
    {
        get
        {
            ListIterator<T> it = new ListIterator<T>(this);
            return it;
        }
    }
}