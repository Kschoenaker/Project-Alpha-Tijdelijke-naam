namespace ProjectAlpha;

class Player
{
    public Location CurrentLocation;
    public int CurrentHealth;

    public Player()
    {
        CurrentLocation = World.LocationByID(1); // Set location to home
        CurrentHealth = 100;
    }

    public void InteractionMenu()
    {
        Console.WriteLine("You can perform the following actions in this location:");
        Console.WriteLine("[S] Show your current stats");
        Console.WriteLine("[M] Show the map and move to another location");
        Console.WriteLine("[I] Show your inventory");

        string menu_selection = Console.ReadLine()!.ToLower();

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
                // TODO: MAKE THE INVENTORY SYSTEM SO IT CAN BE SHOWN
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

        //Draw map
        DrawMap();

        Console.WriteLine();
        Console.WriteLine("What direction would you like to go? (N/S/E/W)");
        string direction = Console.ReadLine();

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
}