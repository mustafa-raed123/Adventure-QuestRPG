using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Classes
{
    public abstract class Items
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Items(string name, string description)
        {
            Name = name;
            Description = description;
        }

    }

    public class Weapon:Items
    {

        public int Damage { get; set; }
        public int AttackSpeed { get; set; }

        public Weapon(int damage,int attackSpeed,string name,string description):base(name,description)
        {
            Damage = damage;
            AttackSpeed=attackSpeed;
            
        }
    }

    public class Armor:Items
    {
        public int DefenseRating { get; set; }

        public Armor(int DefenseRating, string name, string description) :base(name,description)
        {
            this.DefenseRating = DefenseRating;
        }
    }

    public class  Potion:Items
    {
        public int HealAmount { get; set; }

        public Potion(int healAmount,string name,string description):base (name,description) 
        {
            HealAmount = healAmount;    
        }
    }
}
