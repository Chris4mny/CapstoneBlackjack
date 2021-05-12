// Chris Foremny IT3500

using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneBlackjackCards
{
    public class TheCards : FourShuffledDecks
    {
        private int cardDealt;
        int[] bootOfCards;
        FourShuffledDecks fourDecks;

        public TheCards() // Constructor
        {
            fourDecks = new FourShuffledDecks();
            bootOfCards = fourDecks.retrieveManyShuffledDecks(4);
            cardDealt = 0;
        }

        public int retrieveOneCard()
        {
            int theCard;

            if (cardDealt == bootOfCards.Length - 52)
            {
                bootOfCards = fourDecks.retrieveManyShuffledDecks(4);
                cardDealt = 0;
            }

            theCard = bootOfCards[cardDealt];

            cardDealt++;
            /*if (cardDealt == 1)
                theCard = -1 * theCard;*/
            return theCard;
        }
    }
}