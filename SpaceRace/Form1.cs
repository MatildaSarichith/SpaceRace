using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceRace
{
    public partial class Form1 : Form
    {
        Rectangle player1 = new Rectangle(200, 150, 20, 20);
        SolidBrush pinkBrush = new SolidBrush(Color.Pink);
        int playerSpeed = 10;

        Rectangle player2 = new Rectangle(200, 150, 20, 20);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);

        List<Rectangle> asteroidsLeft = new List<Rectangle>();
        List<Rectangle> asteroidsRight = new List<Rectangle>();

        List<Rectangle> astroids = new List<Rectangle>();
        List<int> astroidSpeed = new List<int>();
        int astroidSize = 10;

        int player1Score = 0;
        int player2Score = 0;

        bool wDown = false;
        bool sDown = false;
        bool upDown = false;
        bool downDown = false;

        string gameState = "Waiting";

        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            player1ScoreLabel.Visible = true;
            player2ScoreLabel.Visible = true;

            player1.Location = new Point(250, this.Height - player1.Height);
            player2.Location = new Point(550, this.Height - player1.Height);

            gameTimer.Enabled = true;
            gameState = "running";

            player1Score = 0;
            player2Score = 0;

            astroids.Clear();
            astroidSpeed.Clear();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Space: 
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           if (gameState == "Running")
            {
                // draw players
                e.Graphics.FillRectangle(pinkBrush, player1);
                e.Graphics.FillRectangle(blueBrush, player2);

                for (int i = 0; i < astroids.Count; i++)
                {
                    // draw asteroids
                    e.Graphics.FillRectangle(blueBrush,astroids[i]);
                }
            }
           
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // move player 1
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            // move player 2
            if (upDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            // move astroids
            for (int i = 0; i < astroids.Count;i++)
            {
                int x = astroids[i].X + astroidSpeed[i];
                astroids[i] = new Rectangle(x, astroids[i].Y, 20, astroidSize);
            }

            // when player reaches top +1 point, player restarts at bottom
            if (player1.Y == 0)
            {
                player1.Y = this.Height - player1.Height;
                player1Score++;
                player1ScoreLabel.Text = $"{player1Score}";
            }
            else if (player2.Y == 0)
            {
                player2.Y = this.Height - player2.Height;
                player1Score++;
                player2ScoreLabel.Text = $"{player2Score}";
            }

            // first player to 3 points wins 
            if (player1Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
            }
            else if (player2Score == 3)
            {
                gameTimer.Enabled = false;
                gameState = "over";
            }

            Refresh();            
        }
    }
}
