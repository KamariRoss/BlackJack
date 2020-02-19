using System;
using System.Collections.Generic;

namespace BlackJack
{
  class Program
  {
    static void Main(string[] args)

    {
      bool flag = true;
      while (flag)
      {

        // 1. Challenge user to a game
        Console.Write("Hello! Welcome to Blackjack! ");
        Console.WriteLine("What is you name?");
        var user = Console.ReadLine();
        Console.WriteLine($"{user} lest's play Blackjack");

        // 2. Create a list of cards
        var suits = new List<string>() { "clover", "hearts", "spades", "diamonds" };
        var ranks = new List<string>() { "ace", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "jack", "queen", "king" };
        var deck = new List<Card>();
        for (int i = 0; i < suits.Count; i++)
        {
          for (int j = 0; j < ranks.Count; j++)
          {
            // 3. Combining the cards
            var card = new Card();
            card.Rank = ranks[j];
            card.Suit = suits[i];
            if (card.Suit == "diamonds" || card.Suit == "hearts")
            {
              card.ColorOfTheCard = "red";
            }
            else
            {
              card.ColorOfTheCard = "black";
            }
            deck.Add(card);
          }
        }
        // 4. Shuffle the cards
        for (int i = deck.Count - 1; i >= 1; i--)
        {
          var j = new Random().Next(i);
          var temp = deck[j];
          deck[j] = deck[i];
          deck[i] = temp;
        }
        // 5.pass cards out
        var playerHand = new List<Card>();
        var topcard = deck[0];
        deck.RemoveAt(0);
        playerHand.Add(topcard);
        topcard = deck[0];
        deck.RemoveAt(0);
        playerHand.Add(topcard);

        var dealerHand = new List<Card>();
        topcard = deck[0];
        deck.RemoveAt(0);
        dealerHand.Add(topcard);
        topcard = deck[0];
        deck.RemoveAt(0);
        dealerHand.Add(topcard);

        // for loop has to start here

        // 6. get totals for hand
        var playerTotal = 0;
        for (int i = 0; i < playerHand.Count; i++)
        {
          playerTotal += playerHand[i].GetCardValue();
        }
        Console.WriteLine($"Your total is {playerTotal}");

        var dealerTotal = 0;
        for (int i = 0; i < dealerHand.Count; i++)
        {
          dealerTotal += dealerHand[i].GetCardValue();
        }
        // checkpoint 1.

        Console.WriteLine($"Your first card is {playerHand[0].Rank} of {playerHand[0].Suit}");
        Console.WriteLine($"Your second card is {playerHand[1].Rank} of {playerHand[1].Suit}");


        // 7. Creating black jack, bust, or draw
        bool pass = true;
        while (pass)
        {

          Console.WriteLine("hit or stand");
          var playerChoice = Console.ReadLine().ToLower();
          if (playerChoice == "hit")
          {
            pass = true;

            topcard = deck[0];
            deck.RemoveAt(0);
            playerHand.Add(topcard);

            playerTotal = 0;
            for (int i = 0; i < playerHand.Count; i++)
            {
              playerTotal += playerHand[i].GetCardValue();
            }

            Console.WriteLine($"Your total is {playerTotal}");

          }
          else if (playerChoice == "stand")
          {
            pass = false;

          }
          if (playerTotal >= 21 || playerChoice == "stand")
          {
            pass = false;
            bool limit = false;
            while (limit)
            {
              dealerHand.Add(topcard);
              topcard = deck[0];
              deck.RemoveAt(0);
              dealerHand.Add(topcard);

              dealerTotal = 0;
              for (int i = 0; i < dealerHand.Count; i++)
              {
                dealerTotal += dealerHand[i].GetCardValue();
              }
              if (dealerTotal >= 17)
              {
                limit = false;
              }
              // game logic
            }
            if (playerTotal == 21 && dealerTotal > 21 || playerTotal == 21 && dealerTotal != 21 || playerTotal == 21 && dealerTotal < 21)
            {
              Console.WriteLine($"BlackJack! Congratulations {user} your total was {playerTotal} and the dealer total was {dealerTotal}");
            }
            else if (dealerTotal == playerTotal && dealerTotal < 21 && playerTotal < 21)
            {
              Console.WriteLine($"{user}, your total was {playerTotal} and the dealers was {dealerTotal}.  You both bust ");
            }
            else if (dealerTotal == 21 && playerTotal == 21)
            {
              Console.WriteLine("${user}, you and the dealer had {playerTotal} ");
            }
            else if (dealerTotal == 21 && playerTotal > 21 || dealerTotal == 21 && playerTotal != 21 || dealerTotal == 21 && playerTotal < 21)
            {
              Console.WriteLine($"You lose! The dealer's total was {dealerTotal} and yours was {playerTotal}");
            }
            else if (dealerTotal != 21 && playerTotal != 21 && dealerTotal > playerTotal)
            {
              Console.WriteLine($"You lose! The dealer's total was {dealerTotal} and yours was {playerTotal} ");
            }
            else if (dealerTotal != 21 && playerTotal != 21 && dealerTotal < playerTotal)
            {
              Console.WriteLine($" You win! The dealer's total was {dealerTotal} and yours was {playerTotal}");
            }
          }
        }

        Console.WriteLine("Play again? 'yes' or 'no'");
        string playAgain = Console.ReadLine().ToLower();
        if (playAgain == "no")
          flag = false;
        else if (playAgain == "yes")
        {
          flag = true;
        }
      }
    }
  }
}
