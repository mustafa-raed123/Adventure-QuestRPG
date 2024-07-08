using Adventure.Classes;
using static Adventure.Classes.Monster;

namespace Adventure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Adventue Quest-Rpg");
            Player player = new Player("Mustafa", 100 ,20);
            Adventures adventure = new Adventures();
            adventure.StartGame(player);
            EndBattle(player);
        }

        public static void EndBattle(Player player)
        {
            if (player.Health > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You win and the battle is ended.");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("You lose and the battle is ended.");
            }
        }
    }
}
