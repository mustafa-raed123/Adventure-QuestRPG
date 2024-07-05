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
            bool attacker= true;
            int Level  = 0;
            int Demage = 0;
            int xp  = 0;
             public bool Test = false;  // For the Test
            bool  IsWin = false;
          List<string>lsPlayerInventory = new List<string>();
          //  Level selectedLevel;
        public bool StartBattle(ref Player player ,ref Monster monster)
        {
            //if (!Test)
            //{
            //    monster.ChooseLevel();
            //}
            
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
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{player.Name} Turn: ");
                    
                    Attack( ref player ,ref monster);

                }
                if(attacker)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{monster.Name} Turn: ");
                    
                    
                    Attack(ref monster, ref player);

                }
               
               
            } while (player.Health > 0);

            return false;
        }

        public bool RandomItem()
        {
            Random random = new Random();
            int Item=random.Next(1,100);
            return Item>0 && Item<=20;

        }
        public void Attack(ref Player player, ref Monster monster) {

            player.AttackPower = GetAttackPowerPlayer();
            Console.WriteLine($"your Attack Power is {player.AttackPower}");
            Demage += player.AttackPower; 
            monster.Health -= player.AttackPower;
            if (monster.Health > 0)
            {

                PrintInfo(player, monster);
            }
            else
            {
                //int ItemDroped=RandomItem();
                if(RandomItem())
                {
                    //determine the type of item and add it to lsPlayerInventory
                }
                monster.Health = 0;
                PrintInfo(player, monster);
                attacker = false;
            }

            //else 
            //{
            //    monster.Health = 0; 
            //    PrintInfo(player, monster);
            //    attacker = false;
            //}

        }
        public void Attack(ref Monster monster, ref Player player)
        {

            ReduceHealthPlayer(ref player, monster.AttackPower);
            if (player.Health > 0)
            {

                PrintInfo(player, monster);
            }
            else
            {
                player.Health = 0;
                PrintInfo(player, monster);
                attacker = false;
            }

        }
        public int GetAttackPowerPlayer( )
        {
            Random random = new Random();
            int AttackValue;
            return AttackValue = (random.Next(15, 20));

        }


        public void PrintInfo(Player player  , Monster monster) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.Name } Health is {player.Health} , And Defense is {player.Defense}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{monster.Name} Health is {monster.Health}");

            Console.ResetColor();

        }
 
      
      public void ReduceHealthPlayer(ref Player player, int attackMonster)
        {
            
            int damage = attackMonster - (player.Defense / 2);

            
            if (damage < 0) damage = 0;

            
            player.Health -= damage;
            player.Defense -= 5;
            Console.WriteLine($"Monster attacks with {attackMonster} damage. Player takes {damage} damage.");

            if (player.Defense < 0) player.Defense = 0;

        }
   



    }
}
