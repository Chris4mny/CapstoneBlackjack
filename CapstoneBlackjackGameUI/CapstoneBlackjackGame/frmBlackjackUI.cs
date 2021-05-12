// Chris Foremny IT3500

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CapstoneBlackjackGame
{
    public partial class frmBlackjackTable : Form
    {
        int cardToDeal = 0;
        int playerOneNextCardLocation = 0;
        int playerTwoNextCardLocation = 0;
        int dealerNextCardLocation = 0;
        int valuePlayer1;
        int valuePlayer2;
        int valueDealer;
        int milliseconds = 1500;
        CapstoneBlackjackCards.Gameplay GP = new CapstoneBlackjackCards.Gameplay();
        CapstoneBlackjackCards.TheCards theDeck;

        public frmBlackjackTable()
        {
            InitializeComponent();
        }

        private void frmBlackjackTable_Load(object sender, EventArgs e)
        {
            theDeck = GP.getTheDeck();
        }

        /*private void btnDeal_Click(object sender, EventArgs e) // deal button to start game, calls dealTheInitialCards method
        {
            dealTheInitialCardsTwoPlayers();
            btnHitPlayer1.Enabled = true;
            btnStandPlayer1.Enabled = true;
        }*/

        private void dealTheInitialCardsOnePlayer()
        {
            int cardOne = theDeck.retrieveOneCard(); // -----------------------------------------player 1 first card
            String faceOne = GP.decodeTheFaceOfTheCard(cardOne);
            int suit = GP.decodeTheSuitOfTheCard(cardOne);
            valuePlayer1 = GP.decodeTheValueOfTheCard(cardOne);

            lblCard1Player1.Visible = true;
            lblCard1Player1.BackColor = Color.Black;
            lblCard1Player1.Text = faceOne + " " + (char)suit;
            cardToDeal++;

            int cardTwo = theDeck.retrieveOneCard(); //----------------------------------------dealers first card
            String faceTwo = GP.decodeTheFaceOfTheCard(cardTwo);
            int suit1 = GP.decodeTheSuitOfTheCard(cardTwo);
            valueDealer = GP.decodeTheValueOfTheCard(cardTwo);

            lblCard1Dealer.Visible = true;
            lblCard1Dealer.BackColor = Color.Black;
            lblCard1Dealer.Text = faceTwo + " " + (char)suit1;
            cardToDeal++;

            int cardThree = theDeck.retrieveOneCard(); //----------------------------------------player 1 second card
            String faceThree = GP.decodeTheFaceOfTheCard(cardThree);
            int suit3 = GP.decodeTheSuitOfTheCard(cardThree);
            valuePlayer1 += GP.decodeTheValueOfTheCard(cardThree);

            lblCard2Player1.Visible = true;
            lblCard2Player1.Text = faceThree + " " + (char)suit3;
            lblPlayer1Score.Text = valuePlayer1.ToString();
            cardToDeal++;

            int cardFour = theDeck.retrieveOneCard();// --------------------------------------- dealer second card
            String faceFour = GP.decodeTheFaceOfTheCard(cardFour);
            int suit4 = GP.decodeTheSuitOfTheCard(cardFour);
            valueDealer += GP.decodeTheValueOfTheCard(cardFour);

            lblCard2Dealer.Visible = true;
            lblCard2Dealer.Text = faceFour + " " + (char)suit4;
            lblDealerScore.Text = valueDealer.ToString();
            cardToDeal++;

            btnHitPlayer1.Enabled = true;
            btnStandPlayer1.Enabled = true;

            if (valuePlayer1 == 21)
            {
                lblBlackjackDisplayPlayer1.Visible = true; // label with blackjack
                btnHitPlayer1.Enabled = false;
                btnStandPlayer1.Enabled = false;

                dealersTurnToPlay();
            }
            if (valuePlayer1 > 21) // checks for an ace initial deal
            {
                valuePlayer1 += -10;
            }
            if (valueDealer > 21)
            {
                valueDealer += -10;
            }
        }

        private void dealTheInitialCardsTwoPlayers()
        {
            int cardOne = theDeck.retrieveOneCard(); // -----------------------------------------player 1 first card
            String faceOne = GP.decodeTheFaceOfTheCard(cardOne);
            int suit = GP.decodeTheSuitOfTheCard(cardOne);
            valuePlayer1 = GP.decodeTheValueOfTheCard(cardOne);

            lblCard1Player1.Visible = true;
            lblCard1Player1.BackColor = Color.Black;
            lblCard1Player1.Text = faceOne + " " + (char)suit;
            cardToDeal++;

            int cardTwo = theDeck.retrieveOneCard();  //----------------------------------------player 2 first card
            String faceTwo = GP.decodeTheFaceOfTheCard(cardTwo);
            int suit2 = GP.decodeTheSuitOfTheCard(cardTwo);
            valuePlayer2 = GP.decodeTheValueOfTheCard(cardTwo);

            lblCard1Player2.Visible = true;
            lblCard1Player2.BackColor = Color.Black;
            lblCard1Player2.Text = faceTwo + " " + (char)suit2;
            cardToDeal++;

            int cardThree = theDeck.retrieveOneCard(); //----------------------------------------dealers first card
            String faceThree = GP.decodeTheFaceOfTheCard(cardThree);
            int suit3 = GP.decodeTheSuitOfTheCard(cardThree);
            valueDealer = GP.decodeTheValueOfTheCard(cardThree);

            lblCard1Dealer.Visible = true;
            lblCard1Dealer.BackColor = Color.Black;
            lblCard1Dealer.Text = faceThree + " " + (char)suit3;
            cardToDeal++;

            int cardFour = theDeck.retrieveOneCard(); //----------------------------------------player 1 second card
            String faceFour = GP.decodeTheFaceOfTheCard(cardFour);
            int suit4 = GP.decodeTheSuitOfTheCard(cardFour);
            valuePlayer1 += GP.decodeTheValueOfTheCard(cardFour);

            lblCard2Player1.Visible = true;
            lblCard2Player1.Text = faceFour + " " + (char)suit4;
            lblPlayer1Score.Text = valuePlayer1.ToString();
            cardToDeal++;

            int cardFive = theDeck.retrieveOneCard(); //---------------------------------------- player 2 second card
            String faceFive = GP.decodeTheFaceOfTheCard(cardFive);
            int suit5 = GP.decodeTheSuitOfTheCard(cardFive);
            valuePlayer2 += GP.decodeTheValueOfTheCard(cardFive);

            lblCard2Player2.Visible = true;
            lblCard2Player2.Text = faceFive + " " + (char)suit5;
            lblPlayer2Score.Text = valuePlayer2.ToString();
            cardToDeal++;

            int cardSix = theDeck.retrieveOneCard();// --------------------------------------- dealer second card
            String faceSix = GP.decodeTheFaceOfTheCard(cardSix);
            int suit6 = GP.decodeTheSuitOfTheCard(cardSix);
            valueDealer += GP.decodeTheValueOfTheCard(cardSix);
            lblCard2Dealer.Visible = true;
            lblCard2Dealer.Text = faceSix + " " + (char)suit6;
            lblDealerScore.Text = valueDealer.ToString();
            cardToDeal++;

            // btnDeal.Enabled = false; // disables the deal button after one click
            btnHitPlayer1.Enabled = true;
            btnStandPlayer1.Enabled = true;

            if (valuePlayer1 == 21)
            {
                lblBlackjackDisplayPlayer1.Visible = true; // label with blackjack
                btnHitPlayer1.Enabled = false;
                btnStandPlayer1.Enabled = false;
                lblCard1Player1.BackColor = Color.White;
                MessageBox.Show("Player1 has blackjack, player 2's turn");
                btnHitPlayer2.Enabled = true;
                btnStandPlayer2.Enabled = true;
            }

            if (valuePlayer2 == 21 && btnHitPlayer2.Enabled == true)
            {
                lblBlackjackDisplayPlayer2.Visible = true; // label with blackjack
                btnHitPlayer2.Enabled = false;
                btnStandPlayer2.Enabled = false;

                MessageBox.Show("Dealer's turn");
                dealersTurnToPlay();
            }

            if (valuePlayer1 > 21) // checks for an ace on initial deal
            {
                valuePlayer1 += -10;
            }
            if (valuePlayer2 > 21)
            {
                valuePlayer1 += -10;
            }
            if (valueDealer > 21)
            {
                valueDealer += -10;
            }
        }

        private void btnHitPlayer1_Click(object sender, EventArgs e)
        {
            Label[] lblArray = new Label[9]; // array of labels for cards
            lblArray[0] = lblCard3Player1;
            lblArray[1] = lblCard4Player1;
            lblArray[2] = lblCard5Player1;
            lblArray[3] = lblCard6Player1;
            lblArray[4] = lblCard7Player1;
            lblArray[5] = lblCard8Player1;
            lblArray[6] = lblCard9Player1;
            lblArray[7] = lblCard10Player1;
            lblArray[8] = lblCard11Player1;

            if (cardToDeal - 6 < lblArray.Length) // -6 for the cards that were initially dealt
            {
                int card = theDeck.retrieveOneCard();
                String face = GP.decodeTheFaceOfTheCard(card);
                int suit = GP.decodeTheSuitOfTheCard(card);
                valuePlayer1 += GP.decodeTheValueOfTheCard(card);

                if (card == 11 && valuePlayer1 > 21) // checks for an ace
                {
                    valuePlayer1 += -10;
                }

                lblArray[playerOneNextCardLocation].Visible = true;
                lblArray[playerOneNextCardLocation].Text = face + " " + (char)suit;
            }

            if (valuePlayer1 > 21)
            {
                lblPlayer1Score.Visible = true;
                lblPlayer1Score.Text = valuePlayer1.ToString();
                lblCard1Player1.BackColor = Color.White;

                MessageBox.Show("Player 1 has busted"); // player has busted 
                btnHitPlayer1.Enabled = false; // players buttons disabled
                btnStandPlayer1.Enabled = false;

                if (grpBoxPlayer2.Enabled == true) // checks for a second player
                {
                    MessageBox.Show("Player 2's turn");
                    btnHitPlayer2.Enabled = true;
                    btnStandPlayer2.Enabled = true;
                }
                else if (grpBoxPlayer2.Enabled == false)
                {
                    MessageBox.Show("Dealer's turn");
                    dealersTurnToPlay();
                }
            }

            cardToDeal++;

            playerOneNextCardLocation++;
        }

        private void btnStandPlayer1_Click(object sender, EventArgs e)
        {
            lblPlayer1Score.Visible = true;
            lblCard1Player1.BackColor = Color.White; // turns down card to face up
            lblPlayer1Score.Text = valuePlayer1.ToString();
            btnHitPlayer1.Enabled = false;
            btnStandPlayer1.Enabled = false;

            if (grpBoxPlayer2.Enabled == false)
            {
                MessageBox.Show("Dealer's Turn");
                dealersTurnToPlay();
            }
            else if (grpBoxPlayer2.Enabled == true)
            {
                MessageBox.Show("player 2's turn");

                btnHitPlayer2.Enabled = true;
                btnStandPlayer2.Enabled = true;
            }
        }

        private void btnExitTheProgram_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1); // closes the program
        }

        private void btnStandPlayer2_Click(object sender, EventArgs e)
        {
            lblPlayer2Score.Visible = true;
            lblCard1Player2.BackColor = Color.White;
            lblPlayer2Score.Text = valuePlayer2.ToString();
            btnHitPlayer2.Enabled = false;
            btnStandPlayer2.Enabled = false;

            MessageBox.Show("Dealer's Turn");

            dealersTurnToPlay();
        }

        private void btnHitPlayer2_Click(object sender, EventArgs e)
        {
            Label[] lblArray = new Label[9];

            lblArray[0] = lblCard3Player2;
            lblArray[1] = lblCard4Player2;
            lblArray[2] = lblCard5Player2;
            lblArray[3] = lblCard6Player2;
            lblArray[4] = lblCard7Player2;
            lblArray[5] = lblCard8Player2;
            lblArray[6] = lblCard9Player2;
            lblArray[7] = lblCard10Player2;
            lblArray[8] = lblCard11Player2;

            if (cardToDeal - 6 < lblArray.Length)
            {
                int card = theDeck.retrieveOneCard();
                String face = GP.decodeTheFaceOfTheCard(card);
                int suit = GP.decodeTheSuitOfTheCard(card);
                valuePlayer2 += GP.decodeTheValueOfTheCard(card);

                if (card == 11 && valuePlayer2 > 21)
                {
                    valuePlayer2 += -10;
                }

                lblArray[playerTwoNextCardLocation].Visible = true;
                lblArray[playerTwoNextCardLocation].Text = face + " " + (char)suit;
            }

            if (valuePlayer2 > 21)
            {
                lblPlayer2Score.Visible = true;
                lblPlayer2Score.Text = valuePlayer2.ToString();
                lblCard1Player2.BackColor = Color.White;

                MessageBox.Show("Player 2 has busted");
                lblCard1Player2.BackColor = Color.White;
                btnHitPlayer2.Enabled = false;
                btnStandPlayer2.Enabled = false;
                lblPlayer2Score.Visible = true;

                dealersTurnToPlay();
            }

            cardToDeal++;

            playerTwoNextCardLocation++;
        }

        private void dealersTurnToPlay()
        {
            lblDealerScore.Visible = true;
            lblCard1Dealer.BackColor = Color.White;

            if (valuePlayer1 > 21 && valuePlayer2 > 21)
            {
                checkForWinnerTwoPlayers(valueDealer, valuePlayer1, valuePlayer2);
            }

            while (valueDealer == 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The Dealer has blackjack!!";
                break;
            }

            while (valueDealer < 21)
            {
                if (valueDealer < 21 && valueDealer >= 17)
                {
                    lblDealerScore.Visible = true;
                    if (lblPlayer1Score.Visible == true && lblPlayer2Score.Visible == true)
                    {
                        checkForWinnerTwoPlayers(valueDealer, valuePlayer1, valuePlayer2);
                    }
                    else
                    {
                        checkForWinnerSinglePlayer(valueDealer, valuePlayer1);
                    }
                    break;
                }

                Label[] lblArray = new Label[9];
                lblArray[0] = lblCard3Dealer;
                lblArray[1] = lblCard4Dealer;
                lblArray[2] = lblCard5Dealer;
                lblArray[3] = lblCard6Dealer;
                lblArray[4] = lblCard7Dealer;
                lblArray[5] = lblCard8Dealer;
                lblArray[6] = lblCard9Dealer;
                lblArray[7] = lblCard10Dealer;
                lblArray[8] = lblCard11Dealer;

                if (cardToDeal - 6 < lblArray.Length)
                {
                    int card = theDeck.retrieveOneCard();
                    String face = GP.decodeTheFaceOfTheCard(card);
                    int suit = GP.decodeTheSuitOfTheCard(card);
                    valueDealer += GP.decodeTheValueOfTheCard(card);

                    if (card == 11 && valueDealer > 21)
                    {
                        valueDealer += -10;
                    }

                    lblArray[dealerNextCardLocation].Visible = true;
                    lblArray[dealerNextCardLocation].Text = face + " " + (char)suit;
                }

                cardToDeal++;

                lblDealerScore.Text = valueDealer.ToString();

                if (valueDealer > 21)
                {
                    MessageBox.Show("Dealer has busted");
                    if (lblDealerScore.Visible == true && lblPlayer1Score.Visible == true && lblPlayer2Score.Visible == true)
                    {
                        checkForWinnerTwoPlayers(valueDealer, valuePlayer1, valuePlayer2);
                    }
                    else if (lblDealerScore.Visible == true && lblPlayer1Score.Visible == true)
                    {
                        checkForWinnerSinglePlayer(valueDealer, valuePlayer1);
                    }
                    break;
                }
                else
                {
                    continue;
                }
            }

            dealerNextCardLocation++;
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void btnOnePlayer_Click(object sender, EventArgs e)
        {
            grpBoxPlayer1.Visible = true;
            grpBoxPlayer2.Enabled = false;
            grpBoxIntroduction.Visible = false;

            dealTheInitialCardsOnePlayer();
        }

        private void btnTwoPlayers_Click(object sender, EventArgs e)
        {
            grpBoxPlayer1.Visible = true;
            grpBoxPlayer2.Visible = true;
            grpBoxIntroduction.Visible = false;

            dealTheInitialCardsTwoPlayers();
        }

        private void checkForWinnerSinglePlayer(int valueDealer, int valuePlayer1)
        {
            if (valueDealer == valuePlayer1)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "Player 1 and the dealer have tied";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer < valuePlayer1 && valueDealer <= 21 && valuePlayer1 <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "Player 1 has won";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer > 21 && valuePlayer1 <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The dealer has busted, Player1 has won";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer > valuePlayer1 && valueDealer <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The dealer has beat Player 1";

                Thread.Sleep(milliseconds);
            }
        }

        private void checkForWinnerTwoPlayers(int valueDealer, int valuePlayer1, int valuePlayer2)
        {
            Thread.Sleep(milliseconds);

            if (valueDealer == valuePlayer1)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "Player 1 and the dealer have tied";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer == valuePlayer2)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "Player 2 and the dealer have tied";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer < valuePlayer1 && valueDealer <= 21 && valuePlayer1 <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "Player 1 has won";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer < valuePlayer2 && valueDealer <= 21 && valuePlayer2 <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "Player 2 has won";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer > 21 && valuePlayer1 <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The dealer has busted, Player 1 has won";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer > 21 && valuePlayer1 <= 21 && valuePlayer2 <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The dealer has busted, Player 2 & Player 1 win";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer > 21 && valuePlayer2 <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The dealer has busted, Player 2 has won";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer > valuePlayer1 && valueDealer > valuePlayer2 && valueDealer <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The dealer has won beat and beat both players";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer > valuePlayer1 && valueDealer <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The dealer has beat Player 1";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer > valuePlayer2 && valueDealer <= 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "The dealer has beat Player 2";

                Thread.Sleep(milliseconds);
            }
            if (valueDealer <= 21 && valuePlayer1 > 21 && valuePlayer2 > 21)
            {
                lblDisplayResults.Visible = true;
                lblDisplayResults.Text = "Both players have busted. The dealer is the winner.";

                Thread.Sleep(milliseconds);
            }
        }

        private void lblCard1Player1_MouseHover(object sender, EventArgs e) // Shows face down card to the player                      
        {
            lblCard1Player1.BackColor = Color.White;
        }

        private void lblCard1Player1_MouseLeave(object sender, EventArgs e) // hides face down card to the player
        {
            lblCard1Player1.BackColor = Color.Black;
        }

        private void lblCard1Player2_MouseHover(object sender, EventArgs e)
        {
            lblCard1Player2.BackColor = Color.White;
        }

        private void lblCard1Player2_MouseLeave(object sender, EventArgs e)
        {
            lblCard1Player2.BackColor = Color.Black;
        }
    }
}
