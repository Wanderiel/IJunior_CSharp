namespace ISL_11_BossFight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ConsoleKey CommandBaseAttack = ConsoleKey.E;
            const ConsoleKey CommandSpellFireball = ConsoleKey.R;
            const ConsoleKey CommandSpellExplosion = ConsoleKey.T;
            const ConsoleKey CommandSpellHeal = ConsoleKey.H;

            Random random = new Random();
            int bossHealth = 50;
            int bossMaxDamage = 3;
            int boosBonusDamage = random.Next(bossMaxDamage) + 1;
            bool isBossLive = true;

            int playerMaxHealth = 30;
            int playerHealth = playerMaxHealth;
            int playerMaxMana = 20;
            int playerMana = playerMaxMana;
            int playerMaxDamage = 3;
            int playerBonusDamage = random.Next(playerMaxDamage) + 1;
            bool isPlayerLive = true;

            int spellFireballDamage = 8;
            int spellFireballManaCost = 5;

            int spellExplosionDamage = 10;
            bool canCastSpellExplosion = false;

            int spellHealRestoreHealth = 10;
            int spellHealRestoreMana = 5;
            int spellHealCount = 3;

            while (isPlayerLive && isBossLive)
            {
                int damage = 0;
                Console.Clear();
                Console.WriteLine($"Ваши Здоровье/Мана: {playerHealth}/{playerMana}");
                Console.WriteLine($"Здоровье Боса: {bossHealth}");
                Console.WriteLine("\nВаши действия?");
                Console.WriteLine($"[{CommandBaseAttack}] - Выполнить простую атаку");

                if (playerMana > spellFireballManaCost)
                    Console.WriteLine($"[{CommandSpellFireball}] - Прочитать заклинание огненного шара " +
                        $"(стоимость {spellFireballManaCost}, урон {spellFireballDamage})");

                if (canCastSpellExplosion)
                    Console.WriteLine($"[{CommandSpellExplosion}] - Подорвать противника (урон {spellExplosionDamage})");

                if (spellHealCount > 0)
                    Console.WriteLine($"[{CommandSpellHeal}] - Восстановить {spellHealRestoreHealth} здоровья и {spellHealRestoreMana} маны " +
                        $"(количество: {spellHealCount})");

                ConsoleKey key = Console.ReadKey(true).Key;
                Console.WriteLine();

                switch (key)
                {
                    case CommandBaseAttack:
                        damage = random.Next(playerMaxDamage) + 1 + playerBonusDamage;
                        break;

                    case CommandSpellFireball:
                        if (playerMana >= spellFireballManaCost)
                        {
                            playerMana -= spellFireballManaCost;
                            damage = spellFireballDamage;
                            canCastSpellExplosion = true;
                        }
                        else
                        {
                            Console.WriteLine("У вас не достаточно маны для заклинания");
                        }
                        break;

                    case CommandSpellExplosion:
                        damage = spellExplosionDamage;
                        canCastSpellExplosion = false;
                        break;

                    case CommandSpellHeal:
                        playerHealth = Math.Clamp(playerHealth + spellHealRestoreHealth, playerHealth, playerMaxHealth);
                        playerMana = Math.Clamp(playerMana + spellHealRestoreMana, playerMana, playerMaxMana);
                        spellHealCount--;
                        Console.WriteLine($"Восстановлено: {spellHealRestoreHealth} здоровья и {spellHealRestoreMana} маны");
                        Console.WriteLine($"Осталось зарядов: {spellHealCount}");
                        break;
                }

                if (damage > 0)
                {
                    bossHealth -= damage;
                    Console.WriteLine($"Вы нанесли {damage} урона");
                }

                Console.ReadKey();
            }
        }
    }
}
