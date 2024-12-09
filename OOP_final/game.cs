using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cauldron_class;
using Weapons_class;
using Armor_class;
using System.ComponentModel.Design;
using Character_class;

namespace OOP_final
{
    public class Game
    {

        int[] startingStats = { 12, 14, 16 };

        Caldron caldron = new Caldron();

        Weapons weapon = new Weapons();

        Armor armor = new Armor();

        public (int str, int agil, int endur, bool charMade, string name) StartGame()
        {
            List<string> atributes = new List<string> { "strength 'str'", "agility 'agil'", "endurance 'endur'" };

            int str = 0;
            int agil = 0;
            int endur = 0;
            bool charMade = false;

            Console.WriteLine();
            string welcome = "Welcome adventurer to...";
            int pad = (Console.WindowWidth - welcome.Length) / 2;
            string padWelcome = new string(' ', pad) + welcome;
            Console.WriteLine(padWelcome);

            Console.WriteLine("\n");
            string text = @"
                          A     DDDDD   V   V  EEEEE  N   N  TTTTT  U   U  RRRR    EEEEE  SSSSS      
                         A A    D    D  V   V  E      NN  N    T    U   U  R   R   E      S          
                        A   A   D    D  V   V  EEEE   N N N    T    U   U  RRRR    EEEE    SSS       
                        AAAAA   D    D   V V   E      N  NN    T    U   U  R  R    E           S     
                        A   A   DDDDD     V    EEEEE  N   N    T     UUU   R   R   EEEEE   SSSSS     
                
                            I   N   N    TTTTT  H   H  EEEEE    DDDDD    A    RRRR    K   K
                            I   NN  N      T    H   H  E        D    D  A A   R   R   K  K
                            I   N N N      T    HHHHH  EEEE     D    D A   A  RRRR    KKK
                            I   N  NN      T    H   H  E        D    D AAAAA  R  R    K  K
                            I   N   N      T    H   H  EEEEE    DDDDD  A   A  R   R   K   K
";
            Console.WriteLine(text);
            Console.WriteLine("\n");

            string Text = "Press any key to wake up.";
            int padding = (Console.WindowWidth - Text.Length) / 2;
            string padText = new string(' ', padding) + Text;
            Console.WriteLine(padText);
            Console.ReadKey(true);

            Console.Clear();

            Console.WriteLine("\nYou awake in a dark land you can't see anything around you.");
            Console.WriteLine("Your mind is foggy, but bits of information are coming back.\nThere is a name that comes to you... What is it?");
            string name = Console.ReadLine();

            Console.WriteLine($"\nWelcome {name} I hope your adventures go well.\nThere are many dangers in the dark you will need strength, agility, and endurance to survive.");
            Console.WriteLine("Which is your greatest atribute, 'str', 'agil', or 'endur'?");
            string atOne = Console.ReadLine();

            if (atOne == "str")
            { 
                Console.WriteLine("A choice with potential. Strength will help you defeat your enemies quickly. You cannot rely on strength alone however.");
                atributes.Remove("strength 'str'");
                str = startingStats[2];
            }
            else if (atOne == "agil")
            { 
                Console.WriteLine("A wise choice, the ability to avoid damage is vital. Though you will quickly fall if all you rely on is your quickness.");
                atributes.Remove("agility 'agil'");
                agil = startingStats[2];
            }
            else 
            { 
                Console.WriteLine("Sturdy like a rock, a valuable trait. Even the hardest rock can be worn away in time.");
                atributes.Remove("enduracne 'endur'");
                endur = startingStats[2];
            }
            Console.WriteLine("What is of next most importance?");
            Console.WriteLine($"{atributes[0]} or {atributes[1]}");
            string secondC = Console.ReadLine();

            if (secondC == "str")
            {
                atributes.Remove("strength 'str'");
                str = startingStats[1];
                if (atributes[0] == "endurance 'endur'") { endur = startingStats[0]; }
                else { agil = startingStats[0]; }
                Console.WriteLine($"A choice with potential. Strength will help you defeat your enemies quickly. Which makes {atributes[0]} of least importance to you.");
                charMade = true;
            }
            else if (secondC == "agil")
            {
                atributes.Remove("agility 'agil'");
                agil = startingStats[1];
                if (atributes[0] == "endurance 'endur'") { endur = startingStats[0]; }
                else { str = startingStats[0]; }
                Console.WriteLine($"A wise choice, the ability to avoid damage is vital. Which makes {atributes[0]} of least importance to you.");
                charMade = true;
            }
            else
            {
                atributes.Remove("enduracne 'endur'");
                endur = startingStats[1];
                if (atributes[0] == "agility 'agil'") { agil = startingStats[0]; }
                else { str = startingStats[0]; }
                Console.WriteLine($"Sturdy like a rock, a valuable trait. Which makes {atributes[0]} of least importance to you.");            
                charMade = true;
            }
            Console.WriteLine("\nI pray your choices serve you well. If you are ready I can offer some light to the situation.");
            Console.WriteLine("\nAre you ready to begin?\n (press any key to begin...)");
            Console.ReadKey(true);


            return (str, agil, endur, charMade, name);
        }

