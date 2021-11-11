using System;
namespace AdventureGame
{
    public class Barrier: IGameBoardObject
    {
        public Barrier()
        {
        }

        public virtual bool CanStep()
        {
            return false;
        }

        public virtual string GetCharacter()
        {
            return "X";
        }

        public virtual ConsoleColor GetColor()
        {
            return ConsoleColor.White;
        }

        public virtual void OnStep(Player player) {}
    }
}
