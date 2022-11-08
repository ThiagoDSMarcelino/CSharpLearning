using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

public static class ExtensionMethods
{
    public static IEnumerable<string> Open(this string file)
    {
        var stream = new StreamReader(file);

        while (!stream.EndOfStream)
            yield return stream.ReadLine();

        stream.Close();
    }
    public static IEnumerable<T> Save_CSV<T>(this IEnumerable<T> coll, string path)
    {
        var stream = new StreamWriter($"./{path}");
        foreach (var item in coll)
            stream.WriteLine(item);
        stream.Close();
        return coll;
    }
    public static IEnumerable<string> Read(this IEnumerable<string> coll, IDictionary<string, int> obrigatorio, IDictionary<string, int> essencial)
    {
        var it = coll.GetEnumerator();
        var header = it.MoveNext() ? it.Current.Replace("\"", "").Split(';').ToList() : null;
        if (header == null)
            throw new Exception();

        while (it.MoveNext())
        {
            var item = it.Current.Replace("\"", "").Split(';');
            string newData = "";
            bool todosDados = true;

            foreach (var data in obrigatorio)
            {
                newData += $"{data.Key}: {item[data.Value]};";
                if (item[data.Value] == "")
                    todosDados = false;
            }

            foreach (var data in essencial)
                newData += $"{data.Key}: {item[data.Value]};";
            
            if (todosDados)
                yield return newData;
        }
    }
    public static void Estatisticas(this IEnumerable<string> coll)
    {
        var it = coll.GetEnumerator();
        var header = it.MoveNext() ? it.Current.Replace("\"", "").Split(';').ToList() : null;
        if (header == null)
            throw new Exception();

        while (it.MoveNext())
        {
            var item = it.Current.Replace(" ", "").Split(';');
            
        }
    }
    public static int GetIndex(this IEnumerable<string> coll, string value)
    {
        var it = coll.GetEnumerator();
        var header = it.MoveNext() ? it.Current.Replace("\"", "").Split(';').ToList() : null;
        if (header == null)
            throw new Exception();
        return header.IndexOf(value);
    }
}