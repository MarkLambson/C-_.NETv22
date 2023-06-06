public class Enemy 
{
    public string Name {get; set;}
    public int Health {get; set;}
    public List<Attack> AttackList {get; set;}

    //enemy constructor
    public Enemy(string name)
    {
        Name = name;
        Health = 100;
        AttackList = new List<Attack>();
    }

//enemy method
    public Attack RandomAttack()
    {
        Random rand = new Random();
        return AttackList[rand.Next(0, AttackList.Count)];
    }
}