using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards
{
    public class CardDeck
    {
        // Constant Variable 
        const int PLAYERS = 4;
        const int NO_CARDS = 52;
        const int CARDS_PER_PLAYER = 9;

        // Arrays
        public string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        public string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"};


        // Method to generate new cards, shuffle and distribute cards
        public void CardsGenerator()
        {
            int card = 0;

            // Array of Cards
            string[] deck = new string[NO_CARDS];
            string[,] Cards = new string[suits.Length, ranks.Length];
            

            // Create new cards by concatinating ranks and suits
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    Cards[i, j] = String.Concat(ranks[j] + " - " + suits[i]);
                    deck[card] = Cards[i, j];
                    card++;
                }
            }

            // Suffle Cards using random method
            Random random = new Random();

            for (int i = 0; i < deck.Length; i++)
            {
                int randomCard = random.Next(0, deck.Length + 1);
                string temp = deck[i]; 
                deck[i] = deck[randomCard];
                deck[randomCard] = temp;
            }

            Distribute(deck);

        }

        // Distribute cards to players - 1 card to each player
        public void Distribute(string[] deck)
        {
            int noOfCards = 0;
            for (int player = 0; player < PLAYERS; player++)
            {
                Console.WriteLine($"\nPlayer {player+1} cards:");
                Console.WriteLine("---------------------");
                for (int card = 0; card < CARDS_PER_PLAYER; card++)
                {
                    
                    Console.WriteLine(deck[noOfCards]);
                    noOfCards++;
                }
            }
        }
    }
}
