public class Student : Person 
//child class inherits : parent class (in this case FirstName, LastName)
{
    public string CurrentStack {get; set;}
    public int StudentId {get; set;}

    public Student (string firstName, string lastName, string currentStack, int studentId) : base(firstName, lastName)
    //base is used to call parent classes constructor, applies it to child witout hard coding it
    {
        CurrentStack = currentStack;
        StudentId = studentId;
    }
}