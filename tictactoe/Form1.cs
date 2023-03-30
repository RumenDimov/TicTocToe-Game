using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tictactoe
{
    public partial class TicTacToe : Form
    {
        bool turn = true; // true = x turn; false = Y turn

        int turnCount = 0;

        bool thereIsWinner = false;
        public TicTacToe()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed By Rumen Dimov", "Tic Tac Toe Game");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;// casting object into a button

            if (turn)
                b.Text = "X";

            else 
                b.Text = "O";

            turn = !turn; //flips the turn, someone else's turn

            b.Enabled = false; // disable the button once it is clicked

            turnCount++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            

            //horizontal checks
            if (button1.Text == button2.Text && button2.Text == button3.Text && !button1.Enabled)

                thereIsWinner = true;

            else if (button4.Text == button5.Text && button5.Text == button6.Text && !button4.Enabled)

                thereIsWinner = true;

            else if (button7.Text == button8.Text && button8.Text == button9.Text && !button7.Enabled)

                thereIsWinner = true;


            //vertical checks
            else if (button1.Text == button4.Text && button4.Text == button7.Text && !button1.Enabled)

                thereIsWinner = true;

            else if (button2.Text == button5.Text && button5.Text == button8.Text && !button2.Enabled)

                thereIsWinner = true;

            else if (button3.Text == button6.Text && button6.Text == button9.Text && !button3.Enabled)

                thereIsWinner = true;



            //horizontal checks
            else if (button1.Text == button5.Text && button5.Text == button9.Text && !button1.Enabled)

                thereIsWinner = true;

            else if (button3.Text == button5.Text && button5.Text == button7.Text && !button3.Enabled)

                thereIsWinner = true;

            


            //check if there is a winner

            if (thereIsWinner)
            {
                disableButtons();// if there is a winner, disable buttons

                String winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";

                MessageBox.Show($"{winner} Wins!", "Yay");
            }
            else
            {
                if (turnCount == 9)
                    MessageBox.Show("Draw!", "Bummer!");
            }

        } //end checkForWinner method


        private void disableButtons()
        {
            try
            {

                foreach (Control c in Controls)
                {
                    Button b = (Button)c;//cating an button in object.

                    b.Enabled = false;


                }//end foreach

            }
            catch { }

            

        }//end disableButtons method

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //reseting the game

            turn = true;

            turnCount = 0;

            try
            {

                foreach (Control c in Controls)
                {
                    Button b = (Button)c;//cating an control in a button.

                    b.Enabled = true;

                    b.Text = "";


                }//end foreach

            }
            catch { }
        }
    }
}
