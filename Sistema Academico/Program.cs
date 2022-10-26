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
            while (true)
            {
                try
                {
                    Console.WriteLine("Qual o nome do curso? ");
                    name = Console.ReadLine(); 
                    Console.WriteLine("Qual a carga horária do curso? ");
                    workload = int.Parse(Console.ReadLine());
                    break;
                }
                catch (System.IO.IOException)
                {
                    Console.WriteLine("Carga horária inválida");
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Data);
                }
            }
            
            
            APIRest.CreateCourse(name, workload);
            break;
        
        case 2:
            if (APIRest.NumberCourses == 0)
            {
                Console.WriteLine("Não há cursos cadastrados!");
                break;
            }
            APIRest.ReadCourses();
            break;
        
        case 3:
            if (APIRest.NumberCourses == 0)
            {
                Console.WriteLine("Não há cursos cadastrados!");
                break;
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Qual o nome do aluno? ");
                    name = Console.ReadLine(); 
                    
                    Console.WriteLine("Qual curso o aluno vai fazer: ");
                    APIRest.ReadCourses();
                    index = int.Parse(Console.ReadLine()) - 1;
                    break;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Data);
                }
            }
            

            APIRest.CreateStudent(name, index);
            break;
        
        case 4:
            if (APIRest.NumberStudents == 0)
            {
                Console.WriteLine("Não há alunos cadastrados!");
                break;
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("Para qual curso vai dar nota: ");
                    APIRest.ReadCourses();
                    index = int.Parse(Console.ReadLine()) - 1;
                    break;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Data);
                }
            }
            

            APIRest.Grade(index);
            break;
        
        case 5:
            if (APIRest.NumberCourses == 0)
            {
                Console.WriteLine("Não há cursos cadastrados!");
                break;
            }

            if (APIRest.NumberStudents == 0)
            {
                Console.WriteLine("Não há alunos cadastrados!");
                break;
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("De qual curso deseja ver as estatísticas: ");
                    APIRest.ReadCourses();
                    index = int.Parse(Console.ReadLine()) - 1;
                    break;
                }
                catch (System.Exception e)
                {
                    Console.WriteLine(e.Data);
                }
            }
            
            APIRest.Statistics(index);
            break;

        case 6:
            Console.WriteLine("Obrigado por usar nossos serviços!");
            running = false;
            break;
        
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
    Console.WriteLine("Aperte qualquer tecla para prosseguir");
    Console.ReadKey(true);
}