//create a loop that prints all values 1-255
void PrintAllValues () 
{
    for(int i = 1; i <= 255; i++)
    {
        Console.WriteLine(i);
    }
}
PrintAllValues();
//--------------------------------------------//

//create a loop that generates 5 random numbers between 10 and 20
Random rand = new Random();
for(int i = 1; i <= 5; i++)
{
    Console.WriteLine(rand.Next(10,21));
}
//-------------------------------------------------------------//

//modify loop above to add the 5 integers and print the sum
Random rand2 = new Random();
int random = 0;
int sum = 0;
for(int i = 1; i <= 5; i++)
{
    random = rand2.Next(10,21);
    sum += random;
}
Console.WriteLine("Sum of random numbers:" + sum);
//-----------------------------------------------------------//

//create a loop that prints all values 1-100 that are divisible by 3 or 5 but not both
void PrintDivisibleNumber (int num = 100) 
{
    for(int i = 1; i <= num; i++)
    {
        bool isDivisibleBy3 = i % 3 == 0;
        bool isDivisibleBy5 = i % 5 == 0;
        bool isDivisibleBy3And5 = isDivisibleBy3 && isDivisibleBy5;

        if(isDivisibleBy3And5)
        {
            Console.WriteLine();
        } 
        else if(isDivisibleBy3) 
        {
            Console.WriteLine(i);
        }
        else if (isDivisibleBy5) 
        {
            Console.WriteLine(i);
        }
        else 
        {
        Console.WriteLine();
        }
    }
}
PrintDivisibleNumber();
//-----------------------------------------------------------------------------------//

//modify loop above to print "Fizz" for multiples of 3 and "Buzz" for multiples of 5
void PrintDivisibleNumber2 (int num = 100) 
{
    for(int i = 1; i <= num; i++)
    {
        bool isDivisibleBy3 = i % 3 == 0;
        bool isDivisibleBy5 = i % 5 == 0;
        bool isDivisibleBy3And5 = isDivisibleBy3 && isDivisibleBy5;

        if(isDivisibleBy3And5)
        {
            Console.WriteLine();
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
        Console.WriteLine();
        }
    }
}
PrintDivisibleNumber2();
//----------------------------------------------------------------------------------//

//modify the previous loop to include printing "FizzBuzz" for nums that are multiples of both 3 and 5
void PrintDivisibleNumber3 (int num = 100) 
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
        Console.WriteLine();
        }
    }
}
PrintDivisibleNumber3();
//---------------------------------------------------------------------------------------------------//