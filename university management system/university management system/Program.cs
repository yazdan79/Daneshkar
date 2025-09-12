using System;

public class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public virtual string GetDetails()
    {
        return "Name: " + Name + ", Age: " + Age;
    }
}

public class Student : Person
{
    public string StudentID;
    public string Major;

    public Student(string name, int age, string studentID, string major)
        : base(name, age)     
    {
        StudentID = studentID;
        Major = major;
    }

    public override string GetDetails()
    {
        return "Student - Name: " + Name + ", Age: " + Age +
               ", StudentID: " + StudentID + ", Major: " + Major;
    }
}

public class Professor : Person
{
    public string ProfessorID;
    public string Subject;

    public Professor(string name, int age, string professorID, string subject)
        : base(name, age)
    {
        ProfessorID = professorID;
        Subject = subject;
    }

    public override string GetDetails()
    {
        return "Professor - Name: " + Name + ", Age: " + Age +
               ", ProfessorID: " + ProfessorID + ", Subject: " + Subject;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Person student1 = new Student("Ali", 20, "S123", "Computer Science");
        Person professor1 = new Professor("Dr. Reza", 45, "P456", "Mathematics");

        Console.WriteLine(student1.GetDetails());
        Console.WriteLine(professor1.GetDetails());

        Console.ReadLine(); 
    }
}
