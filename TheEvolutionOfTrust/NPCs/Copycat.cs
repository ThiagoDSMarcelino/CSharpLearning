public class Copycat : NPC
{
    private bool willHelp { get; set; } = true;
    public override bool decision() => this.willHelp;

    public override void receive(int value)
    {
        this.willHelp = value > 0;
        base.receive(value);
    }
}