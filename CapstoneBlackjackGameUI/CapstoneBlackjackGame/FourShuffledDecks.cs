// Chris Foremny IT3500

using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneBlackjackCards
{
    public class FourShuffledDecks : ShuffleTheDeck
    {
        public FourShuffledDecks()
        {

        }

        public int[] retrieveManyShuffledDecks(int numberOfDecks)
        {
            ShuffleTheDeck sc = new ShuffleTheDeck();
            const int numberOfCardsInADeck = 52;
            int[] fourDecks = new int[numberOfCardsInADeck * numberOfDecks];
            int cardToTransfer = 0;

            for (int n = 0; n < numberOfDecks; n++)
            {
                int[] aDeck = getOneDeck();

                //displayCardFaces(aDeck);
                
                aDeck = sc.shuffle(aDeck);
                
                //displayCardFaces(aDeck);

                for (int p = 0; p < numberOfCardsInADeck; p++, cardToTransfer++)
                {
                    fourDecks[cardToTransfer] = aDeck[p];
                }

                //displayCardFaces(fourDecks);
            }

            fourDecks = sc.shuffle(fourDecks);

            displayCardFaces(fourDecks);

            return fourDecks;
        }

        private int[] getOneDeck()
        {
            DeckOfCards d1 = new DeckOfCards();

            return d1.retrieve1Deck();
        }

        public void displayCards(int[] cardsToShow)
        {
            for (int n = 0; n < cardsToShow.Length; n++)
            {
                if (n > 0 && n % 13 == 0)
                    Console.WriteLine();

                if (cardsToShow[n] < 10)
                    Console.Write(" ");

                Console.Write(cardsToShow[n] + "  ");
            }

            Console.WriteLine("\n\n");
        }

        private void displayCardFaces(int[] cardsToShow)
        {
            int face;
            int suit;
            const int adjustToGetSuit = 3; // adjust for unicode value

            for (int n = 0; n < cardsToShow.Length; n++)
            {
                if (n > 0 && n % 13 == 0)
                    Console.WriteLine();

                face = cardsToShow[n] % 13 + 1;
                suit = cardsToShow[n] % 4 + adjustToGetSuit;

                switch (face)
                {
                    case 11:
                        Console.Write("J");
                        break;
                    case 12:
                        Console.Write("Q");
                        break;
                    case 13:
                        Console.Write("K");
                        break;
                    case 1:
                        Console.Write("A");
                        break;
                    default:
                        Console.Write(face);
                        break;
                }
                switch (suit)
                {
                    case 3:
                        Console.Write((char)3);
                        break;
                    case 4:
                        Console.Write((char)4);
                        break;
                    case 5:
                        Console.Write((char)5);
                        break;
                    case 6:
                        Console.Write((char)6);
                        break;
                }

                Console.Write("  ");
            }

            Console.WriteLine("\n\n");
        }
    }
}