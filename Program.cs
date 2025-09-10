using ProjectAlpha;

public class Program
{
    public static void Main()
    {
        World TemporaryWorld = new World();

        Console.WriteLine("You wake up to a world on the edge of ruin");
        Console.WriteLine("Whispers of giant spiders invading the land echo through every village and forest path. Crops are withering, people are disappearing, and fear spreads like poison.");
        Console.WriteLine();
        Console.WriteLine("But not all hope is lost.");
        Console.WriteLine();
        Console.WriteLine("You have the freedom to go where you're needed—help struggling townsfolk, complete quests, uncover hidden secrets, and grow stronger with every challenge.");
        Console.WriteLine();
        Console.WriteLine("Every step you take brings you closer to the truth… and to the power you'll need to stop the swarm.");
        Console.WriteLine();
        Console.WriteLine("The spiders are coming.");
        Console.WriteLine("Will you be ready?");
        Console.WriteLine();

        Console.WriteLine("What is the name of this brave warrior?");
        string name = Console.ReadLine()!;
        Console.WriteLine($"{name}? Very well, very well.");

        Player player = new Player(name);

        bool gameRunning = true;
        while (gameRunning)
        {
            player.InteractionMenu();
        }
    }
}