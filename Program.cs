using ProjectAlpha;
using System.Threading;

public class Program
{
    public static void Main()
    {
        World TemporaryWorld = new World();

        Console.WriteLine("You wake up to a world on the edge of ruin");
        Thread.Sleep(1000);
        Console.WriteLine("Whispers of giant spiders invading the land echo through every village and forest path. Crops are withering, people are disappearing, and fear spreads like poison.");
        Thread.Sleep(4000);
        Console.WriteLine();
        Console.WriteLine("But not all hope is lost.");
        Thread.Sleep(1000);
        Console.WriteLine();
        Console.WriteLine("You have the freedom to go where you're needed—help struggling townsfolk, complete quests, uncover hidden secrets, and grow stronger with every challenge.");
        Console.WriteLine();
        Thread.Sleep(5000);
        Console.WriteLine("Every step you take brings you closer to the truth… and to the power you'll need to stop the swarm.");
        Thread.Sleep(4000);
        Console.WriteLine();
        Console.WriteLine("The spiders are coming.");
        Console.WriteLine("Will you be ready?");
        Thread.Sleep(1000);
        Console.WriteLine();

        Console.WriteLine("What is the name of this brave warrior?");
        string name = Console.ReadLine()!;
        Console.WriteLine($"{name}? Very well, very well.");

        Player player = new Player(name);

        bool gameRunning = true;
        while (gameRunning)
        {
            player.InteractionMenu();



            
            if (player.CurrentHealth == 0)
            {
                gameRunning = StartGameOver();
            }
            else if (player.CompletedQuest.Count() == 3)
            {
                Console.WriteLine($"YOU HAVE DEFEATED THE MOSNSTERS");
                Console.WriteLine($"and saved the village");
                Console.WriteLine($"you wil now for always me know als HERO {player.Name}");
                Thread.Sleep(30000);
                gameRunning = false;

            }



        }



    }
        public static bool StartGameOver()
    {
        Console.WriteLine("game over");
        Thread.Sleep(2000);
        Console.WriteLine("do you want to start over");

        while (true)
        {
            Console.WriteLine("y/n");
            string startOver = Console.ReadLine();
            if (startOver == "y")
            { return true; }
            else if (startOver == "n")
            { return false; }
            else
            { Console.WriteLine("invalid awnser"); }


        }
    }
}