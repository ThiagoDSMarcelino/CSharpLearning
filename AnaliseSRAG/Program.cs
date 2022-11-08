using System;
using System.Linq;

var df = "Data/INFLUD21-24-10-2022.csv".Open();

Console.Clear();
var sla = df.Take(5000).Read().Save_CSV("Data/testes/sla.csv");