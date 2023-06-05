string someString = "Hello World!";
int someNum = 39;
//someNum = someString; -----> will not work, we declare what this data is, and it can only be that (int, string, etc.) 


// Console.WriteLine(someString);
// Console.WriteLine(someNum);
// Console.WriteLine(someNum);

//void means no data, can be replaced by int, string, etc.
// void PrintDivisibleNumber () 
// {
//  return 12345;
// }

// string PrintDivisibleNumber () 
// {
//     return "12345";
// }
//functions create a new line at the curly brace, different than JS

// Console.WriteLine(PrintDivisibleNumber());

//camel case for variables ---> thisIsCamelCase
//pascal case for everything else ---> ThisIsPascalCase



//FOR FUNDIMENTALS I, II, III
//for loop to print numbers 1 - 255, show whats divisible by 3, show whats divisible by 5
void PrintDivisibleNumber (int num = 100) 
{
    for(int i = 1; i <= num; i++)
    {
        bool isDivisibleBy3 = i % 3 == 0;
        bool isDivisibleBy5 = i % 5 == 0;
        bool isDivisibleBy3And5 = isDivisibleBy3 && isDivisibleBy5;

        if(isDivisibleBy3And5)
        {
            Console.WriteLine("FizzBuzz");
        } 
        else if(isDivisibleBy3) 
        {
            Console.WriteLine("Fizz");
        }
        else if (isDivisibleBy5) 
        {
            Console.WriteLine("Buzz");
        }
        else 
        {
        Console.WriteLine(i);
        }
    }
}

// PrintDivisibleNumber();
// Console.WriteLine("=================================");
// PrintDivisibleNumber(25);
// --------------------------------------------------------------------------------------------------------//


List<string> names = new List<string>()
{
    "Dan", "Ben", "Thien", "Zach", "Mark", "Tillman"
};
names.Add("Maliq");
names.Add("Blake");
names.Add("Mike");
// ^ how to add things to a list, not the best if you're adding a lot, can only add a single argument at a time
names.AddRange(new List<string>{ "David", "Malo"});
//we can also add a list of items to our list with the ADDRANGE function

Console.WriteLine(String.Join(", ", names));
// Console.WriteLine(names); -----> will not show whats in the list, will only just show what the list type is

List<string> FilterLongNames(List<string> allNames, int length = 4)
{
    List<string> output = new List<string>();
    foreach (string name in allNames)
    {
        if(name.Length > length)
        {
            output.Add(name);
        }
    }
    return output;
}

List<string> longNames = FilterLongNames(names, 4);

Console.WriteLine(String.Join(", ", longNames));