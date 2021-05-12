// Chris Foremny IT3500

using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneBlackjackCards
{
    public class DeckOfCards
    {
        private int[] theDeck;
        private int[] theRandomizedDeck;

        public DeckOfCards()
        {
  
        }

        public int[] retrieve1Deck()
        {
            int[] createdDeck = createADeck();

            int [] intitalizedDeck = initializeTheDeck(createdDeck);

            int [] shuffledDeck = randomizeDeck(intitalizedDeck);

            return shuffledDeck;
        }

        private int[] createADeck()
        {
            theDeck = new int[52];

            //cards 0-12 are clubs
            //cards 13 - 25 are diamonds
            //cards 26-38 are hearts
            //cards 39-51 are spades

            for (int n = 0; n < theDeck.Length; n++)
            {
                theDeck[n] = n;
            }

            return theDeck;
        }

        private int[] initializeTheDeck(int [] theDeck)
        {
            theDeck = new int[52];

            for (int n = 0; n < theDeck.Length; n++)
            {
                theDeck[n] = n + 1;
            }

            return theDeck;
        }

        private void displayTheDeck(int[] displayItem)
        {
            for (int n = 1; n < displayItem.Length + 1; n++)
            {
                Console.Write(displayItem[n - 1] + "  ");

                if (n % 13 == 0)
                {
                    Console.WriteLine();
                }
            }
        }

        public int [] randomizeDeck(int [] initializedDeck)
        {
            theRandomizedDeck = new int[52];

            Random rnd = new Random();

            for (int n = 0; n < theRandomizedDeck.Length; n++)
            {
                int theCard = rnd.Next() % 52;

                do
                {
                    if (theDeck[theCard] != -1)
                    {
                        theRandomizedDeck[n] = theDeck[theCard];
                        theDeck[theCard] = -1;
                        //Console.WriteLine(theCard + " is in if");
                        break;
                    }
                    else
                    {
                        theCard++;

                        if (theCard == 52)
                        {
                            theCard = 0;
                        }
                    }
                   
                } while (true);
            }

            return theRandomizedDeck;
        }
    }
}