//Tartarun
//jogo de corrida de tartarugas com multithreading
//Grupo:
//Gabriel Alexander Pinheiro Bravo
//Felipe Vieira Canalle
//William Luz
//Victor Luiz


using System.Drawing;
using System.Threading;

class Turtle
{
    public string name;
    private float weight;
    private float width;
    private Color color;
    private int speed;
    public int xPosition;
    public bool finished;

    public Turtle(string name, float weight, float width, Color color)
    {
        this.name = name;
        this.weight = weight;
        this.width = width;
        this.color = color;
        this.speed = new Random().Next(1, 6);
    }

    public void Present()
    {
        Console.WriteLine($"Nome: {name}");
        Console.WriteLine($"Peso: {weight}kg");
        Console.WriteLine($"Largura: {width}cm");
        Console.WriteLine($"Cor: {color.Name}");
        Console.WriteLine($"Velocidade: {speed}");
    }

    public void Move(float trackLength)
    {
        this.xPosition += this.speed;
        if (this.xPosition >= trackLength)
        {
            this.finished = true;
        }
    }
}

class Program
{
    static void Race(List<Turtle> turtles, int trackLength)
    {
        // countdown to start
        bool raceFinished = false;

        foreach (Turtle turtle in turtles)
        {
            turtle.xPosition = 0;
            turtle.finished = false;
        }

        Console.WriteLine("1. Rodas anexadas!");
        Thread.Sleep(1000);

        Thread[] threads = new Thread[turtles.Count];
        Console.WriteLine("2. Threads criadas!");
        Thread.Sleep(1000);

        Console.WriteLine("3. Corrida iniciada!");
        Thread.Sleep(1000);

        for (int i = 0; i < turtles.Count; i++)
        {
            int localI = i;
            threads[i] = new Thread(() =>
            {
                Turtle turtle = turtles[localI];
                while (!turtle.finished)
                {
                    turtle.Move(trackLength);
                    Thread.Sleep(100);
                }
            });
            threads[i].Start();
        }

        Turtle winnerTurtle = null;

        while (!raceFinished)
        {
            foreach (Turtle turtle in turtles)
            {
                if (turtle.finished)
                {
                    raceFinished = true;
                    winnerTurtle = turtle;
                }
            }
            Console.Clear();
            DrawTurtles(turtles, trackLength);
            Thread.Sleep(100);
        }

        Console.WriteLine("");

        Console.WriteLine($"A tartaruga {winnerTurtle.name} venceu a corrida!");
        Console.Write("Continuando em 3...");
        Thread.Sleep(1000);
        Console.Write(" 2...");
        Thread.Sleep(1000);
        Console.Write(" 1...");
        Thread.Sleep(1000);

        Console.Clear();
        PresetWinner(winnerTurtle);
        Console.ReadKey();
    }

    static void PresetWinner(Turtle winnerTurtle)
    {
        Console.WriteLine("-=- | Vencedor | -=-");
        Console.WriteLine("");
        Console.WriteLine($"A tartaruga {winnerTurtle.name} venceu a corrida!");
        Console.WriteLine("");
        Console.WriteLine($"Informações da tartaruga {winnerTurtle.name}:");
        Console.WriteLine("");
        winnerTurtle.Present();
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
        Console.ReadKey();
    }

    static void DrawTurtles(List<Turtle> turtles, int trackLength)
    {
        //Console.Clear();
        Console.WriteLine("-=- | Corrida | -=-");
        Console.WriteLine("");
        for (int i = 0; i < turtles.Count; i++)
        {
            Console.Write("|");
            for (int b = 0; b < trackLength; b++)
            {
                if (b == (int)turtles[i].xPosition)
                {
                    Console.Write(turtles[i].name[0]);
                }
                else
                {
                    Console.Write("-");
                }
            }
            Console.WriteLine("|");
        }
    }
    static void PresentTurtles(List<Turtle> turtles)
    {
        foreach (Turtle turtle in turtles)
        {
            Console.WriteLine("-=- | Tartarugas | -=-");
            Console.WriteLine("");
            Console.WriteLine("Tartaruga nº" + (turtles.IndexOf(turtle) + 1));
            Console.WriteLine("");
            turtle.Present();
            Console.WriteLine("");
            if (turtles.IndexOf(turtle) < turtles.Count - 1)
            {
                Console.WriteLine("Pressione qualquer tecla para ver a próxima tartaruga");
                Console.ReadKey();
                Console.Clear();
            }
        }
        
    }

