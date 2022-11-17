public abstract class BinaryOperator : Operator
{
    private Operator inputX = null;
    private Operator inputY = null;

    public abstract bool Compute(bool X, bool Y);

    public override void Update()
    {
        if (inputX == null || inputY == null)
            return;

        bool newState = Compute(inputX.Output, inputY.Output);
        if (newState == state)
            return;
        
        this.state = newState;
        this.Next?.Update();
    }

    protected override void ConnectInput(Operator component)
    {
        if (inputX == null)
            this.inputX = component;
        else if (inputY == null)
            this.inputY = component;
        else
            throw new System.Exception("Todas portas estão sendo usadas");
        this.Update();
    }
}