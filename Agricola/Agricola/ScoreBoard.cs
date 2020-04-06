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
    public partial class ScoreBoard : Form
    {
    	private MyBox[] boxes;
    	
        public ScoreBoard()
        {
            InitializeComponent();
        }

        public ScoreBoard(GameSetup g)
        {
            InitializeComponent();
            
            boxes = new MyBox[50];
            for(int i = 0; i < 50; i++)
        	{
        		boxes[i] = new MyBox();
        		this.Controls.Add(boxes[i].box);
        	}
            
            for(int i = 0; i < 10; i++)
        	{
        		for(int j = 0; j < 5; j++)
        		{
        			string name = "textBox";
        			name.Insert(6,(i*5+j).ToString());
		        	this.boxes[i*5+j].box.Location = new System.Drawing.Point(65+j*50, 36+i*24);
		        	this.boxes[i*5+j].box.Margin = new System.Windows.Forms.Padding(4);
		        	this.boxes[i*5+j].box.Name = name;
		        	this.boxes[i*5+j].box.ReadOnly = true;
		        	this.boxes[i*5+j].box.Size = new System.Drawing.Size(45, 22);
		        	this.boxes[i*5+j].box.TabIndex = 1;
		        	this.boxes[i*5+j].box.Text = "0";
		        	this.boxes[i*5+j].box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        		}
        	}
            scoring(g);
        }

        public void scoring(GameSetup g)
        {           
            
            for (int i = 0; i < g.nPlayers; i++)
            {
                PlayerBoard player = g.players[i];
                int crops = 0;
                int animals = 0;
                int fields = 0;
                int pastures = 0;
                int rooms = 0;
                int empty = 0;
                int stables = 0;
                int cards = 0;
                int people = 0;
                int score = 0;
                
                int grain = player.resources[4];
                int veg = player.resources[5];

                for (int j = 0; j < 15; j++)
                {
                    if (player.farmSpaces[j] == 'e') { empty--; }
                    if (player.farmSpaces[j] == 'c') { rooms++; }
                    if (player.farmSpaces[j] == 's') { rooms += 2; }
                    if (player.farmSpaces[j] == 'h') { stables++; }
                    if (player.farmSpaces[j] == 'u') { veg++; }
                    if (player.farmSpaces[j] == 'v') { veg += 2; }
                    if (player.farmSpaces[j] == 'x') { grain++; }
                    if (player.farmSpaces[j] == 'y') { grain += 2; }
                    if (player.farmSpaces[j] == 'z') { grain += 3; }
                }

                if (player.nFields >= 5) { fields = 4; }
                else if (player.nFields <= 1) { fields--; }
                else { fields = player.nFields - 1; }

                if (player.pastureCounter >= 5) { pastures = 4; }
                else if (player.pastureCounter == 1) { pastures--; } //PastureConter starts at 1
                else { pastures = player.pastureCounter - 1; }

                if (grain >= 8) { crops += 4; }
                else if (grain == 0) { crops--; }
                else if (grain == 1) { crops++; }
                else { crops += grain / 2; }

                if (veg >= 4) { crops += 4; }
                else if (veg == 0) { crops--; }
                else { crops += veg; }

                if (player.resources[6] >= 8) { animals += 4; } //Sheep
                else if (player.resources[6] == 0) { animals--; }
                else if (player.resources[6] == 1) { animals++; }
                else { animals += player.resources[6] / 2; }

                if (player.resources[7] >= 7) { animals += 4; } //Boars
                else if (player.resources[7] == 0) { animals--; }
                else { animals += (player.resources[7]+1) / 2; }

                if (player.resources[8] >= 6) { animals += 4; } //Cattle
                else if (player.resources[8] == 0) { animals--; }
                else { animals += player.resources[8] / 2 + 1; }

                people += player.maxMembers * 3;
                cards += player.baseScore; //Base score from cards

                if (player.boughtMajImprov[7])
                {
                    if (player.resources[0] >= 7) { cards += 3; }
                    else if (player.resources[0] >= 5) { cards += 2; }
                    else if (player.resources[0] >= 3) { cards += 1; }
                }

                if (player.boughtMajImprov[8])
                {
                    if (player.resources[1] >= 7) { cards += 3; }
                    else if (player.resources[1] >= 5) { cards += 2; }
                    else if (player.resources[1] >= 3) { cards += 1; }
                }

                if (player.boughtMajImprov[9])
                {
                    if (player.resources[2] >= 5) { cards += 3; }
                    else if (player.resources[2] >= 4) { cards += 2; }
                    else if (player.resources[2] >= 2) { cards += 1; }
                }
                
                score = crops + fields + animals + pastures + empty + stables + people + cards + rooms;
                
                this.boxes[i].box.Text = crops.ToString();
                this.boxes[5+i].box.Text = animals.ToString();
                this.boxes[10+i].box.Text = pastures.ToString();
                this.boxes[15+i].box.Text = fields.ToString();
                this.boxes[20+i].box.Text = empty.ToString();
                this.boxes[25+i].box.Text = rooms.ToString();
                this.boxes[30+i].box.Text = cards.ToString();
                this.boxes[35+i].box.Text = stables.ToString();                
                this.boxes[40+i].box.Text = people.ToString();
                this.boxes[45+i].box.Text = score.ToString();
            }

        }


    }
    
    class MyBox
    {
    		public System.Windows.Forms.TextBox box;
    		
    		public MyBox()
    		{
    			box = new System.Windows.Forms.TextBox();
    		}
    }
}
