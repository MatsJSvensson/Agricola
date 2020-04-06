using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Agricola
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int[] nPlayers;
            nPlayers = new int[1];
            nPlayers[0] = 0;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SetupForm(nPlayers));
            GameSetup game = new GameSetup(nPlayers[0]);
            //Application.Run(new Form1(game));
            //PlayerBoard board = new PlayerBoard(2, game);
            Application.Run(new MainBoard(game));
            Application.Run(new ScoreBoard(game));
        }
    }
}
