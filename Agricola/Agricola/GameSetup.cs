using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agricola
{
    public class GameSetup
    {
        public int nPlayers{get; set;}
        public int round { get; set; }
        public int[] roundCardOrder;
        public int currentPlayer;
        public int startingPlayer;
        public PlayerBoard[] players;
        private int finishedPlayers;
        public bool[] enabledRoundCards;
        public bool[] availableMajImprov;
        public int wellPlayer;
        public int wellFood;
        public int foodConsumption;
        public int woodGain;
        private Utilities u;

        //Main board resources
        public int nStartingP;
        public int nTWood3;
        public int nTClay1;
        public int nTReed1;
        public int nFishing;
        public int nSheep;
        public int nStoneStage2;
        public int nBoars;
        public int nStoneStage4;
        public int nCattle;


        public int endPlayerTurn()
        {
            players[currentPlayer].currentMembers -= 1;
            players[currentPlayer].board.Hide();
            currentPlayer++;
            currentPlayer = currentPlayer % nPlayers;

            if (players[currentPlayer].currentMembers <= 0)
            {
                finishedPlayers++;
                if (finishedPlayers >= nPlayers)
                {
                    finishedPlayers = 0;
                    return endRound(); //Round or game end
                }
                else
                {
                    return endPlayerTurn();
                }
            }
            else
            {
                finishedPlayers = 0;
                players[currentPlayer].board.updateBoard();
                return 0; //Turn end
            }
        }

        public int endRound()
        {
            if (round == 14) { return 2; } //Game end
       
            round++;
            enabledRoundCards[roundCardOrder[round-1]] = true;

            for (int i = 0; i < nPlayers; i++) 
            { players[i].currentMembers = players[i].maxMembers; }

            currentPlayer = startingPlayer;
            players[currentPlayer].board.updateBoard();

            nStartingP++;
            nTWood3 += woodGain;
            nTClay1++;
            nTReed1++;
            nFishing++;
            if (enabledRoundCards[0]) { nSheep++; }
            if (enabledRoundCards[4]) { nStoneStage2++; }
            if (enabledRoundCards[7]) { nBoars++; }
            if (enabledRoundCards[9]) { nStoneStage4++; }
            if (enabledRoundCards[10]) { nCattle++; }

            if (wellFood > 0) { players[wellPlayer].resources[9]++; wellFood--; }
            return 1; //Round end
        }

        public void fieldPhase()
        {
            for(int i = 0; i < nPlayers; i++) //Field phase
            {
                for (int j = 0; j < 15; j++)
                {
                    switch (players[i].farmSpaces[j])
                    {
                        case 'u': //1 Vegetable
                            players[i].farmSpaces[j] = 'f';
                            players[i].resources[5]++;
                            players[i].board.tileText[j].Visible = false;
                            break;
                        case 'v': //2 Vegetables
                            players[i].farmSpaces[j] = 'u';
                            players[i].resources[5]++;
                            u.showPastures(players[i],j,"1");
                            break;
                        case 'x': //1 grain
                            players[i].farmSpaces[j] = 'f';
                            players[i].resources[4]++;
                            players[i].board.tileText[j].Visible = false;
                            break;
                        case 'y': //2 grain
                            players[i].farmSpaces[j] = 'x';
                            players[i].resources[4]++;
                            u.showPastures(players[i],j,"1");
                            break;
                        case 'z': //3 grain
                            players[i].farmSpaces[j] = 'y';
                            players[i].resources[4]++;
                            u.showPastures(players[i],j,"2");
                            break;
                        default:
                            break;
                    }
                }
                players[i].board.updateBoard();
            }
        }


        public GameSetup(int nP)
        {
            nPlayers = nP;
            finishedPlayers = nP;
            Random r = new Random();
            startingPlayer = r.Next(0, nP);
            currentPlayer = startingPlayer;
            round = 0;
            nStartingP = 0;
            wellFood = 0;
            wellPlayer = -1;
            u = new Utilities();

            if (nPlayers == 1)
            {
                foodConsumption = 3;
                woodGain = 2;
            }
            else { foodConsumption = 2; woodGain = 3; }

            nTWood3 = 0;
            nTClay1 = 0;
            nTReed1 = 0;
            nFishing = 0;
            nSheep = 0;
            nStoneStage2 = 0;
            nBoars = 0;
            nStoneStage4 = 0;
            nCattle = 0;

            availableMajImprov = new bool[10];
            for (int i = 0; i < 10; i++) { availableMajImprov[i] = true; }

            enabledRoundCards = new bool[14];
            for (int i = 0; i < 14; i++) { enabledRoundCards[i] = false; }

            roundCardOrder = new int[14];
            for (int i = 0; i < 14; i++) { roundCardOrder[i] = i; }
            int r1; int r2; int temp;
            for (int i = 0; i < 7; i++)
            {
                r1 = r.Next(0, 4);
                r2 = r.Next(0, 4);
                temp = roundCardOrder[r1]; roundCardOrder[r1] = roundCardOrder[r2]; roundCardOrder[r2] = temp;
                r1 = r.Next(4, 7);
                r2 = r.Next(4, 7);
                temp = roundCardOrder[r1]; roundCardOrder[r1] = roundCardOrder[r2]; roundCardOrder[r2] = temp;
                r1 = r.Next(7, 9);
                r2 = r.Next(7, 9);
                temp = roundCardOrder[r1]; roundCardOrder[r1] = roundCardOrder[r2]; roundCardOrder[r2] = temp;
                r1 = r.Next(9, 11);
                r2 = r.Next(9, 11);
                temp = roundCardOrder[r1]; roundCardOrder[r1] = roundCardOrder[r2]; roundCardOrder[r2] = temp;
                r1 = r.Next(11, 13);
                r2 = r.Next(11, 13);
                temp = roundCardOrder[r1]; roundCardOrder[r1] = roundCardOrder[r2]; roundCardOrder[r2] = temp;
            }

        }

        public void initializePlayers(MainBoard m)
        {
            players = new PlayerBoard[nPlayers];
            for (int i = 0; i < nPlayers; i++) { players[i] = new PlayerBoard(i,this,m); }
        }
    }
}
