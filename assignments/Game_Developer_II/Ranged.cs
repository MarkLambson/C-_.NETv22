public class Ranged : Enemy
{
    //ranged constructor using inheritence
    public int Distance { get; set; }
    public Ranged(string name) : base(name)
    {
        Health = 100;
        Distance = 5;
        AttackList = new List<Attack>() { new Attack("Arrow Shot", 20), new Attack("Knife Throw", 15) };
    }

    //ranged methods
    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"{Name} uses Dash, {Name} can now use Ranged Attacks!");
    }

    public override void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (Distance >= 10)
        {
            base.PerformAttack(target, chosenAttack);
        }
        else
        {
            Console.WriteLine($"{Name} is too close! Use Dash to create space!");
        }
    }
}