public class Grudger : NPC
{
    private bool willHelp { get; set; } = true;
    public override bool decision() => this.willHelp;

    public override void receive(int value)
    {
        if (value < 1)
            this.willHelp = false;
        base.receive(value);
    }
}