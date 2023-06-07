//Create instances of the Melee, Ranged, and Magic Caster classes
Console.WriteLine("1)");
Console.WriteLine("instances successfully created");
Melee meleeFighter = new Melee("Melee Fighter");
Ranged rangedFighter = new Ranged("Ranged Fighter");
Magic magicCaster = new Magic("Magic Caster");

//Perform the Kick Attack from your Melee class character on your Ranged character
Console.WriteLine("2)");
meleeFighter.PerformAttack(rangedFighter, meleeFighter.AttackList[1]);

//Perform the Rage method from your Melee class character on your Magic Caster character
Console.WriteLine("3)");
meleeFighter.Rage(magicCaster);

//Perform the Shoot an Arrow Attack from your Ranged character on your Melee character 
//(if you wrote everything as listed above, you should not have been able to attack due to the Distance constraint)
Console.WriteLine("4)");
rangedFighter.PerformAttack(meleeFighter, rangedFighter.AttackList[0]);

//Have your Ranged character perform the Dash method
Console.WriteLine("5)");
rangedFighter.Dash();

//Perform another Shoot an Arrow Attack from your Ranged character 
//(this one should have worked now if everything is set up properly)
Console.WriteLine("6)");
rangedFighter.PerformAttack(meleeFighter, rangedFighter.AttackList[0]);

//Perform a Fireball Attack from your Magic Caster on your Melee character
Console.WriteLine("7)");
magicCaster.PerformAttack(meleeFighter, magicCaster.AttackList[0]);

//Have the Magic Caster perform the Heal method on the Ranged character
Console.WriteLine("8)");
magicCaster.Heal(rangedFighter);

//Have the Magic Caster perform the Heal method on themselves
Console.WriteLine("9)");
magicCaster.Heal(magicCaster);




//Console.WriteLine("It' working... IT'S WORKING!!!");
//testing to see if we're in business