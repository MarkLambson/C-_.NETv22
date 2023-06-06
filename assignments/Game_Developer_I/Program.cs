//enemy instance
Enemy enemy1 = new Enemy("Dreg");

//attack instances
Attack atk1 = new Attack("Emotional Damage", 15);
Attack atk2 = new Attack("Step on LEGO", 25);
Attack atk3 = new Attack("Annoy", 5);

//adding attacks to enemy1's AttackList
enemy1.AttackList.Add(atk1);
enemy1.AttackList.Add(atk2);
enemy1.AttackList.Add(atk3);

//calling enemy1's random attack from List
Console.WriteLine(enemy1.RandomAttack().Name);


// Console.WriteLine("It's working... IT'S WORKING!!!!");
//^ test to make sure we're in business