using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Agricola
{
    public partial class MainBoard : Form
    {
        GameSetup g;
        Utilities u;
        ScoreBoard s;
        bool harvest;
        int harvestCounter;
        bool harvestOver;
        int t; //Turn status

        public MainBoard(GameSetup game)
        {
            g = game;
            u = new Utilities();
            harvest = false;
            harvestCounter = 0;
            harvestOver = false;
            t = 0; 

            g.initializePlayers(this);
            s = new ScoreBoard(g);
            InitializeComponent();
        }

        public void endTurn()
        {            
            if (!harvest) { t = g.endPlayerTurn(); }
            
			//Harvest kallas i början av rundan efter snarare än slutet av aktuell runda. Rundan tickar inte upp till 15 utan 14 kallas två gånger
            if ((g.round == 5 || g.round == 8 || g.round == 10 || g.round == 12 || g.round == 14) && !harvest && t >= 1)
            { 
                g.fieldPhase();
                harvest = true;
                harvestCounter = 0;
                g.players[0].board.doneIndicator = 0;
                this.Hide();
            }

            if (harvestOver) 
            { 
            	if (t == 2) //end of the game
                {
                    this.Close();
                }
            	else
            	{
	            	harvest = false; 
	            	harvestOver = false;
					harvestCounter = 0;	            	
	            	this.Show(); 
            	}
            }

            if (harvest) { harvesting(); }
            else
            {
                if (t == 1)
                {
                    u.enableCardText(this, g);
                    u.enableButtons(this, g);
                    for (int i = 0; i < g.nPlayers; i++) { g.players[i].newBorn = 0; }
                }
                this.currentPlayerText.Text = System.String.Format("Player {0}", g.currentPlayer + 1);
                this.Activate();
            }
        }

        private void harvesting()
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            if (thisPlayer.board.doneIndicator == 0)
            {
                thisPlayer.board.Show();
                thisPlayer.board.Activate();
                thisPlayer.board.calledBy = 13;
                thisPlayer.board.infoBox.Text = "Produce food for harvest";
                thisPlayer.board.doneButton.Visible = true;
                u.enableMajImprovButtons(thisPlayer.board, thisPlayer.boughtMajImprov, false);
                thisPlayer.board.well.Visible = false;
                thisPlayer.board.clayOven.Visible = false;
                thisPlayer.board.stoneOven.Visible = false;
                thisPlayer.board.radioSheep.Visible = true;
                thisPlayer.board.radioBoars.Visible = true;
                thisPlayer.board.radioCattle.Visible = true;
                thisPlayer.board.radioGrain.Visible = true;
                thisPlayer.board.radioVegetables.Visible = true;
                thisPlayer.board.spareButton.Visible = true;
                thisPlayer.board.spareButton.Text = "Eat raw";
            }

            if (thisPlayer.board.doneIndicator == 1)
            {
            	
            	thisPlayer.resources[9] -= thisPlayer.maxMembers * g.foodConsumption -thisPlayer.newBorn*(g.foodConsumption-1); //eating            	
                if (thisPlayer.resources[9] < 0)
                {
                	int scoreLoss = thisPlayer.resources[9] * 3;
                    thisPlayer.baseScore += scoreLoss;
                    thisPlayer.resources[9] = 0;
                    thisPlayer.board.infoBox.Text = System.String.Format("You just lost {0} points", scoreLoss*(-1));
                }
                thisPlayer.board.updateBoard();
                
                for (int i = 6; i < 9; i++) //Breeding
                {
                    if (thisPlayer.resources[i] >= 2) { thisPlayer.resources[i]++; }
                }
                
                thisPlayer.board.radioGrain.Visible = false;
                thisPlayer.board.radioVegetables.Visible = false;
                thisPlayer.board.spareButton.Visible = false;
                thisPlayer.board.laborerR.Visible = true;
                thisPlayer.board.laborerR.Text = "Release";
                thisPlayer.board.infoBox.Text = "Allocate animals";
                thisPlayer.board.calledBy = 14;
                thisPlayer.board.livestockAllocation();
                thisPlayer.board.hideMajImprovs();
                thisPlayer.board.allocating = true;
            }

            if (thisPlayer.board.doneIndicator == 2)
            {
                thisPlayer.board.doneButton.Visible = false;
                thisPlayer.board.radioBoars.Visible = false;
                thisPlayer.board.radioCattle.Visible = false;
                thisPlayer.board.radioSheep.Visible = false;
                thisPlayer.board.laborerR.Visible = false;
                thisPlayer.board.allocating = false;
                thisPlayer.board.doneIndicator = 0;
                thisPlayer.board.infoBox.Text = "";
                harvestCounter++;
                if (harvestCounter >= g.nPlayers)
                {
                    harvestOver = true;
                    
                }
                
                thisPlayer.board.doneIndicator = 0;
                g.currentPlayer++;
            	g.currentPlayer = g.currentPlayer % g.nPlayers;
                endTurn();
            }
        }



        public void bRooms_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            if (thisPlayer.board.doneIndicator == 0)
            {
                this.Hide();
                thisPlayer.board.Show();
                thisPlayer.board.Activate();
                thisPlayer.board.calledBy = 1;
                thisPlayer.board.infoBox.Text = "Click the farmyard space to improve";
            }

            if (thisPlayer.board.doneIndicator == 2)
            {
                this.bRooms.Enabled = false;
                this.bRooms.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }

            if(thisPlayer.board.doneIndicator > 0)
            {
                this.Show();
                thisPlayer.board.room.Visible = false;
                thisPlayer.board.stable.Visible = false;
                thisPlayer.board.doneButton.Visible = false;
                thisPlayer.board.doneIndicator = 0;
                thisPlayer.board.infoBox.Text = "";
            }
        }

        private void startingP_Click(object sender, EventArgs e)
        {
            g.startingPlayer = g.currentPlayer;
            g.players[g.currentPlayer].resources[9] += g.nStartingP;
            g.players[g.currentPlayer].board.updateBoard();
            g.nStartingP = 0;
            this.startingP.Enabled = false;
            this.startingP.BackColor = u.playerColor(g.currentPlayer);
            endTurn();
        }

        private void tGrain_Click(object sender, EventArgs e)
        {
            g.players[g.currentPlayer].resources[4] += 1;
            this.tGrain.Enabled = false;
            this.tGrain.BackColor = u.playerColor(g.currentPlayer);
            endTurn();
        }

        public void plow_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            if (thisPlayer.board.doneIndicator == 0)
            {
                this.Hide();
                thisPlayer.board.Show();
                thisPlayer.board.Activate();
                thisPlayer.board.calledBy = 2;
                thisPlayer.board.infoBox.Text = "Click an empty space to plow a/o 'Done'";
                thisPlayer.board.doneButton.Visible = true;
            }
            if (thisPlayer.board.doneIndicator == 2)
            {
                this.plow.Enabled = false;
                this.plow.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }

            if (thisPlayer.board.doneIndicator > 0)
            {
                this.Show();
                thisPlayer.board.doneIndicator = 0;
                thisPlayer.board.infoBox.Text = "";
                thisPlayer.board.doneButton.Visible = false;
            }
        }

        public void bStable_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            if (thisPlayer.board.doneIndicator == 0)
            {
                this.Hide();
                thisPlayer.board.Show();
                thisPlayer.board.Activate();
                thisPlayer.board.calledBy = 3;
                thisPlayer.board.infoBox.Text = "Click a space to build or buttons to bake";
                thisPlayer.board.doneButton.Visible = true;
                u.enableMajImprovButtons(thisPlayer.board, thisPlayer.boughtMajImprov, true);
            }

            if (thisPlayer.board.doneIndicator == 2)
            {
                this.bStable.Enabled = false;
                this.bStable.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }

            if (thisPlayer.board.doneIndicator > 0)
            {
                this.Show();
                thisPlayer.board.stable.Visible = false;
                thisPlayer.board.doneButton.Visible = false;
                thisPlayer.board.doneIndicator = 0;
                thisPlayer.board.infoBox.Text = "";
            }
        }

        public void laborer_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];

            if (thisPlayer.board.doneIndicator == 0)
            {
                thisPlayer.resources[9]++;
                thisPlayer.board.calledBy = -1;

                this.Hide();
                thisPlayer.board.Show();
                thisPlayer.board.Activate();
                thisPlayer.board.infoBox.Text = "Click the resource you fancy";
                thisPlayer.board.laborerW.Visible = true;
                thisPlayer.board.laborerC.Visible = true;
                thisPlayer.board.laborerS.Visible = true;
                thisPlayer.board.laborerR.Visible = true;
                thisPlayer.board.laborerR.Text = "Reed";
                thisPlayer.board.doneIndicator = 2;
            }
            else
            {
                this.Show();
                thisPlayer.board.doneIndicator = 0;
                thisPlayer.board.infoBox.Text = "";
                thisPlayer.board.updateBoard();
                this.laborer.Enabled = false;
                this.laborer.BackColor = u.playerColor(g.currentPlayer);                
                endTurn();
            }
        }

        private void tWood3_Click(object sender, EventArgs e)
        {
            g.players[g.currentPlayer].resources[0] += g.nTWood3;
            g.nTWood3 = 0;
            this.tWood3.Enabled = false;
            this.tWood3.BackColor = u.playerColor(g.currentPlayer);
            g.players[g.currentPlayer].board.updateBoard();
            endTurn();
        }

        private void tClay1_Click(object sender, EventArgs e)
        {
            g.players[g.currentPlayer].resources[1] += g.nTClay1;
            g.nTClay1 = 0;
            this.tClay1.Enabled = false;
            this.tClay1.BackColor = u.playerColor(g.currentPlayer);
            g.players[g.currentPlayer].board.updateBoard();
            endTurn();
        }

        private void tReed1_Click(object sender, EventArgs e)
        {
            g.players[g.currentPlayer].resources[3] += g.nTReed1;
            g.nTReed1 = 0;
            this.tReed1.Enabled = false;
            this.tReed1.BackColor = u.playerColor(g.currentPlayer);
            g.players[g.currentPlayer].board.updateBoard();
            endTurn();
        }

        private void fishing_Click(object sender, EventArgs e)
        {
            g.players[g.currentPlayer].resources[9] += g.nFishing;
            g.nFishing = 0;
            this.fishing.Enabled = false;
            this.fishing.BackColor = u.playerColor(g.currentPlayer);
            g.players[g.currentPlayer].board.updateBoard();
            endTurn();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.startButton.Visible = false;
            this.showScore.Enabled = true;
            endTurn();
        }

        private void bRound1_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[0],this))
            {
                this.bRound1.Enabled = false;
                this.bRound1.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound2_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[1],this))
            {
                this.bRound2.Enabled = false;
                this.bRound2.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound3_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[2],this))
            {
                this.bRound3.Enabled = false;
                this.bRound3.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound4_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[3],this))
            {
                this.bRound4.Enabled = false;
                this.bRound4.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound5_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[4],this))
            {
                this.bRound5.Enabled = false;
                this.bRound5.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound6_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[5],this))
            {
                this.bRound6.Enabled = false;
                this.bRound6.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound7_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[6],this))
            {
                this.bRound7.Enabled = false;
                this.bRound7.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound8_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[7],this))
            {
                this.bRound8.Enabled = false;
                this.bRound8.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound9_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[8],this))
            {
                this.bRound9.Enabled = false;
                this.bRound9.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound10_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[9],this))
            {
                this.bRound10.Enabled = false;
                this.bRound10.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound11_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[10],this))
            {
                this.bRound11.Enabled = false;
                this.bRound11.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound12_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[11],this))
            {
                this.bRound12.Enabled = false;
                this.bRound12.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void bRound13_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[12],this))
            {
                this.bRound13.BackColor = u.playerColor(g.currentPlayer);
                this.bRound13.Enabled = false;
                endTurn();
            }
        }

        private void bRound14_Click(object sender, EventArgs e)
        {
            if (u.actions(g, g.roundCardOrder[13],this))
            {
                this.bRound14.Enabled = false;
                this.bRound14.BackColor = u.playerColor(g.currentPlayer);
                endTurn();
            }
        }

        private void showScore_Click(object sender, EventArgs e)
        {
            if (s.IsDisposed)
            {
                s = new ScoreBoard(g);
            }
            else
            {
                s.Show();
                s.scoring(g);
            }
        }
    }
}
