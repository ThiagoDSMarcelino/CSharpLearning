using System;

var df = "Data/INFLUD21-24-10-2022.csv".Open().Read();

// EX. 1
// var semVacina = df.QtdDoses(0).Estatisticas("Sem vacina");
// var primeiraDose = df.QtdDoses(1).Estatisticas("Priemira dose");
// var segundaDose = df.QtdDoses(2).Estatisticas("Segunda dose");
// var doseReforco = df.QtdDoses(3).Estatisticas("Dose de reforço");

// EX. 2
int india = df.CurePerVac("india");
int astrazeneca = df.CurePerVac("astrazeneca");
int butantan = df.CurePerVac("butantan");

Console.WriteLine(india);
Console.WriteLine(astrazeneca);
Console.WriteLine(butantan);