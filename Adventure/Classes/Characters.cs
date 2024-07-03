using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Adventure.Classes
{
    public abstract class Characters : IBattleStates
    {
        
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        public Characters(string Name, int Health)
        {
            this.Name = Name;
            this.Health = Health;
        }
    }
    public class Player : Characters
    {

        public Player(string Name, int Health) : base(Name, Health)
        {   

        }    

    }
    public enum Level
    {
        Easy = 1,
        Mid = 2 ,
        Hard = 3,

    }

    public abstract class Monster :IBattleStates
    {
     
        public Level selectedLevel { get; set; }
        public string Name { get ; set; }
        public int Health { get ; set; }
        public int AttackPower { get; set;  }
        public int Defense { get; set; } 
        public Monster(string Name, int Health) 
        {
            {
                this.Name = Name;
                this.Health = Health;
                selectedLevel = Level.Easy;
            }


        }
        public class ClsMonster : Monster
        {
            
            public ClsMonster(string Name, int Health ) :
                base(Name, Health)
            {

            }

            public void ChooseLevel()
            {
                Console.WriteLine("What level do you need? (Easy = 1, Mid = 2, Hard = 3)");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, out Level selectedLevel) && Enum.IsDefined(typeof(Level), selectedLevel))
                {
                    this.selectedLevel = selectedLevel;
                    Console.WriteLine($"You selected: {selectedLevel} (Level {(int)selectedLevel})");
                }
                else
                {
                    Console.WriteLine($"Invalid input. Defaulting to: {selectedLevel} (Level {(int)selectedLevel})");
                }
            }
        }

    }
}


