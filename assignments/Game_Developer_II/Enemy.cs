public class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public List<Attack> AttackList { get; set; }

    //enemy constructor
    public Enemy(string name)
    {
        Name = name;
        Health = 100;
        AttackList = new List<Attack>();
    }

    //enemy methods
    protected void ReduceHealth(int amount)
    {
        Health -= amount;
        if (Health < 0)
        {
            Health = 0;
        }
    }
    public virtual void PerformAttack(Enemy target, Attack chosenAttack)
    {
        target.ReduceHealth(chosenAttack.DmgAmt);
        Console.WriteLine($"{Name} attacks {target.Name} with {chosenAttack.Name}! It deals {chosenAttack.DmgAmt} damage! {target.Name} now has {target.Health}hp left!");
    }


    public void RandomAtk()
    {
        Random random = new Random();
        int idx = random.Next(AttackList.Count);
        Attack attack = AttackList[idx];
        Console.WriteLine($"{Name} uses {attack.Name}! Health has been reduced by {attack.DmgAmt}.");
    }
}