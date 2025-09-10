namespace ProjectAlpha;

public class Monster
{
    public int ID;
    public string Name;
    public int MaxDamage;
    public int CurrentHealth;
    public int MaxHealth;

    public Monster(int id, string name, int maxdamage, int currenthealth, int maxhealth)
    {
        ID = id;
        Name = name;
        MaxDamage = maxdamage;
        CurrentHealth = currenthealth;
        MaxHealth = maxhealth;
    }
};