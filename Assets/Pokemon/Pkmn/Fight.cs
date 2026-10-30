
using NUnit.Framework.Internal.Filters;
using System;
using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace Pkmn
{
    public class Fight
    {
        public Fight(Character character1, Character character2)
        {
            if(character1 == null || character2 == null)
            {
                throw new ArgumentNullException("Dear dev you cannot fight a null pokemon");
            }
            Character1 = character1;
            Character2 = character2;
            IsFightFinished = false;
        }

        public Character Character1 { get; }
        public Character Character2 { get; }
        /// <summary>
        /// Est-ce la condition de victoire/défaite a été rencontré ?
        /// </summary>
        public bool IsFightFinished { get; private set; }

        /// <summary>
        /// Jouer l'enchainement des attaques. Attention à bien gérer l'ordre des attaques par apport à la speed des personnages
        /// </summary>
        /// <param name="skillFromCharacter1">L'attaque selectionné par le joueur 1</param>
        /// <param name="skillFromCharacter2">L'attaque selectionné par le joueur 2</param>
        /// <exception cref="ArgumentNullException">si une des deux attaques est null</exception>
        public void ExecuteTurn(Skill skillFromCharacter1, Skill skillFromCharacter2)
        {
            Character first = Character1;
            Character second = Character2;
            Skill firstSkill = skillFromCharacter1;
            Skill secondSkill = skillFromCharacter2;
            bool test = Character2.HasPriority();
            bool test1 = Character1.HasPriority();

            if ((Character2.HasPriority() && !Character1.HasPriority()) || 
                (!Character2.HasPriority() && !Character1.HasPriority() && Character2.Speed> Character1.Speed) 
                || (Character2.HasPriority() && Character1.HasPriority() && Character2.Speed > Character1.Speed))
            {
                first = Character2;
                second = Character1;
                firstSkill = skillFromCharacter2;
                secondSkill = skillFromCharacter1;
            }
                
                second.ReceiveAttack(firstSkill);
                if (second.CurrentHealth <= 0)
                {
                    IsFightFinished = true;
                    return;
                }
            first.ReceiveAttack(secondSkill);
            if (first.CurrentHealth <= 0)
            {
                IsFightFinished = true;
            }
            /*if(first.CurrentStatus !=null)
            {
                first.DamageOverTime(first.CurrentStatus.DamageEachTurn);
                first.CurrentStatus.EndTurn();
            }

            if (second.CurrentStatus != null)
            {
                second.DamageOverTime(first.CurrentStatus.DamageEachTurn);
                second.CurrentStatus.EndTurn();
            }*/

        }

    }
}
