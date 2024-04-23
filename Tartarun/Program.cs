//Tartarun
//jogo de corrida de tartarugas com multithreading
//Grupo:
//Gabriel Alexander Pinheiro Bravo
//Felipe Vieira Canalle
//William Luz
//Victor Luiz

using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;

class Trait
{
    public string name;
    public string description;
    public bool logged;
    public bool triggered;
    private string triggerMessage;
    public string TriggerMessage(Turtle turtle1, Turtle turtle2 = null)
    {
        string text = "";
        if (turtle2 != null)
        {
            text = (triggerMessage.Replace("$", turtle1.name).Replace("#", turtle2.name));
        }
        else
        {
            text = (triggerMessage.Replace("$", turtle1.name));
        }
        Thread thread = new Thread(ResetTrigger);
        return text;
    }

    void ResetTrigger()
    {    
        Thread.Sleep(100);
        this.triggered = false;
    }

    public Trait(string name)
    {
        this.name = name;
        switch (name)
        {
            case "safada":
                description = "Gosta de jogar sujo, ocasionalmente sabota uma tartaruga adversária.";
                triggerMessage = "SAFADA! A tartaruga $ sabotou a tartaruga #";
                break;

            case "esperta":
                description = "Ocasionalmente utiliza skates para se aumentar a eficiencia de seu movimento.";
                triggerMessage = "ESPERTA! A tartaruga $ utilizou um skate para se mover mais rápido!";
                break;

            case "preguiçosa":
                description = "Ocasionalmente se auto-declara cansada. mesmo que não esteja.";
                triggerMessage = "PREGUIÇOSA! A tartaruga $ se declarou cansada e parou de se mover!";
                break;

            case "determinada":
                description = "Ocasionalmente se recusa a descansar, e recupera parte de sua vitalidade como mágica";
                triggerMessage = "DETERMINADA! A tartaruga $ se recusou a descansar e recuperou parte de sua vitalidade!";
                break;

            case "distraida":
                description = "Ocasionalmente se move na direção oposta, ela nem sabe o que está fazendo...";
                triggerMessage = "DISTRAÍDA! A tartaruga $ chapou!";
                break;
        
        }
    }

    public bool Activate()
    {
        switch (name)
        {
            case "safada":
                return new Random().Next(0, 101) <= 10;

            case "esperta":
                return new Random().Next(0, 101) <= 10;

            case "preguiçosa":
                return new Random().Next(0, 101) <= 10;

            case "determinada":
                return new Random().Next(0, 101) <= 10;

            case "distraida":
                return new Random().Next(0, 101) <= 25;

            default:
                return false;
        }
    }
}

class Turtle
{
    public string name;
    private float weight;
    private float width;
    private Color color;
    private int speed;
    private float IMC;
    private int chanceToMove;
    public int xPosition;
    public bool finished;
    public int tiredness;
    private int tirednessPerMove;
    public bool resting;
    public float restingTime = 0;
    public float timeFinished;
    public Trait turtleTrait;
    private string[] traits = { "safada", "esperta", "preguiçosa", "determinada", "distraida"};

    public Turtle(string name, float weight, float width, Color color)
    {
        Random random = new Random();

        this.name = name;
        this.weight = weight;
        this.width = width;
        this.color = color;
        turtleTrait = new Trait(traits[random.Next(0, traits.Length)]);
        speed = random.Next(1, 6);
        IMC = this.weight / ((this.width/100) * (this.width/100));

        if (IMC < 50)
        {
            chanceToMove = 25;
            tirednessPerMove = 15;

        }
        else if (IMC < 100)
        {
            chanceToMove = 50;
            tirednessPerMove = 10;
        }
        else if (IMC < 125)
        {
            chanceToMove = 100;
            tirednessPerMove = 5;
        }
        else if (IMC < 200)
        {
            chanceToMove = 50;
            tirednessPerMove = 10;
        }
        else
        {
            chanceToMove = 25;
            tirednessPerMove = 15;
        }
    }

