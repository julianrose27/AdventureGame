# AdventureGame

1.1
* My midterm project isn’t necessarily a story-driven game. I wrote more of a 2d game engine that allows arbitrarily large game board and allows the placement of different objects on the game board that the player can interact with. I have included a short demo of the types of things that my code can do.
1.2. Characters
* The player can control their character using the arrow keys. The Player.cs class inherits from IGameBoardObject.cs and it contains an Inventory variable which is a list that stores Item objects. The player class also contains the balance that the player has which can be spent at Merchant game board objects.
1.3. Items
* There are no strict items that exist in the game. There is, however, and Item class which takes a string Name and an integer Worth in its constructor. Items are unique to each map that can be created.