        public async 
        Task
MenuIntro(bool firstTime)
        {
            bool firstMenu = firstTime;


            if (firstMenu)
            {
                Console.WriteLine("Welcome to my fire. If only you could stay longer.\nWhile I must soon send you on your way know this is not our last meeting.");
                Console.WriteLine("The monster horde is upon us. They have come from the depths to destroy us." +
                    "\nI have discovered a way to the Alpha beast, the creature that leads the horde.\nI would go myself but my magic doesn't work in the depths." +
                    "\nI can send you down and pull you out but that is the only aid I can give.");
                Console.WriteLine("You must battle to gain wealth which will let you buy better gear to defeat stronger foes the deeper you go.");
                Console.WriteLine("Return to me after each battle and you will have the option to increase your might.");
                Console.WriteLine("Now look into my cauldron and behold your path forward...\n\nPress any key to look into the cauldren.");
                Console.ReadKey(true);
                Console.Clear();

                await caldron.CauldronAnimate(400);

                Console.Clear();

                Console.WriteLine("The smoke from the cauldron rises creating a cloud. Within the cloud you see words form...\n\n");
            }
            else
            { Console.WriteLine("Welcome back gaze into my cauldron once more to continue your quest.\n\nPress any key to gaze in the cauldren");
                Console.ReadKey(true);
                Console.Clear();

                await caldron.CauldronAnimate(400);

                Console.Clear();

                Console.WriteLine("The smoke from the cauldron rises creating a cloud. Within the cloud you see words form...\n\n");
            }
            





        }

        public (bool fight, bool view, bool inven, bool heal, bool exit, int gold, int weap, int arm, int rWeap, bool ranSelect) Menu(int pGold, int numbweap, int numbArm, int rWeap, bool ranSelect)
        {
            int gold = pGold;
            int weapLv = numbweap;
            int armLv = numbArm;
            int randW = rWeap;
            bool ranWeapSelect = ranSelect;



            bool fight = false;
            bool exit = false;
            bool view = false;
            bool inventory = false;
            bool heal = false;

            bool mainMenu = true;

            while (mainMenu)
            {Console.WriteLine("What do you wish to do?");
            Console.WriteLine("\n• Fight Monsters (type 'fight)\n• View your stats (type 'view')\n• Purchase gear (type 'buy')" +
                    "\n• View your inventory of previously purchased weapons (type 'inven')\n• Tend your wounds (type 'heal')\n• Exit the game (type 'exit')");
            string playerChoice = Console.ReadLine().ToLower();

            if (playerChoice == "fight")
            { fight = true; mainMenu = false; }
            else if (playerChoice == "view") { view = true; mainMenu = false; }
            else if (playerChoice == "buy") { 
                    var eMResult = EquipMenu(gold, weapLv, armLv, randW, ranWeapSelect); 
                    gold = eMResult.gold;
                    weapLv = eMResult.weap;
                    armLv = eMResult.arm;
                    randW = eMResult.randW;
                    ranWeapSelect = eMResult.ranSelect;
                }
            else if (playerChoice == "view") { view = true; mainMenu = false; }
            else if (playerChoice == "exit") { exit = true;  mainMenu = false; }
            else if (playerChoice == "inven") { inventory = true; mainMenu = false; }
            else if (playerChoice == "heal") { heal = true; mainMenu = false; }
            }
            return (fight, view, inventory, heal, exit, gold, weapLv, armLv, randW, ranWeapSelect);

        }

