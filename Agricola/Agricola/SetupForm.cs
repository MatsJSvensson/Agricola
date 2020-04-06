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
    public partial class SetupForm : Form
    {
        private int[] nPlayers;

        public SetupForm(int[] n)
        {
            InitializeComponent();
            nPlayers = n;
        }

        private void nPlayersButton1_CheckedChanged(object sender, EventArgs e)
        {
            nPlayers[0] = 1;
        }

        private void nPlayersButton2_CheckedChanged(object sender, EventArgs e)
        {
            nPlayers[0] = 2;
        }

        private void nPlayersButton3_CheckedChanged(object sender, EventArgs e)
        {
            nPlayers[0] = 3;
        }

        private void nPlayersButton4_CheckedChanged(object sender, EventArgs e)
        {
            nPlayers[0] = 4;
        }

        private void nPlayersButton5_CheckedChanged(object sender, EventArgs e)
        {
            nPlayers[0] = 5;
        }

        public void continueButton_Click(object sender, EventArgs e)
        {
            if (nPlayers[0] > 0) { this.Close(); }
        }


    }
}
