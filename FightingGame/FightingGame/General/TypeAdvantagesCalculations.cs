using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class TypeAdvantagesCalculations
    {
        public int checkNormalMove(Elements element, int adventageNumber)
        {
            //checks if adventage/disadventage/nullify has already been used
            bool hasNoCalcYet = true;

            //adventage calculation
            if (element == Elements.Ki || element == Elements.Fire)
            {
                adventageNumber = adventageNumber * 2;
                hasNoCalcYet = false;
            }

            //disadventage calculation
            if (element == Elements.Normal)
            {
                adventageNumber = adventageNumber / 2;
                hasNoCalcYet = false;
            }

            //nullify calculation
            if (element == Elements.Bug)
            {
                adventageNumber = 0;
                //isNullified = true;
                hasNoCalcYet = false;
            }

            //if none of the above
            if (hasNoCalcYet == true)
            {
                adventageNumber = adventageNumber + (adventageNumber / 2);
            }

            //return new number
            return adventageNumber;
        }

        public int checkFightingMove(Elements element, int adventageNumber)
        {
            ////checks if adventage/disadventage/nullify has already been used
            //bool hasNoCalcYet = true;

            ////adventage calculation
            //if (element == Elements.Ki || element == Elements.Fire)
            //{
            //    adventageNumber = adventageNumber + 2;
            //    hasNoCalcYet = false;
            //}

            ////disadventage calculation
            //if (element == Elements.Normal)
            //{
            //    adventageNumber = adventageNumber - 2;
            //    hasNoCalcYet = false;
            //}

            ////nullify calculation
            //if (element == Elements.Bug)
            //{
            //    adventageNumber = 0;
            //    //isNullified = true;
            //    hasNoCalcYet = false;
            //}

            ////if none of the above
            //if (hasNoCalcYet == true)
            //{
            //    adventageNumber = adventageNumber + 1;
            //}

            ////return new number
            //return adventageNumber;
            return 0;
        }
    }
}
