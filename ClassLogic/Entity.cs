public abstract class Entity
{
    public string Name { get; protected set; }
    public int Life { get; protected set; }
    public Weapon Weapon { get; protected set; }
    public abstract void Attack(Entity target, string where, int distance);
    public abstract void ReciveDamage(int damage);
}