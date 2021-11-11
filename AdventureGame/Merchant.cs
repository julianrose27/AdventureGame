using System;
using System.Collections.Generic;
using static AdventureGame.Utility;

namespace AdventureGame
{
    public class Merchant: IGameBoardObject
    {

        private List<Item> Stock = new List<Item>();

        public Merchant (List<Item> Stock)
        {
            this.Stock = Stock;
        }

        public bool CanStep()
        {
            return false;
        }

        public string GetCharacter()
        {
            return "M";
        }

        public ConsoleColor GetColor()
        {
            return ConsoleColor.Red;
        }

        public List<Item> GetStock()
        {
            return Stock;
        }

        public void OnStep(Player player)
        {
            Console.Clear();
            Console.WriteLine("Hello there, welcome to my shop. Take a look around and see if you'd like to purchase anything...\n\n");

            // print the Merchant's stock to the console
            for (int i = 1; i < Stock.Count + 1; i++)
            {
                Console.WriteLine($"{i}: {Stock[i - 1].GetName()} ... ${Stock[i - 1].GetWorth()}");
            }

            Console.WriteLine("\nType \"exit\" to exit");

            Console.Write($"\nYou have: ${player.GetBalance()}\n\n");

            string selection = Console.ReadLine();
            int selectionInt = 0;

            if (selection.ToLower() == "exit")
            {
                Console.Clear();
                Console.WriteLine("Have a good day.");
                Pause();
            }
            else
            {
                try
                {
                    selectionInt = int.Parse(selection);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Please make sure that you are inputting a number or \"exit\"");
                    Pause();
                    OnStep(player);
                }

                try
                {
                    player.PurchaseItem(Stock[selectionInt - 1], this);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.WriteLine("Please input a number that cooresponds to an item for sale.");
                    Pause();
                    OnStep(player);
                }
            }

        }
    }
}
