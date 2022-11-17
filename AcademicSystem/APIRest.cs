using System;
using System.Collections.Generic;

public static class APIRest
{
    private static List<Student> Students { get; set; } = new List<Student>();
    private static List<Course> Courses { get; set; } = new List<Course>();
    public static int NumberCourses { get; private set; } = 0;
    public static int NumberStudents { get; private set; } = 0;
    public static void CreateCourse(string name, int workload)
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
            foreach (var item in APIRest.Courses)
                if (item.Code == code)
                    isValid = false;
            if (isValid)
                break;
        }
        
        APIRest.Courses.Add(new Course(name, code, workload));
        APIRest.NumberCourses++;
    }
    public static void CreateStudent(string name, int index)
    {
        if (name == "")
            throw new Exception("Nome inválido");
        
        int courseCode = APIRest.Courses[index].Code;
        
        Random r = new Random();
        int registration = 0;
        while (true)
        {
            bool isValid = true;
            registration = r.Next(999);
            foreach (var item in APIRest.Students)
                if (item.Registration == registration)
                    isValid = false;
            if (isValid)
                break;
        }

        APIRest.Students.Add(new Student(name, registration, courseCode));
        APIRest.NumberStudents++;
    }
    public static void ReadCourses()
    {
        for (int i = 0; i < APIRest.Courses.Count; i++)
            Console.WriteLine($"{i+1} -- {APIRest.Courses[i].Name}");
    }
    public static void Grade(int index)
    {
        int courseCode = APIRest.Courses[index].Code;
        for (int i = 0; i < APIRest.Students.Count; i++)
        {
            Console.WriteLine($"Qual a nota do aluno {APIRest.Students[i].Name} - {APIRest.Students[i].Registration}");
            APIRest.Students[i].Grade = float.Parse(Console.ReadLine());
        }
    }
    public static void Statistics(int index)
    {
        int courseCode = APIRest.Courses[index].Code;
        int approved = 0, count = 0;
        float total = 0;
        
        for (int i = 0; i < APIRest.Students.Count; i++)
        {
            if (APIRest.Students[i].Grade >= 7)
                approved++;
            total += APIRest.Students[i].Grade;
            count++;
        }

        Console.WriteLine($"Aprovados {approved}");
        Console.WriteLine($"Reprovados {count - approved}");
        Console.WriteLine($"Média {total / count}");
    }
}