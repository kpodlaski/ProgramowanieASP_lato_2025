using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.IO;
using System.Windows.Threading;

namespace BallSimulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        internal List<Ball> Balls = new List<Ball>();
        private Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
            Ball.CanvasWidth = (int) DrawingCanvas.Width;
            Ball.CanvasHeight = (int) DrawingCanvas.Height;
            HashSet<int> coords = new HashSet<int>();
            int nx =  (int) (DrawingCanvas.Width / (2* Ball.BallRadius));
            int ny = (int)(DrawingCanvas.Height / (2* Ball.BallRadius));
            while (coords.Count< 50)
            {
                int x = rnd.Next(nx);
                int y = rnd.Next(ny);
                if (coords.Contains(10000 * x + y)) continue;
                coords.Add(1000 * x + y);
                Balls.Add(new Ball(this, x* (2*Ball.BallRadius+1), y*(2*Ball.BallRadius+1)));
                Debug.WriteLine(coords.Count);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            foreach (Ball ball in Balls)
                ball.Start();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Ball ball in Balls)
                ball.Reset();
        }

        public void NewEllipse(Ball ball)
        {
            Dispatcher.Invoke(() =>
            {   Ellipse ellipse = new Ellipse();
                ellipse.Height = 2*Ball.BallRadius;
                ellipse.Width = 2 * Ball.BallRadius;
                Color randomColor = Color.FromRgb((byte) rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256));
                ellipse.Fill = new SolidColorBrush(randomColor);
                ellipse.Stroke = System.Windows.Media.Brushes.Black;
                ellipse.StrokeThickness = 1;
                DrawingCanvas.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, ball.X);
                Canvas.SetTop(ellipse, ball.Y);
                ball.Ellipse = ellipse;
                
            });
        }

        public void DrawShape(Shape shape, double X, double Y)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, 
                ()=> {
                Canvas.SetLeft(shape, X);
                Canvas.SetTop(shape, Y);
            });
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure?", "",
                                                  MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            foreach (Ball ball in Balls)
                ball.Stop();
            Thread.Sleep(40);
            base.OnClosing(e);
        }



    }
}