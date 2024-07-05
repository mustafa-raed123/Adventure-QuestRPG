using Adventure.Classes;
using static Adventure.Classes.Monster;

namespace Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Mustafa", 100 ,20);
            Adventures adventure = new Adventures();

            adventure.StartGame(player);

            ////ClsMonster monster = new ClsMonster("monster", 100 );
            //BattleSystem battleSystem = new BattleSystem();
            ////battleSystem.StartBattle(player, monster);
            EndBattle(player);
            

        }

        public static void EndBattle(Player player)
        {
            if (player.Health > 0)
            {
                Console.WriteLine($"You win and the battle is ended.");
               

            }
            else
            {
                Console.WriteLine("You lose and the battle is ended.");
            }
        }
    }
}
