
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
    public static IEnumerable<string[]> Split(this IEnumerable<string> coll, char separetor = ';')
    {
        foreach (var line in coll)
            yield return line.Split(separetor);
    }
    public static IEnumerable<string> FindAll(this IEnumerable<string> coll, string findValue)
    {
        foreach (var line in coll)
            if (line.Contains(findValue.ToUpper()))
                yield return line;
    }
    public static int Sum(this IEnumerable<string> coll)
    {
        int total = 0;
        foreach (var line in coll.Split(','))
        {
            string number = "";
            foreach (var element in line[1])
            {
                if (!Char.IsNumber(element))
                    break;
                number += element;
            }
            if (number != "")
                total += int.Parse(number);
        }
        return total;
    }
    public static IEnumerable<string> FindAllList(this IEnumerable<string> coll, string[] findValues)
    {
        foreach (var line in coll)
            foreach (var value in findValues)
                if (line.Contains(value.ToUpper()))
                {
                    yield return line;
                    break;
                }

    }
    public static void Save_CSV<T>(this IEnumerable<T> coll, string name)
    {
        var stream = new StreamWriter($"./Data/{name}.csv");
        foreach (var item in coll)
            stream.WriteLine(item);
        stream.Close();
    }
}