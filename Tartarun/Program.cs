//Tartarun
//jogo de corrida de tartarugas com multithreading
//Grupo:
//Gabriel Alexander Pinheiro Bravo
//Iori de Souza Leite
//Felipe Vieira Canalle
//William Luz

using System.Drawing;
using System.Threading;
using System.Media;

class Trait
{
    public string name;
    public string description;
    public bool triggered;
    private string triggerMessage;
    private string[] triggerMessageActorNames = new string[2];
    public string TriggerMessage()
    {
        string text = "";
        if (triggerMessageActorNames[1] != null)
        {
            text = (triggerMessage.Replace("$", triggerMessageActorNames[0]).Replace("#", triggerMessageActorNames[1]));
        }
        else
        {
            text = (triggerMessage.Replace("$", triggerMessageActorNames[0]));
        }
        //Thread resetTriggerThread = new Thread(ResetTrigger);
        //resetTriggerThread.Start();
        triggered = false;
        return text;
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
            
            case "fofa":
                description = "Tenta ajudar a tartaruga atrás dela a pegar o ritmo!";
                triggerMessage = "FOFA! A tartaruga $ puxou a tartaruga #";
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

    public void TraitHandler(Turtle turtle, List<Turtle> otherTurtles)
    {
        switch (name)
        {
            case "safada":
                turtle.xPosition += turtle.speed;
                turtle.tiredness += turtle.tirednessPerMove;
                Turtle unluckyTurtle = otherTurtles[new Random().Next(0, otherTurtles.Count)];
                unluckyTurtle.tiredness = 100;
                triggered = true;
                triggerMessageActorNames[0] = turtle.name;
                triggerMessageActorNames[1] = unluckyTurtle.name;
                break;

            case "fofa":
                turtle.xPosition += turtle.speed;
                turtle.tiredness += turtle.tirednessPerMove;
                Turtle luckyTurtle = null;

                foreach (Turtle otherTurtle in otherTurtles)
                {
                    //pega a tartaruga atrás dela
                    if (otherTurtle.xPosition < turtle.xPosition)
                    {
                        if (luckyTurtle == null)
                        {
                            luckyTurtle = otherTurtle;
                        }
                        else if (otherTurtle.xPosition > luckyTurtle.xPosition)
                        {
                            luckyTurtle = otherTurtle;
                        }
                    }
                }

                if (luckyTurtle != null)
                {
                    luckyTurtle.xPosition += turtle.xPosition;
                    triggerMessageActorNames[0] = turtle.name;
                    triggerMessageActorNames[1] = luckyTurtle.name;
                    triggered = true;
                }
                break;

            case "esperta":
                
                if(turtle.xPosition + turtle.speed * 2 <= 100)
                {
                    turtle.xPosition += turtle.speed * 2;
                }
                else
                {
                    turtle.xPosition = 100;
                }

                turtle.tiredness += turtle.tirednessPerMove;
                triggerMessageActorNames[0] = turtle.name;
                triggerMessageActorNames[1] = null;
                triggered = true;
                break;
            
            case "preguiçosa":              
                turtle.tiredness = 100;
                triggerMessageActorNames[0] = turtle.name;
                triggerMessageActorNames[1] = null;
                triggered = true;
                break;
            
            case "determinada":
                turtle.xPosition += turtle.speed;

                if(turtle.tiredness >= 100)
                {
                    turtle.tiredness = 0;
                    triggerMessageActorNames[0] = turtle.name;
                    triggerMessageActorNames[1] = null;
                    triggered = true;
                }
                else
                {
                    turtle.tiredness += turtle.tirednessPerMove;
                }
                break;

            case "distraida":
                
                if (turtle.xPosition - turtle.speed * 3 >=0)            
                {
                    turtle.xPosition -= turtle.speed * 3;
                }

                else
                {
                    turtle.xPosition = 0;
                }

                turtle.tiredness += turtle.tirednessPerMove;
                triggerMessageActorNames[0] = turtle.name;
                triggerMessageActorNames[1] = null;
                triggered = true;
                break;

            default:
                //blabla
                break;
        }
    } 

    public bool Activate()
    {
        if (!triggered)
        {
            switch (name)
            {
                case "safada":
                    return new Random().Next(0, 101) <= 15;

                case "fofa":
                    return new Random().Next(0, 101) <= 15;

                case "esperta":
                    return new Random().Next(0, 101) <= 15;

                case "preguiçosa":
                    return new Random().Next(0, 101) <= 15;

                case "determinada":
                    return new Random().Next(0, 101) <= 15;

                case "distraida":
                    return new Random().Next(0, 101) <= 15;

                default:
                    return false;
            }
        }
        else
        {
            return false;
        }
    }
}

class Turtle
{
    public string name;
    private float weight;
    private float width;
    public ConsoleColor color;
    public int speed;
    private float IMC;
    private int chanceToMove;
    public int xPosition;
    public bool finished;
    public int tiredness;
    public int tirednessPerMove;
    public bool resting;
    public float restingTime = 0;
    public float timeFinished;
    public Trait trait;
    private string[] possibleTraitNames = { "safada", "fofa", "esperta", "preguiçosa", "determinada", "distraida"};

