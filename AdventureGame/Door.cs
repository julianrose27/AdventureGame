using System;
using static AdventureGame.Utility;
namespace AdventureGame
{
    public class Door: Barrier
    {
        int ID;
        private bool Locked = true;
        DoorKey key;
        private bool canStep = false;

        public Door(DoorKey key)
        {
            this.key = key;
        }

        public override string GetCharacter()
        {
            return "D";
        }

        public override bool CanStep()
        {
            return canStep;
        }

        public override ConsoleColor GetColor()
        {
            return ConsoleColor.DarkBlue;
        }

        public override void OnStep(Player player)
        {
            if (Locked)
            {
                // iterate through the keys that the player has in their inventory
                foreach (Item i in player.GetInventory())
                {
                    // if the ID of the key matches the ID of the door, unlock the door
                    if (i == key)
                    {
                        Locked = false;
                        canStep = true;
                        UnlockDoor();

                    }
                }
                // if the door is still locked after looking through all the player's keys, tell the player that the door is locked
                if (Locked)
                {
                    LockedDoor();
                }
            }

        }

        protected virtual void LockedDoor()
        {
            Console.Clear();
            Console.WriteLine("Looks like this door is locked... If only you had a key...");
            Pause();
        }

        protected virtual void UnlockDoor()
        {
            Console.Clear();
            Console.WriteLine($"You unlocked the door using {key.GetName()}");
            Pause();
        }
    }
}
