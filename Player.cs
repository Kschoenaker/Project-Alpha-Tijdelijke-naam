using System.Runtime.InteropServices;

namespace ProjectAlpha;

public class Player
{
    public string Name;
    public Location CurrentLocation;
    public int CurrentHealth;
    public int MaxHealth;
    public Inventory PlayerInventory;

    public List<Quest> CompletedQuest;
    public Quest CurrentQuest;

    public Player(string input_name)
    {
        Name = input_name;
        CurrentLocation = World.LocationByID(1); // Set location to home
        CurrentHealth = 100;
        MaxHealth = 100;
        PlayerInventory = new Inventory(10);
        PlayerInventory.AddItem(new Weapon(1, "Rusty Sword", 5));

    }

    public void TalkToNpc(string npc)
    {
        Console.WriteLine($"[T] Talk to {npc}");

    }
    //  
    public void HandleNpc()
    {
        // check --> OP DE JUISTE LOCATION BENT
        if (!(CurrentLocation.ID == 3 || CurrentLocation.ID == 7 || CurrentLocation.ID == 4))
        {
            return;
        }
        
        // NPC DIALOG --> BASED ON QUEST

        // start quest or dont start quest
        int questId = 0;
        switch (CurrentLocation.ID)
        {
            case 9:
                questId = 3;
                break;
            case 7:
                questId = 2;
                break;
            case 4:
                questId = 1;
                break;
        }

        Quest locationQuest = World.QuestByID(questId);

        Console.WriteLine(locationQuest.Description);

        Console.WriteLine("start quest y/n");

            string StartQuest = Console.ReadLine();
            if (StartQuest == "y")
            {
                CurrentQuest = locationQuest;
                Console.WriteLine("start battle");
                // start a battle of the right location --> current zetten op de goede kwest --> npc diolog
                start_battle();
            }
            else if (StartQuest == "n")
            {
                Console.WriteLine("dont start battle");
            }
    }

    public void InteractionMenu()
    {
        //  als quest location id == 7 --> talk to nps rats quest
        //  als location == 4  --> talk to npc en snakes
        //  als location == 9 --> talk to nps for spiders
        //  als location == 3 --> talk to guard 
        //- comlpteted quest count >=2 can move to next location

        Console.WriteLine($"You are now at {CurrentLocation.Name}");
        Console.WriteLine("You can perform the following actions in this location:");
        Console.WriteLine("[S] Show your current stats");
        Console.WriteLine("[M] Show the map and move to another location");
        Console.WriteLine("[I] Show your inventory");
        if (CurrentLocation.ID == 7)
        {
            TalkToNpc("Carl the farmer");
        }
        else if (CurrentLocation.ID == 4)
        {
            TalkToNpc("Lannie the Alchamist");
        }
        else if (CurrentLocation.ID == 3)
        {
            TalkToNpc("the stoic guard");
        }



        // als je op een bepaalde locatie bent 

        string menu_selection = Console.ReadLine()!.ToLower();

        // CurrentQuest = World.QuestByID(1);
        // start_battle();

        switch (menu_selection)
        {
            case "s":
                Console.WriteLine($"Current health: {CurrentHealth}");
                break;
            // TODO: ADD MORE STUFF TO DISPLAY !!!

            case "m":
                MoveLocation();
                break;

            case "i":
                PlayerInventory.ShowItems();
                break;
            case "t":
                // dont start quest
                HandleNpc();
                break;
            default:
                break;
        }

        // The options are the following:
        // M for Map/Move, which will show the map and challenge the user what location they want to move to (see move location)
        // S for stats, which shows stats like: health, gold, strength.
        // I to show the player inventory.
        // NPC initials to interact/talk with them (related to start a quest).
    }