    static void Credits()
    {
        Console.WriteLine("-=- | Tartarun | -=-");

        Console.WriteLine("Tartarun é um jogo de corrida de tartarugas");
        Console.WriteLine("A ideia é utilizar o conceito de multithreading, para atualizar a posição de cada tartaruga simultaneamente");
        Console.WriteLine("");
        Console.WriteLine("Desenvolvido por: Gabriel Alexander Pinheiro Bravo");
        Console.WriteLine("GitHub: http://github.com/xandeco024");
        Console.WriteLine("");
        Console.WriteLine("Grupo da atividade:");
        Console.WriteLine("Gabriel Alexander Pinheiro Bravo");
        Console.WriteLine("Felipe Vieira Canalle");
        Console.WriteLine("William Luz");
        Console.WriteLine("Victor Luiz");
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.WriteLine("");
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
        Console.ReadKey();
    }

    static List<Turtle> CreateTurtles()
    {
        List<Turtle> turtles = new List<Turtle>();

        Console.WriteLine("Você deseja preencher as tartarugas automaticamente e aleatoriamente? (s/n)");
        string answer = Console.ReadLine();
        if (answer == "s")
        {
            string[] nomesTartarugas = {
                    "Leonardo",
                    "Donatello",
                    "Rafael",
                    "Michelangelo",
                    "Splinter",
                    "April",
                    "Casey Jones",
                    "Shredder",
                    "Bebop",
                    "Rocksteady",
                    "Mestre Splinter",
                    "Karai",
                    "Tatsu",
                    "Usagi Yojimbo",
                    "Leatherhead"
                };
            
            for (int i = 0; i < 6; i++)
            {
                string name = nomesTartarugas[new Random().Next(0, nomesTartarugas.Length)];
                float weight = new Random().Next(0, 551);
                float width = new Random().Next(0, 251);
                Color color = Color.FromArgb(new Random().Next(0, 256), new Random().Next(0, 256), new Random().Next(0, 256));
                Turtle turtle = new Turtle(name, weight, width, color);
                turtles.Add(turtle);
            }
        }
        else
        {
            for (int i = 1; i < 6; i++)
            {
                Console.WriteLine($"Tartaruga {i}");
                Console.WriteLine("Nome:");
                string name = Console.ReadLine();
                Console.WriteLine("Peso (min: 0kg | max: 550kg):");
                float weight = float.Parse(Console.ReadLine());
                Console.WriteLine("Largura (min: 0cm | max 250cm):");
                float width = float.Parse(Console.ReadLine());
                Console.WriteLine("Cor (em ingles):");
                Color color = Color.FromName(Console.ReadLine());

                Turtle turtle = new Turtle(name, weight, width, color);
                turtles.Add(turtle);
                Console.Clear();
            }
        }
        return turtles;
    }

    static void Main()
    {
        int trackLength = 100;

        //turtlelist
        bool running = true;

        Console.Clear();

        Console.WriteLine("-=- | Tartarun | -=-");

        Console.WriteLine("Bem-vindo ao Tartarun!");
        Console.WriteLine("Para começar, crie as tartarugas que irão competir na corrida!");
        Console.WriteLine("");

        List<Turtle> turtles = CreateTurtles();
        Console.WriteLine("Tartarugas criadas com sucesso!");
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();

        while(running)
        {
            Console.Clear();
            Console.WriteLine("-=- | MENU | -=-");
            Console.WriteLine("");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine();
            Console.WriteLine("1. Começar corrida");
            Console.WriteLine("2. Apresentar tartarugas");
            Console.WriteLine("3. Recriar tartarugas");
            Console.WriteLine("4. Créditos");
            Console.WriteLine("5. Sair");
            Console.WriteLine("");
            Console.WriteLine("-=-=-=-=-=-=-=-=-"); 

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Clear();
                    Race(turtles, trackLength);
                    break;

                case 2:
                    Console.Clear();
                    PresentTurtles(turtles);
                    break;

                case 3:
                    Console.Clear();
                    turtles = CreateTurtles();
                    break;

                case 4:
                    Console.Clear();
                    Credits();
                    break;

                case 5:
                    Console.Clear();
                    running = false;
                    break;
            }
        }
    }
}