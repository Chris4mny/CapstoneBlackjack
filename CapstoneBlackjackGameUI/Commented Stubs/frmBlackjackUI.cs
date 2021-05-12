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
            
        }

        private void dealTheInitialCardsOnePlayer()
        {
            
        }

        private void dealTheInitialCardsTwoPlayers()
        {
            
        }

        private void btnHitPlayer1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnStandPlayer1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHitPlayer2_Click(object sender, EventArgs e)
        {
            
        }

        private void dealersTurnToPlay()
        {
            
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            
        }

        private void btnOnePlayer_Click(object sender, EventArgs e)
        {
           
        }

        private void btnTwoPlayers_Click(object sender, EventArgs e)
        {
            
        }

        private void checkForWinnerSinglePlayer(int valueDealer, int valuePlayer1)
        {
            
        }

        private void checkForWinnerTwoPlayers(int valueDealer, int valuePlayer1, int valuePlayer2)
        {
            
        }

        private void lblCard1Player1_MouseHover(object sender, EventArgs e) // Shows face down card to the player                      
        {
           
        }

        private void lblCard1Player1_MouseLeave(object sender, EventArgs e) // hides face down card to the player
        {

        }

        private void lblCard1Player2_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void lblCard1Player2_MouseLeave(object sender, EventArgs e)
        {
            
        }
    }
}
