List< Eruption > eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

//PrintNames method to help with 14
void PrintNames(List<Eruption> eruptions)
{
    foreach (Eruption eruption in eruptions)
    {
        Console.WriteLine(eruption.Volcano.ToString());

    }
}

//⁡⁢⁣⁢---------------------------------------------------------ASSINGMENT TASKS BELOW--------------------------------------------------------------⁡//

// 1. Use LINQ to find the first eruption that is in Chile and print the result.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("1. Use LINQ to find the first eruption that is in Chile and print the result.");
Eruption chile = eruptions.First(eruption => eruption.Location == "Chile");
Console.WriteLine(chile.ToString());
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 2. Find the first eruption from the "Hawaiian Is" location and print it. If none is found, print "No Hawaiian Is Eruption found."
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("2. Find the first eruption from the 'Hawaiian Is' location and print it. If none is found, print 'No Hawaiian Is Eruption found'");
Eruption? hawaiiIs = eruptions.FirstOrDefault(eruption => eruption.Location == "Hawaii Is");
if (hawaiiIs != null)
{
    Console.WriteLine(hawaiiIs.ToString());
}
else
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 3. Find the first eruption from the "Greenland" location and print it. If none is found, print "No Greenland Eruption found."
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("3. Find the first eruption from the 'Greenland' location and print it. If none is found, print 'No Greenland Eruption found'");
Eruption? greenland = eruptions.FirstOrDefault(eruption => eruption.Location == "Greenland");
if (greenland != null)
{
    Console.WriteLine(greenland.ToString());
}
else
{
    Console.WriteLine("No Greenland Eruption found.");
}
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 4. Find the first eruption that is after the year 1900 AND in "New Zealand", then print it.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("4. Find the first eruption that is after the year 1900 AND in 'New Zealand', then print it");
List<Eruption> after1900 = eruptions.Where(eruption => eruption.Year > 1900).ToList();
Eruption newZealand = after1900.First(eruption => eruption.Location == "New Zealand");
Console.WriteLine(newZealand.ToString());
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 5. Find all eruptions where the volcano's elevation is over 2000m and print them.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("5. Find all eruptions where the volcano's elevation is over 2000m and print them");
List<Eruption> elevation2000m = eruptions.Where(eruption => eruption.ElevationInMeters > 2000).ToList();
PrintEach(elevation2000m);
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 6. Find all eruptions where the volcano's name starts with "L" and print them. Also print the number of eruptions found.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("6. Find all eruptions where the volcano's name starts with 'L' and print them. Also print the number of eruptions found");
List<Eruption> startsWithL = eruptions.Where(eruption => eruption.Volcano.StartsWith("L")).ToList();
PrintEach(startsWithL);
Console.WriteLine(startsWithL.Count);
Console.WriteLine("^Number of eruptions found");
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 7. Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("7. Find the highest elevation, and print only that integer (Hint: Look up how to use LINQ to find the max!)");
int highestElevation = eruptions.Max(eruption => eruption.ElevationInMeters);
Console.WriteLine(highestElevation);
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 8. Use the highest elevation variable to find and print the name of the Volcano with that elevation.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("8. Use the highest elevation variable to find and print the name of the Volcano with that elevation.");
Eruption nameHighestElevation = eruptions.First(eruption => eruption.ElevationInMeters == highestElevation);
Console.WriteLine(nameHighestElevation.Volcano);
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 9. Print all Volcano names alphabetically.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("9. Print all Volcano names alphabetically.");
List<Eruption> alphabetical = eruptions.OrderBy(eruption => eruption.Volcano).ToList();
PrintEach(alphabetical);
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 10. Print the sum of all the elevations of the volcanoes combined.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("10. Print the sum of all the elevations of the volcanoes combined.");
int allElevation = eruptions.Sum(eruption => eruption.ElevationInMeters);
Console.WriteLine(allElevation);
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 11. Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("11. Print whether any volcanoes erupted in the year 2000 (Hint: look up the Any query)");
Console.WriteLine(eruptions.Any(eruption => eruption.Year == 2000));
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 12. Find all stratovolcanoes and print just the first three (Hint: look up Take)
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("12. Find all stratovolcanoes and print just the first three (Hint: look up Take)");
List<Eruption> threeStratovolcanoes = eruptions.Where(eruption => eruption.Type == "Stratovolcano").Take(3).ToList();
PrintEach(threeStratovolcanoes);
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 13. Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("13. Print all the eruptions that happened before the year 1000 CE alphabetically according to Volcano name.");
List<Eruption> before1000Alphabetical = eruptions.Where(eruption => eruption.Year < 1000).OrderBy(eruption => eruption.Volcano).ToList();
PrintEach(before1000Alphabetical);
//---------------------------------------------------------------------------------------------------------------------------------------------------//


// 14. Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.
Console.WriteLine("--------------------------------------------------------------------------------------------------------");
Console.WriteLine("14. Redo the last query, but this time use LINQ to only select the volcano's name so that only the names are printed.");
List<Eruption> before1000AlphabeticalNames = eruptions.Where(eruption => eruption.Year < 1000).OrderBy(eruption => eruption.Volcano).ToList();
PrintNames(before1000AlphabeticalNames);
//^PrintNames defined above under class
//---------------------------------------------------------------------------------------------------------------------------------------------------//