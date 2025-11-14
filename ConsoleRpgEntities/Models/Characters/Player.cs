using ConsoleRpgEntities.Models.Abilities.PlayerAbilities;
using ConsoleRpgEntities.Models.Attributes;
using ConsoleRpgEntities.Models.Equipment;
using ConsoleRpgEntities.Models.Characters.Monsters;

namespace ConsoleRpgEntities.Models.Characters
{
    public class Player : ITargetable, IPlayer
    {
        public int Experience { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public virtual IEnumerable<Ability> Abilities { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public void Attack(ITargetable target)
        {
            // Player-specific attack logic
            foreach (var item in Items) {
                if (item is Weapon weapon)
                {
                    Console.WriteLine($"{Name} attacks {target.Name} with {weapon.Name} for {weapon.Damage}!");
                    if (target is Monster monster)
                    {
                        monster.Health -= weapon.Damage;
                        Console.WriteLine($"{monster.Name}'s health is now {monster.Health}.");
                    }
                    return;
                }
            }
        }

        public void Defend(Monster monster)
        {
            // Player-specific defend logic
            int totalDefense = 0;
            foreach (var item in Items)
            {
                if (item is Armor armor)
                {
                    totalDefense += armor.Defense;
                }
            }

            
            int? netDamage = monster.Power - totalDefense;


            Health -= netDamage > 0 ? netDamage.Value : 0;
            Console.WriteLine($"{Name} defends against {monster.Power} damage with {totalDefense} defense. Net damage taken: {netDamage}. Health is now {Health}.");
        }

        public void UseAbility(IAbility ability, ITargetable target)
        {
            if (Abilities.Contains(ability))
            {
                ability.Activate(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} does not have the ability {ability.Name}!");
            }
        }
    }
}
