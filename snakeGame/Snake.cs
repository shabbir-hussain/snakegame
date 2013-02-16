using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace snakeGame
{
  
    class Snake
    {
        private Rectangle[] snakebody;
        private SolidBrush brush;
        private int width, height;
        private Point position;
        private double velocityX;
        private double velocityY;
        private Point velocity;
        private double accel;
        private double angle;

        public Snake()
        {
            snakebody = new Rectangle[3];
            brush = new SolidBrush(Color.Azure);

            position.X = 20;
            position.Y = 0;
            width = 10;
            height = 10;

            velocity = new Point(0, 0);
            velocityX =1;
            velocityY =0;
            accel = 0;
            angle = 0;

            for (int i = 0; i < snakebody.Length; i++)
            {
                snakebody[i] = new Rectangle(position.X-(10*i), position.Y, width, height);
                
            }
        }

        public void drawSnake(Graphics paper)
        {
            //draw
            for (int i = 0; i < snakebody.Length;i++)
            {
                paper.FillRectangle(brush, snakebody[i]);
            }
        }

        public void UpdateSnake()
        {
            //update acceleration
            velocityX += (System.Math.Cos(angle)*accel);
            velocityY += (System.Math.Sin(angle) * accel);
            accel = 0;

            velocity.X = (int)velocityX;
            velocity.Y = (int)velocityY;

            position = add(position, velocity);

            for(int i=0; i < snakebody.Length; i++)
            {
                snakebody[i].Location = add(snakebody[i].Location, velocity);
            }

        }


        public void snakeAccel()
        {
            accel += 0.5;
            if (accel > 2)
                accel -= 0.5;
        }
        public void snakeDecel()
        {
            accel -= 0.5;
            if (accel < -2)
                accel += 0.5;
        }

        //helper
        public Point add(Point p1, Point p2)
        {
            Point res = new Point(p1.X + p2.X, p1.Y + p2.Y);
            return res;
        }
    }
}
