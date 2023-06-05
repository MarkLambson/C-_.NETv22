// 1. Iterate and print values
// Given a List of strings, iterate through the List and print out all the values. 
static void PrintList(List<string> MyList)
{
    foreach(string name in MyList )
    {
        Console.WriteLine(name);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);
//-----------------------------------------------------------------------------------------//
Console.WriteLine("=============================================");

// 2. Print Sum
// Given a List of integers, calculate and print the sum of the values.
static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    IntList.ForEach(num => sum += num);
    Console.WriteLine(sum);
}
List<int> TestIntList = new List<int>() {2, 7, 12, 9, 3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);
//----------------------------------------------------------------------------------//
Console.WriteLine("=============================================");

// 3. Find Max
// Given a List of integers, find and return the largest value in the List.
static int FindMax(List<int> IntList)
{
    int high = IntList[0];
    IntList.ForEach(num => {
        if (num > high)
        {
            high = num;
        }
    });
    return high;
}
List<int> TestIntList2 = new List<int>() { -9, 12, 10, 3, 17, 5 };
// You should get back 17 in this example
Console.WriteLine(FindMax(TestIntList2));
//--------------------------------------------------------------------------//
Console.WriteLine("=============================================");

// 4. Square the Values
// Given a List of integers, return the List with all the values squared.
static List<int> SquareValues(List<int> IntList)
{
    for (int i = 0; i < IntList.Count; i++)
    {
        IntList[i] *= IntList[i];
    }
    IntList.ForEach(num => Console.WriteLine(num));
    return IntList;
}
List<int> TestIntList3 = new List<int>() { 1, 2, 3, 4, 5 };
// You should get back [1,4,9,16,25], think about how you will show that this worked
SquareValues(TestIntList3);
//-------------------------------------------------------------------------------------//
Console.WriteLine("=============================================");

// 5. Replace Negative Numbers with 0
// Given an array of integers, return the array with all values below 0 replaced with 0.
static int[] NonNegatives(int[] IntArray)
{
    for (int i = 0; i < IntArray.Length; i++)
    {
        if(IntArray[i] < 0)
        {
            IntArray[i] = 0;
        }
        Console.WriteLine(IntArray[i]);
    }
    return IntArray;
}
int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
// You should get back [0,2,3,0,5], think about how you will show that this worked
NonNegatives(TestIntArray);
//------------------------------------------------------------------------------------------//
Console.WriteLine("=============================================");

// 6. Print Dictionary
// Given a dictionary, print the contents of the said dictionary.
static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    foreach(KeyValuePair<string,string> entry in MyDictionary)
    {
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
}
Dictionary<string, string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);
//------------------------------------------------------------------------------------//
Console.WriteLine("=============================================");

// 7. Find Key
// Given a search term, return true or false whether the given term is a key in a dictionary.
static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    foreach(var key in MyDictionary.Keys)
    {
        if (key == SearchTerm)
        {
            return true;
        }
    }
    return false;
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));
//------------------------------------------------------------------------------------------//
Console.WriteLine("=============================================");

// 8. Generate a Dictionary
// Given a List of names and a List of integers, 
// create a dictionary where the key is a name from the List of names,
// and the value is a number from the List of numbers. 
// Assume that the two Lists will be of the same length. 
// Don't forget to print your results to make sure it worked.

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string, int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string,int> NumsAndNames = new Dictionary<string, int>();
    for (int i = 0; i < Names.Count; i++)
    {
        NumsAndNames.Add(Names[i], Numbers[i]);
    }
    foreach(KeyValuePair<string,int> entry in NumsAndNames)
    {
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
    return NumsAndNames;
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here
List<string> names = new List<string> {"Julie", "Harold", "James", "Monica"};
List<int> nums = new List<int> {6, 12, 7, 10};
Console.WriteLine(GenerateDictionary(names, nums));
//------------------------------------------------------------------------------------------//
Console.WriteLine("=============================================");