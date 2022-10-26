bool running = true;
Machine[] machines = new Machine[]
{
    new MaquinaDeBicoInjetor()
};

while (running)
{
    Console.Clear();
    Console.WriteLine($"Seu dinheiro R$ {Factory.Coins}.00");
    Console.WriteLine("Para produzir aperte 0");
    Console.WriteLine("Para abrir o menu de maquinas aperte 1");
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.D0:
            Factory.Click(machines);
            break;
        case ConsoleKey.D1:
            Console.Clear();
            Console.WriteLine("Qual manquina deseja comprar?");
            for (int i = 0; i < machines.Length; i++)
                Console.WriteLine($"{i+1} -- {machines[i]} #{machines[i].Quantity}: R$ {machines[i].Price:N0}.00");
            
            try
            {
                if (machines[int.Parse(Console.ReadLine()) - 1].Buy())
                    Console.WriteLine("Compra concluida");

                else
                    Console.WriteLine("Dinehiro insuficiente");
            }
            catch (System.Exception)
            {
                Console.WriteLine("Compra cancelada");
            }
            Console.WriteLine("\nAperte qualquer botão para continuar");
            Console.ReadKey(true);
            break;
        case ConsoleKey.Escape:
            running = false;
            break;
    }
}
