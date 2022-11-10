using System;
using System.Linq;
using System.Collections.Generic;

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

// foreach (var cl in query)
//     Console.WriteLine($"Doses tomadas: {cl.NumberVacs} Taxa de letalidade: {cl.Lethality * 100}%");

// Ex. 2
List<string[]> allVac = new List<string[]>();
allVac.Add(new string[] { "CORONAVAC", "CAR", "CO", "CRO" });
allVac.Add(new string[] { "BUTANTAN", "BU", "BT", "BI", "TANTAN" });
allVac.Add(new string[] { "ASTRAZENECA", "AZ", "AS", "ATRA" });
allVac.Add(new string[] { "FIOCRUZ", "FI", "CRUZ" });
allVac.Add(new string[] { "PFIZER", "PHI", "PF", "FI", "PZ", "PI", "FAI", "FHI", "PLI", "PTI", "PHY", "FEI", "PAI", "PRI" });
allVac.Add(new string[] { "OXFORD", "OX", "0X", "ORF", "ORO", "OSF", "OKF", "EXF", "OSWALDO", "OSVALDO" });
allVac.Add(new string[] { "SINOVAC", "SIN", "SIN" });
allVac.Add(new string[] { "JANSSEN", "JANS", "JAN", "JENS", "JONS", "JHAN", "JONH", "JOHS", "JOHN", "JHON", "JAHN", "JAHS" });
allVac.Add(new string[] { "INDIA" });

var query2 = df
            .Where(c => c.NumberVacs > 0)
            .Select(c => 
                {
                    var vac1 = allVac.FirstOrDefault(vacs => 
                            vacs.Any(
                                n => c.Vac1.Contains(n, StringComparison.OrdinalIgnoreCase)));
                    
                    var vac2 = allVac.FirstOrDefault(vacs => 
                            vacs.Any(
                                n => c.Vac2.Contains(n, StringComparison.OrdinalIgnoreCase)));
                    
                    var vacRef = allVac.FirstOrDefault(vacs => 
                            vacs.Any(
                                n => c.VacRef.Contains(n, StringComparison.OrdinalIgnoreCase)));
                    
                    
                    c.Vac1 = vac1 != null ? vac1[0] : "Desconhecido";
                    c.Vac2 = vac2 != null ? vac2[0] : "Desconhecido";
                    c.VacRef = vacRef != null ? vacRef[0] : "Desconhecido";

                    return c;
                })
            .GroupBy(c => $"{c.Vac1}/{c.Vac2}")
            .Select(g => new {
                VacNanme = g.Key,
                Lethality = g.Average(c => c.IsDead ? 1.0 : 0.0)
            });

foreach (var cl in query2)
    Console.WriteLine($"VacName: {cl.VacNanme} Taxa de letalidade: {cl.Lethality * 100}%");