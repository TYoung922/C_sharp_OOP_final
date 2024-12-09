using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Weapons_class
{
    public class Weapons
    {
        string[] weapons = { "your fists", "Chipped Dagger", "Adequat Short Sword", "Nice Long Sword", "Sting", "Sword of Piercing", "Excalibur", "orcrist",
            "Anduril", "Galamdring", "Vorpal Sword" };

        string[] weaponDiscription = { "your fists", "A simple dagger that has chipps in its blade after repeadted use", "As the name suggests it is adequat." +
                " By far a step up from that measely dagger, but not by much.", "Finally a weapon of decent quality. A very plain sword, but sturdy",
         "Sting? This truly is the mystical sword of halfling adventurers. What a find.", "This sturdy Rapier is great at getting through enemy" +
                " defenses. It increases your chance of getting a crit.", "Gues you get to be king, that is if you make it out of here alive.",
        "While a little on the heavy side this single edged sword will do some damage.", "Another chance at kingship. This sword is strong against ghosts.",
        "This sword has touched magic. If you hold it close to your ear you hear a faint crackling.", "This is a sword of legends. You feel power corsing" +
                " through it and vibrating up your arm.\nShould you land a critical hit you can tell it will spell instant death."};

        int[] weaponDamage = { 0,  1, 2, 3, 5, 6, 7, 8, 10, 13, 15 };

        string[] randomWeap = { "your fists", "bone knife", "stone axe", "broken sword", "broken axe", "rusty spear", "rusty sword", "kitchen knife", "Unbalivably Sword" +
                " of Awesome Killing!"};

        string[] randDiscrip = { "your fists", "A knife made of bone", "A crude stone axe", "A sturdy hilt with half a blade", "An axe that has a large section missing" +
                " in the blade, about the size of a neck.", "An old rusty spear, it hasn't seen much use.", "An old rusty sword, it hasn't seen much use.",
        "This kitchen knife is great for chopping vegies, not so much for monsters.", "What... How... This shouldn't be here!\n\nWell I guess you got" +
                " the 'Unbalivable Sword of Awesome Killing!'\n You won't even have to try with this."};

        int[] randDamage = { 0, 1, 1, 1, 1, 2, 2, 2, 100 };

        public (string weapon, string descrip, int damage) SelectNextWeapon(int wLvl)
        {
            int weaponTurn = wLvl;
            string weapon = weapons[weaponTurn];
            string descrip = weaponDiscription[weaponTurn];
            int damage = weaponDamage[weaponTurn];

            if (weaponTurn < weapons.Length)
            {weapon = weapons[weaponTurn + 1];
            descrip = weaponDiscription[weaponTurn + 1];
                damage = weaponDamage[weaponTurn + 1];
            }
            else
            {
                Console.WriteLine("There is nothing better than what you currently have.");
            }
            return (weapon, descrip, damage);
        }

        public (string weapon, string descrip, int damage) getWeaponInfo(int wLvl)
        {
            int weaponTurn = wLvl;
            string weapon = weapons[weaponTurn];
            string descrip = weaponDiscription[weaponTurn];
            int damage = weaponDamage[weaponTurn];

            return (weapon, descrip, damage);
        }

        public bool checkMoreWeap(int wLvl)
        {
            int waponTurn = wLvl;
            if (waponTurn < weapons.Length - 1) { return true; }
            else { return false; }
        }

        public (string weapon, string descrip, int damage) SelectRandom()
        {
            Random random = new Random();
            int weapRoll = random.Next(1, 101);

            string weapon;
            string descrip;
            int damage;

            if (weapRoll > 98)
            { weapon = randomWeap[8]; descrip = randDiscrip[8]; damage = randDamage[8]; return (weapon, descrip, damage); }
            else
            {
                int v = random.Next(1, 8);
                weapon = randomWeap[v];
                descrip = randDiscrip[v];
                damage = randDamage[v];
                return (weapon, descrip, damage);
            }
        }
        public int GetRandWeapIndex(string wName)
        { string name = wName; int rIndex = Array.FindIndex(randomWeap, s => s.Contains(name)); return rIndex; }

        public (string rWname, int damage) RandWepInfo(int rWIndex)
        { string rWname = randomWeap[rWIndex]; int damage = randDamage[rWIndex]; return (rWname, damage); }

        public (int curWeapon, bool selectRandom) weapInventory(int pWepLv, int curWep, int pRanWepLv)
        {
            bool inventoryOn = true;
            int curWeapon = curWep;
            bool selectRandom = false;
            while (inventoryOn)
            {Console.Clear();
            Console.WriteLine("Here are all the weapons you own:");
                Console.WriteLine($"\nYour current random weapon: {randomWeap[pRanWepLv]}\n");
            for (int i = 0; i <= pWepLv; i++)
            {
                Console.WriteLine($"\n{i} Weapon: {weapons[i]}\n• Description: {weaponDiscription[i]}\n");
            }
            Console.WriteLine("What would you like to equip? (type the number next to the weapon, or 'random' for you random weapon)");
            string choice = Console.ReadLine();

            if (choice == "random")
            {
                    Console.WriteLine($"You have selected {randomWeap[pRanWepLv]}");
                    selectRandom = true; 
            }
            else if (int.TryParse(choice, out int selectedWeapon))
                { 
                    if (selectedWeapon >= 0 && selectedWeapon <= pWepLv)
                    {
                        curWeapon = selectedWeapon;
                        Console.WriteLine($"You have selected {weapons[selectedWeapon]}");
                    }
                }
            else
            {
                Console.WriteLine("You have selected an invalid choice\nPress any key to continue...");
                Console.ReadKey(true);
                continue;
            }
            Console.WriteLine("\nWould you like to exit your inventory? 'y' or 'n'");
            string leave = Console.ReadLine().ToLower();
            if ( leave == "y")
                { inventoryOn = false; }
            }
            Console.Clear();
            return (curWeapon, selectRandom);
        }
    }
}
