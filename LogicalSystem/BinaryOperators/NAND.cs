public class NAND : BinaryOperator
{
    public override bool Compute(bool X, bool Y) => !(X && Y);
}