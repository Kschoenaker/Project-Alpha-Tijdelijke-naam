namespace ProjectAlpha;

public class Weapon
{
    public int ID;
    public string Name;
    public int MaximumDamage;

    public Weapon(int id, string name, int maxdamage) {
        ID = id;
        Name = name;
        MaximumDamage = maxdamage;
    }
};