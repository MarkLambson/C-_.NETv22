
Console.WriteLine("\n\n**Let's learn LINQ**\n\n");

List<int> numbers = new List<int>()
{
  5, 15, 20, 0, 1, 3, 25
};

List<int> numsAboveTen = numbers.Where(num => num > 10).ToList();
// List<int> numsAboveTen = numbers.Where(n => n > 10).ToList();

Console.WriteLine(String.Join(" ,", numsAboveTen));



List<string> names = new List<string>()
{
  "Neil", "Mark", "Lauren", "Jake", "Adam", "Garrett"
};

int ShortestLength = names.Min(name => name.Length);
Console.WriteLine($"The shortest name is {ShortestLength} long");




List<VideoGame> games = new List<VideoGame> {
    new VideoGame("Apex Legends", "Riot", "E", 0, "Xbox"),
    new VideoGame("The Last of Us", "Naughty Dog", "M", 39.99, "PlayStation"),
    new VideoGame("Untitled Goose Game", "House House", "E", 29.99, "PC"),
    new VideoGame("Super Mario Bros.", "Nintendo", "E", 49.99, "SNES"),
    new VideoGame("Elden Ring", "FromSoftware", "M", 59.99, "PC"),
    new VideoGame("World of Warcraft", "Blizzard", "E", 49.99, "PC"),
    new VideoGame("Overwatch 2", "Blizzard", "T", 0, "PC")
};

VideoGame? game = games.FirstOrDefault(game => game.Title == "Overwatch 2");

if (game != null)
{
    Console.WriteLine(game.ToString());
}
else 
{
    Console.WriteLine("Not found");
    
}

List<double> Prices = games.Select(game => game.Price).ToList();
Console.WriteLine(String.Join(", ", Prices));

bool FreeStuff = games.Any(game => game.Price == 0);
bool AllFree = games.All(game => game.Price == 0);
Console.WriteLine($"There are free games: {FreeStuff}");
Console.WriteLine($"All the games are free: {AllFree}");

List<VideoGame> ThreeCheapest = games.OrderBy(g => g.Price).Take(3).ToList();


void PrintGames (List<VideoGame> games)
{
    foreach (VideoGame game in games)
    {
        Console.WriteLine(game.ToString());
        
    }
}

// Console.WriteLine("***Three cheapest***");
// PrintGames(ThreeCheapest);

List<VideoGame> PCByPrice = games.Where(game => game.Platform.Contains("PC")).OrderBy(game => game.Price).ToList();
PrintGames(PCByPrice);