    bool MoveLocation()
    {
        Console.WriteLine($"Current location: {CurrentLocation.Name}");
        Console.WriteLine("Move options");
        ShowMoveOptions();

        Console.WriteLine();

        //Draw map
        DrawMap();

        Console.WriteLine();
        Console.WriteLine("What direction would you like to go? (N/S/E/W)");
        string direction = Console.ReadLine()!;

        if (!(direction == "N" || direction == "S" || direction == "E" || direction == "W"))
        {
            Console.WriteLine("Input is invalid");
            return false;
        }

        switch (direction)
        {
            case "N":
                if (CurrentLocation.LocationToNorth != null)
                {
                    CurrentLocation = CurrentLocation.LocationToNorth;
                }
                else
                {
                    Console.WriteLine("There is no location here.");
                    return false;
                }
                break;
            case "S":
                if (CurrentLocation.LocationToSouth != null)
                {
                    CurrentLocation = CurrentLocation.LocationToSouth;
                }
                else
                {
                    Console.WriteLine("There is no location here.");
                    return false;
                }
                break;
            case "E":
                if (CurrentLocation.LocationToEast != null)
                {
                    CurrentLocation = CurrentLocation.LocationToEast;
                }
                else
                {
                    Console.WriteLine("There is no location here.");
                    return false;
                }
                break;
            case "W":
                if (CurrentLocation.LocationToWest != null)
                {
                    CurrentLocation = CurrentLocation.LocationToWest;
                }
                else
                {
                    Console.WriteLine("There is no location here.");
                    return false;
                }
                break;
        }

        Console.WriteLine($"Location updated successfully: {CurrentLocation.Name}");
        Console.WriteLine(CurrentLocation.MoveMessage);
        Console.WriteLine();

        InteractionMenu();

        return true;
    }

    void ShowMoveOptions()
    {
        if (CurrentLocation.LocationToNorth != null)
        {
            Console.WriteLine($"North: {CurrentLocation.LocationToNorth.Name}");
        }
        if (CurrentLocation.LocationToSouth != null)
        {
            Console.WriteLine($"South: {CurrentLocation.LocationToSouth.Name}");
        }
        if (CurrentLocation.LocationToEast != null)
        {
            Console.WriteLine($"East: {CurrentLocation.LocationToEast.Name}");
        }
        if (CurrentLocation.LocationToWest != null)
        {
            Console.WriteLine($"West: {CurrentLocation.LocationToWest.Name}");
        }
    }

    void DrawMap()
    {
        Console.WriteLine("          AG");
        Console.WriteLine("          AH");
        Console.WriteLine("FF - FH - TQ - GP - BR - SF");
        Console.WriteLine("          HM");

        Console.WriteLine();

        Console.WriteLine("AG = Alchemist's Garden");
        Console.WriteLine("AH = Alchemist's Hut");
        Console.WriteLine("FF = Farmer's Field");
        Console.WriteLine("FH = Farmhouse");
        Console.WriteLine("TQ = Town Square");
        Console.WriteLine("GP = Guard Post");
        Console.WriteLine("BR = Bridge");
        Console.WriteLine("SF = Spider Field");
        Console.WriteLine("HM = Home");
    }

    public void start_battle()
    {
        int monsterID = 0;
        switch (CurrentQuest.ID)
        {
            case 1:
                monsterID = 2;
                break;
            case 2:
                monsterID = 1;
                break;
            case 3:
                monsterID = 3;
                break;
        }
        List<Monster> monsters = new List<Monster>();
        Monster monsterType = World.MonsterByID(monsterID);

        for (int i = 1; i <= 3; i++)
        {
            Monster tempMonster = new Monster(monsterType.ID, monsterType.Name, monsterType.MaxDamage, monsterType.CurrentHealth, monsterType.MaxHealth);
            monsters.Add(tempMonster);
        }

        Battle NewBattle = new Battle(this, monsters);

        bool battleResult = NewBattle.HandleBattle();
        if (battleResult)
        {
            CompletedQuest.Add(CurrentQuest);
            CurrentQuest = null;
        }
    }
}