using ProjectAlpha;

class Inventory
{
    List<Weapon> Items = new List<Weapon>();

    public Inventory(int maxSpace = 2)
    {
        int MaxSpace = maxSpace
    }

    public void AddItem(Weapon weapon)
    {
        Items.Add(weapon);
    }

    public void RemoveItem(Weapon item)
    {
        Items.Remove(item);
    }

    public void ShowItems()
    {
        Console.WriteLine("Inventory:");
        foreach (string item in Items)
        {
            Console.WriteLine("- " + item.Name);
        }

