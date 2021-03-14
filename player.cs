using System.Collections.Generic;

namespace A3_TextAdventure
{
    public class player: IAttackable
    {
        public int health { get; set; }

        public int gold { get; set; }

        public List<item> Bag { get; set; }

        public int point { get; set; }
        public bool IsDestroyed { get ; set; }
        
    }
}
