using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        List<Monster> lsMonstoer { get; set; }
        List<string> lsLocations = new List<string> { "Forest", "Town", "Caves", "Mines", "Demonic Deserts" };
       
        List<string> lsLocation = new List<string> { "Forest", "Town", "Caves", "Mines", "Demonic Deserts" };
        List<Monster> lsMonsterThatChoosen = new List<Monster>();
        
        List<string> lsLocationsThatChoosen =new List<string>();
        string LocationName = "";

        public Adventures()
        {
            // this.player = player;
            lsMonstoer = new List<Monster>();
            battleSystem = new BattleSystem();
        }

        public void MonsterChoice()
        {
            string[] MonsterNmae = { "Zompie", "Hydra ", " Orc  ", "Golem ", "Dragon" };

            var HealthLevel = 1;
            var MOnsterAttackPower = 1;
            for (int i = 0; i < 5; i++)
            {

              //  HealthLevel = 45 * (i + 1);
              HealthLevel = 5 * (i + 1);


                if (i == 4)
                {
                  //   MOnsterAttackPower = (i + 1) * 9;
                    MOnsterAttackPower = (i + 1) * 2;

                    BossMonster BossMonster = new BossMonster($"{MonsterNmae[i]}", HealthLevel, MOnsterAttackPower);
                    lsMonstoer.Add(BossMonster);
                }
                else
                {
                 // MOnsterAttackPower = (i + 1) * 4;
                  MOnsterAttackPower = (i + 1) * 2;

                    ClsMonster monster = new ClsMonster($"{MonsterNmae[i]}", HealthLevel, MOnsterAttackPower

                        );
                    lsMonstoer.Add(monster);
                }

            }


        }
        public int ChoiceRandomlyLocation()
        {
            int IndexLocation = 0;
            Random random = new Random();

            IndexLocation = random.Next(0, 5);

            while(isLocatinChoosen(lsLocations[IndexLocation]))
            {
                IndexLocation = random.Next(0, 5);
            }

            lsLocationsThatChoosen.Add(lsLocations[IndexLocation]);
           
            return IndexLocation;
        }
        public bool isMonsterChoosen(Monster Monster)
        {
            for (int i = 0; i < lsLocationsThatChoosen.Count; i++)
            {
                if (lsMonsterThatChoosen[i].Name==Monster.Name)
                {
                    return true;
                }

            }
            return false;

        }
        public int ChoiceRandomlyMonster()
        {
            int IndexMonster = 0;
            Random random = new Random();

            IndexMonster = random.Next(0, 5);

            while (isMonsterChoosen(lsMonstoer[IndexMonster]))
            {
                IndexMonster = random.Next(0, 5);
            }

            lsMonsterThatChoosen.Add(lsMonstoer[IndexMonster]);

            return IndexMonster;
        }
        public bool isLocatinChoosen(string LocationName)
        {
            for (int i = 0; i < lsLocationsThatChoosen.Count; i++)
            {
                if (lsLocationsThatChoosen[i] == LocationName)
                {
                    return true;
                }

            }
            return false;   
              
        }
        public bool CheckValidInput()
        {
            string playerChoice;
            bool validInput = false;

            while (!validInput)
            {

                playerChoice = Console.ReadLine().ToLower();

                if (playerChoice == "yes" || playerChoice == "no" )
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            return validInput;
        }


        public void StartGame(Player player)
        {
            //it Edited!
            MonsterChoice();
            while (player.Health > 0)
            {
                  // ClsMonster cmonster =new ClsMonster("dfh",100,12);
                  Monster monster = lsMonstoer[ChoiceRandomlyMonster()];
                

                //string LocationName = lsLocations[ChoiceRandomlyLocation()];
                //if (monster.Health == 0) continue;
                //ChoiceLocation();
                //bool CheckLocation = isLocatinChoosen(LocationName);
                int index = ChoiceRandomlyLocation();
                LocationName =lsLocations[index];
                //CheckLocation = isLocatinChoosen(LocationName);
             
              
                Console.WriteLine();
                Console.WriteLine("\t┌────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine($"\t│                {player.Name}          &         {monster.Name}" + "                   │ ");
                Console.WriteLine("\t└────────────────────────────────────────────────────────────────────┘");
                Console.WriteLine($"                          Location      {LocationName}\n");
                Console.WriteLine("Press any think to start the game ");
                Console.ReadKey();

                //MonsterChoice();
                // while(player.Health > 0)  {
                //   Monster monster =  lsMonstoer[ChoiceRandomlyLocation()];
                //    if (monster.Health == 0) continue;
                //    ChoiceLocation();       
                //    Console.WriteLine();
                //    Console.WriteLine("\t┌────────────────────────────────────────────────────────────────────┐");
                //    Console.WriteLine($"\t│                {player.Name}          &         {monster.Name}" + "                   │ "); 
                //    Console.WriteLine("\t└────────────────────────────────────────────────────────────────────┘");
                //    Console.WriteLine($"                          Location      {CurrentLocation}");
                //    Console.WriteLine("Press any think to start the game ");
                //    Console.ReadKey();
                bool IsWin = battleSystem.StartBattle(ref player, ref monster);
                if (IsWin && Level<5)
                {
                    Console.WriteLine("You win");
                    CompleteGame(ref player);
                    Console.WriteLine("DO you want to Complete the Game:(yes / no) ");
                    if (CheckValidInput())
                    {
                        continue;
                    }
                    else
                    {
                        return;
                    }

                    //if (rep == "yes")
                    //{
                    //    continue;

                    //}
                    //else
                    //{
                    //    return;
                    //}
                }
                else
                {
                    return;
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


            //List<string> lsLocations = new List<string> { "Forest", "Town", "Caves", "Mines", "Demonic Deserts" };
            Console.Write("{");
            for (int i = 0; i < lsLocations.Count; i++)
            {

                Console.Write($"{lsLocations[i]} = {i + 1} ,");
            }
            Console.WriteLine("}");
            int Choicecurrent = Convert.ToInt16(Console.ReadLine());
            CurrentLocation = lsLocations[Choicecurrent - 1];


        }

    }
}

   

