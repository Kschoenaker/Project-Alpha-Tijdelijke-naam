using ProjectAlpha;

public class Battle
{
    public Player PlayerReference;
    public List<Monster> MonsterList;
    public int Stamina;

    private bool battleStarted = true;
    private int turnsDefend = 0;
    private Random rand = new Random();

    public Battle(Player playerReference)
    {
        PlayerReference = playerReference;
        Stamina = 100;
    }

    public void StartBattle()
    {
        Console.WriteLine("A dangerous opponent lies ahead");
        Console.WriteLine("You ready you're weapon");

        while (battleStarted)
        {
            PrintPlayerStats();

            string playerChoice = BattleOptionMenu().ToUpper();
            switch (playerChoice)
            {
                case "A":
                    HandlePlayerAttack();
                    break;
                case "D":
                    Console.WriteLine("You defend. You're stance firms");
                    Console.WriteLine("For the next 3 turns you take half damage");

                    Stamina += 25;
                    if (Stamina >= 100) { Stamina = 100; }
                    turnsDefend = 3;
                    break;
                case "F":
                    Console.WriteLine("You attempt to flee.");
                    if (((double)PlayerReference.CurrentHealth / (double)PlayerReference.MaxHealth) >= rand.NextDouble())
                    {
                        Console.WriteLine("You fled successfully");
                        battleStarted = false;
                    }
                    else
                    {
                        Console.WriteLine("Your attempt to flee was unsuccessful");
                    }
                    break;
                default:
                    Console.WriteLine("You stand confused, you may have tried to do something you can't");
                    Console.WriteLine("This mistake cost you a turn.");
                    break;
            }

            // Enemy attack
            if (battleStarted)
            {
                foreach (Monster attackingEnemy in MonsterList)
                {
                    Console.WriteLine($"{attackingEnemy.Name} tries attacking");
                }
            }
        }
    }

    public string BattleOptionMenu()
    {
        Console.WriteLine("Make your move:");
        Console.WriteLine("[A] Attack");
        Console.WriteLine("[D] Defend");
        Console.WriteLine("[F] Flee");

        return Console.ReadLine();
    }

    public string AttackTypeMenu()
    {
        Console.WriteLine("What size attack:");
        Console.WriteLine("[A] Big attack (Stamina cost: 45)");
        Console.WriteLine("[S] Medium attack (Stamina cost: 25)");
        Console.WriteLine("[D] Small attack (Stamina cost: 10)");

        return Console.ReadLine();
    }

    public void HandlePlayerAttack()
    {
        string type = AttackTypeMenu();
        int staminaRequired = 0;
        double attackMultiplier = 1.0;

        switch (type)
        {
            case "A":
                staminaRequired = 45;
                attackMultiplier = 1.7;
                break;
            case "S":
                staminaRequired = 20;
                attackMultiplier = 1.0;
                break;
            case "D":
                staminaRequired = 10;
                attackMultiplier = 0.6;
                break;
            default:
                Console.WriteLine("You raise you're weapon, but suddenly stop. You don't know what to do.");
                Console.WriteLine("You lose you're turn");
                return;
        }

        if (Stamina > staminaRequired)
        {
            Stamina -= staminaRequired;
            Monster choosenMonster = ChooseMonster();

            if (choosenMonster is not null)
            {
                choosenMonster.Health -= (double)PlayerReference.CurrentWeapon.Damage * attackMultiplier;
                return;
            }
            else
            {
                Console.WriteLine("You strike the air with full force.");
                Console.WriteLine("The monsters look confused");
                return;
            }
        }
        else
        {
            Console.WriteLine("You stumble, you're body is too tired to this attack");
            Stamina = 0;
            return;
        }
    }

    public Monster ChooseMonster()
    {
        Console.WriteLine("What monster will you attack");
        for (int i = 0; i < MonsterList.Count; i++)
        {
            Console.WriteLine($"[{i}] {MonsterList[i].Name} - {MonsterList[i].CurrentHealth}/{MonsterList[i].MaxHealth}");
        }

        int choice = int.Parse(Console.ReadLine());

        try
        {
            return MonsterList[choice];
        }
        catch
        {
            return null;
        }
    }

    public void PrintPlayerStats()
    {
        Console.WriteLine($"Health: {PlayerReference.CurrentHealth} | Stamina: {Stamina}");
    }
}