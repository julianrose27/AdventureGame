using System;
using System.Collections.Generic;
using static AdventureGame.Utility;

namespace AdventureGame
{
    public class Crate: IGameBoardObject
    {

        Item item;
        List<Item> items = new List<Item>();

        // constructor that adds a single item to the inventory of the crate
        public Crate(Item item)
        {
            this.item = item;
        }

        // constructor that allows a list of items to be passed to the crate
        public Crate(List<Item> items)
        {
            this.items = items;
        }

        public bool CanStep()
        {
            return true;
        }

        public string GetCharacter()
        {
            return "C";
        }

        public ConsoleColor GetColor()
        {
            return ConsoleColor.DarkRed;
        }

        public void OnStep(Player player)
        {
            Console.Clear();
            // if the "item" variable isn't null, give the item to the player
            if (item != null)
            {
                player.GiveItem(item);
                Console.WriteLine($"Congrats, you found a {item.GetName()} in the crate!");
            }
            // if the "item" variable is empty, give the player all the items in the "items" list
            else
            {
                Console.Write("Congrats, you found ");
                foreach(Item i in items)
                {
                    Console.Write(i.GetName() + ", ");
                    player.GiveItem(i);
                }
                Console.Write(" in the crate!");
            }
            Pause();
        }
    }
}
