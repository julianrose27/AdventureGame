using System;
namespace AdventureGame
{
    public interface IGameBoardObject
    {
        public void OnStep(Player player);
        public ConsoleColor GetColor();
        public string GetCharacter();
        public bool CanStep();
    }
}