        public (int gold, int weap, int arm, int randW, bool ranSelect) EquipMenu(int pGold, int nubWeapons, int nubArmor, int rWeap, bool ranSelect)
        {
            int gold = pGold;
            int weapNumb = nubWeapons;
            int armNumb = nubArmor;
            int weapRand = rWeap;
            string response;
            bool wepBuy = false;
            bool ranWeapSelect = ranSelect;

            bool inMenu = true;


            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine($"Your gear is an important contributor to your success or failure\nYou have {gold} gold available to you.");
                Console.WriteLine("\n\nYour options are:\n• Buy a Weapon (type 'weapon')\n• Buy Armor (type 'armor')" +
                    "\n• Leave the Shop (type 'leave')");
                response = Console.ReadLine().ToLower();

                if (response == "weapon")
                {
                    var weps = EquipWeap(weapNumb, weapRand, gold, ranWeapSelect);
                    gold = weps.goldP;
                    //if (weps.randWeap != weapRand && weapNumb == weps.curWeap) { weapRand = weps.randWeap; }
                    //else { weapNumb = weps.curWeap; weapRand = 0; }
                    weapRand = weps.randWeap;
                    weapNumb = weps.curWeap;
                    wepBuy = weps.buyWep;
                    ranWeapSelect = weps.ranSelect;


                }
                else if (response == "armor")
                {
                   var arm = EquipArmor(armNumb, gold);
                    armNumb = arm.curArmor;
                    gold = arm.gold;
                }
                else { Console.Clear(); inMenu = false; }
            }
            return (gold, weapNumb, armNumb, weapRand, ranWeapSelect);

        }

