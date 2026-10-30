
namespace Pkmn
{
    /// <summary>
    /// Défintion simple d'un équipement apportant des boost de stats
    /// </summary>
    public class Equipment
    {
        public Equipment(int bonusHealth, int bonusAttack, int bonusDefense, int bonusSpeed)
        {
            BonusHealth = bonusHealth;
            BonusAttack = bonusAttack;
            BonusDefense = bonusDefense;
            BonusSpeed = bonusSpeed;
            HasPriority =false;
            
        }

        public Equipment(int bonusHealth, int bonusAttack, int bonusDefense, int bonusSpeed, bool priority)
        {
            BonusHealth = bonusHealth;
            BonusAttack = bonusAttack;
            BonusDefense = bonusDefense;
            BonusSpeed = bonusSpeed;
            HasPriority = priority;

        }

        public int BonusHealth { get; protected set; }
        public int BonusAttack { get; protected set; }
        public int BonusDefense { get; protected set; }
        public int BonusSpeed { get; protected set; }
        public bool HasPriority { get; protected set; }

    }
}
