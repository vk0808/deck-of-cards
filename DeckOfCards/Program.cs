using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Welcome message
            Console.WriteLine("Deck of Cards\n");

            CardDeck cards = new CardDeck();
            cards.CardsGenerator();
        }
    }
}
