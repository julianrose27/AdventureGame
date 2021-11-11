using System;
using static AdventureGame.Utility;
namespace AdventureGame
{
    public class Goal: EmptySpace
    {
        public Goal()
        {
        }

        public override string GetCharacter()
        {
            return "G";
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.Yellow;
        }

        public override void OnStep(Player player)
        {
            Console.WriteLine("Congrats, you've beaten the map!");
            player.BeatMap();
            Console.Clear();
            Pause();
        }

    }
}
