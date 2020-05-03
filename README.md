All Cards on Deck!
In this project, you will use C# to model a deck of playing cards. You'll also add functionality to it such as shuffling and dealing.

Shuffling Cards
Computers are notoriously bad at random numbers. This is a pretty deep and complex topic, but it's worth pointing out that most random numbers we use in computing are actually "pseudorandom". For this assignment, you will read about, then implement, a popular algorithm that shuffles the order of a finite set using C#'s built in Random.Next() function as a pseudorandom number generator.

Objectives
Demonstrate usage of arrays to model resources
Understand and implement algorithms
understand loops
Requirements
Your deck should contain 52 unique cards.
All cards should be represented as as string such as "Ace of Hearts"
There are four suits: "Clubs", "Diamonds", "Hearts", and "Spades".
There are 13 ranks: "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", and "King".
You will model these in code, in any way you see fit. It may require you to experiment and try a number of techniques. There are many valid solutions.

To shuffle the cards, you should implement the Fisher–Yates shuffle algorithm:

For our purposes, n is 52:

for i from n - 1 down to 1 do:
j = random integer (where 0 <= j <= i)
swap items[i] with items[j]
hint: really understand the algorithm before you try to implement it.

Explorer Mode
Once the program starts, you should create a new deck.
After deck creation, you should shuffle the deck using Fisher–Yates shuffle algorithm.
After the deck is shuffled, display the top card.
Give the user an option to see the next card or quit the program.
