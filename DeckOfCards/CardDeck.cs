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


        // Method to generate new cards and shuffle cards
        public void CardsGenerator()
        {
            int card = 0;

            // Array of Cards
            string[] deck = new string[NO_CARDS];
            string[,] Cards = new string[ranks.Length, suits.Length];
            string[,] playersCards = new string[PLAYERS, CARDS_PER_PLAYER];


            // Create new cards by concatinating ranks and suits
            for (int r = 0; r < ranks.Length; r++)
            {
                for (int s = 0; s < suits.Length; s++)
                {
                    Cards[r, s] = String.Concat(ranks[r] + " - " + suits[s]);
                    deck[card] = Cards[r, s];
                    card++;
                }
            }

            // Copy the original deck for sorting
            string[] originalSorted = new string[NO_CARDS];
            deck.CopyTo(originalSorted, 0);


            // Suffle Cards using random method
            Random random = new Random();

            for (int i = 0; i < deck.Length; i++)
            {
                // pick random card from the deck and swap
                int randomCard = random.Next(0, deck.Length);
                string temp = deck[i]; 
                deck[i] = deck[randomCard];
                deck[randomCard] = temp;
            }


            // Get cards for each player
            for (int i = 0; i < PLAYERS; i++)
            {
                // call distributor method for each player
                string[] play = Distributor(deck, originalSorted, i);
                for (int j = 0; j < CARDS_PER_PLAYER; j++)
                {
                    playersCards[i, j] = play[j];
                }
            }

            // Display cards for all players
            Display(playersCards);

        }

        // Method to distribute card for each player
        private string[] Distributor(string[] deck, string[] sortedDeck, int n)
        {
            string[] player = new string[CARDS_PER_PLAYER];
            
            for (int cards = 0; cards < CARDS_PER_PLAYER; cards++)
            {
                player[cards] = deck[cards + (n * CARDS_PER_PLAYER)];
            }

            // call sort method for each method
            string[] sorted = new string[CARDS_PER_PLAYER];
            sorted = Sort(sortedDeck, player);

            return sorted;
        }

        // Method to sort player cards
        private string[] Sort(string[] deck, string[] player)
        {
            string[] sortedPlayer = new string[CARDS_PER_PLAYER];
            int index = 0;

            // Get index of each card in order of original sorted deck and store it into sorted array
            for (int i = 0; i < NO_CARDS; i++)
            {
                int pos = Array.IndexOf(player, deck[i]);
                if (pos > -1)
                {
                    sortedPlayer[index] = player[pos];
                    index++;
                }
            }
            return sortedPlayer;
        }


        // Display player cards
        private void Display(string[,] playersCards)
        {
            for (int player = 0; player < PLAYERS; player++)
            {
                Console.WriteLine($"\nPlayer {player + 1} cards:");
                Console.WriteLine("---------------------");
                for (int card = 0; card < CARDS_PER_PLAYER; card++)
                {
                    Console.WriteLine(playersCards[player, card]);
                }
            }
        }
    }
}
