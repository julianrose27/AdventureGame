using System;
using System.Collections.Generic;
using static AdventureGame.Utility;

namespace AdventureGame
{
    public class Demo
    {
        public Demo()
        {
            Console.WriteLine("Would you like to read the tutorial before starting? (y/n)\n\n");
            Console.Write("> ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Tutorial();
            }
            else
            {
                StartGame();
            }

        }

        private void Tutorial()
        {
            Console.Clear();
            Item DummyItem = new Item("dummy", 0);
            List<Item> DummyMerchantStock = new List<Item>();

            EmptySpace DummyEmptySpace = new EmptySpace();
            Crate DummyCrate = new Crate(DummyItem);
            Merchant DummyMerchant = new Merchant(DummyMerchantStock);
            Barrier DummyBarrier = new Barrier();
            Door DummyDoor = new Door(new DoorKey("DummyKey", 0, 0));
            Goal DummyGoal = new Goal();

            Console.WriteLine("Welcome to my game!\n\n");
            Console.WriteLine("When the gameboard is displayed, you can move around with your arrow keys. In this view, you are also able to press \"I\" to open your inventory.");
            Console.WriteLine("Objects on the gameboard are represented by a character and color.");
            Console.Write("For example, blank spaces on the board are represented like this: ");
            Console.ForegroundColor = DummyEmptySpace.GetColor();
            Console.Write(DummyEmptySpace.GetCharacter());
            Console.ResetColor();
            Console.WriteLine("\nYou can move freely around blank spaces.");
            Pause();


            Console.Write($"Crates are represented with a ");
            Console.ForegroundColor = DummyCrate.GetColor();
            Console.Write(DummyCrate.GetCharacter());
            Console.ResetColor();
            Console.WriteLine(". They contain items when you walk into them.");
            Pause();

            Console.Write("Merchants sell items for money and are represented with an ");
            Console.ForegroundColor = DummyMerchant.GetColor();
            Console.Write(DummyMerchant.GetCharacter());
            Console.ResetColor();
            Console.WriteLine(". You can purchase items from Merchants.");
            Pause();

            Console.Write("Barriers are represented with an ");
            Console.ForegroundColor = DummyBarrier.GetColor();
            Console.Write(DummyBarrier.GetCharacter());
            Console.ResetColor();
            Console.WriteLine(". You are not able to walk through barriers.");
            Pause();

            Console.Write("Doors, represented with an ");
            Console.ForegroundColor = DummyDoor.GetColor();
            Console.Write(DummyDoor.GetCharacter());
            Console.ResetColor();
            Console.WriteLine(", are locked and behave as a barrier at first but with the right key, you will be able to open it.");

            Pause();

            Console.Write("To win, you must make your way to the goal which looks like this: ");
            Console.ForegroundColor = DummyGoal.GetColor();
            Console.Write(DummyGoal.GetCharacter());
            Console.ResetColor();
            Console.WriteLine(".");
            Pause();

            Console.WriteLine("That's it for the tutorial, let's jump into the demo map!");
            Pause();

            StartGame();
        }

        public void StartGame()
        {
            GameMap map = new GameMap(15);

            DoorKey key1 = new DoorKey("Key 1", 20, 0);

            List<Item> MerchantStock = new List<Item>();

            MerchantStock.Add(new Item("Sword", 30));
            MerchantStock.Add(key1);

            // add objects to the game board
            map.AddGameBoardObject(new Barrier(), 0, 4);
            map.AddGameBoardObject(new Barrier(), 1, 4);
            map.AddGameBoardObject(new Barrier(), 2, 4);
            map.AddGameBoardObject(new Barrier(), 3, 4);
            map.AddGameBoardObject(new Barrier(), 4, 4);
            map.AddGameBoardObject(new Barrier(), 5, 4);
            map.AddGameBoardObject(new Barrier(), 6, 4);
            map.AddGameBoardObject(new Barrier(), 8, 4);
            map.AddGameBoardObject(new Barrier(), 9, 4);
            map.AddGameBoardObject(new Barrier(), 10, 4);
            map.AddGameBoardObject(new Barrier(), 11, 4);
            map.AddGameBoardObject(new Barrier(), 12, 4);
            map.AddGameBoardObject(new Barrier(), 13, 4);
            map.AddGameBoardObject(new Barrier(), 14, 4);
            map.AddGameBoardObject(new Door(key1), 7, 4);
            map.AddGameBoardObject(new Crate(new Item("Bag of Money", 50)), 14, 6);
            map.AddGameBoardObject(new Merchant(MerchantStock), 1, 10);
            map.AddGameBoardObject(new Goal(), 7, 1);

            map.InitializePlayer(7, 13);

            map.PrintMap();

        }

    }
}
