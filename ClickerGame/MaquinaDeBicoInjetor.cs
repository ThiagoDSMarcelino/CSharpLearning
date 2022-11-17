
public class MaquinaDeBicoInjetor : Machine
{
    public override double Price { get; protected set; } = 100;
    protected override int productValue { get; set; } = 60;

    protected override double formula(int quantity, double price) => price * Math.Pow(2, quantity);
}