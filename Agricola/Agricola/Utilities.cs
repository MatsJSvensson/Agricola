using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agricola
{
    public class Utilities
    {
        public int[][] neighbourMatrix;

        public Utilities()
        {
            neighbourMatrix = new int[15][];
            
            neighbourMatrix[0] = new int[8] { -1, -1, 1, 5, 20, 0, 21, 5}; //Space left,top,right,bot fence left,top,right,bot
            neighbourMatrix[1] = new int[8] { 0, -1, 2, 6, 21, 1, 22, 6 };
            neighbourMatrix[2] = new int[8] { 1, -1, 3, 7, 22, 2, 23, 7 };
            neighbourMatrix[3] = new int[8] { 2, -1, 4, 8, 23, 3, 24, 8 };
            neighbourMatrix[4] = new int[8] { 3, -1, -1, 9, 24, 4, 25, 9 };

            neighbourMatrix[5] = new int[8] { -1, 0, 6, 10, 26, 5, 27, 10 };
            neighbourMatrix[6] = new int[8] { 5, 1, 7, 11, 27, 6, 28, 11 };
            neighbourMatrix[7] = new int[8] { 6, 2, 8, 12, 28, 7, 29, 12 };
            neighbourMatrix[8] = new int[8] { 7, 3, 9, 13, 29, 8, 30, 13 };
            neighbourMatrix[9] = new int[8] { 8, 4, -1, 14, 30, 9, 31, 14 };

            neighbourMatrix[10] = new int[8] { -1, 5, 11, -1, 32, 10, 33, 15 };
            neighbourMatrix[11] = new int[8] { 10, 6, 12, -1, 33, 11, 34, 16 };
            neighbourMatrix[12] = new int[8] { 11, 7, 13, -1, 34, 12, 35, 17 };
            neighbourMatrix[13] = new int[8] { 12, 8, 14, -1, 35, 13, 36, 18 };
            neighbourMatrix[14] = new int[8] { 13, 9, -1, -1, 36, 14, 37, 19 };
        }

        public void enableCardText(MainBoard m, GameSetup g)
        {
            int card = g.roundCardOrder[g.round-1]+1;
            switch (g.round)
            {
                case 14:
                    m.bRound14.Text = roundCardText(card);
                    break;
                case 13:
                    m.bRound13.Text = roundCardText(card);
                    break;
                case 12:
                    m.bRound12.Text = roundCardText(card);
                    break;
                case 11:
                    m.bRound11.Text = roundCardText(card);
                    break;
                case 10:
                    m.bRound10.Text = roundCardText(card);
                    break;
                case 9:
                    m.bRound9.Text = roundCardText(card);
                    break;
                case 8:
                    m.bRound8.Text = roundCardText(card);
                    break;
                case 7:
                    m.bRound7.Text = roundCardText(card);
                    break;
                case 6:
                    m.bRound6.Text = roundCardText(card);
                    break;
                case 5:
                    m.bRound5.Text = roundCardText(card);
                    break;
                case 4:
                    m.bRound4.Text = roundCardText(card);
                    break;
                case 3:
                    m.bRound3.Text = roundCardText(card);
                    break;
                case 2:
                    m.bRound2.Text = roundCardText(card);
                    break;
                case 1:
                    m.bRound1.Text = roundCardText(card);
                    break;
                default:
                    break;
            }
        }

        public string roundCardText(int n)
        {
            string cardText;
            switch (n)
            {
                case 1:
                    cardText = "Take 1 Sheep (increase 1)";
                    break;
                case 2:
                    cardText = "Build Fences (1 wood/fence)";
                    break;
                case 3:
                    cardText = "Major Improvement";
                    break;
                case 4:
                    cardText = "Sow a/o Bake Bread";
                    break;
                case 5:
                    cardText = "Take # Stone (increase 1)";
                    break;
                case 6:
                    cardText = "Family growth";
                    break;
                case 7:
                    cardText = "After Renovation also Major Improvement";
                    break;
                case 8:
                    cardText = "Take # Wild Boars (increase 1)";
                    break;
                case 9:
                    cardText = "Take 1 Vegetable";
                    break;
                case 10:
                    cardText = "Take # Stone (increase 1)";
                    break;
                case 11:
                    cardText = "Take # Cattle (increase 1)";
                    break;
                case 12:
                    cardText = "Plow a/o Sow";
                    break;
                case 13:
                    cardText = "Family Growth (even without space)";
                    break;
                case 14:
                    cardText = "After Renovation also Fences";
                    break;
                default:
                    cardText = "Cardtext?";
                    break;
            }
            return cardText;
        }

        public void enableButtons(MainBoard m, GameSetup g)
        {
            switch (g.round)
            {
                case 14:
                    m.bRound14.Enabled = true;
                    m.bRound14.BackColor = System.Drawing.SystemColors.Control;
                    goto case 13;
                case 13:
                    m.bRound13.Enabled = true;
                    m.bRound13.BackColor = System.Drawing.SystemColors.Control;
                    goto case 12;
                case 12:
                    m.bRound12.Enabled = true;
                    m.bRound12.BackColor = System.Drawing.SystemColors.Control;
                    goto case 11;
                case 11:
                    m.bRound11.Enabled = true;
                    m.bRound11.BackColor = System.Drawing.SystemColors.Control;
                    goto case 10;
                case 10:
                    m.bRound10.Enabled = true;
                    m.bRound10.BackColor = System.Drawing.SystemColors.Control;
                    goto case 9;
                case 9:
                    m.bRound9.Enabled = true;
                    m.bRound9.BackColor = System.Drawing.SystemColors.Control;
                    goto case 8;
                case 8:
                    m.bRound8.Enabled = true;
                    m.bRound8.BackColor = System.Drawing.SystemColors.Control;
                    goto case 7;
                case 7:
                    m.bRound7.Enabled = true;
                    m.bRound7.BackColor = System.Drawing.SystemColors.Control;
                    goto case 6;
                case 6:
                    m.bRound6.Enabled = true;
                    m.bRound6.BackColor = System.Drawing.SystemColors.Control;
                    goto case 5;
                case 5:
                    m.bRound5.Enabled = true;
                    m.bRound5.BackColor = System.Drawing.SystemColors.Control;
                    goto case 4;
                case 4:
                    m.bRound4.Enabled = true;
                    m.bRound4.BackColor = System.Drawing.SystemColors.Control;
                    goto case 3;
                case 3:
                    m.bRound3.Enabled = true;
                    m.bRound3.BackColor = System.Drawing.SystemColors.Control;
                    goto case 2;
                case 2:
                    m.bRound2.Enabled = true;
                    m.bRound2.BackColor = System.Drawing.SystemColors.Control;
                    goto case 1;
                case 1:
                    m.bRound1.Enabled = true;
                    m.bRound1.BackColor = System.Drawing.SystemColors.Control;
                    break;
                default:
                    break;
            }

            m.bRooms.Enabled = true;
            m.bRooms.BackColor = System.Drawing.SystemColors.Control;
            m.startingP.Enabled = true;
            m.startingP.Text = System.String.Format("Starting Player and {0} food", g.nStartingP);
            m.startingP.BackColor = System.Drawing.SystemColors.Control;
            m.tGrain.Enabled = true;
            m.tGrain.BackColor = System.Drawing.SystemColors.Control;
            m.plow.Enabled = true;
            m.plow.BackColor = System.Drawing.SystemColors.Control;
            m.bStable.Enabled = true;
            m.bStable.BackColor = System.Drawing.SystemColors.Control;
            m.laborer.Enabled = true;
            m.laborer.BackColor = System.Drawing.SystemColors.Control;
            m.tWood3.Enabled = true;
            m.tWood3.Text = System.String.Format("Take {0} wood (increase {1})", g.nTWood3, g.woodGain);
            m.tWood3.BackColor = System.Drawing.SystemColors.Control;
            m.tClay1.Enabled = true;
            m.tClay1.Text = System.String.Format("Take {0} clay (increase 1)", g.nTClay1);
            m.tClay1.BackColor = System.Drawing.SystemColors.Control;
            m.tReed1.Enabled = true;
            m.tReed1.Text = System.String.Format("Take {0} reed (increase 1)", g.nTReed1);
            m.tReed1.BackColor = System.Drawing.SystemColors.Control;
            m.fishing.Enabled = true;
            m.fishing.Text = System.String.Format("Take {0} food (increase 1)", g.nFishing);
            m.fishing.BackColor = System.Drawing.SystemColors.Control;

            if (g.enabledRoundCards[0])
            { resourceTexts(Array.IndexOf(g.roundCardOrder, 0), System.String.Format("Take {0} Sheep (increase 1)", g.nSheep), m); }
            if (g.enabledRoundCards[4])
            { resourceTexts(Array.IndexOf(g.roundCardOrder, 4), System.String.Format("Take {0} Stone (increase 1)", g.nStoneStage2), m); }
            if (g.enabledRoundCards[7])
            { resourceTexts(Array.IndexOf(g.roundCardOrder, 7), System.String.Format("Take {0} Wild Boars (increase 1)", g.nBoars), m); }
            if (g.enabledRoundCards[9])
            { resourceTexts(Array.IndexOf(g.roundCardOrder, 9), System.String.Format("Take {0} Stone (increase 1)", g.nStoneStage4), m); }
            if (g.enabledRoundCards[10])
            { resourceTexts(Array.IndexOf(g.roundCardOrder, 10), System.String.Format("Take {0} Cattle (increase 1)", g.nCattle), m); }
        }

        public void disableRoundCards(MainBoard m, int cardNumber, int playerNumber)
        {
            switch (cardNumber)
            {
                case 0:
                    m.bRound1.Enabled = false;
                    m.bRound1.BackColor = playerColor(playerNumber);
                    break;
                case 1:
                    m.bRound2.Enabled = false;
                    m.bRound2.BackColor = playerColor(playerNumber);
                    break;
                case 2:
                    m.bRound3.Enabled = false;
                    m.bRound3.BackColor = playerColor(playerNumber);
                    break;
                case 3:
                    m.bRound4.Enabled = false;
                    m.bRound4.BackColor = playerColor(playerNumber);
                    break;
                case 4:
                    m.bRound5.Enabled = false;
                    m.bRound5.BackColor = playerColor(playerNumber);
                    break;
                case 5:
                    m.bRound6.Enabled = false;
                    m.bRound6.BackColor = playerColor(playerNumber);
                    break;
                case 6:
                    m.bRound7.Enabled = false;
                    m.bRound7.BackColor = playerColor(playerNumber);
                    break;
                case 7:
                    m.bRound8.Enabled = false;
                    m.bRound8.BackColor = playerColor(playerNumber);
                    break;
                case 8:
                    m.bRound9.Enabled = false;
                    m.bRound9.BackColor = playerColor(playerNumber);
                    break;
                case 9:
                    m.bRound10.Enabled = false;
                    m.bRound10.BackColor = playerColor(playerNumber);
                    break;
                case 10:
                    m.bRound11.Enabled = false;
                    m.bRound11.BackColor = playerColor(playerNumber);
                    break;
                case 11:
                    m.bRound12.Enabled = false;
                    m.bRound12.BackColor = playerColor(playerNumber);
                    break;
                case 12:
                    m.bRound13.Enabled = false;
                    m.bRound13.BackColor = playerColor(playerNumber);
                    break;
                case 13:
                    m.bRound14.Enabled = false;
                    m.bRound14.BackColor = playerColor(playerNumber);
                    break;
            }
        }

        public System.Drawing.Color playerColor(int n)
        {
            System.Drawing.Color col;
            switch (n)
            {
                case 0:
                    col = System.Drawing.Color.Red;
                    break;
                case 1:
                    col = System.Drawing.Color.Blue;
                    break;
                case 2:
                    col = System.Drawing.Color.Green;
                    break;
                case 3:
                    col = System.Drawing.Color.Purple;
                    break;
                case 4:
                    col = System.Drawing.Color.White;
                    break;
                default:
                    col = System.Drawing.Color.Red;
                    break;
            }
            return col;
        }

        public System.Drawing.Color spaceColor(char c)
        {
            System.Drawing.Color col = System.Drawing.Color.Lime;

            switch (c)
            {
                case 'w':
                    col = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
                    break;
                case 'c':
                    col = System.Drawing.Color.SandyBrown;
                    break;
                case 's':
                    col = System.Drawing.Color.DimGray;
                    break;
                case 'p':
                    col = System.Drawing.Color.YellowGreen;
                    break;
                case 'f':
                    col = System.Drawing.Color.DarkGoldenrod;
                    break;
                case 'b':
                    col = System.Drawing.Color.Tomato;
                    break;
                case 'h':
                    col = System.Drawing.Color.Tomato;
                    break;
                case 'e':
                    col = System.Drawing.Color.Lime;
                    break;
                case 'u':
                    col = System.Drawing.Color.Orange;
                    break;
                case 'v':
                    col = System.Drawing.Color.DarkOrange;
                    break;
                case 'x':
                    col = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(100)))));
                    break;
                case 'y':
                    col = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(64)))));
                    break;
                case 'z':
                    col = System.Drawing.Color.Yellow;
                    break;
            }
            return col;
        }

        public bool actions(GameSetup g, int n, MainBoard m)
        {
            bool success = false;
            char newSort = 'c';
            int newType = 1;
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch(n)
            {
                case 0: //Sheep
                    if (thisPlayer.board.doneIndicator == 0)
                    {
                        thisPlayer.resources[6] += g.nSheep;
                        thisPlayer.board.nSheep.Text = thisPlayer.resources[6].ToString();
                        g.nSheep = 0;
                        m.Hide();
                        thisPlayer.board.Show();
                        thisPlayer.board.Activate();
                        thisPlayer.board.calledBy = 7;
                        thisPlayer.board.doneButton.Visible = true;
                        thisPlayer.board.livestockAllocation();
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.doneButton.Visible = false;
                        thisPlayer.board.radioBoars.Visible = false;
                        thisPlayer.board.radioCattle.Visible = false;
                        thisPlayer.board.radioSheep.Visible = false;
                        thisPlayer.board.laborerR.Visible = false;
                        thisPlayer.board.infoBox.Text = "";
                        thisPlayer.board.hideMajImprovs();
                        if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 0), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }
                    break;
                case 1: //Fence
                    if (thisPlayer.board.doneIndicator == 0)
                    {
                        m.Hide();
                        thisPlayer.board.Show();
                        thisPlayer.board.Activate();
                        thisPlayer.board.calledBy = 6;
                        thisPlayer.board.infoBox.Text = "Click the fences you want and then done";
                        thisPlayer.board.doneButton.Visible = true;
                        thisPlayer.board.showFences();
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.doneButton.Visible = false;
                        thisPlayer.board.radioBoars.Visible = false;
                        thisPlayer.board.radioCattle.Visible = false;
                        thisPlayer.board.radioSheep.Visible = false;
                        thisPlayer.board.infoBox.Text = "";
                        if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 1), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }
                    break;
                case 2: //Major Improv
                    
                    if (thisPlayer.board.doneIndicator == 0)
                    {
                        m.Hide();
                        thisPlayer.board.Show();
                        thisPlayer.board.Activate();
                        thisPlayer.board.calledBy = 4;
                        thisPlayer.board.infoBox.Text = "Build the improvement you want or click done";
                        thisPlayer.board.doneButton.Visible = true;
                        this.enableMajImprovButtons(thisPlayer.board, g.availableMajImprov,false);
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.doneButton.Visible = false;
                        thisPlayer.board.infoBox.Text = "";
                        thisPlayer.board.hideMajImprovs();
                        if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 2), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }
                    break;
                case 3: //Sow/Bake
                    if (thisPlayer.board.doneIndicator == 0)
                    {
                        m.Hide();
                        thisPlayer.board.Show();
                        thisPlayer.board.Activate();
                        thisPlayer.board.calledBy = 5;
                        thisPlayer.board.infoBox.Text = "Choose field and crop to sow or improvement to bake";
                        thisPlayer.board.doneButton.Visible = true;
                        enableMajImprovButtons(thisPlayer.board, thisPlayer.boughtMajImprov, true);
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.doneButton.Visible = false;
                        thisPlayer.board.infoBox.Text = "";
                        thisPlayer.board.hideMajImprovs();
                        if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 3), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }
                    break;
                case 4: //Stone
                    g.players[g.currentPlayer].resources[2] += g.nStoneStage2;
                    g.nStoneStage2 = 0;
                    success = true;
                    break;
                case 5: //Family growth
                    if (thisPlayer.maxMembers < g.players[g.currentPlayer].nRooms && thisPlayer.maxMembers < 5)
                    {
                        thisPlayer.maxMembers++;
                        success = true;
                        thisPlayer.newBorn++;
                    }
                    break;
                case 6: //Renovation + Improv
                    if (thisPlayer.houseSort == 'w') { newType = 1; newSort = 'c'; }
                    if (thisPlayer.houseSort == 'c') { newType = 2; newSort = 's'; }

                    if (thisPlayer.board.doneIndicator == 0 && thisPlayer.houseSort != 's')
                    {
                        if (thisPlayer.resources[newType] >= thisPlayer.nRooms && thisPlayer.resources[3] >= 1)
                        {
                            thisPlayer.resources[newType] -= thisPlayer.nRooms;
                            thisPlayer.resources[3] -= 1;
                            for (int i = 0; i < 15; i++)
                            {
                                if (thisPlayer.farmSpaces[i] == thisPlayer.houseSort) { thisPlayer.farmSpaces[i] = newSort; }
                            }
                            thisPlayer.houseSort = newSort;
                            thisPlayer.houseType = newType;
                            m.Hide();
                            thisPlayer.board.updateBoard();
                            thisPlayer.board.Show();
                            thisPlayer.board.Activate();
                            thisPlayer.board.calledBy = 10;
                            thisPlayer.board.infoBox.Text = "Build the improvement you want or click done";
                            thisPlayer.board.doneButton.Visible = true;
                            this.enableMajImprovButtons(thisPlayer.board, g.availableMajImprov, false);
                        }
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.doneButton.Visible = false;
                        thisPlayer.board.infoBox.Text = "";
                        thisPlayer.board.hideMajImprovs();
                        if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 6), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }                    
                    break;
                case 7: //Boars
                    
                    if (thisPlayer.board.doneIndicator == 0)
                    {
                        thisPlayer.resources[7] += g.nBoars;
                        g.nBoars = 0;
                        thisPlayer.board.nBoars.Text = thisPlayer.resources[7].ToString();
                        m.Hide();
                        thisPlayer.board.Show();
                        thisPlayer.board.Activate();
                        thisPlayer.board.calledBy = 8;
                        thisPlayer.board.doneButton.Visible = true;
                        thisPlayer.board.livestockAllocation();
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.doneButton.Visible = false;
                        thisPlayer.board.radioBoars.Visible = false;
                        thisPlayer.board.radioCattle.Visible = false;
                        thisPlayer.board.radioSheep.Visible = false;
                        thisPlayer.board.laborerR.Visible = false;
                        thisPlayer.board.infoBox.Text = "";
                        thisPlayer.board.hideMajImprovs();
                        if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 7), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }
                    break;
                case 8: //Veggie
                    g.players[g.currentPlayer].resources[5] += 1;
                    success = true;
                    break;
                case 9: //Stone
                    g.players[g.currentPlayer].resources[2] += g.nStoneStage4;
                    g.nStoneStage4 = 0;
                    success = true;
                    break;
                case 10: //Cattle
                    
                    if (thisPlayer.board.doneIndicator == 0)
                    {
                        thisPlayer.resources[8] += g.nCattle;
                        g.nCattle = 0;
                        thisPlayer.board.nCattle.Text = thisPlayer.resources[8].ToString();
                        m.Hide();
                        thisPlayer.board.Show();
                        thisPlayer.board.Activate();
                        thisPlayer.board.calledBy = 9;
                        thisPlayer.board.doneButton.Visible = true;
                        thisPlayer.board.livestockAllocation();
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.doneButton.Visible = false;
                        thisPlayer.board.radioBoars.Visible = false;
                        thisPlayer.board.radioCattle.Visible = false;
                        thisPlayer.board.radioSheep.Visible = false;
                        thisPlayer.board.laborerR.Visible = false;
                        thisPlayer.board.infoBox.Text = "";
                        thisPlayer.board.hideMajImprovs();
                        if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 10), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }
                    break;
                case 11: //Plow/Sow
                    if (thisPlayer.board.doneIndicator == 0)
                    {
                        m.Hide();
                        thisPlayer.board.Show();
                        thisPlayer.board.Activate();
                        thisPlayer.board.calledBy = 11;
                        thisPlayer.board.infoBox.Text = "Click an empty space to plow a/o 'Done'";
                        thisPlayer.board.doneButton.Visible = true;
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.infoBox.Text = "";
                        thisPlayer.board.doneButton.Visible = false; if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 11), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }
                    break;
                case 12: //Family crowded
                    if (thisPlayer.maxMembers < 5)
                    {
                        g.players[g.currentPlayer].maxMembers++;
                        success = true;
                        thisPlayer.newBorn++;
                    }
                    break;
                case 13: //Renovation + Fence
                    if(thisPlayer.houseSort == 'w') { newType = 1; newSort = 'c';}
                    if(thisPlayer.houseSort == 'c') { newType = 2; newSort = 's';}
                        
                    if (thisPlayer.board.doneIndicator == 0 && thisPlayer.houseSort != 's')
                    {
                        if (thisPlayer.resources[newType] >= thisPlayer.nRooms && thisPlayer.resources[3] >= 1)
                        {
                            thisPlayer.resources[newType] -= thisPlayer.nRooms;
                            thisPlayer.resources[3] -= 1;
                            for (int i = 0; i < 15; i++)
                            {
                                if (thisPlayer.farmSpaces[i] == thisPlayer.houseSort) { thisPlayer.farmSpaces[i] = newSort; }
                            }
                            thisPlayer.houseSort = newSort;
                            thisPlayer.houseType = newType;
                            m.Hide();
                            thisPlayer.board.Show();
                            thisPlayer.board.Activate();
                            thisPlayer.board.calledBy = 12;
                            thisPlayer.board.infoBox.Text = "Click the fences you want and then done";
                            thisPlayer.board.doneButton.Visible = true;
                            thisPlayer.board.showFences();
                        }
                    }

                    if (thisPlayer.board.doneIndicator > 0)
                    {
                        m.Show();
                        thisPlayer.board.doneButton.Visible = false;
                        thisPlayer.board.radioBoars.Visible = false;
                        thisPlayer.board.radioCattle.Visible = false;
                        thisPlayer.board.radioSheep.Visible = false;
                        thisPlayer.board.infoBox.Text = "";
                        if (thisPlayer.board.doneIndicator == 2)
                        {
                            disableRoundCards(m, Array.IndexOf(g.roundCardOrder, 13), g.currentPlayer);
                            thisPlayer.board.doneIndicator = 0;
                            m.endTurn();
                        }
                        thisPlayer.board.doneIndicator = 0;
                    }
                    break;
                default:
                    break;
            }
            return success;

        }

        public void resourceTexts(int n, string s, MainBoard m)
        {
            switch (n+1)
            {
                case 14:
                    m.bRound14.Text = s;
                    break;
                case 13:
                    m.bRound13.Text = s;
                    break;
                case 12:
                    m.bRound12.Text = s;
                    break;
                case 11:
                    m.bRound11.Text = s;
                    break;
                case 10:
                    m.bRound10.Text = s;
                    break;
                case 9:
                    m.bRound9.Text = s;
                    break;
                case 8:
                    m.bRound8.Text = s;
                    break;
                case 7:
                    m.bRound7.Text = s;
                    break;
                case 6:
                    m.bRound6.Text = s;
                    break;
                case 5:
                    m.bRound5.Text = s;
                    break;
                case 4:
                    m.bRound4.Text = s;
                    break;
                case 3:
                    m.bRound3.Text = s;
                    break;
                case 2:
                    m.bRound2.Text = s;
                    break;
                case 1:
                    m.bRound1.Text = s;
                    break;
                default:
                    break;
            }
        }

        public void enableMajImprovButtons(Form1 board, bool[] improvList,bool bake)
        {
            int finish = 10;
            if (bake) { finish = 7; }
            for (int i = 0; i < finish; i++)
            {
                if (improvList[i])
                {
                    switch (i)
                    {
                        case 0:
                            board.fireplace1.Visible = true;
                            break;
                        case 1:
                            board.fireplace2.Visible = true;
                            break;
                        case 2:
                            board.cookingHearth1.Visible = true;
                            break;
                        case 3:
                            board.cookingHearth2.Visible = true;
                            break;
                        case 4:
                            board.well.Visible = true;
                            break;
                        case 5:
                            board.clayOven.Visible = true;
                            break;
                        case 6:
                            board.stoneOven.Visible = true;
                            break;
                        case 7:
                            board.joinery.Visible = true;
                            break;
                        case 8:
                            board.pottery.Visible = true;
                            break;
                        case 9:
                            board.basketmaker.Visible = true;
                            break;
                    }
                }
            }
            if (bake) { board.well.Visible = false; }
        }

        public bool checkFences(PlayerBoard thisPlayer)
        {
            int[] fences;
            fences = new int[38];
            int[] crossings;
            crossings = new int[24];

            for (int i = 0; i < 38; i++)
            {
                if (thisPlayer.preliminaryFences[i] || thisPlayer.builtFences[i]) { fences[i] = 1; }
                else { fences[i] = 0; }
            }

            crossings[0] = fences[0] + fences[20];
            crossings[1] = fences[0] + fences[1] + fences[21];
            crossings[2] = fences[1] + fences[2] + fences[22];
            crossings[3] = fences[2] + fences[3] + fences[23];
            crossings[4] = fences[3] + fences[4] + fences[24];
            crossings[5] = fences[4] + fences[25];
            crossings[6] = fences[5] + fences[20] + fences[26];
            crossings[7] = fences[5] + fences[6] + fences[21] + fences[27];
            crossings[8] = fences[6] + fences[7] + fences[22] + fences[28];
            crossings[9] = fences[7] + fences[8] + fences[23] + fences[29];
            crossings[10] = fences[8] + fences[9] + fences[24] + fences[30];
            crossings[11] = fences[9] + fences[25] + fences[31];
            crossings[12] = fences[10] + fences[26] + fences[32];
            crossings[13] = fences[10] + fences[11] + fences[27] + fences[33];
            crossings[14] = fences[11] + fences[12] + fences[28] + fences[34];
            crossings[15] = fences[12] + fences[13] + fences[29] + fences[35];
            crossings[16] = fences[13] + fences[14] + fences[30] + fences[36];
            crossings[17] = fences[14] + fences[31] + fences[37];
            crossings[18] = fences[15] + fences[32];
            crossings[19] = fences[15] + fences[16] + fences[33];
            crossings[20] = fences[16] + fences[17] + fences[34];
            crossings[21] = fences[17] + fences[18] + fences[35];
            crossings[22] = fences[18] + fences[19] + fences[36];
            crossings[23] = fences[19] + fences[37];

            bool correct = true;
            for (int i = 0; i < 24; i++) 
            {
                if (crossings[i] == 1) { correct = false; }
            }
            return correct;
        }

        public bool checkPastures(PlayerBoard thisPlayer)
        {
            bool correct = true;
            for (int i = 0; i < 15; i++) { thisPlayer.pastureIndicator[i] = false; }
            resetPastures(thisPlayer);
            thisPlayer.pastureCounter = 1;

            for(int i = 0; i < 15; i++)
            {
                if (!thisPlayer.pastureIndicator[i])
                {
                    if (!pastureChecker(i, thisPlayer, true))
                    {
                        correct = false;
                        break;
                    }
                }
                resetPastures(thisPlayer);
            }
            return correct;
        }

        private bool pastureChecker(int index, PlayerBoard thisPlayer, bool originalCall)
        {
            bool correct = true;
            bool isPasture = true;
            int[][] members = thisPlayer.pastureMembers;
            int[] indices = thisPlayer.pastureIndices;
            int pCounter = thisPlayer.pastureCounter;
            thisPlayer.pastureIndicator[index] = true;

            bool leftFence = (thisPlayer.preliminaryFences[neighbourMatrix[index][4]] || thisPlayer.builtFences[neighbourMatrix[index][4]]);
            bool topFence = (thisPlayer.preliminaryFences[neighbourMatrix[index][5]] || thisPlayer.builtFences[neighbourMatrix[index][5]]);
            bool rightFence = (thisPlayer.preliminaryFences[neighbourMatrix[index][6]] || thisPlayer.builtFences[neighbourMatrix[index][6]]);
            bool botFence = (thisPlayer.preliminaryFences[neighbourMatrix[index][7]] || thisPlayer.builtFences[neighbourMatrix[index][7]]);

            if (leftFence && topFence && originalCall)
            {
                members[pCounter][0] = index;
                indices[pCounter] = 1;
                if (!rightFence)
                {
                    if (!checkSpace(neighbourMatrix[index][2], thisPlayer)) { isPasture = false; }
                }
                if (!botFence)
                {
                    if (!checkSpace(neighbourMatrix[index][3], thisPlayer)) { isPasture = false; }
                }

                if (isPasture)
                {
                    bool hasStable = false;
                    for (int i = 0; i < indices[pCounter]; i++)
                    {
                        if (thisPlayer.farmSpaces[members[pCounter][i]] == 'b' || thisPlayer.farmSpaces[members[pCounter][i]] == 'h') 
                        {
                            if (hasStable) { return false; } //Check for double stables
                            else { hasStable = true; }
                        }
                        else if (thisPlayer.farmSpaces[members[pCounter][i]] == 'p' || thisPlayer.farmSpaces[members[pCounter][i]] == 'e') { } 
                        else { return false; }
                    }
                    thisPlayer.pastureCounter++;
                }

            }

            if (!originalCall)
            {
                members[pCounter][indices[pCounter]] = index;
                indices[pCounter]++;
                if (!leftFence) 
                {
                    if (!checkSpace(neighbourMatrix[index][0], thisPlayer)) { return false; }                     
                }
                if (!topFence)
                {
                    if (!checkSpace(neighbourMatrix[index][1], thisPlayer)) { return false; }
                }
                if (!rightFence)
                {
                    if (!checkSpace(neighbourMatrix[index][2], thisPlayer)) { return false; }
                }
                if (!botFence)
                {
                    if (!checkSpace(neighbourMatrix[index][3], thisPlayer)) { return false; }
                }

            }

            return correct;
        }

        private bool checkSpace(int index, PlayerBoard thisPlayer)
        {
            if (index == -1) { return false; }
            else 
            {
                if (thisPlayer.pastureIndicator[index]) { return true; } //Already checked
                else { return pastureChecker(index, thisPlayer, false); } 
            }
        }

        private void resetPastures(PlayerBoard thisPlayer)
        {
            if (thisPlayer.pastureCounter < 6)
            {
                thisPlayer.pastureIndices[thisPlayer.pastureCounter] = 0;
                for (int i = 0; i < 12; i++)
                {
                    thisPlayer.pastureMembers[thisPlayer.pastureCounter][i] = -1;
                }
            }
        }

        public void confirmFences(PlayerBoard thisPlayer)
        {
            bool hasStable;

            for (int i = 0; i < 38; i++)
            {
                if (thisPlayer.preliminaryFences[i])
                {
                    thisPlayer.builtFences[i] = true;
                    thisPlayer.preliminaryFences[i] = false;
                    thisPlayer.board.built = true;
                }
            }
            for (int i = 1; i < thisPlayer.pastureCounter; i++)
            {
                int stop = thisPlayer.pastureIndices[i];
                hasStable = false;
                for (int j = 0; j < stop; j++)
                {
                    int tile = thisPlayer.pastureMembers[i][j];
                    if (thisPlayer.farmSpaces[tile] == 'e') { thisPlayer.farmSpaces[tile] = 'p'; }
                    if (thisPlayer.farmSpaces[tile] == 'b') { thisPlayer.farmSpaces[tile] = 'h'; }
                    if (thisPlayer.farmSpaces[tile] == 'h') { hasStable = true; }
                }
                thisPlayer.pastureSizes[i] = stop * 2;
                if (hasStable) { thisPlayer.pastureSizes[i] *= 2; }
            }

        }

        public void showPastures(PlayerBoard thisPlayer, int n, string s)
        {
            Form1 board = thisPlayer.board;
            
            board.tileText[n].Visible = true;
            board.tileText[n].Text = s;
            board.tileText[n].BackColor = spaceColor(thisPlayer.farmSpaces[n]);
        }

        public bool hasNeighbour(PlayerBoard thisPlayer, int tile, char thisType)
        {
            int left = neighbourMatrix[tile][0];
            int top = neighbourMatrix[tile][1];
            int right = neighbourMatrix[tile][2];
            int bot = neighbourMatrix[tile][3];
            bool correct = false;

            if (left >= 0)
            {
                if (thisPlayer.farmSpaces[left] == thisType) { return true; }
            }
            if (top >= 0)
            {
                if (thisPlayer.farmSpaces[top] == thisType) { return true; }
            }
            if (right >= 0)
            {
                if (thisPlayer.farmSpaces[right] == thisType) { return true; }
            }
            if (bot >= 0)
            {
                if (thisPlayer.farmSpaces[bot] == thisType) { return true; }
            }
            return correct;
        }
    }
}
