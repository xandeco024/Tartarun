using System.Drawing;
using System.Threading;

class Turtle
{
    public string name;
    private float weight;
    private float width;
    private Color color;
    private int speed;
    public float xPosition;
    public bool finished;

    public Turtle(string name, float weight, float width, Color color)
    {
        this.name = name;
        this.weight = weight;
        this.width = width;
        this.color = color;
        this.speed = new Random().Next(1, 6);
        this.xPosition = 0;
    }

    public void Present()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"Weight: {weight} kg");
        Console.WriteLine($"Width: {width} cm");
        Console.WriteLine($"Color: {color}");
        Console.WriteLine($"Speed: {speed}");
    }

    public void Move(float trackLength)
    {
        xPosition += speed;
        if (xPosition >= 100)
        {
            finished = true;
        }
    }
}

class Program
{
    static void Race(List<Turtle> turtles, int trackLength)
    {
        // countdown to start

        Console.WriteLine("1. Rodas anexadas!");
        Thread.Sleep(1000);
        Console.WriteLine("2. Nitro ativado!");
        Thread.Sleep(1000);
        Console.WriteLine("3. Largada!");

        bool raceFinished = false;
        
        Thread[] threads = new Thread[turtles.Count];
        for (int i = 0; i < turtles.Count; i++)
        {
            threads[i] = new Thread(() =>
            {
                Turtle turtle = turtles[i];
                trackLength = 100;

                while (!turtle.finished)
                {
                    turtle.Move(trackLength);
                    Thread.Sleep(100);
                }
            });
            threads[i].Start();
        }

        while (!raceFinished)
        {
            raceFinished = true;
            foreach (Turtle turtle in turtles)
            {
                if (!turtle.finished)
                {
                    raceFinished = false;
                    break;
                }
            }
            DrawTurtles(turtles, trackLength);
            Thread.Sleep(100);
        }
    }

    static void DrawTurtles(List<Turtle> turtles, int trackLength)
    {
        Console.Clear();
        for (int i = 0; i < turtles.Count; i++)
        {
            for (int b = 0; i < turtles[i].xPosition; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("T");
            Console.WriteLine("");
        }
    }
    static void PresentTurtles(List<Turtle> turtles)
    {
        foreach (Turtle turtle in turtles)
        {
            turtle.Present();
            Console.WriteLine("");
            if (turtles.IndexOf(turtle) < turtles.Count - 1)
            {
                Console.WriteLine("Press any key to see the next turtle");
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

        Console.WriteLine("Desenvolvido por: Gabriel Alexander Pinheiro Bravo");
        Console.WriteLine("GitHub: http://github.com/xandeco024");

        Console.WriteLine("Grupo da atividade:");
        Console.WriteLine("Gabriel Alexander Pinheiro Bravo");
        Console.WriteLine("Felipe Vieira Canalle");
        Console.WriteLine("William Luz");
        Console.WriteLine("Victor Luiz");

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.ReadKey();
    }

    static List<Turtle> CreateTurtles()
    {
        List<Turtle> turtles = new List<Turtle>();

        Console.Write("Você deseja preencher as tartarugas automaticamente e aleatoriamente? (s/n)");
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

        List<Turtle> turtles = CreateTurtles();

        while(running)
        {
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