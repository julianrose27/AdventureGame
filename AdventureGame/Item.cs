using System;
namespace AdventureGame
{
    public class Item
    {

        protected string Name;
        protected int Worth;


        public Item(string Name, int Worth)
        {
            this.Name = Name;
            this.Worth = Worth;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetWorth()
        {
            return Worth;
        }

    }
}
