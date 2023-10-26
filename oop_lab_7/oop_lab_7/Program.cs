using System;

public interface obj_stat
{
    void object_status();
}

public interface bec_old
{
    void become_older(int years);
}

public interface balance
{
    int balance { get; set; }
}

public interface earn_cash
{
    void earn();
}

public abstract class Person : obj_stat, bec_old, balance
{
    public string name { get; set; }
    public int age { get; set; }
    public int balance { get; set; }
    public Person(string name = "null", int age = -1)
    {
        this.name = name;
        this.age = age;
    }
    public void become_older(int years = 1)
    {
        age += years;
    }
    public virtual void object_status()
    {
        Console.WriteLine("Object = Person");
    }
}

public class Employee : Person, earn_cash
{
    public int salary { get; set; }
    public Employee(string name = "null", int age = -1, int salary = 0) : base(name, age)
    {
        this.salary = salary;
    }
    public override void object_status()
    {
        Console.WriteLine("Object = Employee");
    }
    public void earn()
    {
        Console.Write("balance before = {0}", balance);
        balance += 1;
        Console.Write("\nbalance after = {0}\n", balance);
    }
    public void earn(int x)
    {
        Console.Write("balance before = {0}", balance);
        balance += x;
        Console.Write("\nbalance after = {0}\n", balance);
    }
}

public class Worker : Employee
{
    public int level_of_education { get; set; }
    public Worker(string name = "null", int age = -1, int salary = 0, int level_of_education = 0) :
        base(name, age, salary)
    {
        this.level_of_education = level_of_education;
    }
    public void lvl_ed_up(int upper = 1)
    {
        level_of_education += upper;
    }
    public override void object_status()
    {
        Console.WriteLine("Object = Worker");
    }
}

public class Engineer : Worker
{
    public int skill_level { get; set; }
    public Engineer(string name = "null", int age = -1, int salary = 0, int level_of_education = 0,
                    int skill_level = 0) :
        base(name, age, salary, level_of_education)
    {
        this.skill_level = skill_level;
    }
    public override void object_status()
    {
        Console.WriteLine("Object = Engineer");
    }
}

class Program
{
    public static void Main()
    {
        Employee e1 = new Employee();
        try
        {
            e1.object_status();
            e1.earn();
            Console.WriteLine("\n");
            e1.earn(40);
            //int y = 0;
            //int x = 5 / y;
            int[] arr = { 1, 2, 3 };
            //Console.WriteLine(arr[5]);
        }
        catch (StackOverflowException ex)
        {
            Console.WriteLine("StackOverflowException: " + ex.Message); // стек переполняется из-за слишком глубокой или бесконечной рекурсии.
        }
        catch (ArrayTypeMismatchException ex)
        {
            Console.WriteLine("ArrayTypeMismatchException: " + ex.Message); // происходит попытка присвоить элементу массива значение неправильного типа.
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("DivideByZeroException: " + ex.Message); // происходит деление на ноль.
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("IndexOutOfRangeException: " + ex.Message); // обращение к элементу массива или коллекции происходит с использованием недопустимого индекса.
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine("InvalidCastException: " + ex.Message); // происходит попытка приведения объекта к неправильному типу.
        }
        catch (OutOfMemoryException ex)
        {
            Console.WriteLine("OutOfMemoryException: " + ex.Message); // системе не хватает памяти для выполнения операции.
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("OverflowException: " + ex.Message); // происходит арифметическое переполнение, например, при переполнении целочисленного типа данных.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message); // не удалось поймать конкретный тип исключения.
        }
    }
}