        public (int curWeap, int randWeap, int goldP, bool ranSelect, bool buyWep) EquipWeap(int nubWeapons, int randW, int pMoney, bool ranSelect)
        {
            int nubWeap = nubWeapons;
            int numbRand = randW;
            bool selectRan = false;
            int curGold = pMoney;
            bool ranWeapSelect = ranSelect;
            bool wepBuy = false;
            bool wMenu = true;

            while (wMenu)
            {Console.Clear();
            Console.WriteLine("I should warn you that the shop is poor itself.\nIn order to see better weapons you must spend" +
                "money so they can aford to get a more powerful weapon.\n\nYou have a few options to choose from");
            Console.WriteLine("• See the next available weapon for sale (type 'next')\n• Buy and equip a random weapon for 1 gold. " +
                "(poor chances but you never know what you might get) (type 'random')\n• Go back (type 'back')");
            string choice = Console.ReadLine().ToLower();

                if (choice == "next")
                {
                    bool checkW = weapon.checkMoreWeap(nubWeap);

                    if (checkW) 
                    {Console.Clear();
                    var nextWeap = weapon.SelectNextWeapon(nubWeap);
                    string wName = nextWeap.weapon;
                    string wDescrip = nextWeap.descrip;
                    int price = nextWeap.damage;

                    Console.WriteLine($"The next weapon for sale is: {wName}\nDescription: {wDescrip}\nDo you want to buy it for {price} gold?" +
                        $"(your current balance is {curGold})" +
                        $" 'y' or 'n'");
                    string buy = Console.ReadLine().ToLower();

                        if (buy == "y")
                        {
                            if (curGold >= price)
                            {
                                nubWeap += 1;
                                //numbRand = 0;
                                curGold -= price;
                                ranWeapSelect = false;
                                wepBuy = true;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Sorry you don't have enought gold.\n\nPress any button to return to the menu.");
                                Console.ReadKey(true);
                            }
                        }
                    }  
                    else { Console.Clear(); Console.WriteLine("You have the best there is to get.\nPress any key to return to the menu."); Console.ReadKey(true); }

                }
                else if (choice == "random")
                {
                    Console.Clear();

                    if (curGold >= 1)
                    {
                        Console.WriteLine("Note that there is only space for one random weapon at a time in your inventory. You will have to destroy any previously atained random weapons" +
                            " to get a new one.\nAre you ok with this? 'y' or 'n'");
                        string okDestroy = Console.ReadLine();
                        if (okDestroy == "y")
                        {                       
                            var rWeap = weapon.SelectRandom();
                            string randWep = rWeap.weapon;
                            string randD = rWeap.descrip;
                            curGold -= 1;
                            wepBuy = true;
                            Console.WriteLine($"You recieved and equiped {randWep}\ndescription: {randD}");
                            ranWeapSelect = true;
                            numbRand = weapon.GetRandWeapIndex(randWep);
                            Console.WriteLine("\n\nPress any key to return to menu.");
                            Console.ReadKey(true);
                        }
                        else { Console.WriteLine("Very well. (Press any button to return to the menu)"); Console.ReadKey(true);}
                    }
                    else
                    {
                        Console.WriteLine("Sorry you don't have enought gold.\n\nPress any button to return to the menu.");
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    wMenu = false;
                }
            }
            return (nubWeap, numbRand, curGold, ranWeapSelect, wepBuy);
        }

        public (int curArmor, int gold) EquipArmor(int aNumb, int pMoney)
        {
            int curArmor = aNumb;
            int gold = pMoney;
            //string reply = "null";
            bool aMenu = true;
            
            while (aMenu)
            {Console.Clear();
            Console.WriteLine("I should warn you that the shop is poor itself.\nIn order to see better armor you must spend" +
                "money so they can aford to get a more powerful armor.\nYou have a few options to choose from");
            Console.WriteLine("• Check out next available Armor option (type 'check')\n• Go back (type 'back')");
            string armorCheck = Console.ReadLine().ToLower();

                if (armorCheck == "check")
                {
                    Console.Clear();
                    var aTest = armor.checkMoreArmor(curArmor);
                    if (aTest == true)
                    {
                    var nextArmor = armor.SelectNextArmor(curArmor);
                    string aName = nextArmor.armor;
                    string aDec = nextArmor.descrip;
                    int price = nextArmor.bonus;
                    
                        Console.WriteLine($"Your next armor choice is: {aName}\nDescription: {aDec}\nPrice: {price} gold");
                    Console.WriteLine($"\nWould you like to purchase {aName} 'y' or 'n'");
                    string buy = Console.ReadLine().ToLower();

                        if (buy == "y")
                        {
                            if (gold >= price)
                            { curArmor += 1; gold -= price; }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Sorry you don't have enought gold.\n\nPress any button to return to the menu.");
                                Console.ReadKey(true);
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("There is nothing better than what you already possess.\nPress any button to return to the menu");
                        Console.ReadKey(true);
                    }



                }
                else { aMenu = false; }
            }
            return (curArmor, gold);
        }

        public void firstFight(string pName)
        {
            Console.Clear();
            Console.WriteLine("I wish you the best of luck. I wish I could give you more aid but my resources are limited. I can offer you this however...\n\n\n");
            Console.WriteLine(
                @"

|               |
|               |
|               |
\               /
 \             /
  \____  _____/  
       (O)
    .-'''''-.
  .'    *    `.
 :     * *     :
: * * *   * * * :
:  *         *  :
 :  *   *   *  :
  `.  *   *  .'
    `-.....-'");
            Console.WriteLine("\n\n(press any button to take medallion)");
            Console.ReadKey(true );
            Console.Clear();
            Console.WriteLine("You take the medallion and can feel the power held within.\n\nActivate that when you wish to return, but be warned" +
                $" I can not summon you back when you are engaged in combat. \nI dare not risk accidently bringing a monster back with you. Good luck {pName}!" +
                $"\n\n(press any key to bid farewell to the wizard.)");
            Console.ReadKey(true);
        }
    }
}





