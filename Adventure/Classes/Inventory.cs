using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Adventure.Classes
{
    public class Inventory
    {
        List<Items> lsItems;

        public Inventory()
        {
            lsItems = new List<Items>();
        }
        public void AddInventory(Items item)
        {
            PrintItemInfo(item);

        }
        public void PrintItemInfo(Items item)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("You have received :                                                     ");
            if (item is Armor armorItem)
            {
                Console.WriteLine($"{armorItem.Name}: {armorItem.Description} ==> This Contains + {armorItem.DefenseRating} Defense");
                lsItems.Add(item);
            }
            else if (item is Weapon weaponItem)
            {
                Console.WriteLine($"{weaponItem.Name}: {weaponItem.Description} ==> This Contains + {weaponItem.Damage} Attack Power");
                lsItems.Add(item);
            }
            else if (item is Potion potionItem)
            {
                Console.WriteLine($"{potionItem.Name}: {potionItem.Description} ==> This Contains + {potionItem.HealAmount} Health");
                lsItems.Add(item);

            }
            Console.ResetColor();
        }
        public void CheckUseItems(ref Player player)
        {
            if (lsItems.Count > 0)
            {
                Console.WriteLine("DO you Want to Use Items (Yes / No)");
                string Check = Console.ReadLine().ToLower();  /*  Handle This  */
                if (Check == "yes")
                {
                    int numOfItems = PrintItems();
                    CheckUseItems(lsItems[numOfItems], ref player);
                }

            }
            else
            {
                return;
            }

        }
        public int PrintItems()
        {

            for (int i = 0; i < lsItems.Count; i++)
            {
                Console.WriteLine($" {lsItems[i].Name}  Press ==> {i + 1} ");

            }
            Console.WriteLine($"Press Enter  {lsItems.Count + 1}==>  to Exit ");
            int itemnum = IsValidInput();     /*Handle This */
            return itemnum - 1;

        }
        public void CheckUseItems(Items item, ref Player player)
        {
            if (item is Armor armorItem)
            {
                player.Defense += armorItem.DefenseRating;
                lsItems.Remove(armorItem);

                Console.WriteLine($"Your Defense Up to {player.Defense}");

            }
            else if (item is Potion potionItem)
            {
                player.Health += potionItem.HealAmount;
                lsItems.Remove(potionItem);
                if (player.Health > 100)
                {
                    player.Health = 100;
                }
                Console.WriteLine($"Your Health Up to {player.Health}");
            }
            else if (item is Weapon weaponItem)
            {

                player.AttackPower = weaponItem.Damage;
                lsItems.Remove(weaponItem);
                Console.WriteLine($"Your AttackPower is {player.AttackPower}");
            }

        }
        public int IsValidInput()
        {

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int Index))
                {
                    if (Index > 0 && Index <= lsItems.Count + 1)
                    {
                        return Index;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid number:");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }
            }



        }
    }
}
