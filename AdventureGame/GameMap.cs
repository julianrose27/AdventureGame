using System;
using System.Collections.Generic;
using static AdventureGame.Utility;

namespace AdventureGame
{
    public class GameMap
    {
        // the map is stored in nested lists with IGameBoardObject interfaces
        private List<List<IGameBoardObject>> Map = new List<List<IGameBoardObject>>();
        private Player player = new Player();
        // keep track of the player X and Y coordinates on the map
        int PlayerYIndex;
        int PlayerXIndex;
        // the dimensions of the map
        int Dimension;

        public GameMap(int Dimension)
        {
            // set the  dimension of the map
            this.Dimension = Dimension;

            // create the map and populate it with EmptySpace objects
            for(int i = Dimension; i > 0; i--)
            {
                List<IGameBoardObject> Row = new List<IGameBoardObject>();
                for(int x = Dimension; x > 0; x--)
                {
                    Row.Add(new EmptySpace());
                }
                Map.Add(Row);
            }
        }

        public void InitializePlayer(int x, int y)
        {
            PlayerXIndex = x;
            PlayerYIndex = y;

            Map[PlayerYIndex][PlayerXIndex] = player;

        }

        // add game board objects to the map in the cooresponding X and Y coordinates
        public void AddGameBoardObject(IGameBoardObject GameBoardObject, int x, int y)
        {
            Map[y][x] = GameBoardObject;
        }

        // print the map to the console
        public void PrintMap()
        {
            // make sure that the map hasn't been beaten yet
            if (!player.GetBeaten())
            {
                Console.Clear();

                Console.WriteLine($"X: {PlayerXIndex} Y:{PlayerYIndex}\n");

                foreach (List<IGameBoardObject> l in Map)
                {
                    foreach (IGameBoardObject s in l)
                    {
                        Console.ForegroundColor = s.GetColor();
                        Console.Write(s.GetCharacter());
                        Console.ResetColor();
                    }
                    Console.WriteLine();
                }
                Move();
            }

        }

        private void Move()
        {
            // set the space that the player is on to a new EmptySpace
            Map[PlayerYIndex][PlayerXIndex] = new EmptySpace();

            // read the direction that the player wants to go in and call the corresponding method
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:
                    MoveNorth();
                    break;
                case ConsoleKey.DownArrow:
                    MoveSouth();
                    break;
                case ConsoleKey.RightArrow:
                    MoveEast();
                    break;
                case ConsoleKey.LeftArrow:
                    MoveWest();
                    break;
                case ConsoleKey.I:
                    player.PrintInventory();
                    break;

            }
            // place the player in the correct position that they should be in
            Map[PlayerYIndex][PlayerXIndex] = player;
            PrintMap();
        }

        private void MoveWest()
        {
            // check to make sure that the player isn't on the very edge of the map
            if (PlayerXIndex != 0)
            {
                // check to make sure that the player can actually step on the space
                if (Map[PlayerYIndex][PlayerXIndex - 1].CanStep())
                {
                    // change the player's coordinate to be on the new spot
                    PlayerXIndex--;
                    // run the IGameBoardObject OnStep() method at the player's current postition
                    Map[PlayerYIndex][PlayerXIndex].OnStep(player);
                }
                else
                {
                    // run the IGameBoardObject OnStep() method in the position where the player tried to move but can't
                    Map[PlayerYIndex][PlayerXIndex - 1].OnStep(player);
                }
            }
        }

        private void MoveEast()
        {

            if (PlayerXIndex < Dimension-1)
            {
                if (Map[PlayerYIndex][PlayerXIndex + 1].CanStep())
                {
                    PlayerXIndex++;
                    Map[PlayerYIndex][PlayerXIndex].OnStep(player);

                }
                else
                {
                    Map[PlayerYIndex][PlayerXIndex + 1].OnStep(player);
                }

            }
        }

        private void MoveSouth()
        {
            if (PlayerYIndex < Dimension-1)
            {
                if (Map[PlayerYIndex + 1][PlayerXIndex].CanStep())
                {
                    PlayerYIndex++;
                    Map[PlayerYIndex][PlayerXIndex].OnStep(player);

                }
                else
                {
                    Map[PlayerYIndex + 1][PlayerXIndex].OnStep(player);
                }

            }

        }

        private void MoveNorth()
        {

            if (PlayerYIndex != 0)
            {
                if (Map[PlayerYIndex - 1][PlayerXIndex].CanStep())
                {
                    PlayerYIndex--;
                    Map[PlayerYIndex][PlayerXIndex].OnStep(player);
                }
                else
                {
                    Map[PlayerYIndex - 1][PlayerXIndex].OnStep(player);
                }

            }

        }
    }
}
