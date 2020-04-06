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
    public partial class Form1 : Form
    {
        GameSetup g;
        MainBoard m;
        int playerNumber;
        public bool built;
        public bool fencesBuilt;
        public int doneIndicator;
        public int calledBy;
        private int chosenFarmSpace;
        private Utilities u;
        private bool ovenUsed;
        public bool allocating;
        private bool sowTime;
        public System.Windows.Forms.Label[] tileText;

        public Form1(GameSetup game, int n, MainBoard mBoard)
        {
            m = mBoard;
            g = game;
            u = new Utilities();
            playerNumber = n;
            built = false;
            fencesBuilt = false;
            ovenUsed = false;
            doneIndicator = 0;
            calledBy = 0;
            chosenFarmSpace = -1;
            allocating = false;
            sowTime = false;
            InitializeComponent();
            
            tileText = new System.Windows.Forms.Label[15];
            tileText[0] = this.pasture1;
            tileText[1] = this.pasture2;
            tileText[2] = this.pasture3;
            tileText[3] = this.pasture4;
            tileText[4] = this.pasture5;
            tileText[5] = this.pasture6;
            tileText[6] = this.pasture7;
            tileText[7] = this.pasture8;
            tileText[8] = this.pasture9;
            tileText[9] = this.pasture10;
            tileText[10] = this.pasture11;
            tileText[11] = this.pasture12;
            tileText[12] = this.pasture13;
            tileText[13] = this.pasture14;
            tileText[14] = this.pasture15;
        }

        public void updateBoard()
        {
            PlayerBoard thisPlayer = g.players[playerNumber];
            this.nWood.Text = thisPlayer.resources[0].ToString();
            this.nClay.Text = thisPlayer.resources[1].ToString();
            this.nStone.Text = thisPlayer.resources[2].ToString();
            this.nReed.Text = thisPlayer.resources[3].ToString();
            this.nGrain.Text = thisPlayer.resources[4].ToString();
            this.nVegetables.Text = thisPlayer.resources[5].ToString();
            this.nSheep.Text = thisPlayer.resources[6].ToString();
            this.nBoars.Text = thisPlayer.resources[7].ToString();
            this.nCattle.Text = thisPlayer.resources[8].ToString();
            this.nFood.Text = thisPlayer.resources[9].ToString();
            this.nMembers.Text = System.String.Format("{0}/{1}", thisPlayer.currentMembers, thisPlayer.maxMembers);

            updateFarmSpaces(thisPlayer);
            this.Show();
        }

        private void updateFarmSpaces(PlayerBoard thisPlayer)
        {
            Utilities u = new Utilities();
            this.pictureBox1.BackColor = u.spaceColor(thisPlayer.farmSpaces[0]);
            this.pictureBox2.BackColor = u.spaceColor(thisPlayer.farmSpaces[1]);
            this.pictureBox3.BackColor = u.spaceColor(thisPlayer.farmSpaces[2]);
            this.pictureBox4.BackColor = u.spaceColor(thisPlayer.farmSpaces[3]);
            this.pictureBox5.BackColor = u.spaceColor(thisPlayer.farmSpaces[4]);
            this.pictureBox6.BackColor = u.spaceColor(thisPlayer.farmSpaces[5]);
            this.pictureBox7.BackColor = u.spaceColor(thisPlayer.farmSpaces[6]);
            this.pictureBox8.BackColor = u.spaceColor(thisPlayer.farmSpaces[7]);
            this.pictureBox9.BackColor = u.spaceColor(thisPlayer.farmSpaces[8]);
            this.pictureBox10.BackColor = u.spaceColor(thisPlayer.farmSpaces[9]);
            this.pictureBox11.BackColor = u.spaceColor(thisPlayer.farmSpaces[10]);
            this.pictureBox12.BackColor = u.spaceColor(thisPlayer.farmSpaces[11]);
            this.pictureBox13.BackColor = u.spaceColor(thisPlayer.farmSpaces[12]);
            this.pictureBox14.BackColor = u.spaceColor(thisPlayer.farmSpaces[13]);
            this.pictureBox15.BackColor = u.spaceColor(thisPlayer.farmSpaces[14]);
        }

        public void hideMajImprovs()
        {
            this.fireplace1.Visible = false;
            this.fireplace2.Visible = false;
            this.cookingHearth1.Visible = false;
            this.cookingHearth2.Visible = false;
            this.well.Visible = false;
            this.clayOven.Visible = false;
            this.stoneOven.Visible = false;
            this.joinery.Visible = false;
            this.pottery.Visible = false;
            this.basketmaker.Visible = false;
        }

        public void showFences()
        {
            this.pictureBox16.Visible = true;
            this.pictureBox17.Visible = true;
            this.pictureBox18.Visible = true;
            this.pictureBox19.Visible = true;
            this.pictureBox20.Visible = true;
            this.pictureBox21.Visible = true;
            this.pictureBox22.Visible = true;
            this.pictureBox23.Visible = true;
            this.pictureBox24.Visible = true;
            this.pictureBox25.Visible = true;
            this.pictureBox26.Visible = true;
            this.pictureBox27.Visible = true;
            this.pictureBox28.Visible = true;
            this.pictureBox29.Visible = true;
            this.pictureBox30.Visible = true;
            this.pictureBox31.Visible = true;
            this.pictureBox32.Visible = true;
            this.pictureBox33.Visible = true;
            this.pictureBox34.Visible = true;
            this.pictureBox35.Visible = true;
            this.pictureBox36.Visible = true;
            this.pictureBox37.Visible = true;
            this.pictureBox38.Visible = true;
            this.pictureBox39.Visible = true;
            this.pictureBox40.Visible = true;
            this.pictureBox41.Visible = true;
            this.pictureBox42.Visible = true;
            this.pictureBox43.Visible = true;
            this.pictureBox44.Visible = true; 
            this.pictureBox45.Visible = true;
            this.pictureBox46.Visible = true;
            this.pictureBox47.Visible = true;
            this.pictureBox48.Visible = true;
            this.pictureBox49.Visible = true;
            this.pictureBox50.Visible = true;
            this.pictureBox51.Visible = true;
            this.pictureBox52.Visible = true;
            this.pictureBox53.Visible = true;
        }

        public void hideFences()
        {
            PlayerBoard thisPlayer = g.players[playerNumber];

            if (!thisPlayer.builtFences[0]) { this.pictureBox16.Visible = false; }
            if (!thisPlayer.builtFences[1]) { this.pictureBox17.Visible = false; }
            if (!thisPlayer.builtFences[2]) { this.pictureBox18.Visible = false; }
            if (!thisPlayer.builtFences[3]) { this.pictureBox19.Visible = false; }
            if (!thisPlayer.builtFences[4]) { this.pictureBox20.Visible = false; }
            if (!thisPlayer.builtFences[5]) { this.pictureBox21.Visible = false; }
            if (!thisPlayer.builtFences[6]) { this.pictureBox22.Visible = false; }
            if (!thisPlayer.builtFences[7]) { this.pictureBox23.Visible = false; }
            if (!thisPlayer.builtFences[8]) { this.pictureBox24.Visible = false; }
            if (!thisPlayer.builtFences[9]) { this.pictureBox25.Visible = false; }
            if (!thisPlayer.builtFences[10]) { this.pictureBox26.Visible = false; }
            if (!thisPlayer.builtFences[11]) { this.pictureBox27.Visible = false; }
            if (!thisPlayer.builtFences[12]) { this.pictureBox28.Visible = false; }
            if (!thisPlayer.builtFences[13]) { this.pictureBox29.Visible = false; }
            if (!thisPlayer.builtFences[14]) { this.pictureBox30.Visible = false; }
            if (!thisPlayer.builtFences[15]) { this.pictureBox31.Visible = false; }
            if (!thisPlayer.builtFences[16]) { this.pictureBox32.Visible = false; }
            if (!thisPlayer.builtFences[17]) { this.pictureBox33.Visible = false; }
            if (!thisPlayer.builtFences[18]) { this.pictureBox34.Visible = false; }
            if (!thisPlayer.builtFences[19]) { this.pictureBox35.Visible = false; }
            if (!thisPlayer.builtFences[20]) { this.pictureBox36.Visible = false; }
            if (!thisPlayer.builtFences[21]) { this.pictureBox37.Visible = false; }
            if (!thisPlayer.builtFences[22]) { this.pictureBox38.Visible = false; }
            if (!thisPlayer.builtFences[23]) { this.pictureBox39.Visible = false; }
            if (!thisPlayer.builtFences[24]) { this.pictureBox40.Visible = false; }
            if (!thisPlayer.builtFences[25]) { this.pictureBox41.Visible = false; }
            if (!thisPlayer.builtFences[26]) { this.pictureBox42.Visible = false; }
            if (!thisPlayer.builtFences[27]) { this.pictureBox43.Visible = false; }
            if (!thisPlayer.builtFences[28]) { this.pictureBox44.Visible = false; }
            if (!thisPlayer.builtFences[29]) { this.pictureBox45.Visible = false; }
            if (!thisPlayer.builtFences[30]) { this.pictureBox46.Visible = false; }
            if (!thisPlayer.builtFences[31]) { this.pictureBox47.Visible = false; }
            if (!thisPlayer.builtFences[32]) { this.pictureBox48.Visible = false; }
            if (!thisPlayer.builtFences[33]) { this.pictureBox49.Visible = false; }
            if (!thisPlayer.builtFences[34]) { this.pictureBox50.Visible = false; }
            if (!thisPlayer.builtFences[35]) { this.pictureBox51.Visible = false; }
            if (!thisPlayer.builtFences[36]) { this.pictureBox52.Visible = false; }
            if (!thisPlayer.builtFences[37]) { this.pictureBox53.Visible = false; }
        }

        private void fireplace1_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    if (thisPlayer.resources[4] >= 1)
                    {
                        thisPlayer.resources[4]--;
                        thisPlayer.resources[9] += 2;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nGrain.Text = thisPlayer.resources[4].ToString();
                        built = true;
                    }
                    break;
                case 4: //Buy Maj Improv
                    if (built)
                    {
                        if (thisPlayer.resources[4] >= 1)
                        {
                            thisPlayer.resources[4]--;
                            thisPlayer.resources[9] += 2;
                            this.nFood.Text = thisPlayer.resources[9].ToString();
                            this.nGrain.Text = thisPlayer.resources[4].ToString();
                        }
                    }
                    if (thisPlayer.resources[1] >= 2)
                    {
                        thisPlayer.resources[1] -= 2;
                        thisPlayer.boughtMajImprov[0] = true;
                        g.availableMajImprov[0] = false;
                        built = true;
                        fireplace1.Text = "Use Fireplace";
                        thisPlayer.baseScore++;
                        doneButton_Click(sender, e);
                    }
                    break;
                case 5:
                    goto case 3;
                case 7:
                    switch (thisPlayer.resourceChosen)
                    {
                        case 0:
                            if (thisPlayer.resources[6] > 0)
                            {
                                thisPlayer.resources[6]--;
                                thisPlayer.resources[9] += 2;
                                this.nSheep.Text = thisPlayer.resources[6].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 1:
                            if (thisPlayer.resources[7] > 0)
                            {
                                thisPlayer.resources[7]--;
                                thisPlayer.resources[9] += 2;
                                this.nBoars.Text = thisPlayer.resources[7].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 2:
                            if (thisPlayer.resources[8] > 0)
                            {
                                thisPlayer.resources[8]--;
                                thisPlayer.resources[9] += 3;
                                this.nCattle.Text = thisPlayer.resources[8].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 3:
                            break;
                        case 4:
                            if (thisPlayer.resources[5] > 0)
                            {
                                thisPlayer.resources[5]--;
                                thisPlayer.resources[9] += 2;
                                this.nVegetables.Text = thisPlayer.resources[5].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                    }
                    break;
                case 8:
                    goto case 7;
                case 9:
                    goto case 7;
                case 10:
                    goto case 4;
                case 13:
                    goto case 7;
                case 14:
                    goto case 7;
            
            }
        }

        private void fireplace2_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    if (thisPlayer.resources[4] >= 1)
                    {
                        thisPlayer.resources[4]--;
                        thisPlayer.resources[9] += 2;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nGrain.Text = thisPlayer.resources[4].ToString();
                        built = true;
                    }
                    break;
                case 4: //Buy Maj Improv
                    if (built)
                    {
                        if (thisPlayer.resources[4] >= 1)
                        {
                            thisPlayer.resources[4]--;
                            thisPlayer.resources[9] += 2;
                            this.nFood.Text = thisPlayer.resources[9].ToString();
                            this.nGrain.Text = thisPlayer.resources[4].ToString();
                        }
                    }
                    else if (thisPlayer.resources[1] >= 3)
                    {
                        thisPlayer.resources[1] -= 3;
                        thisPlayer.boughtMajImprov[1] = true;
                        g.availableMajImprov[1] = false;
                        built = true;
                        fireplace2.Text = "Use Fireplace";
                        thisPlayer.baseScore++;
                        doneButton_Click(sender, e);
                    }
                    break;
                case 5:
                    goto case 3;
                case 7:
                    switch (thisPlayer.resourceChosen)
                    {
                        case 0:
                            if (thisPlayer.resources[6] > 0)
                            {
                                thisPlayer.resources[6]--;
                                thisPlayer.resources[9] += 2;
                                this.nSheep.Text = thisPlayer.resources[6].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 1:
                            if (thisPlayer.resources[7] > 0)
                            {
                                thisPlayer.resources[7]--;
                                thisPlayer.resources[9] += 2;
                                this.nBoars.Text = thisPlayer.resources[7].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 2:
                            if (thisPlayer.resources[8] > 0)
                            {
                                thisPlayer.resources[8]--;
                                thisPlayer.resources[9] += 3;
                                this.nCattle.Text = thisPlayer.resources[8].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 3:
                            break;
                        case 4:
                            if (thisPlayer.resources[5] > 0)
                            {
                                thisPlayer.resources[5]--;
                                thisPlayer.resources[9] += 2;
                                this.nVegetables.Text = thisPlayer.resources[5].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                    }
                    break;
                case 8:
                    goto case 7;
                case 9:
                    goto case 7;
                case 10:
                    goto case 4;
                case 13:
                    goto case 7;
                case 14:
                    goto case 7;
            }
        }

        private void cookingHearth1_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    if (thisPlayer.resources[4] >= 1)
                    {
                        thisPlayer.resources[4]--;
                        thisPlayer.resources[9] += 3;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nGrain.Text = thisPlayer.resources[4].ToString();
                        built = true;
                    }
                    break;
                case 4:
                    if (built)
                    {
                        if (thisPlayer.resources[4] >= 1)
                        {
                            thisPlayer.resources[4]--;
                            thisPlayer.resources[9] += 3;
                            this.nFood.Text = thisPlayer.resources[9].ToString();
                            this.nGrain.Text = thisPlayer.resources[4].ToString();
                        }
                    }
                    else if (thisPlayer.boughtMajImprov[0])
                    {
                        thisPlayer.boughtMajImprov[2] = true;
                        g.availableMajImprov[2] = false;
                        thisPlayer.boughtMajImprov[0] = false;
                        g.availableMajImprov[0] = true;
                        built = true;
                        cookingHearth1.Text = "Use Cooking hearth";
                        doneButton_Click(sender, e);
                    }
                    else if (thisPlayer.boughtMajImprov[1])
                    {
                        thisPlayer.boughtMajImprov[2] = true;
                        g.availableMajImprov[2] = false;
                        thisPlayer.boughtMajImprov[1] = false;
                        g.availableMajImprov[1] = true;
                        built = true;
                        cookingHearth1.Text = "Use Cooking hearth";
                        doneButton_Click(sender, e);
                    }
                    else if (thisPlayer.resources[1] >= 4)
                    {
                        thisPlayer.resources[1] -= 4;
                        thisPlayer.boughtMajImprov[2] = true;
                        g.availableMajImprov[2] = false;
                        built = true;
                        cookingHearth1.Text = "Use Cooking hearth";
                        thisPlayer.baseScore++;
                        doneButton_Click(sender, e);
                    }
                    break;
                case 5:
                    goto case 3;
                case 7:
                    switch (thisPlayer.resourceChosen)
                    {
                        case 0:
                            if (thisPlayer.resources[6] > 0)
                            {
                                thisPlayer.resources[6]--;
                                thisPlayer.resources[9] += 2;
                                this.nSheep.Text = thisPlayer.resources[6].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 1:
                            if (thisPlayer.resources[7] > 0)
                            {
                                thisPlayer.resources[7]--;
                                thisPlayer.resources[9] += 3;
                                this.nBoars.Text = thisPlayer.resources[7].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 2:
                            if (thisPlayer.resources[8] > 0)
                            {
                                thisPlayer.resources[8]--;
                                thisPlayer.resources[9] += 4;
                                this.nCattle.Text = thisPlayer.resources[8].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 3:
                            break;
                        case 4:
                            if (thisPlayer.resources[5] > 0)
                            {
                                thisPlayer.resources[5]--;
                                thisPlayer.resources[9] += 3;
                                this.nVegetables.Text = thisPlayer.resources[5].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                    }
                    break;
                case 8:
                    goto case 7;
                case 9:
                    goto case 7;
                case 10:
                    goto case 4;
                case 13:
                    goto case 7;
                case 14:
                    goto case 7;
            }
        }

        private void cookingHearth2_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    if (thisPlayer.resources[4] >= 1)
                    {
                        thisPlayer.resources[4]--;
                        thisPlayer.resources[9] += 3;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nGrain.Text = thisPlayer.resources[4].ToString();
                        built = true;
                    }
                    break;
                case 4:
                    if (built)
                    {
                        if (thisPlayer.resources[4] >= 1)
                        {
                            thisPlayer.resources[4]--;
                            thisPlayer.resources[9] += 3;
                            this.nFood.Text = thisPlayer.resources[9].ToString();
                            this.nGrain.Text = thisPlayer.resources[4].ToString();
                        }
                    }
                    else if (thisPlayer.boughtMajImprov[0])
                    {
                        thisPlayer.boughtMajImprov[3] = true;
                        g.availableMajImprov[3] = false;
                        thisPlayer.boughtMajImprov[0] = false;
                        g.availableMajImprov[0] = true;
                        built = true;
                        cookingHearth2.Text = "Use Cooking hearth";
                        doneButton_Click(sender, e);
                    }
                    else if (thisPlayer.boughtMajImprov[1])
                    {
                        thisPlayer.boughtMajImprov[3] = true;
                        g.availableMajImprov[3] = false;
                        thisPlayer.boughtMajImprov[1] = false;
                        g.availableMajImprov[1] = true;
                        built = true;
                        cookingHearth2.Text = "Use Cooking hearth";
                        doneButton_Click(sender, e);
                    }
                    else if (thisPlayer.resources[1] >= 5)
                    {
                        thisPlayer.resources[1] -= 5;
                        thisPlayer.boughtMajImprov[3] = true;
                        g.availableMajImprov[3] = false;
                        built = true;
                        cookingHearth2.Text = "Use Cooking hearth";
                        thisPlayer.baseScore++;
                        doneButton_Click(sender, e);
                    }
                    break;
                case 5:
                    goto case 3;
                case 7:
                    switch (thisPlayer.resourceChosen)
                    {
                        case 0:
                            if (thisPlayer.resources[6] > 0)
                            {
                                thisPlayer.resources[6]--;
                                thisPlayer.resources[9] += 2;
                                this.nSheep.Text = thisPlayer.resources[6].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 1:
                            if (thisPlayer.resources[7] > 0)
                            {
                                thisPlayer.resources[7]--;
                                thisPlayer.resources[9] += 3;
                                this.nBoars.Text = thisPlayer.resources[7].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 2:
                            if (thisPlayer.resources[8] > 0)
                            {
                                thisPlayer.resources[8]--;
                                thisPlayer.resources[9] += 4;
                                this.nCattle.Text = thisPlayer.resources[8].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                        case 3:
                            break;
                        case 4:
                            if (thisPlayer.resources[5] > 0)
                            {
                                thisPlayer.resources[5]--;
                                thisPlayer.resources[9] += 3;
                                this.nVegetables.Text = thisPlayer.resources[5].ToString();
                                this.nFood.Text = thisPlayer.resources[9].ToString();
                            }
                            break;
                    }
                    break;
                case 8:
                    goto case 7;
                case 9:
                    goto case 7;
                case 10:
                    goto case 4;
                case 13:
                    goto case 7;
                case 14:
                    goto case 7;
            }
        }

        private void well_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    this.infoBox.Text = "You can't bake with that...";
                    break;
                case 4:
                    if (thisPlayer.resources[0] >= 1 && thisPlayer.resources[2] >= 3)
                    {
                        thisPlayer.resources[0]--;
                        thisPlayer.resources[2] -= 3;
                        thisPlayer.boughtMajImprov[4] = true;
                        g.availableMajImprov[4] = false;
                        built = true;
                        well.Text = "Well";
                        g.wellPlayer = playerNumber;
                        if (14 - g.round >= 5) { g.wellFood = 5; }
                        else { g.wellFood = 14 - g.round; }
                        thisPlayer.baseScore += 4;
                        doneButton_Click(sender, e);
                    }
                    break;
                case 10:
                    goto case 4;
            }
        }

        private void clayOven_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    if (thisPlayer.resources[4] >= 1)
                    {
                        thisPlayer.resources[4]--;
                        thisPlayer.resources[9] += 5;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nGrain.Text = thisPlayer.resources[4].ToString();
                        clayOven.Enabled = false;
                        built = true;
                    }
                    break;
                case 4:
                    if (built)
                    {
                        if (thisPlayer.resources[4] >= 1)
                        {
                            thisPlayer.resources[4]--;
                            thisPlayer.resources[9] += 5;
                            this.nFood.Text = thisPlayer.resources[9].ToString();
                            this.nGrain.Text = thisPlayer.resources[4].ToString();
                            clayOven.Enabled = false;
                        }
                    }
                    else if (thisPlayer.resources[1] >= 3 && thisPlayer.resources[2] >= 1)
                    {
                        thisPlayer.resources[1] -= 3;
                        thisPlayer.resources[2]--;
                        thisPlayer.boughtMajImprov[5] = true;
                        g.availableMajImprov[5] = false;
                        built = true;
                        clayOven.Text = "Use Clay Oven";
                        thisPlayer.baseScore += 2;
                        hideMajImprovs();
                        u.enableMajImprovButtons(thisPlayer.board, thisPlayer.boughtMajImprov, true);
                        infoBox.Text = "You may now bake";
                    }
                    break;
                case 5:
                    goto case 3;
                case 10:
                    goto case 4;
            }
        }

        private void stoneOven_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    if (thisPlayer.resources[4] >= 1)
                    {
                        thisPlayer.resources[4]--;
                        thisPlayer.resources[9] += 4;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nGrain.Text = thisPlayer.resources[4].ToString();
                        if (ovenUsed) { stoneOven.Enabled = false; }
                        else { ovenUsed = true; }
                        built = true;
                    }
                    break;
                case 4: //Build Maj Imrovs
                    if (built)
                    {
                        if (thisPlayer.resources[4] >= 1)
                        {
                            thisPlayer.resources[4]--;
                            thisPlayer.resources[9] += 4;
                            this.nFood.Text = thisPlayer.resources[9].ToString();
                            this.nGrain.Text = thisPlayer.resources[4].ToString();
                            if (ovenUsed) { stoneOven.Enabled = false; }
                            else { ovenUsed = true; }
                        }
                    }
                    else if (thisPlayer.resources[1] >= 1 && thisPlayer.resources[2] >= 3)
                    {
                        thisPlayer.resources[1]--;
                        thisPlayer.resources[2] -= 3;
                        thisPlayer.boughtMajImprov[6] = true;
                        g.availableMajImprov[6] = false;
                        built = true;
                        stoneOven.Text = "Use Stone Oven";
                        thisPlayer.baseScore += 3;
                        hideMajImprovs();
                        u.enableMajImprovButtons(thisPlayer.board, thisPlayer.boughtMajImprov, true);
                        infoBox.Text = "You may now bake";
                    }
                    break;
                case 5:
                    goto case 3;
                case 10:
                    goto case 4;
            }
        }

        private void joinery_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    this.infoBox.Text = "You can't bake with that...";
                    break;
                case 4:
                    if (thisPlayer.resources[0] >= 2 && thisPlayer.resources[2] >= 2)
                    {
                        thisPlayer.resources[0] -= 2;
                        thisPlayer.resources[2] -= 2;
                        thisPlayer.boughtMajImprov[7] = true;
                        g.availableMajImprov[7] = false;
                        built = true;
                        joinery.Text = "Use Joinery";
                        thisPlayer.baseScore += 2;
                        doneButton_Click(sender, e);
                    }
                    break;
                case 10:
                    goto case 4;
                case 13:
                    if (thisPlayer.resources[0] > 0)
                    {
                        thisPlayer.resources[9] += 2;
                        thisPlayer.resources[0]--;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nWood.Text = thisPlayer.resources[0].ToString();
                        this.joinery.Visible = false;
                    }
                    break;
            }
        }

        private void pottery_Click(object sender, EventArgs e)
        {

            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    this.infoBox.Text = "You can't bake with that...";
                    break;
                case 4:
                    if (thisPlayer.resources[1] >= 2 && thisPlayer.resources[2] >= 2)
                    {
                        thisPlayer.resources[1] -= 2;
                        thisPlayer.resources[2] -= 2;
                        thisPlayer.boughtMajImprov[8] = true;
                        g.availableMajImprov[8] = false;
                        built = true;
                        pottery.Text = "Use Pottery";
                        thisPlayer.baseScore += 2;
                        doneButton_Click(sender, e);
                    }
                    break;
                case 10:
                    goto case 4;
                case 13:
                    if (thisPlayer.resources[1] > 0)
                    {
                        thisPlayer.resources[9] += 2;
                        thisPlayer.resources[1]--;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nClay.Text = thisPlayer.resources[1].ToString();
                        this.pottery.Visible = false;
                    }
                    break;
            }
        }

        private void basketmaker_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[g.currentPlayer];
            switch (calledBy)
            {
                case 3: //Stable n Bake
                    this.infoBox.Text = "You can't bake with that...";
                    break;
                case 4:
                    if (thisPlayer.resources[2] >= 2 && thisPlayer.resources[3] >= 2)
                    {
                        thisPlayer.resources[2] -= 2;
                        thisPlayer.resources[3] -= 2;
                        thisPlayer.boughtMajImprov[9] = true;
                        g.availableMajImprov[9] = false;
                        built = true;
                        basketmaker.Text = "Use Basket Workshop";
                        thisPlayer.baseScore += 2;
                        doneButton_Click(sender, e);
                    }
                    break;
                case 10:
                    goto case 4;
                case 13:
                    if (thisPlayer.resources[2] > 0)
                    {
                        thisPlayer.resources[9] += 3;
                        thisPlayer.resources[2]--;
                        this.nFood.Text = thisPlayer.resources[9].ToString();
                        this.nReed.Text = thisPlayer.resources[3].ToString();
                        this.basketmaker.Visible = false;
                    }
                    break;
            }
        }

        private void room_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[playerNumber];

            if (thisPlayer.resources[thisPlayer.houseType] >= 5 && thisPlayer.resources[3] >= 2)
            {
                if (thisPlayer.farmSpaces[chosenFarmSpace] == 'e' && u.hasNeighbour(thisPlayer,chosenFarmSpace,thisPlayer.houseSort))
                {                
                    thisPlayer.nRooms++;
                    thisPlayer.resources[thisPlayer.houseType] -= 5;
                    thisPlayer.resources[3] -= 2;
                    built = true;
                    thisPlayer.farmSpaces[chosenFarmSpace] = thisPlayer.houseSort;
                    updateFarmSpaces(thisPlayer);
                }
            }
        }

        private void stable_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[playerNumber];
            int stablePrice = 10;

            if (calledBy == 1)
            {
                stablePrice = 2;
            }
            if (calledBy == 3)
            {
                stablePrice = 1;              
            }

            if (thisPlayer.resources[0] >= stablePrice && thisPlayer.nStables < 4 && (thisPlayer.farmSpaces[chosenFarmSpace] == 'p' || thisPlayer.farmSpaces[chosenFarmSpace] == 'e'))
            {
                thisPlayer.nStables++;
                thisPlayer.resources[0] -= stablePrice;
                this.nWood.Text = thisPlayer.resources[0].ToString();
                built = true;
                if (thisPlayer.farmSpaces[chosenFarmSpace] == 'p')
                {                    
                    thisPlayer.farmSpaces[chosenFarmSpace] = 'h';
                    int pasture = -1;
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (thisPlayer.pastureMembers[i][j] == chosenFarmSpace)
                            {
                                pasture = i;
                                break;
                            }
                        }
                    }
                    thisPlayer.pastureSizes[pasture] *= 2;
                }
                else if (thisPlayer.farmSpaces[chosenFarmSpace] == 'e')
                {
                    thisPlayer.farmSpaces[chosenFarmSpace] = 'b';
                }
                updateFarmSpaces(thisPlayer);
            }
            if (built && calledBy == 3)
            {
                stable.Enabled = false;
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            if (built) { doneIndicator = 2; }
            else { doneIndicator = 1; }

            PlayerBoard thisPlayer = g.players[playerNumber];

            bool sOkay; bool bOkay; bool cOkay;

            switch (calledBy)
            {
                case 1:
                    m.bRooms_Click(sender, e);
                    break;
                case 2:
                    if (thisPlayer.farmSpaces[chosenFarmSpace] == 'e' )
                    {
                        if (thisPlayer.nFields == 0 || u.hasNeighbour(thisPlayer, chosenFarmSpace, 'f') || u.hasNeighbour(thisPlayer, chosenFarmSpace, 'u') || u.hasNeighbour(thisPlayer, chosenFarmSpace, 'v') || u.hasNeighbour(thisPlayer, chosenFarmSpace, 'x') || u.hasNeighbour(thisPlayer, chosenFarmSpace, 'y') || u.hasNeighbour(thisPlayer, chosenFarmSpace, 'z'))
                        {
                            thisPlayer.farmSpaces[chosenFarmSpace] = 'f';
                            thisPlayer.nFields++;
                            doneIndicator = 2;
                            built = true;
                        }
                    }
                    if (calledBy == 2) { m.plow_Click(sender, e); }
                    else
                    {
                        sowTime = true;
                        this.infoBox.Text = "Choose field and crop to sow or improvement to bake";
                    }
                    break;
                case 3:
                    m.bStable_Click(sender, e);
                    stable.Enabled = true;
                    clayOven.Enabled = true;
                    stoneOven.Enabled = true;
                    ovenUsed = false;
                    break;
                case 4:
                    u.actions(g, 2, m);
                    clayOven.Enabled = true;
                    stoneOven.Enabled = true;
                    ovenUsed = false;
                    break;
                case 5:
                    u.actions(g, 3, m);
                    clayOven.Enabled = true;
                    stoneOven.Enabled = true;
                    sowGrain.Visible = false;
                    sowVegetables.Visible = false;
                    ovenUsed = false;
                    break;
                case 6: //Fence building
                    if (allocating)
                    {
                        sOkay = (thisPlayer.livestockAllocated[0] == thisPlayer.resources[6]);
                        bOkay = (thisPlayer.livestockAllocated[1] == thisPlayer.resources[7]);
                        cOkay = (thisPlayer.livestockAllocated[2] == thisPlayer.resources[8]);
                        if (fencesBuilt) { doneIndicator = 2; }
                        if (sOkay && bOkay && cOkay) 
                        { 
                            allocating = false; 
                            fencesBuilt = false;
                            u.actions(g, 1, m); 
                        }
                    }
                    else if (u.checkFences(thisPlayer))
                    {
                        if (u.checkPastures(thisPlayer))
                        {
                            u.confirmFences(thisPlayer);
                            updateFarmSpaces(thisPlayer);
                            hideFences();
                            
                            livestockAllocation(); 
                            allocating = true;
                            fencesBuilt = true;
                            goto case 6; 
                        }
                    }
                    break;
                case 7:
                    sOkay = (thisPlayer.livestockAllocated[0] == thisPlayer.resources[6]);
                    bOkay = (thisPlayer.livestockAllocated[1] == thisPlayer.resources[7]);
                    cOkay = (thisPlayer.livestockAllocated[2] == thisPlayer.resources[8]);
                    if (sOkay && bOkay && cOkay) { doneIndicator = 2; u.actions(g, 0, m); }
                    break;
                case 8:
                    sOkay = (thisPlayer.livestockAllocated[0] == thisPlayer.resources[6]);
                    bOkay = (thisPlayer.livestockAllocated[1] == thisPlayer.resources[7]);
                    cOkay = (thisPlayer.livestockAllocated[2] == thisPlayer.resources[8]);
                    if (sOkay && bOkay && cOkay) { doneIndicator = 2; u.actions(g, 7, m); }
                    break;
                case 9:
                    sOkay = (thisPlayer.livestockAllocated[0] == thisPlayer.resources[6]);
                    bOkay = (thisPlayer.livestockAllocated[1] == thisPlayer.resources[7]);
                    cOkay = (thisPlayer.livestockAllocated[2] == thisPlayer.resources[8]);
                    if (sOkay && bOkay && cOkay) { doneIndicator = 2; u.actions(g, 10, m); }
                    break;
                case 10:
                    u.actions(g, 6, m);
                    clayOven.Enabled = true;
                    stoneOven.Enabled = true;
                    ovenUsed = false;
                    break;      
                case 11:
                    if (!sowTime) { goto case 2; }
                    else
                    {
                        sowTime = false;
                        sowGrain.Visible = false;
                        sowVegetables.Visible = false;
                        u.actions(g, 11, m);
                    }
                    break;
                case 12:
                    goto case 6;
                case 13:
                    doneIndicator = 1;
                    m.endTurn();
                    break;
                case 14:
                    sOkay = (thisPlayer.livestockAllocated[0] == thisPlayer.resources[6]);
                    bOkay = (thisPlayer.livestockAllocated[1] == thisPlayer.resources[7]);
                    cOkay = (thisPlayer.livestockAllocated[2] == thisPlayer.resources[8]);
                    if (sOkay && bOkay && cOkay) { doneIndicator = 2; m.endTurn(); }
                    break;
            }
            built = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e) //Fence buttons 0 to 37
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox1.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox2.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox3.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox4.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox5.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox6.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox7.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox8.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox9.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(8);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox10.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(9);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox11.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(10);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox12.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(11);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox13.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(12);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox14.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(13);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            updateFarmSpaces(g.players[playerNumber]);
            pictureBox15.BackColor = System.Drawing.Color.LightSeaGreen;
            farmyardClick(14);
        }

        private void farmyardClick(int farmSpace)
        {
            chosenFarmSpace = farmSpace;          

            switch (calledBy)
            {
                case 0:
                    break;
                case 1:
                    this.room.Visible = true;
                    this.room.Text = System.String.Format("Build room (5{0} 2r)",g.players[g.currentPlayer].houseSort);
                    this.stable.Visible = true;
                    this.stable.Text = "Build Stable (2w)";
                    this.doneButton.Visible = true;
                    break;
                case 2:
                    break;
                case 3:
                    this.stable.Visible = true;
                    this.stable.Text = "Build Stable (1w)";
                    break;
                case 4:
                    break;
                case 5:
                    this.sowGrain.Visible = true;
                    this.sowVegetables.Visible = true;
                    break;
                case 6:
                    if (allocating)
                    {
                        allocation();
                    }
                    break;
                case 7:
                    allocation();
                    break;
                case 8:
                    allocation();
                    break;
                case 9:
                    allocation();
                    break;
                case 11:
                    if (sowTime) { goto case 5; }
                    break;
                case 14:
                    allocation();
                    break;
                default:
                    break;
            }
        }

        private void laborerW_Click(object sender, EventArgs e)
        {
            g.players[g.currentPlayer].resources[0]++;
            laborerW.Visible = false;
            laborerC.Visible = false;
            laborerS.Visible = false;
            laborerR.Visible = false;
            m.laborer_Click(sender, e);
        }

        private void laborerC_Click(object sender, EventArgs e)
        {
            g.players[g.currentPlayer].resources[1]++;
            laborerW.Visible = false;
            laborerC.Visible = false;
            laborerS.Visible = false;
            laborerR.Visible = false;
            m.laborer_Click(sender, e);

        }

        private void laborerS_Click(object sender, EventArgs e)
        {
            g.players[g.currentPlayer].resources[2]++;
            laborerW.Visible = false;
            laborerC.Visible = false;
            laborerS.Visible = false;
            laborerR.Visible = false;
            m.laborer_Click(sender, e);
        }

        private void laborerR_Click(object sender, EventArgs e)
        {
            if (calledBy >= 6)
            {
                releaseLivestock();
            }
            else
            {
                g.players[g.currentPlayer].resources[3]++;
                laborerW.Visible = false;
                laborerC.Visible = false;
                laborerS.Visible = false;
                laborerR.Visible = false;
                m.laborer_Click(sender, e);
            }
        }

        private void sowGrain_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[playerNumber];
            if (thisPlayer.resources[4] >= 1 && thisPlayer.farmSpaces[chosenFarmSpace] == 'f')
            {
                thisPlayer.resources[4]--;
                thisPlayer.farmSpaces[chosenFarmSpace] = 'z';
                u.showPastures(thisPlayer,chosenFarmSpace,"3");
                updateFarmSpaces(thisPlayer);
                nGrain.Text = thisPlayer.resources[4].ToString();
                built = true;
            }
        }

        private void sowVegetables_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[playerNumber];
            if (thisPlayer.resources[5] >= 1 && thisPlayer.farmSpaces[chosenFarmSpace] == 'f')
            {
                thisPlayer.resources[5]--;
                thisPlayer.farmSpaces[chosenFarmSpace] = 'v';
                u.showPastures(thisPlayer,chosenFarmSpace,"2");
                updateFarmSpaces(thisPlayer);
                nVegetables.Text = thisPlayer.resources[5].ToString();
                built = true;
            }
        }
        
        private void fenceClick(PictureBox theFence, int fenceID)
        {
        	PlayerBoard thisPlayer = g.players[playerNumber];
            if (!thisPlayer.builtFences[fenceID])
            {
                bool[] prelFences = thisPlayer.preliminaryFences;
                if (prelFences[fenceID])
                {
                    prelFences[fenceID] = false;
                    theFence.BackColor = System.Drawing.SystemColors.ButtonShadow;
                    thisPlayer.resources[0]++;
                    thisPlayer.nFences--;
                    this.nWood.Text = thisPlayer.resources[0].ToString(); 
                }
                else if(thisPlayer.resources[0] >= 1)
                {
                	if(thisPlayer.nFences < 15)
                	{
	                    prelFences[fenceID] = true;
	                    theFence.BackColor = u.playerColor(playerNumber);
	                    thisPlayer.resources[0]--;
	                    thisPlayer.nFences++;
	                    this.nWood.Text = thisPlayer.resources[0].ToString();
                	}
                	else
                	{
                		thisPlayer.board.infoBox.Text="To many fences! Maximum 15";	
                	}
                }
                else{ thisPlayer.board.infoBox.Text="Out of wood"; }
            }
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
        	fenceClick(pictureBox16,0);
        	
            /*
			PlayerBoard thisPlayer = g.players[playerNumber];
            if (!thisPlayer.builtFences[0])
            {
                bool[] prelFences = thisPlayer.preliminaryFences;
                if (prelFences[0])
                {
                    prelFences[0] = false;
                    pictureBox16.BackColor = System.Drawing.SystemColors.ButtonShadow;
                    thisPlayer.resources[0]++;
                    thisPlayer.nFences--;
                    this.nWood.Text = thisPlayer.resources[0].ToString(); 
                }
                else if(thisPlayer.resources[0] >= 1 && thisPlayer.nFences < 15)
                {
                    prelFences[0] = true;
                    pictureBox16.BackColor = u.playerColor(playerNumber);
                    thisPlayer.resources[0]--;
                    thisPlayer.nFences++;
                    this.nWood.Text = thisPlayer.resources[0].ToString();
                }
            }
            */
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox17,1);
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox18,2);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox19,3);
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox20,4);
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox21,5);
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox22,6);
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox23,7);
        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox24,8);
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox25,9);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox26,10);
        }

        private void pictureBox27_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox27,11);
        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox28,12);
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox29,13);
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox30,14);
        }

        private void pictureBox31_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox31,15);
        }

        private void pictureBox32_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox32,16);
        }

        private void pictureBox33_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox33,17);
        }

        private void pictureBox34_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox34,18);
        }

        private void pictureBox35_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox35,19);
        }

        private void pictureBox36_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox36,20);
        }

        private void pictureBox37_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox37,21);
        }

        private void pictureBox38_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox38,22);
        }

        private void pictureBox39_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox39,23);
        }

        private void pictureBox40_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox40,24);
        }

        private void pictureBox41_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox41,25);
        }

        private void pictureBox42_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox42,26);
        }

        private void pictureBox43_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox43,27);
        }

        private void pictureBox44_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox44,28);
        }

        private void pictureBox45_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox45,29);
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox46,30);
        }

        private void pictureBox47_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox47,31);
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox48,32);
        }

        private void pictureBox49_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox49,33);
        }

        private void pictureBox50_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox50,34);
        }

        private void pictureBox51_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox51,35);
        }

        private void pictureBox52_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox52,36);
        }

        private void pictureBox53_Click(object sender, EventArgs e)
        {
            fenceClick(pictureBox53,37);
        }

        private void radioSheep_CheckedChanged(object sender, EventArgs e)
        {
            g.players[playerNumber].resourceChosen = 0;
        }

        private void radioBoars_CheckedChanged(object sender, EventArgs e)
        {
            g.players[playerNumber].resourceChosen = 1;
        }

        private void radioCattle_CheckedChanged(object sender, EventArgs e)
        {
            g.players[playerNumber].resourceChosen = 2;
        }

        private void radioGrain_CheckedChanged(object sender, EventArgs e)
        {
            g.players[playerNumber].resourceChosen = 3;
        }

        private void radioVegetables_CheckedChanged(object sender, EventArgs e)
        {
            g.players[playerNumber].resourceChosen = 4;
        }

        public void livestockAllocation()
        {
            PlayerBoard thisPlayer = g.players[playerNumber];
            this.radioSheep.Visible = true;
            this.radioSheep.Text = System.String.Format("Sheep {0} left", thisPlayer.resources[6]);
            this.radioBoars.Visible = true;
            this.radioBoars.Text = System.String.Format("Boars {0} left", thisPlayer.resources[7]);
            this.radioCattle.Visible = true;
            this.radioCattle.Text = System.String.Format("Cattle {0} left", thisPlayer.resources[8]);
            this.infoBox.Text = "Select livestock and allocate by clicking pastures";

            for (int i = 0; i < 6; i++) 
            { 
                thisPlayer.pastureInhabitants[i] = 0;
                thisPlayer.pastureRace[i] = -1; 
            }
            for (int i = 0; i < 3; i++) { thisPlayer.livestockAllocated[i] = 0; }
            for (int i = 0; i < 15; i++) { thisPlayer.stableUsed[i] = false; }

            for(int i = 0; i < 15; i++)
            {
            	if(thisPlayer.farmSpaces[i] == 'b' || thisPlayer.farmSpaces[i] == 'h' || thisPlayer.farmSpaces[i] == 'p' || thisPlayer.farmSpaces[i] == 'w' || thisPlayer.farmSpaces[i] == 'c' || thisPlayer.farmSpaces[i] == 's')
            	{
            		tileText[i].Visible = false;
            	}
            }
            


            if (calledBy > 6) //At pick livestock and harvest
            {
                this.laborerR.Visible = true;
                this.laborerR.Text = "Release";
                u.enableMajImprovButtons(this, thisPlayer.boughtMajImprov, true);
                this.clayOven.Visible = false;
                this.stoneOven.Visible = false;
            }
        }

        private void allocation()
        {
            PlayerBoard thisPlayer = g.players[playerNumber];
            
            if (thisPlayer.livestockAllocated[thisPlayer.resourceChosen] < thisPlayer.resources[thisPlayer.resourceChosen + 6])
            {
                if (thisPlayer.farmSpaces[chosenFarmSpace] == 'b' && !thisPlayer.stableUsed[chosenFarmSpace])
                {
                    thisPlayer.stableUsed[chosenFarmSpace] = true;
                    switch (thisPlayer.resourceChosen)
                    {
                        case 0:
                            u.showPastures(thisPlayer, chosenFarmSpace, "1 sheep");
                            thisPlayer.livestockAllocated[0]++;
                            this.radioSheep.Text = System.String.Format("Sheep {0} left", thisPlayer.resources[6] - thisPlayer.livestockAllocated[0]);
                            break;
                        case 1:
                            u.showPastures(thisPlayer, chosenFarmSpace, "1 boar");
                            thisPlayer.livestockAllocated[1]++;
                            this.radioBoars.Text = System.String.Format("Boar {0} left", thisPlayer.resources[7] - thisPlayer.livestockAllocated[1]);
                            break;
                        case 2:
                            u.showPastures(thisPlayer, chosenFarmSpace, "1 cattle");
                            thisPlayer.livestockAllocated[2]++;
                            this.radioCattle.Text = System.String.Format("Cattle {0} left", thisPlayer.resources[8] - thisPlayer.livestockAllocated[2]);
                            break;
                    }
                }
                else if (thisPlayer.farmSpaces[chosenFarmSpace] == 'p' || thisPlayer.farmSpaces[chosenFarmSpace] == 'h')
                {
                    bool isOkay = false;
                    int pasture = -1;
                    for (int i = 0; i < 6; i++)
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (thisPlayer.pastureMembers[i][j] == chosenFarmSpace)
                            {
                                pasture = i;
                                break;
                            }
                        }
                    }

                    if (thisPlayer.pastureInhabitants[pasture] == 0)
                    {                        
                        thisPlayer.pastureRace[pasture] = thisPlayer.resourceChosen;                       
                        isOkay = true;
                    }
                    else if (thisPlayer.pastureRace[pasture] == thisPlayer.resourceChosen && thisPlayer.pastureSizes[pasture] > thisPlayer.pastureInhabitants[pasture])
                    {
                        isOkay = true;
                    }

                    if (isOkay)
                    {
                        thisPlayer.pastureInhabitants[pasture]++;
                        thisPlayer.livestockAllocated[thisPlayer.resourceChosen]++;

                        switch (thisPlayer.resourceChosen)
                        {
                            case 0:
                                u.showPastures(thisPlayer, thisPlayer.pastureMembers[pasture][0], System.String.Format("{0} sheep",thisPlayer.pastureInhabitants[pasture]));
                                this.radioSheep.Text = System.String.Format("Sheep {0} left", thisPlayer.resources[6] - thisPlayer.livestockAllocated[0]); 
                                break;
                            case 1:
                                u.showPastures(thisPlayer, thisPlayer.pastureMembers[pasture][0], System.String.Format("{0} boar/s", thisPlayer.pastureInhabitants[pasture]));
                                this.radioBoars.Text = System.String.Format("Boars {0} left", thisPlayer.resources[7] - thisPlayer.livestockAllocated[1]);
                                break;
                            case 2:
                                u.showPastures(thisPlayer, thisPlayer.pastureMembers[pasture][0], System.String.Format("{0} cattle", thisPlayer.pastureInhabitants[pasture]));
                                this.radioCattle.Text = System.String.Format("Cattle {0} left", thisPlayer.resources[8] - thisPlayer.livestockAllocated[2]);
                                break;
                        }
                    }
                }
                else if (thisPlayer.farmSpaces[chosenFarmSpace] == 'w' || thisPlayer.farmSpaces[chosenFarmSpace] == 'c' || thisPlayer.farmSpaces[chosenFarmSpace] == 's')
                {
                    if (!thisPlayer.stableUsed[10])
                    {
                        thisPlayer.stableUsed[10] = true;
                        switch (thisPlayer.resourceChosen)
                        {
                            case 0:
                                u.showPastures(thisPlayer, 10, "1 sheep");
                                thisPlayer.livestockAllocated[0]++;
                                this.radioSheep.Text = System.String.Format("Sheep {0} left", thisPlayer.resources[6] - thisPlayer.livestockAllocated[0]);
                                break;
                            case 1:
                                u.showPastures(thisPlayer, 10, "1 boar");
                                thisPlayer.livestockAllocated[1]++;
                                this.radioBoars.Text = System.String.Format("Boar {0} left", thisPlayer.resources[7] - thisPlayer.livestockAllocated[1]);
                                break;
                            case 2:
                                u.showPastures(thisPlayer, 10, "1 cattle");
                                thisPlayer.livestockAllocated[2]++;
                                this.radioCattle.Text = System.String.Format("Cattle {0} left", thisPlayer.resources[8] - thisPlayer.livestockAllocated[2]);
                                break;
                        }
                    }
                }

            }
            
        }

        private void releaseLivestock()
        {
            PlayerBoard thisPlayer = g.players[playerNumber];
            if (thisPlayer.resources[thisPlayer.resourceChosen + 6] > thisPlayer.livestockAllocated[thisPlayer.resourceChosen])
            {
                switch (thisPlayer.resourceChosen)
                {
                    case 0:
                        thisPlayer.resources[6]--;
                        thisPlayer.board.nSheep.Text = thisPlayer.resources[6].ToString();
                        this.radioSheep.Text = System.String.Format("Sheep {0} left", thisPlayer.resources[6] - thisPlayer.livestockAllocated[0]);
                        break;
                    case 1:
                        thisPlayer.resources[7]--;
                        thisPlayer.board.nBoars.Text = thisPlayer.resources[7].ToString();
                        this.radioSheep.Text = System.String.Format("Boar {0} left", thisPlayer.resources[7] - thisPlayer.livestockAllocated[1]);
                        break;
                    case 2:
                        thisPlayer.resources[8]--;
                        thisPlayer.board.nCattle.Text = thisPlayer.resources[8].ToString();
                        this.radioSheep.Text = System.String.Format("Cattle {0} left", thisPlayer.resources[8] - thisPlayer.livestockAllocated[2]);
                        break;
                }
            }
        }

        private void spareButton_Click(object sender, EventArgs e)
        {
            PlayerBoard thisPlayer = g.players[playerNumber];
            if (thisPlayer.resourceChosen == 3 && thisPlayer.resources[4] >= 1)
            {
                thisPlayer.resources[4]--;
                thisPlayer.resources[9]++;
                this.nFood.Text = thisPlayer.resources[9].ToString();
                this.nGrain.Text = thisPlayer.resources[4].ToString();
            }

            if (thisPlayer.resourceChosen == 4 && thisPlayer.resources[5] >= 1)
            {
                thisPlayer.resources[5]--;
                thisPlayer.resources[9]++;
                this.nFood.Text = thisPlayer.resources[9].ToString();
                this.nVegetables.Text = thisPlayer.resources[5].ToString();
            }
        }
    }
}
