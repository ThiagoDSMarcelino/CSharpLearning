using System;

var df = "Data/LAB_PR_COV.csv"
    .Open()
    .Skip(1);
int total = df.Count();

var coronavac = df.FindAllList(new string[] { "CORONAVAC" });
var butantan = df.FindAllList(new string[] { "BUTANTAN" });
var astra = df.FindAllList(new string[] { "ASTRAZENECA", "ASTRAZENICA" });
var fiocruz = df.FindAllList(new string[] { "FIOCRUZ" });
var pfizer = df.FindAllList(new string[] { "PFIZER" });
var oxford = df.FindAllList(new string[] { "OXFORD" });
var sinovac = df.FindAllList(new string[] { "SINOVAC" });
var nao = df.FindAllList(new string[] { "NAO" });


coronavac.Save_CSV("Coronavac");
int sumCoronavac = coronavac.Sum();

Console.WriteLine(total);
int newTotal = coronavac.Count() + butantan.Count() + astra.Count() + fiocruz.Count() + pfizer.Count()+ sinovac.Count() + oxford.Count() + nao.Count();
Console.WriteLine(newTotal);
Console.WriteLine(coronavac.Count());
Console.WriteLine(butantan.Count());
Console.WriteLine(astra.Count());
Console.WriteLine(fiocruz.Count());
Console.WriteLine(pfizer.Count());
Console.WriteLine(oxford.Count());
Console.WriteLine(sinovac.Count());
Console.WriteLine(nao.Count());