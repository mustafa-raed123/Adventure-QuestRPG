using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Adventure.Classes.Monster;
using static System.Net.Mime.MediaTypeNames;
using static System.Reflection.Metadata.BlobBuilder;

namespace Adventure.Classes
{
    public class Adventures
    {
        string CurrentLocation;
      //  Player player;
        BattleSystem battleSystem;

        public int Level = 1;
        List<Monster> Lsmonsters { get; set; }
        
        public Adventures()
        {
           // this.player = player;
            Lsmonsters = new List<Monster> ();
            battleSystem = new BattleSystem();
        }

        public void MonsterChoice()
        {
            string[] MonsterNmae = { "Zompie", "Hydra ", " Orc  ", "Golem ", "Dragon" };
            
            var HealthLevel  = 1; 
            var MOnsterAttackPower  = 1;
            for (int i = 0; i < 5 ; i++)
            {

                HealthLevel = 45 * (i + 1);
                

                if (i == 4)
                {
                    MOnsterAttackPower = (i + 1) * 9;
                    BossMonster BossMonster = new BossMonster($"{MonsterNmae[i]}", HealthLevel , MOnsterAttackPower);
                    Lsmonsters.Add(BossMonster);
                }
                else
                {
                    MOnsterAttackPower = (i + 1) * 4;
                    ClsMonster monster = new ClsMonster($"{MonsterNmae[i]}", HealthLevel, MOnsterAttackPower
                        
                        );
                    Lsmonsters.Add(monster);


                }
                
            }


        }
        public int ChoiceRandomlyMonster()
        {
            Random random = new Random();
            
            return random.Next(0, 5);
        }

        public void StartGame( Player player )
        {
            MonsterChoice();
             while(player.Health > 0)  {
               Monster monster =  Lsmonsters[ChoiceRandomlyMonster()];
                if (monster.Health == 0) continue;
                ChoiceLocation();       
                Console.WriteLine();
                Console.WriteLine("\t┌────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine($"\t│                {player.Name}          &         {monster.Name}" + "                   │ "); 
                Console.WriteLine("\t└────────────────────────────────────────────────────────────────────┘");
                Console.WriteLine($"                          Location      {CurrentLocation}");
                Console.WriteLine("Press any think to start the game ");
                Console.ReadKey();
                bool IsWin = battleSystem.StartBattle(ref player, ref monster);
                if (IsWin)
                {
                    Console.WriteLine("You win");
                    CompleteGame(ref player);
                     Console.WriteLine("DO you want to Complete the Game:(yes / no) ");
                    string rep = Console.ReadLine();
                    if (rep == "yes")
                    {
                        continue; 
                        
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
        public void CompleteGame(ref Player player)
        {
            player.xp += 200;             
                player.Health = 100;           
            player.Defense += 10 * ++Level;          
            Console.WriteLine($" your Level up to {Level} \n and Health is{player.Health} and the Defense is {player.Defense}");         
            Console.WriteLine($"\n and Yur Defense is {player.Defense}");           
        }
        public void ChoiceLocation()
        {
            Console.WriteLine("IN Which Location Do you Want to Play:   ");


            List<string> location = new List<string> { "Forest", "Town", "Caves", "Mines", "Demonic Deserts" };
            Console.Write("{");
            for (int i = 0; i < location.Count; i++) {

                Console.Write ($"{location[i]} = {i+1} ,");
            }
            Console.WriteLine("}");
            int Choicecurrent = Convert.ToInt16(Console.ReadLine());
            CurrentLocation = location[Choicecurrent - 1];




        }

    }
}
