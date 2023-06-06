Student studentOne = new Student("Dan", "Wartsbaugh", "C#", 9001);
Person personOne = new Person("Max", "Rauchman");
Person personTwo = new Person()
{
    FirstName = "Mark",
    LastName = "Lambson"
};
Student studentTwo = new Student ("Tillman", "Pugh", "C#", 9002);
Student studentThree = new Student ("Mark", "Lambson", "C#", 9003);

List<Person> personList = new List<Person>()
{
    personOne,
    personTwo,
    studentOne,
};

List<Student> studentList = new List<Student>();
studentList.Add(studentOne);
studentList.Add(studentTwo);
studentList.Add(studentThree);

Lecture myLecture = new Lecture("C# OOP", 2, personOne, studentList);


Console.WriteLine(studentThree.FullName());
Console.WriteLine(studentTwo.FirstName);
Console.WriteLine(studentOne.StudentId);
Console.WriteLine(myLecture.Instructor.FullName());
// Console.WriteLine(myLecture.Roster); <------ASK ABOUT THIS ONE