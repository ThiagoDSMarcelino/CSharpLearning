using System;

World.GerateNPCs(1500, 2500, 2000, 3000, 1000);

while (World.Round < 1000000)
{
    World.Play();
}
Console.WriteLine($"Round: {World.Round}");
Console.WriteLine($"Moedas Totais: {World.TotalCoins}");
Console.WriteLine($"Falidos: {World.Bankrupt}");