// Chris Foremny IT3500

using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneBlackjackCards
{
    public class ShuffleTheDeck
    {
        public ShuffleTheDeck() { } // Constructor

        public int[] shuffle(int[] cardsToShuffle)
        {
            Random rnd = new Random();
            int shuffleCard;

            int[] shuffledDecks = new int[cardsToShuffle.Length];

            for (int n = 0; n < shuffledDecks.Length; n++)
            {
                shuffleCard = rnd.Next() % cardsToShuffle.Length;

                while (cardsToShuffle[shuffleCard] == -1)
                {
                    shuffleCard++;

                    if (shuffleCard == cardsToShuffle.Length)
                    {
                        shuffleCard = 0;
                    }
                }

                shuffledDecks[n] = cardsToShuffle[shuffleCard];
                cardsToShuffle[shuffleCard] = -1;
            }

            return shuffledDecks;
        }

        private void displayDecks(int[] cardsToDisplay)
        {
            for (int n = 0; n < cardsToDisplay.Length; n++)
            {
                if (n > 0 && n % 13 == 0)

                    Console.WriteLine();

                Console.Write(cardsToDisplay[n] + "  ");
            }
        }
    }
}