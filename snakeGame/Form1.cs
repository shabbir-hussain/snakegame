using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace snakeGame
{
    public partial class Form1 : Form
    {

        Graphics paper;
        Snake snake = new Snake();

        bool upArrow = false;
        bool downArrow = false;

        public Form1()
        {
            InitializeComponent();
        }

        //get key state
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    upArrow = true;
                    break;
                case Keys.Down:
                    downArrow = true;
                    break;
                default:
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    upArrow = false;
                    break;
                case Keys.Down:
                    downArrow = false;
                    break;
                default:
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            snake.drawSnake(paper);
        }

        //update
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (upArrow)
                snake.snakeAccel();
            if (downArrow)
                snake.snakeDecel();

            snake.UpdateSnake();
            this.Invalidate();
        }


    }
}
