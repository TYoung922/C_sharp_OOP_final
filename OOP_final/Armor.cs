using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Armor_class
{
    public class Armor
    {
        string[] armorList = { "nothing", "Gambison", "Leather Armor", "Chain Mail", "Full Plate", "Enchanted Armor" };
        string[] armorDescrip = {"nothing", "A simple padded jacket. It won't do much but it is better than nothing.", "This is decent armor. It won't hold up against" +
                " strong enemies but it's better than just cloth.", "This armor made of interlocking medal rings is good quality. This should help protect " +
                "you against most foes.", "This is the absolute best you can get! This will keep you alive for some time.", "This stuning golden armor shines with" +
                "an inner light of power."};
        int[] armorBonus = { 0, 2, 4, 6, 8, 10 };
        int[] armorAc = { 0, 1, 2, 1, 1, 1 };

        public (string armor, string descrip, int bonus, int ac) SelectArmor(int aTurn)
        {
            int armorTurn = aTurn;
            string armor = armorList[armorTurn];
            string descrip = armorDescrip[armorTurn];
            int bonus = armorBonus[armorTurn];
            int ac = armorAc[armorTurn];
            return (armor, descrip, bonus, ac);
        }

        public (string armor, string descrip, int bonus) SelectNextArmor(int aTurn)
        {
            int armorTurn = aTurn;
            string armor = armorList[armorTurn + 1];
            string descrip = armorDescrip[armorTurn + 1];
            int bonus = armorBonus[armorTurn + 1];


            return (armor, descrip, bonus);
        }

        public bool checkMoreArmor(int aTurn)
        {
            int armorTurn = aTurn;

            if (armorTurn < armorList.Length - 1) { return true; }
            else { return false; }
        }
    }
}
