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
        
        var properties = typeof(CasoCovid).GetProperties();
        while (it.MoveNext())
        {
            var item = it.Current.Replace("\"", "").Split(';');
            CasoCovid newCasoCovid = new CasoCovid();
            foreach (var prop in properties)
                newCasoCovid.SetValues(prop.Name, item[header.IndexOf(prop.Name)]);
            
            if
            (
                newCasoCovid.CLASSI_FIN == 5 && 
                newCasoCovid.EVOLUCAO != 0 &&
                newCasoCovid.VACINA_COV != 0
            )
                yield return newCasoCovid;
        }
    }
    public static IEnumerable<CasoCovid> QtdDoses(this IEnumerable<CasoCovid> coll, int qtdDoses)
    {
        var it = coll.GetEnumerator();
        while (it.MoveNext())
        {
            var item = it.Current;
            switch (qtdDoses)
            {
                case 0:
                    if (item.VACINA_COV == 2)
                        yield return item;
                    break;
                
                case 1:
                    if (item.FAB_COV_1 != default(string) && item.FAB_COV_2 == default(string))
                        yield return item;
                    break;
                case 2:
                    if (item.FAB_COV_2 != default(string) && item.FAB_COVREF == default(string))
                        yield return item;
                    break;
                case 3:
                    if (item.FAB_COVREF != default(string))
                        yield return item;
                    break;
            }
        }
            
    }
    public static IEnumerable<CasoCovid> Estatisticas(this IEnumerable<CasoCovid> coll, string name)
    {
        int vivos = 0;
        int mortos = 0;
        var it = coll.GetEnumerator();

        while (it.MoveNext())
        {
            var item = it.Current;
            if (item.EVOLUCAO == 1)
                vivos++;
            else if (item.EVOLUCAO == 2)
                mortos++;
        }

        float total = vivos + mortos;
        string dataStr = "";
        dataStr += $"Porcentagem de vivos e mortos para aqueles que tomaram até a {name}\n";
        dataStr += $"Vivos: {vivos / total * 100}\n";
        dataStr += $"Mortos: {mortos / total * 100}\n";
        Console.WriteLine(dataStr);
        return coll;
    }
    public static int CurePerVac(this IEnumerable<CasoCovid> coll, string vacName)
    {
        int vacCount = 0;
        var it = coll.GetEnumerator();
        while (it.MoveNext())
        {
            var item = it.Current;
            if (item.EVOLUCAO == 1)
            {
                if (item.FAB_COV_1 != null && item.FAB_COV_1.Contains(vacName, StringComparison.OrdinalIgnoreCase))
                    vacCount++;
                if (item.FAB_COV_2 != null && item.FAB_COV_2.Contains(vacName, StringComparison.OrdinalIgnoreCase))
                    vacCount++;
                if (item.FAB_COVREF != null && item.FAB_COVREF.Contains(vacName, StringComparison.OrdinalIgnoreCase))
                    vacCount++;
            }
        }
        return vacCount;
    }
}