namespace ProjectAlpha;

public class Weapon
{
    int ID;
    string Name;
    int MaximumDamage;

    public Weapon(int id, string name, int maxdamage) {
        ID = id;
        Name = name;
        MaximumDamage = maxdamage;
    }
};