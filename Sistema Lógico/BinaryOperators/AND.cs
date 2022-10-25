public class AND : BinaryOperator
{
    public override bool Compute(bool X, bool Y) => X && Y;
}