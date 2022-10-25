public class Fearful : NPC
{
    private bool willHelp { get; set; } = true;
    public override bool decision() => this.willHelp;

    public override void receive(int value)
    {
        if (this.Coins == 1)
            this.willHelp = false;
        else
            this.willHelp = true;
        base.receive(value);
    }
}