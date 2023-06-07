public class Melee : Enemy
{
    //melee constructor using inheritence
    public Melee(string name) : base(name)
    {
        Name = name;
        Health = 120;
        AttackList = new List<Attack>() { new Attack("Punch", 20), new Attack("Kick", 15), new Attack("Tackle", 25) };
    }

    //melee method
    public void Rage(Enemy target)
    {
        Random random = new Random();
        int idx = random.Next(AttackList.Count);
        Attack randomAttack = AttackList[idx];
        int rageBuff = randomAttack.DmgAmt + 10;
        PerformAttack(target, new Attack(randomAttack.Name, rageBuff));
    }
}