public class Location
{
    public int ID;
    public string Name;
    public string MoveMessage;
    public dynamic Extra1;
    public dynamic Extra2;

    // Location swap
    public Location LocationToNorth = null;
    public Location LocationToSouth = null;
    public Location LocationToEast = null;
    public Location LocationToWest = null;

    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;

    public Location(int id, string name, string moveMessage, dynamic extra1, dynamic extra2)
    {
        ID = id;
        Name = name;
        MoveMessage = moveMessage;
        Extra1 = extra1;
        Extra2 = extra2;
    }

}