using System;

public static class World
{
    private static NPC[] NPCs { get; set; } = new NPC[10000];
    private static int index { get; set; } = 0;
    public static int TotalCoins { get; private set; } = World.NPCs.Length * 10;
    public static int Round { get; private set; } = 0;
    public static int Bankrupt { get; private set; } = 0;
    public static void GerateNPCs
        (int cooperator, int cheater, int copycat, int fearful, int grudger)
    {
        if (cooperator + cheater + copycat + fearful + grudger != World.NPCs.Length)
            throw new Exception();
        for (int i = 0; i < cooperator; i++)
            World.AddNPC(new Cooperator());
        for (int i = 0; i < cheater; i++)
            World.AddNPC(new Cheater());
        for (int i = 0; i < copycat; i++)
            World.AddNPC(new Copycat());
        for (int i = 0; i < fearful; i++)
            World.AddNPC(new Fearful());
        for (int i = 0; i < grudger; i++)
            World.AddNPC(new Grudger());
    }
    private static void AddNPC(NPC npc)
    {
        World.NPCs[World.index] = npc;
        World.index++;
    }
    public static void Play()
    {
        Random r = new Random();
        
        NPC npc1 = null, npc2 = null;
        while (true)
        {
            npc1 = World.NPCs[r.Next(World.NPCs.Length)];
            npc2 = World.NPCs[r.Next(World.NPCs.Length)];
            if ((npc1.Coins > 0 && npc2.Coins > 0) && (npc1 != npc2))
                break;
        }

        if (npc1.decision() && npc2.decision())
        {
            npc1.receive(1);
            npc2.receive(1);
            World.TotalCoins += 2;
        }
        else if (npc1.decision() && !npc2.decision())
        {
            npc1.receive(-1);
            npc2.receive(4);
            World.TotalCoins += 3;
        }
        else if (!npc1.decision() && npc2.decision())
        {
            npc1.receive(4);
            npc2.receive(-1);
            World.TotalCoins += 3;
        }
        else
        {
            npc1.receive(0);
            npc2.receive(0);
        }

        if (npc1.Coins <= 0)
            World.Bankrupt += 1;

        if (npc2.Coins <= 0)
            World.Bankrupt += 1;

        World.Round += 1;
    }
}