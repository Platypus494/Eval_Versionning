using Pkmn;
using NUnit.Framework;
using System;
namespace Pkmn.Tests
{
    public class FightMoreTests
    {
        // Tu as probablement remarqué qu'il y a encore beaucoup de code qui n'a pas été testé ...
        // À présent c'est à toi de créer des features et les TU sur le reste du projet

        // Ce que tu peux ajouter:
        // - Ajouter davantage de sécurité sur les tests apportés
        // - un heal ne régénère pas plus que les HP Max
        // - si on abaisse les HPMax les HP courant doivent suivre si c'est au dessus de la nouvelle valeur
        // - ajouter un equipement qui rend les attaques prioritaires puis l'enlever et voir que l'attaque n'est plus prioritaire etc)
        // - Le support des status (sleep et burn) qui font des effets à la fin du tour et/ou empeche le pkmn d'agir
        // - Gérer la notion de force/faiblesse avec les différentes attaques à disposition (skills.cs)
        // - Cumuler les force/faiblesses en ajoutant un type pour l'équipement qui rendrait plus sensible/résistant à un type
        // - L'utilisation d'objets : Potion, SuperPotion, Vitess+, Attack+ etc.
        // - Gérer les PP (limite du nombre d'utilisation) d'une attaque,
        // si on selectionne une attack qui a 0 PP on inflige 0

        // Choisis ce que tu veux ajouter comme feature et fait en au max.
        // Les nouveaux TU doivent être dans ce fichier.
        // Modifiant des features il est possible que certaines valeurs
        // des TU précédentes ne matchent plus, tu as le droit de réadapter les valeurs
        // de ces anciens TU pour ta nouvelle situation.

        [Test]
        public void GreatDefenseCannotHeal()
        {
            var pikachu = new Character(100, 50, 100, 20, TYPE.NORMAL);
            var punch = new Punch();
            var oldHealth = pikachu.CurrentHealth;

            pikachu.ReceiveAttack(punch);
            Assert.That(pikachu.CurrentHealth,
                Is.EqualTo(oldHealth)); // 100 and not 130 due to the attack value being negative
            Assert.That(pikachu.CurrentStatus, Is.EqualTo(null));
            Assert.That(pikachu.IsAlive, Is.EqualTo(true));
        }

        [Test]
        public void FightWithOneShotAndPriorityTurn()
        {
            Character pikachu = new Character(10000, 50, 30, 20, TYPE.NORMAL);
            var shield = new Equipment(0, 0, 10, 0,true);
            pikachu.Equip(shield);
            Character mewtwo = new Character(10, 500, 0, 200, TYPE.NORMAL);
            Fight f = new Fight(pikachu, mewtwo);
            Punch p = new Punch();
            MegaPunch mp = new MegaPunch();

            f.ExecuteTurn(p, mp);

            Assert.That(pikachu.IsAlive, Is.EqualTo(true));
            Assert.That(mewtwo.IsAlive, Is.EqualTo(false));
            Assert.That(pikachu.CurrentHealth, Is.EqualTo(pikachu.MaxHealth));
            Assert.That(f.IsFightFinished, Is.EqualTo(true));
        }

        [Test]
        public void RemovePriorityEquipement()
        {
            Character pikachu = new Character(10000, 50, 30, 20, TYPE.NORMAL);
            var shield = new Equipment(0, 0, 10, 0, true);
            pikachu.Equip(shield);
            Character mewtwo = new Character(100, 500, 0, 200, TYPE.NORMAL);
            Fight f = new Fight(pikachu, mewtwo);
            Punch p = new Punch();
            MegaPunch mp = new MegaPunch();
            pikachu.Unequip();
            f.ExecuteTurn(p, mp);

            Assert.That(pikachu.IsAlive, Is.EqualTo(true));
            Assert.That(mewtwo.IsAlive, Is.EqualTo(true));
            Assert.That(f.IsFightFinished, Is.EqualTo(false));
        }

        [Test]
        public void EffectiveAttack()
        {
            Character pikachu = new Character(120, 0, 0, 20, TYPE.WATER);
            Character bulbizard = new Character(1000, 500, 0, 200, TYPE.GRASS);
            Fight f = new Fight(pikachu, bulbizard);
            Punch p = new Punch();
            MagicalGrass mp = new MagicalGrass();

            f.ExecuteTurn(p, mp);

            Assert.That(pikachu.IsAlive, Is.EqualTo(false));//I changed magical grass to do 100 damage since its effective it should kill pikachu (no pikachu were harm)
            Assert.That(bulbizard.IsAlive, Is.EqualTo(true));
            Assert.That(f.IsFightFinished, Is.EqualTo(true));
        }

        [Test]
        public void ResistAttack()
        {
            Character pikachu = new Character(100, 0, 0, 20, TYPE.GRASS);
            Character bulbizard = new Character(1000, 500, 0, 200, TYPE.WATER);
            Fight f = new Fight(pikachu, bulbizard);
            Punch p = new Punch();
            WaterBlouBlou mp = new WaterBlouBlou(); //perfect name

            f.ExecuteTurn(p, mp);

            Assert.That(pikachu.CurrentHealth,
                Is.EqualTo(20));// same logic here pickachu should have 20 health left 
            Assert.That(bulbizard.IsAlive, Is.EqualTo(true));
            Assert.That(f.IsFightFinished, Is.EqualTo(false));
        }

        /*[Test]
        public void Burn()
        {
            Character pikachu = new Character(1, 0, 0, 20, TYPE.GRASS);
            Character bulbizard = new Character(1000, 500, 100000, 200, TYPE.WATER);
            Fight f = new Fight(pikachu, bulbizard);
            Punch p = new Punch();
            FireBall mp = new FireBall(); 

            f.ExecuteTurn(p, mp);

            Assert.That(pikachu.IsAlive, Is.EqualTo(false));
            Assert.That(f.IsFightFinished, Is.EqualTo(true));
        }*/
    }
}
