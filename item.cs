using System;

namespace A3_TextAdventure
{
    public class item
    {
        public string name { get; set; }

        public int value { get; set; }

        public string description { get; set; }

        public virtual string printText()
        {
            return $"{name}: ({value} gold) {description}";
        }
    }

    public class weapon : item, IWeapon
    {
    }

    public class canAttackedItem : item, IAttackable
    {
        public bool IsDestroyed { get ; set ; }

        public override string printText()
        {
            if (IsDestroyed)
            {
                this.value = 0;
                return $"A destroyed {name}, worth 0";
            } else
            {
                return $"{name}: ({value} gold) {description}";
            }
        }
    }
}
