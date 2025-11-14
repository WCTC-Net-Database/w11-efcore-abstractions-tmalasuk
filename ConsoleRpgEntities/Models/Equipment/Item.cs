using ConsoleRpgEntities.Models.Characters;




namespace ConsoleRpgEntities.Models.Equipment;
public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
     public virtual Player? Owner { get; set; } //made it so only one player can have the item

    override public string ToString()
        {
            return $"{Name} (Id: {Id}): {Description}";
        }
    }

    public class Weapon : Item
    {
        public int Damage { get; set; }

    }

    public class Armor : Item
    {
        public int Defense { get; set; }
    }
