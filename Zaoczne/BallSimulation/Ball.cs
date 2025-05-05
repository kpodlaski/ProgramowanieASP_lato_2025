using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BallSimulation
{
    public class Ball
    {
        private MainWindow window;
        public Ellipse Ellipse;
        private Thread thread = null;
        private volatile bool isRunning = false;
        private volatile bool isColiding  = false;
        public static int CanvasWidth = 700;
        public static int CanvasHeight = 400;
        public static int BallRadius = 8;

        public Ball(MainWindow window, double x, double y)
        {
            this.window = window;
            this.X = x;
            this.Y = y;
            Reset();
            window.NewEllipse(this);
        }

        

        public double X { get; private set; }
        public double Y { get; private set; }
        
        public double V { get; private set; }
        public double Vx { get; private set; }
        public double Vy { get; private set; }

        

        public void Reset()
        {
            Random rand = new Random(); 
            Vx = rand.NextDouble() * 4 - 2;
            Vy = rand.NextDouble() * 4 - 2;
            V = Math.Sqrt(Vx*Vx+ Vy*Vy);
        }

        public void MoveXY(double dx, double dy){
            X += dx;
            Y += dy;
        }
        private void move(){
            MoveXY(Vx, Vy);
        }
        private void animation(){
            while (isRunning){
                move();
                collisions();
                draw();
                Thread.Sleep(30);
            }
        }

        private double distance(Ball b)
        {
            return (this.X - b.X) * (this.X - b.X) + (this.Y - b.Y) * (this.Y - b.Y);
        }

        private void collisions()
        {
            if (X - BallRadius < 0) { X = BallRadius; Vx = -Vx; }
            if (Y - BallRadius< 0) {  Y = BallRadius; Vy = -Vy; }
            if (X + BallRadius > CanvasWidth) { X = CanvasWidth - BallRadius; Vx = -Vx; }
            if (Y + BallRadius> CanvasHeight) { Y = CanvasHeight - BallRadius; Vy = -Vy; }
            foreach (Ball b in window.Balls)
            {
                if (b == this) continue;
                if (distance(b) < 4* BallRadius * BallRadius)
                {
                    if (isColiding) break;
                    if (b.isColiding) continue;
                    exchangeVelocitiesWith(b);
                    Debug.WriteLine("Collision");
                    break;
                }
            }
        }

        private void exchangeVelocitiesWith(Ball b)
        {
            lock (window)
            {   
                this.isColiding = true;
                b.isColiding = true;
                this.Vx += b.Vx;
                b.Vx = this.Vx - b.Vx;
                this.Vx = this.Vx - b.Vx;
                this.Vy += b.Vy;
                b.Vy = this.Vy - b.Vy;
                this.Vy = this.Vy - b.Vy;
                this.isColiding = false;
                b.isColiding = false;
            }
            
        }

        private void draw(){
            window.DrawShape(Ellipse, X-BallRadius, Y-BallRadius);         
        }

        public void Start(){
            if (thread is null){
                thread = new Thread(
                    new ThreadStart(this.animation));
                isRunning = true;
                thread.Start();
            }
        }

        public void Stop()
        {
            isRunning = false;
            thread = null;
        }
    }
}
