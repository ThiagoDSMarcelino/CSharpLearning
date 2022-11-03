public static class ExtensionMethods
{
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> coll, T item)
    {
        yield return item;

        foreach (var collItem in coll)
            yield return collItem;
    }
    public static IEnumerable<T> Append<T>(this IEnumerable<T> coll, T item)
    {
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            yield return it.Current;
        
        yield return item;
    }
    public static T FirstOrDefault<T>(this IEnumerable<T> coll)
    {
        var it = coll.GetEnumerator();
        return it.MoveNext() ? it.Current : default(T);
    }
    public static T LastOrDefault<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            count++;
        
        return count == 0 ? default(T) : it.Current;
    }
    public static T[] ToArray<T>(this IEnumerable<T> coll)
    {
        T[] arr = new T[coll.Count()];

        var it = coll.GetEnumerator();
        for (int index = 0; it.MoveNext(); index++)
            arr[index] = it.Current;
        
        return arr;
    }
    public static List<T> ToList<T>(this IEnumerable<T> coll)
    {
        List<T> list = new List<T>();

        var it = coll.GetEnumerator();
        while (it.MoveNext())
            list.Add(it.Current);
        
        return list;
    }
    public static int Count<T>(this IEnumerable<T> coll)
    {
        int count = 0;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
            count++;
        
        return count;
    }
    public static IEnumerable<T> Take<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++)
            yield return it.Current;
    }
    public static IEnumerable<T> Skip<T>(this IEnumerable<T> coll, int N)
    {
        var it = coll.GetEnumerator();
        for (int i = 0; i < N && it.MoveNext(); i++);
        
        while (it.MoveNext())
            yield return it.Current;
    }
    public static IEnumerable<string> Open(this string file)
    {
        var stream = new StreamReader(file);

        while (!stream.EndOfStream)
            yield return stream.ReadLine();

        stream.Close();
    }
    public static IEnumerable<string[]> Split(this IEnumerable<string> coll, string value = ";")
    {
        foreach (var line in coll)
            yield return line.Split(value);
    }
    public static IEnumerable<string> Find(this IEnumerable<string> coll, string findValue)
    {
        foreach (var line in coll)
            if (line.Contains(findValue.ToUpper()))
                yield return line;
    }
    public static IEnumerable<string> NotFind(this IEnumerable<string> coll, string findValue)
    {
        foreach (var line in coll)
            if (!line.Contains(findValue.ToUpper()))
                yield return line;
    }
    public static int Sum(this IEnumerable<string> coll)
    {
        coll.Split(",");
        foreach (var element in coll)
            if (element.Count() < 2)
            Console.WriteLine(element);
        return 1;
    }
}