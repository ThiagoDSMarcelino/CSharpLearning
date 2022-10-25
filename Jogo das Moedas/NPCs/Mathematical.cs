using System;
public class Mathematical : NPC
{
    public override bool decision()
    {
        Random r = new Random();
        return r.Next(4) == 0;
    }
}