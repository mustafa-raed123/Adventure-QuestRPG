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
        BattleSystem battleSystem;
        bool ForTestUnit = true;
        public int Level = 1;
        public List<Monster> lsMonstoer { get; set; }
        List<string> lsLocations = new List<string> { "Forest", "Town", "Caves", "Mines", "Demonic Deserts" };
        public string CurrentLocation = "Forest";
        List<Monster> lsMonsterThatChoosen = new List<Monster>(); 
        string LocationName = "";

        public Adventures()
        {
            lsMonstoer = new List<Monster>();
            battleSystem = new BattleSystem();
        }

        public void ChoiceMonster()
        {
            string[] MonsterNmae = { "Zompie", "Hydra ", " Orc  ", "Golem ", "Dragon" };

            var HealthLevel = 1;
            var MOnsterAttackPower = 1;
            for (int i = 0; i < MonsterNmae.Length; i++)
            {
                if (i == 4)
                {
                    
                    MOnsterAttackPower = (i + 2) * 4;
                    HealthLevel = 22 * (i + 9);
                    BossMonster BossMonster = new BossMonster($"{MonsterNmae[i]}", HealthLevel, MOnsterAttackPower);
                    lsMonstoer.Add(BossMonster);
                }
                else
                {
                     
                    HealthLevel = 15 * ((i+1) + 2);
                    MOnsterAttackPower = (i + 5) * 3;
                    ClsMonster monster = new ClsMonster($"{MonsterNmae[i]}", HealthLevel, MOnsterAttackPower);
                    lsMonstoer.Add(monster);
                }
            }
        }
        public bool isMonsterChoosen(Monster monster)
        {
            foreach (var chosenMonster in lsMonsterThatChoosen)
            {
                if (chosenMonster.Name == monster.Name)
                {
                    return true;
                }
            }
            return false;
        }
        public int ChoiceRandomlyMonster()
        {
            Random random = new Random();
            int indexMonster;

            do
            {
                indexMonster = random.Next(0, lsMonstoer.Count);
            } while (isMonsterChoosen(lsMonstoer[indexMonster]));

            lsMonsterThatChoosen.Add(lsMonstoer[indexMonster]);
            return indexMonster;
        }
        public bool CheckValidInput()
        {
            string playerChoice = "";
            bool validInput = false;
            bool IsConinue = false;

            while (!validInput)
            {

                playerChoice = Console.ReadLine().ToLower();

                if (playerChoice == "yes" || playerChoice == "no")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            if (playerChoice == "yes")
            {

                IsConinue = true;
            }
            else
            {
                IsConinue = false;
            }

            return IsConinue;
        }
        public void StartGame(Player player)
        {
            bool isContinue = true;
            ChoiceMonster();
            while (player.Health > 0 && isContinue)
            {

                Monster monster = lsMonstoer[ChoiceRandomlyMonster()];

                ChoiceLocation();
                Console.WriteLine();
                Console.WriteLine("\t┌────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine($"\t│                {player.Name}          &         {monster.Name}" + "                   │ ");
                Console.WriteLine("\t└────────────────────────────────────────────────────────────────────┘");
                Console.WriteLine($"                               Location        {CurrentLocation}\n");
               
                bool IsWin = battleSystem.StartBattle(ref player, ref monster);
                if (IsWin && Level < 5)
                {
                    Console.WriteLine("You win");
                    CompleteGame(ref player);

                    Console.WriteLine("DO you want to Complete the Game:(yes / no) ");
                     isContinue = CheckValidInput();                  
                } 
                else
                {
                    return;
                }
            }
        }
        public void CompleteGame(ref Player player)
        {
          
            player.Health += 20;
            if(player.Health > 100)
            {
                player.Health = 100;
            }
            
            Console.WriteLine($" and Your your Level up to {++Level} \n and Health is{player.Health}");
           
        }
        public void ChoiceLocation()
        {
            Console.WriteLine($"You are currently in {CurrentLocation}. Would you like to change your location? (Yes/No)");

            string ChoiseLocation = Console.ReadLine().ToLower();
            if(ChoiseLocation != "yes" && ChoiseLocation != "y")
            {
                return;
            }
            Console.WriteLine("Please enter the name of the location where you would like to play:");
            Console.Write("{");
            for (int i = 0; i < lsLocations.Count; i++)
            {

                Console.Write($"{lsLocations[i]} = {i + 1} ,");
            }
            Console.WriteLine("}");
            
            if (int.TryParse(Console.ReadLine(), out int ChoiceLocationINdex))
            {
                ChangeCurrrentLocation(ChoiceLocationINdex);
            }
            else
            {
                Console.WriteLine("Envalid Input ");
                return;
            }


        }
        public void ChangeCurrrentLocation(int Choicecurrent)
        {
            if (Choicecurrent <= 0 || Choicecurrent > lsLocations.Count)
            {
                Console.WriteLine("Envalid Input ");
                return;
            }
            else
            {
                CurrentLocation = lsLocations[Choicecurrent - 1];

            }

        }
    }
}