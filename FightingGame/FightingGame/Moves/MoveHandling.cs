using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public abstract class MoveHandling
    {
        //maybe only use calculation methods here that return values
        public static int physicalAttack(Character attacker, Character attackee)
        {
            int attack = attacker.getAttackValue();
            int defence = attackee.getDefenceValue();

            if (attack > defence)
            {
                return attack - defence;
            }
            else
            {
                return 5;
            }
        }

        public static void Defend(Character self)
        {
            //change block to true(maybe instead of this just handle it in the BattleArena)
        }

        public static void Reflect(Character self)
        {
            //change block and reflect to true(maybe instead of this just handle it in the BattleArena)
        }

        public static void dealAllDamageAndLeaveEffects(Character attacker, Character attackee, List<Ailments> ailments)
        {
            //deal magic and physical attack and leave effect
        }

        public static void dealPhysicalDamageAndLeaveEffects(Character attacker, Character attackee, List<Ailments> ailments)
        {

        }

        public static void dealMagicalDamageAndLeaveEffects(Character attacker, Character attackee, List<Ailments> ailments)
        {

        }
    }
}
