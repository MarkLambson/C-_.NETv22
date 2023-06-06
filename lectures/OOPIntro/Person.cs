public class Person 
{
//auto implemented properties, fields have no get set.
    public string FirstName {get; set;}
    public string LastName {get; set;}

//constructor function no params
//can be the same name as a function with params, you just need different
//arguments in each function, another ex:
//public Person(string nickName, int age)
    public Person() { }

//constructor function with params, wont need to return, its implied that its
//going to return the new class instance
//constructors are named after the class itself
    public Person(string firstName, string lastName) 
    { 
        FirstName = firstName;
        LastName = lastName;
    }

//methods 
    public string FullName()
    {
        return $"{FirstName} {LastName}";
    } 
}