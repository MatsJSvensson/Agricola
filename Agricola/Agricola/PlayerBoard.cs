using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agricola
{
    public class PlayerBoard
    {
        public char[] farmSpaces; //Type of tile
        /*
          w - wooden room
          c - clay room
          s - stone room
          f - field
          x - field with 1 grain
          y - field with 2 grain
          z - field with 3 grain
          u - field with 1 vegetable
          v - field with 2 vegetables
          p - pasture
          b - stable
          h - fenced stable      
        */ 
        public int playerNumber;
        public Form1 board;
        public int[] resources { get; set; } //Wood, Clay, Stone, Reed, Grain, Veg, Sheep, Boars, Cattle, Food
        public int maxMembers;
        public int currentMembers;
        public int newBorn;
        public int baseScore; //Base score from cards
        public int nRooms;
        public int houseType; //Type of house (0/1/2)
        public char houseSort; //Type of house (wood/clay/stone)
        public int nStables;
        public int nFields;
        public int nFences;
        public bool[] boughtMajImprov; //List of all major improvements. True if bought
        public bool[] builtFences; //Fences built and confirmed
        public bool[] preliminaryFences; //Fences built under fencing phase
        public bool[] pastureIndicator; //Indicates if tile x is part of any pasture (temporary)
        public int[][] pastureMembers; //Lists the tiles (y) included in pasture x
        public int[] pastureSizes; //Indicates the size of pasture x
        public int pastureCounter; //Number of pastures + 1
        public int[] pastureIndices; //Number of tiles in pasture x
        public int[] pastureRace; //Type of animal in pasture x
        public int[] pastureInhabitants; //Number of animals in pasture x
        public int resourceChosen;
        public int[] livestockAllocated;
        public bool[] stableUsed;
            

        public PlayerBoard(int n, GameSetup g, MainBoard m)
        {
            playerNumber = n;
            maxMembers = 2;
            currentMembers = 0;
            newBorn = 0;
            baseScore = 0;
            nRooms = 2;
            houseType = 0;
            houseSort = 'w';
            nFields = 0;
            nStables = 0;
            nFences = 0;
            resourceChosen = 0;

            farmSpaces = new char[15];
            for (int i = 0; i < 15; i++) { farmSpaces[i] = 'e'; }
            farmSpaces[5] = 'w';
            farmSpaces[10] = 'w';

            resources = new int[10];
            for (int i = 0; i < 9; i++) { resources[i] = 0; }
            if (playerNumber == g.startingPlayer) { resources[9] = 2; }
            else { resources[9] = 3; }

            boughtMajImprov = new bool[10];
            for(int i = 0; i < 10; i++) { boughtMajImprov[i] = false; }

            builtFences = new bool[38];
            for (int i = 0; i < 10; i++) { builtFences[i] = false; }
            preliminaryFences = new bool[38];
            for (int i = 0; i < 10; i++) { preliminaryFences[i] = false; }

            pastureIndicator = new bool[15];
            for (int i = 0; i < 15; i++) { pastureIndicator[i] = false; }

            pastureSizes = new int[6];
            pastureSizes[0] = 1;
            for (int i = 1; i < 6; i++) { pastureSizes[i] = 0; }

            pastureMembers = new int[6][];
            for (int i = 0; i < 6; i++)
            {
                pastureMembers[i] = new int[12];
                for (int j = 0; j < 12; j++)
                {
                    pastureMembers[i][j] = -1;
                }
            }

            pastureCounter = 1;
            pastureIndices = new int[6];
            for (int i = 0; i < 6; i++) { pastureIndices[i] = 0; }

            pastureInhabitants = new int[6];
            for (int i = 0; i < 6; i++) { pastureInhabitants[i] = 0; }

            pastureRace = new int[6];
            for (int i = 0; i < 6; i++) { pastureRace[i] = -1; }

            livestockAllocated = new int[3];
            for (int i = 0; i < 3; i++) { livestockAllocated[i] = 0; }

            stableUsed = new bool[15];
            for (int i = 0; i < 15; i++) { stableUsed[i] = false; }

            board = new Form1(g,playerNumber,m);
            board.Text = System.String.Format("Player {0}", playerNumber+1);
        }
    }
}
