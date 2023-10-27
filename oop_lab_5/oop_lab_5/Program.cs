using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

class Institute
{
    public string Name { get; set; }
    public List<Group> Groups { get; } = new List<Group>();

    public Institute(string name)
    {
        Name = name;
    }

    public void AddGroup(Group group)
    {
        Groups.Add(group);
    }
}

class Group
{
    public string Name { get; set; }
    public List<Student> Students { get; } = new List<Student>();

    public Group(string name)
    {
        Name = name;
    }

    public void AddStudent(Student student)
    {
        Students.Add(student);
    }
}

class Student
{
    public string Name { get; set; }
    public double Grade { get; set; }

    public Student(string name, double grade)
    {
        Name = name;
        Grade = grade;
    }
}

class Program
{
        static List<Institute> institutes = new List<Institute>();

    static void Main()
    {
        Institute institute = new Institute("ИМИТ");
        institutes.Add(institute);
        Group group = new Group("ПРИ");
        institute.AddGroup(group);
        Student student = new Student("Иван", 4);
        group.AddStudent(student);
        student = new Student("Василий", 3);
        group.AddStudent(student);
        student = new Student("Николай", 4);
        group.AddStudent(student);
        student = new Student("Константин", 5);
        group.AddStudent(student);

        group = new Group("ИВТ");
        institute.AddGroup(group);
        student = new Student("Денис", 4);
        group.AddStudent(student);
        student = new Student("Даниил", 5);
        group.AddStudent(student);
        student = new Student("Александр", 5);
        group.AddStudent(student);
        student = new Student("Андрей", 2);
        group.AddStudent(student);

        group = new Group("ИСТ");
        institute.AddGroup(group);
        student = new Student("Игорь", 5);
        group.AddStudent(student);
        student = new Student("Лев", 3);
        group.AddStudent(student);
        student = new Student("Леонид", 3);
        group.AddStudent(student);
        student = new Student("Павел", 4);
        group.AddStudent(student);

        institute = new Institute("ИЭУ");
        institutes.Add(institute);
        group = new Group("ЭБ");
        institute.AddGroup(group);
        student = new Student("Семен", 5);
        group.AddStudent(student);
        student = new Student("Сергей", 5);
        group.AddStudent(student);
        student = new Student("Руслан", 4);
        group.AddStudent(student);

        institute = new Institute("ИПТ");
        institutes.Add(institute);
        group = new Group("ИБ");
        institute.AddGroup(group);
        student = new Student("Петр", 4);
        group.AddStudent(student);
        student = new Student("Дмитрий", 4);
        group.AddStudent(student);
        student = new Student("Виктор", 4);
        group.AddStudent(student);

        while (true)
        {
            clearConsole();
            Console.WriteLine("Меню программы:");
            Console.WriteLine("1. Добавить институт");
            Console.WriteLine("2. Добавить группу");
            Console.WriteLine("3. Добавить студента");
            Console.WriteLine("4. Редактировать институт");
            Console.WriteLine("5. Редактировать группу");
            Console.WriteLine("6. Редактировать студента");
            Console.WriteLine("7. Удалить институт");
            Console.WriteLine("8. Удалить группу");
            Console.WriteLine("9. Удалить студента");
            Console.WriteLine("10. Вывести данные в файл");
            Console.WriteLine("11. Выйти из программы");
            Console.Write("Выберите действие: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddInstitute();
                    break;
                case 2:
                    AddGroup();
                    break;
                case 3:
                    AddStudent();
                    break;
                case 4:
                    EditInstitute();
                    break;
                case 5:
                    EditGroup();
                    break;
                case 6:
                    EditStudent();
                    break;
                case 7:
                    DeleteInstitute();
                    break;
                case 8:
                    DeleteGroup();
                    break;
                case 9:
                    DeleteStudent();
                    break;
                case 10:
                    SaveDataToFile();
                    break;
                case 11:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }

    static void clearConsole()
    {
        Console.WriteLine("Нажмите enter для продолжения...");
        Console.ReadLine();
        Console.Clear();
    }

    static void AddInstitute()
    {
        Console.Write("Введите название института: ");
        string name = Console.ReadLine();
        Institute institute = new Institute(name);
        institutes.Add(institute);
    }

    static void AddGroup()
    {
        Console.Write("Введите название группы: ");
        string name = Console.ReadLine();
        Console.Write("Введите институт, к которому относится группа: ");
        string instituteName = Console.ReadLine();
        Institute institute = institutes.Find(i => i.Name == instituteName);
        if (institute != null)
        {
            Group group = new Group(name);
            institute.AddGroup(group);
        }
        else
        {
            Console.WriteLine("Институт не найден.");
        }
    }

    static void AddStudent()
    {
        Console.Write("Введите имя студента: ");
        string name = Console.ReadLine();
        Console.Write("Введите группу, к которой относится студент: ");
        string groupName = Console.ReadLine();
        Student student = null;

        foreach (var institute in institutes)
        {
            var group = institute.Groups.Find(g => g.Name == groupName);
            if (group != null)
            {
                double grade;
                Console.Write("Введите оценку студента: ");
                if (double.TryParse(Console.ReadLine(), out grade))
                {
                    student = new Student(name, grade);
                    group.AddStudent(student);
                }
                else
                {
                    Console.WriteLine("Некорректная оценка. Студент не добавлен.");
                }
                return;
            }
        }

        Console.WriteLine("Группа не найдена.");
    }

    static void EditInstitute()
    {
        Console.Write("Введите название института для редактирования: ");
        string instituteName = Console.ReadLine();
        Institute institute = institutes.Find(i => i.Name == instituteName);
        if (institute != null)
        {
            Console.Write("Введите новое название института: ");
            string newName = Console.ReadLine();
            institute.Name = newName;
            Console.WriteLine("Институт отредактирован.");
        }
        else
        {
            Console.WriteLine("Институт не найден.");
        }
    }

    static void EditGroup()
    {
        Console.Write("Введите название группы для редактирования: ");
        string groupName = Console.ReadLine();
        Group group = null;

        foreach (var institute in institutes)
        {
            group = institute.Groups.Find(g => g.Name == groupName);
            if (group != null)
            {
                Console.Write("Введите новое название группы: ");
                string newName = Console.ReadLine();
                group.Name = newName;
                Console.WriteLine("Группа отредактирована.");
                return;
            }
        }

        Console.WriteLine("Группа не найдена.");
    }

    static void EditStudent()
    {
        Console.Write("Введите имя студента для редактирования: ");
        string studentName = Console.ReadLine();
        Student student = null;

        foreach (var institute in institutes)
        {
            foreach (var group in institute.Groups)
            {
                student = group.Students.Find(s => s.Name == studentName);
                if (student != null)
                {
                    Console.Write("Введите новое имя студента: ");
                    string newName = Console.ReadLine();
                    double newGrade;

                    if (double.TryParse(Console.ReadLine(), out newGrade))
                    {
                        student.Name = newName;
                        student.Grade = newGrade;
                        Console.WriteLine("Студент отредактирован.");
                    }
                    else
                    {
                        Console.WriteLine("Некорректная оценка. Студент не отредактирован.");
                    }
                    return;
                }
            }
        }

        Console.WriteLine("Студент не найден.");
    }

    static void DeleteInstitute()
    {
        Console.Write("Введите название института для удаления: ");
        string instituteName = Console.ReadLine();
        Institute institute = institutes.Find(i => i.Name == instituteName);
        if (institute != null)
        {
            institutes.Remove(institute);
            Console.WriteLine("Институт удален.");
        }
        else
        {
            Console.WriteLine("Институт не найден.");
        }
    }

    static void DeleteGroup()
    {
        Console.Write("Введите название группы для удаления: ");
        string groupName = Console.ReadLine();
        Group group = null;

        foreach (var institute in institutes)
        {
            group = institute.Groups.Find(g => g.Name == groupName);
            if (group != null)
            {
                institute.Groups.Remove(group);
                Console.WriteLine("Группа удалена.");
                return;
            }
        }

        Console.WriteLine("Группа не найдена.");
    }

    static void DeleteStudent()
    {
        Console.Write("Введите имя студента для удаления: ");
        string studentName = Console.ReadLine();
        Student student = null;

        foreach (var institute in institutes)
        {
            foreach (var group in institute.Groups)
            {
                student = group.Students.Find(s => s.Name == studentName);
                if (student != null)
                {
                    foreach (var g in institute.Groups)
                    {
                        g.Students.Remove(student);
                    }
                    Console.WriteLine("Студент удален.");
                    return;
                }
            }
        }

        Console.WriteLine("Студент не найден.");
    }
    
    static void SaveDataToFile()
    {
        Console.Write("Введите имя файла для сохранения данных: ");
        string fileName = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            int maxHonorStudents = 0;
            string instituteWithMaxHonorStudents = "";

            foreach (var institute in institutes)
            {
                int honorStudentsCount = 0;

                writer.WriteLine($"Институт: {institute.Name}");

                foreach (var group in institute.Groups)
                {
                    if (group.Students.All(student => student.Grade > 2))
                    {
                        writer.WriteLine($"-Группа: {group.Name}");

                        foreach (var student in group.Students)
                        {
                            writer.WriteLine($"--Студент: {student.Name}, Оценка: {student.Grade}");

                            if (student.Grade >= 5)
                            {
                                honorStudentsCount++;
                            }
                        }
                    }
                }

                if (honorStudentsCount > maxHonorStudents)
                {
                    maxHonorStudents = honorStudentsCount;
                    instituteWithMaxHonorStudents = institute.Name;
                }
            }

            writer.WriteLine($"Институт с наибольшим количеством отличников: {instituteWithMaxHonorStudents}. Количество отличников: {maxHonorStudents}");
        }
        Console.WriteLine($"Данные сохранены в файл {fileName}");
    }
}
