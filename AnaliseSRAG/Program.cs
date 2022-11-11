using System;
using System.Linq;

var df = "Data/INFLUD21-24-10-2022.csv"
    .Open()
    .Read()
    .Where(c => c.IsCovid);

// Ex. 1
var query = df
        .GroupBy(c => c.NumberVacs)
        .Select(g => new {
            NumberVacs = g.Key,
            Lethality = g.Average(c => c.IsDead ? 1.0 : 0.0)
        });

Console.WriteLine("Doses por morte");
foreach (var cl in query)
    Console.WriteLine($"Doses tomadas: {cl.NumberVacs} Taxa de letalidade: {cl.Lethality * 100}%");

// Ex. 2
var query2 = df
            .Where(c => c.NumberVacs > 0)
            .GroupBy(c => c.Vaccine)
            .Select(g => new {
                VacName = g.Key,
                QtdVac = g.Count(),
                Lethality = g.Average(c => c.IsDead ? 1.0 : 0.0)
            });

Console.WriteLine("\nVacina por morte");
foreach (var cl in query2)
    Console.WriteLine($"VacName: {cl.VacName} Qunatidade de vacinas: {cl.QtdVac} Taxa de letalidade: {cl.Lethality * 100}%");

// Ex. 3
var query3 = df
            .GroupBy(c => c.Age / 8)
            .Select(g => new {
                Gruop = g.Key switch
                {
                    1 => "Jovens/Crianças",
                    2 => "Adultos",
                    3 => "Idosos",
                    _ => "Mucei"
                },
                Lethality = g.Average(c => c.IsDead ? 1.0 : 0.0)
            });
Console.WriteLine("\nIdade por morte");
Console.WriteLine($"Média de idade: {df.Average(c => c.Age)}");
foreach (var cl in query3)
    Console.WriteLine($"Grupo: {cl.Gruop} Taxa de letalidade: {cl.Lethality * 100}%");