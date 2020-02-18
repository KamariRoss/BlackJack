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
        /*Console.WriteLine($"Dealer total is {dealerTotal}");

        Console.WriteLine($"Your first card is {playerHand[0].Rank} of {playerHand[0].Suit}");
        Console.WriteLine($"Your second card is {playerHand[1].Rank} of {playerHand[1].Suit}");
        */

        // 7. Creating black jack, bust, or draw

        if (playerTotal == 21 && dealerTotal > 21 || playerTotal == 21 && dealerTotal != 21 || playerTotal == 21 && dealerTotal < 21)
        {
          Console.WriteLine($"Congratulations {user} your total was {playerTotal} and the dealer total was {dealerTotal}");

        }

        else if (dealerTotal == playerTotal && dealerTotal < 21 && playerTotal < 21)
        {
          Console.WriteLine("${user}, you and the dealer bust ");

        }
        else if (dealerTotal == 21 && playerTotal == 21)
        {
          Console.WriteLine("${user}, you and the dealer had {playerTotal} ");

        }
        else if (dealerTotal == 21 && playerTotal > 21 || dealerTotal == 21 && playerTotal != 21 || dealerTotal == 21 && playerTotal < 21)
        {
          Console.WriteLine("${user}, you and the dealer had {playerTotal} ");
        }
        else if (dealerTotal != 21 && playerTotal != 21 || dealerTotal < 21 && playerTotal < 21)
        {
          Console.WriteLine("hit or stand");
          var playerChoice = Console.ReadLine().ToLower();
          if (playerChoice == "hit")
          {
            topcard = deck[0];
            deck.RemoveAt(0);
            playerHand.Add(topcard);

            for (int i = 0; i < playerHand.Count; i++)
            {
              playerTotal += playerHand[i].GetCardValue();
            }

            Console.WriteLine($"Your total is {playerTotal}");
            Console.WriteLine($"Your first card is {playerHand[0].Rank} of {playerHand[0].Suit}");
            Console.WriteLine($"Your second card is {playerHand[1].Rank} of {playerHand[1].Suit}");
            Console.WriteLine($"Your third card is {playerHand[2].Rank} of {playerHand[2].Suit}");
            if (playerTotal < 21)
            {
              Console.WriteLine("hit or stand");
              playerChoice = Console.ReadLine().ToLower();
              if (playerChoice == "stand")
              {

                while (dealerTotal < 17)
                {

                  topcard = deck[0];
                  deck.RemoveAt(0);
                  dealerHand.Add(topcard);

                  for (int i = 0; i < dealerHand.Count; i++)
                  {
                    dealerTotal += dealerHand[i].GetCardValue();
                  }
                  /*
                                    Console.WriteLine($"Dealer total is {dealerTotal}");
                                    Console.WriteLine($"Dealer first card is {dealerHand[0].Rank} of {dealerHand[0].Suit}");
                                    Console.WriteLine($"Dealer second card is {dealerHand[1].Rank} of {dealerHand[1].Suit}");
                                    Console.WriteLine($"Dealer third card is {dealerHand[2].Rank} of {dealerHand[2].Suit}");
                  */

                }
              }
              else if (playerChoice == "hit")
              {
                topcard = deck[0];
                deck.RemoveAt(0);
                playerHand.Add(topcard);

                for (int i = 0; i < playerHand.Count; i++)
                {
                  playerTotal += playerHand[i].GetCardValue();
                }

                Console.WriteLine($"Your total is {playerTotal}");
                Console.WriteLine($"Your first card is {playerHand[0].Rank} of {playerHand[0].Suit}");
                Console.WriteLine($"Your second card is {playerHand[1].Rank} of {playerHand[1].Suit}");
                Console.WriteLine($"Your third card is {playerHand[2].Rank} of {playerHand[2].Suit}");
                if (playerTotal < 21)
                {
                  Console.WriteLine("hit or stand");
                  playerChoice = Console.ReadLine().ToLower();
                  if (playerChoice == "stand")
                  {

                    while (dealerTotal < 17)
                    {

                      topcard = deck[0];
                      deck.RemoveAt(0);
                      dealerHand.Add(topcard);

                      for (int i = 0; i < dealerHand.Count; i++)
                      {
                        dealerTotal += dealerHand[i].GetCardValue();
                      }
                      /*
                                            Console.WriteLine($"Dealer total is {dealerTotal}");
                                            Console.WriteLine($"Dealer first card is {dealerHand[0].Rank} of {dealerHand[0].Suit}");
                                            Console.WriteLine($"Dealer second card is {dealerHand[1].Rank} of {dealerHand[1].Suit}");
                                            Console.WriteLine($"Dealer third card is {dealerHand[2].Rank} of {dealerHand[2].Suit}");
                      */

                    }
                  }
                  else if (playerChoice == "hit")
                  {
                    topcard = deck[0];
                    deck.RemoveAt(0);
                    playerHand.Add(topcard);

                    for (int i = 0; i < playerHand.Count; i++)
                    {
                      playerTotal += playerHand[i].GetCardValue();
                    }

                    Console.WriteLine($"Your total is {playerTotal}");
                    Console.WriteLine($"Your first card is {playerHand[0].Rank} of {playerHand[0].Suit}");
                    Console.WriteLine($"Your second card is {playerHand[1].Rank} of {playerHand[1].Suit}");
                    Console.WriteLine($"Your third card is {playerHand[2].Rank} of {playerHand[2].Suit}");


                  }

                }
              }
              //stand

              else if (playerChoice == "stand")
              {

                while (dealerTotal < 17)
                {

                  topcard = deck[0];
                  deck.RemoveAt(0);
                  dealerHand.Add(topcard);

                  for (int i = 0; i < dealerHand.Count; i++)
                  {
                    dealerTotal += dealerHand[i].GetCardValue();
                  }
                  /*
                                    Console.WriteLine($"Dealer total is {dealerTotal}");
                                    Console.WriteLine($"Dealer first card is {dealerHand[0].Rank} of {dealerHand[0].Suit}");
                                    Console.WriteLine($"Dealer second card is {dealerHand[1].Rank} of {dealerHand[1].Suit}");
                                    Console.WriteLine($"Dealer third card is {dealerHand[2].Rank} of {dealerHand[2].Suit}");

                  */
                }
              }


            }

            {

            }


            if (playerTotal == 21 && dealerTotal > 21 || playerTotal == 21 && dealerTotal != 21 || playerTotal == 21 && dealerTotal < 21)
            {
              Console.WriteLine($"Congratulations {user} your total was {playerTotal} and the dealer total was {dealerTotal}");

            }

            else if (dealerTotal == playerTotal && dealerTotal < 21 && playerTotal < 21)
            {
              Console.WriteLine("${user}, you and the dealer bust ");

            }
            else if (dealerTotal == 21 && playerTotal == 21)
            {
              Console.WriteLine("${user}, you and the dealer had {playerTotal} ");

              Console.WriteLine($"Dealer first card is {dealerHand[0].Rank} of {dealerHand[0].Suit}");
              Console.WriteLine($"Dealer second card is {dealerHand[1].Rank} of {dealerHand[1].Suit}");
              Console.WriteLine($"Dealer third card is {dealerHand[2].Rank} of {dealerHand[2].Suit}");
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
  }
}
