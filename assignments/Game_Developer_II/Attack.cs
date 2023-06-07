public class Attack
{
    public string Name { get; set; }
    public int DmgAmt { get; set; }

    //attack constructor
    public Attack(string name, int dmg)
    {
        Name = name;
        DmgAmt = dmg;
    }
}