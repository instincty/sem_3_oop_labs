using System;

public interface IObjectStatus
{
    void ObjectStatus();
}

public interface IBecomeOlder
{
    void BecomeOlder(int years);
}

public interface IBalance
{
    int Balance { get; set; }
}

public interface IEarnCash
{
    void Earn();
}

public abstract class Person : IObjectStatus, IBecomeOlder, IBalance
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Balance { get; set; }

    public Person(string name = "null", int age = -1)
    {
        Name = name;
        Age = age;
    }

    public void BecomeOlder(int years = 1)
    {
        Age += years;
    }

    public virtual void ObjectStatus()
    {
        Console.WriteLine("Object = Person");
    }
}

public class Employee : Person, IEarnCash
{
    public int Salary { get; set; }

    public Employee(string name = "null", int age = -1, int salary = 0) : base(name, age)
    {
        Salary = salary;
    }

    public override void ObjectStatus()
    {
        Console.WriteLine("Object = Employee");
    }

    public void Earn()
    {
        Console.Write("Balance before = {0}", Balance);
        Balance += 1;
        Console.Write("\nBalance after = {0}\n", Balance);
    }

    public void Earn(int x)
    {
        Console.Write("Balance before = {0}", Balance);
        Balance += x;
        Console.Write("\nBalance after = {0}\n", Balance);
    }
}

public class Worker : Employee
{
    public int LevelOfEducation { get; set; }

    public Worker(string name = "null", int age = -1, int salary = 0, int levelOfEducation = 0) :
        base(name, age, salary)
    {
        LevelOfEducation = levelOfEducation;
    }

    public void LevelEducationUp(int upper = 1)
    {
        LevelOfEducation += upper;
    }

    public override void ObjectStatus()
    {
        Console.WriteLine("Object = Worker");
    }
}

public class Engineer : Worker
{
    public int SkillLevel { get; set; }

    public Engineer(string name = "null", int age = -1, int salary = 0, int levelOfEducation = 0, int skillLevel = 0) :
        base(name, age, salary, levelOfEducation)
    {
        SkillLevel = skillLevel;
    }

    public override void ObjectStatus()
    {
        Console.WriteLine("Object = Engineer");
    }
}

class Program
{
    public delegate void MethodDelegate();

    public static void Main()
    {
        Employee e1 = new Employee();
        e1.ObjectStatus();
        e1.Earn();
        Console.WriteLine("\n");
        e1.Earn(40);

        MethodDelegate del = e1.ObjectStatus;
        del += e1.Earn;
        
        del.Invoke();
    }
}
