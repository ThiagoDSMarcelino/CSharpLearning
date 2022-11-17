using System;
public class Heavy : Entity
{
    public Heavy()
    {
        Weapon gun = new Minigun();
        this.Name = "Heavy";
        this.Life = 300;
        this.Weapon = gun;
    }
    public override void Attack(Entity target, string where, int distance){
        Random r = new Random();
        bool isCrit = r.Next(100) < 2; 
        int longRange = distance > 50 ? 0 : distance > 25 ? 1 : 2;
        int damage = r.Next(this.Weapon.MinDamage[longRange], this.Weapon.MinDamage[longRange]);
        if (where == "foot") {
            damage = damage / 2;
        } else if (where == "head") {
            damage = damage * 2;
        }
        damage = isCrit ? damage * 2 : damage;
        target.ReciveDamage(damage);
    }
    public override void ReciveDamage(int damage)
    {
        this.Life -= damage;
    }
}