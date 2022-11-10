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
    public static IEnumerable<CasoCovid> Read(this IEnumerable<string> coll)
    {
        var it = coll.GetEnumerator();
        var header = it.MoveNext() ? it.Current.Replace("\"", "").Split(';').ToList() : null;
        if (header == null)
            throw new Exception();
        
        while (it.MoveNext())
        {
            var caso = it.Current.Replace("\"", "").Split(';');
            CasoCovid newCasoCovid = new CasoCovid();
            
            if (int.Parse(caso[header.IndexOf("NU_IDADE_N")]) < 0)
                continue;
            newCasoCovid.Age = byte.Parse(caso[header.IndexOf("NU_IDADE_N")]);
            newCasoCovid.IsDead = caso[header.IndexOf("EVOLUCAO")] == "2";
            newCasoCovid.IsCovid = caso[header.IndexOf("CLASSI_FIN")] == "5";
            if (caso[header.IndexOf("FAB_COV_1")] != "")
            {
                newCasoCovid.Vac1 = caso[header.IndexOf("FAB_COV_1")];
                newCasoCovid.NumberVacs++;
            }
            if (caso[header.IndexOf("FAB_COV_2")] != "")
            {
                newCasoCovid.Vac1 = caso[header.IndexOf("FAB_COV_2")];
                newCasoCovid.NumberVacs++;
            }
            if (caso[header.IndexOf("FAB_COVREF")] != "")
            {
                newCasoCovid.Vac1 = caso[header.IndexOf("FAB_COVREF")];
                newCasoCovid.NumberVacs++;
            }
            
            yield return newCasoCovid;
        }
    }
}