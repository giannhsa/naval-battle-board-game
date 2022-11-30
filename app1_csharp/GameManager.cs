using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app1_csharp
{
    class GameManager
    {
        private string[,] playerBoard = new string[11, 11];
        private string[,] computerBoard = new string[11, 11];
        private int pX = 10;
        private int pY = 200;
        private int cX = 500;
        private int cY = 200;
        private int width = 40;
        private int height = 40;
        private Button[,] playerButtons = new Button[11, 11];
        private Button[,] computerButtons = new Button[11, 11];
        Random rand = new Random();
        //lists of indexes of boats
        //player boats
        List<string> playerAT = new List<string>();
        List<string> playerAP = new List<string>();
        List<string> playerP = new List<string>();
        List<string> playerY = new List<string>();
        //comouter boats
        List<string> computerAT = new List<string>();
        List<string> computerAP = new List<string>();
        List<string> computerP = new List<string>();
        List<string> computerY = new List<string>();
        public GameManager()
        {
            //create arrays with letters
            playerBoard[0, 0] = "0";
            playerBoard[0, 1] = "Α";
            playerBoard[0, 2] = "Β";
            playerBoard[0, 3] = "Γ";
            playerBoard[0, 4] = "Δ";
            playerBoard[0, 5] = "Ε";
            playerBoard[0, 6] = "Ζ";
            playerBoard[0, 7] = "Η";
            playerBoard[0, 8] = "Θ";
            playerBoard[0, 9] = "Ι";
            playerBoard[0, 10] = "Κ";
            //
            computerBoard[0, 0] = "0";
            computerBoard[0, 1] = "Α";
            computerBoard[0, 2] = "Β";
            computerBoard[0, 3] = "Γ";
            computerBoard[0, 4] = "Δ";
            computerBoard[0, 5] = "Ε";
            computerBoard[0, 6] = "Ζ";
            computerBoard[0, 7] = "Η";
            computerBoard[0, 8] = "Θ";
            computerBoard[0, 9] = "Ι";
            computerBoard[0, 10] = "Κ";
            //
            for (int i = 1; i < 11; i++)
            {
                playerBoard[i, 0] = i.ToString();
                computerBoard[i, 0] = i.ToString();
            }
            //create buttons
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    //player buttons initialize
                    playerButtons[i, j] = new Button();
                    playerButtons[i, j].Size = new System.Drawing.Size(width, height);
                    playerButtons[i, j].Location = new System.Drawing.Point(pX, pY);
                    playerButtons[i, j].Font = new Font("Arial", 12, FontStyle.Bold);
                    playerButtons[i, j].Visible = true;
                    if (playerBoard[i, j] != null)
                    {
                        playerButtons[i, j].Enabled = false;
                    }
                    playerButtons[i, j].Text = playerBoard[i, j];
                    //playerButtons[i, j].Enabled = false;
                    pX += width;
                    //computer buttons initialize
                    computerButtons[i, j] = new Button();
                    computerButtons[i, j].Size = new System.Drawing.Size(width, height);
                    computerButtons[i, j].Location = new System.Drawing.Point(cX, cY);
                    computerButtons[i, j].Visible = true;
                    computerButtons[i, j].Font = new Font("Arial", 12, FontStyle.Bold);
                    if (computerBoard[i, j] != null)
                    {
                        computerButtons[i, j].Enabled = false;
                    }
                    computerButtons[i, j].Text = computerBoard[i, j];
                    cX += width;
                }
                cY += height;
                cX = 500;
                pY += height;
                pX = 10;
            }
        }

        public Button[,] PlayerButtons { get => playerButtons;}
        public Button[,] ComputerButtons { get => computerButtons;}

        //test

        //


        public void PlacePlayerBoats()
        {
            //ΑΠ αεροπλανοφορο 
            //ΑΤ αντιτορπιλικο
            //Π πολεμικο
            //Υ υποβρυχιο
            //player Boats
            int ri = rand.Next(0, 11);
            int rj = rand.Next(0, 11);
            int choice = rand.Next(0, 2);//horizontaly or vertically
            //place αεροπλανοφορο
            bool placed = false;
            while (!placed)
            {
                if (choice == 0)
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 5; i++)
                    {
                        if (rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (playerBoard[ri, rj + i] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 5; i++)
                        {
                            playerBoard[ri, rj + i] = "ΑΠ";
                            playerAP.Add(ri.ToString() + "," + (rj + i).ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }
                }
                else
                {
                    bool empty = true;
                    //search vertically
                    for (int i = 0; i < 5; i++)
                    {
                        if(ri + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (playerBoard[ri + i, rj] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 5; i++)
                        {
                            playerBoard[ri + i, rj] = "ΑΠ";
                            playerAP.Add((ri+i).ToString() + "," + rj.ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }

                }
            }
            //place αντιτορπιλικο
            placed = false;
            while (!placed)
            {
                if (choice == 0)
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 4; i++)
                    {
                        if (rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (playerBoard[ri, rj + i] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 4; i++)
                        {
                            playerBoard[ri, rj + i] = "ΑΤ";
                            playerAT.Add(ri.ToString() + "," + (rj + i).ToString());

                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }
                }
                else
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 4; i++)
                    {
                        if (ri + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (playerBoard[ri + i, rj] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 4; i++)
                        {
                            playerBoard[ri + i, rj] = "ΑΤ";
                            playerAT.Add((ri+i).ToString() + "," + rj.ToString());

                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }

                }
            }
            //place πολεμικο
            placed = false;
            while (!placed)
            {
                if (choice == 0)
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 3; i++)
                    {
                        if (rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (playerBoard[ri, rj + i] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 3; i++)
                        {
                            playerBoard[ri, rj + i] = "Π";
                            playerP.Add(ri.ToString() + "," + (rj + i).ToString());

                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }
                }
                else
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 3; i++)
                    {
                        if (ri + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (playerBoard[ri + i, rj] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 3; i++)
                        {
                            playerBoard[ri + i, rj] = "Π";
                            playerP.Add((ri+i).ToString() + "," + rj.ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }

                }
            }
            //place Υποβρυχιο
            placed = false;
            while (!placed)
            {
                if (choice == 0)
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 2; i++)
                    {
                        if (rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (playerBoard[ri, rj + i] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 2; i++)
                        {
                            playerBoard[ri, rj + i] = "Υ";
                            playerY.Add(ri.ToString() + "," + (rj + i).ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }
                }
                else
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 2; i++)
                    {
                        if (ri + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (playerBoard[ri + i, rj] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 2; i++)
                        {
                            playerBoard[ri + i, rj] = "Υ";
                            playerY.Add((ri+i).ToString() + "," + rj.ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }

                }
            }
            PlaceComputerBoats();
        }

        //place computer boats
        public void PlaceComputerBoats()
        {
            //ΑΠ αεροπλανοφορο 
            //ΑΤ αντιτορπιλικο
            //Π πολεμικο
            //Υ υποβρυχιο
            //computer  Boats
            //for each boat search to find N positions empty in the row if found place the boat there
            int ri = rand.Next(0, 11);
            int rj = rand.Next(0, 11);
            int choice = rand.Next(0, 2);//horizontaly or vertically
            //place αεροπλανοφορο
            bool placed = false;
            while (!placed)
            {
                if (choice == 0)
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 5; i++)
                    {
                        if (rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (computerBoard[ri, rj + i] != null || rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 5; i++)
                        {
                            computerBoard[ri, rj + i] = "ΑΠ";
                            computerAP.Add(ri.ToString() + "," + (rj + i).ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }
                }
                else
                {
                    bool empty = true;
                    //search vertically
                    for (int i = 0; i < 5; i++)
                    {
                        if (ri + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (computerBoard[ri + i, rj] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 5; i++)
                        {
                            computerBoard[ri + i, rj] = "ΑΠ";
                            computerAP.Add((ri+i).ToString() + "," + rj.ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }

                }
            }
            //place αντιτορπιλικο
            placed = false;
            while (!placed)
            {
                if (choice == 0)
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 4; i++)
                    {
                        if (rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (computerBoard[ri, rj + i] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 4; i++)
                        {
                            computerBoard[ri, rj + i] = "ΑΤ";
                            computerAT.Add(ri.ToString() + "," + (rj + i).ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }
                }
                else
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 4; i++)
                    {
                        if (ri + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (computerBoard[ri + i, rj] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 4; i++)
                        {
                            computerBoard[ri + i, rj] = "ΑΤ";
                            computerAT.Add((ri + i).ToString() + "," + rj.ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }

                }
            }
            //place πολεμικο
            placed = false;
            while (!placed)
            {
                if (choice == 0)
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 3; i++)
                    {
                        if (rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (computerBoard[ri, rj + i] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 3; i++)
                        {
                            computerBoard[ri, rj + i] = "Π";
                            computerP.Add(ri.ToString() + "," + (rj + i).ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }
                }
                else
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 3; i++)
                    {
                        if (ri + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (computerBoard[ri + i, rj] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 3; i++)
                        {
                            computerBoard[ri + i, rj] = "Π";
                            computerP.Add((ri + i).ToString() + "," + rj.ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }

                }
            }
            //place Υποβρυχιο
            placed = false;
            while (!placed)
            {
                if (choice == 0)
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 2; i++)
                    {
                        if (rj + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (computerBoard[ri, rj + i] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 2; i++)
                        {
                            computerBoard[ri, rj + i] = "Υ";
                            computerY.Add(ri.ToString() + "," + (rj + i).ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }
                }
                else
                {
                    bool empty = true;
                    //search horizontaly
                    for (int i = 0; i < 2; i++)
                    {
                        if (ri + i > 10)
                        {
                            empty = false;
                            break;
                        }
                        if (computerBoard[ri + i, rj] != null)
                        {
                            empty = false;
                            break;
                        }
                    }
                    if (empty)
                    {
                        placed = true;
                        for (int i = 0; i < 2; i++)
                        {
                            computerBoard[ri + i, rj] = "Υ";
                            computerY.Add((ri + i).ToString() + "," + rj.ToString());
                        }
                    }
                    else
                    {
                        ri = rand.Next(0, 11);
                        rj = rand.Next(0, 11);
                        choice = rand.Next(0, 2);
                    }

                }
            }
            updateButtonsText();
        }

        //show the boats on the board
        public void updateButtonsText()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    playerButtons[i, j].Text = playerBoard[i, j];
                    if(computerBoard[i, j]!="ΑΤ" && computerBoard[i, j] != "ΑΠ" && computerBoard[i, j] != "Π" && computerBoard[i, j] != "Υ")
                    {
                        computerButtons[i, j].Text = computerBoard[i, j];

                    }
                }
            }
        }

        //find button in players button array and return position
        public Tuple<int, int> indexOfPlayerButton(Button btn)
        {
            for (int i =0; i<11; i++)
            {
                for (int j = 0; j<11; j++)
                {
                    if(playerButtons[i,j] == btn)
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return Tuple.Create(-1, -1);
        }

        //find button in computer buttons array and return position
        public Tuple<int, int> indexOfComputerButton(Button btn)
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (computerButtons[i,j] == btn)
                    {
                        return Tuple.Create(i, j);
                    }
                }
            }
            return Tuple.Create(-1, -1);
        }
        //ΑΠ αεροπλανοφορο 
        //ΑΤ αντιτορπιλικο
        //Π πολεμικο
        //Υ υποβρυχιο
        //check if a boat is hit in the computer's board
        public string checkPlayerMove(int i, int j)
        {
            string result = "";
            if(computerBoard[i,j] == null)
            {
                computerBoard[i, j] = "-";
                computerButtons[i, j].Text = "-";
                computerButtons[i, j].ForeColor = Color.Green;
                //result = "Αστόχησες!";
            }
            else if(computerBoard[i,j] == "ΑΠ")
            {
                computerBoard[i, j] = "X";
                computerButtons[i, j].Text = "X";
                computerButtons[i, j].ForeColor = Color.Red;
                computerAP.Remove(i.ToString() + "," + j.ToString());
                //result = "Τον πέτυχες!";
                if (computerAP.Count == 0)//check if all AP are destroyed
                {
                    result = "Κατέστρεψα το αεροπλανοφόρο!";
                }
            }
            else if (computerBoard[i, j] == "ΑΤ")
            {
                computerBoard[i, j] = "X";
                computerButtons[i, j].Text = "X";
                computerButtons[i, j].ForeColor = Color.Red;
                computerAT.Remove(i.ToString() + "," + j.ToString());
                //result = "Τον πέτυχες!";
                if (computerAT.Count == 0)//check if all AP are destroyed
                {
                    result = "Κατέστρεψα το αντιτορπιλικό!";
                }
            }
            else if (computerBoard[i, j] == "Π")
            {
                computerBoard[i, j] = "X";
                computerButtons[i, j].Text = "X";
                computerButtons[i, j].ForeColor = Color.Red;
                computerP.Remove(i.ToString() + "," + j.ToString());
                //result = "Τον πέτυχες!";
                if (computerP.Count == 0)//check if all AP are destroyed
                {
                    result = "Κατέστρεψα το πολεμικό!";
                }
            }
            else if (computerBoard[i, j] == "Υ")
            {
                computerBoard[i, j] = "X";
                computerButtons[i, j].Text = "X";
                computerButtons[i, j].ForeColor = Color.Red;
                computerY.Remove(i.ToString() + "," + j.ToString());
               // result = "Τον πέτυχες!";
                if (computerY.Count == 0)//check if all AP are destroyed
                {
                    result = "Κατέστρεψα το υποβρύχιο!";
                }
            }
            //if all lists containing boat positions are empty then you win
            if(computerAP.Count ==0 && computerAT.Count==0 && computerP.Count ==0 && computerY.Count == 0)
            {
                result = "Νίκησες!";
            }
            return result;

        }

        //computers move
        public Tuple<int, int> computerMove()
        {
            //get the indexes of all the available moves and randomly pick one
            List<Tuple<int, int>> emptySpots = new List<Tuple<int, int>>();
            for (int i =0; i<11; i++)
            {
                for (int j = 0; j < 11; j++){
                    if (playerBoard[i, j] == null || playerBoard[i, j] =="ΑΤ" || playerBoard[i, j] =="ΑΠ" || playerBoard[i, j] =="Π" || playerBoard[i, j] == "Υ")
                    {
                        emptySpots.Add(Tuple.Create(i, j));
                    }
                }
            }
            int index = rand.Next(emptySpots.Count);
            return emptySpots[index];
        }


        //ΑΠ αεροπλανοφορο 
        //ΑΤ αντιτορπιλικο
        //Π πολεμικο
        //Υ υποβρυχιο
        //check if a boat is hit in the computer's board
        public string checkComputerMove(int i, int j)
        {
            string result = "";
            if (playerBoard[i, j] == null)
            {
                playerBoard[i, j] = "-";
                playerButtons[i, j].Text = "-";
                playerButtons[i, j].ForeColor = Color.Green;
                //result = "Αστόχησες!";
            }
            else if (playerBoard[i, j] == "ΑΠ")
            {
                playerBoard[i, j] = "X";
                playerButtons[i, j].Text = "X";
                playerButtons[i, j].ForeColor = Color.Red;
                playerAP.Remove(i.ToString() + "," + j.ToString());
                //result = "Τον πέτυχες!";
                if (playerAP.Count == 0)//check if all AP are destroyed
                {
                    result = "Βυθίστηκε το αεροπλανοφόρο μου!";
                }
            }
            else if (playerBoard[i, j] == "ΑΤ")
            {
                playerBoard[i, j] = "X";
                playerButtons[i, j].Text = "X";
                playerButtons[i, j].ForeColor = Color.Red;
                playerAT.Remove(i.ToString() + "," + j.ToString());
                //result = "Τον πέτυχες!";
                if (playerAT.Count == 0)//check if all AP are destroyed
                {
                    result = "Βυθίστηκε το αντιτορπιλικό μου!";
                }
            }
            else if (playerBoard[i, j] == "Π")
            {
                playerBoard[i, j] = "X";
                playerButtons[i, j].Text = "X";
                playerButtons[i, j].ForeColor = Color.Red;
                playerP.Remove(i.ToString() + "," + j.ToString());
                ///result = "Τον πέτυχες!";
                if (playerP.Count == 0)//check if all AP are destroyed
                {
                    result = "Βυθίστηκε το πολεμικό μου!";
                }
            }
            else if (playerBoard[i, j] == "Υ")
            {
                playerBoard[i, j] = "X";
                playerButtons[i, j].Text = "X";
                playerButtons[i, j].ForeColor = Color.Red;
                playerY.Remove(i.ToString() + "," + j.ToString());
                //result = "Τον πέτυχες!";
                if (playerY.Count == 0)//check if all AP are destroyed
                {
                    result = "Βυθίστηκε το υποβρυχιό μου";
                }
            }
            //if all lists containing boat positions are empty then you win
            if (playerAP.Count == 0 && playerAT.Count == 0 && playerP.Count == 0 && playerY.Count == 0)
            {
                result = "Έχασες!";
            }
            return result;

        }

        //reset arrays
        public void resetArrays()
        {
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    playerBoard[i, j] = null;
                    computerBoard[i, j] = null;
                    playerButtons[i, j].Text = null;
                    computerButtons[i, j].Text = null;
                }
            }
            //
            playerBoard[0, 0] = "0";
            playerBoard[0, 1] = "Α";
            playerBoard[0, 2] = "Β";
            playerBoard[0, 3] = "Γ";
            playerBoard[0, 4] = "Δ";
            playerBoard[0, 5] = "Ε";
            playerBoard[0, 6] = "Ζ";
            playerBoard[0, 7] = "Η";
            playerBoard[0, 8] = "Θ";
            playerBoard[0, 9] = "Ι";
            playerBoard[0, 10] = "Κ";
            //
            computerBoard[0, 0] = "0";
            computerBoard[0, 1] = "Α";
            computerBoard[0, 2] = "Β";
            computerBoard[0, 3] = "Γ";
            computerBoard[0, 4] = "Δ";
            computerBoard[0, 5] = "Ε";
            computerBoard[0, 6] = "Ζ";
            computerBoard[0, 7] = "Η";
            computerBoard[0, 8] = "Θ";
            computerBoard[0, 9] = "Ι";
            computerBoard[0, 10] = "Κ";
            //
            for (int i = 1; i < 11; i++)
            {
                playerBoard[i, 0] = i.ToString();
                computerBoard[i, 0] = i.ToString();
            }
            //create buttons
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    //player buttons initialize
                    if (playerBoard[i, j] != null)
                    {
                        playerButtons[i, j].Enabled = false;                        
                    }
                    playerButtons[i, j].ForeColor = Color.Black;
                    playerButtons[i, j].Text = playerBoard[i, j];
                    //computer buttons initialize             
                    if (computerBoard[i, j] != null)
                    {
                        computerButtons[i, j].Enabled = false;
                    }
                    computerButtons[i, j].Text = computerBoard[i, j];                   
                }
            }
            PlacePlayerBoats();
        }
    }

}



