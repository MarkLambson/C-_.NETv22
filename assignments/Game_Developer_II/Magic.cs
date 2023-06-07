public class Magic : Enemy
{
    //magic constructor using inheritence
    public Magic(string name) : base(name)
    {
        Health = 80;
        AttackList = new List<Attack>() { new Attack("Fireball", 25), new Attack("Lightning Bolt", 20), new Attack("Staff Strike", 10) };
    }

    //magic method
    public void Heal(Enemy target)
    {
        target.Health += 40;
        Console.WriteLine($"{Name} uses a healing spell on {target.Name}! {target.Name}'s Health has increased by 40hp");
    }
}