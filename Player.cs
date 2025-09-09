class Player
{
    public Location CurrentLocation;

    public Player()
    {
        CurrentLocation = // Set location to home
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

        // Show move options
        Console.WriteLine("Move options");
        ShowMoveOptions();

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