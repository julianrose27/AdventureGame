using System;
using System.Collections.Generic;
using static AdventureGame.Utility;

namespace AdventureGame
{
    public class Player: IGameBoardObject
    {

        private int Balance = 0;
        private List<Item> Inventory = new List<Item>();
        private bool Beaten = false;

        public Player()
        {
        }

        public bool CanStep()
        {
            return false;
        }

        public string GetCharacter()
        {
            return "P";
        }

        public ConsoleColor GetColor()
        {
            return ConsoleColor.Green;
        }

        public void OnStep(Player player) {}

        public int GetBalance()
        {
            return Balance;
        }

        // verify that the player has enough balance to purchase the item, subtract the balance and then add the item to the inventory
        public void PurchaseItem(Item i, Merchant merchant)
        {
            if (Balance >= i.GetWorth())
            {
                Balance = Balance - i.GetWorth();
                Inventory.Add(i);
                merchant.GetStock().Remove(i);
                Console.Clear();
                Console.WriteLine("Thanks for your patronage.");
                Pause();
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Unfortunately, you are {i.GetWorth() - Balance} dollars short. Come back later!");
                Pause();
            }
        }

        public void GiveItem(Item item)
        {
            if (item.GetName() == "Bag of Money")
            {
                Balance += item.GetWorth();
            }
            else
            {
                Inventory.Add(item);
            }
        }

        // print the player's inventory to the console
        public void PrintInventory()
        {
            Console.Clear();
            Console.WriteLine("Your Inventory:\n");
            foreach(Item item in Inventory)
            {
                Console.WriteLine(item.GetName());
            }
            Console.WriteLine("\nYour balance is: $" + Balance);

            Pause();

        }

        public List<Item> GetInventory()
        {
            return Inventory;
        }

        public void BeatMap()
        {
            Beaten = true;
        }

        public bool GetBeaten()
        {
            return Beaten;
        }
    }
}
