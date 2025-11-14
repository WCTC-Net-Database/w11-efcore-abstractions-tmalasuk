using ConsoleRpgEntities.Models.Attributes;

namespace ConsoleRpgEntities.Models.Characters.Monsters
{
    public class Goblin : Monster
    {
        public int Sneakiness { get; set; }

        

        public override void Attack(ITargetable target)
        {
            if (target is Player player)
            {
                player.Defend(this);
            }
        }
    }
}
