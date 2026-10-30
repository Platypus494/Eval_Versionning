using System;

namespace Pkmn
{
    /// <summary>
    /// Définition d'un personnage
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Stat de base, HP
        /// </summary>
        int _baseHealth;
        /// <summary>
        /// Stat de base, ATK
        /// </summary>
        int _baseAttack;
        /// <summary>
        /// Stat de base, DEF
        /// </summary>
        int _baseDefense;
        /// <summary>
        /// Stat de base, SPE
        /// </summary>
        int _baseSpeed;
        /// <summary>
        /// Type de base
        /// </summary>
        TYPE _baseType;

        public Character(int baseHealth, int baseAttack, int baseDefense, int baseSpeed, TYPE baseType)
        {
            _baseHealth = baseHealth;
            _baseAttack = baseAttack;
            _baseDefense = baseDefense;
            _baseSpeed = baseSpeed;
            _baseType = baseType;
            CurrentHealth = baseHealth;
            IsAlive = true;
        }
        /// <summary>
        /// HP actuel du personnage
        /// </summary>
        public int CurrentHealth { get; private set; }
        public TYPE BaseType { get => _baseType;}
        /// <summary>
        /// HPMax, prendre en compte base et equipement potentiel
        /// </summary>
        public int MaxHealth
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return _baseHealth + CurrentEquipment.BonusHealth;
                }
                return _baseHealth ;
            }
        }
        /// <summary>
        /// ATK, prendre en compte base et equipement potentiel
        /// </summary>
        public int Attack
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return _baseAttack + CurrentEquipment.BonusAttack;
                }
                return _baseAttack;
            }
        }
        /// <summary>
        /// DEF, prendre en compte base et equipement potentiel
        /// </summary>
        public int Defense
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return _baseDefense + CurrentEquipment.BonusDefense;
                }
                return _baseDefense;
            }
        }
        /// <summary>
        /// SPE, prendre en compte base et equipement potentiel
        /// </summary>
        public int Speed
        {
            get
            {
                if (CurrentEquipment != null)
                {
                    return _baseSpeed + CurrentEquipment.BonusSpeed;
                }
                return _baseSpeed;
            }
        }
        /// <summary>
        /// Equipement unique du personnage
        /// </summary>
        public Equipment CurrentEquipment { get; private set; }
        /// <summary>
        /// null si pas de status
        /// </summary>
        public StatusEffect CurrentStatus { get; private set; }

        public bool IsAlive{ get; private set; }


        /// <summary>
        /// Application d'un skill contre le personnage
        /// On pourrait potentiellement avoir besoin de connaitre le personnage attaquant,
        /// Vous pouvez adapter au besoin
        /// </summary>
        /// <param name="s">skill attaquant</param>
        /// <exception cref="NotImplementedException"></exception>
        public void ReceiveAttack(Skill s)
        {
            if (Defense < s.Power)
            {
                int attack = s.Power - Defense;
                CurrentHealth -= (int)(attack * TypeResolver.GetFactor(s.Type, BaseType));
                if (CurrentHealth <= 0)
                {
                    CurrentHealth = 0;
                    IsAlive = false;
                }
            }
            if (s.Status != StatusPotential.NONE && CurrentStatus == null)
            {
                if (s.Status == StatusPotential.SLEEP)
                {
                    CurrentStatus =new SleepStatus();
                }
                if( s.Status == StatusPotential.BURN)
                {
                    CurrentStatus = new BurnStatus();
                }
            }
        }
        /// <summary>
        /// Equipe un objet au personnage
        /// </summary>
        /// <param name="newEquipment">equipement a appliquer</param>
        /// <exception cref="ArgumentNullException">Si equipement est null</exception>
        public void Equip(Equipment newEquipment)
        {
            if (newEquipment == null)
            {
                throw new ArgumentNullException("dear dev the equipment that you want to add is null");
            }
            CurrentEquipment = newEquipment;
        }
        /// <summary>
        /// Desequipe l'objet en cours au personnage
        /// </summary>
        public void Unequip()
        {
            CurrentEquipment = null;
        }

        public bool HasPriority()
        {
            if (CurrentEquipment != null)
            {
                return CurrentEquipment.HasPriority;
            }
            else
            {
                return false;
            }
        }

        public void DamageOverTime(int DamageOverTime)
        {
            if (DamageOverTime < 0)
            {
                throw new ArgumentException("...");
            }
            CurrentHealth -= DamageOverTime;
            if (CurrentHealth <= 0) {
                CurrentHealth = 0;
                IsAlive = false;
            }
        }
    }
}
