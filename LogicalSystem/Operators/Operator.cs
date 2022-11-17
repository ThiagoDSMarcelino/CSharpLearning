public abstract class Operator
{
    public virtual bool Output { get => this.state; }
    protected Operator Next { get; private set; }
    protected bool state = false;
    public abstract void Update();
    protected abstract void ConnectInput(Operator component);
    public void Connect(Operator component){
        this.Next = component;
        this.Next.ConnectInput(this);
    }
}