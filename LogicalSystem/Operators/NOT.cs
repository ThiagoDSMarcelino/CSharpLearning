public class NOT : Operator
{
    private Operator input = null;

    public override void Update()
    {
        this.state = !input.Output;
        this.Next?.Update();
    }

    protected override void ConnectInput(Operator component)
    {
        if (input == null)
            this.input = component;
        else
            throw new System.Exception("A porta já está sendo usada");
        this.Update();
    }
}