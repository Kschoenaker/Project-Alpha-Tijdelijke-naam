using ProjectAlpha;
using System;
using System.Collections.Generic;

class Inventory
{
    private List<Weapon> Items = new List<Weapon>();
    private int MaxSpace;

    public Inventory(int maxSpace = 10)
    {
        MaxSpace = maxSpace;
    }

    public void AddItem(Weapon weapon)
    {
        if (Items.Count < MaxSpace)
        {
            Items.Add(weapon);
        }
        else
        {
            Console.WriteLine("Inventory is full!");
        }
    }

    public void RemoveItem(Weapon item)
    {
        Items.Remove(item);
    }

    public void ShowItems()
    {
        Console.WriteLine("Inventory:");
        foreach (Weapon item in Items)
        {
            Console.WriteLine("- " + item.Name);
        }
    }
}