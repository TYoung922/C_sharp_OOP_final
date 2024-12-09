using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Character_class
{
    public class Character
    {
        public int baseHealth = 50;
        public string Name;
        public int baseAttack = 5;

        public Character(string name)
        { Name = name; }
    }

    public class Player : Character
    {
        int str;
        int dex;
        int con;
        public int strbonus;
        public int agilbonus;
        public int endurbonus;
        public int curHealth;
        
        public int weaponLvl = 0;
        public int curWeapInd;
        public string weaponName;
        public int weapBonus;
        
        public int armorLvl = 0;
        public string armor;
        public int armorBonus;
        public int heroAc = 10;
        
        public int ranWeap;
        public string ranWeapName;
        public int ranWeapBonus;

        public bool ranWeapSelect = false;
        
        public int gold;

        public int gearLv;

        public List<int> potions;

        
        public Player(string name, int str, int dex, int con) : base(name)
        {
            this.str = str; this.dex = dex; this.con = con;
            strbonus = (str - 10) / 2;
            agilbonus = (dex - 10) / 2;
            endurbonus = (con - 10) / 2;

            baseHealth += endurbonus + 10;
            curHealth = baseHealth;

            heroAc += agilbonus;

            weaponName = "fists";

            baseAttack += strbonus;
            potions = new List<int> { 0, 0, 0, 0, 0};
        }

        public void ViewStats()
        {

            if (ranWeapSelect)
            {
                Console.Clear();
                Console.WriteLine($"Adventurer name: {Name}\n\nStats:\n  • Strength: {str} (+{strbonus})\n  • Agility: {dex}(+{agilbonus})\n  • Endurance: {con}(+{endurbonus})\n\n" +
                    $"Gear:\n  • Weapon: {ranWeapName}(+{ranWeapBonus})\n  • Armor: {armor}(+{armorBonus})\n\nHealth: {curHealth}/{baseHealth}");
                Console.WriteLine("\n\n\nPress any button to return to menu.");
                Console.ReadKey(true);
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Adventurer name: {Name}\n\nStats:\n  • Strength: {str} (+{strbonus})\n  • Agility: {dex}(+{agilbonus})\n  • Endurance: {con}(+{endurbonus})\n\n" +
                    $"Gear:\n  • Weapon: {weaponName}(+{weapBonus})\n  • Armor: {armor}(+{armorBonus})\n\nHealth: {curHealth}/{baseHealth}");
                Console.WriteLine("\n\n\nPress any button to return to menu.");
                Console.ReadKey(true);
                Console.Clear();
            }
        }

        public int Heal(int hLvl)
        {
            int healLevl = hLvl;
            int healingPotential = (4 * healLevl) + 1;

            Random random = new Random();
            int healRoll = random.Next(1, healingPotential) + healLevl + endurbonus;

            curHealth += healRoll;
            if (curHealth > baseHealth) { curHealth = baseHealth; }
            return healRoll; 
        }

        public int potionMenu(bool full)
        {
            int healthBack = 0;
            Console.Clear();
            bool pMenOn = true;
            while (pMenOn) {
                Console.WriteLine($"You open your bag of potions. There are" +
                    $"\n• {potions[0]} Lvl 1.\n• {potions[1]} Lvl 2.\n• {potions[2]} Lvl 3.\n• {potions[3]} Lvl 4.\n• {potions[4]} Lvl 5.\n\n" +
                    $"\n(type the potion lvl number of the potion you would like to use)");
                string pChoice = Console.ReadLine();

                if (int.TryParse(pChoice, out int lvl))
                {
                    if (potions[lvl - 1] > 0)
                    {if (lvl > 0 && lvl < 6 && full)
                        {
                            healthBack = Heal(lvl);
                            pMenOn = false;
                        }
                        else if (lvl > 0 && lvl < 6 && !full)
                        {
                            int newlvl = lvl - 1;
                            if (newlvl > 0)
                            {
                                healthBack = Heal(newlvl);
                            }
                            else { healthBack = Heal(1); }
                            pMenOn = false;
                        }
                        else { Console.WriteLine("Potions of that levle don't exist."); }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Sorry, you have no more potions of that levle. Due to the speed of combat your turn is taken up");
                    }
                }
                else { Console.Clear(); Console.WriteLine("That wasn't a valid choice."); }
            }
            return healthBack;
        }

        public void HealMenu()
        {
            Console.Clear();
            if (curHealth == baseHealth)
            { Console.WriteLine("No injuries I see. You are wise to stock up on health potions ahead of time."); }
            else { Console.WriteLine("You sustained some injuries I see. Not to worry we can fix you up."); }

            bool healMenOn = true;

            while (healMenOn)
            { 
                Console.WriteLine($"Your health is currently {curHealth}/{baseHealth}\nWhat brand of healing would you like?\n• Buy potions for you journey into the dark (type 'buy')" +
                    $"\n• Use your purchased potions before heading off (type 'use')" +
                    "\n• view your current health potion inventory (type 'bag')\n• Return to the main menu (type 'exit')");
                string response = Console.ReadLine().ToLower();

                if (response == "buy")
                {
                    bool buyingOn = true;
                    bool buySuccess = false;
                    Console.Clear();
                    while (buyingOn)
                    {
                        if (buySuccess) { Console.Clear(); Console.WriteLine("Thanks for your purchase"); }
                        Console.WriteLine($"Your current gold is {gold}" +
                            $"\n\nWe have different strength healing potions to choose from.\n• Lvl 1 potion (1 gold)\n• Lvl 2 potion (2 gold)\n• Lvl 3 potion (3 gold)" +
                        "\n• Lvl 4 potion (4 gold)\n• Lvl 5 potion (5 gold)\n\n(type the levl number (1-5) of the potion you would like or 'exit' to leave this menu.)");
                    string wBuy = Console.ReadLine();

                        if (wBuy == "1" && gold >= 1)
                        {
                            gold -= 1;
                            potions[0]++;
                            buySuccess = true;
                        }
                        else if (wBuy == "2" && gold >= 2)
                        {
                            gold -= 2;
                            potions[1]++;
                            buySuccess = true;
                        }
                        else if (wBuy == "3" && gold >= 3)
                        {
                            gold -= 3;
                            potions[2]++;
                            buySuccess = true;
                        }
                        else if (wBuy == "4" && gold >= 4)
                        {
                            gold -= 4;
                            potions[3]++;
                            buySuccess = true;
                        }
                        else if (wBuy == "5" && gold >= 5)
                        {
                            gold -= 5;
                            potions[4]++;
                            buySuccess = true;
                        }
                        else if (int.TryParse(wBuy, out int number))
                        { if (number < gold) { Console.Clear(); Console.WriteLine("Sorry you don't have enough gold"); buySuccess = false; } }
                        else if (wBuy == "exit") { buyingOn = false; Console.Clear(); }
                        else { Console.Clear(); Console.WriteLine("That wasn't a valid choice."); buySuccess = false; }

                    }
                }
                else if (response == "use")
                { 
                    Console.Clear();
                    Console.WriteLine($"Your current HP is {curHealth}/{baseHealth}\n• You have {potions[0]} Lvl 1 potions\n• You have {potions[1]} Lvl 2 potions\n• You have {potions[2]} Lvl 3 potions" +
                        $"\n• You have {potions[3]} Lvl 4 potions\n• You have {potions[4]} Lvl 5 potions \n\n(Type the number of the potion level you would like to use.)");
                    string potionUsed = Console.ReadLine();
                    if (potionUsed == "1" && potions[0] > 0)
                    {
                        potions[0]--;
                        var healing = Heal(1); Console.WriteLine($"Your levle 1 potion healed you for {healing}");
                        Console.WriteLine($"Your HP is now {curHealth}/{baseHealth}\n\n(Press any key to continue)");
                        Console.ReadKey(true);
                    }
                    else if (potionUsed == "2" && potions[1] > 0)
                    {
                        potions[1]--;
                        var healing = Heal(2); Console.WriteLine($"Your levle 2 potion healed you for {healing}");
                        Console.WriteLine($"Your HP is now {curHealth}/{baseHealth}\n\n(Press any key to continue)");
                        Console.ReadKey(true);
                    }
                    else if (potionUsed == "3" && potions[2] > 0)
                    {
                        potions[2]--;
                        var healing = Heal(3); Console.WriteLine($"Your levle 3 potion healed you for {healing}");                       
                        Console.WriteLine($"Your HP is now {curHealth}/{baseHealth}\n\n(Press any key to continue)");
                        Console.ReadKey(true);
                    }
                    else if (potionUsed == "4" && potions[3] > 0)
                    {
                        potions[3]--;
                        var healing = Heal(4); Console.WriteLine($"Your levle 4 potion healed you for {healing}");
                        Console.WriteLine($"Your HP is now {curHealth}/{baseHealth}\n\n(Press any key to continue)");
                        Console.ReadKey(true);
                    }
                    else if (potionUsed == "5" && potions[4] > 0)
                    {
                        potions[4]--;
                        var healing = Heal(5); Console.WriteLine($"Your levle 5 potion healed you for {healing}");
                        Console.WriteLine($"Your HP is now {curHealth}/{baseHealth}\n\n(Press any key to continue)");
                        Console.ReadKey(true);
                    }
                    else if (int.TryParse(potionUsed, out int number))
                        { if (potions[number - 1] < 1) { Console.WriteLine("Sorry you don't have any potions of that level. \n(press any key to continue)"); Console.ReadKey(true); } }
                    else { Console.WriteLine("That is not a valid response"); }
                    Console.Clear();
                }
                else if (response == "bag")
                { Console.Clear(); Console.WriteLine($"Your bag contains:\n• {potions[0]} Lvl 1 potions\n• {potions[1]} Lvl 2 potions\n• {potions[2]} Lvl 3 potions" +
                    $"\n• {potions[3]} Lvl 4 potions\n• {potions[4]} Lvl 5 potions\n\n(Press any key to return to the menu)"); Console.ReadKey(true); Console.Clear();
                }
                else if (response == "exit")
                { healMenOn = false; Console.Clear(); }
                else { Console.WriteLine("That's not a valid input. Please try again."); }
                
            }
        }

        public bool CheckForCrit(int attack)
        {
            bool critWep = false;

            if ( weaponName == "Sword of Piercing" || weaponName == "Vorpal Sword")
            {
                critWep = true;
            }

            if (attack >= 18 && critWep)
            { return true; }
            else if (attack > 19 && !critWep)
            { return true; }
            else { return false; }
        }

        public void SetGearLv()
        {
            gearLv = armorLvl + weaponLvl;
        }
    }

    public class Monster : Character
    {
        public string name;
        public int beastArmor;
        public int monstAc;
        public int goldDrop;
        public int attack;
        public int health;

        public int curHP;
        public Monster(string name) : base(name) 
        {
            this.name = "Monster";
            baseHealth = 25;
        }

        List<(string name, int damage, int deffense, int ac)> monsterList = new List<(string, int, int, int)>
        {
            ("Large Rat", 0, 0, 10),
            ("Angry Boar", 1, 0, 10),
            ("Mange Dog", 1, 0, 10),  
            ("kabold",2, 1, 11), 
            ("Enraged Bear", 2, 1, 11), 
            ("Dire Wolf", 3, 2, 12), 
            ("goblin", 3, 2, 12), 
            ("War Orc", 4, 3, 13), 
            ("Gargoyle", 4, 3, 13),
            ("Minotaur", 5, 4, 14), 
            ("Gorgon", 6, 5, 15), 
            ("Troll", 8, 7, 15), 
            ("Wyvern", 10, 9, 16), 
            ("Hydra", 12, 13, 17), 
            ("Dragon", 15, 14, 17)
        };

        public void SelectMonster(int range)
        {
            int myRange = range;
            int minR = 0;
            List<(string name, int damage, int deffense, int ac)> mSelection = new List<(string name, int damage, int deffense, int ac)>();
            if (range == 0)
            {
                mSelection.Add(monsterList[0]);
            }
            else
            {
                foreach (var item in monsterList)
                {
                    if (item.damage <= myRange)
                    {
                        mSelection.Add(item);
                    }
                }
                minR += 1;
            }
            Random random = new Random();

            int randNum = random.Next(minR, myRange + 1);
            name = mSelection[randNum].name;
            baseAttack += mSelection[randNum].damage;
            beastArmor = mSelection[randNum].deffense;
            baseHealth += mSelection[randNum].damage;
            curHP = baseHealth;
            monstAc = mSelection[randNum].ac;
            goldDrop = mSelection[randNum].damage;
            if (goldDrop < 1) { goldDrop = 1; }
        }

        public void FaceDragon()
        {
            name = monsterList[14].name;
            attack = baseAttack + monsterList[14].damage;
            beastArmor = monsterList[14].deffense;
            health = baseHealth + monsterList[14].damage;
            curHP = health;
            monstAc = monsterList[14].ac;
            goldDrop = monsterList[14].damage;
        }

        // 11 weap 5 arm max 16 / monst 15
    }
}
