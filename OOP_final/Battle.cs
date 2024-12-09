using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Character_class;

namespace OOP_final
{
    public class Battle
    {
        public (bool playerAlive, bool DragonDead) BattleMenu(Monster monst, Player hero)
        {
            string enemy = monst.name;
            int eDamage = monst.baseAttack;
            int eDefend = monst.beastArmor;
            //int enemyHp = monst.baseHealth;

            int uDamage = hero.baseAttack + hero.weapBonus;
            int uDefend = hero.armorBonus;
            int uAgility = hero.agilbonus;
            string pWep = hero.weaponName;
            int uHp = hero.curHealth;

            bool playAlive = true;

            string atkImg = @"
            ;     \
            `;   __`\
             ;,-',_`,\
              ;|/`)  \
               \/'_)/ |
                \/( | :
           ,---=='='=`===----.
           `---==|  ;  \==---'
--  --  --  --   |  ;.  \
--  --  --  --   |  `;   \
--  --  --  --   |   ;.   \
--  --  --  --   |   `;    \
--  --  --  --   |    ;.    \
--  --  --  --   |    `;     \   
--  --  --  --   |     ;.     \
--  --  --  --   |     `;      \
--  --  --  --   `--..._ `  _.-'
                        `--'

       SHWING";

            bool enter = true;

            bool menu = false;
            
            Console.Clear();

            string[] directions = { "to your left", "to your right", "above you", "behind you" };
            Random rand = new Random();
            int pInitative = rand.Next(1, 21) + uAgility;
            int mInitative = rand.Next(1, 21); ;



            while (enter)
            { 
                    string sound = directions[rand.Next(0, 3)];
                    Console.WriteLine($"You appear in a dark cave. There is a faint sickly red glow from strange moss growing on the walls and ceiling\n" +
                        $"You hear something {sound}. You look to see the shadow of a creature emerging from the darkness...\n\n(press any key to look) ");
                    Console.ReadKey(true);
                Console.Clear();
                    Console.WriteLine($"It's a {enemy}\n\nDo you stand and fight or run away? (type 'fight' or 'run')");
                    string choice = Console.ReadLine();

                    if (choice == "fight")
                    { menu = true; enter = false; }
                    else if (choice == "run")
                    { 
                        Console.WriteLine("You reach for the medalion the wizard gave you to let him teleport you back.\n\n(press any key to activate medalion)");
                        Console.ReadKey(true);
                        Console.Clear();
                        enter = false;
                        menu = false;
                    }
                    else { Console.WriteLine("Not a valid response. Try again."); }
                 
            }

            bool firstRound = true;
            int monsterRoll = rand.Next(1, 21);
            int playerRoll = rand.Next(1, 21) + uAgility;

            int tempAc = 0;
            bool monstDead = false;

            bool pFirst = true;
            bool isDragon = false;
            bool dragonDead = false;
            if (monst.name == "Dragon") { isDragon = true; }


            while (menu)
            {
                if (firstRound)
                {
                    Console.Clear();
                    Console.WriteLine($"You ready your {hero.weaponName} facing off agains the {monst.name }"); 
                    if (playerRoll >= monsterRoll) { pFirst = true; Console.WriteLine("Your quick reactions allows you to go first.\n\n(press " +
                        "any key to take your turn)"); Console.ReadKey(true); firstRound = false;}
                    else
                    {
                        Console.WriteLine("You didn't respond quick enough and the {enemy} strikes first. \n\n(press any key to see what happens)");
                        Console.ReadKey(true);
                        pFirst = false;
                        firstRound = false;
                    }
                }
                else if (pFirst)
                {
                    var takeTurn = playerTurn(hero, monst);
                    tempAc = takeTurn.blk;

                    if (takeTurn.atk[0] >= monst.monstAc) {
                        int dmgTaken = takeTurn.atk[1] - monst.beastArmor;
                        monst.curHP -= dmgTaken;
                        Console.Clear();
                        Console.WriteLine(atkImg);
                        if (takeTurn.crit) 
                        { 
                            Console.WriteLine("(You got a crit)"); 
                            if (hero.weaponName == "Vorpal Sword")
                            {
                                Console.WriteLine($"With your powerful Vorpal Sword you behead the {monst.name}");
                            }
                        }
                        if (takeTurn.crit && hero.weaponName == "Vorpal Sword")
                        {                                                        
                            Console.WriteLine($"With your powerful Vorpal Sword you behead the {monst.name}" +
                                $"\n(press any key to continue)");
                        }
                        else
                        {
                            Console.WriteLine($"\n\nYou did {dmgTaken} to the {monst.name}\n\n(press any key to see enemy attack)");
                        }
                        Console.ReadKey(true);
                        pFirst = false;
                        if (monst.curHP < 0) { monstDead = true; }
                    }
                    else if (takeTurn.atk[0] < monst.monstAc && takeTurn.atk[0] > 0) { Console.WriteLine("You missed. \n\n(press any key to continue)"); 
                        Console.ReadKey(true);}
                    //else if (takeTurn.run && takeTurn.safe) { Console.WriteLine }
                    else { Console.WriteLine("Your didn't do any damage this turn. Lets see what your enemy manages.\n(press any key to continue)");
                        Console.ReadKey(true);
                        pFirst = false; }
                }
                else if (!pFirst && !monstDead)
                {
                    var monstTurn = EnemyTurn(monst.baseAttack, monst.monstAc - 10);
                    if (monstTurn.roll >= hero.heroAc + tempAc)
                    {
                        int dmgTaken = monstTurn.damage - hero.armorBonus;
                        hero.curHealth -= dmgTaken;
                        Console.Clear();
                        Console.WriteLine($"You took {dmgTaken} from the {monst.name}\n\n(press any key to continue)");
                        Console.ReadKey(true);
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine($"The {monst.name} missed. You take not damage.\n\n(press any key to continue)");
                    }
                    pFirst = true;
                }
                if (hero.curHealth < 1)
                { playAlive = false; menu = false; }
                else if (monst.curHP < 1)
                {
                    Console.WriteLine($"You have successfully slain the {monst.name}. \nYou recieve {monst.goldDrop} gold" +
                        $"\n\n(press any key to activate the medallion and return to the wizard)");
                    Console.ReadKey(true);
                    Console.Clear();
                    hero.gold += monst.goldDrop;

                    if (isDragon) { dragonDead = true; }

                    menu = false;
                }
                else { playAlive = true; }

            }

            //if dragon dead
            return (playAlive, dragonDead);

        }

        public (List<int> atk, int blk, bool run, bool safe, bool instKill, bool crit) playerTurn(Player hero, Monster monst)
        {
            List<int> atk = new List<int>{0, 0};
            int block = 0;
            bool runAway = false;
            bool safeRun = false;
            bool actChoice = true;
            bool instaKill = false;
            bool youCrit = false;

            while (actChoice)
            {
                Console.Clear();
                Console.WriteLine($"Your current HP is {hero.curHealth}/{hero.baseHealth}\nThe {monst.name} HP is {monst.curHP}/{monst.baseHealth}\n\n" +
                    $"\nWhat do you wish to do?\n• 'Attack' (atempt to do damage)\n• 'Block' (sometimes you can prepare something esle while blocking)" +
                "\n• 'Potion' (drink one of your potions to regain health)\n• 'Run' Away (there are a few ways to do this)");
                string action = Console.ReadLine().ToLower();

                if (action == "attack") 
                {
                    bool fullAtk = true;
                    var atkTry = PlayerAttack(fullAtk, hero.weapBonus + hero.baseAttack);
                    var crit = hero.CheckForCrit(atkTry.roll);
                    int rollBouns = atkTry.roll + hero.strbonus+(hero.weapBonus/3);
                    int atkDmg = atkTry.damage;
                    if (crit) { atkDmg *= 2; youCrit = true; if (hero.weaponName == "Vorpal Sword") { instaKill = true; } }

                    atk[0] = rollBouns;
                    atk[1] = atkDmg;
                     
                    actChoice = false; 
                }
                else if (action == "block")
                {
                    bool bChoice = true;
                    while (bChoice)
                    {
                        Console.WriteLine("When you block you prepare for an enemy attack increasing your chances of resisting damage." +
                        "\nHowever, there are a few ways to prepare for an attack. Which do you want to do?\n• " +
                        "\n• 'Counter' block (increase defense by 1 while performing a much weaker attack)" +
                        "\n• 'Full' block (increase defense by 4 but take no other action)" +
                        "\n• 'heal' block (increase defense by 2 and heal, though the level of the potion you use is decreased)" +
                        "\n• 'flee' block (increase defense by 3 and run away. This gaurantees escape)");
                        string blockType = Console.ReadLine().ToLower();

                        if (blockType == "counter") 
                        {
                            bool fullAtk = false;
                            var atkTry = PlayerAttack(fullAtk, hero.weapBonus + hero.baseAttack);
                            int atkDmg = atkTry.damage;

                            atk[0] = atkTry.roll + hero.strbonus;
                            atk[1] = atkDmg;

                            block = 1;
                            bChoice = false; 
                        }
                        else if (blockType == "full") { block = 4; bChoice = false; }
                        else if (blockType == "heal") 
                        { 
                            bool fullPotion = false;
                            int potion = hero.potionMenu(fullPotion);
                            Console.Clear();
                            Console.WriteLine($"You gain {potion} health back. Your current HP is {hero.curHealth}/{hero.baseHealth}" +
                                $"\n\n(press any key to continue)");
                            bChoice = false; 
                        }
                        else if (blockType == "flee") { block = 3; safeRun = true; bChoice = false; }
                        else { Console.WriteLine("that wasn't a valid response"); }
                    }
                    actChoice = false;
                }
                else if (action == "potion") 
                {
                    bool fullHeal = true;
                    var potion = hero.potionMenu(fullHeal);
                    Console.Clear();
                    Console.WriteLine($"You gain {potion} health back. Your current HP is {hero.curHealth}/{hero.baseHealth}\n\n(press any key to continue)");
                    Console.ReadKey();
                    actChoice = false; 
                }
                else if (action == "run") { safeRun = false; runAway = true; actChoice = false; }
                else { Console.WriteLine("That wasn't a valid response"); }
            }
           return (atk, block, runAway, safeRun, instaKill, youCrit);
        }

        public (int roll, int damage) PlayerAttack(bool fullAtk, int atkPow)
        {
            Random random = new Random();
            int pRoll = random.Next(1, 21);
            int pDamage;
            if (fullAtk) { pDamage = random.Next(1, 6) + atkPow; }
            else { pDamage = random.Next(1, 4) + (atkPow / 2); }

            return (pRoll, pDamage);

        }

        public (int roll, int damage) EnemyTurn(int enemyD, int enemyPlus)
        {
            Random random = new Random();
            int mDdice = 4;

            if (enemyD >= 10)
            { mDdice = 6; }

            int atkRoll = random.Next(1, 21) + enemyPlus;
            int atkDamage = random.Next(1, mDdice) + enemyD;

            return (atkRoll, atkDamage);
        }
    }
}
