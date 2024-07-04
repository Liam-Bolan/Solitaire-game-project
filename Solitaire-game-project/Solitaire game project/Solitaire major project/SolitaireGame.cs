﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Solitaire_major_project
{
    public partial class SolitaireGame : Form
    {
        static List<Card> CardsOnScreen = new List<Card>();
        static List<acebox> aceboxes = new List<acebox>();
        static List<Card>[] CardColumn = new List<Card>[8];
        static List<Card>[] SuitPiles = new List<Card>[4];
        static List<Card> GamePile = new List<Card>();
        static Card[] TurnedCards = new Card[3];
        static deck deck = new deck();
        int pos = 0;
        public SolitaireGame()
        {
            InitializeComponent();
        }
        

        private void SolitaireGame_Load(object sender, EventArgs e)
        {
            
        
            deck.Shuffle();
            pictureBox1.Top = 53;
            pictureBox1.Left = 55;
            pictureBox1.Width = 115;
            pictureBox1.Height = 170;
            pictureBox1.BringToFront();
            boxdeck boxdeck = new boxdeck();
          
            for (int i = 24; i > 0; i--)
            {
                Card c = deck.Draw();
                c.GameLoc = "GamePile";
                c.Location = new Point(55, 53);
                c.Parent = this;
                GamePile.Add(c);
            }

            PictureBox drawButton = new PictureBox();
            


            for (int cols = 7; cols >0; cols--)
            {
                CardColumn[cols] = new List<Card>();
                for (int i = cols; i > 0; i--)
                {

                    Card c = deck.Draw();
                    c.GameLoc = "Column" + cols;
                    CardColumn[cols].Add(c);
                    if (i == cols) { c.flip(); }
                    c.Location = new Point(975 - (150*(7-cols)), 300 + 10 * i);
                    c.Parent = this;

                }

            }

            for(int i = 0; i < 4; i++)
            { 
                acebox a = new acebox();
                SuitPiles[i] = new List<Card>();
                a.Location = new Point(585+130 * i,50);
                a.Parent = this;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SolitaireGame_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle Mouse = new Rectangle(e.X, e.Y, 1, 1);
            Rectangle GamePileRect = new Rectangle(55, 53, 115, 170);
            if (GamePileRect.IntersectsWith(Mouse))
            {
                Card d1 = GamePile[0];
                d1.Left = 180;
                d1.flip();
                Card d2 = GamePile[1];
                d2.Left = 200;
                d2.flip();

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            int pos2 = 250;

            
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (TurnedCards[i] != null)
                    { 
                        TurnedCards[i].flip();
                        TurnedCards[i].Left = 55;
                        TurnedCards[i].Top = 53;
                        TurnedCards[i] = null;
                    }
                    TurnedCards[i] = GamePile[pos];
                    TurnedCards[i].flip();
                    TurnedCards[i].Left += pos2;

                    pos2 -= 60;
                    pos++;
                }
   
                
            }
        }
    }
}
