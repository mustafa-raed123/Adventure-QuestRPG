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
        int Location;
        public int Level {  get; set; }
        List<Monster> Lsmonsters { get; set; }
        
        public Adventures()
        {
            Lsmonsters = new List<Monster> ();
        }

        public void MonsterChoice()
        {
            var HealthLevel  = 1; 
            for (int i = 1; i <= 5 ; i++)
            {

                HealthLevel = 50 * i;
                if (i == 5)
                {
                    BossMonster BossMonster = new BossMonster($"BossMonster", HealthLevel);
                    Lsmonsters.Add(BossMonster);
                }
                else
                {
                    ClsMonster monster = new ClsMonster($"Monster{i}", HealthLevel);
                    Lsmonsters.Add(monster);
                }
                
            }


        }
        public int ChoiceRandomlyMonster()
        {
            Random random = new Random();
            
            return random.Next(0, 5);
        }

        public void StartGame()
        {
            Monster monster =  Lsmonsters[ChoiceRandomlyMonster()];
            for (int i = 0; i < Lsmonsters.Count; i++)
            {


            }
        }
        public void CompleteBattle(ref Player player, ref ClsMonster monster)
        {
            int Demage = 0;
            player.Health = (int)((player.Health + (Demage / 3)) * 1.3);
            if (player.Health > 100)
            {
                player.Health = 100;
            }
            player.Defense += 5 * ++Level;
            Demage = 0;
            Console.WriteLine($" your Level is {Level} \n and Health is{player.Health} and the Defense is {player.Defense}");
            DefensePlayer(ref player);
            Console.WriteLine($"\n and Yur Defense is {player.Defense}");
            monster.Health = 100;
            attacker = true;
        }
        public void ChoiceLocation()
        {
            List<string> location = new List<string> { "Forest","Town" ,  };


            
        }

    }
}
