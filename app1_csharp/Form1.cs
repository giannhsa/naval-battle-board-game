using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app1_csharp
{

    public partial class Form1 : Form
    {
        private GameManager gameManager = new GameManager();
        //arrays with buttons
        private Button[,] playerButtons;
        private Button[,] computerButtons;
        private int seconds = 0;//count elapsed time of current game session
        private int attempts = 0;
        private int wins = 0;
        private int loses = 0;
        private bool gameStart = false;
        private Database db = new Database();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            playerButtons = gameManager.PlayerButtons;
            computerButtons = gameManager.ComputerButtons;
            for (int i =0; i<11; i++)
            {
                for (int j = 0; j<11; j++)
                {
                    this.Controls.Add(playerButtons[i, j]);
                    //add click event to buttons
                    playerButtons[i, j].Click += computer_button_click;
                    this.Controls.Add(computerButtons[i, j]);
                    computerButtons[i, j].Click += player_button_click;
                }
            }
        }

        //button to start the game
        private void button1_Click(object sender, EventArgs e)
        {
            attempts = 0;
            seconds = 0;
            gameManager.resetArrays();
            button1.Enabled = false;
            timer1.Enabled = true;//enable timer
            //create boats on board
            gameStart = true;
            //gameManager.PlacePlayerBoats();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds += 1;
            label3.Text = "Time: " + seconds.ToString() + "secs";
        }

        private void player_button_click(object sender, EventArgs e)
        {
            if (!gameStart)
            {
                MessageBox.Show("Start a new game first!");
            }
            else if (((Button)sender).Text!= "")
            {
                MessageBox.Show("You cant choose the same spot again");
            }
            else
            {
                attempts += 1;
                //find the button clicked
                Button clickedButton = (Button)sender;
                var position = gameManager.indexOfComputerButton(clickedButton);
                string result = gameManager.checkPlayerMove(position.Item1, position.Item2);
                //player wins
                if(result == "Νίκησες!")
                {
                    MessageBox.Show(result + " Μετά από: " + attempts.ToString() + " προσπάθειες.");
                    button1.Enabled = true;
                    wins += 1;
                    label4.Text = "Wins: " + wins.ToString();
                    gameStart = false;
                    //end game
                    timer1.Enabled = false;
                    db.Insert("Player", seconds, attempts);
                }
                else if (result != "")
                {
                    richTextBox1.AppendText(result+"\n");
                
                }
                //computer's turn
                //position in buttons array of the button that the computer wants to press
                var position1 = gameManager.computerMove();
                computer_button_click(playerButtons[position1.Item1, position1.Item2], null);

            }
        }

        private void computer_button_click(object sender, EventArgs e)
        {
            if(e == null)
            {
                Button clickedButton = (Button)sender;
                var position = gameManager.indexOfPlayerButton(clickedButton);
                string result = gameManager.checkComputerMove(position.Item1, position.Item2);
                //player loses
                if (result == "Έχασες!")
                {
                    loses += 1;
                    label5.Text = "Loses: " + loses.ToString();
                    gameStart = false;
                    MessageBox.Show(result);
                    button1.Enabled = true;                    
                    //end game
                    timer1.Enabled = false;
                    db.Insert("Computer", seconds, attempts);
                }
                else if (result != "")
                {
                    richTextBox1.AppendText(result + "\n");
                }

            }
        }


    }
}
