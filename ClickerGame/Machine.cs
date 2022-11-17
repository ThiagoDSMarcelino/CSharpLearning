public abstract class Machine
{
    public abstract double Price { get; protected set; }
    protected abstract int productValue { get; set; }
    public int Quantity { get; protected set; } = 0;
    public int Gerate { get; set; } = 0;
    protected abstract double formula(int quantity, double price);
    public bool Buy()
    {
        if (this.Price > Factory.Coins) return false;
        Factory.Coins -= this.Price;
        this.Quantity++;
        this.Price = this.formula(this.Quantity, this.Price);
        this.Gerate = Quantity * productValue;
        return true;
    }
}