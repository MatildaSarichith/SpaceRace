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
        int player1Speed = 10;

        Rectangle player2 = new Rectangle(200, 150, 20, 20);
        SolidBrush blueBrush = new SolidBrush(Color.Blue);
        int player2Speed = 10;

        List<Rectangle> obstaclesLeft = new List<Rectangle>();
        List<Rectangle> obstaclesRight = new List<Rectangle>();

        List<Rectangle> astroids = new List<Rectangle>();
        List<int> ballSpeeds = new List<int>();
        List<string> ballColours = new List<string>();
        int ballSize = 10;

        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
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
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(pinkBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // move player 1
            if (upDown == true && player1.Y > 0)
            {
                player1.Y -= player1Speed;
            }

            if (downDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += player1Speed;
            }

            // move player 2
            if (upDown == true && player2.Y > 0)
            {
                player2.Y -= player2Speed;
            }

            if (downDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += player2Speed;
            }

            
        }
    }
}
