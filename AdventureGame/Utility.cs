using System;
namespace AdventureGame
{
    // a utility class for some random methods that take care of repetitive things I'm too lazy to type out
    public static class Utility
    {
        // wait for user input and then clear the console
        public static void Pause()
        {
            Console.WriteLine("\n\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        // an overloaded version of the Pause method in the case that I don't want to clear the console
        public static void Pause(bool Clear)
        {
            if (Clear)
            {
                Pause();
            }
            else
            {
                Console.WriteLine("\n\nPress any key to continue...");
                Console.ReadKey();

            }
        }

    }
}
