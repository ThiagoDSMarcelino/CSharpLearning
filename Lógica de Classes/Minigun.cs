public class Minigun : Weapon
{
    public Minigun() : base("Minigun")
    {
        this.Name = "Minigun";
        this.MinDamage = new int[] { 4, 12, 32 };
        this.MaxDamage = new int[] { 12, 30, 50 };
        this.FireRate = 105;
        this.Ammo = 200;
        this.ReloadTime = 2.5F;
    }
}