// Chris Foremny IT3500

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace CapstoneBlackjackCards
{
    public class Gameplay
    {
        private TheCards theDeck = new TheCards();
        private int player1Card1Value = 0;
        private int player1Card2Value = 0;
        private int player1Hand = 0;
        private int getAnotherCard = 0;
        private int player2Card1Value = 0;
        private int player2Card2Value = 0;
        private int player2Hand = 0;
        private int dealerCard1Value = 0;
        private int dealerCard2Value = 0;
        private int dealersHand = 0;
        private int milliseconds = 3000;
        private String player1FaceValue;
        private int player1UnicodeSuit;
        private String player2FaceValue;
        private int player2UnicodeSuit;
        private String dealerFaceValue;
        private int dealerUnicodeSuit;
        private String player1Name;
        private String player2Name;


        public Gameplay()
        {
            
        }

        public TheCards getTheDeck()
        {
            return theDeck;
        }

        public void playTheGame()
        {
            InputOutput IO = new InputOutput();

            IO.dislpayOutputToTheUser("Welcome to the Blackjack Table\n");

            Thread.Sleep(milliseconds);

            String numberOfPlayers = retrieveThePlayersNames();

            Thread.Sleep(milliseconds);

            if (numberOfPlayers == "1")
            {
                player1Blackjack();

                dealerBlackjack();

                checkForTheWinnerOnePlayer();

                decisionToContinuePlayingBlackjackOnePlayer();
            }
            else if (numberOfPlayers == "2")
            {
                player1Blackjack();

                player2Blackjack();

                dealerBlackjack();

                checkForTheWinnerTwoPlayers();

                decisionToContinuePlayingBlackjackTwoPlayer();
            }
            else
            {
                IO.dislpayOutputToTheUser("Invalid entry, try again");

                System.Environment.Exit(1);
            }
        }

        public String retrieveThePlayersNames()
        {
            InputOutput IO = new InputOutput();

            String numberOfPlayers = IO.obtainInputFromTheUser("How many player do you have? Enter 1 or 2");

            if (numberOfPlayers == "1")
            {
                player1Name = IO.obtainInputFromTheUser("Enter the name for Player 1: ");
            }
            else
            {
                player1Name = IO.obtainInputFromTheUser("Enter the name for player 1: ");

                player2Name = IO.obtainInputFromTheUser("Enter the name for player 2: ");
            }

            return numberOfPlayers;
        }

        public void decisionToContinuePlayingBlackjackOnePlayer()
        {
            InputOutput IO = new InputOutput();

            while (true)
            {
                String playAgain = IO.obtainInputFromTheUser("Do you want to continue playing? Enter Y or N"); ;

                if (playAgain == "Y" || playAgain == "y")
                {
                    player1Blackjack();

                    dealerBlackjack();

                    checkForTheWinnerOnePlayer();

                    decisionToContinuePlayingBlackjackOnePlayer();
                }
                else if (playAgain == "N" || playAgain == "n")
                {
                    Console.WriteLine("Thank you for playing Blackjack");

                    System.Environment.Exit(1);
                }
                else
                {
                    IO.dislpayOutputToTheUser("Invalid entry, Try again");
                    continue;
                }
            }
        }

        public void decisionToContinuePlayingBlackjackTwoPlayer()
        {
            InputOutput IO = new InputOutput();

            while (true)
            {
                String playAgain = IO.obtainInputFromTheUser("Do you want to continue playing? Enter Y or N"); ;

                if (playAgain == "Y" || playAgain == "y")
                {
                    player1Blackjack();

                    player2Blackjack();

                    dealerBlackjack();

                    checkForTheWinnerTwoPlayers();

                    decisionToContinuePlayingBlackjackTwoPlayer();
                }
                else if (playAgain == "N" || playAgain == "n")
                {
                    Console.WriteLine("Thank you for playing Blackjack");

                    System.Environment.Exit(1);
                }
                else
                {
                    IO.dislpayOutputToTheUser("Invalid entry, Try again");
                    continue;
                }
            }
        }

        public void dealerBlackjack()
        {
            InputOutput IO = new InputOutput();

            while (true)
            {
                int cardOne = theDeck.retrieveOneCard();

                dealerUnicodeSuit = (char)decodeTheSuitOfTheCard(cardOne);

                dealerFaceValue = Convert.ToString(decodeTheFaceOfTheCard(cardOne));

                dealerCard1Value = decodeTheValueOfTheCard(cardOne);

                Thread.Sleep(milliseconds);

                IO.dislpayOutputToTheUser("Dealer's first card is a " + dealerFaceValue + " of " + dealerUnicodeSuit + "'s\n");

                int cardTwo = theDeck.retrieveOneCard();

                dealerUnicodeSuit = (char)decodeTheSuitOfTheCard(cardTwo);

                dealerFaceValue = Convert.ToString(decodeTheFaceOfTheCard(cardTwo));

                dealerCard2Value = decodeTheValueOfTheCard(cardTwo);

                Thread.Sleep(milliseconds);

                IO.dislpayOutputToTheUser("Dealer's second card is a " + dealerFaceValue + " of " + dealerUnicodeSuit + "'s\n");

                Thread.Sleep(milliseconds);

                dealersHand = dealerCard1Value + dealerCard2Value;

                if (dealersHand > 21) // checks for an ace
                {
                    dealersHand -= 10;
                }

                IO.dislpayOutputToTheUser("Dealer's hand value is: " + dealersHand + "\n");

                Thread.Sleep(milliseconds);

                if (dealersHand <= 21 && player1Hand > 21)
                {
                    break;
                }

                if (dealersHand <= 21 && player1Hand > 21 && player2Hand > 21)
                {
                    break;
                }

                if (player1Hand <= 21 || player2Hand <= 21 && dealersHand < 21 || dealersHand < 17) // dealer plays if player1 or 2 did not bust
                {
                    while (dealersHand < 21 && dealersHand <= 16) // dealer hits on these conditions in logical expression
                    {
                        getAnotherCard = theDeck.retrieveOneCard();

                        dealerUnicodeSuit = (char)decodeTheSuitOfTheCard(getAnotherCard);

                        dealerFaceValue = decodeTheFaceOfTheCard(getAnotherCard);

                        getAnotherCard = decodeTheValueOfTheCard(getAnotherCard);

                        Thread.Sleep(milliseconds);

                        IO.dislpayOutputToTheUser("Dealer must hit\n");

                        Thread.Sleep(milliseconds);

                        IO.dislpayOutputToTheUser("Dealer was dealt a " + dealerFaceValue + " of " + dealerUnicodeSuit + "'s\n");

                        dealersHand = dealersHand + getAnotherCard;

                        Thread.Sleep(milliseconds);

                        IO.dislpayOutputToTheUser("Dealers hand value is: " + dealersHand + "\n");

                        if (dealersHand < 17)
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                break;
            }
        }

        public void checkForTheWinnerOnePlayer()
        {
            InputOutput IO = new InputOutput();

            if (dealersHand == player1Hand)
            {
                IO.dislpayOutputToTheUser(player1Name + " and the dealer have tied\n");
            }
            if (dealersHand < player1Hand && dealersHand <= 21 && player1Hand <= 21)
            {
                IO.dislpayOutputToTheUser(player1Name + " has won\n");
            }
            if (dealersHand > 21 && player1Hand <= 21)
            {
                IO.dislpayOutputToTheUser("The dealer has busted, " + player1Name + " has won\n");
            }
            if (dealersHand > player1Hand && dealersHand <= 21)
            {
                IO.dislpayOutputToTheUser("The dealer has beat " + player1Name + "\n");
            }
        }

        public void checkForTheWinnerTwoPlayers()
        {
            InputOutput IO = new InputOutput();

            if (dealersHand == player1Hand)
            {
                IO.dislpayOutputToTheUser(player1Name + " and the dealer have tied\n");
            }
            if (dealersHand == player2Hand)
            {
                IO.dislpayOutputToTheUser(player2Name + " and the dealer have tied\n");
            }
            if (dealersHand < player1Hand && dealersHand <= 21 && player1Hand <= 21)
            {
                IO.dislpayOutputToTheUser(player1Name + " has won\n");
            }
            if (dealersHand < player2Hand && dealersHand <= 21 && player2Hand <= 21)
            {
                IO.dislpayOutputToTheUser(player2Name + " has won\n");
            }
            if (dealersHand > 21 && player1Hand <= 21)
            {
                IO.dislpayOutputToTheUser("The dealer has busted, " + player1Name + " has won\n");
            }
            if (dealersHand > 21 && player2Hand <= 21)
            {
                IO.dislpayOutputToTheUser("The dealer has busted, " + player2Name + " has won\n");
            }
            if (dealersHand == 21 && player1Hand != 21 && player2Hand != 21)
            {
                IO.dislpayOutputToTheUser("The dealer has won beat and beat both players\n");
            }
            if (dealersHand > player1Hand && dealersHand <= 21)
            {
                IO.dislpayOutputToTheUser("The dealer has beat " + player1Name + "\n");
            }
            if (dealersHand > player2Hand && dealersHand <= 21)
            {
                IO.dislpayOutputToTheUser("The dealer has beat " + player2Name + "\n");
            }
            if (dealersHand <= 21 && player1Hand > 21 && player2Hand > 21)
            {
                IO.dislpayOutputToTheUser("Both players have busted. The dealer is the winner.\n");
            }
        }

        public void player2Blackjack()
        {
            InputOutput IO = new InputOutput();

            while (true)
            {
                int cardOne = theDeck.retrieveOneCard();

                player2UnicodeSuit = (char)decodeTheSuitOfTheCard(cardOne);

                player2FaceValue = Convert.ToString(decodeTheFaceOfTheCard(cardOne));

                player2Card1Value = decodeTheValueOfTheCard(cardOne);

                Thread.Sleep(milliseconds);

                IO.dislpayOutputToTheUser("First card for " + player2Name + " is a: " + player2FaceValue + " of " + player2UnicodeSuit + "'s\n");

                int cardTwo = theDeck.retrieveOneCard();

                player2UnicodeSuit = (char)decodeTheSuitOfTheCard(cardTwo);

                player2FaceValue = decodeTheFaceOfTheCard(cardTwo);

                player2Card2Value = decodeTheValueOfTheCard(cardTwo);

                Thread.Sleep(milliseconds);

                IO.dislpayOutputToTheUser("Second card for " + player2Name + " is a: " + player2FaceValue + " of " + player2UnicodeSuit + "'s\n");

                Thread.Sleep(milliseconds);

                player2Hand = player2Card1Value + player2Card2Value; // add the cards to create the hand

                IO.dislpayOutputToTheUser(player2Name + "'s hand value is: " + player2Hand + "\n");

                Thread.Sleep(milliseconds);

                if (player2Hand > 21) // checks for an Ace on first two cards, if the hand it greater than 21 it subtracts 10
                {
                    player2Hand -= 10;
                }

                if (player2Hand == 21) // check for blackjack, if so player wins and breaks
                {
                    IO.dislpayOutputToTheUser("BlackJack you win!!!\n");

                    Thread.Sleep(milliseconds);

                    break;
                }

                while (player2Hand < 21) // if hand is less than 21 ask player to hit or stay
                {
                    String player2Answer = IO.obtainInputFromTheUser(player2Name + ", Do you want to hit? Y or N\n");

                    if (player2Answer == "Y" || player2Answer == "y") // if player hits
                    {
                        getAnotherCard = theDeck.retrieveOneCard();

                        player2UnicodeSuit = (char)decodeTheSuitOfTheCard(getAnotherCard);

                        player2FaceValue = decodeTheFaceOfTheCard(getAnotherCard);

                        getAnotherCard = decodeTheValueOfTheCard(getAnotherCard);

                        checkForAcePlayer2(getAnotherCard);

                        Thread.Sleep(milliseconds);

                        IO.dislpayOutputToTheUser(player2Name + " you were dealt " + player2FaceValue + " of " + player2UnicodeSuit + "'s\n");

                        Thread.Sleep(milliseconds);

                        IO.dislpayOutputToTheUser(player2Name + "'s hand value is " + player2Hand + "\n");

                        Thread.Sleep(milliseconds);

                        if (player2Hand > 21) // over 21 is a bust and game is over for the player
                        {
                            IO.dislpayOutputToTheUser(player2Name + " you busted\n");

                            Thread.Sleep(milliseconds);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (player2Answer == "N" || player2Answer == "n") // player does not want another card
                    {
                        Thread.Sleep(milliseconds);

                        IO.dislpayOutputToTheUser("You decided to stay. " + player2Name + "'s hand value is: " + player2Hand + "\n");

                        Thread.Sleep(milliseconds);

                        break;
                    }
                    else
                    {
                        IO.dislpayOutputToTheUser("Incorrect input, try again\n"); // invalid entry try again

                        continue;
                    }
                }

                break;
            }

        }

        public void checkForAcePlayer2(int getAnotherCard)
        {
            while (true)
            {
                if (getAnotherCard == 11 && player2Hand < 21)
                {
                    player2Hand = player2Hand + 1;

                    break;
                }
                else
                {
                    player2Hand = player2Hand + getAnotherCard;

                    break;
                }
            }
        }

        public void checkForAcePlayer1(int getAnotherCard)
        {
            while (true)
            {
                if (getAnotherCard == 11 && player1Hand < 21)
                {
                    player1Hand = player1Hand + 1;

                    break;
                }
                else
                {
                    player1Hand = player1Hand + getAnotherCard;

                    break;
                }
            }
        }

        public void player1Blackjack()
        {
            InputOutput IO = new InputOutput();

            while (true)
            {
                int cardOne = theDeck.retrieveOneCard();

                player1UnicodeSuit = (char)decodeTheSuitOfTheCard(cardOne);

                player1FaceValue = Convert.ToString(decodeTheFaceOfTheCard(cardOne));

                player1Card1Value = decodeTheValueOfTheCard(cardOne);

                IO.dislpayOutputToTheUser("First card for " + player1Name + " is a: " + player1FaceValue + " of " + player1UnicodeSuit + "'s\n");

                Thread.Sleep(milliseconds);

                int cardTwo = theDeck.retrieveOneCard();

                player1UnicodeSuit = (char)decodeTheSuitOfTheCard(cardTwo);

                player1FaceValue = decodeTheFaceOfTheCard(cardTwo);

                player1Card2Value = decodeTheValueOfTheCard(cardTwo);

                IO.dislpayOutputToTheUser("Second card for " + player1Name + " is a: " + player1FaceValue + " of " + player1UnicodeSuit + "'s\n");

                Thread.Sleep(milliseconds);

                player1Hand = player1Card1Value + player1Card2Value; // add the cards to create the hand

                IO.dislpayOutputToTheUser(player1Name + "'s hand value is: " + player1Hand + "\n");

                Thread.Sleep(milliseconds);

                if (player1Hand > 21) // checks for an Ace on first two cards, if the hand it greater than 21 it subtracts 10
                {
                    player1Hand -= 10;
                }

                if (player1Hand == 21) // check for blackjack, if so player wins and breaks
                {
                    IO.dislpayOutputToTheUser("BlackJack you win!!!\n");

                    Thread.Sleep(milliseconds);

                    break;
                }

                while (player1Hand < 21) // if hand is less than 21 ask player to hit or stay
                {
                    String player1Answer = IO.obtainInputFromTheUser(player1Name + ", Do you want to hit? Y or N\n");

                    if (player1Answer == "Y" || player1Answer == "y") // if player hits
                    {
                        getAnotherCard = theDeck.retrieveOneCard();

                        player1UnicodeSuit = (char)decodeTheSuitOfTheCard(getAnotherCard);

                        player1FaceValue = decodeTheFaceOfTheCard(getAnotherCard);

                        getAnotherCard = decodeTheValueOfTheCard(getAnotherCard);

                        checkForAcePlayer1(getAnotherCard);

                        Thread.Sleep(milliseconds);

                        IO.dislpayOutputToTheUser(player1Name + " you were dealt " + player1FaceValue + " of " + player1UnicodeSuit + "'s\n");

                        Thread.Sleep(milliseconds);

                        IO.dislpayOutputToTheUser(player1Name + "'s hand value is " + player1Hand + "\n");

                        Thread.Sleep(milliseconds);

                        if (player1Hand > 21) // over 21 is a bust and game is over for the player
                        {
                            IO.dislpayOutputToTheUser(player1Name + " you busted\n");

                            Thread.Sleep(milliseconds);
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (player1Answer == "N" || player1Answer == "n") // player does not want another card
                    {
                        IO.dislpayOutputToTheUser("You decided to stay. " + player1Name + "'s hand value is: " + player1Hand + "\n");

                        Thread.Sleep(milliseconds);

                        break;
                    }
                    else
                    {
                        IO.dislpayOutputToTheUser("Incorrect input, try again\n"); // invalid entry try again

                        continue;
                    }
                }

                break;
            }
        }

        public int decodeTheValueOfTheCard(int theValueOfTheCard)
        {
            theValueOfTheCard = theValueOfTheCard % 13 + 1;

            switch (theValueOfTheCard)
            {
                case 1:
                    theValueOfTheCard = 11;
                    break;
                case 11:
                    theValueOfTheCard = 10;
                    break;
                case 12:
                    theValueOfTheCard = 10;
                    break;
                case 13:
                    theValueOfTheCard = 10;
                    break;
                default:
                    break;
            }

            return theValueOfTheCard;
        }

        public int decodeTheSuitOfTheCard(int theUniocodeSuit)
        {
            const int adjustToGetSuit = 3; // adjust for unicode value

            theUniocodeSuit = theUniocodeSuit % 4 + adjustToGetSuit;

            switch (theUniocodeSuit)
            {
                case 3:
                    theUniocodeSuit = 9824; // spades
                    break;
                case 4:
                    theUniocodeSuit = 9825; // hearts
                    break;
                case 5:
                    theUniocodeSuit = 9826; // diamonds
                    break;
                case 6:
                    theUniocodeSuit = 9827; // clubs
                    break;
            }

            return theUniocodeSuit;
        }

        public String decodeTheFaceOfTheCard(int theFaceOfTheCard)
        {
            theFaceOfTheCard = theFaceOfTheCard % 13 + 1;
            
            switch (theFaceOfTheCard)
            {
                case 11:
                    if (theFaceOfTheCard == 11)
                    {
                        return "J";
                    }
                    break;
                case 12:
                    if (theFaceOfTheCard == 12)
                    {
                        return "Q";
                    }
                    break;
                case 13:
                    if (theFaceOfTheCard == 13)
                    {
                        return "K";
                    }
                    break;
                case 1:
                    if (theFaceOfTheCard == 1)
                    {
                        return "A";
                    }
                    break;
                default:
                    theFaceOfTheCard.ToString();
                    break;
            }

            return theFaceOfTheCard.ToString();
        }
    }
}
