using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Adventure.Classes.Monster;
using static System.Net.Mime.MediaTypeNames;

namespace Adventure.Classes
{
    public class BattleSystem
    {
        Inventory inventory = new Inventory();
        bool attacker= true;
            int Level  = 0;
            
            int xp  = 0;
             public bool Test = false;  // For the Test
            bool  IsWin = false;
          List<string>lsPlayerInventory = new List<string>();
          
        public bool StartBattle(ref IBattleStates player, ref IBattleStates monster)
        {
            inventory.CheckUseItems(ref player);
            Console.WriteLine("Press any think to start the game ");
            Console.ReadKey();
            do
            {
                if (!attacker)

                {
                    if (Test)
                    {
                        return true;
                    }
                    attacker = true;
                    return true;
                   
                }
                if (attacker) {
                   
                    Console.WriteLine($"{player.Name} Turn: ");
                    
                    Attack( ref player ,ref monster);

                }
                if(attacker)
                {
                    
                    Console.WriteLine($"{monster.Name} Turn: ");
                    
                    
                    Attack(ref monster, ref player);

                }
                if(monster.Health == 0)
                {
                    if (RandomItem())
                    {
                        InventoryPlayer();
                    }
                }
               
               
            } while (player.Health > 0);

            return false;
        }

        public bool RandomItem()
        {
            Random random = new Random();
            int Item=random.Next(1,40);
            return Item<=20;

        }
        public void Attack(ref IBattleStates Attacker, ref IBattleStates Target) {
            Console.WriteLine($" Attack Power is {Attacker.AttackPower}");
            
            ReduceHealthTarget(ref Attacker, ref Target,Attacker.AttackPower);
            if (Target.Health > 0)
            {
                PrintInfo(Attacker, Target);
                Console.WriteLine("------------------------------");
            }
            else
            {
                Target.Health = 0;
                PrintInfo(Attacker, Target);
                attacker = false;                
            }
        }
        public void PrintInfo(IBattleStates Attacker  , IBattleStates Target) {
            
            Console.WriteLine($"{Attacker.Name } Health is {Attacker.Health} , And Defense is {Attacker.Defense}");
            
            Console.WriteLine($"{Target.Name} Health is {Target.Health}");

            Console.ResetColor();

        }
        public void ReduceHealthTarget(ref IBattleStates Attacker , ref IBattleStates Target, int attackPower)
        {

            int damage = attackPower - (Target.Defense / 2);


            if (damage < 0) damage = 0;


            Target.Health -= damage;
            Target.Defense -= 5;
            Console.WriteLine($"{Attacker.Name} attacks with {attackPower} damage. {Target.Name} takes {damage} damage.");

            if (Target.Defense < 0) Target.Defense = 0;

        }
        public void InventoryPlayer()
        {
            List<Items> items = new List<Items> { Weapons() , Armor() , Potion() };

            

            inventory.AddInventory(items[RandomNum()]);



        }
        public Weapon Weapons()
        {
            Weapon weapon1 = new Weapon(25, "Sword", "A sharp weapon used in close combat. The sword can have one or two edges");
            Weapon weapon2 = new Weapon(30, "Axes", "A heavy weapon with a sharp metal head.");
            Weapon weapon3 = new Weapon(35, "Gun", "A firearm designed for rapid, automatic fire,\n capable of shooting multiple rounds per minute. Machine guns often come with a large magazine or belt-fed ammunition system");



            List<Weapon> weapons = new List<Weapon> { weapon1, weapon2, weapon3 };
            return weapons[RandomNum()];
            
        }
        public Armor Armor()
        {
            Armor armor1 = new Armor(20, "Light Armor", "Provides moderate protection against physical and magical attacks");
            Armor armor2 = new Armor(30, "Medium Armor", "Strikes a balance between protection and agility,\n providing moderate protection while maintaining some movement speed");
           
            Armor armor3 = new Armor(35, "Heavy Armor", "Offers very high protection against physical attacks but reduces character movement speed");

            List<Armor> weapons = new List<Armor> { armor1, armor2, armor3 };
            return weapons[RandomNum()];


        }
        public Potion Potion()
        {
           Potion  Potion1 = new Potion(35, "Minor Healing Potion", "Used to moderately restore health points (HP)");
           Potion Potion2 = new Potion(45, "Medium Healing Potion", "Provides significant improvement in healing, aiding recovery after more challenging encounters.");
           Potion Potion3 = new Potion(60, "Large Healing Potion", "Often the most effective potions for recovery after long battles or major fights");
          

            List<Potion> weapons = new List<Potion> { Potion1, Potion2, Potion3 };

            return weapons[RandomNum()];
        }
        public int RandomNum()
        {
            Random random = new Random();
            return random.Next(0, 3);

        }
    }
}
