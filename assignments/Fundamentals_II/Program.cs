//THREE BASIC ARRAYS
//Create an integer array with values 0-9
int[] numArr = new int[10];
for (int i = 0; i < numArr.Length; i++)
{
    numArr[i] = i;
}
//-----------------------------------------//

//Create a string array with the names "Tim", "Martin", "Nikki", and "Sara"
string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};
//-------------------------------------------------------------------------//

//Create a boolean array of length 10, fill with alternating true/false values starting with true
bool[] myBools = new bool[10];
for (int i = 0; i < myBools.Length; i++)
{
    if (i % 2 == 0 || i == 0)
    {
        myBools[i] = true;
    }
    else
    {
        myBools[i] = false;
    }
}
Console.WriteLine(myBools[2]); 
//-----------------------------------------------------------------------------------------//

//LIST OF FLAVORS
//Create a string list of icecream flavors that holds at LEAST 5 flavors
List<string> icecreamFlavors = new List<string> {"vanilla", "chocolate", "butter pecan", "cookies n cream", "rocky road"};
//-------------------------------------------------------------------------------------------------------------------------//

//output the length of the list
Console.WriteLine(icecreamFlavors.Count);
//------------------------------------------//

//output the 3rd flavor in the list
Console.WriteLine(icecreamFlavors[2]);
//-------------------------------------//

//remove the 3rd flavor using its index location
icecreamFlavors.Remove("butter pecan");
//--------------------------------------//

//output the length of the list again, should be one fewer
Console.WriteLine(icecreamFlavors.Count);
//--------------------------------------------------------//

//USER DICTIONARY
//create a dictionary that will store string keys and values
Dictionary<string,string> users = new Dictionary<string,string>();
//-------------------------------------------------------------------//

//Add key/value pairs to the dictionary where:
//each key is a name from my names array 
//each value is randomly selected from my flavors list
//loop through the dictionary and print out each user's name and ice cream
Random rand = new Random();
    for (int i = 0; i < names.Length; i++)
    {
        users.Add(names[i], icecreamFlavors[rand.Next(icecreamFlavors.Count)]);
    }
        foreach (KeyValuePair<string,string> user in users)
    {
        Console.WriteLine($"{user.Key} - {user.Value}");
    }