    public Turtle(string name, float weight, float width, ConsoleColor color)
    {
        Random random = new Random();

        this.name = name;
        this.weight = weight;
        this.width = width;
        this.color = color;
        trait = new Trait(possibleTraitNames[random.Next(0, possibleTraitNames.Length)]);
        speed = random.Next(1, 6);
        IMC = this.weight / ((this.width/100) * (this.width/100));
        IMCHandler();
    }

    void IMCHandler()
    {
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
        Console.WriteLine($"Traço: {trait.name.ToUpper()}");
        Console.WriteLine($"    - {trait.description}");
        Console.WriteLine($"Cor: {color.ToString()}");
        Console.WriteLine($"Velocidade: {speed}");
        Console.WriteLine($"IMC: {IMC}");
    }

    public void Move(float trackLength, List<Turtle> otherTurtles)
    {
        bool move = new Random().Next(0, 101) <= chanceToMove;

        if (move)
        {
            if (trait.Activate())
            {
                trait.TraitHandler(this, otherTurtles);
            }
            else
            {
                xPosition += speed;
                tiredness += tirednessPerMove;
            }
        }

        else if (tiredness >= 100)
        {
            resting = true;
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
        restingTime += 1;

        if (trait.name == "determinada" && trait.Activate())
        {
            tiredness = 0;
            resting = false;
            trait.triggered = true;
        }
        else if (tiredness <= 0)
        {
            tiredness = 0;
            resting = false;
        }
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
                        turtle.Move(trackLength, otherTurtles);
                    }

                    Thread.Sleep(2000/speedMultiplier);
                }
            });
            threads[i].Start();
        }

        List<Turtle> winners = new List<Turtle>();
        List<string> log = new List<string>();

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
            AddLog(turtles, log);
            DrawLog(log);
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

    static void AddLog(List<Turtle> turtles, List<string> log)
    {
        foreach (Turtle turtle in turtles)
        {
            if (turtle.trait.triggered)
            {
                log.Add(turtle.trait.TriggerMessage());
            }
        }
    }

    static void DrawLog(List<string> log)
    {
        if(log.Count >= 5)
        {
            log.RemoveAt(0);
        }

        Console.WriteLine("");
        Console.WriteLine("Log da corrida:");
        Console.WriteLine("");
        foreach (string logEntry in log)
        {
            Console.WriteLine(logEntry);
        }
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
    }

    static void DrawStatus(Turtle turtle)
    {
        if (turtle.resting)
        {
            Console.WriteLine($"Descansando...");
        }
        else if(turtle.trait.triggered)
        {
            switch (turtle.trait.name)
            {
                case "safada":
                    Console.WriteLine(" SAFADA!");
                    break;

                case "fofa":
                    Console.WriteLine(" FOFA!");
                    break;

                case "esperta":
                    Console.WriteLine(" SK8");
                    break;

                case "preguiçosa":
                    Console.WriteLine(" COCHILANDO!");
                    break;

                case "determinada":
                    Console.WriteLine(" SUPERANDO");
                    break;

                case "distraida":
                    Console.WriteLine(" CHAPANDO!");
                    break;
            }
        }
        else
        {
            Console.WriteLine("");
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
            Console.ForegroundColor = turtles[i].color;
            Console.Write("|");
            for (int b = 0; b < trackLength; b++)
            {
                if (b == (int)turtles[i].xPosition)
                {
                    //draw turtle first letter with color
                    Console.Write(turtles[i].name[0]);
                }
                else
                {
                    Console.Write("-");
                }
            }
            if (turtles[i].finished)
            {
                Console.Write(turtles[i].name[0]);
            }
            else
            {
                Console.Write("|");
            }
            DrawStatus(turtles[i]);
            Console.ResetColor();
        }
        Console.WriteLine("");
        Console.Write("Cansaço: ");
        foreach (Turtle turtle in turtles)
        {
            Console.ForegroundColor = turtle.color;
            Console.Write(turtle.name + " " + (turtle.tiredness) +"%");
            Console.ResetColor();
            Console.Write(" | ");
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
        Console.WriteLine("Iori de Souza Leite");
        Console.WriteLine("Felipe Vieira Canalle");
        Console.WriteLine("William Luz");
        Console.WriteLine("");
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
        Console.WriteLine("");
        Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-");
        Console.ReadKey();
    }

    static List<Turtle> CreateTurtles(int amount)
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
            List<int> turtleUnavaliableColorIndexes = new List<int>();

            Random randomName = new Random();
            Random randomColor = new Random();

            for (int i = 0; i < amount; i++)
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

                int colorIndex;

                while (true)
                {
                    colorIndex = randomColor.Next(1, 11);

                    if (!turtleUnavaliableColorIndexes.Contains(colorIndex))
                    {
                        turtleUnavaliableColorIndexes.Add(colorIndex);
                        break;
                    }
                }

                ConsoleColor color = ConsoleColor.Black;
                switch(colorIndex)
                {
                    case 1:
                        color = ConsoleColor.Red;
                        break;
                    case 2:
                        color = ConsoleColor.DarkYellow;
                        break;
                    case 3:
                        color = ConsoleColor.Yellow;
                        break;
                    case 4:
                        color = ConsoleColor.Green;
                        break;
                    case 5:
                        color = ConsoleColor.Blue;
                        break;
                    case 6:
                        color = ConsoleColor.DarkBlue;
                        break;
                    case 7:
                        color = ConsoleColor.Magenta;
                        break;
                    case 8:
                        color = ConsoleColor.DarkMagenta;
                        break;
                    case 9:
                        color = ConsoleColor.Gray;
                        break;
                    case 10:
                        color = ConsoleColor.White;
                        break;
                }
                Turtle turtle = new Turtle(name, weight, width, color);
                turtles.Add(turtle);
            }
        }
        else
        {
            for (int i = 1; i < amount + 1; i++)
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
                //Console.WriteLine("1. Vermelho | 2. Laranja | 3. Amarelo | 4. Verde | 5. Azul | 6. Roxo | 7. Preto | 8. Branco");
                Console.WriteLine("1. Vermelho | 2. Amarelo Escuro | 3. Amarleo | 4. Verde | 5. Azul ");
                Console.WriteLine(" 6. Azul Escuro | 7. Magenta | 8. Magenta Escuro | 9. Cinza | 10. Branco" );
                Console.Write("Indice da cor escolhida: ");
                int colorIndex;
                while (!int.TryParse(Console.ReadLine(), out colorIndex) || colorIndex < 1 || colorIndex > 10)
                {
                    Console.Write("Cor inválida! Digite um índice válido: ");
                }
                ConsoleColor color = ConsoleColor.Black;
                switch(colorIndex)
                {
                    case 1:
                        color = ConsoleColor.Red;
                        break;
                    case 2:
                        color = ConsoleColor.DarkYellow;
                        break;
                    case 3:
                        color = ConsoleColor.Yellow;
                        break;
                    case 4:
                        color = ConsoleColor.Green;
                        break;
                    case 5:
                        color = ConsoleColor.Blue;
                        break;
                    case 6:
                        color = ConsoleColor.DarkBlue;
                        break;
                    case 7:
                        color = ConsoleColor.Magenta;
                        break;
                    case 8:
                        color = ConsoleColor.DarkMagenta;
                        break;
                    case 9:
                        color = ConsoleColor.Gray;
                        break;
                    case 10:
                        color = ConsoleColor.White;
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
    
    class BetSystem
    {
        class Bet
        {
            public string betterName;
            public string turtleName;
            public int amount;
            public bool won;
        }
    }

    static void Main()
    {
        int trackLength = 100;  
        bool running = true;

        Console.Clear();
        List<Turtle> turtles = new List<Turtle>();

        while(running)
        {
            Console.Clear();
            Console.WriteLine("-=- | Tartarun - MENU | -=-");
            Console.WriteLine("");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine();
            if (turtles.Count == 0)
            {
                Console.WriteLine("1. Iniciar corrida NAO DA");
            }
            else
            {
                Console.WriteLine("1. Iniciar corrida");
            }
            Console.WriteLine("2. Apresentar tartarugas");
            if (turtles.Count == 0)
            {
                Console.WriteLine("3. Criar tartarugas");
            }
            else
            {
                Console.WriteLine("3. Recriar tartarugas");
            }
            Console.WriteLine("4. Apostar");
            Console.WriteLine("5. Créditos");
            Console.WriteLine("6. Sair");
            Console.WriteLine("");
            Console.WriteLine("-=-=-=-=-=-=-=-=-=-=-=-=-=-"); 
            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 6)
            {
                Console.WriteLine("");
                Console.Write("Opção inválida! Digite um número de 1 a 5: ");
            }

            switch (option)
            {
                case 1:
                    Console.Clear();
                    if (turtles.Count == 0)
                    {
                        Console.WriteLine("Como fazer uma corrida sem corredores?");
                        Console.WriteLine("Crie  as tartarugas antes de iniciar a corrida!");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Digite o multiplicador de velocidade da corrida (1 a 10): ");
                        int speedMultiplier;
                        while (!int.TryParse(Console.ReadLine(), out speedMultiplier) || speedMultiplier < 1 || speedMultiplier > 10)
                        {
                            Console.Write("Multiplicador inválido! Digite um número de 1 a 10: ");
                        }
                        Race(turtles, trackLength, speedMultiplier);
                    }
                    break;

                case 2:
                    Console.Clear();
                    if (turtles.Count == 0)
                    {
                        Console.WriteLine("Que tartarugas?");
                        Console.WriteLine("Crie as tartarugas antes de apresentá-las!");
                        Console.WriteLine("Pressione qualquer tecla para voltar ao menu");
                        Console.ReadKey();
                    }
                    else
                    {
                        PresentTurtles(turtles);
                    }
                    break;

                case 3:
                    Console.Clear();
                    Console.WriteLine("Insira a quantidade de tartarugas que deseja criar (min: 1 | max: 10): ");
                    int turtleAmount;
                    while (!int.TryParse(Console.ReadLine(), out turtleAmount) || turtleAmount < 1 || turtleAmount > 10)
                    {
                        Console.Write("Quantidade inválida! Digite um número de 1 a 10: ");
                    }
                    turtles = CreateTurtles(turtleAmount);
                    break;

                case 4:
                    Console.Clear();
                    Console.WriteLine("Apostar");
                    break;

                case 5:
                    Console.Clear();
                    Credits();
                    break;

                case 6:
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