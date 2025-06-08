using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame
{
    public class CharacterForms
    {
        public bool hasAlternatives;
        public int ableToEvolveFromThisLevel; //this is the level from which the character is able to evolve into next character

        public CharacterForms(int ableEvolutionLevel, bool hasAlternatives)
        {
            this.ableToEvolveFromThisLevel = ableEvolutionLevel;
            this.hasAlternatives = hasAlternatives;

            //the allowedAlternativeForms is a list that contains all the alternative forms this character could posses
            //this.allowedForms = allowedAlternativeForms;
        }
    }
}
