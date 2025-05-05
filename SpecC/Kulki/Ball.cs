using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Kulki
{
    public class Ball
    {
        double X, Y, Vx, Vy;
        Ellipse Ellipse;
        Thread thread;
        private bool isRunning;

        public Ball(double x, double y, Ellipse e)
        {
            this.X = x;
            this.Y = y;
            Vx = 2;
            Vy = -1;
            Ellipse = e;
            thread = new Thread(new ThreadStart(livecycle));

        }

        private void livecycle()
        {
            isRunning = true;
            while (isRunning)
            {
                updatePosition();
                checkCollisions();
                reDraw();
                Thread.Sleep(30);
            }
        }

        private void reDraw()
        {
            Ellipse.Dispatcher.Invoke(new Action(() =>
            {
                Canvas.SetLeft(Ellipse, X);
                Canvas.SetTop(Ellipse, Y);
            } ));
        }

        private void checkCollisions()
        {
            //TODO
        }

        private void updatePosition()
        {
            X += Vx;
            Y += Vy;
        }

        internal void Start()
        {
            thread.Start();
        }

        internal void Stop()
        {
            isRunning=false;
        }
    }
}
