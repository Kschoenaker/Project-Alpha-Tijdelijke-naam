using ProjectAlpha;

public class Battle
{
    public Player PlayerReference;
    public List<Monster> MonsterList;
    public int Stamina;

    private Weapon CurrentWeapon;
    private bool battleStarted = true;
    private int turnsDefend = 0;
    private Random rand = new Random();

    public Battle(Player playerReference, List<Monster> monsters)
    {
        PlayerReference = playerReference;
        MonsterList = monsters;
        Stamina = 100;
    }

    public bool HandleBattle()
    {
        Console.WriteLine("A dangerous opponent lies ahead!");
        Console.WriteLine("Select your weapon.");

        int index = 0;
        foreach (Weapon weapon in PlayerReference.PlayerInventory.Items)
        {
            Console.WriteLine($"[{index}] {weapon.Name}");
            index++;
        }
        int select = Convert.ToInt32(Console.ReadLine());
        CurrentWeapon = PlayerReference.PlayerInventory.Items[select];

        Console.WriteLine();
        Console.WriteLine("You ready your weapon.");
        Console.WriteLine();

        while (battleStarted)
        {
            PrintPlayerStats();

            string playerChoice = BattleOptionMenu().ToUpper();
            Console.WriteLine();
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

            // Check if enemies are dead
            if (MonsterList.Count <= 0)
            {
                Console.WriteLine("You win the battle.");
                return true;
            }

            // Enemy attack
            if (battleStarted)
            {
                foreach (Monster attackingEnemy in MonsterList)
                {
                    Console.WriteLine($"{attackingEnemy.Name} tries attacking");
                    if (0.4 > rand.NextDouble())
                    {
                        int damage = 0;
                        if (turnsDefend > 0)
                        {
                            damage = Convert.ToInt32((double)attackingEnemy.MaxDamage / 2);
                            Console.WriteLine($"{attackingEnemy.Name} deals {damage} to you");
                            PlayerReference.CurrentHealth -= damage;
                        }
                        else
                        {
                            damage = attackingEnemy.MaxDamage;
                            Console.WriteLine($"{attackingEnemy.Name} deals {damage} to you");
                            PlayerReference.CurrentHealth -= damage;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{attackingEnemy.Name} misses they're attack.");
                    }
                    Console.WriteLine();
                }

                if (PlayerReference.CurrentHealth <= 0)
                {
                    battleStarted = false; //Player dead
                    return false;
                }
            }

            if (turnsDefend > 0)
            {
                turnsDefend -= 1;
            }
        }
        return false;
    }

    public string BattleOptionMenu()
    {
        Console.WriteLine("Make your move:");
        Console.WriteLine("[A] Attack");
        Console.WriteLine("[D] Defend");
        Console.WriteLine("[F] Flee");

        return Console.ReadLine()!.ToUpper();
    }

    public string AttackTypeMenu()
    {
        Console.WriteLine("What size attack:");
        Console.WriteLine("[A] Big attack (Stamina cost: 45)");
        Console.WriteLine("[S] Medium attack (Stamina cost: 25)");
        Console.WriteLine("[D] Small attack (Stamina cost: 10)");

        return Console.ReadLine()!.ToUpper();
    }

    public void HandlePlayerAttack()
    {
        string type = AttackTypeMenu();
        Console.WriteLine();
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
            Monster chosenMonster = ChooseMonster()!;

            if (chosenMonster is not null)
            {
                chosenMonster.CurrentHealth -= Convert.ToInt32((double)CurrentWeapon.MaximumDamage * attackMultiplier);
                CheckMonsterHealth(chosenMonster);
                return;
            }
            else
            {
                Console.WriteLine("You strike the air with full force.");
                Console.WriteLine("The monsters look confused.");
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

    public Monster? ChooseMonster()
    {
        Console.WriteLine("What monster will you attack");
        for (int i = 0; i < MonsterList.Count; i++)
        {
            Console.WriteLine($"[{i}] {MonsterList[i].Name} - {MonsterList[i].CurrentHealth}/{MonsterList[i].MaxHealth} Hp");
        }

        int choice = int.Parse(Console.ReadLine()!);

        try
        {
            return MonsterList[choice];
        }
        catch
        {
            return null;
        }
    }

    public void CheckMonsterHealth(Monster monster)
    {
        if (monster.CurrentHealth <= 0)
        {
            Console.WriteLine($"{monster.Name} was slain");
            Console.WriteLine();
            MonsterList.Remove(monster);
        }
    }

    public void PrintPlayerStats()
    {
        Console.WriteLine($"Health: {PlayerReference.CurrentHealth} | Stamina: {Stamina}");
    }
}