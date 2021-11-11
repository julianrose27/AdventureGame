using System;
namespace AdventureGame
{
    public class EmptySpace: IGameBoardObject
    {
        public EmptySpace()
        {
        }

        public bool CanStep()
        {
            return true;
        }

        public virtual string GetCharacter()
        {
            return "0";
        }

        public virtual ConsoleColor GetColor()
        {
            return ConsoleColor.Black;
        }

        public virtual void OnStep(Player player) { }
    }
}
