using System;
using System.Collections.Generic;
using System.Linq;

var df = "Data/INFLUD21-24-10-2022.csv".Open();

IDictionary<string, int> obrigatorio = new Dictionary<string, int>()
{
    {"CLASSI_FIN", df.GetIndex("CLASSI_FIN")},
    {"VACINA_COV", df.GetIndex("VACINA_COV")},
    {"EVOLUCAO", df.GetIndex("EVOLUCAO")},
};
IDictionary<string, int> essencial = new Dictionary<string, int>()
{
    {"DOSE_1_COV", df.GetIndex("DOSE_1_COV")},
    {"DOSE_2_COV", df.GetIndex("DOSE_2_COV")},
    {"DOSE_REF", df.GetIndex("DOSE_REF")},
};

List<string> sla = new List<string>();

var sla = df.Read(obrigatorio, essencial).Save_CSV("Data/testes/sla.csv");
