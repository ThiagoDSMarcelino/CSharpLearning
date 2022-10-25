public class Input : Operator
{
    public bool IsOn
    {
        get => state;
        set
        {
            this.state = value;
            this.Update();
        }
    }
    public override bool Output => this.IsOn;
    public override void Update() => this.Next?.Update();
    protected override void ConnectInput(Operator component) => 
        throw new System.Exception("Não é possivel conectar componentes ao Input");
}