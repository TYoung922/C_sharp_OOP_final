//Random random = new Random();
//int randomInt = random.Next(1, 20);
//Console.WriteLine(randomInt);
//Console.WriteLine(randomInt);
//Console.WriteLine(random.Next(1, 20));
//Console.WriteLine(random.Next(1, 20));

using System.Runtime.CompilerServices;
using System.Text;
using OOP_final;
using Character_class;
using Weapons_class;
using Armor_class;

Console.OutputEncoding = System.Text.Encoding.UTF8;

bool isOn = true;

Game game = new Game();
Weapons weapons = new Weapons();
Armor armor = new Armor();

bool charMade = false;
bool firstMenu = true;
bool fromFight = true;

//I have made some quick changes to show how things can progress. I have given myself enough money to by
//gear to level up my character to end game. Based of the level of the player's gear the code will randomly
// select a monster from a list of monsters who are equal or lower to their levl.

Player player = null;
//Player player = new Player("ty", 14, 12, 16);

Monster monster = new Monster("Monster");

Battle battle = new Battle();



bool firstFight = true;


while (isOn)
{
    if (!charMade)
    {
        var stats = game.StartGame();
        int strength = stats.str;
        int agility = stats.agil;
        int endurance = stats.endur;
        charMade = stats.charMade;
        string name = stats.name;

        player = new Player(name, strength, agility, endurance);
    }



    if (firstMenu)
    {
        Fire fire = new Fire();

        Thread animationThread = new Thread(fire.Start);
        animationThread.Start();

        // Stop animation when 'U' is pressed
        while (true)
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.U)
            {
                fire.Stop();
                animationThread.Join(); // Wait for the thread to finish
                break;
            }
        }

        Wizard wizard = new Wizard(player.Name);
        Thread wizardAnimate = new Thread(wizard.Start);
        wizardAnimate.Start();

        // Stop animation when 'U' is pressed
        while (true)
        {
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.U)
            {
                wizard.Stop();
                wizardAnimate.Join(); // Wait for the thread to finish
                break;
            }
        }
    }

    if (fromFight)
    {await game.MenuIntro(firstMenu);
        if (firstMenu == true) { firstMenu = false; }
        fromFight = false;
    }

    var menResult = game.Menu(player.gold, player.weaponLvl, player.armorLvl, player.ranWeap, player.ranWeapSelect);
    //player gold update
    player.gold = menResult.gold;

    //Player weapon update
    //Check if player bought new weapon
    if (player.weaponLvl < menResult.weap)
    {
        var getWeapInfo = weapons.getWeaponInfo(menResult.weap); //get the stats of the weapon
        player.weaponName = getWeapInfo.weapon;
        player.weapBonus = getWeapInfo.damage;
    }
    player.weaponLvl = menResult.weap;
    player.curWeapInd = menResult.weap;


    //Player amror update
    player.armorLvl = menResult.arm;
    var getArmInfo = armor.SelectArmor(player.armorLvl);
    player.armor = getArmInfo.armor;
    player.armorBonus = getArmInfo.bonus;
    player.heroAc += getArmInfo.ac;

    //Player random weapon update
    player.ranWeapSelect = menResult.ranSelect;
    player.ranWeap = menResult.rWeap;
    var getRanInfo = weapons.RandWepInfo(player.ranWeap);
    player.ranWeapName = getRanInfo.rWname;
    player.ranWeapBonus = getRanInfo.damage;
    
    
    bool fight = menResult.fight;
    bool exit = menResult.exit;
    bool view = menResult.view;
    bool inventory = menResult.inven;
    bool heal = menResult.heal;



    if (fight)
    {
        if (firstFight)
        {
            game.firstFight(player.Name);
            firstFight = false;
        }
        fromFight = true;
        player.SetGearLv();
        if (player.gearLv == 15)
        {
            monster.FaceDragon();
        }
        else
        {
            monster.SelectMonster(player.gearLv);
        }
        var encounter = battle.BattleMenu(monster, player);
        if (!encounter.playerAlive) {
            Console.Clear();
            Console.WriteLine("You Died...\n\n\n\nGame Over!");
            isOn = false; }
        if (encounter.DragonDead) 
        {
            Console.Clear();
            Console.WriteLine($"Well done {player.Name} you have slain the Alpha beast!\nYou will be forever sung" +
                $" as our hero. We can't thank you enough.\nWith the Alpha beast's power gone I can send you home." +
                $"\n\n(press any key to return home)");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine("The wizard waves his staff and there is a bright flash of light. " +
                "\nYou open your eyes to find you have returned home..." +
                "\n\n\nGame Over");
            isOn = false;
        }
    }
    else if (view == true)
    {
        fromFight = false;
        player.ViewStats();
    }
    else if (inventory)
    {
        fromFight = false;
        var weapSelect = weapons.weapInventory(player.weaponLvl, player.curWeapInd, player.ranWeap);
        if (weapSelect.selectRandom) { player.ranWeapSelect = true; }
        else 
        {
            player.ranWeapSelect = false;
            player.weaponName = weapons.getWeaponInfo(weapSelect.curWeapon).weapon;
            player.weapBonus = weapons.getWeaponInfo(weapSelect.curWeapon).damage;
        }
    }
    else if (heal) { player.HealMenu(); }
    else if (exit) { isOn = false; }


    //Console.WriteLine($"exit {exit}");

    

    

}