    public void Present()
    {
        Console.WriteLine($"Nome: {name}");
        Console.WriteLine($"Peso: {weight}kg");
        Console.WriteLine($"Largura: {width}cm");
        Console.WriteLine($"Traço: {turtleTrait.name.ToUpper()}");
        Console.WriteLine($"    - {turtleTrait.description}");
        Console.WriteLine($"Cor: {color.Name}");
        Console.WriteLine($"Velocidade: {speed}");
        Console.WriteLine($"IMC: {IMC}");
    }

    public void Move(float trackLength)
    {
        bool move = false;
        move = new Random().Next(0, 101) <= chanceToMove;

        if (move)
        {
            switch (turtleTrait.name)
            {
                case "safada":
                    xPosition += speed;
                    tiredness += tirednessPerMove;
                    //turtleTrait.triggered = true;
                    break;

                case "esperta":
                    if (turtleTrait.Activate())
                    {
                        xPosition += speed * 2;
                        turtleTrait.triggered = true;
                    }
                    else
                    {
                        xPosition += speed;
                    }

                    tiredness += tirednessPerMove;
                    break;
                    
                case "preguiçosa":
                    if (turtleTrait.Activate())
                    {
                        xPosition += speed;
                        tiredness = 100;
                        turtleTrait.triggered = true;
                    }
                    else
                    {
                        xPosition += speed;
                        tiredness += tirednessPerMove;
                    }
                    break;

                case "distracted":
                    if (turtleTrait.Activate())
                    {
                        turtleTrait.triggered = true;
                        xPosition -= speed * 2;
                    }
                    else
                    {
                        xPosition += speed;
                    }
                    tiredness += tirednessPerMove;
                    break;

                default:
                    xPosition += speed;
                    break;
            }

            if (tiredness >= 100)
            {
                tiredness = 100;
                resting = true;
            }
        }

        if (xPosition >= trackLength)
        {
            finished = true;
            timeFinished = DateTime.Now.Second;
        }
    }

    public void Rest()
    {
        tiredness -= 10;
        if (turtleTrait.name == "determinada" && turtleTrait.Activate())
        {
            tiredness = 0;
            turtleTrait.triggered = true;
        }
        else if (tiredness <= 0)
        {
            tiredness = 0;
            resting = false;
        }
        restingTime += 1;
    }

    public void Reset()
    {
        xPosition = 0;
        tiredness = 0;
        resting = false;
        restingTime = 0;
        finished = false;
    }
}

