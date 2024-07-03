using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Adventure.Classes
{
    public class BattleSystem
    {
            bool attacker= true;
            int Level = 1;
            int Demage = 0;
            int xp = 0;
             public bool Test = false;  // For the Test
          //Created by mustafa and muhammad
        public void StartBattle(Player player , ClsMonster monster)
        {
            if (!Test)
            {
                monster.ChooseLevel();
            }
            do
            {
                if (!attacker)

                {
                    if (Test)
                    {
                        return;
                    }
                    Console.WriteLine("you win");
                    Console.WriteLine("DO you want to :(yes / no) ");
                    string rep = Console.ReadLine();
                    if(rep  == "yes")
                    {
                        Repeate ( ref player,ref monster);
                        continue;
                    }
                    else
                    {
                        return;
                    }
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


        }
        public void Attack(ref Player player, ref ClsMonster monster) {
            Thread.Sleep(300);
            player.AttackPower = GetAttackPowerPlayer();
            Console.WriteLine($"your Attack Power is {player.AttackPower}");
            Demage += player.AttackPower; 
            monster.Health -= player.AttackPower;
            if (monster.Health > 0)
            { 

                PrintInfo(player, monster);
            }else
            {
                monster.Health = 0; 
                PrintInfo(player, monster);
                attacker = false;
            }

        }
        public void Attack(ref ClsMonster monster, ref Player player)
        {
            Thread.Sleep(300);

            monster.AttackPower = GetAttackPowerMonster(monster);
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
        public int GetAttackPowerMonster(ClsMonster monster)
        {
            Random random = new Random();
            int AttackValue;
            if ((int)monster.selectedLevel == 3)
            {
                AttackValue = (random.Next(15, 20));
            }
            else if ((int)monster.selectedLevel == 2)
            {
                AttackValue = (random.Next(10, 19));
            }
            else
            {
                AttackValue = (random.Next(7, 15));
            }
            return AttackValue;

        }
        public void PrintInfo(Player player  , ClsMonster monster) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{player.Name } Health is {player.Health} , And Defense is {player.Defense}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{monster.Name} Health is {monster.Health}");

            Console.ResetColor();

        }
        public void Repeate(ref Player player,ref ClsMonster monster)
        {
            
            player.Health = (int)((player.Health + (Demage / 3)) * 1.3) ;
            if (player.Health > 100) {
                player.Health = 100;
            }
            player.Defense  += 5 * ++Level;
            Demage = 0;
            Console.WriteLine($" your Level is {Level} \n and Health is{player.Health } and the Defense is {player.Defense }");
            
            Console.WriteLine($"\n and Yur Defense is {player.Defense}");
            monster.Health = 100;
            attacker = true;
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
