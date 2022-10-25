using System;
using System.Collections.Generic;

public static class Database
{
    private static List<Student> Students { get; set; } = new List<Student>();
    private static List<Course> Courses { get; set; } = new List<Course>();
    public static int NumberCourses { get; private set; } = 0;
    public static int NumberStudents { get; private set; } = 0;
    public static void AddCourse(string name, int workload)
    {
        if (name == "")
            throw new Exception("Nome inválido");
        
        if (workload < 1)
            throw new Exception("Carga horária inválida");
        
        Random r = new Random();
        int code = 0;
        while (true)
        {
            bool isValid = true;
            code = r.Next(999);
            foreach (var item in Database.Courses)
                if (item.Code == code)
                    isValid = false;
            if (isValid)
                break;
        }
        
        Database.Courses.Add(new Course(name, code, workload));
        Database.NumberCourses++;
    }
    public static void AddStudent(string name, int index)
    {
        if (name == "")
            throw new Exception("Nome inválido");
        
        int courseCode = Database.Courses[index].Code;
        
        Random r = new Random();
        int registration = 0;
        while (true)
        {
            bool isValid = true;
            registration = r.Next(999);
            foreach (var item in Database.Students)
                if (item.Registration == registration)
                    isValid = false;
            if (isValid)
                break;
        }

        Database.Students.Add(new Student(name, registration, courseCode));
        Database.NumberStudents++;
    }
    public static void ShowCourses()
    {
        for (int i = 0; i < Database.Courses.Count; i++)
            Console.WriteLine($"{i+1} -- {Database.Courses[i].Name}");
    }
    public static void Grade(int index)
    {
        int courseCode = Database.Courses[index].Code;
        for (int i = 0; i < Database.Students.Count; i++)
        {
            Console.WriteLine($"Qual a nota do aluno {Database.Students[i].Name} - {Database.Students[i].Registration}");
            Database.Students[i].Grade = float.Parse(Console.ReadLine());
        }
    }
    public static void Statistics(int index)
    {
        int courseCode = Database.Courses[index].Code;
        int approved = 0, count = 0;
        float total = 0;
        
        for (int i = 0; i < Database.Students.Count; i++)
        {
            if (Database.Students[i].Grade >= 7)
                approved++;
            total += Database.Students[i].Grade;
            count++;
        }

        Console.WriteLine($"Aprovados {approved}");
        Console.WriteLine($"Reprovados {count - approved}");
        Console.WriteLine($"Média {total / count}");
    }
}