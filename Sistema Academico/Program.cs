using System;

bool running = true;
while (running)
{
    Console.Clear();
    Console.WriteLine("1 - Cadastrar Curso");
    Console.WriteLine("2 - Listar Cursos");
    Console.WriteLine("3 - Cadastrar Aluno");
    Console.WriteLine("4 - Dar Notas");
    Console.WriteLine("5 - Estatísticas");
    Console.WriteLine("6 - Sair");

    int choice = int.Parse(Console.ReadLine());
    Console.Clear();

    string name;
    int workload, index;

    switch (choice)
    {
        case 1:
            Console.WriteLine("Qual o nome do curso? ");
            name = Console.ReadLine(); 
            
            Console.WriteLine("Qual a carga horaria do curso? ");
            workload = int.Parse(Console.ReadLine()); 
            
            Database.AddCourse(name, workload);
            break;
        
        case 2:
            if (Database.NumberCourses == 0)
            {
                Console.WriteLine("Não há cursos cadastrados!");
                break;
            }
            Database.ShowCourses();
            break;
        
        case 3:
            if (Database.NumberCourses == 0)
            {
                Console.WriteLine("Não há cursos cadastrados!");
                break;
            }

            Console.WriteLine("Qual o nome do aluno? ");
            name = Console.ReadLine(); 
            
            Console.WriteLine("Qual curso o aluno vai fazer: ");
            Database.ShowCourses();
            index = int.Parse(Console.ReadLine()) - 1;

            Database.AddStudent(name, index);
            break;
        
        case 4:
            if (Database.NumberStudents == 0)
            {
                Console.WriteLine("Não há alunos cadastrados!");
                break;
            }

            Console.WriteLine("Para qual curso vai dar nota: ");
            Database.ShowCourses();
            index = int.Parse(Console.ReadLine()) - 1;

            Database.Grade(index);
            break;
        
        case 5:
            if (Database.NumberCourses == 0)
            {
                Console.WriteLine("Não há cursos cadastrados!");
                break;
            }

            if (Database.NumberStudents == 0)
            {
                Console.WriteLine("Não há alunos cadastrados!");
                break;
            }

            Console.WriteLine("De qual curso deseja ver as estatísticas: ");
            Database.ShowCourses();
            index = int.Parse(Console.ReadLine()) - 1;

            Database.Statistics(index);
            break;

        case 6:
            Console.WriteLine("Obrigado por usar nossos serviços!");
            running = false;
            break;
        
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
    Console.ReadKey(true);
}