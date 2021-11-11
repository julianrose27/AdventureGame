using System;
namespace AdventureGame
{
    public class DoorKey: Item
    {

        int ID;

        public DoorKey(string Name, int Worth, int ID) : base(Name, Worth)
        {
            this.ID = ID;
        }

        public int GetID()
        {
            return ID;
        }
    }
}
