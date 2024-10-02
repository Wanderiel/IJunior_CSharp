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
            int bossMaxDamage = 5;
            int boosBonusDamage = random.Next(bossMaxDamage) + 1;
            bool isBossLive = true;

            int playerMaxHealth = 30;
            int playerHealth = playerMaxHealth;
            int playerMaxMana = 15;
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
                        if (canCastSpellExplosion)
                        {
                            damage = spellExplosionDamage;
                            canCastSpellExplosion = false;
                            Console.WriteLine("Искусство - это ВЗРЫВ!");
                        }
                        break;

                    case CommandSpellHeal:
                        if (spellHealCount > 0)
                        {
                            playerHealth = Math.Clamp(playerHealth + spellHealRestoreHealth, playerHealth, playerMaxHealth);
                            playerMana = Math.Clamp(playerMana + spellHealRestoreMana, playerMana, playerMaxMana);
                            spellHealCount--;
                            Console.WriteLine($"Восстановлено: {spellHealRestoreHealth} здоровья и {spellHealRestoreMana} маны");
                            Console.WriteLine($"Осталось зарядов: {spellHealCount}");
                        }
                        break;
                }

                if (damage > 0)
                {
                    bossHealth -= damage;
                    Console.WriteLine($"Вы нанесли {damage} урона");
                }

                int bossDamage = random.Next(bossMaxDamage) + 1 + boosBonusDamage;
                playerHealth -= bossDamage;
                Console.WriteLine($"Противник наносит вам урон {bossDamage}");

                if (bossHealth < 0)
                    isBossLive = false;

                if (playerHealth < 0)
                    isPlayerLive = false;

                Console.ReadKey();
            }

            if (isPlayerLive)
                Console.WriteLine("Противник повержен, победа за вами!");
            else if (isBossLive)
                Console.WriteLine("Вы мертвы...");
            else
                Console.WriteLine("Противник повержен, но и вы не живы...");

            Console.ReadKey();
        }
    }
}