class Program
{
    static void Race(List<Turtle> turtles, int trackLength, int speedMultiplier)
    {
        // countdown to start
        bool raceFinished = false;

        foreach (Turtle turtle in turtles)
        {
            turtle.Reset();
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
                List<Turtle> otherTurtles = new List<Turtle>();

                foreach (Turtle otherTurtle in turtles)
                {
                    if (otherTurtle != turtle)
                    {
                        otherTurtles.Add(otherTurtle);
                    }
                }

                while (!turtle.finished)
                {
                    if (turtle.resting)
                    {
                        turtle.Rest();
                    }
                    else
                    {
                        turtle.Move(trackLength);
                    }

                    Thread.Sleep(2000/speedMultiplier);
                }
            });
            threads[i].Start();
        }

        List<Turtle> winners = new List<Turtle>();

        while (!raceFinished)
        {
            float time = DateTime.Now.Second;
            foreach (Turtle turtle in turtles)
            {
                if (turtle.finished && winners.Count == 0)
                {
                    winners.Add(turtle);
                }
                else if (turtle.finished && turtle.timeFinished == time)
                {
                    winners.Add(turtle);
                }
            }

            if (winners.Count != 0)
            {
                raceFinished = true;
            }

            Console.Clear();
            DrawTurtles(turtles, trackLength);
            DrawLog(turtles);
            Thread.Sleep(200);
        }

        Turtle winnerTurtle = null;

        foreach (Turtle turtle in winners)
        {
          if (winnerTurtle == null)
          {
            winnerTurtle = turtle;
          }
          else if (turtle.restingTime < winnerTurtle.restingTime)
          {
            winnerTurtle = turtle;
          }
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
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=- | Vencedor | -=-=-=-=-=-=-=-=-=-=-");
        Console.WriteLine("");
        Console.WriteLine($"A tartaruga {winnerTurtle.name} venceu a corrida!");
        Console.WriteLine("");
        Console.WriteLine($"Informações da tartaruga {winnerTurtle.name}:");
        Console.WriteLine("");
        winnerTurtle.Present();
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
        Console.ReadKey();
    }

    static void DrawLog(List<Turtle> turtles)
    {
        Console.WriteLine("");
        Console.WriteLine("Log da corrida:");
        Console.WriteLine("");
        foreach (Turtle turtle in turtles)
        {
            if (turtle.turtleTrait.triggered)
            {
                Console.WriteLine(turtle.turtleTrait.TriggerMessage(turtle));
            }
        }
    }

    static void DrawTurtles(List<Turtle> turtles, int trackLength)
    {
        //Console.Clear();
        //definir tamanho do console para 130 colunas
        //verifica se está rodando no windows
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= | Corrida INTENSA | =-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
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
            if (turtles[i].finished)
            {
                Console.WriteLine(turtles[i].name[0]);
            }
            else
            {
                Console.WriteLine("|");
            }
        }
        Console.WriteLine("");
        Console.Write("Cansaço: ");
        foreach (Turtle turtle in turtles)
        {
            Console.Write(turtle.name + " " + (turtle.tiredness) +"% | ");
        }
        Console.WriteLine("");
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

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
            else
            {
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
                Console.ReadKey();
            }
        }
        
    }

    static void Credits()
    {
        Console.WriteLine("-=- | Tartarun | -=-");

        Console.WriteLine("Tartarun é um jogo de corrida de tartarugas");
        Console.WriteLine("A ideia é utilizar o conceito de multithreading, para atualizar a posição de cada tartaruga simultaneamente");
        Console.WriteLine("");
        Console.WriteLine("Desenvolvido por: ");
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

        Console.Write("Você deseja preencher as tartarugas automaticamente e aleatoriamente? (s/n): ");
        string answer = Console.ReadLine();

        while (answer != "s" && answer != "n")
        {
            Console.Write("Resposta inválida! Digite 's' para sim e 'n' para não: ");
            answer = Console.ReadLine();
        }

        if (answer == "s")
        {
            string[] turtleNames = {
                    "Leonardo",
                    "Donatello",
                    "Rafael",
                    "Michelangelo",
                    "Joaquim",
                    "Kiara",
                    "Ta-lenta",
                    "Ta-rapida",
                    "Tortuguita",
                    "Bebop",
                    "Victor",
                    "Canalle",
                    "Luiz",
                    "William",
                    "Roberto",
                    "Antônio",
                    "Carlos",
                    "Jobim",
                    "Lucy"
                };

            List<string> turtleUnavaliableNames = new List<string>();
            
            Random randomName = new Random();

            for (int i = 0; i < 5; i++)
            {
                string name = "";
                while (true)
                {
                    name = turtleNames[randomName.Next(0, turtleNames.Length)];
                    if (!turtleUnavaliableNames.Contains(name))
                    {
                        turtleUnavaliableNames.Add(name);
                        break;
                    }
                }

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
                Console.WriteLine("-=- | Tartarun - Criação de Tartaruags | -=-");
                Console.WriteLine("");
                Console.WriteLine($"Tartaruga {i}");
                Console.WriteLine("");
                Console.Write("Nome: ");
                string name = Console.ReadLine();
                while (name == "")
                {
                    Console.Write("Nome inválido! Digite um nome: ");
                    name = Console.ReadLine();
                }
                Console.Write("Peso (min: 0kg | max: 550kg): ");
                float weight;
                while (!float.TryParse(Console.ReadLine(), out weight) || weight < 0 || weight > 550)
                {
                    Console.Write("Peso inválido! Digite um peso válido: ");
                }
                Console.Write("Largura (min: 0cm | max 250cm): ");
                float width;
                while (!float.TryParse(Console.ReadLine(), out width) || width < 0 || width > 250)
                {
                    Console.Write("Largura inválida! Digite uma largura válida: ");
                }
                Console.WriteLine("Escolha uma cor da lista de cores");
                Console.WriteLine("1. Vermelho | 2. Laranja | 3. Amarelo | 4. Verde | 5. Azul | 6. Roxo | 7. Preto | 8. Branco");
                Console.Write("Indice da cor escolhida: ");
                int colorIndex;
                while (!int.TryParse(Console.ReadLine(), out colorIndex) || colorIndex < 1 || colorIndex > 8)
                {
                    Console.Write("Cor inválida! Digite um índice válido: ");
                }
                Color color;
                switch (colorIndex)
                {
                    case 1:
                        color = Color.Red;
                        break;
                    case 2:
                        color = Color.Orange;
                        break;
                    case 3:
                        color = Color.Yellow;
                        break;
                    case 4:
                        color = Color.Green;
                        break;
                    case 5:
                        color = Color.Blue;
                        break;
                    case 6:
                        color = Color.Purple;
                        break;
                    case 7:
                        color = Color.Black;
                        break;
                    case 8:
                        color = Color.White;
                        break;
                    default:
                        color = Color.Black;
                        break;
                }

                Console.WriteLine("");
                Console.WriteLine("Tartaruga criada com sucesso!");
                Console.WriteLine("");
                Console.WriteLine("Pressione qualquer tecla para criar a próxima tartaruga");
                Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
                Console.ReadKey();
        
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

        if (System.Environment.OSVersion.Platform == PlatformID.Win32NT)
        {
            //Console.SetWindowSize(101, 0);
        }

        Console.WriteLine("-=- | Tartarun | -=-");

        Console.WriteLine(DateTime.Now.Second);

        Console.WriteLine("Bem-vindo ao Tartarun!");
        Console.WriteLine("Para começar, crie as tartarugas que irão competir na corrida!");
        Console.WriteLine("");

        List<Turtle> turtles = CreateTurtles();
        Console.WriteLine("Tartarugas criadas com sucesso!");
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para ser direcionado ao menu");
        Console.ReadKey();

        while(running)
        {
            Console.Clear();
            Console.WriteLine("-=- | Tartarun - MENU | -=-");
            Console.WriteLine("");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine();
            Console.WriteLine("1. Começar corrida");
            Console.WriteLine("2. Apresentar tartarugas");
            Console.WriteLine("3. Recriar tartarugas");
            Console.WriteLine("4. Créditos");
            Console.WriteLine("5. Sair");
            Console.WriteLine("");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-"); 

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 5)
            {
                Console.WriteLine("");
                Console.Write("Opção inválida! Digite um número de 1 a 5: ");
            }

            switch (option)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Digite o multiplicador de velocidade da corrida (1 a 10): ");
                    int speedMultiplier;
                    while (!int.TryParse(Console.ReadLine(), out speedMultiplier) || speedMultiplier < 1 || speedMultiplier > 10)
                    {
                        Console.Write("Multiplicador inválido! Digite um número de 1 a 10: ");
                    }
                    Race(turtles, trackLength, speedMultiplier);
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
                    Console.WriteLine("Obrigado por jogar Tartarun!");
                    Console.WriteLine("Até breve! (espero)");
                    Console.Write("Saindo em 3...");
                    Thread.Sleep(100);
                    Console.Write(" 2...");
                    Thread.Sleep(100);
                    Console.Write(" 1...");
                    Thread.Sleep(100);
                    running = false;
                    break;
            }
        }
    }
}