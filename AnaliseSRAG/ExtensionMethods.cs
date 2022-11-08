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
    public static IEnumerable<string> Read(this IEnumerable<string> coll)
    {
        var it = coll.GetEnumerator();
        var header = it.MoveNext() ? it.Current.Replace("\"", "").Split(';').ToList() : null;
        if (header == null)
            throw new Exception();
        
        int[] dataIndex = new int[]
        {
            header.IndexOf("CLASSI_FIN"),
            header.IndexOf("VACINA_COV"),
            header.IndexOf("DOSE_1_COV"),
            header.IndexOf("DOSE_2_COV"),
            header.IndexOf("DOSE_REF"),

        };
        while (it.MoveNext())
        {
            var item = it.Current.Replace("\"", "").Split(';');
            string newData = "";
            bool sla = false;

            foreach (var data in dataIndex)
            {
                newData += $"{item[data]} -- ";
                if (item[data] == "")
                    sla = true;
            }
            // if (sla)
            //     Console.WriteLine(newData);
            yield return newData;
        }
    }
    public static IEnumerable<T> Save_CSV<T>(this IEnumerable<T> coll, string path)
    {
        var stream = new StreamWriter($"./{path}");
        foreach (var item in coll)
            stream.WriteLine(item);
        stream.Close();
        return coll;
    }
}