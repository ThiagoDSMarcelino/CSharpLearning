public abstract class Weapon
{
    protected Weapon(string name)
    {
        this.Name = name;
    }

    public string Name { get; protected set; }
    public int[] MinDamage { get; protected set; }
    public int[] MaxDamage { get; protected set; }
    public int FireRate { get; protected set; }
    public int Ammo { get; protected set; }
    public float ReloadTime { get; set; }
}