public abstract class NPC
{
    public int Coins { get; protected set; } = 10;
    public abstract bool decision();
    public virtual void receive(int value) => this.Coins += value;
}